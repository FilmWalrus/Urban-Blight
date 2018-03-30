Public Class Turn

#Region " Variables "
    Public CurrentPlayer As Player = Nothing

    Public CitizenList As New List(Of Person)
    Public LocationList As New List(Of CitySquare)

    Public HospitalList As New List(Of Building)

    Public DeadCitizens As New List(Of Person)

    Public NoDeath As Boolean = False
    Public NoEmigration As Boolean = False
    Public NoCrime As Boolean = False

    Public Enum DeathCause
        NaturalCauses
        Illness
        TrafficAccident
        Murder
        Unknown
    End Enum

    Public Enum CrimeType
        ParkingTicket
        TrafficTicket
        Robbery
        Vandalism
        Arson
        Murder
        Unknown
    End Enum

#End Region

#Region " Person Events "

    Public Sub New(ByRef thePlayer As Player, ByVal theYear As Integer)
        CurrentPlayer = thePlayer

        If theYear < 10 Then
            ' Don't let anyone die in the first few turns. It unbalances the game too much.
            NoDeath = True
            NoCrime = True
        End If
        If theYear < 15 Then
            ' Don't let anyone emigrate in the first few turns. It unbalances the game too much.
            NoEmigration = True
        End If
    End Sub

    Sub UpdatePeople()

        '-- Gather all the current player's people
        GatherCitizens()

        '-- Gather all the occupied territory (all players)
        GatherTerritory()

        '-- Gather hospitals (effects births and deaths)
        GatherHospitals()

        '-- Handle business expansions
        BuildingsExpand()

        '-- Grow, live, and learn
        LiveYourLife()

        '-- Have babies
        Reproduce()

        '-- Die
        HandleDeaths()

        '-- Move between locations (can emigrate to other players)
        Travel()

        '-- Visit buildings within range and apply for jobs if unemployed
        Work()

        '-- Commit crimes like theft and murder and get in car accidents
        MajorCrimes()

        '-- Collect taxes from citizens and pay for upkeep of land
        Taxation()

    End Sub


    Sub LiveYourLife()
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Person = CitizenList(i)

            '-- Age and change internally
            thePerson.UpdateInternal()

            Dim originalHome As CitySquare = thePerson.Residence

            '-- Get the odds for traffic tickets
            Dim drivingOdds As Integer = 0
            drivingOdds += thePerson.Criminality / 8.0
            drivingOdds += thePerson.Drunkenness / 4.0
            drivingOdds += thePerson.Mobility / 9.0

            Dim parkingOdds As Integer = 1
            parkingOdds += thePerson.Criminality / 10.0

            'Find all the locations within range (based on the person's mobiility and the quality of roads)
            Dim locationsInRange As New List(Of CitySquare)
            RangeChecker(originalHome, thePerson.Mobility, locationsInRange)

            ' Visit each location in range
            For j As Integer = 0 To locationsInRange.Count - 1
                Dim currentLocation As CitySquare = locationsInRange(j)
                thePerson.AddEvent(currentLocation.GetVisitMethod())
                currentLocation.SetVisitMethod(CitySquare.TransportType.Bike)

                '-- Issue speeding ticket
                If GetRandom(0, 200) < drivingOdds Then
                    thePerson.CommitCrime(CrimeType.ParkingTicket)
                End If

                '-- Visit each building at this location
                For n As Integer = 0 To currentLocation.Buildings.Count - 1

                    '-- Issue parking ticket
                    If GetRandom(0, 200) < parkingOdds Then
                        thePerson.CommitCrime(CrimeType.TrafficTicket)
                    End If

                    '-- Have person potentially visit each building in range for leisure and change due to external factors
                    Dim currentBuilding As Building = currentLocation.Buildings(n)
                    currentBuilding.AffectPerson(thePerson)
                Next
            Next
        Next
    End Sub

    Sub Reproduce()

        Dim EventCount As Integer = 0
        Dim EventCountTwins As Integer = 0
        Dim LocalEvent As String = ""
        Dim LocalEventTwins As String = ""

        '-- Get the adjustment to reproduction based on AI difficulty level (1.0 if current player is human)
        Dim ReproduceAdj As Double = CurrentPlayer.GetReproduceAdjustment()

        Dim thePerson As Person
        For i As Integer = 0 To CitizenList.Count - 1
            thePerson = CitizenList(i)
            thePerson.TouchedKey = 0

            '-- Check if nearby buildings (like the maternity ward) affect the birthrate
            Dim MaternityWardAdj As Double = GetMaternityWardAdjust(thePerson)
            ReproduceAdj *= MaternityWardAdj

            If thePerson.WillReproduce(ReproduceAdj) Then

                Dim homeTown As CitySquare = thePerson.Residence
                Dim newChild As Person = thePerson.Reproduce()
                CitizenList.Add(newChild)

                'Check for twins (very rare)
                Dim newChild2 As Person = Nothing
                Dim TwinOdds As Double = 14 * MaternityWardAdj
                If (GetRandom(0, 1000) < TwinOdds) Then
                    newChild2 = thePerson.Reproduce()
                    CitizenList.Add(newChild2)
                End If

                '--Post Event
                If newChild2 Is Nothing Then
                    EventCount += 1
                    If EventCount >= EventLimit Then
                        LocalEvent = EventCount.ToString() + " citizens had children." + ControlChars.NewLine
                    Else
                        LocalEvent += thePerson.GetNameAndAddress() + " gave birth to " + newChild.Name + "." + ControlChars.NewLine
                    End If
                Else
                    'Twins!!
                    EventCountTwins += 1
                    If EventCountTwins >= EventLimit Then
                        LocalEventTwins = EventCountTwins.ToString() + " citizens had twins." + ControlChars.NewLine
                    Else
                        LocalEventTwins += thePerson.GetNameAndAddress() + " had twins named " + newChild.Name + " and " + newChild2.Name + "." + ControlChars.NewLine
                    End If
                End If

            End If
        Next

        Diary.BirthEvents += LocalEvent + LocalEventTwins
    End Sub

    Sub HandleDeaths()
        Dim EventCountNatural As Integer = 0
        Dim LocalEventNatural As String = ""
        Dim EventCountIllness As Integer = 0
        Dim LocalEventIllness As String = ""
        Dim EventCountAccident As Integer = 0
        Dim LocalEventAccident As String = ""
        Dim LocalCountSaves As Integer = 0
        Dim LocalEventSaves As String = ""

        If NoDeath Then
            Return
        End If

        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Person = CitizenList(i)

            '-- Handle deaths by natural causes
            Dim odds As Double = 0.0
            odds += (thePerson.Age - 20.0) / 4.0
            If thePerson.Health <= 0 Or GetRandom(0, 100) < odds Then
                '-- Attempt to save the life of this citizen
                Dim Rescuer As Building = AttemptToSave(thePerson, DeathCause.NaturalCauses)
                If Rescuer IsNot Nothing Then
                    '-- Citizen was saved!
                    LocalCountSaves += 1
                    If LocalCountSaves >= EventLimit Then
                        LocalEventSaves = LocalCountSaves.ToString() + " lives were saved by hospitals." + ControlChars.NewLine
                    Else
                        LocalEventSaves += Rescuer.GetNameAndAddress() + " saved the life of " + thePerson.GetNameAndAddress() + "." + ControlChars.NewLine
                    End If

                Else
                    If thePerson.Die(DeathCause.NaturalCauses) Then
                        DeadCitizens.Add(thePerson)

                        '--Post Event
                        EventCountNatural += 1
                        If EventCountNatural >= EventLimit Then
                            LocalEventNatural = EventCountNatural.ToString() + " citizens died of natural causes." + ControlChars.NewLine
                        Else
                            LocalEventNatural += thePerson.GetNameAndAddress() + ", age " + thePerson.Age.ToString() + ", died of natural causes." + ControlChars.NewLine
                        End If

                        Continue For
                    End If
                End If
            End If

            '-- Handle deaths by illness
            odds = 0.0
            odds += (32 - thePerson.Health) / 4.0
            If GetRandom(0, 100) < odds Then

                '-- Attempt to save the life of this citizen
                Dim Rescuer As Building = AttemptToSave(thePerson, DeathCause.Illness)
                If Rescuer IsNot Nothing Then
                    '-- Citizen was saved!
                    LocalCountSaves += 1
                    If LocalCountSaves >= EventLimit Then
                        LocalEventSaves = LocalCountSaves.ToString() + " lives were saved by hospitals." + ControlChars.NewLine
                    Else
                        LocalEventSaves += Rescuer.GetNameAndAddress() + " saved the life of " + thePerson.GetNameAndAddress() + "." + ControlChars.NewLine
                    End If

                Else
                    If thePerson.Die(DeathCause.Illness) Then
                        '-- Citizen died
                        DeadCitizens.Add(thePerson)

                        '--Post Event
                        EventCountIllness += 1
                        If EventCountIllness >= EventLimit Then
                            LocalEventIllness = EventCountIllness.ToString() + " citizens died of illness." + ControlChars.NewLine
                        Else
                            LocalEventIllness += thePerson.GetNameAndAddress() + ", age " + thePerson.Age.ToString() + ", died of illness." + ControlChars.NewLine
                        End If

                        '-- Can only die once
                        Continue For
                    End If
                End If
            End If

            '-- Handle deaths by car accident
            Dim currentLocation As CitySquare = thePerson.Residence
            odds = 0.0
            odds += thePerson.Mobility / 10.0
            odds += thePerson.Drunkenness / 4.0
            odds += (currentLocation.getPopulation / 5.0)
            odds -= (currentLocation.Transportation * 2.5)
            If thePerson.Age < 15 Then
                odds /= 2.0
            End If

            If GetRandom(0, 100) <= odds Then
                '-- Attempt to save the life of this citizen
                Dim Rescuer As Building = AttemptToSave(thePerson, DeathCause.TrafficAccident)
                If Rescuer IsNot Nothing Then
                    '-- Citizen was saved!
                    LocalCountSaves += 1
                    If LocalCountSaves >= EventLimit Then
                        LocalEventSaves = LocalCountSaves.ToString() + " lives were saved by hospitals." + ControlChars.NewLine
                    Else
                        LocalEventSaves += Rescuer.GetNameAndAddress() + " saved the life of " + thePerson.GetNameAndAddress() + "." + ControlChars.NewLine
                    End If

                Else
                    If thePerson.Die(DeathCause.TrafficAccident) Then

                        DeadCitizens.Add(thePerson)

                        '--Post Event
                        EventCountAccident += 1
                        If EventCountAccident >= EventLimit Then
                            LocalEventAccident = EventCountAccident.ToString() + " citizens died in traffic accidents." + ControlChars.NewLine
                        Else
                            LocalEventAccident += thePerson.GetNameAndAddress() + ", age " + thePerson.Age.ToString() + ", died in a car accident." + ControlChars.NewLine
                        End If

                        Continue For
                    End If
                End If
            End If

        Next

        PurgeDead()

        Diary.DeathEvents += LocalEventSaves + LocalEventNatural + LocalEventIllness + LocalEventAccident
    End Sub

    Sub Travel()

        Dim InternalCount As Integer = 0
        Dim ExternalCount As Integer = 0
        Dim InternalMove As String = ""
        Dim ExternalMove As String = ""

        Dim thePerson As Person
        For i As Integer = 0 To CitizenList.Count - 1
            thePerson = CitizenList(i)
            Dim originalHome As CitySquare = thePerson.Residence

            'Find all the locations within range (based on the person's mobiility and the quality of roads)
            Dim locationsInRange As New List(Of CitySquare)
            RangeChecker(originalHome, thePerson.Mobility, locationsInRange)

            If locationsInRange.Count > 0 And GetRandom(0, 1) = 1 Then '-- 50% chance of moving if the option presents itself. Seems a little high?

                '-- Sort the movement options based on preference for space, culture or jobs
                Dim localPop As Integer = originalHome.getPopulation()
                If thePerson.Employment = 0 And thePerson.Age >= 16 And GetRandom(0, 30 + thePerson.Mobility) < (38 - localPop) Then
                    '-- Unemployed adults mostly look for jobs
                    SortType = JobSort
                ElseIf GetRandom(0, 80 + thePerson.Mobility) < (30 - localPop) Then
                    '-- If population isn't a problem head towards the most culture
                    SortType = CultureSort
                Else
                    '-- If local population is high, head to lower population area
                    SortType = PopSort
                End If

                locationsInRange.Sort()

                Dim choiceIndex As Integer = GetRandom(0, SafeDivide(locationsInRange.Count - 1, 3.0))
                Dim newHome As CitySquare = locationsInRange(choiceIndex)
                If Not (originalHome.RowID = newHome.RowID And originalHome.ColID = newHome.ColID) Then '-- Only "move" if it is to a new square

                    '-- Happy people are loyal
                    If newHome.OwnerID <> CurrentPlayer.ID Then
                        If NoEmigration Or GetRandom(0, 100) < thePerson.Happiness Then
                            Continue For
                        End If
                    End If

                    '-- People are reluctant to move to the desert
                    If newHome.Terrain = TerrainDesert Then
                        If GetRandom(0, 1) = 0 Then
                            Continue For
                        End If
                    End If

                    '-- Move out of original home
                    originalHome.People.Remove(thePerson)

                    '-- Move into new home
                    newHome.AddPerson(thePerson)
                    thePerson.Residence = newHome

                    Dim OldAddress As String = originalHome.GetName()
                    Dim NewAddress As String = newHome.GetName()

                    If newHome.OwnerID = CurrentPlayer.ID Then
                        '--Post Event for internal move
                        InternalCount += 1
                        If InternalCount >= EventLimit Then
                            InternalMove = InternalCount.ToString() + " citizens moved." + ControlChars.NewLine
                        Else
                            InternalMove += thePerson.Name + " of " + OldAddress + " moved to " + NewAddress + "." + ControlChars.NewLine
                        End If
                    Else
                        '--Post Event for external move
                        ExternalCount += 1
                        If ExternalCount >= EventLimit Then
                            ExternalMove = ExternalCount.ToString() + " citizens emigrated." + ControlChars.NewLine
                        Else
                            ExternalMove += thePerson.Name + " of " + OldAddress + " emigrated to " + NewAddress + "." + ControlChars.NewLine
                        End If
                    End If

                End If
            End If
        Next

        Diary.MoveEvents += InternalMove + ExternalMove

    End Sub

    Sub Work()
        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""

        Dim thePerson As Person
        For i As Integer = 0 To CitizenList.Count - 1
            thePerson = CitizenList(i)

            Dim originalHome As CitySquare = thePerson.Residence

            'Find all the locations within range (based on the person's mobiility and the quality of roads)
            Dim locationsInRange As New List(Of CitySquare)
            RangeChecker(originalHome, thePerson.Mobility, locationsInRange)
            Dim foundJob As Boolean = False

            For j As Integer = 0 To locationsInRange.Count - 1

                Dim currentLocation As CitySquare = locationsInRange(j)

                For n As Integer = 0 To currentLocation.Buildings.Count - 1

                    Dim currentBuilding As Building = currentLocation.Buildings(n)

                    '-- Apply for a job if the building is hiring and the person is interested
                    If currentBuilding.WillHire(thePerson) And thePerson.WillApply(currentBuilding) Then

                        'Hire the employee
                        currentBuilding.HireEmployee(thePerson)
                        foundJob = True

                        If thePerson.Age = 16 Then
                            '-- If employed from an early age, buy a hotrod
                            thePerson.Mobility += GetRandom(3, 4)
                        End If
                    End If
                Next
            Next

            If foundJob Then
                '--Post Event
                EventCount += 1
                If EventCount >= EventLimit Then
                    LocalEvent = EventCount.ToString() + " citizens got new jobs." + ControlChars.NewLine
                Else
                    LocalEvent += thePerson.GetNameAndAddress() + " took a job at the " + thePerson.JobBuilding.GetNameAndAddress() + "." + ControlChars.NewLine
                End If
            End If
        Next

        Diary.HireEvents += LocalEvent
    End Sub

    Sub MajorCrimes()

        If NoCrime Then
            Return
        End If

        Dim TotalBuildings As Integer = CurrentPlayer.GetPlayerDevelopment()

        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""

        Dim LocalEventTheft As String = ""
        Dim LocalEventArson As String = ""
        Dim LocalEventMurder As String = ""

        Dim TheftSum As Integer = 0
        Dim CountTheft As Integer = 0
        Dim CountArson As Integer = 0
        Dim CountMurder As Integer = 0
        Dim CountAccident As Integer = 0
        Dim VictimName As String = ""

        Dim thePerson As Person
        Dim citizenCount As Integer = CitizenList.Count
        For i As Integer = 0 To citizenCount - 1
            thePerson = CitizenList(i)

            '-- No crime for extreme youths
            If (thePerson.Age < 16) Then
                Continue For
            End If

            '-- Theft
            Dim odds As Integer = 0
            odds += thePerson.Criminality / 3.0
            odds -= thePerson.Employment / 5.0
            If GetRandom(0, 100) < odds Then
                Dim theft As Integer = Math.Min(thePerson.Criminality, CurrentPlayer.TotalMoney)
                If thePerson.CommitCrime(CrimeType.Robbery, theft.ToString()) Then
                    CurrentPlayer.TotalMoney -= theft

                    TheftSum += theft
                    CountTheft += 1
                    '--Post Event
                    If CountTheft >= EventLimit Then
                        LocalEventTheft = CountTheft.ToString() + " citizens stole a combined $" + TheftSum.ToString() + "." + ControlChars.NewLine
                    ElseIf theft > 0 Then
                        LocalEventTheft += thePerson.GetNameAndAddress() + " stole $" + theft.ToString + "." + ControlChars.NewLine
                    End If
                End If
                thePerson.RobberyCount += 1

            End If

            Dim currentLocation As CitySquare = thePerson.Residence
            Dim buildingCount As Integer = currentLocation.Buildings.Count
            Dim localPop As Integer = currentLocation.getPopulation()

            '-- Arson
            odds = 0
            odds += thePerson.Criminality / 8.0
            odds -= (thePerson.Happiness - 20) / 10.0
            If GetRandom(0, 150) < odds And buildingCount > 0 And GetRandom(0, 9) < TotalBuildings Then
                Dim targetBuilding As Building = currentLocation.Buildings(GetRandom(0, buildingCount - 1))
                If thePerson.CommitCrime(CrimeType.Arson, targetBuilding.GetNameAndAddress()) Then
                    targetBuilding.Destroy()

                    CountArson += 1
                    '--Post Event
                    If CountMurder >= EventLimit Then
                        LocalEventArson = "Citizens burned down " + CountArson.ToString + " buildings." + ControlChars.NewLine
                    Else
                        LocalEventArson += thePerson.GetNameAndAddress() + " burned down the " + targetBuilding.GetNameAndAddress + "." + ControlChars.NewLine
                    End If
                End If
            End If


            '-- Murder
            odds = 0
            odds += thePerson.Criminality / 6.5
            odds += thePerson.Drunkenness / 9.0
            If GetRandom(0, 100) < odds And localPop > 1 Then
                Dim theVictim As Person = thePerson
                While (theVictim.Equals(thePerson))
                    theVictim = currentLocation.People(GetRandom(0, localPop - 1))
                End While

                '-- Killing spree potential (especially if the crime paid off)
                thePerson.Criminality += GetRandom(4, Math.Min(7, theVictim.Employment / 7.0))

                If theVictim.Die(DeathCause.Murder) Then

                    If thePerson.CommitCrime(CrimeType.Murder, theVictim.GetNameAndAddress()) Then
                        DeadCitizens.Add(theVictim)

                        CountMurder += 1
                        '--Post Event
                        If CountMurder >= EventLimit Then
                            LocalEventMurder = CountMurder.ToString + " citizens were murdered." + ControlChars.NewLine
                        Else
                            LocalEventMurder += thePerson.GetNameAndAddress() + " killed " + theVictim.Name + "." + ControlChars.NewLine
                        End If
                    End If
                End If
            End If
        Next

        PurgeDead()

        Diary.DeathEvents += LocalEventMurder
        Diary.CrimeEvents += LocalEventTheft + LocalEventArson
    End Sub

    Sub Taxation()
        '-- Collect taxes from citizens
        Dim RegularTaxRate As Integer = 5
        Dim DependentTaxRate As Integer = 2
        Dim EmployedTaxRate As Integer = 3

        '-- Income
        Dim revenue As Integer = 0
        Dim trafficFines As Integer = 0
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Person = CitizenList(i)

            '-- Collect taxes for each person
            Dim personalTax As Integer = 0
            If thePerson.Age < 16 Then
                personalTax += DependentTaxRate '-- Children (dependents) don't pay as much tax
            Else
                personalTax += RegularTaxRate '-- Adults pay the full standard rate
            End If

            If thePerson.JobBuilding IsNot Nothing Then
                '-- Employed citizens pay higher rates
                personalTax += EmployedTaxRate
            End If

            '-- Collect unpaid fines (e.g. traffic tickets) then clear the citizen's debt
            trafficFines += thePerson.UnpaidFines
            thePerson.UnpaidFines = 0

            '-- Townships take their cut
            If thePerson.Residence.Terrain = TerrainTownship Then
                personalTax = Math.Floor(personalTax * 0.8)
            End If

            revenue += personalTax
        Next

        '-- Get the adjustment to taxes based on AI difficulty level (1.0 if current player is human)
        Dim TaxAdj As Double = CurrentPlayer.GetTaxAdjustment()
        revenue *= TaxAdj

        '-- Pay upkeep on the land
        Dim upkeep As Integer = 0
        For i As Integer = 0 To LocationList.Count - 1
            Dim theLocation As CitySquare = LocationList(i)

            If theLocation.Terrain = TerrainDirt Then '-- Dirt has lower upkeep
                upkeep += 8
            ElseIf theLocation.Terrain = TerrainSwamp Then '-- Swamp has higher upkeep
                upkeep += 15
            Else
                upkeep += 10
            End If
        Next

        If CurrentPlayer.TotalTerritory > 1 Then
            '-- Upkeep never exceeds (territory / 10)% of your revenue
            Dim maxUpkeepFraction As Double = CurrentPlayer.TotalTerritory / 10
            Dim revenueFraction As Double = revenue * maxUpkeepFraction
            If upkeep > revenueFraction Then
                upkeep = revenueFraction
            End If
        Else
            '-- No upkeep until you have more than 3 territories
            upkeep = 0
        End If


        Dim FinancialString As String = "You collected $" + revenue.ToString() + " in taxes." + ControlChars.NewLine
        If trafficFines > 0 Then
            FinancialString += "You collected $" + trafficFines.ToString() + " in traffic fines." + ControlChars.NewLine
        End If
        If upkeep > 0 Then
            FinancialString += "You payed $" + upkeep.ToString() + " in upkeep." + ControlChars.NewLine
        End If
        Diary.TaxEvents = FinancialString

        '-- Update the player's money
        CurrentPlayer.TotalMoney += revenue + trafficFines - upkeep
    End Sub



#End Region

#Region " Building Events "

    Sub BuildingsExpand()
        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""

        '-- The success rate of a building is current = to the sum of the employment stat of employees
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Person = CitizenList(i)

            If thePerson.JobBuilding IsNot Nothing Then
                'Update success of job
                thePerson.JobBuilding.Success += thePerson.Employment
            End If
        Next

        '-- Expanding buildings that are successful
        '-- Currently based on employee quality. Eventually should take into account number of visitors
        For i As Integer = 0 To LocationList.Count - 1
            Dim theLocation As CitySquare = LocationList(i)

            For k As Integer = 0 To theLocation.Buildings.Count - 1
                Dim theBuilding As Building = theLocation.Buildings(k)

                '-- Update the buildings age and other info
                If Not theBuilding.UpdateInternal() Then
                    Continue For
                End If

                '-- Check if the building expanded
                If theBuilding.CheckSuccess() Then
                    '--Post Event
                    EventCount += 1
                    If EventCount >= EventLimit Then
                        LocalEvent = EventCount.ToString() + " businesses expanded." + ControlChars.NewLine
                    Else
                        LocalEvent += theBuilding.GetNameAndAddress() + " expanded to capacity " + theBuilding.Jobs.ToString + "." + ControlChars.NewLine
                    End If
                End If

                '-- Clear success at the end
                theBuilding.Success = 0
            Next
        Next

        Diary.ExpansionEvents += LocalEvent
    End Sub

#End Region

#Region " Hospital Stuff "

    Sub GatherHospitals()

        HospitalList.Clear()

        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)

                '-- Add all medical buildings at this location
                HospitalList.AddRange(thisLocation.GetBuildingsByTag(BuildingGen.TagEnum.Medical))
            Next
        Next

    End Sub

    Function AttemptToSave(ByRef thePerson As Person, ByVal causeOfDeath As Integer) As Building

        For i As Integer = 0 To HospitalList.Count - 1
            If HospitalList(i).SavePatient(thePerson, causeOfDeath) Then
                Return HospitalList(i)
            End If
        Next

        Return Nothing
    End Function

    Function GetMaternityWardAdjust(ByRef thePerson As Person) As Double

        Dim BirthrateAdjust As Double = 1.0
        For i As Integer = 0 To HospitalList.Count - 1
            BirthrateAdjust *= HospitalList(i).GetBirthrateAdjust(thePerson)
        Next

        Return BirthrateAdjust
    End Function

#End Region

#Region " Support "
    Sub GatherCitizens()

        CitizenList.Clear()

        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = CurrentPlayer.ID Then
                    Dim localPop As Integer = GridArray(i, j).getPopulation()
                    For k As Integer = 0 To localPop - 1
                        Dim thePerson As Person = GridArray(i, j).People(k)
                        thePerson.JourneyString = "" '-- Clear their journey string
                        CitizenList.Add(thePerson)
                    Next
                End If
            Next
        Next

    End Sub

    Sub GatherTerritory()

        LocationList.Clear()

        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = CurrentPlayer.ID Then
                    LocationList.Add(GridArray(i, j))
                End If
            Next
        Next

    End Sub

    Sub PurgeDead()
        For i As Integer = 0 To DeadCitizens.Count - 1
            Dim DeadCitizen As Person = DeadCitizens(i)
            CitizenList.Remove(DeadCitizen)
        Next
        DeadCitizens.Clear()
    End Sub

    Sub ClearVisited()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)
                If thisLocation.OwnerID >= 0 Then
                    thisLocation.VisitedKey = 0
                    thisLocation.DragLoss = -1
                End If
            Next
        Next
    End Sub

    Sub RangeChecker(ByRef location As CitySquare, ByVal Mobility As Integer, ByRef visitList As List(Of CitySquare))
        ClearVisited()

        '-- Travel outward from this location
        TravelOnward(location, Mobility)

        '-- Add every location that was visited during the travel to the visitList
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)
                If thisLocation.OwnerID >= 0 And thisLocation.VisitedKey > 0 Then
                    visitList.Add(thisLocation)

                    '-- Clear the visit info while we are here
                    thisLocation.VisitedKey = 0
                    thisLocation.DragLoss = -1
                End If
            Next
        Next
    End Sub

    Sub TravelOnward(ByRef location As CitySquare, ByVal Mobility As Integer)
        '-- Make sure this location is habited and that we didn't already reach here some faster way
        If location.VisitedKey > Mobility Or location.OwnerID < 0 Then
            Return
        End If

        '-- Mark as an official visit with the current mobility and visit method (like bike, car, plane, etc)
        location.VisitedKey = Mobility
        location.SetVisitMethod(location.VisitMethodAttempt)

        '-- (Don't recalculate the drag loss if we've been here already)
        If location.DragLoss < 0 Then
            '-- Poor roads make travel difficult
            'Dim DragLoss1 As Integer = (7 - GetRandom(0, location.Transportation + 2))
            Dim DragLoss1 As Integer = (5 - GetRandom(0, location.Transportation))
            Dim DragLoss2 As Integer = (5 - GetRandom(0, location.Transportation))
            location.DragLoss = (DragLoss1 * DragLoss2) + 4
        End If

        Mobility -= location.DragLoss

        '-- Mountains also slow travel
        If location.Terrain = TerrainMountain Then
            Mobility -= 6
        End If

        '-- Check to see if you have enough mobility to continue onward
        If Mobility < 0 Then
            Return
        End If

        '-- Continue traveling to locations adjacent to this location
        Dim adjacentList As List(Of CitySquare) = location.GetAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            TravelOnward(adjacentList(i), Mobility)
        Next
    End Sub

#End Region

End Class

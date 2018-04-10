Public Class Turn

#Region " Variables "
    Public CurrentPlayer As Player = Nothing

    Public CitizenList As New List(Of Citizen)
    Public LocationList As New List(Of CitySquare)

    Public DevelopmentList As New List(Of Building)
    Public HospitalList As New List(Of Building)
    Public CrimePreventerList As New List(Of Building)
    Public FoodCount As Integer

    Public DeadCitizens As New List(Of Citizen)
    Public DestroyedBuildings As New List(Of Building)

    Public NoDeath As Boolean = False
    Public NoEmigration As Boolean = False
    Public NoCrime As Boolean = False

    Public VisitOrder As Integer = 0

    Public Enum DeathCause
        NaturalCauses
        Illness
        TrafficAccident
        Murder
        ResistingArrest
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

        Setup()

        '-- Handle business expansions
        BuildingsExpand()

        '-- Age and change internally
        AgeAndChange()

        '-- Visit buildings, apply for jobs and change residence
        VisitPlaces()

        '-- Have babies
        Reproduce()

        '-- Commit crimes like theft and murder and get in car accidents
        MajorCrimes()

        '-- Die
        HandleDeaths()

        '-- Collect taxes from citizens and pay for upkeep of land
        Taxation()

        Cleanup()
    End Sub

    Sub AgeAndChange()
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Citizen = CitizenList(i)

            '-- Age and change internally
            thePerson.UpdateInternal()
        Next
    End Sub

    Sub VisitPlaces()
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Citizen = CitizenList(i)

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
            RangeChecker(originalHome, thePerson, locationsInRange)

            ' Visit each location in range
            For j As Integer = 0 To locationsInRange.Count - 1
                Dim theLocation As CitySquare = locationsInRange(j)

                '-- Record the visit to this location
                theLocation.VisitHere(thePerson)

                '-- Visit buildings at this location. Apply for jobs if unemployed.
                VisitBuildings(thePerson, theLocation, parkingOdds, drivingOdds)
            Next

            '-- Consider a change of residence (Warning: this changes the order of locations visited)
            ChangeResidence(thePerson, locationsInRange)
        Next
    End Sub

    Sub VisitBuildings(ByRef thePerson As Citizen, ByRef theLocation As CitySquare, ByVal drivingOdds As Double, ByVal parkingOdds As Double)

        '-- Issue speeding ticket
        If GetRandom(0, 200) < drivingOdds Then
            thePerson.CommitCrime(CrimeType.ParkingTicket)
        End If

        '-- Visit each building at this location
        Dim foundJob As Boolean = False
        For n As Integer = 0 To theLocation.Buildings.Count - 1

            '-- Issue parking ticket
            If GetRandom(0, 200) < parkingOdds Then
                thePerson.CommitCrime(CrimeType.TrafficTicket)
            End If

            '-- Have person potentially visit each building in range for leisure and change due to external factors
            Dim currentBuilding As Building = theLocation.Buildings(n)
            currentBuilding.AffectPerson(thePerson)

            '-- See if this building will hire the person
            If currentBuilding.WillHire(thePerson) Then
                'Hire the employee
                currentBuilding.HireEmployee(thePerson)
            End If
        Next

        '-- If you work at a building, you are affected by it an extra time.
        If thePerson.JobBuilding IsNot Nothing Then
            thePerson.JobBuilding.AffectPerson(thePerson)
        End If

    End Sub

    Sub ChangeResidence(ByRef thePerson As Citizen, ByRef locationsInRange As List(Of CitySquare))

        Dim originalHome As CitySquare = thePerson.Residence

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
                If Not newHome.IsOwned(CurrentPlayer.ID) Then
                    If NoEmigration Or GetRandom(0, 100) < thePerson.Happiness Then
                        Return
                    End If
                End If

                '-- People are reluctant to move to the desert
                If newHome.Terrain = TerrainDesert Then
                    If GetRandom(0, 1) = 0 Then
                        Return
                    End If
                End If

                '-- Move out of original home
                originalHome.People.Remove(thePerson)

                '-- Move into new home
                newHome.AddPerson(thePerson)
                thePerson.Residence = newHome

                Dim OldAddress As String = originalHome.GetName()
                Dim NewAddress As String = newHome.GetName()
                thePerson.AddEvent("Moved from " + OldAddress + " to " + NewAddress)

                If newHome.IsOwned(CurrentPlayer.ID) Then
                    '--Post Event for internal move
                    Diary.MoveEvents.AddEvent(thePerson.Name + " of " + OldAddress + " moved to " + NewAddress)
                Else
                    '--Post Event for external move
                    Diary.EmigrationEvents.AddEvent(thePerson.Name + " of " + OldAddress + " emigrated to " + NewAddress)
                End If

            End If
        End If

    End Sub

    Sub Reproduce()

        Dim EventCount As Integer = 0
        Dim EventCountTwins As Integer = 0
        Dim LocalEvent As String = ""
        Dim LocalEventTwins As String = ""

        '-- Get the adjustment to reproduction based on AI difficulty level (1.0 if current player is human)
        Dim PlayerReproduceAdj As Double = CurrentPlayer.GetReproduceAdjustment()

        Dim thePerson As Citizen
        For i As Integer = 0 To CitizenList.Count - 1
            thePerson = CitizenList(i)
            thePerson.TouchedKey = 0

            '-- Check if nearby buildings (like the maternity ward) affect the birthrate
            Dim MaternityWardAdj As Double = GetMaternityWardAdjust(thePerson)
            Dim FoodAdj As Double = thePerson.Residence.GetFoodAdjust()
            Dim ReproduceAdj As Double = PlayerReproduceAdj * MaternityWardAdj * FoodAdj

            If thePerson.WillReproduce(ReproduceAdj) Then

                Dim homeTown As CitySquare = thePerson.Residence
                Dim newChild As Citizen = thePerson.Reproduce()
                CitizenList.Add(newChild)

                'Check for twins (very rare)
                Dim newChild2 As Citizen = Nothing
                Dim TwinOdds As Double = 14 * ReproduceAdj
                If (GetRandom(0, 1000) < TwinOdds) Then
                    newChild2 = thePerson.Reproduce()
                    CitizenList.Add(newChild2)
                End If

                '--Post Event
                If newChild2 Is Nothing Then
                    Diary.BirthEvents.AddEvent(thePerson.GetNameAndAddress() + " gave birth to " + newChild.Name)
                Else
                    'Twins!!
                    Diary.TwinEvents.AddEvent(thePerson.GetNameAndAddress() + " had twins named " + newChild.Name + " and " + newChild2.Name)
                End If
            End If
        Next
    End Sub

    Sub HandleDeaths()
        If NoDeath Then
            Return
        End If

        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Citizen = CitizenList(i)

            '-- Handle deaths by natural causes
            Dim odds As Double = 0.0
            odds += (thePerson.Age - 20.0) / 4.0
            If thePerson.Health <= 0 Or GetRandom(0, 100) < odds Then
                '-- Attempt to save the life of this citizen
                If Not SaveVictim(thePerson, DeathCause.NaturalCauses) Then
                    If thePerson.Die(DeathCause.NaturalCauses) Then
                        DeadCitizens.Add(thePerson)
                        Diary.DeathNaturalEvents.AddEvent(thePerson.GetNameAndAddress() + ", age " + thePerson.Age.ToString() + ", died of natural causes")
                        Continue For '-- Can only die once
                    End If
                End If
            End If

            '-- Handle deaths by illness
            odds = 0.0
            odds += (32 - thePerson.Health) / 4.0
            If GetRandom(0, 100) < odds Then

                '-- Attempt to save the life of this citizen
                If Not SaveVictim(thePerson, DeathCause.Illness) Then

                    If thePerson.Die(DeathCause.Illness) Then
                        '-- Citizen died
                        DeadCitizens.Add(thePerson)
                        Diary.DeathIllnessEvents.AddEvent(thePerson.GetNameAndAddress() + ", age " + thePerson.Age.ToString() + ", died of illness")
                        Continue For '-- Can only die once
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
                If Not SaveVictim(thePerson, DeathCause.TrafficAccident) Then
                    If thePerson.Die(DeathCause.TrafficAccident) Then
                        DeadCitizens.Add(thePerson)
                        Diary.DeathTrafficEvents.AddEvent(thePerson.GetNameAndAddress() + ", age " + thePerson.Age.ToString() + ", died in a car accident")
                        Continue For '-- Can only die once
                    End If
                End If
            End If

        Next

        PurgeDead()
    End Sub

    Sub MajorCrimes()

        If NoCrime Then
            Return
        End If

        Dim TotalBuildings As Integer = CurrentPlayer.GetPlayerDevelopment()

        Dim thePerson As Citizen
        Dim citizenCount As Integer = CitizenList.Count
        For i As Integer = 0 To citizenCount - 1
            thePerson = CitizenList(i)

            '-- No crime for extreme youths
            If (thePerson.Age < 16) Then
                Continue For
            End If

            Dim CrimeFlag As Boolean = False
            Dim TheftAmount As Integer = 0
            Dim BuildingInsurance As Integer = 0
            Dim PersonalInsurance As Integer = 0

            '-- Theft
            Dim odds As Integer = 0
            odds += thePerson.Criminality / 3.0
            odds -= thePerson.Employment / 5.0
            If GetRandom(0, 100) < odds Then
                Dim theft As Integer = Math.Max(1, Math.Min(thePerson.Criminality, CurrentPlayer.TotalMoney))
                If thePerson.CommitCrime(CrimeType.Robbery, theft.ToString()) Then
                    '-- Attempt to prevent this crime
                    If Not PreventCrime(thePerson, CrimeType.Robbery) Then
                        CrimeFlag = True
                        CurrentPlayer.TotalMoney -= theft
                        TheftAmount = theft
                        Diary.TheftEvents.AddEvent(thePerson.GetNameAndAddress() + " stole $" + theft.ToString)
                        'LocalEventTheft = CountTheft.ToString() + " citizens stole a combined $" + TheftSum.ToString() + "." + ControlChars.NewLine
                    End If
                End If

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
                    '-- Attempt to prevent this crime
                    If Not PreventCrime(thePerson, CrimeType.Arson) Then
                        CrimeFlag = True
                        DestroyedBuildings.Add(targetBuilding)
                        BuildingInsurance += SafeDivide(targetBuilding.GetBaseCost(), 2.0)
                        Diary.ArsonEvents.AddEvent(thePerson.GetNameAndAddress() + " burned down the " + targetBuilding.GetNameAndAddress)
                    End If
                End If
            End If


            '-- Murder
            odds = 0
            odds += thePerson.Criminality / 6.5
            odds += thePerson.Drunkenness / 9.0
            If GetRandom(0, 100) < odds And localPop > 1 Then
                Dim theVictim As Citizen = thePerson
                While (theVictim.Equals(thePerson))
                    theVictim = currentLocation.People(GetRandom(0, localPop - 1))
                End While

                If thePerson.CommitCrime(CrimeType.Murder, theVictim.GetNameAndAddress()) Then
                    '-- Attempt to prevent this crime
                    If Not PreventCrime(thePerson, CrimeType.Murder) Then
                        If theVictim.Die(DeathCause.Murder) Then
                            CrimeFlag = True
                            '-- Killing spree potential (especially if the crime paid off)
                            thePerson.Criminality += GetRandom(4, Math.Min(7, theVictim.Employment / 7.0))

                            DeadCitizens.Add(theVictim)
                            PersonalInsurance += 20
                            Diary.MurderEvents.AddEvent(thePerson.GetNameAndAddress() + " killed " + theVictim.Name)
                        End If
                    End If
                End If
            End If

            '-- Handle kickbacks from crime rings
            If CrimeFlag Then
                Dim theCrimeRing As List(Of Building) = thePerson.Residence.GetBuildingsByType(BuildingGen.BuildingEnum.Crime_Ring)
                If theCrimeRing.Count > 0 Then
                    '-- Crime rings give you a kickback equal to half the value of the crime
                    Dim KickbackSum As Integer = SafeDivide(TheftAmount + BuildingInsurance + PersonalInsurance, 2.0)
                    theCrimeRing(0).AddRevenue(KickbackSum)
                    theCrimeRing(0).AddEffects(1)
                End If
            End If
        Next

        PurgeRuins()
        PurgeDead()
    End Sub

    Sub Taxation()
        '-- Collect taxes and pay upkeep

        Dim RegularTaxRate As Integer = 5
        Dim DependentTaxRate As Integer = 2
        Dim EmployedTaxRate As Integer = 3

        Dim revenue As Integer = 0
        Dim upkeep As Integer = 0
        Dim trafficFines As Integer = 0

        '-- Income from citizens
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Citizen = CitizenList(i)

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
            trafficFines += thePerson.CollectFines()

            '-- Pay any upkeep on this citizen (like welfare)
            upkeep += thePerson.CollectUpkeep()

            '-- Townships take their cut
            If thePerson.Residence.Terrain = TerrainTownship Then
                personalTax = Math.Floor(personalTax * 0.8)
            End If

            revenue += personalTax
        Next

        '-- Income from development
        For i As Integer = 0 To DevelopmentList.Count - 1
            Dim theBuilding As Building = DevelopmentList(i)

            '-- Building revenue increase with visitors. Some buildings also generate revenue through other means
            revenue += theBuilding.CollectRevenue()

            '-- Building upkeep increases with age. Some buildings also generate upkeep through other means
            upkeep += theBuilding.CollectUpkeep()
        Next

        '-- Get the adjustment to taxes based on AI difficulty level (1.0 if current player is human)
        Dim TaxAdj As Double = CurrentPlayer.GetTaxAdjustment()
        revenue *= TaxAdj

        '-- Pay upkeep on the land
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

        '-- Choose between "You" and "They" based on if the player is human or robot
        Dim Pronoun As String = "You"
        If CurrentPlayer.PlayerType = PlayerAI Then
            Pronoun = "They"
        End If

        Diary.TaxEvents.AddEventNoLimit(Pronoun + " collected $" + revenue.ToString() + " in taxes")
        If trafficFines > 0 Then
            Diary.TaxEvents.AddEventNoLimit(Pronoun + " collected $" + trafficFines.ToString() + " in traffic fines")
        End If
        If upkeep > 0 Then
            Diary.TaxEvents.AddEventNoLimit(Pronoun + " payed $" + upkeep.ToString() + " in upkeep")
        End If

        '-- Update the player's money
        CurrentPlayer.TotalMoney += revenue + trafficFines - upkeep
    End Sub



#End Region

#Region " Building Events "

    Sub BuildingsExpand()

        '-- The BusinessSuccess of a building is current = to the sum of the employment stat of employees / by the # of jobs (see UpdateInternal)
        For i As Integer = 0 To CitizenList.Count - 1
            Dim thePerson As Citizen = CitizenList(i)

            If thePerson.JobBuilding IsNot Nothing Then
                'Update BusinessSuccess of job
                thePerson.JobBuilding.BusinessSuccess += thePerson.Employment
            End If
        Next

        '-- Expanding buildings that are successful
        '-- Currently based on employee quality. Eventually should take into account number of visitors
        For i As Integer = 0 To DevelopmentList.Count - 1

            Dim theBuilding As Building = DevelopmentList(i)

            '-- Update the buildings age and other info
            If Not theBuilding.UpdateInternal() Then
                DestroyedBuildings.Add(theBuilding)
            End If

            '-- Check if the building expanded
            theBuilding.ExpandIfSuccessful()
        Next

        '-- Remove buildings that were destroyed
        PurgeRuins()
    End Sub

#End Region

#Region " Setup "

    Sub Setup()
        '-- Setup and gather buildings
        GatherBuildings()

        '-- Gather all the current player's people
        GatherCitizens()

        '-- Gather all the occupied territory (all players)
        GatherTerritory()
    End Sub

    Sub GatherCitizens()

        CitizenList.Clear()

        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).IsOwned(CurrentPlayer.ID) Then
                    Dim localPop As Integer = GridArray(i, j).getPopulation()
                    For k As Integer = 0 To localPop - 1
                        Dim thePerson As Citizen = GridArray(i, j).People(k)
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
                If GridArray(i, j).IsOwned(CurrentPlayer.ID) Then
                    LocationList.Add(GridArray(i, j))
                End If
            Next
        Next

    End Sub

    Sub GatherBuildings()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim theLocation As CitySquare = GridArray(i, j)
                For k As Integer = 0 To theLocation.Buildings.Count - 1
                    Dim thisBuilding As Building = theLocation.Buildings(k)
                    If thisBuilding.OwnerID = CurrentPlayer.ID Then
                        thisBuilding.SetupBuilding()

                        '-- Development list contains all the buildings the player owns
                        DevelopmentList.Add(thisBuilding)
                    End If

                    '-- These lists contain all the buildings of a given type, owned by anyone
                    If thisBuilding.Tags.Contains(BuildingGen.TagEnum.Medical) Then
                        HospitalList.Add(thisBuilding)
                    End If
                    If thisBuilding.Tags.Contains(BuildingGen.TagEnum.Security) Then
                        CrimePreventerList.Add(thisBuilding)
                    End If
                Next
            Next
        Next
    End Sub

#End Region

#Region " Cleanup "

    Sub Cleanup()
        '-- Reset any temporary building data
        CleanupBuildings()

        '-- Clear visit info from locations
        ClearVisited()
    End Sub

    Sub PurgeDead()
        For i As Integer = 0 To DeadCitizens.Count - 1
            Dim DeadCitizen As Citizen = DeadCitizens(i)
            CitizenList.Remove(DeadCitizen)
        Next
        DeadCitizens.Clear()
    End Sub

    Sub PurgeRuins()
        For i As Integer = 0 To DestroyedBuildings.Count - 1
            Dim DestoryedBuilding As Building = DestroyedBuildings(i)
            DestoryedBuilding.Destroy()
        Next
        DestroyedBuildings.Clear()
    End Sub

    Sub ClearVisited()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)
                thisLocation.ClearVisit()
            Next
        Next
    End Sub

    Sub CleanupBuildings()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim theLocation As CitySquare = GridArray(i, j)
                For k As Integer = 0 To theLocation.Buildings.Count - 1
                    If theLocation.Buildings(k).OwnerID = CurrentPlayer.ID Then
                        theLocation.Buildings(k).CleanupBuilding()
                    End If
                Next
            Next
        Next
    End Sub

#End Region

#Region " Hospital Stuff "

    Function SaveVictim(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean

        For i As Integer = 0 To HospitalList.Count - 1
            If HospitalList(i).SavePatient(thePerson, causeOfDeath) Then
                '-- Citizen was saved!
                Diary.RescueEvents.AddEvent(HospitalList(i).GetNameAndAddress() + " saved the life of " + thePerson.GetNameAndAddress())
                Return True
            End If
        Next

        Return False
    End Function

    Function GetMaternityWardAdjust(ByRef thePerson As Citizen) As Double

        Dim BirthrateAdjust As Double = 1.0
        For i As Integer = 0 To HospitalList.Count - 1
            BirthrateAdjust *= HospitalList(i).GetBirthrateAdjust(thePerson)
        Next

        Return BirthrateAdjust
    End Function

#End Region

#Region " Crime Prevention "

    Function PreventCrime(ByRef theCriminal As Citizen, ByVal criminalAct As Integer) As Boolean

        For i As Integer = 0 To CrimePreventerList.Count - 1
            Dim PreventionOutcome As Integer = CrimePreventerList(i).PreventCrime(theCriminal, criminalAct)
            If PreventionOutcome <> CrimePreventionBuilding.PreventionType.Fail Then
                Dim PreventionText As String = ""
                PreventionText += theCriminal.Name + "'s "
                Select Case criminalAct
                    Case CrimeType.Murder
                        PreventionText += "murder"
                    Case CrimeType.Arson
                        PreventionText += "arson"
                    Case CrimeType.Vandalism
                        PreventionText += "vandalism"
                    Case CrimeType.Robbery
                        PreventionText += "robbery"
                    Case Else
                        PreventionText += "criminal"
                End Select
                PreventionText += " plot foiled by " + CrimePreventerList(i).GetName()

                '-- Handle criminals killed resisting arrest
                If PreventionOutcome = CrimePreventionBuilding.PreventionType.SuccessFatal Then
                    If theCriminal.Die(DeathCause.ResistingArrest) Then
                        PreventionText += ". Perpetrator killed resisting arrest"
                        DeadCitizens.Add(theCriminal)
                    End If
                End If

                Diary.CrimesPeventedEvents.AddEvent(PreventionText)
                Return True
            End If
        Next

        Return False
    End Function

#End Region

#Region " Travelling "
    Sub RangeChecker(ByRef theLocation As CitySquare, ByRef thePerson As Citizen, ByRef visitList As List(Of CitySquare))
        ClearVisited()

        '-- Travel outward from this location
        VisitOrder = 0
        TravelOnward(theLocation, thePerson, thePerson.Mobility)

        '-- Add every location that was visited during the travel to the visitList
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)
                If thisLocation.IsOwned() And thisLocation.VisitedKey > 0 Then
                    visitList.Add(thisLocation)
                End If
            Next
        Next

        '-- Sort the locations by the order the citizen visited them
        SortType = VisitOrderSort
        visitList.Sort()
    End Sub

    Sub TravelOnward(ByRef theLocation As CitySquare, ByRef thePerson As Citizen, ByVal Endurance As Integer)
        '-- Make sure this location is habited and that we didn't already reach here some faster (or equivalent) way
        If theLocation.VisitedKey >= Endurance Or Not theLocation.IsOwned() Then
            Return
        End If

        '-- Mark as an official visit with the current endurance and visit method (like bike, car, plane, etc)
        theLocation.VisitedKey = Endurance
        theLocation.SetVisitMethod(theLocation.VisitMethodAttempt)
        VisitOrder += 1
        theLocation.VisitOrder = VisitOrder

        '-- (Don't recalculate the drag loss if we've been here already)
        If theLocation.DragLoss < 0 Then
            '-- Poor roads make travel difficult
            'Dim DragLoss1 As Integer = (7 - GetRandom(0, location.Transportation + 2))
            Dim DragLoss1 As Integer = (5 - GetRandom(0, theLocation.Transportation))
            Dim DragLoss2 As Integer = (5 - GetRandom(0, theLocation.Transportation))
            theLocation.DragLoss = (DragLoss1 * DragLoss2) + 4
        End If

        Endurance -= theLocation.DragLoss

        '-- Mountains also slow travel
        If theLocation.Terrain = TerrainMountain Then
            Endurance -= 6
        End If

        '-- Check for travel bonuses based on buildings.
        For i As Integer = 0 To theLocation.Buildings.Count - 1
            theLocation.Buildings(i).UpdateEndurance(Endurance, thePerson)
        Next

        '-- Check to see if you have enough endurance to continue onward
        If Endurance < 0 Then
            Return
        End If

        '-- Continue traveling to locations adjacent to this location
        Dim adjacentList As List(Of CitySquare) = theLocation.GetAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            TravelOnward(adjacentList(i), thePerson, Endurance)
        Next
    End Sub

#End Region

End Class

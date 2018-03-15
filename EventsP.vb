Public Class EventsP

#Region " Variables "
    Public EventString As String = ""

    Public CurrentPlayer As Player = Nothing

    Public CitizenList As New ArrayList
    Public LocationList As New ArrayList

    Public NoDeath As Boolean = False
    Public NoEmigration As Boolean = False
    Public NoCrime As Boolean = False

#End Region


#Region " Person Events "

    Public Sub New(ByRef thePlayer As Player, ByVal theYear As Integer)
        CurrentPlayer = thePlayer

        If theYear < 10 Then
            ' Don't let anyone die in the first few turns. It unbalances the game too much.
            NoDeath = True
            NoCrime = True
        End If
        If theYear < 20 Then
            ' Don't let anyone emigrate in the first few turns. It unbalances the game too much.
            NoEmigration = True
        End If
    End Sub

    Function UpdatePeople() As String

        EventString = ""

        '-- Gather all the current player's people
        GatherCitizens()

        '-- Gather all the occupied territory (all players)
        GatherTerritory()

        '-- Population lifecycles
        AgeAndDie()

        '-- Have babies
        Reproduce()

        '-- Move between locations (can emigrate to other players)
        Travel()

        '-- Visit buildings within range for leisure and apply for jobs if unemployed
        LeisureAndWork()

        '-- Commit crimes like theft and murder and get in car accidents
        MajorCrimes()

        '-- Collect taxes from citizens and pay for upkeep of land
        Taxation()

        Return EventString

    End Function



    Sub AgeAndDie()
        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""

        Dim thePerson As Person
        Dim citizenCount As Integer = CitizenList.Count
        For i As Integer = 0 To citizenCount - 1
            thePerson = CitizenList(i)

            '-- Age and change
            thePerson.UpdateInternal()

            If NoDeath Then
                Continue For
            End If

            '--Sudden death for the youngish but unhealthy
            Dim suddenDeath As Integer = 0
            suddenDeath += (thePerson.Age - 20.0) / 4.0
            If thePerson.Health < 32 Then
                suddenDeath += (32 - thePerson.Health) / 4.0
            End If
            If thePerson.Health <= 0 Or thePerson.Age > 110 Or GetRandom(0, 100) < suddenDeath Then
                '--Deaths
                If thePerson.Die() Then

                    '-- Remove citizen from citizen list
                    CitizenList.RemoveAt(i)
                    citizenCount -= 1
                    i -= 1

                    '--Post Event
                    EventCount += 1
                    If EventCount >= EventLimit Then
                        LocalEvent = EventCount.ToString() + " citizens died." + ControlChars.NewLine
                    Else
                        LocalEvent += thePerson.GetNameAndAddress() + " died at the age of " + thePerson.Age.ToString() + "." + ControlChars.NewLine
                    End If
                End If
            End If

        Next

        EventString += LocalEvent
    End Sub

    Sub Reproduce()

        Dim EventCount As Integer = 0
        Dim EventCountTwins As Integer = 0
        Dim LocalEvent As String = ""
        Dim LocalEventTwins As String = ""

        Dim thePerson As Person
        For i As Integer = 0 To CitizenList.Count - 1
            thePerson = CitizenList(i)

            thePerson.TouchedKey = 0
            If thePerson.WillReproduce() Then
                Dim homeTown As CitySquare = thePerson.Residence
                Dim theName As String = homeTown.Birth(thePerson)

                'Check for twins (very rare)
                Dim theName2 As String = ""
                If (GetRandom(0, 1000) < 14) Then
                    theName2 = homeTown.Birth(thePerson)
                End If

                '--Post Event
                If theName2.Length <= 0 Then
                    EventCount += 1
                    If EventCount >= EventLimit Then
                        LocalEvent = EventCount.ToString() + " citizens had children." + ControlChars.NewLine
                    Else
                        LocalEvent += thePerson.GetNameAndAddress() + " gave birth to " + theName + "." + ControlChars.NewLine
                    End If
                Else
                    'Twins!!
                    EventCountTwins += 1
                    If EventCount >= EventLimit Then
                        LocalEventTwins = EventCount.ToString() + " citizens had twins." + ControlChars.NewLine
                    Else
                        LocalEventTwins += thePerson.GetNameAndAddress() + " had twins named " + theName + " and " + theName2 + "." + ControlChars.NewLine
                    End If
                End If

            End If
        Next

        EventString += LocalEvent + LocalEventTwins
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
            ClearVisited()
            Dim locationsInRange As New ArrayList
            RangeChecker(originalHome, thePerson.Mobility, locationsInRange)

            If locationsInRange.Count > 0 And GetRandom(0, 1) = 1 Then '-- 50% chance of moving if the option presents itself. Seems a little high?

                '-- Sort the movement options based on preference for space, culture or jobs
                Dim localPop As Integer = originalHome.getPopulation()
                If thePerson.Employment = 0 And thePerson.Age >= 16 And GetRandom(0, 30 + thePerson.Mobility) < (38 - localPop) Then
                    SortType = JobSort
                ElseIf GetRandom(0, 80 + thePerson.Mobility) < (30 - localPop) Then
                    SortType = CultureSort
                Else
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

                    '-- Move out of original home
                    originalHome.People.Remove(thePerson)

                    '-- Move into new home
                    newHome.People.Add(thePerson)
                    thePerson.Residence = newHome

                    Dim OldAddress As String = originalHome.GetName()
                    Dim NewAddress As String = newHome.GetName()

                    If newHome.OwnerID = CurrentPlayer.ID Then
                        '--Post Event for internal move
                        InternalCount += 1
                        If InternalCount >= EventLimit Then
                            InternalMove = InternalCount.ToString() + " citizens moved." + ControlChars.NewLine
                        Else
                            InternalMove += OldAddress + " moved to " + NewAddress + "." + ControlChars.NewLine
                        End If
                    Else
                        '--Post Event for external move
                        ExternalCount += 1
                        If ExternalCount >= EventLimit Then
                            ExternalMove = ExternalCount.ToString() + " citizens emigrated." + ControlChars.NewLine
                        Else
                            ExternalMove += OldAddress + " emigrated to  " + NewAddress + "." + ControlChars.NewLine
                        End If
                    End If

                End If
            End If
        Next

        EventString += InternalMove + ExternalMove

    End Sub

    Sub LeisureAndWork()
        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""

        Dim thePerson As Person
        For i As Integer = 0 To CitizenList.Count - 1
            thePerson = CitizenList(i)
            Dim originalHome As CitySquare = thePerson.Residence

            'Find all the locations within range (based on the person's mobiility and the quality of roads)
            ClearVisited()
            Dim locationsInRange As New ArrayList
            RangeChecker(originalHome, thePerson.Mobility, locationsInRange)

            For j As Integer = 0 To locationsInRange.Count - 1

                Dim currentLocation As CitySquare = locationsInRange(j)

                For n As Integer = 0 To currentLocation.Buildings.Count - 1

                    '-- Have person potentially visit each building in range for leisure
                    Dim currentBuilding As Building = currentLocation.Buildings(n)
                    currentBuilding.AffectPerson(thePerson)

                    '-- Apply for a job if the building is hiring and the person is unemployed
                    If currentBuilding.Hiring() And thePerson.WillEmploy() Then

                        'Have person take job if in range
                        thePerson.Employment += 1
                        thePerson.JobBuilding = currentBuilding
                        currentBuilding.Filled += 1

                        If thePerson.Age = 16 Then
                            '-- If employed from an early age, buy a hotrod
                            thePerson.Mobility += GetRandom(3, 4)
                        End If

                        '--Post Event
                        EventCount += 1
                        If EventCount >= EventLimit Then
                            LocalEvent = EventCount.ToString() + " citizens got new jobs." + ControlChars.NewLine
                        Else
                            LocalEvent += thePerson.GetNameAndAddress() + " took a job at the " + currentBuilding.GetNameAndAddress() + "." + ControlChars.NewLine
                        End If
                    End If
                Next
            Next

        Next

        EventString += LocalEvent
    End Sub

    Sub MajorCrimes()

        If NoCrime Then
            Return
        End If

        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""

        Dim LocalEventTheft As String = ""
        Dim LocalEventMurder As String = ""
        Dim LocalEventAccident As String = ""
        Dim TheftSum As Integer = 0
        Dim CountTheft As Integer = 0
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
            If GetRandom(0, 100) < odds Then
                Dim theft As Integer = Math.Min(thePerson.Criminality, CurrentPlayer.TotalMoney)
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

            Dim currentLocation As CitySquare = thePerson.Residence
            Dim localPop As Integer = currentLocation.getPopulation()

            '-- Murder
            odds = 0
            odds += thePerson.Criminality / 6.5
            odds += thePerson.Drunkenness / 9.0
            If GetRandom(0, 100) < odds And localPop > 1 Then
                Dim theVictim As Person = thePerson
                While (theVictim.Name = thePerson.Name) '-- Could loop forever if only 2 people and they have the same name
                    theVictim = currentLocation.People(GetRandom(0, localPop - 1))
                End While

                '-- Killing spree potential (especially if the crime paid off)
                thePerson.Criminality += GetRandom(4, Math.Min(7, theVictim.Employment / 7.0))

                If theVictim.Die() Then

                    currentLocation.People.Remove(theVictim)
                    citizenCount -= 1

                    CountMurder += 1
                    '--Post Event
                    If CountMurder >= EventLimit Then
                        LocalEventMurder = CountMurder.ToString + " citizens were murdered." + ControlChars.NewLine
                    Else
                        LocalEventMurder += thePerson.GetNameAndAddress() + " killed " + theVictim.Name + "." + ControlChars.NewLine
                    End If
                End If
            End If

            '-- Car Accident
            odds = 0
            odds += thePerson.Mobility / 10.0
            odds += thePerson.Drunkenness / 4.0
            odds += (currentLocation.getPopulation / 5.0)
            odds -= (currentLocation.Transportation * 2.0)
            If GetRandom(0, 100) <= odds Then
                If thePerson.Die() Then

                    currentLocation.People.Remove(thePerson)
                    citizenCount -= 1
                    i -= 1

                    CountAccident += 1
                    '--Post Event
                    If CountAccident >= EventLimit Then
                        LocalEventAccident = CountAccident.ToString() + " citizens died in traffic accidents." + ControlChars.NewLine
                    Else
                        LocalEventAccident += thePerson.GetNameAndAddress() + " died in a car accident." + ControlChars.NewLine
                    End If
                End If
            End If

        Next

        EventString += LocalEventTheft + LocalEventMurder + LocalEventAccident
    End Sub

    Sub Taxation()
        '--
        Dim RegularTaxRate As Integer = 5
        Dim EmployedTaxRate As Integer = 2
        Dim LandTax As Integer = 10

        Dim revenue As Integer = (CitizenList.Count * RegularTaxRate)
        revenue += (CurrentPlayer.TotalEmployed * EmployedTaxRate)
        Dim land As Integer = CurrentPlayer.TotalTerritory
        If land > 3 And revenue > (land * LandTax * 2.0) Then
            land *= LandTax
            EventString = "You payed " + land.ToString() + " in upkeep." + ControlChars.NewLine + EventString
        Else
            land = 0
        End If
        EventString = "You collected " + revenue.ToString() + " in taxes." + ControlChars.NewLine + EventString
        revenue -= land
        CurrentPlayer.TotalMoney += Math.Max(0, revenue)
    End Sub



#End Region


#Region " Support "
    Sub GatherCitizens()

        CitizenList.Clear()

        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = CurrentPlayer.ID Then
                    Dim localPop As Integer = BoxInfo(i, j).getPopulation()
                    For k As Integer = 0 To localPop - 1
                        Dim thePerson As Person = BoxInfo(i, j).People(k)
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
                If BoxInfo(i, j).OwnerID >= 0 Then
                    LocationList.Add(BoxInfo(i, j))
                End If
            Next
        Next

    End Sub

    Sub ClearVisited()
        For i As Integer = 0 To LocationList.Count - 1
            Dim thisLocation As CitySquare = LocationList(i)
            thisLocation.VisitedKey = 0
        Next
    End Sub

    Function RangeChecker(ByRef location As CitySquare, ByVal Mobility As Integer, ByRef visitList As ArrayList) As Integer
        If location.VisitedKey > Mobility Or location.OwnerID < 0 Then
            Return 0
        End If

        '-- Mark
        location.VisitedKey = Mobility

        '-- Add to potential candidates
        visitList.Add(location)

        '-- Continue moving
        Dim DragLoss1 As Integer = (5 - GetRandom(0, location.Transportation))
        Dim DragLoss2 As Integer = (5 - GetRandom(0, location.Transportation))
        Mobility -= (DragLoss1 * DragLoss2)
        If Mobility < 0 Then
            Return 0
        End If

        Dim adjacentList As ArrayList = location.GetAdjacents()

        For i As Integer = 0 To adjacentList.Count - 1
            RangeChecker(adjacentList(i), Mobility, visitList)
        Next
    End Function

#End Region

End Class

Public Class Person

#Region " Variables "
    Public Name As String = ""

    Public JobBuilding As Building = Nothing

    '-- Personal history
    Public BirthPlace As CitySquare = Nothing
    Public Residence As CitySquare = Nothing

    '-- Family
    Public ParentName As String = "Unknown"
    Public Children As New List(Of String)

    '-- Traits
    Public Happiness As Integer = 0
    Public Health As Integer = 0 '(0 dies, higher reproduces)
    Public Employment As Integer = 0 '(0 for unemployed)
    Public Intelligence As Integer = 0
    Public Creativity As Integer = 0
    Public Mobility As Integer = 0 '(0 Is stationary)
    Public Drunkenness As Integer = 0
    Public Criminality As Integer = 0
    Public Age As Integer = 1

    Public Const MinorAge As Integer = 16

    '-- Criminal Record
    Public ParkingTicketCount As Integer = 0
    Public DrivingTicketCount As Integer = 0
    Public RobberyCount As Integer = 0
    Public ArsonCount As Integer = 0
    Public MurderCount As Integer = 0

    '-- Financials
    Public Wealth As Integer = 0
    Public UnpaidFines As Integer = 0

    '-- Life Events
    Public JourneyString As String = ""

    '-- Mark
    Public TouchedKey As Integer = 0
#End Region

#Region " New "
    Public Sub New()
        '-- Create randomly
        Name = Namer.GeneratePersonName()
        Happiness = GetRandom(25, 35)
        Health = GetRandom(40, 50)
        Employment = 0
        Intelligence = GetRandom(3, 10)
        Creativity = GetRandom(3, 10)
        Mobility = GetRandom(0, 5)
        Drunkenness = 0
        Criminality = GetRandom(0, 10)
        Age = 1
    End Sub

    Public Sub New(ByVal isAdult As Boolean)
        '-- Create randomly
        Name = Namer.GeneratePersonName()

        Happiness = GetRandom(25, 35)
        Health = GetRandom(40, 50)
        Employment = 0
        Drunkenness = 0

        If isAdult Then
            '-- Adult
            Age = GetRandom(20, 30)
            Intelligence = GetRandom(20, 30)
            Creativity = GetRandom(20, 30)
            Mobility = GetRandom(12, 25)
            Criminality = GetRandom(0, 10)
        Else
            '-- Newborn
            Age = 1
            Intelligence = GetRandom(3, 10)
            Creativity = GetRandom(3, 10)
            Mobility = GetRandom(0, 5)
            Criminality = GetRandom(0, 5)
        End If


    End Sub

    Public Sub New(ByRef Parent As Person)
        '-- Create randomly with heriditary influence
        Name = Namer.GeneratePersonName()
        Happiness = GetRandom(20, 30) + (Parent.Happiness / 9.0)
        Health = GetRandom(Math.Min(40, Parent.Health), 50)
        Employment = 0
        Intelligence = GetRandom(3, 8 + (Parent.Intelligence / 16.5))
        Creativity = GetRandom(3, 8 + (Parent.Creativity / 16.5))
        Mobility = GetRandom(0, 5)
        Drunkenness = GetRandom(0, Math.Max(12, Parent.Drunkenness))
        Criminality = GetRandom(0, 8 + (Parent.Criminality / 6.0))
        Age = 1
        ParentName = Parent.Name
        Parent.Children.Add(Name)
        BirthPlace = Parent.Residence
    End Sub

#End Region

#Region " Manipulate "
    Sub Cap()
        '-- Tops
        If Happiness > 100 Then
            Happiness = 100
        End If
        If Health > 100 Then
            Health = 100
        End If
        If Employment > 100 Then
            Employment = 100
        End If
        If Intelligence > 100 Then
            Intelligence = 100
        End If
        If Creativity > 100 Then
            Creativity = 100
        End If
        If Mobility > 100 Then
            Mobility = 100
        End If
        If Drunkenness > 100 Then
            'Death from alcohol poisoning
            Drunkenness = 100
        End If
        If Criminality > 100 Then
            Criminality = 100
        End If

        '-- Bottoms
        If Happiness < 0 Then
            Happiness = 0
        End If
        If Health < 0 Then
            'Death from sickness
            Health = 0
        End If
        If Employment < 0 Then
            Employment = 0
        End If
        If Intelligence < 0 Then
            Intelligence = 0
        End If
        If Creativity < 0 Then
            Creativity = 0
        End If
        If Mobility < 0 Then
            Mobility = 0
        End If
        If Drunkenness < 0 Then
            Drunkenness = 0
        End If
        If Criminality < 0 Then
            Criminality = 0
        End If
    End Sub

    Public Sub AddEvent(ByVal eString As String)
        JourneyString += eString + ControlChars.NewLine
    End Sub

    Public Sub AddEvent(ByVal eString As String, ByVal eStat As Integer)
        '-- Add an event that changed a stat
        If eStat <> 0 Then
            If eStat > 0 Then
                JourneyString += "+"
            End If
            JourneyString += eStat.ToString + " " + eString + ControlChars.NewLine
        End If
    End Sub


    Public Sub UpdateInternal()
        Dim maxBonus, maxLoss As Double
        Dim statChange As Integer = 0
        Dim statChange2 As Integer = 0

        Dim thePop As Integer = Residence.getPopulation()
        Dim theRoad As Integer = Residence.Transportation

        '-- Age
        Age = Age + TimeIncrement
        If Age <= 28 Then
            '-- Upslope
            Health += 1
        End If
        If Age >= 45 Then
            '-- Downslope
            maxLoss = (Age - 50.0) / 10.0
            If maxLoss < 0 Then
                maxLoss = 0
            End If
            statChange = GetRandom(maxLoss, maxLoss + 2)
            Health -= statChange
            AddEvent("health due to aging", -statChange)
        End If

        '--Health
        If Health < 15 Then
            '-- Deteriation
            Health -= 1
            AddEvent("health due to sickness", -1)

            If Employment = 0 Then
                '-- Starving artist
                statChange = GetRandom(0, 3)
                Creativity += statChange
                AddEvent("creativity struggling for survival", statChange)
            End If
        End If

        '--Happiness
        If Happiness >= 70 Then
            '-- Happiness improves health
            maxBonus = (Happiness - 60.0) / 10.0
            statChange = GetRandom(0, maxBonus)
            Health += statChange
            AddEvent("health from happiness", statChange)
        ElseIf Happiness <= 10 Then
            '-- Depression sickness
            statChange = GetRandom(1, 3)
            Health -= statChange
            AddEvent("health due to depression", -statChange)
        End If
        If Happiness <= 15 Then
            '-- Unhappy people lash out at society
            statChange = GetRandom(0, 2)
            Criminality += statChange
            AddEvent("criminality due to anger & bitterness", statChange)
        End If

        '--Employment
        If Employment > 0 Then
            '-- Success leads to promotions
            maxBonus = (Intelligence / 8.0) + (Creativity / 9.0) ' - 5 (allow work performance to be bad and employee to be fired
            statChange = GetRandom(0, maxBonus)
            Employment += statChange
            AddEvent("employment for solid work performance", statChange)

            '-- Criminality drops
            statChange = GetRandom(0, 1)
            Criminality -= statChange
            AddEvent("criminality b/c of steady employment", -statChange)
        Else
            If Not IsMinor() Then
                '-- Unemployment is depressing and encourages a life of crime
                statChange = GetRandom(0, 3)
                Happiness -= statChange
                AddEvent("happiness due to unemployment frustration", -statChange)

                statChange = GetRandom(0, 2)
                Criminality += statChange
                AddEvent("criminality from unemployment desperation", statChange)
            End If
        End If
        If Employment > 50 Then
            '-- Fast track
            maxBonus = ((Employment - 40.0) / 10.0)
            statChange = GetRandom(0, maxBonus)
            Happiness += statChange
            AddEvent("happiness due to satisfying job", statChange)
        End If

        '--Intelligence and Creativity
        If Age <= 35 Then '-- Occurs 11 times
            '-- Personal drive
            statChange = GetRandom(0, SafeDivide(Intelligence, 15.0))
            Intelligence += statChange
            AddEvent("intelligence due to youthful drive", statChange)

            statChange = GetRandom(0, SafeDivide(Creativity, 15.0))
            Creativity += statChange
            AddEvent("creativity due to youthful drive", statChange)
        End If
        If Age <= 18 Then '-- Occurs 5 times
            '-- Street smarts
            maxBonus = GetRandom(0, thePop / 8.0)

            '-- Primary school
            statChange = GetRandom(2, 5 + maxBonus)
            Intelligence += statChange
            AddEvent("intelligence at primary school", statChange)

            statChange = GetRandom(2, 4 + maxBonus)
            Creativity += statChange
            AddEvent("creativity at primary school", statChange)
        End If
        If Age >= 18 And Age <= 25 Then '-- Occurs 3 times
            If Intelligence >= 30 + (thePop / 5.0) Then
                '-- Higher education. Gets more competitive with population.
                statChange = GetRandom(1, 5)
                Intelligence += statChange
                AddEvent("intelligence from community college", statChange)

                statChange = GetRandom(1, 5)
                Creativity += statChange
                AddEvent("creativity from community college", statChange)
            Else
                statChange = GetRandom(0, 2)
                Intelligence += statChange
                AddEvent("intelligence (not attending college)", statChange)

                statChange = GetRandom(0, 2)
                Creativity += statChange
                AddEvent("creativity (not attending college)", statChange)
            End If
        End If

        '-- Mobility and transportation
        maxBonus += GetRandom(theRoad / 2.0, theRoad)
        If Age <= 19 Then
            '-- Learn to walk, then to run
            statChange = GetRandom(1, 3)
            Mobility += statChange
            AddEvent("mobility from learning to walk/run", statChange)
        ElseIf Age >= 50 Then
            '-- Arthritis
            maxLoss = (Age - 40.0) / 8.5
            statChange = GetRandom(0, maxLoss)
            Mobility -= statChange
            AddEvent("mobility from aging/arthritis", -statChange)
        End If
        If Age = 16 Then
            '-- Learn to drive
            statChange = GetRandom(3, 8)
            Mobility += statChange
            AddEvent("mobility from learning to drive", statChange)
        End If


        '-- Drunkenness
        If Drunkenness >= 10 Then
            '-- Addiction
            maxBonus = Drunkenness / 10.0
            statChange = GetRandom(0, maxBonus)
            Drunkenness += statChange
            AddEvent("substance abuse from dependence", statChange)
        End If
        If Drunkenness >= 2 And Drunkenness <= 20 Then
            '-- Pleasant buzz
            statChange = GetRandom(0, 2)
            Happiness += statChange
            AddEvent("happiness from being pleasantly buzzed", statChange)
        End If
        If Drunkenness >= 25 Then
            '-- Liver damage
            maxLoss = Drunkenness / 13.0
            statChange = GetRandom(0, maxLoss)
            Health -= statChange
            AddEvent("health from liver damage", -statChange)
        End If
        If Drunkenness >= 30 Then
            '-- Destructive lifestyle
            Happiness -= GetRandom(0, 2)
            AddEvent("happiness from destructive lifestyle", -statChange)
        End If
        If Drunkenness >= 40 And Health <= 12 And GetRandom(0, 100) <= 15 Then
            '-- Go cold turkey
            Drunkenness = 0
            AddEvent("=0 drunkenness; went cold turkey to stay alive")
        End If

        '-- Population
        If thePop >= 5 Then
            '-- A person suffers from urban blight once per 5 population
            Dim numberOfBlights As Integer = Math.Floor(SafeDivide(thePop, 5.0))

            For i As Integer = 0 To numberOfBlights - 1
                maxBonus = SafeDivide(thePop, 5.0)
                Dim switchman As Integer = GetRandom(0, 2)
                '-- Crowded areas reduces health, happiness and increased crime
                If switchman = 0 Then
                    statChange = GetRandom(0, maxBonus)
                    Criminality += statChange
                    AddEvent("criminality from overpopulation", statChange)
                ElseIf switchman = 1 Then
                    statChange = GetRandom(0, maxBonus)
                    Happiness -= statChange
                    AddEvent("happiness from overpopulation", -statChange)
                Else
                    statChange = GetRandom(0, maxBonus)
                    Health -= statChange
                    AddEvent("health from overpopulation", -statChange)
                End If
            Next
        End If

        '-- Terrain
        Select Case (Residence.Terrain)
            Case TerrainForest
                statChange = GetRandom(1, 3)
                Happiness += statChange
                AddEvent("happiness from forest", statChange)

                statChange = GetRandom(1, 3)
                Health += statChange
                AddEvent("health from forest", statChange)
            Case TerrainMountain
                statChange = GetRandom(1, 3)
                Creativity += statChange
                AddEvent("creativity from mountain", statChange)

                statChange = GetRandom(0, 2)
                Mobility -= statChange
                AddEvent("mobility from mountain", -statChange)
            Case TerrainSwamp
                statChange = GetRandom(2, 4)
                Health -= statChange
                AddEvent("health from swawmp", -statChange)
            Case TerrainDirt
                statChange = GetRandom(0, 2)
                Creativity -= statChange
                AddEvent("creativity from boring ol' dirt", -statChange)
            Case TerrainDesert
                statChange = GetRandom(1, 3)
                Mobility += statChange
                AddEvent("mobility from wide open desert", statChange)
        End Select
        If Residence.Coastal Then
            '-- Coastal areas make people happier
            statChange = GetRandom(1, 2)
            Happiness += statChange
            AddEvent("happiness from coastal life", statChange)
        End If

        '-- Cap all values between 0 and 100
        Cap()

    End Sub

    Function WillReproduce(Optional ByVal Adjustment As Double = 1.0) As Boolean
        'Remove happiness constraint?
        If Age >= 16 And Age <= 49 And Health > 20 And Happiness > 10 Then
            Dim Odds As Double = 0.0
            Odds += (25.0 - Math.Abs(25.0 - Age))
            Odds += (Health / 7.0)
            Odds += (Happiness / 10.0)
            Odds += Math.Min(5, Drunkenness / 6.0)
            Odds += (Employment / 20.0)

            Odds *= Adjustment

            If GetRandom(0, 100) <= Odds Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function Reproduce() As Person
        Dim child As New Person(Me)
        child.BirthPlace = Residence
        child.Residence = Residence
        Residence.People.Add(child)
        AddEvent("Gave birth to " + child.Name)
        Return child
    End Function

    Function Die(ByVal CauseOfDeath As Integer) As Boolean
        'Free dead person's job
        If JobBuilding IsNot Nothing Then
            JobBuilding.Employees.Remove(Me)
        End If

        'Free dead person's residence
        Residence.People.Remove(Me)

        '-- Record cause of death
        Select Case CauseOfDeath
            Case Turn.DeathCause.Illness
                AddEvent("Died of illness")
            Case Turn.DeathCause.Murder
                AddEvent("Murdered")
            Case Turn.DeathCause.NaturalCauses
                AddEvent("Died of natural causes")
            Case Turn.DeathCause.TrafficAccident
                AddEvent("Died in traffic accident")
            Case Turn.DeathCause.Unknown
                AddEvent("Died of unknown causes")
        End Select

        Return True
    End Function

    Function WillApply(ByRef newJob As Building) As Boolean

        If JobBuilding IsNot Nothing Then
            '-- If already employed, make sure this other opportunity is better
            If newJob.Cost <= JobBuilding.Cost Then '-- Change this to salary in future
                Return False
            End If

            '-- Even if the opportunity is better, stick with your current job most of the time
            If GetRandom(0, 100) < 85 Then
                Return False
            End If
        End If

        If Age >= 10 And Intelligence >= 5 Then
            Dim Odds As Double = 20
            Odds = Odds + (15 - Math.Abs(Age - 35.0)) / 5.0
            Odds = Odds + (Health / 9.0)
            Odds = Odds + (Happiness / 15.0)
            Odds = Odds - (Drunkenness / 6.0)
            Odds = Odds - (Criminality / 5.0)
            Odds = Odds + (Intelligence / 4.5)
            Odds = Odds + (Creativity / 5.5)
            Odds = Odds + (Mobility / 15.0)
            If GetRandom(0, 100) <= Odds Then
                AddEvent("Hired by the " + newJob.GetNameAndAddress())
                Return True
            Else
                AddEvent("Job application rejected by the " + newJob.GetNameAndAddress())
                Return False
            End If
        End If

        Return False
    End Function

    Function CommitCrime(ByVal CrimeType As Integer, ByVal Optional ExtraText As String = "") As Boolean

        If Age < 16 Then
            Return False
        End If

        '-- Record cause of death
        Select Case CrimeType
            Case Turn.CrimeType.ParkingTicket
                ParkingTicketCount += 1
                UnpaidFines += 1
                AddEvent("Received a parking ticket")
            Case Turn.CrimeType.TrafficTicket
                DrivingTicketCount += 1
                UnpaidFines += 2
                AddEvent("Received a traffic ticket")
            Case Turn.CrimeType.Robbery
                RobberyCount += 1
                AddEvent("Stole $" + ExtraText)
            Case Turn.CrimeType.Vandalism
                AddEvent("Vandalized the " + ExtraText)
            Case Turn.CrimeType.Arson
                ArsonCount += 1
                AddEvent("Burned down the " + ExtraText)
            Case Turn.CrimeType.Murder
                MurderCount += 1
                AddEvent("Killed " + ExtraText)
            Case Turn.CrimeType.Unknown
                AddEvent("Committed unknown crime")
        End Select

        Return True
    End Function

#End Region

#Region " Support "

    Public Function GetNameAndAddress() As String
        Return Name.ToString() + " of " + Residence.GetName()
    End Function

    Public Function IsMinor() As Boolean
        If Age < MinorAge Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsElderly() As Boolean
        If Age > 50 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function toString() As String
        '-- Print the citizen's name
        Dim PersonString As String = ""
        PersonString += "Name: " + Name.ToString + ControlChars.NewLine
        If BirthPlace Is Nothing Then
            'PersonString += "Birthplace: Unknown" + ControlChars.NewLine
        Else
            PersonString += "Birthplace: " + BirthPlace.GetName() + ControlChars.NewLine
        End If
        If Residence IsNot Nothing Then
            PersonString += "Residence: " + Residence.GetName() + ControlChars.NewLine
        End If


        '-- Print the citizen's stats
        PersonString += "Age: " + Age.ToString + ControlChars.NewLine
        PersonString += "Health: " + Health.ToString + ControlChars.NewLine
        PersonString += "Happiness: " + Happiness.ToString + ControlChars.NewLine
        PersonString += "Employment: " + Employment.ToString + ControlChars.NewLine
        PersonString += "Intelligence: " + Intelligence.ToString + ControlChars.NewLine
        PersonString += "Creativity: " + Creativity.ToString + ControlChars.NewLine
        PersonString += "Mobility: " + Mobility.ToString + ControlChars.NewLine
        PersonString += "Drunkenness: " + Drunkenness.ToString + ControlChars.NewLine
        PersonString += "Criminality: " + Criminality.ToString + ControlChars.NewLine
        PersonString += ControlChars.NewLine

        '-- Print the citizen's age and employment status
        If IsMinor() Then
            PersonString += "Minor." + ControlChars.NewLine
        End If
        If JobBuilding Is Nothing Then
            If Age > 16 Then
                PersonString += "Currently unemployed." + ControlChars.NewLine
            End If
        Else
            PersonString += "Employed by the " + JobBuilding.GetNameAndAddress() + "." + ControlChars.NewLine
        End If
        PersonString += ControlChars.NewLine

        '-- Print the citizen's parents and children
        If ParentName.Length > 0 Or Children.Count > 0 Then
            If ParentName.Length > 0 Then
                PersonString += "Parent: " + ParentName + ControlChars.NewLine
            End If
            If Children.Count > 0 Then
                PersonString += "Children: "
                For i As Integer = 0 To Children.Count - 1
                    PersonString += Children(i)
                    If i = Children.Count - 1 Then
                        PersonString += ControlChars.NewLine
                    Else
                        PersonString += ", "
                    End If
                Next
            End If
            PersonString += ControlChars.NewLine
        End If

        '-- Print the citizen's criminal record
        If ParkingTicketCount + DrivingTicketCount + RobberyCount + ArsonCount + MurderCount > 0 Then
            PersonString += "Criminal record: " + ControlChars.NewLine
            If ParkingTicketCount > 0 Then
                PersonString += "Parking tickets: " + ParkingTicketCount.ToString + ControlChars.NewLine
            End If
            If DrivingTicketCount > 0 Then
                PersonString += "Traffic tickets: " + DrivingTicketCount.ToString + ControlChars.NewLine
            End If
            If RobberyCount > 0 Then
                PersonString += "Robbery: " + RobberyCount.ToString + ControlChars.NewLine
            End If
            If ArsonCount > 0 Then
                PersonString += "Arson: " + ArsonCount.ToString + ControlChars.NewLine
            End If
            If MurderCount > 0 Then
                PersonString += "Murder: " + MurderCount.ToString + ControlChars.NewLine
            End If
            PersonString += ControlChars.NewLine
        End If

        If Residence.CountBuildingsByType(BuildingGen.BuildingEnum.Detective_Agency) > 0 Or DebugMode Then
            PersonString += JourneyString + ControlChars.NewLine
        End If


        Return PersonString
    End Function
#End Region



End Class

Public Class Citizen

#Region " Variables "
    Public Name As String = ""

    Public JobBuilding As Building = Nothing

    '-- Personal history
    Public BirthPlace As CitySquare = Nothing
    Public Residence As CitySquare = Nothing

    '-- Family
    Public ParentName As String = "Unknown"
    Public Children As New List(Of String)

    '-- Stats (like Health and Happiness)
    Public Stats(StatEnum.EnumEnd - 1) As Integer

    Public Age As Integer = 1
    Public TimeAtJob As Integer = 0

    Public Const MinorAge As Integer = 16
    Public Const ElderAge As Integer = 55

    '-- Criminal Record
    Public CrimeCount(CrimeEnum.EnumEnd - 1) As Integer

    '-- Financials
    Public BuildingsFounded As New List(Of Building)
    Public CountFounded As Integer = 0
    Public Wealth As Integer = 0
    Public UnpaidFines As Integer = 0
    Public UnpaidUpkeep As Integer = 0

    '-- Life Events
    Public JourneyString As String = ""

    '-- Mark
    Public TouchedKey As Integer = 0
#End Region

#Region " New "
    Public Sub New()
        '-- Create randomly
        Name = Namer.GeneratePersonName()
        SetStat(StatEnum.Happiness, GetRandom(25, 35))
        SetStat(StatEnum.Health, GetRandom(40, 50))
        SetStat(StatEnum.Employment, 0)
        SetStat(StatEnum.Intelligence, GetRandom(3, 10))
        SetStat(StatEnum.Creativity, GetRandom(3, 10))
        SetStat(StatEnum.Mobility, GetRandom(0, 5))
        SetStat(StatEnum.Drunkenness, 0)
        SetStat(StatEnum.Criminality, GetRandom(0, 10))
        Age = 1
    End Sub

    Public Sub New(ByVal isAdult As Boolean)
        '-- Create randomly
        Name = Namer.GeneratePersonName()

        If isAdult Then
            '-- Adult
            Age = GetRandom(20, 30)
            SetStat(StatEnum.Happiness, GetRandom(35, 45))
            SetStat(StatEnum.Health, GetRandom(45, 55))
            SetStat(StatEnum.Intelligence, GetRandom(20, 30))
            SetStat(StatEnum.Creativity, GetRandom(20, 30))
            SetStat(StatEnum.Mobility, GetRandom(12, 25))
            SetStat(StatEnum.Employment, GetRandom(10, 20))
            SetStat(StatEnum.Drunkenness, GetRandom(0, 5))
            SetStat(StatEnum.Criminality, GetRandom(0, 10))
        Else
            '-- Newborn
            Age = GetRandom(1, TimeIncrement)
            SetStat(StatEnum.Happiness, GetRandom(25, 35))
            SetStat(StatEnum.Health, GetRandom(40, 50))
            SetStat(StatEnum.Intelligence, GetRandom(3, 10))
            SetStat(StatEnum.Creativity, GetRandom(3, 10))
            SetStat(StatEnum.Mobility, GetRandom(0, 5))
            SetStat(StatEnum.Employment, 0)
            SetStat(StatEnum.Drunkenness, 0)
            SetStat(StatEnum.Criminality, GetRandom(0, 5))
        End If


    End Sub

    Public Sub New(ByRef Parent As Citizen)

        Name = Namer.GeneratePersonName()
        Age = 1
        ParentName = Parent.Name
        Parent.Children.Add(Name)
        BirthPlace = Parent.Residence

        '-- Create randomly with heriditary influence (need to separate nature vs nurture better)
        SetStat(StatEnum.Happiness, GetRandom(20, 30) + (Parent.GetStat(StatEnum.Happiness) / 9.0))
        SetStat(StatEnum.Health, GetRandom(Math.Min(30, Parent.GetStat(StatEnum.Health)), 50))
        SetStat(StatEnum.Employment, 0)
        SetStat(StatEnum.Intelligence, GetRandom(3, 8 + (Parent.GetStat(StatEnum.Intelligence) / 16.5)))
        SetStat(StatEnum.Creativity, GetRandom(3, 8 + (Parent.GetStat(StatEnum.Creativity) / 16.5)))
        SetStat(StatEnum.Mobility, GetRandom(0, 5))
        SetStat(StatEnum.Drunkenness, GetRandom(0, Math.Max(12, Parent.GetStat(StatEnum.Drunkenness))))
        SetStat(StatEnum.Criminality, GetRandom(0, 8 + (Parent.GetStat(StatEnum.Criminality) / 6.0)))

    End Sub

#End Region

#Region " Gets and Sets "
    Public Sub SetStat(ByVal StatType As Integer, ByVal StatValue As Integer)
        Stats(StatType) = StatValue
    End Sub

    Public Function GetStat(ByVal StatType As Integer) As Integer
        Return Stats(StatType)
    End Function

    Public Sub OffsetStat(ByVal StatType As Integer, ByVal StatOffset As Integer)
        Stats(StatType) += StatOffset
    End Sub

    Public Sub OffsetStat(ByVal StatType As Integer, ByVal StatOffset As Integer, ByVal Reason As String)
        Stats(StatType) += StatOffset
        AddEvent(GetStatName(StatType) + ": " + Reason, StatOffset)
    End Sub
#End Region

#Region " Manipulate "
    Sub Cap()

        '-- Cap all stats between 0 and 100
        For i As Integer = 0 To Stats.Length - 1
            If Stats(i) > 100 Then
                Stats(i) = 100
            ElseIf Stats(i) < 0 Then
                Stats(i) = 0
            End If
        Next

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

    Public Sub FoundBuilding(Optional ByVal newBuildingId As Integer = -1)
        '-- Found a new building at the resident location of this citizen
        Dim newBuilding As Building = BuildingGenerator.CreateBuilding(newBuildingId)
        newBuilding.Founder = Me
        newBuilding.PurchasePrice = 0
        Residence.AddBuilding(newBuilding, Residence.OwnerID)

        '-- Record this citizen as the founder
        BuildingsFounded.Add(newBuilding)
        CountFounded += 1

        '-- Post event
        Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " founded a " + newBuilding.GetName())
        AddEvent("Founded a " + newBuilding.GetName())
    End Sub

    Public Sub SelfEmploy()
        '-- Self-employ at a random job
        Dim newBuilding As New SelfEmployBuilding(-1, 0, 1)
        newBuilding.ChooseSelfEmployment(Me)
        newBuilding.HireEmployee(Me, True)
    End Sub

    Public Sub UpdateInternal()
        Dim maxBonus, maxLoss As Double
        Dim statChange As Integer = 0
        Dim statChange2 As Integer = 0

        Dim thePop As Integer = Residence.getPopulation()
        Dim theRoad As Integer = Residence.Transportation

        AddEvent("Started in " + Residence.GetName())

        '-- Age
        Age = Age + TimeIncrement
        If Age <= 28 Then
            '-- Upslope
            OffsetStat(StatEnum.Health, 1)
        End If
        If Age >= 45 Then
            '-- Downslope
            maxLoss = (Age - 50.0) / 10.0
            If maxLoss < 0 Then
                maxLoss = 0
            End If
            statChange = GetRandom(maxLoss, maxLoss + 2)
            OffsetStat(StatEnum.Health, -statChange, "Aging")
        End If

        '--Health
        If GetStat(StatEnum.Health) < 15 Then
            '-- Deteriation
            OffsetStat(StatEnum.Health, -1, "Sickness")

            If GetStat(StatEnum.Employment) = 0 Then
                '-- Starving artist
                statChange = GetRandom(0, 3)
                OffsetStat(StatEnum.Creativity, statChange, "Starving artist")
            End If
        End If

        '--Happiness
        If GetStat(StatEnum.Happiness) >= 70 Then
            '-- Happiness improves health
            maxBonus = (GetStat(StatEnum.Happiness) - 60.0) / 10.0
            statChange = GetRandom(0, maxBonus)
            OffsetStat(StatEnum.Health, statChange, "Happy")
        ElseIf GetStat(StatEnum.Happiness) <= 10 Then
            '-- Depression sickness
            statChange = GetRandom(1, 3)
            OffsetStat(StatEnum.Health, -statChange, "Depressed")
        End If
        If GetStat(StatEnum.Happiness) <= 15 Then
            '-- Unhappy people lash out at society
            statChange = GetRandom(0, 2)
            OffsetStat(StatEnum.Criminality, statChange, "Angry and bitter")
        End If

        '--Employment
        If IsEmployed() Then
            TimeAtJob += TimeIncrement

            If IsSelfEmployed() Then
                '-- Be your own boss
                statChange = GetRandom(0, 1)
                OffsetStat(StatEnum.Happiness, statChange, "Self-employed")
            End If

            '-- Success leads to promotions
            maxBonus = (GetStat(StatEnum.Intelligence) / 8.0) + (GetStat(StatEnum.Creativity) / 9.0) ' - 5 (allow work performance to be bad and employee to be fired. Also maybe upper cap on this?
            statChange = GetRandom(0, maxBonus)
            OffsetStat(StatEnum.Employment, statChange, "Work performance")

            '-- Criminality drops
            statChange = GetRandom(0, 1)
            OffsetStat(StatEnum.Criminality, -statChange, "Steady employment")
        Else
            If Not IsMinor() Then

                If Residence.CountBuildingsByType(BuildingGen.BuildingEnum.Welfare_Service) > 0 Then
                    '-- Welfare service allows you to skip negative unemployment effects, but requires upkeep
                    Dim WelfareCost As Integer = 2
                    UnpaidUpkeep += WelfareCost
                    Dim WelfareService As Building = Residence.GetBuildingsByType(BuildingGen.BuildingEnum.Welfare_Service)(0)
                    WelfareService.AddUpkeep(WelfareCost)
                    WelfareService.AddEffects(1)
                Else
                    '-- Unemployment is depressing, limits food and healthcare options and, if times get desperate, can lead to crime
                    statChange = GetRandom(0, 3)
                    OffsetStat(StatEnum.Happiness, -statChange, "Unemployment frustration")

                    statChange = GetRandom(0, 3)
                    OffsetStat(StatEnum.Health, -statChange, "Lack of employment healthcare")

                    statChange = GetRandom(0, 2)
                    OffsetStat(StatEnum.Criminality, statChange, "Unemployment desperation")
                End If
            End If
        End If
        If GetStat(StatEnum.Employment) > 50 Then
            '-- Fast track
            maxBonus = ((GetStat(StatEnum.Employment) - 40.0) / 10.0)
            statChange = GetRandom(0, maxBonus)
            OffsetStat(StatEnum.Happiness, statChange, "Satisfying job")
        End If

        '--Intelligence and Creativity
        If Age <= 35 Then '-- Occurs 11 times
            '-- Personal drive
            statChange = GetRandom(0, SafeDivide(GetStat(StatEnum.Intelligence), 15.0))
            OffsetStat(StatEnum.Intelligence, statChange, "Youthful drive")

            statChange = GetRandom(0, SafeDivide(GetStat(StatEnum.Creativity), 15.0))
            OffsetStat(StatEnum.Creativity, statChange, "Youthful drive")
        End If
        If Age <= 18 Then '-- Occurs 5 times
            '-- Street smarts
            maxBonus = GetRandom(0, thePop / 8.0)

            '-- Primary school
            statChange = GetRandom(0, 4 + maxBonus)
            OffsetStat(StatEnum.Intelligence, statChange, "Primary school")

            statChange = GetRandom(0, 3 + maxBonus)
            OffsetStat(StatEnum.Creativity, statChange, "Primary school")
        End If
        If Age >= 18 And Age <= 25 Then '-- Occurs 3 times
            If GetStat(StatEnum.Intelligence) >= 30 + (thePop / 5.0) Then
                '-- Higher education. Gets more competitive with population.
                statChange = GetRandom(1, 4)
                OffsetStat(StatEnum.Intelligence, statChange, "Community college")

                statChange = GetRandom(1, 4)
                OffsetStat(StatEnum.Creativity, statChange, "Community college")
            Else
                statChange = GetRandom(0, 2)
                OffsetStat(StatEnum.Intelligence, statChange, "Apprenticeship")

                statChange = GetRandom(0, 2)
                OffsetStat(StatEnum.Creativity, statChange, "Apprenticeship")
            End If
        End If

        '-- Mobility and transportation
        maxBonus += GetRandom(theRoad / 2.0, theRoad)
        If Age <= 19 Then
            '-- Learn to walk, then to run
            statChange = GetRandom(1, 3)
            OffsetStat(StatEnum.Mobility, statChange, "Exercise")
        ElseIf Age >= 50 Then
            '-- Arthritis
            maxLoss = (Age - 40.0) / 8.5
            statChange = GetRandom(0, maxLoss)
            OffsetStat(StatEnum.Mobility, -statChange, "Arthritis")
        End If
        If Age = 16 Then
            '-- Learn to drive
            statChange = GetRandom(3, 8)
            OffsetStat(StatEnum.Mobility, statChange, "Drivers license")
        End If


        '-- Drunkenness
        If GetStat(StatEnum.Drunkenness) >= 10 Then
            '-- Addiction
            maxBonus = GetStat(StatEnum.Drunkenness) / 10.0
            statChange = GetRandom(0, maxBonus)
            OffsetStat(StatEnum.Drunkenness, statChange, "Dependence")
        End If
        If GetStat(StatEnum.Drunkenness) >= 2 And GetStat(StatEnum.Drunkenness) <= 20 And Age >= 10 Then
            '-- Pleasant buzz
            statChange = GetRandom(0, 2)
            OffsetStat(StatEnum.Happiness, statChange, "Pleasantly buzzed")
        End If
        If GetStat(StatEnum.Drunkenness) >= 25 Then
            '-- Liver damage
            maxLoss = GetStat(StatEnum.Drunkenness) / 13.0
            statChange = GetRandom(0, maxLoss)
            OffsetStat(StatEnum.Health, -statChange, "Liver damage")
        End If
        If GetStat(StatEnum.Drunkenness) >= 30 Then
            '-- Destructive lifestyle
            statChange = GetRandom(0, 2)
            OffsetStat(StatEnum.Happiness, statChange, "Destructive lifestyle")
        End If
        If GetStat(StatEnum.Drunkenness) >= 40 And GetStat(StatEnum.Health) <= 12 And GetRandom(0, 100) <= 15 Then
            '-- Go cold turkey
            OffsetStat(StatEnum.Drunkenness, -100, "Cold turkey")
        End If

        '-- Population
        Dim AdjustedPopulation As Integer = Residence.GetAdjustedPopulation()
        If AdjustedPopulation >= 5 Then
            '-- A person suffers from urban blight once per 5 population
            Dim numberOfBlights As Integer = Math.Floor(SafeDivide(AdjustedPopulation, 5.0))

            For i As Integer = 0 To numberOfBlights - 1
                maxBonus = SafeDivide(AdjustedPopulation, 5.0)
                Dim switchman As Integer = GetRandom(0, 2)
                '-- Crowded areas reduces health, happiness and increased crime
                If switchman = 0 Then
                    statChange = GetRandom(0, maxBonus)
                    OffsetStat(StatEnum.Criminality, statChange, "Overpopulation")
                ElseIf switchman = 1 Then
                    statChange = GetRandom(0, maxBonus)
                    OffsetStat(StatEnum.Happiness, -statChange, "Overpopulation")
                Else
                    statChange = GetRandom(0, maxBonus)
                    OffsetStat(StatEnum.Health, -statChange, "Overpopulation")
                End If
            Next
        End If

        '-- Terrain
        Select Case (Residence.Terrain)
            Case TerrainEnum.Forest
                statChange = GetRandom(1, 3)
                OffsetStat(StatEnum.Happiness, statChange, GetTerrainName(Residence.Terrain) + " life")

                statChange = GetRandom(1, 3)
                OffsetStat(StatEnum.Health, statChange, GetTerrainName(Residence.Terrain) + " life")
            Case TerrainEnum.Mountain
                statChange = GetRandom(1, 3)
                OffsetStat(StatEnum.Creativity, statChange, GetTerrainName(Residence.Terrain) + " life")

                statChange = GetRandom(0, 2)
                OffsetStat(StatEnum.Mobility, -statChange, GetTerrainName(Residence.Terrain) + " life")
            Case TerrainEnum.Swamp
                statChange = GetRandom(2, 4)
                OffsetStat(StatEnum.Health, -statChange, GetTerrainName(Residence.Terrain) + " life")
            Case TerrainEnum.Dirt
                statChange = GetRandom(0, 2)
                OffsetStat(StatEnum.Creativity, -statChange, GetTerrainName(Residence.Terrain) + " life")
            Case TerrainEnum.Desert
                statChange = GetRandom(1, 3)
                OffsetStat(StatEnum.Mobility, statChange, GetTerrainName(Residence.Terrain) + " life")
        End Select
        If Residence.Coastal Then
            '-- Coastal areas make people happier
            statChange = GetRandom(1, 2)
            OffsetStat(StatEnum.Happiness, statChange, "Coastal life")
        End If

        '-- Cap all values between 0 and 100
        Cap()


        If Not IsMinor() Then
            '-- Found new buildings
            If GetRandom(1, 2000) < GetStat(StatEnum.Intelligence) Then
                FoundBuilding(-1)
            End If

            '-- Self Employ
            If Not IsSelfEmployed() Then
                Dim SelfEmployOdds As Integer = GetStat(StatEnum.Creativity)
                If IsEmployed() Then '-- Odds of self-employment go up when unemployed
                    SelfEmployOdds *= 2.0
                End If
                If GetRandom(1, 1000) < SelfEmployOdds Then
                    SelfEmploy()
                End If
            End If
        End If
    End Sub

#Region " Reproduce "
    Function WillReproduce(Optional ByVal Adjustment As Double = 1.0) As Boolean
        'Remove happiness constraint?
        If Age >= 16 And Age <= 49 And GetStat(StatEnum.Health) > 15 And GetStat(StatEnum.Health) > 10 Then
            Dim Odds As Double = 0.0
            Odds += (25.0 - Math.Abs(25.0 - Age))
            Odds += (GetStat(StatEnum.Health) / 7.0)
            Odds += (GetStat(StatEnum.Happiness) / 10.0)
            Odds += Math.Min(5, GetStat(StatEnum.Drunkenness) / 6.0)
            Odds += (GetStat(StatEnum.Employment) / 20.0)

            Odds *= Adjustment

            If GetRandom(0, 100) <= Odds Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function Reproduce() As Citizen
        Dim child As New Citizen(Me)
        child.BirthPlace = Residence
        child.Residence = Residence
        Residence.People.Add(child)
        AddEvent("Gave birth to " + child.Name)
        Return child
    End Function

#End Region

#Region " Death "
    Function GetDeathOdds(ByVal CauseOfDeath As Integer) As Double
        Dim Odds As Double = 0.0
        Select Case CauseOfDeath
            Case DeathEnum.Illness
                Odds = (32.0 - GetStat(StatEnum.Health)) / 4.0
            Case DeathEnum.Murder
            Case DeathEnum.NaturalCauses
                '-- Science increases average life expectancy
                Dim AdjustedAge As Integer = Age - Players(Residence.OwnerID).ScienceCount
                Odds += (Age - 20.0) / 4.0
            Case DeathEnum.TrafficAccident
                Dim currentLocation As CitySquare = Residence
                Odds = 0.0
                Odds += GetStat(StatEnum.Mobility) / 10.0
                Odds += GetStat(StatEnum.Drunkenness) / 4.0
                Odds += (currentLocation.getPopulation / 5.0)
                Odds -= (currentLocation.Transportation * 2.5)
                If Age < 15 Then
                    Odds /= 2.0
                End If
            Case DeathEnum.Unknown

        End Select
        Return Odds
    End Function

    Function WillDie(ByVal CauseOfDeath As Integer) As Boolean

        If GetRandom(1, 100) < GetDeathOdds(CauseOfDeath) Then
            Return True
        End If

        Select Case CauseOfDeath
            Case DeathEnum.Illness
            Case DeathEnum.Murder
            Case DeathEnum.NaturalCauses
                If StatEnum.Health <= 0 Then
                    Return True
                End If
            Case DeathEnum.TrafficAccident
            Case DeathEnum.Unknown

        End Select
        Return False
    End Function

    Function Die(ByVal CauseOfDeath As Integer) As Boolean
        'Free dead person's job
        If JobBuilding IsNot Nothing Then
            JobBuilding.Employees.Remove(Me)
        End If

        '-- Record the age and cause of death at their residence
        Residence.DeathAges.Add(Age)
        Residence.DeathCauseCounts(CauseOfDeath) += 1

        'Free dead person's residence
        Residence.People.Remove(Me)

        '-- Record cause of death
        Select Case CauseOfDeath
            Case DeathEnum.Illness
                AddEvent("Died of illness")
                Diary.DeathIllnessEvents.AddEvent(GetNameAndAddress() + ", age " + Age.ToString() + ", died of illness")
            Case DeathEnum.Murder
                AddEvent("Murdered")
            Case DeathEnum.NaturalCauses
                AddEvent("Died of natural causes")
                Diary.DeathNaturalEvents.AddEvent(GetNameAndAddress() + ", age " + Age.ToString() + ", died of natural causes")
            Case DeathEnum.TrafficAccident
                AddEvent("Died in traffic accident")
                Diary.DeathTrafficEvents.AddEvent(GetNameAndAddress() + ", age " + Age.ToString() + ", died in a car accident")
            Case DeathEnum.ResistingArrest
                AddEvent("Died resisting arrest")
            Case DeathEnum.Unknown
                AddEvent("Died of unknown causes")
        End Select

        Return True
    End Function
#End Region

#Region " Employment "
    Function IsEmployed() As Boolean
        Return (JobBuilding IsNot Nothing)
    End Function

    Function IsSelfEmployed() As Boolean
        If JobBuilding Is Nothing Then
            Return False
        End If

        Return JobBuilding.Type = BuildingGen.SelfEmployed
    End Function

    Function WillApply(ByRef newJob As Building) As Boolean

        If IsEmployed() Then
            '-- If already employed, make sure this other opportunity is better
            If TimeAtJob <= TimeIncrement Or newJob.GetBaseCost() <= JobBuilding.GetBaseCost() Then '-- Change this to salary in future
                Return False
            End If

            '-- Even if the opportunity is better, stick with your current job most of the time
            If GetRandom(1, 100) <= 85 Then
                Return False
            End If
        End If

        Return True
    End Function

    Sub ApplicationAccepted()

        TimeAtJob = 0
        OffsetStat(StatEnum.Employment, 1)
        OffsetStat(StatEnum.Happiness, 3, "New job")

        If IsSelfEmployed() Then
            AddEvent(JobBuilding.GetEmploymentStatement())
        Else
            AddEvent("Hired by the " + JobBuilding.GetNameAndAddress())
        End If

        If Age <= MinorAge Then
            '-- If employed from an early age, buy a hotrod
            Dim statChange As Integer = GetRandom(3, 4)
            OffsetStat(StatEnum.Mobility, statChange, "Bought car while young")
        End If
    End Sub

    Sub ApplicationRejected()

        AddEvent("Job application rejected by the " + GetNameAndAddress())

        '-- Deal with rejection by disappointment or drinking
        If GetRandom(0, 1) = 0 Then
            OffsetStat(StatEnum.Happiness, -1, "Turned down for a job")
        Else
            OffsetStat(StatEnum.Drunkenness, 1, "Turned down for a job")
        End If

    End Sub

    Sub Fired()
        '-- Fired from job
        If JobBuilding IsNot Nothing Then

            '-- Can't be fired from self-employment
            If IsSelfEmployed() Then
                Return
            End If

            JobBuilding.Employees.Remove(Me)
            AddEvent("Fired from the " + JobBuilding.GetNameAndAddress())
            JobBuilding = Nothing
        End If
    End Sub
#End Region

#Region " Crimes "
    Function GetCrimeOdds(ByVal CrimeType As Integer) As Double
        Dim Odds As Double = 0.0
        Select Case CrimeType
            Case CrimeEnum.Parking_Tickets
                Odds += GetStat(StatEnum.Criminality) / 10.0
            Case CrimeEnum.Traffic_Tickets
                '-- Traffic accidents increase with alcohol and frequent travelling
                Odds += GetStat(StatEnum.Criminality) / 8.0
                Odds += GetStat(StatEnum.Drunkenness) / 4.0
                Odds += GetStat(StatEnum.Mobility) / 9.0
            Case CrimeEnum.Robbery
                '-- Robbery increase with unemployment
                Odds += GetStat(StatEnum.Criminality) / 3.0
                Odds -= GetStat(StatEnum.Employment) / 5.0
            Case CrimeEnum.Vandalism
                '-- Vandalism increases when juveniles flock together
                Odds += GetStat(StatEnum.Criminality) / 12.0
                If IsInAgeRange(8, 22) Then
                    Odds += Residence.GetCitizensInAgeRange(8, 22)
                End If
            Case CrimeEnum.Arson
                '-- Arson increases with unhappiness and claustraphobia
                Odds += GetStat(StatEnum.Criminality) / 8.0
                Odds -= (GetStat(StatEnum.Happiness) - 20) / 10.0
                Odds += (Residence.getDevelopment() - 2)
            Case CrimeEnum.Murder
                '-- Murder increases when drunk and angry?
                Odds += GetStat(StatEnum.Criminality) / 6.5
                Odds += GetStat(StatEnum.Drunkenness) / 9.0
            Case CrimeEnum.Unknown

        End Select
        Return Odds
    End Function

    Function WillCommitCrime(ByVal CrimeType As Integer, ByVal Optional OptionalData As Integer = 0) As Boolean

        Dim MinCrimeAge As Integer = MinorAge
        Dim MaxRand As Integer = 100

        Select Case CrimeType
            Case CrimeEnum.Parking_Tickets
            Case CrimeEnum.Traffic_Tickets
                MaxRand = 200
            Case CrimeEnum.Robbery
            Case CrimeEnum.Vandalism
                '-- No vandalism if no buildings present.
                MinCrimeAge = 8
                If Residence.Buildings.Count = 0 Then
                    Return False
                End If
            Case CrimeEnum.Arson
                '-- No arson if no buildings present. Arson is less likely when the player has few total buildings.
                If Residence.Buildings.Count = 0 Or GetRandom(0, 9) > OptionalData Then
                    Return False
                End If
                MaxRand = 150
            Case CrimeEnum.Murder
                '-- Can't murder someone if you are all alone
                If Residence.People.Count < 2 Then
                    Return False
                End If
            Case CrimeEnum.Unknown
        End Select

        '-- No crime for extreme youths
        If Age < MinCrimeAge Then
            Return False
        End If

        If GetRandom(1, MaxRand) < GetCrimeOdds(CrimeType) Then
            Return True
        End If

        Return False
    End Function

    Function CommitCrime(ByVal CrimeType As Integer, ByVal Optional ExtraText As String = "") As Boolean

        CrimeCount(CrimeType) += 1

        '-- Record cause of death
        Select Case CrimeType
            Case CrimeEnum.Parking_Tickets
                UnpaidFines += 1
                AddEvent("Received a parking ticket")
            Case CrimeEnum.Traffic_Tickets
                UnpaidFines += 2
                AddEvent("Received a traffic ticket")
            Case CrimeEnum.Robbery
                AddEvent("Stole $" + ExtraText)
                Diary.TheftEvents.AddEvent(GetNameAndAddress() + " stole $" + ExtraText)
            Case CrimeEnum.Vandalism
                AddEvent("Vandalized the " + ExtraText)
                Diary.VandalismEvents.AddEvent(Name + " vandalized the " + ExtraText)
            Case CrimeEnum.Arson
                AddEvent("Burned down the " + ExtraText)
                Diary.ArsonEvents.AddEvent(Name + " burned down the " + ExtraText)
            Case CrimeEnum.Murder
                AddEvent("Killed " + ExtraText)
                Diary.MurderEvents.AddEvent(Name + " killed " + ExtraText)

                '-- Possibility to trigger a killing spree
                If GetRandom(0, 2) = 0 Then
                    OffsetStat(StatEnum.Criminality, GetRandom(4, 10), "Serial killer")
                Else
                    OffsetStat(StatEnum.Criminality, GetRandom(0, 3))
                End If
            Case CrimeEnum.Unknown
                AddEvent("Committed unknown crime")
        End Select

        Return True
    End Function
#End Region


    Public Function CollectFines() As Integer
        Dim FinesDue As Integer = UnpaidFines
        UnpaidFines = 0
        Return FinesDue
    End Function

    Public Function CollectUpkeep() As Integer
        Dim UpkeepDue As Integer = UnpaidUpkeep
        UnpaidUpkeep = 0
        Return UpkeepDue
    End Function

#End Region

#Region " Movement "
    Public Function WillMove(ByRef thisLocation As CitySquare) As Boolean

        Dim DissuasiveFactors As Integer = 0

        '-- People are reluctant to move to the desert
        If thisLocation.Terrain = TerrainEnum.Desert Then
            DissuasiveFactors += 1
        End If
        '-- People are reluctant to move to locations with disreputable buildings
        DissuasiveFactors += thisLocation.CountBuildingsByTag(BuildingGen.TagEnum.Disreputable)

        If DissuasiveFactors = 0 Then
            Return True
        End If

        Dim OddsOfMoving As Double = SafeDivide(100, DissuasiveFactors + 1)

        Return (GetRandom(1, 100) < OddsOfMoving)
    End Function

    Public Function WillVisit(ByRef thisLocation As CitySquare) As Boolean
        '-- Every dissuasive building reduces the change a citizen will visit by 10%
        Dim DissuasiveFactors As Integer = thisLocation.CountBuildingsByTag(BuildingGen.TagEnum.Disreputable)
        Dim OddsOfVisiting As Double = 100 - (10 * DissuasiveFactors)
        Return (GetRandom(1, 100) < OddsOfVisiting)
    End Function
#End Region

#Region " Support "

    Public Function GetNameAndAddress() As String
        Return Name.ToString() + " of " + Residence.GetName()
    End Function

    Public Function IsInAgeRange(ByVal LowerAge As Integer, ByVal UpperAge As Integer) As Boolean
        Return (LowerAge <= Age And Age <= UpperAge)
    End Function

    Public Function IsMinor() As Boolean
        Return (Age < MinorAge)
    End Function

    Public Function IsElderly() As Boolean
        Return (Age >= ElderAge)
    End Function

    Public Function GetCitizenValue() As Double
        '-- This value is used to determine score
        Dim personPoints As Integer = 0
        personPoints += (StatEnum.Happiness * 2.5)
        personPoints += StatEnum.Health
        personPoints += (StatEnum.Employment * 1.8)
        personPoints += StatEnum.Intelligence
        personPoints += StatEnum.Creativity
        personPoints += (StatEnum.Mobility * 0.5)
        personPoints -= (StatEnum.Criminality * 2.0)
        personPoints -= (StatEnum.Drunkenness * 1.3)
        personPoints = SafeDivide(personPoints, 180.0)
        If personPoints > 0 Then
            personPoints = personPoints ^ 1.6
        End If
    End Function

    Public Function PrintStat(ByVal StatType As Integer) As String
        Return GetStatName(StatType) + ": " + GetStat(StatType).ToString + ControlChars.NewLine
    End Function

    Public Function PrintCrime(ByVal CrimeType As Integer) As String
        Return GetCrimeName(CrimeType) + ": " + CrimeCount(CrimeType).ToString + ControlChars.NewLine
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
        For i As Integer = 0 To Stats.Length - 1
            PersonString += PrintStat(i)
        Next
        PersonString += ControlChars.NewLine

        '-- Print the citizen's employment status
        Dim WorkStatus As String = ""
        If IsMinor() Then
            WorkStatus += "Minor." + ControlChars.NewLine
        End If
        If JobBuilding Is Nothing Then
            If Not IsMinor() Then
                WorkStatus += "Currently unemployed." + ControlChars.NewLine
            End If
        Else
            WorkStatus += JobBuilding.GetEmploymentStatement() + "." + ControlChars.NewLine
        End If
        If WorkStatus.Length > 0 Then
            PersonString += WorkStatus + ControlChars.NewLine
        End If

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
        Dim CrimeString As String = ""
        For i As Integer = 0 To CrimeEnum.EnumEnd - 1
            If CrimeCount(i) > 0 Then
                CrimeString += PrintCrime(i).ToString
            End If
        Next
        If CrimeString.Length > 0 Then
            PersonString += CrimeString + ControlChars.NewLine
        End If

        '-- Print this person's "life Journey" (everything they did including all stat changes)
        If Residence.CountBuildingsByType(BuildingGen.BuildingEnum.Detective_Agency) > 0 Or DebugMode Then
            PersonString += JourneyString + ControlChars.NewLine
        End If


        Return PersonString
    End Function
#End Region



End Class

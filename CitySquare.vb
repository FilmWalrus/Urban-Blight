Public Class CitySquare
    Implements IComparable

#Region " Variables "
    Public RowID As Integer = 0
    Public ColID As Integer = 0
    Public OwnerID As Integer = -1
    Public CityName As String = ""

    '-- Travel and visit
    Public VisitedKey As Integer = -1
    Public DragLoss As Integer = -1
    Public VisitMethodAttempt As Building = Nothing
    Public VisitMethod As Building = Nothing
    Public VisitOrder As Integer = 0

    '--
    Public GridSquare As LabelWithTextBorder = Nothing

    '-- Terrain
    Public Terrain As Integer = TerrainEnum.Plain
    Public Coastal As Boolean = False

    '-- Residents
    Public People As New List(Of Citizen)

    '-- Roads
    Public Transportation As Integer = RoadEnum.None

    '-- Buildings
    Public Buildings As New List(Of Building)
    Public NeighborBuildings As New List(Of Building)
    Public BuildingHistory As Integer = 0
    Public FoundedHistory As Integer = 0
    Public ClosedHistory As Integer = 0

    '-- Mortality Info
    Public DeathAges As New List(Of Integer)
    Public DeathCauseCounts(DeathEnum.EnumEnd - 1) As Integer

    '-- Other Info
    Public OrderAcquired As Integer = 1
    Public NatureCount As Integer = 0
    Public FoodCount As Integer = 0

    Public Enum TransportType
        Bike
        Boat
        Car
        Plane
        Train
        Taxi
    End Enum
#End Region

#Region " New "
    Public Sub New()

    End Sub

    Public Sub New(ByVal row As Integer, ByVal col As Integer)
        RowID = row
        ColID = col

        '-- Randomly determine the terrain type
        Dim tempNum As Integer = GetRandom(1, 100)
        If tempNum <= 10 Then
            Terrain = TerrainEnum.Forest
        ElseIf tempNum <= 20 Then
            Terrain = TerrainEnum.Mountain
        ElseIf tempNum <= 27 Then
            Terrain = TerrainEnum.Dirt
        ElseIf tempNum <= 32 Then
            Terrain = TerrainEnum.Desert
        ElseIf tempNum <= 38 Then
            Terrain = TerrainEnum.Swamp
        ElseIf tempNum <= 44 Then
            Terrain = TerrainEnum.Township
        ElseIf tempNum <= 52 Then
            Terrain = TerrainEnum.Lake
        Else
            Terrain = TerrainEnum.Plain
        End If

        '-- Create the GUI label/button that represents this citySquare
        GridSquare = New LabelWithTextBorder
        UpdateTerrain()
        'Select Case (Terrain)
        '    Case TerrainEnum.Plain
        '        GridSquare.BackColor = ColorPlain
        '    Case TerrainEnum.Dirt
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorDirt
        '    Case TerrainEnum.Forest
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorForest
        '    Case TerrainEnum.Mountain
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorMountain
        '    Case TerrainEnum.Lake
        '        GridSquare.BackColor = ColorOcean
        '    Case TerrainEnum.Swamp
        '        GridSquare.BackColor = ColorSwamp
        '    Case TerrainEnum.Township
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorTownship
        '    Case TerrainEnum.Desert
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorDesert
        'End Select

        GridSquare.Name = "NewBox"
        GridSquare.Tag = row & "," & col
        GridSquare.TabStop = False
        GridSquare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        GridSquare.Text = "0"
        GridSquare.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Public Sub SetTerrain(ByVal TerrainType As Integer)
        Terrain = TerrainType
        UpdateTerrain()
    End Sub

    Public Sub UpdateTerrain()
        GridSquare.BackColor = ColorPlain

        Dim randImageIndex As Integer = GetRandom(1, 2)

        Select Case Terrain
            Case TerrainEnum.Plain
                If GetRandom(1, 20) = 1 Then
                    GridSquare.Image = My.Resources.ResourceManager.GetObject("Flowers1")
                Else
                    GridSquare.Image = Nothing
                End If
            Case TerrainEnum.Forest
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Forest" + GetRandom(1, 3).ToString)
            Case TerrainEnum.Mountain
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Mountain" + GetRandom(1, 3).ToString)
            Case TerrainEnum.Lake
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Lake1")
            Case TerrainEnum.Township
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Township" + GetRandom(1, 3).ToString)
            Case TerrainEnum.Desert
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Desert1")
            Case TerrainEnum.Dirt
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Dirt" + GetRandom(1, 3).ToString)
            Case TerrainEnum.Swamp
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Swamp" + GetRandom(1, 2).ToString)
        End Select

        '-- Old graphics: Just color, no image
        'Select Case (Terrain)
        '    Case TerrainEnum.Plain
        '        GridSquare.BackColor = ColorPlain
        '    Case TerrainEnum.Dirt
        '        GridSquare.BackColor = ColorDirt
        '    Case TerrainEnum.Forest
        '        GridSquare.BackColor = ColorForest
        '    Case TerrainEnum.Mountain
        '        GridSquare.BackColor = ColorMountain
        '    Case TerrainEnum.Lake
        '        GridSquare.BackColor = ColorOcean
        '    Case TerrainEnum.Swamp
        '        GridSquare.BackColor = ColorSwamp
        '    Case TerrainEnum.Township
        '        GridSquare.BackColor = ColorTownship
        '    Case TerrainEnum.Desert
        '        GridSquare.BackColor = ColorDesert
        'End Select
    End Sub

#End Region

#Region " Accessors "
    Public Function getPopulation() As Integer
        Return People.Count
    End Function

    Public Function GetAdjustedPopulation() As Integer
        Dim AdjustedPopluation As Integer = getPopulation()

        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            If thisBuilding.Type = BuildingGen.BuildingEnum.Apartments Then
                '-- Apartment buildings reduce effective population by 10
                AdjustedPopluation -= 10
            End If
            If thisBuilding.Type = BuildingGen.BuildingEnum.Apartments Then
                '-- Suburb buildings reduce effective population by 5
                AdjustedPopluation -= 5
            End If
            If thisBuilding.HasTag(BuildingGen.TagEnum.Entertainment) Then
                '-- Each building with an Entertainment tag reduces population by 1
                AdjustedPopluation -= 1
            End If
        Next

        Return AdjustedPopluation
    End Function

    Public Function getDevelopment() As Integer
        Return Buildings.Count
    End Function

    Public Function getCulture() As Double
        Dim cultureValue As Double = 0.0
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            cultureValue += thisBuilding.GetValueForCitizen()
        Next
        Return cultureValue
    End Function

    Public Function getJobsTotal() As Integer
        Dim jobTotal As Integer = 0
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            jobTotal += thisBuilding.Jobs
        Next
        Return jobTotal
    End Function

    Public Function getJobsFilled() As Integer
        Dim jobFilled As Integer = 0
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            jobFilled += thisBuilding.GetEmployeeCount()
        Next
        Return jobFilled
    End Function

    Public Function getJobsEmpty() As Integer
        Return getJobsTotal() - getJobsFilled()
    End Function

    Public Function getUnemployment(ByVal AdultsOnly As Boolean) As Integer
        '-- We have to actually check every citizen since they might have jobs elsewhere
        Dim citizensUnemployed As Integer = 0
        For i As Integer = 0 To People.Count - 1
            '-- Add up how many citizens unemployed
            Dim currentCitizen As Citizen = People(i)
            If currentCitizen.JobBuilding Is Nothing Then
                If AdultsOnly And currentCitizen.IsMinor Then
                    Continue For
                End If
                citizensUnemployed += 1
            End If
        Next
        Return citizensUnemployed
    End Function

    Public Function getUnemploymentValue() As Double
        '-- We have to actually check every citizen since they might have jobs elsewhere
        Dim unemploymentValue As Double = 0.0
        For i As Integer = 0 To People.Count - 1
            '-- Add up how many citizens unemployed
            Dim currentCitizen As Citizen = People(i)
            If currentCitizen.JobBuilding Is Nothing Then
                If currentCitizen.IsMinor() Then
                    '-- Count minors as a fraction of an adult based on how close they are to working age
                    unemploymentValue += (currentCitizen.Age / Citizen.MinorAge)
                Else
                    unemploymentValue += 1
                End If
            End If
        Next
        Return unemploymentValue
    End Function

    Public Function getEmployment(Optional ByVal SelfEmployedOnly As Boolean = False) As Integer
        '-- We have to actually check every citizen since they might have jobs elsewhere
        Dim citizensEmployed As Integer = 0
        For i As Integer = 0 To People.Count - 1
            '-- Add up how many citizens employed
            Dim currentCitizen As Citizen = People(i)
            If currentCitizen.JobBuilding IsNot Nothing Then
                If SelfEmployedOnly Then
                    If currentCitizen.IsSelfEmployed() Then
                        citizensEmployed += 1
                    End If
                Else
                    citizensEmployed += 1
                End If
            End If
        Next
        Return citizensEmployed
    End Function

    Public Function GetFoodAdjust() As Double
        '-- Each food building on this location increases the birthrate by 2%
        Dim FoodAdjust As Double = (FoodCount * 0.02) + 1.0
        Return FoodAdjust
    End Function

    Public Function CountBuildingsByType(ByVal bType As Integer) As Integer
        Dim buildingCount As Integer = 0
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            If thisBuilding.Type = bType Then
                buildingCount += 1
            End If
        Next
        Return buildingCount
    End Function

    Public Function CountBuildingsByTag(ByVal bTag As Integer) As Integer
        Dim buildingCount As Integer = 0
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            If thisBuilding.HasTag(bTag) Then
                buildingCount += 1
            End If
        Next
        Return buildingCount
    End Function

    Public Function GetBuildingsByType(ByVal bType As Integer) As List(Of Building)
        Dim buildingList As New List(Of Building)
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            If thisBuilding.Type = bType Then
                buildingList.Add(thisBuilding)
            End If
        Next
        Return buildingList
    End Function

    Public Function GetBuildingsByTag(ByVal bTag As Integer) As List(Of Building)
        Dim buildingList As New List(Of Building)
        For i As Integer = 0 To Buildings.Count - 1
            Dim thisBuilding As Building = Buildings(i)
            If thisBuilding.HasTag(bTag) Then
                buildingList.Add(thisBuilding)
            End If
        Next
        Return buildingList
    End Function
#End Region

#Region " Functions "
    Public Function ShowID() As String
        Return RowID.ToString() + "," + ColID.ToString()
    End Function

    Public Function GetName() As String
        If CityName.Length > 0 Then
            Return CityName
        Else
            Return "(" + (RowID + 1).ToString() + "," + (ColID + 1).ToString() + ")"
        End If
    End Function

    Public Function IsOwned() As Boolean
        Return (OwnerID >= 0)
    End Function

    Public Function IsOwned(ByVal playerID As Integer) As Boolean
        Return (OwnerID = playerID)
    End Function

    Public Sub Occupy(ByVal PlayerID As Integer)
        OwnerID = PlayerID
        '-- Generate random city name
        CityName = Namer.GenerateCityName(Me)

        Dim thePlayer As Player = Players(PlayerID)
        OrderAcquired = thePlayer.GetPlayerTerritoryCount()

        '-- Check if this is connected via an exurb
        If thePlayer.ExurbStations.Count > 0 Then
            '-- Find the home and work commuter stations that we should connect
            Dim WorkStation As ExurbBuilding = thePlayer.ExurbStations(0)
            Dim HomeStation As ExurbBuilding = BuildingGenerator.CreateBuilding(BuildingGen.BuildingEnum.Exurb)
            Me.AddBuilding(HomeStation, PlayerID, False)

            '-- Link these two stations
            WorkStation.PairedStation = HomeStation
            HomeStation.PairedStation = WorkStation

            '-- Remove the exurb from the player lists
            thePlayer.ExurbStations.Remove(WorkStation)
            thePlayer.LandOptionBuildings.Remove(WorkStation)

            '-- Seed the location with people
            HomeStation.Location.AddNewPeople(2)
        End If
    End Sub

    Public Sub AddBuilding(ByVal NewBuilding As Building, ByVal PlayerIndex As Integer, Optional ByVal TriggerConstruction As Boolean = True)
        NewBuilding.Location = Me
        NewBuilding.OwnerID = PlayerIndex
        Buildings.Add(NewBuilding)

        '-- Activate any construction effects
        If TriggerConstruction Then
            NewBuilding.ConstructionEffects()
        End If

        '-- Record the history of how many buildings were built here
        BuildingHistory += 1
        If NewBuilding.Founder IsNot Nothing Then
            FoundedHistory += 1
        End If
    End Sub

    Public Sub AddRoad()
        Transportation = Transportation + 1
        If Transportation > RoadEnum.Highway Then
            Transportation = RoadEnum.Highway
        End If
    End Sub

    Public Sub AddPerson(ByVal newPerson As Citizen)
        '-- Use for immigration
        newPerson.Residence = Me
        People.Add(newPerson)
    End Sub

    Public Sub AddNewPeople(ByVal NewPeopleCount As Integer)
        For i As Integer = 0 To NewPeopleCount - 1
            Dim SeedPerson As New Citizen(True)
            AddPerson(SeedPerson)
        Next
    End Sub

    Function GetDistance(ByRef OtherSquare As CitySquare) As Integer
        Return Math.Abs(RowID - OtherSquare.RowID) + Math.Abs(ColID - OtherSquare.ColID)
    End Function

    Sub UpdateCoastline()

        '-- Lakes can't be coastal
        If Terrain = TerrainEnum.Lake Then
            Coastal = False
            Return
        End If

        '-- Any other terrain next to a lake is coastal
        Dim adjacentList As List(Of CitySquare) = GetTrueAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            Dim neighborLocation As CitySquare = adjacentList(i)
            If neighborLocation.Terrain = TerrainEnum.Lake Then
                Coastal = True
                Return
            End If
        Next
        Coastal = False
    End Sub

#Region " View Data "
    Public Function GetMinors() As Integer
        Dim PersonCount As Integer = 0
        For Each Person As Citizen In People
            If Person.IsMinor() Then
                PersonCount += 1
            End If
        Next
        Return PersonCount
    End Function

    Public Function GetElderly() As Integer
        Dim PersonCount As Integer = 0
        For Each Person As Citizen In People
            If Person.IsElderly() Then
                PersonCount += 1
            End If
        Next
        Return PersonCount
    End Function

    Public Function GetCitizensInAgeRange(ByVal LowerAge As Integer, ByVal UpperAge As Integer) As Integer
        Dim PersonCount As Integer = 0
        For Each Person As Citizen In People
            If Person.IsInAgeRange(LowerAge, UpperAge) Then
                PersonCount += 1
            End If
        Next
        Return PersonCount
    End Function

    Public Function AgeView(ByVal MaxAge As Boolean) As Integer

        Dim AgeStat As Integer = 0
        Dim PersonCount As Integer = 0

        '-- Calculate average age or maximum age
        For Each Person As Citizen In People
            If MaxAge Then
                If Person.Age > AgeStat Then
                    AgeStat = Person.Age
                End If
            Else
                AgeStat += Person.Age
                PersonCount += 1
            End If
        Next

        If MaxAge Then
            Return AgeStat
        Else
            Return SafeDivide(AgeStat, PersonCount)
        End If
    End Function

    Public Function BuildingsOwnedByPlayer(ByVal PlayerNumber As Integer) As Integer
        Dim BuildingCount As Integer = 0
        For Each theBuilding As Building In Buildings
            If PlayerNumber = -1 Then
                '-- Count buildings owned by the current player
                If theBuilding.OwnerID = CurrentPlayer.ID Then
                    BuildingCount += 1
                End If
            ElseIf PlayerNumber = -2 Then
                '-- Count buildings owned by everyone not the current player
                If theBuilding.OwnerID <> CurrentPlayer.ID Then
                    BuildingCount += 1
                End If
            Else
                '-- Count buildings owned by the input player
                If theBuilding.OwnerID = PlayerNumber Then
                    BuildingCount += 1
                End If
            End If
        Next
        Return BuildingCount
    End Function

    Public Function GetCrimes(ByVal CrimeType As Integer) As Integer
        '-- Calculate counts of crimes committed by people at this location
        Dim CrimeCount As Integer = 0
        For Each Person As Citizen In People
            CrimeCount += Person.CrimeCount(CrimeType)
        Next
        Return CrimeCount
    End Function

    Public Function GetAverageLifespan() As Integer
        Dim LifeSpanStat As Integer = 0
        Dim PersonCount As Integer = 0

        '-- Calculate average age or maximum age
        For Each DeathAge As Integer In DeathAges
            LifeSpanStat += DeathAge
            PersonCount += 1
        Next

        Return SafeDivide(LifeSpanStat, PersonCount)
    End Function

    Public Function SumBuildingView(ByVal ViewType As Integer) As Integer

        Dim Sum As Integer = 0

        For Each CurrentBuilding As Building In Buildings
            Select Case ViewType
                Case ViewEnum.Revenue_This_Turn
                    Sum += CurrentBuilding.CurrentRevenue
                Case ViewEnum.Total_Revenue
                    Sum += CurrentBuilding.TotalRevenue
                Case ViewEnum.Upkeep_This_Turn
                    Sum += CurrentBuilding.CurrentUpkeep
                Case ViewEnum.Total_Upkeep
                    Sum += CurrentBuilding.TotalUpkeep
            End Select
        Next

        Return Sum
    End Function

    Public Function ComputeAverage(ByVal StatType As Integer, ByVal AdultsOnly As Boolean) As Integer

        Dim AvgStat As Integer = 0
        Dim PersonCount As Integer = 0

        For Each Person As Citizen In People
            Person.Cap()
            If AdultsOnly Then '-- Get an average that includes only adults
                If Person.IsMinor Then
                    Continue For
                End If
            End If
            AvgStat += Person.GetStat(StatType)
            PersonCount += 1
        Next

        AvgStat = SafeDivide(AvgStat, PersonCount)
        Return AvgStat
    End Function

    Public Sub UpdateGridSquare(ByVal SelectedView As Integer)

        Dim displayText As String = ""
        If IsOwned() Or SelectedView = ViewEnum.Coordinates Then
            If OwnerID >= 0 Then
                GridSquare.BackColor = Players(OwnerID).Flag
            End If
            GridSquare.Font = LargeFont
            Select Case (SelectedView)
                Case ViewEnum.Population
                    displayText = getPopulation().ToString
                Case ViewEnum.Minors
                    displayText = GetMinors().ToString
                Case ViewEnum.Elderly
                    displayText = GetElderly().ToString
                Case ViewEnum.Buildings
                    displayText = getDevelopment().ToString
                Case ViewEnum.Roads
                    displayText = Transportation.ToString
                Case ViewEnum.Coordinates
                    GridSquare.Font = RegularFont
                    displayText = (ColID + 1).ToString() + "," + (RowID + 1).ToString()
                Case ViewEnum.Terrain
                    GridSquare.Font = RegularFont
                    displayText = GetTerrainName(Terrain)
                Case ViewEnum.Order
                    displayText = OrderAcquired.ToString()

                Case ViewEnum.Average_Age
                    displayText = AgeView(False).ToString()
                Case ViewEnum.Oldest_Person
                    displayText = AgeView(True).ToString()
                Case ViewEnum.Average_Lifespan
                    displayText = GetAverageLifespan().ToString()

                Case ViewEnum.Average_Happiness
                    displayText = ComputeAverage(StatEnum.Happiness, False).ToString()
                Case ViewEnum.Average_Health
                    displayText = ComputeAverage(StatEnum.Health, False).ToString()
                Case ViewEnum.Average_Employment
                    displayText = ComputeAverage(StatEnum.Employment, False).ToString()
                Case ViewEnum.Average_Intelligence
                    displayText = ComputeAverage(StatEnum.Intelligence, False).ToString()
                Case ViewEnum.Average_Creativity
                    displayText = ComputeAverage(StatEnum.Creativity, False).ToString()
                Case ViewEnum.Average_Mobility
                    displayText = ComputeAverage(StatEnum.Mobility, False).ToString()
                Case ViewEnum.Average_Drunkenness
                    displayText = ComputeAverage(StatEnum.Drunkenness, False).ToString()
                Case ViewEnum.Average_Criminality
                    displayText = ComputeAverage(StatEnum.Criminality, False).ToString()
                Case ViewEnum.Average_Adult_Happiness
                    displayText = ComputeAverage(StatEnum.Happiness, True).ToString()
                Case ViewEnum.Average_Adult_Health
                    displayText = ComputeAverage(StatEnum.Health, True).ToString()
                Case ViewEnum.Average_Adult_Employment
                    displayText = ComputeAverage(StatEnum.Employment, True).ToString()
                Case ViewEnum.Average_Adult_Intelligence
                    displayText = ComputeAverage(StatEnum.Intelligence, True).ToString()
                Case ViewEnum.Average_Adult_Creativity
                    displayText = ComputeAverage(StatEnum.Creativity, True).ToString()
                Case ViewEnum.Average_Adult_Mobility
                    displayText = ComputeAverage(StatEnum.Mobility, True).ToString()
                Case ViewEnum.Average_Adult_Drunkenness
                    displayText = ComputeAverage(StatEnum.Drunkenness, True).ToString()
                Case ViewEnum.Average_Adult_Criminality
                    displayText = ComputeAverage(StatEnum.Criminality, True).ToString()

                Case ViewEnum.Jobs_Filled
                    GridSquare.Font = RegularFont
                    displayText = getJobsFilled().ToString + "/" + getJobsTotal.ToString
                Case ViewEnum.Jobs_Unfilled
                    GridSquare.Font = RegularFont
                    displayText = getJobsEmpty().ToString + "/" + getJobsTotal.ToString
                Case ViewEnum.Jobs_Total
                    displayText = getJobsTotal().ToString
                Case ViewEnum.Jobs_Needed
                    displayText = (getUnemployment(True) - getJobsEmpty()).ToString
                Case ViewEnum.Employed
                    displayText = getEmployment().ToString
                Case ViewEnum.Self_Employed
                    displayText = getEmployment(True).ToString
                Case ViewEnum.Unemployed_Total
                    displayText = getUnemployment(False).ToString
                Case ViewEnum.Unemployed_Adults
                    displayText = getUnemployment(True).ToString

                Case ViewEnum.Revenue_This_Turn
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(SelectedView).ToString
                Case ViewEnum.Total_Revenue
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(SelectedView).ToString
                Case ViewEnum.Upkeep_This_Turn
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(SelectedView).ToString
                Case ViewEnum.Total_Upkeep
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(SelectedView).ToString

                Case ViewEnum.Parking_Tickets
                    displayText = GetCrimes(CrimeEnum.Parking_Tickets).ToString
                Case ViewEnum.Traffic_Tickets
                    displayText = GetCrimes(CrimeEnum.Traffic_Tickets).ToString
                Case ViewEnum.Robberies
                    displayText = GetCrimes(CrimeEnum.Robbery).ToString
                Case ViewEnum.Vandalisms
                    displayText = GetCrimes(CrimeEnum.Vandalism).ToString
                Case ViewEnum.Arsons
                    displayText = GetCrimes(CrimeEnum.Arson).ToString
                Case ViewEnum.Murders
                    displayText = GetCrimes(CrimeEnum.Murder).ToString

                Case ViewEnum.Deaths_by_Natural_Causes
                    displayText = DeathCauseCounts(DeathEnum.NaturalCauses).ToString
                Case ViewEnum.Deaths_by_Illness
                    displayText = DeathCauseCounts(DeathEnum.Illness).ToString
                Case ViewEnum.Deaths_by_Traffic_Accident
                    displayText = DeathCauseCounts(DeathEnum.TrafficAccident).ToString
                Case ViewEnum.Deaths_by_Murder
                    displayText = DeathCauseCounts(DeathEnum.Murder).ToString
                Case ViewEnum.Deaths_by_Resisting_Arrest
                    displayText = DeathCauseCounts(DeathEnum.ResistingArrest).ToString

                Case ViewEnum.Buildings_owned_by_current_player
                    displayText = BuildingsOwnedByPlayer(-1).ToString
                Case ViewEnum.Buildings_owned_by_other_players
                    displayText = BuildingsOwnedByPlayer(-2).ToString
                Case ViewEnum.Buildings_owned_by_Player_1
                    displayText = BuildingsOwnedByPlayer(1).ToString
                Case ViewEnum.Buildings_owned_by_Player_2
                    displayText = BuildingsOwnedByPlayer(2).ToString
                Case ViewEnum.Buildings_owned_by_Player_3
                    displayText = BuildingsOwnedByPlayer(3).ToString
                Case ViewEnum.Buildings_owned_by_Player_4
                    displayText = BuildingsOwnedByPlayer(4).ToString

                Case ViewEnum.Buildings_Created
                    displayText = BuildingHistory.ToString
                Case ViewEnum.Buildings_Founded_by_Citizens
                    displayText = FoundedHistory.ToString
                Case ViewEnum.Buildings_Closed
                    displayText = ClosedHistory.ToString

                Case ViewEnum.Athletic_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Athletic).ToString
                Case ViewEnum.Coffee_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Coffee).ToString
                Case ViewEnum.Commerce_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Commerce).ToString
                Case ViewEnum.Criminal_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Criminal).ToString
                Case ViewEnum.Food_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Food).ToString
                Case ViewEnum.Franchise_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Franchise).ToString
                Case ViewEnum.Government_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Government).ToString
                Case ViewEnum.Manufacturing_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Manufacturing).ToString
                Case ViewEnum.Medical_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Medical).ToString
                Case ViewEnum.Monument_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Monument).ToString
                Case ViewEnum.Nature_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Nature).ToString
                Case ViewEnum.Science_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Science).ToString
                Case ViewEnum.Security_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Security).ToString
                Case ViewEnum.Transport_Buildings
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Transportation).ToString
            End Select
        End If

        GridSquare.Text = displayText
    End Sub
#End Region

    Public Function GetLocationText() As String
        Return "(" + (RowID + 1).ToString + "," + (ColID + 1).ToString + ")"
    End Function

    Public Overrides Function toString() As String
        Dim CityString As String = ""
        Dim TerrainString As String = ""
        Dim theOwner As Integer = OwnerID + 1
        If String.Compare(CityName, "") <> 0 Then
            CityString += "Name: " + CityName + ControlChars.NewLine
        End If
        CityString += "Location: " + GetLocationText() + ControlChars.NewLine
        CityString += "Terrain: "

        CityString += GetTerrainName(Terrain)
        Select Case (Terrain)
            Case TerrainEnum.Plain
                TerrainString = ControlChars.NewLine + "Plains are the default land type. They have no special effects."
            Case TerrainEnum.Dirt
                TerrainString = ControlChars.NewLine + "Dirt makes for a mind-numbingly boring place to live, but it's low upkeep and you start with free roads."
            Case TerrainEnum.Forest
                TerrainString = ControlChars.NewLine + "The natural beauty and fresh air of forests improve the health and happiness of local citizens."
            Case TerrainEnum.Mountain
                TerrainString = ControlChars.NewLine + "Mountains make travel difficult but provide inspiring views. The ready access to construction material mean a free random building."
            Case TerrainEnum.Lake
                TerrainString = ControlChars.NewLine + "Swimming and sailing are fun, but lakes can't be built on. Adjacent coastal regions get a boost to happiness."
            Case TerrainEnum.Swamp
                TerrainString = ControlChars.NewLine + "Swamps are free to buy, but a bit expensive to maintain. The foul-smelling, mosquito-ridden bogs aren't great for your health."
            Case TerrainEnum.Desert
                TerrainString = ControlChars.NewLine + "You can drive as fast as you want in the empty, wind-swept desert. And you get a 50% rebate on the land, but it's hard to convince anyone to move in."
            Case TerrainEnum.Township
                TerrainString = ControlChars.NewLine + "Townships provide free population when you incorporate them, but they also take a cut of the taxes in that location."
        End Select
        If Coastal Then
            CityString += ", Coastal"
        End If
        CityString += ControlChars.NewLine

        If theOwner = 0 Then
            CityString += TerrainString + ControlChars.NewLine + ControlChars.NewLine
            CityString += "Owner: None" + ControlChars.NewLine
        Else
            CityString += "Owner: Player " + theOwner.ToString + ControlChars.NewLine
            CityString += "Population: " + getPopulation().ToString + ControlChars.NewLine
            CityString += "Buildings: " + getDevelopment().ToString + ControlChars.NewLine
            CityString += "Jobs: " + getJobsFilled().ToString + "/" + getJobsTotal().ToString + ControlChars.NewLine
            CityString += "Transportation: "
            Select Case (Transportation)
                Case RoadEnum.None
                    CityString += "None" + ControlChars.NewLine
                Case RoadEnum.Dirt
                    CityString += "Dirt" + ControlChars.NewLine
                Case RoadEnum.Gravel
                    CityString += "Gravel" + ControlChars.NewLine
                Case RoadEnum.Paved
                    CityString += "Paved" + ControlChars.NewLine
                Case RoadEnum.Highway
                    CityString += "Highway" + ControlChars.NewLine
            End Select
            '--Building details
            CityString += ControlChars.NewLine + "Development:" + ControlChars.NewLine
            Dim i As Integer
            For i = 0 To Buildings.Count - 1
                Dim thisBuilding As Building = Buildings(i)
                CityString += thisBuilding.GetName() + ": " + thisBuilding.GetEmployeeCount().ToString() + "/" + thisBuilding.Jobs.ToString() + "   Success: " + thisBuilding.BusinessSuccess.ToString() + ControlChars.NewLine
            Next
        End If

        Return CityString
    End Function

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

        'where the Sorting logic is run

        'Basically says: "if ME greater than the obj card then return 1, if equal return 0 and if less than, return -1"

        If Not TypeOf obj Is CitySquare Then Throw New ArgumentException 'make sure obj is a card before continuing

        Dim city1, city2 As Integer
        Dim temp As CitySquare = CType(obj, CitySquare)

        If SortType = CitySortEnum.VisitOrder Then
            '-- Sort the locations in the order visited
            city1 = getVisitOrder()
            city2 = temp.getVisitOrder()
        ElseIf SortType = CitySortEnum.Population Then
            '-- Always head for least populated area (choose randomly if tied)
            city1 = getPopulation()
            city2 = temp.getPopulation()
        ElseIf SortType = CitySortEnum.Culture Then
            '-- Head for most developed region (choose randomly if tied)
            city1 = -getCulture()
            city2 = -temp.getCulture()
        Else
            '--Head for area with most free jobs if unemployed (choose randomly if tied)
            city1 = -getJobsEmpty()
            city2 = -temp.getJobsEmpty()
        End If

        If city1 < city2 Then
            Return -1
        ElseIf city1 > city2 Then
            Return 1
        Else
            Return 0
        End If
    End Function

#End Region

#Region " Adjacency "

    Function Valid() As Boolean
        If RowID >= 0 And ColID >= 0 And RowID <= GridWidth And ColID <= GridHeight Then
            Return True
        Else
            Return False
        End If
    End Function

    Function GetTrueAdjacents() As List(Of CitySquare)
        Dim AdjacentList As New List(Of CitySquare)

        If RowID - 1 >= 0 Then
            AdjacentList.Add(GridArray(RowID - 1, ColID))
        End If
        If RowID + 1 <= GridWidth Then
            AdjacentList.Add(GridArray(RowID + 1, ColID))
        End If
        If ColID - 1 >= 0 Then
            AdjacentList.Add(GridArray(RowID, ColID - 1))
        End If
        If ColID + 1 <= GridHeight Then
            AdjacentList.Add(GridArray(RowID, ColID + 1))
        End If

        Return AdjacentList

    End Function

    Sub AddToAdjList(ByRef AdjacentList As List(Of CitySquare), ByRef TransportBuilding As Building)

        Dim NewDestinations As List(Of CitySquare) = TransportBuilding.GetAdjacentLocations()

        For i As Integer = 0 To NewDestinations.Count - 1
            Dim NewDestination As CitySquare = NewDestinations(i)
            '-- Add this new destination to the adjacency list if it wasn't already there
            If Not AdjacentList.Contains(NewDestination) Then

                '-- Set the building that was used to reach this destination
                NewDestination.VisitMethodAttempt = TransportBuilding

                AdjacentList.Add(NewDestination)
            End If
        Next
    End Sub

    Function GetAdjacents() As List(Of CitySquare)
        Dim AdjacentList As New List(Of CitySquare)

        '-- Get all the literally adjacent citysquares
        Dim CarAdjacentList As List(Of CitySquare) = GetTrueAdjacents()
        AdjacentList.AddRange(CarAdjacentList)

        '-- Get destinations that are "adjacent" by virtue of a building connecting them
        For i As Integer = 0 To Buildings.Count - 1
            Dim CurrentBuilding As Building = Buildings(i)

            If CurrentBuilding.Type = BuildingGen.BuildingEnum.Taxi_Service Or
                CurrentBuilding.Type = BuildingGen.BuildingEnum.Harbor Or
                CurrentBuilding.Type = BuildingGen.BuildingEnum.Mass_Transit Or
                CurrentBuilding.Type = BuildingGen.BuildingEnum.Airport Or
                CurrentBuilding.Type = BuildingGen.BuildingEnum.Exurb Then

                AddToAdjList(AdjacentList, CurrentBuilding)
            End If
        Next

        Return AdjacentList

    End Function

    Sub GetLocationsInRange(ByVal Range As Integer, ByRef visitList As List(Of CitySquare))
        visitList.Add(Me)

        If Range > 0 Then
            '-- Continue moving to locations adjacent to this location
            Dim adjacentList As List(Of CitySquare) = GetTrueAdjacents()
            For i As Integer = 0 To adjacentList.Count - 1
                If Not visitList.Contains(adjacentList(i)) Then
                    adjacentList(i).GetLocationsInRange(Range - 1, visitList)
                End If
            Next
        End If
    End Sub
#End Region

#Region " Visitation "

    Public Function getVisitOrder() As Integer
        Return VisitOrder
    End Function

    Public Function GetVisitMethod() As String
        Dim visitString As String = "Visited " + GetName() + " by "

        If VisitMethod Is Nothing Then
            visitString += "car"
        Else
            Select Case VisitMethod.Type
                Case BuildingGen.BuildingEnum.Harbor
                    visitString += "boat"
                Case BuildingGen.BuildingEnum.Mass_Transit
                    visitString += "bus"
                Case BuildingGen.BuildingEnum.Airport
                    visitString += "plane"
                Case BuildingGen.BuildingEnum.Taxi_Service
                    visitString += "taxi"
                Case BuildingGen.BuildingEnum.Exurb
                    visitString += "commuter train"
            End Select
        End If
        Return visitString
    End Function

    Public Sub SetVisitMethod(ByRef transportMethod As Building)
        VisitMethod = transportMethod
        VisitMethodAttempt = transportMethod
    End Sub

    Public Sub SetVisitMethodAttempt(ByRef transportMethod As Building)
        VisitMethodAttempt = transportMethod
    End Sub

    Sub VisitHere(ByRef Visitor As Citizen)
        Visitor.AddEvent(GetVisitMethod())
        If VisitMethod IsNot Nothing Then
            VisitMethod.AddEffects(1)
        End If
        SetVisitMethod(Nothing)
    End Sub

    Sub ClearVisit()
        VisitedKey = 0
        DragLoss = -1
        VisitOrder = 0
        VisitMethod = Nothing
        VisitMethodAttempt = Nothing
    End Sub
#End Region

End Class

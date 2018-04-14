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
    Public Terrain As Integer = TerrainPlain
    Public Coastal As Boolean = False

    '-- Residents
    Public People As New List(Of Citizen)

    '-- Roads
    Public Transportation As Integer = RoadNone

    '-- Buildings
    Public Buildings As New List(Of Building)
    Public NeighborBuildings As New List(Of Building)

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
            Terrain = TerrainForest
        ElseIf tempNum <= 20 Then
            Terrain = TerrainMountain
        ElseIf tempNum <= 27 Then
            Terrain = TerrainDirt
        ElseIf tempNum <= 32 Then
            Terrain = TerrainDesert
        ElseIf tempNum <= 38 Then
            Terrain = TerrainSwamp
        ElseIf tempNum <= 44 Then
            Terrain = TerrainTownship
        ElseIf tempNum <= 52 Then
            Terrain = TerrainLake
        Else
            Terrain = TerrainPlain
        End If

        '-- Create the GUI label/button that represents this citySquare
        GridSquare = New LabelWithTextBorder
        UpdateTerrain()
        'Select Case (Terrain)
        '    Case TerrainPlain
        '        GridSquare.BackColor = ColorPlain
        '    Case TerrainDirt
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorDirt
        '    Case TerrainForest
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorForest
        '    Case TerrainMountain
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorMountain
        '    Case TerrainLake
        '        GridSquare.BackColor = ColorOcean
        '    Case TerrainSwamp
        '        GridSquare.BackColor = ColorSwamp
        '    Case TerrainTownship
        '        GridSquare.BackColor = ColorPlain
        '        'GridSquare.BackColor = ColorTownship
        '    Case TerrainDesert
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

    Public Sub Occupy(ByVal PlayerID As Integer)
        OwnerID = PlayerID
        '-- Generate random city name
        CityName = Namer.GenerateCityName(Me)

        OrderAcquired = Players(PlayerID).GetPlayerTerritoryCount()
    End Sub

    Public Sub SetTerrain(ByVal TerrainType As Integer)
        Terrain = TerrainType
        UpdateTerrain()
    End Sub

    Public Sub UpdateTerrain()
        GridSquare.BackColor = ColorPlain

        Dim randImageIndex As Integer = GetRandom(1, 2)

        Select Case Terrain
            Case TerrainPlain
                If GetRandom(1, 20) = 1 Then
                    GridSquare.Image = My.Resources.ResourceManager.GetObject("Flowers1")
                Else
                    GridSquare.Image = Nothing
                End If
            Case TerrainForest
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Forest" + GetRandom(1, 3).ToString)
            Case TerrainMountain
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Mountain" + GetRandom(1, 3).ToString)
            Case TerrainLake
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Lake1")
            Case TerrainTownship
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Township" + GetRandom(1, 3).ToString)
            Case TerrainDesert
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Desert1")
            Case TerrainDirt
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Dirt" + GetRandom(1, 3).ToString)
            Case TerrainSwamp
                GridSquare.Image = My.Resources.ResourceManager.GetObject("Swamp" + GetRandom(1, 2).ToString)
        End Select

        '-- Old graphics: Just color, no image
        'Select Case (Terrain)
        '    Case TerrainPlain
        '        GridSquare.BackColor = ColorPlain
        '    Case TerrainDirt
        '        GridSquare.BackColor = ColorDirt
        '    Case TerrainForest
        '        GridSquare.BackColor = ColorForest
        '    Case TerrainMountain
        '        GridSquare.BackColor = ColorMountain
        '    Case TerrainLake
        '        GridSquare.BackColor = ColorOcean
        '    Case TerrainSwamp
        '        GridSquare.BackColor = ColorSwamp
        '    Case TerrainTownship
        '        GridSquare.BackColor = ColorTownship
        '    Case TerrainDesert
        '        GridSquare.BackColor = ColorDesert
        'End Select
    End Sub

#End Region

#Region " Accessors "
    Public Function getPopulation() As Integer
        Return People.Count
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

    Public Function getEmployment() As Integer
        '-- We have to actually check every citizen since they might have jobs elsewhere
        Dim citizensEmployed As Integer = 0
        For i As Integer = 0 To People.Count - 1
            '-- Add up how many citizens employed
            Dim currentCitizen As Citizen = People(i)
            If currentCitizen.JobBuilding IsNot Nothing Then
                citizensEmployed += 1
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

    Public Sub AddBuilding(ByVal NewBuilding As Building, ByVal PlayerIndex As Integer)
        NewBuilding.Location = Me
        NewBuilding.OwnerID = PlayerIndex
        Buildings.Add(NewBuilding)
        NewBuilding.ConstructionEffects()
    End Sub

    Public Sub AddRoad()
        Transportation = Transportation + 1
        If Transportation > RoadHighway Then
            Transportation = RoadHighway
        End If
    End Sub

    Public Sub AddPerson(ByVal newPerson As Citizen)
        '-- Use for immigration
        newPerson.Residence = Me
        People.Add(newPerson)
    End Sub

    Function GetDistance(ByRef OtherSquare As CitySquare) As Integer
        Return Math.Abs(RowID - OtherSquare.RowID) + Math.Abs(ColID - OtherSquare.ColID)
    End Function

    Sub UpdateCoastline()

        '-- Lakes can't be coastal
        If Terrain = TerrainLake Then
            Coastal = False
            Return
        End If

        '-- Any other terrain next to a lake is coastal
        Dim adjacentList As List(Of CitySquare) = GetTrueAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            Dim neighborLocation As CitySquare = adjacentList(i)
            If neighborLocation.Terrain = TerrainLake Then
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
                Case ViewEnum.CurrentRevenue
                    Sum += CurrentBuilding.CurrentRevenue
                Case ViewEnum.TotalRevenue
                    Sum += CurrentBuilding.TotalRevenue
                Case ViewEnum.CurrentUpkeep
                    Sum += CurrentBuilding.CurrentUpkeep
                Case ViewEnum.TotalUpkeep
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

    Public Sub UpdateGridSquare(ByVal CurrentView As Integer)

        Dim displayText As String = ""
        If IsOwned() Or CurrentView = ViewEnum.Coordinates Then
            If OwnerID >= 0 Then
                GridSquare.BackColor = Players(OwnerID).Flag
            End If
            GridSquare.Font = LargeFont
            Select Case (CurrentView)
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
                Case ViewEnum.AgeAvg
                    displayText = AgeView(False).ToString()
                Case ViewEnum.MaxAge
                    displayText = AgeView(True).ToString()
                Case ViewEnum.LifespanAvg
                    displayText = GetAverageLifespan().ToString()
                Case ViewEnum.HappinessAvg
                    displayText = ComputeAverage(StatEnum.Happiness, False).ToString()
                Case ViewEnum.HealthAvg
                    displayText = ComputeAverage(StatEnum.Health, False).ToString()
                Case ViewEnum.EmploymentAvg
                    displayText = ComputeAverage(StatEnum.Employment, False).ToString()
                Case ViewEnum.IntelligenceAvg
                    displayText = ComputeAverage(StatEnum.Intelligence, False).ToString()
                Case ViewEnum.CreativityAvg
                    displayText = ComputeAverage(StatEnum.Creativity, False).ToString()
                Case ViewEnum.MobilityAvg
                    displayText = ComputeAverage(StatEnum.Mobility, False).ToString()
                Case ViewEnum.DrunkennessAvg
                    displayText = ComputeAverage(StatEnum.Drunkenness, False).ToString()
                Case ViewEnum.CriminalityAvg
                    displayText = ComputeAverage(StatEnum.Criminality, False).ToString()
                Case ViewEnum.HappinessAvgAdults
                    displayText = ComputeAverage(StatEnum.Happiness, True).ToString()
                Case ViewEnum.HealthAvgAdults
                    displayText = ComputeAverage(StatEnum.Health, True).ToString()
                Case ViewEnum.EmploymentAvgAdults
                    displayText = ComputeAverage(StatEnum.Employment, True).ToString()
                Case ViewEnum.IntelligenceAvgAdults
                    displayText = ComputeAverage(StatEnum.Intelligence, True).ToString()
                Case ViewEnum.CreativityAvgAdults
                    displayText = ComputeAverage(StatEnum.Creativity, True).ToString()
                Case ViewEnum.MobilityAvgAdults
                    displayText = ComputeAverage(StatEnum.Mobility, True).ToString()
                Case ViewEnum.DrunkennessAvgAdults
                    displayText = ComputeAverage(StatEnum.Drunkenness, True).ToString()
                Case ViewEnum.CriminalityAvgAdults
                    displayText = ComputeAverage(StatEnum.Criminality, True).ToString()
                Case ViewEnum.JobsFilled
                    GridSquare.Font = RegularFont
                    displayText = getJobsFilled().ToString + "/" + getJobsTotal.ToString
                Case ViewEnum.JobsUnfilled
                    GridSquare.Font = RegularFont
                    displayText = getJobsEmpty().ToString + "/" + getJobsTotal.ToString
                Case ViewEnum.JobsTotal
                    displayText = getJobsTotal().ToString
                Case ViewEnum.JobsNeed
                    displayText = (getUnemployment(True) - getJobsEmpty()).ToString
                Case ViewEnum.Employees
                    displayText = getEmployment().ToString
                Case ViewEnum.UnemployedTotal
                    displayText = getUnemployment(False).ToString
                Case ViewEnum.UnemployedAdults
                    displayText = getUnemployment(True).ToString
                Case ViewEnum.CurrentRevenue
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(CurrentView).ToString
                Case ViewEnum.TotalRevenue
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(CurrentView).ToString
                Case ViewEnum.CurrentUpkeep
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(CurrentView).ToString
                Case ViewEnum.TotalUpkeep
                    GridSquare.Font = RegularFont
                    displayText = SumBuildingView(CurrentView).ToString
                Case ViewEnum.CrimeParkingTicket
                    displayText = GetCrimes(CrimeEnum.ParkingTicket).ToString
                Case ViewEnum.CrimeTrafficTicket
                    displayText = GetCrimes(CrimeEnum.TrafficTicket).ToString
                Case ViewEnum.CrimeRobbery
                    displayText = GetCrimes(CrimeEnum.Robbery).ToString
                Case ViewEnum.CrimeVandalism
                    displayText = GetCrimes(CrimeEnum.Vandalism).ToString
                Case ViewEnum.CrimeArson
                    displayText = GetCrimes(CrimeEnum.Arson).ToString
                Case ViewEnum.CrimeMurder
                    displayText = GetCrimes(CrimeEnum.Murder).ToString
                Case ViewEnum.DeathNaturalCauses
                    displayText = DeathCauseCounts(DeathEnum.NaturalCauses).ToString
                Case ViewEnum.DeathIllness
                    displayText = DeathCauseCounts(DeathEnum.Illness).ToString
                Case ViewEnum.DeathTrafficAccident
                    displayText = DeathCauseCounts(DeathEnum.TrafficAccident).ToString
                Case ViewEnum.DeathMurder
                    displayText = DeathCauseCounts(DeathEnum.Murder).ToString
                Case ViewEnum.DeathResistingArrest
                    displayText = DeathCauseCounts(DeathEnum.ResistingArrest).ToString
                Case ViewEnum.Ad
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Ad).ToString
                Case ViewEnum.Athletic
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Athletic).ToString
                Case ViewEnum.Coffee
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Coffee).ToString
                Case ViewEnum.Commerce
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Commerce).ToString
                Case ViewEnum.Criminal
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Criminal).ToString
                Case ViewEnum.Food
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Food).ToString
                Case ViewEnum.Franchise
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Franchise).ToString
                Case ViewEnum.Government
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Government).ToString
                Case ViewEnum.Manufacturing
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Manufacturing).ToString
                Case ViewEnum.Medical
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Medical).ToString
                Case ViewEnum.Monument
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Monument).ToString
                Case ViewEnum.Nature
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Nature).ToString
                Case ViewEnum.Science
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Science).ToString
                Case ViewEnum.Security
                    displayText = CountBuildingsByTag(BuildingGen.TagEnum.Security).ToString
                Case ViewEnum.Transport
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
            Case TerrainPlain
                TerrainString = ControlChars.NewLine + "Plains are the default land type. They have no special effects."
            Case TerrainDirt
                TerrainString = ControlChars.NewLine + "Dirt makes for a mind-numbingly boring place to live, but it's low upkeep and you start with free roads."
            Case TerrainForest
                TerrainString = ControlChars.NewLine + "The natural beauty and fresh air of forests improve the health and happiness of local citizens."
            Case TerrainMountain
                TerrainString = ControlChars.NewLine + "Mountains make travel difficult but provide inspiring views. The ready access to construction material mean a free random building."
            Case TerrainLake
                TerrainString = ControlChars.NewLine + "Swimming and sailing are fun, but lakes can't be built on. Adjacent coastal regions get a boost to happiness."
            Case TerrainSwamp
                TerrainString = ControlChars.NewLine + "Swamps are free to buy, but a bit expensive to maintain. The foul-smelling, mosquito-ridden bogs aren't great for your health."
            Case TerrainDesert
                TerrainString = ControlChars.NewLine + "You can drive as fast as you want in the empty, wind-swept desert. And you get a 50% rebate on the land, but it's hard to convince anyone to move in."
            Case TerrainTownship
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
                Case RoadNone
                    CityString += "None" + ControlChars.NewLine
                Case RoadDirt
                    CityString += "Dirt" + ControlChars.NewLine
                Case RoadGravel
                    CityString += "Gravel" + ControlChars.NewLine
                Case RoadPaved
                    CityString += "Paved" + ControlChars.NewLine
                Case RoadHighway
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

        If SortType = VisitOrderSort Then
            '-- Sort the locations in the order visited
            city1 = getVisitOrder()
            city2 = temp.getVisitOrder()
        ElseIf SortType = PopSort Then
            '-- Always head for least populated area (choose randomly if tied)
            city1 = getPopulation()
            city2 = temp.getPopulation()
        ElseIf SortType = CultureSort Then
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
                CurrentBuilding.Type = BuildingGen.BuildingEnum.Airport Then

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
                    visitString += "train"
                Case BuildingGen.BuildingEnum.Airport
                    visitString += "plane"
                Case BuildingGen.BuildingEnum.Taxi_Service
                    visitString += "taxi"
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

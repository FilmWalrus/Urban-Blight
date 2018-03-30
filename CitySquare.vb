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
    Public VisitMethodAttempt As Integer = TransportType.Bike
    Public VisitMethod As Integer = TransportType.Bike
    Public VisitOrder As Integer = 0

    '--
    Public GridSquare As Label = Nothing

    '-- Info
    Public Buildings As New List(Of Building)
    Public People As New List(Of Person)
    Public Transportation As Integer = 0
    Public Terrain As Integer = TerrainPlain
    Public Coastal As Boolean = False

    '-- Averages
    Public AvgHappiness As Integer = 0
    Public AvgHealth As Integer = 0
    Public AvgEmployment As Integer = 0
    Public AvgIntelligence As Integer = 0
    Public AvgCreativity As Integer = 0
    Public AvgMobility As Integer = 0
    Public AvgDrunkenness As Integer = 0
    Public AvgCriminality As Integer = 0

    Public Enum TransportType
        Bike
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
        GridSquare = New Label

        Select Case (Terrain)
            Case TerrainPlain
                GridSquare.BackColor = ColorPlain
            Case TerrainDirt
                GridSquare.BackColor = ColorDirt
            Case TerrainForest
                GridSquare.BackColor = ColorForest
            Case TerrainMountain
                GridSquare.BackColor = ColorMountain
            Case TerrainLake
                GridSquare.BackColor = ColorOcean
            Case TerrainSwamp
                GridSquare.BackColor = ColorSwamp
            Case TerrainTownship
                GridSquare.BackColor = ColorTownship
            Case TerrainDesert
                GridSquare.BackColor = ColorDesert
        End Select

        GridSquare.Name = "NewBox"
        GridSquare.Tag = row & "," & col
        GridSquare.TabStop = False
        GridSquare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        GridSquare.Text = "0"
        GridSquare.BorderStyle = BorderStyle.FixedSingle
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

    Public Function getUnemployment() As Integer
        '-- We have to actually check every citizen since they might have jobs elsewhere
        Dim citizensUnemployed As Integer = 0
        For i As Integer = 0 To People.Count - 1
            '-- Add up how many citizens unemployed
            Dim currentCitizen As Person = People(i)
            If currentCitizen.JobBuilding Is Nothing Then
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
            Dim currentCitizen As Person = People(i)
            If currentCitizen.JobBuilding Is Nothing Then
                If currentCitizen.IsMinor() Then
                    '-- Count minors as a fraction of an adult based on how close they are to working age
                    unemploymentValue += (currentCitizen.Age / Person.MinorAge)
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
            Dim currentCitizen As Person = People(i)
            If currentCitizen.JobBuilding IsNot Nothing Then
                citizensEmployed += 1
            End If
        Next
        Return citizensEmployed
    End Function

    Public Function getVisitOrder() As Integer
        Return VisitOrder
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

    Public Function GetVisitMethod() As String
        Dim visitString As String = "Visited " + GetName() + " by "
        Select Case VisitMethod
            Case TransportType.Bike
                visitString += "bike"
            Case TransportType.Car
                visitString += "car"
            Case TransportType.Train
                visitString += "mass transit"
            Case TransportType.Plane
                visitString += "plane"
            Case TransportType.Taxi
                visitString += "taxi"
        End Select
        Return visitString
    End Function

    Public Sub SetVisitMethod(ByVal transportMethod As Integer)
        VisitMethod = transportMethod
        VisitMethodAttempt = transportMethod
    End Sub

    Public Sub SetVisitMethodAttempt(ByVal transportMethod As Integer)
        VisitMethodAttempt = transportMethod
    End Sub

    Public Sub AddBuilding(ByVal NewBuilding As Building)
        NewBuilding.Location = Me
        Buildings.Add(NewBuilding)
        NewBuilding.ConstructionEffects()
    End Sub

    Public Sub AddRoad()
        Transportation = Transportation + 1
        If Transportation > RoadHighway Then
            Transportation = RoadHighway
        End If
    End Sub

    Public Sub AddPerson(ByVal newPerson As Person)
        '-- Use for immigration
        newPerson.Residence = Me
        People.Add(newPerson)
    End Sub

    Function WillExpand() As Boolean

    End Function

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

    Function GetAdjacents() As List(Of CitySquare)
        Dim AdjacentList As New List(Of CitySquare)

        '-- Get all the literally adjacent citysquares
        Dim CarAdjacentList As List(Of CitySquare) = GetTrueAdjacents()
        CarAdjacentList.ForEach(Sub(s) s.SetVisitMethodAttempt(TransportType.Car))
        AdjacentList.AddRange(CarAdjacentList)

        '-- Now get any citysquares that are connect by mass transit
        Dim MassTransitList As List(Of Building) = GetBuildingsByType(BuildingGen.BuildingEnum.Airport)
        For i As Integer = 0 To MassTransitList.Count - 1
            Dim TrainAdjacentList As List(Of CitySquare) = MassTransitList(0).GetAdjacentLocations()
            TrainAdjacentList.ForEach(Sub(s) s.SetVisitMethodAttempt(TransportType.Train))
            AdjacentList.AddRange(TrainAdjacentList)
        Next

        '-- Now get any citysquares that are connect by buildings like airports
        Dim AirportList As List(Of Building) = GetBuildingsByType(BuildingGen.BuildingEnum.Airport)
        If AirportList.Count > 0 Then
            Dim PlaneAdjacentList As List(Of CitySquare) = AirportList(0).GetAdjacentLocations()
            PlaneAdjacentList.ForEach(Sub(s) s.SetVisitMethodAttempt(TransportType.Plane))
            AdjacentList.AddRange(PlaneAdjacentList)
        End If

        Return AdjacentList

    End Function

    Sub GetLocationsInRange(ByVal Range As Integer, ByRef visitList As List(Of CitySquare))
        visitList.Add(Me)

        If Range > 0 Then
            '-- Continue moving to locations adjacent to this location
            Dim adjacentList As List(Of CitySquare) = GetAdjacents()
            For i As Integer = 0 To adjacentList.Count - 1
                If Not visitList.Contains(adjacentList(i)) Then
                    adjacentList(i).GetLocationsInRange(Range - 1, visitList)
                End If
            Next
        End If
    End Sub

    Function GetDistance(ByRef OtherSquare As CitySquare) As Integer
        Return Math.Abs(RowID - OtherSquare.RowID) + Math.Abs(ColID - OtherSquare.ColID)
    End Function

    Sub ClearVisit()
        VisitedKey = 0
        DragLoss = -1
        VisitOrder = 0
        VisitMethod = CitySquare.TransportType.Bike
        VisitMethodAttempt = CitySquare.TransportType.Bike
    End Sub

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

    Public Sub ComputeAverages()

        Dim currentPop As Integer = getPopulation()
        AvgHappiness = 0
        AvgHealth = 0
        AvgEmployment = 0
        AvgIntelligence = 0
        AvgCreativity = 0
        AvgMobility = 0
        AvgDrunkenness = 0
        AvgCriminality = 0

        Dim i As Integer
        For i = 0 To currentPop - 1
            People(i).Cap()
            AvgHappiness += People(i).Happiness
            AvgHealth += People(i).Health
            AvgEmployment += People(i).Employment
            AvgIntelligence += People(i).Intelligence
            AvgCreativity += People(i).Creativity
            AvgMobility += People(i).Mobility
            AvgDrunkenness += People(i).Drunkenness
            AvgCriminality += People(i).Criminality
        Next

        AvgHappiness = SafeDivide(AvgHappiness, currentPop)
        AvgHealth = SafeDivide(AvgHealth, currentPop)
        AvgEmployment = SafeDivide(AvgEmployment, currentPop)
        AvgIntelligence = SafeDivide(AvgIntelligence, currentPop)
        AvgCreativity = SafeDivide(AvgCreativity, currentPop)
        AvgMobility = SafeDivide(AvgMobility, currentPop)
        AvgDrunkenness = SafeDivide(AvgDrunkenness, currentPop)
        AvgCriminality = SafeDivide(AvgCriminality, currentPop)
    End Sub

    Public Sub UpdateGridSquare(ByVal CurrentView As Integer)

        Dim displayText As String = ""
        If OwnerID >= 0 Or CurrentView = LocView Then
            If OwnerID >= 0 Then
                GridSquare.BackColor = Players(OwnerID).Flag
            End If
            GridSquare.Font = LargeFont
            Select Case (CurrentView)
                Case PopView
                    displayText = getPopulation().ToString
                Case LocView
                    GridSquare.Font = RegularFont
                    displayText = (ColID + 1).ToString() + "," + (RowID + 1).ToString()
                Case HappinessView
                    displayText = AvgHappiness.ToString()
                Case HealthView
                    displayText = AvgHealth.ToString()
                Case EmploymentView
                    displayText = AvgEmployment.ToString()
                Case IntelligenceView
                    displayText = AvgIntelligence.ToString()
                Case CreativityView
                    displayText = AvgCreativity.ToString()
                Case MobilityView
                    displayText = AvgMobility.ToString()
                Case DrunkennessView
                    displayText = AvgDrunkenness.ToString()
                Case CriminalityView
                    displayText = AvgCriminality.ToString()
                Case JobView
                    GridSquare.Font = RegularFont
                    displayText = getJobsFilled().ToString + "/" + getJobsTotal.ToString
                Case RoadView
                    displayText = Transportation.ToString
            End Select
        Else
            'TheBoxes(i, j).Appearance.BackColor2 = Color.LightGray
            displayText = ""
        End If

        'If displayText.Length > 0 Then
        '    If displayText.Substring(0, 1) = "0" Then
        '        displayText = ""
        '    End If
        'End If

        GridSquare.Text = displayText
    End Sub

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
                CityString += thisBuilding.GetName() + ": " + thisBuilding.GetEmployeeCount().ToString() + "/" + thisBuilding.Jobs.ToString() + "   Success: " + thisBuilding.Success.ToString() + ControlChars.NewLine
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

End Class

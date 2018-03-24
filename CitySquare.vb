Public Class CitySquare
    Implements IComparable

#Region " Variables "
    Public RowID As Integer = 0
    Public ColID As Integer = 0
    Public OwnerID As Integer = -1
    Public CityName As String = ""
    Public VisitedKey As Integer = -1

    '--
    Public GridSquare As Label = Nothing

    '-- Info
    Public Buildings As New ArrayList
    Public People As New ArrayList
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
        GridSquare.TextAlign = ContentAlignment.MiddleCenter
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

    Public Sub AddBuilding(ByVal NewBuilding As Building)
        Buildings.Add(NewBuilding)
        NewBuilding.Location = Me
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

    Function GetAdjacents() As ArrayList
        Dim AdjacentList As New ArrayList()

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

    Sub UpdateCoastline()

        '-- Lakes can't be coastal
        If Terrain = TerrainLake Then
            Coastal = False
            Return
        End If

        '-- Any other terrain next to a lake is coastal
        Dim adjacentList As ArrayList = GetAdjacents()
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

        Dim tempPerson As Person
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
            If People(i).JobBuilding IsNot Nothing Then
                'Update success of job
                tempPerson = People(i)
                tempPerson.JobBuilding.Success += tempPerson.Employment
            End If
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
                CityString += Buildings(i).type.ToString() + ": " + Buildings(i).GetEmployeeCount().ToString() + "/" + Buildings(i).Jobs.ToString() + "   Success: " + Buildings(i).Success.ToString() + ControlChars.NewLine
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

        If SortType = PopSort Then
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

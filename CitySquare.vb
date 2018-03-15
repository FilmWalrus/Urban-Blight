Public Class CitySquare
    Implements IComparable

#Region " Variables "
    Public RowID As Integer = 0
    Public ColID As Integer = 0
    Public OwnerID As Integer = -1
    Public CityName As String = ""
    Public VisitedKey As Integer = -1

    '-- Info
    'Public Population As Integer = 0
    'Public Development As Integer = 0
    'Public JobsAvailable As Integer = 0
    'Public JobsFilled As Integer = 0
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

    '-- Not trustworthy
    Public TempJobsTotal As Integer = -1
    Public TempJobsFilled As Integer = -1
#End Region

#Region " New "
    Public Sub New()

    End Sub

    Public Sub New(ByVal row As Integer, ByVal col As Integer)
        RowID = row
        ColID = col
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
    End Sub

#End Region

#Region " Accessors "
    Public Function getPopulation() As Integer
        Return People.Count
    End Function
    Public Function getDevelopment() As Integer
        Return Buildings.Count
    End Function
    Public Function getJobsTotal() As Integer
        Dim jobTotal As Integer = 0
        Dim i As Integer
        For i = 0 To Buildings.Count - 1
            jobTotal = jobTotal + Buildings(i).jobs
        Next
        TempJobsTotal = jobTotal
        Return jobTotal
    End Function
    Public Function getJobsFilled() As Integer
        Dim jobFilled As Integer = 0
        Dim i As Integer
        For i = 0 To Buildings.Count - 1
            jobFilled = jobFilled + Buildings(i).filled
        Next
        TempJobsFilled = jobFilled
        Return jobFilled
    End Function
    Public Function getJobsEmpty() As Integer
        Dim JobsEmpty As Integer = 0
        Dim i As Integer
        For i = 0 To Buildings.Count - 1
            JobsEmpty = JobsEmpty + (Buildings(i).jobs - Buildings(i).filled)
        Next
        Return JobsEmpty
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
    End Sub

    Public Sub AddRoad()
        Transportation = Transportation + 1
        If Transportation > RoadHighway Then
            Transportation = RoadHighway
        End If
    End Sub

    Public Function MiracleBirth() As String
        Dim newPerson As New Person
        newPerson.Residence = Me
        People.Add(newPerson)
        Return newPerson.Name
    End Function

    Public Function Birth(ByVal theParent As Person) As String
        Dim newPerson As New Person(theParent)
        newPerson.Residence = Me
        People.Add(newPerson)
        Return newPerson.Name
    End Function

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
            AdjacentList.Add(BoxInfo(RowID - 1, ColID))
        End If
        If RowID + 1 <= GridWidth Then
            AdjacentList.Add(BoxInfo(RowID + 1, ColID))
        End If
        If ColID - 1 >= 0 Then
            AdjacentList.Add(BoxInfo(RowID, ColID - 1))
        End If
        If ColID + 1 <= GridHeight Then
            AdjacentList.Add(BoxInfo(RowID, ColID + 1))
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
            If People(i).Employment > 0 Then
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

    Public Overrides Function toString() As String
        Dim CityString As String = ""
        Dim TerrainString As String = ""
        Dim theOwner As Integer = OwnerID + 1
        If String.Compare(CityName, "") <> 0 Then
            CityString += "Name: " + CityName + ControlChars.NewLine
        End If
        CityString += "Location: (" + (ColID + 1).ToString + "," + (RowID + 1).ToString + ")" + ControlChars.NewLine
        CityString += "Terrain : "

        Select Case (Terrain)
            Case TerrainPlain
                CityString += "Plain"
                TerrainString = ControlChars.NewLine + "Plains are the default land type. They have no special effects."
            Case TerrainDirt
                CityString += "Dirt"
                TerrainString = ControlChars.NewLine + "Dirt makes for a boring place to live, but it's low upkeep and you start with free dirt roads."
            Case TerrainForest
                CityString += "Forest"
                TerrainString = ControlChars.NewLine + "The natural beauty and fresh air of forests increases the health and happiness of local citizens."
            Case TerrainMountain
                CityString += "Mountain"
                TerrainString = ControlChars.NewLine + "Mountains reduce mobility but provide inspiring views. The ready access to construction material means you'll get a random building for free."
            Case TerrainLake
                CityString += "Lake"
                TerrainString = ControlChars.NewLine + "Lakes can't be built on, but adjacent coastal regions get a boost to happiness."
            Case TerrainSwamp
                CityString += "Swamp"
                TerrainString = ControlChars.NewLine + "Swamps are free to buy, but a bit expensive to maintain. The foul-smelling, mosquito-ridden bogs aren't great for your health."
            Case TerrainDesert
                CityString += "Desert"
                TerrainString = ControlChars.NewLine + "You get a 50% rebate on empty, wind-swept deserts because, well... not many people want to live there."
            Case TerrainTownship
                CityString += "Township"
                TerrainString = ControlChars.NewLine + "Townships provide free population when you encorporate them, but they also take a cut of the taxes in that location."
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
            CityString += "Jobs: " + getJobsFilled.ToString + "/" + getJobsTotal().ToString + ControlChars.NewLine
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
                CityString += Buildings(i).type.ToString() + ": " + Buildings(i).Filled.ToString() + "/" + Buildings(i).Jobs.ToString() + "   Success: " + Buildings(i).Success.ToString() + ControlChars.NewLine
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
            city1 = -getDevelopment()
            city2 = -temp.getDevelopment()
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

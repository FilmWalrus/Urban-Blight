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
    Public Transportation = 0
    Public Terrain As Integer = TerrainPlain

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

    Public Sub New(ByVal col As Integer, ByVal row As Integer)
        RowID = row
        ColID = col
        Dim tempNum As Integer = GetRandom(1, 20)
        If tempNum <= 2 Then
            Terrain = TerrainOcean
        ElseIf tempNum <= 4 Then
            Terrain = TerrainRock
        ElseIf tempNum <= 6 Then
            Terrain = TerrainDirt
        ElseIf tempNum <= 8 Then
            Terrain = TerrainForest
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

    Public Function AddBuilding(ByVal NewBuilding As Building)
        Buildings.Add(NewBuilding)
    End Function

    Public Sub AddRoad()
        Transportation = Transportation + 1
        If Transportation > Highway Then
            Transportation = Highway
        End If
    End Sub

    Public Function MiracleBirth() As String
        Dim newPerson As New Person
        People.Add(newPerson)
        Return newPerson.Name
    End Function

    Public Function Birth(ByVal theParent As Person) As String
        Dim newPerson As New Person(theParent)
        People.Add(newPerson)
        Return newPerson.Name
    End Function

    Public Sub AddPerson(ByVal newPerson As Person)
        '-- Use for immigration
        People.Add(newPerson)
    End Sub

    Function WillExpand() As Boolean

    End Function

    Public Sub ComputerAverages()
        Dim tempPerson As Person
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
            If People(i).Employment > 0 Then
                'Update success of job
                tempPerson = People(i)
                BoxInfo(tempPerson.JobLocation.X, tempPerson.JobLocation.Y).Buildings(tempPerson.JobIndex).Success += tempPerson.Employment
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
                CityString += "Plain" + ControlChars.NewLine
                TerrainString = ControlChars.NewLine + "Plains are the default land type. They have no special effects."
            Case TerrainDirt
                CityString += "Dirt" + ControlChars.NewLine
                TerrainString = ControlChars.NewLine + "Dirt terrain makes for easy travel and terraforming. You will start out with dirt roads and get a 25% rebate on the land purchase."
            Case TerrainForest
                CityString += "Forest" + ControlChars.NewLine
                TerrainString = ControlChars.NewLine + "The natural beauty of forests boosts the health and happiness of local citizens."
            Case TerrainRock
                CityString += "Rock" + ControlChars.NewLine
                TerrainString = ControlChars.NewLine + "Rocks provide easy access to construction material. Cities placed here automatically erect one currently available building for free."
            Case TerrainOcean
                CityString += "Lake" + ControlChars.NewLine
                TerrainString = ControlChars.NewLine + "Lakes are fun for sailing but can't be built on."
        End Select
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
                Case None
                    CityString += "None" + ControlChars.NewLine
                Case Dirt
                    CityString += "Dirt" + ControlChars.NewLine
                Case Gravel
                    CityString += "Gravel" + ControlChars.NewLine
                Case Paved
                    CityString += "Paved" + ControlChars.NewLine
                Case Highway
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
            '--Head for area with most free jobs in unemployed (choose randomly if tied)
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

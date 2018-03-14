Module GlobalVars

#Region " Global Variables "
    '--Gameplay
    Public PlayerCount As Integer = 1
    Public GameType As Integer = 1
    Public GoalNumber As Integer = 0
    Public LastCityName As String = ""

    '--GameTypes
    Public Const ScoreGame As Integer = 0
    Public Const TerritoryGame As Integer = 1
    Public Const PopulationGame As Integer = 2
    Public Const DevelopmentGame As Integer = 3
    Public Const YearGame As Integer = 4
    Public Const InfiniteGame As Integer = 5

    '--Board
    Public Const GridWidth As Integer = 9 '-- 0 to 10
    Public Const GridHeight As Integer = 9 '-- 0 to 10
    Public TheBoxes(GridWidth, GridHeight) As Label
    Public BoxInfo(GridWidth, GridHeight) As CitySquare

    '--Terrain
    Public Const TerrainPlain As Integer = 0
    Public Const TerrainDirt As Integer = 1
    Public Const TerrainForest As Integer = 2
    Public Const TerrainRock As Integer = 3
    Public Const TerrainOcean As Integer = 4

    '--Roads
    Public Const RoadNone As Integer = 0
    Public Const RoadDirt As Integer = 1
    Public Const RoadGravel As Integer = 2
    Public Const RoadPaved As Integer = 3
    Public Const RoadHighway As Integer = 4

    '--Tabs
    Public Const EventTab As Integer = 0
    Public Const CardTab As Integer = 1
    Public Const CityTab As Integer = 2
    Public Const PersonTab As Integer = 3
    Public Const ViewTab As Integer = 4

    '--Colors
    Public Flag1 As Color = Color.IndianRed
    Public Flag2 As Color = Color.DarkOrchid 'Color.MediumPurple
    Public Flag3 As Color = Color.DarkOrange
    Public Flag4 As Color = Color.Gold 'Color.Khaki

    Public Const LandTypes As Integer = 5
    Public ColorOcean As Color = Color.SkyBlue 'Color.MidnightBlue
    Public ColorPlain As Color = Color.PaleGreen
    Public ColorRock As Color = Color.LightGray
    Public ColorDirt As Color = Color.Tan
    Public ColorForest As Color = Color.DarkSeaGreen 'Color.ForestGreen

    '--Views
    Public Const PopView = 0
    Public Const LocView = 1
    Public Const HappinessView = 2
    Public Const HealthView = 3
    Public Const EmploymentView = 4
    Public Const IntelligenceView = 5
    Public Const CreativityView = 6
    Public Const MobilityView = 7
    Public Const DrunkennessView = 8
    Public Const CriminalityView = 9
    Public Const JobView = 10
    Public Const RoadView = 11

    '--
    Public TimeIncrement As Integer = 3
    Public Namer As New NameGenerator

    '-- Sort Types
    Public Const PopSort = 0
    Public Const JobSort = 1
    Public Const CultureSort = 2
    Public SortType As Integer = 0
#End Region

#Region " Global Functions "
    Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Randomize(Date.Now.Millisecond)
        Max += 1
        Dim TheResult As Integer = Int(Min + (Rnd() * (Max - Min)))
        Return TheResult
    End Function

    Function SafeDivide(ByVal A As Double, ByVal B As Double) As Double
        If A = 0 Or B = 0 Then
            Return 0
        Else
            Return A / B
        End If
    End Function


#End Region

End Module

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
    Public Const TerrainMountain As Integer = 3
    Public Const TerrainLake As Integer = 4
    Public Const TerrainSwamp As Integer = 5
    Public Const TerrainTownship As Integer = 6
    Public Const TerrainDesert As Integer = 7

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
    Public Flag1 As Color = Color.Red 'Color.IndianRed
    Public Flag2 As Color = Color.DarkViolet 'Color.MediumPurple Color.DarkOrchid
    Public Flag3 As Color = Color.DarkOrange
    Public Flag4 As Color = Color.DeepPink 'Color.Gold

    Public Const LandTypes As Integer = 5
    Public ColorOcean As Color = Color.Aqua 'Color.Aqua 'Color.SkyBlue 'Color.MidnightBlue
    Public ColorPlain As Color = Color.PaleGreen
    Public ColorMountain As Color = Color.LightSlateGray 'Color.LightGray Gray LightSlateGray
    Public ColorDirt As Color = Color.Tan 'Color.Tan'Color.Khaki
    Public ColorForest As Color = Color.DarkSeaGreen 'Color.DarkSeaGreen 'Color.ForestGreen
    Public ColorSwamp As Color = Color.GreenYellow   'Color.OliveDrab 'Color.DarkSeaGreen LightBlue SteelBlue
    Public ColorTownship As Color = Color.GhostWhite 'Color.White
    Public ColorDesert As Color = Color.PaleGoldenrod

    Public ColorPlayerSelected As Color = Color.Gold 'Color.LemonChiffon
    Public ColorPlayerUnselected As Color = Color.White

    '--Views
    Public Const PopView As Integer = 0
    Public Const LocView As Integer = 1
    Public Const HappinessView As Integer = 2
    Public Const HealthView As Integer = 3
    Public Const EmploymentView As Integer = 4
    Public Const IntelligenceView As Integer = 5
    Public Const CreativityView As Integer = 6
    Public Const MobilityView As Integer = 7
    Public Const DrunkennessView As Integer = 8
    Public Const CriminalityView As Integer = 9
    Public Const JobView As Integer = 10
    Public Const RoadView As Integer = 11

    '--
    Public TimeIncrement As Integer = 3
    Public EventLimit As Integer = 5
    Public Namer As New NameGenerator

    '-- Sort Types
    Public Const PopSort As Integer = 0
    Public Const JobSort As Integer = 1
    Public Const CultureSort As Integer = 2
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

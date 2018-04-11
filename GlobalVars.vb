Imports System.Drawing

Module GlobalVars

#Region " Global Variables "
    '-- DEBUG MODE
    Public DebugMode As Boolean = False

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

    '--Player Types
    Public Const PlayerNone As Integer = 0
    Public Const PlayerHuman As Integer = 1
    Public Const PlayerAI As Integer = 2

    '--Players
    Public Players As New List(Of Player)
    Public Const MaxPlayers As Integer = 4
    Public CurrentPlayerIndex As Integer = 0

    '--Cards (Buildings available to buy)

    Public Const RoadCostBase As Integer = 50
    Public Const WipeCostBase As Integer = 100
    Public Const DropCostBase As Integer = 5

    '--Board
    Public Const GridWidth As Integer = 11 '-- 0 to 12
    Public Const GridHeight As Integer = 11 '-- 0 to 12
    Public GridArray(GridWidth, GridHeight) As CitySquare

    '--Terrain (There are 8 types)
    Public Const TerrainPlain As Integer = 0
    Public Const TerrainDirt As Integer = 1
    Public Const TerrainForest As Integer = 2
    Public Const TerrainMountain As Integer = 3
    Public Const TerrainLake As Integer = 4
    Public Const TerrainSwamp As Integer = 5
    Public Const TerrainTownship As Integer = 6
    Public Const TerrainDesert As Integer = 7
    Public Const TerrainMax As Integer = 7

    '--Roads
    Public Const RoadNone As Integer = 0
    Public Const RoadDirt As Integer = 1
    Public Const RoadGravel As Integer = 2
    Public Const RoadPaved As Integer = 3
    Public Const RoadHighway As Integer = 4

    '-- Citizen Stats
    Public Enum StatEnum
        Happiness
        Health
        Employment
        Intelligence
        Creativity
        Mobility
        Drunkenness
        Criminality
        EnumEnd
    End Enum

    '--Tabs
    Public Const EventTab As Integer = 0
    Public Const CityTab As Integer = 1
    Public Const BuildingTab As Integer = 2
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
    Public ColorFlip As Boolean = False

    '--Fonts
    'Dim newBold As New Font(ubEnd.Font.FontFamily, ubEnd.Font.Size, FontStyle.Bold)
    'Dim newRegular As New Font(ubEnd.Font.FontFamily, ubEnd.Font.Size, FontStyle.Regular)
    Public DemoFont As New Font("Franklin Gothic Medium", 18, FontStyle.Regular)
    Public LargeFont As New Font("Franklin Gothic Medium", 14, FontStyle.Regular)
    Public RegularFont As New Font("Franklin Gothic Medium", 12, FontStyle.Regular)

    '--Views
    Public Enum ViewEnum
        Population
        Coordinates
        Order
        Terrain
        Buildings
        Roads

        JobsTotal
        JobsFilled
        JobsUnfilled
        JobsNeed
        Minors
        Elderly

        Employees
        UnemployedAdults
        UnemployedTotal

        AgeAvg
        LifespanAvg
        MaxAge

        HappinessAvg
        HealthAvg
        EmploymentAvg
        IntelligenceAvg
        CreativityAvg
        MobilityAvg
        DrunkennessAvg
        CriminalityAvg

        HappinessAvgAdults
        HealthAvgAdults
        EmploymentAvgAdults
        IntelligenceAvgAdults
        CreativityAvgAdults
        MobilityAvgAdults
        DrunkennessAvgAdults
        CriminalityAvgAdults

        CurrentRevenue
        TotalRevenue
        CurrentUpkeep
        TotalUpkeep

        Athletic
        Coffee
        Commerce
        Criminal
        Culture
        Entertainment
        Food
        Franchise
        Government
        Manufacturing
        Medical
        Monument
        Nature
        Power
        Science
        Security
        Transport
        Travel

        EndEnum
    End Enum

    '--
    Public TimeIncrement As Integer = 3
    Public EventLimit As Integer = 5
    Public Namer As New NameGenerator
    Public Hinter As New HintGenerator
    Public Diary As New EventDiary

    '-- AI Decisions
    Public Const AIPass As Integer = -1
    Public Const AIBuilding1 As Integer = 0
    Public Const AIBuilding2 As Integer = 1
    Public Const AIBuilding3 As Integer = 2
    Public Const AIBuilding4 As Integer = 3
    Public Const AIBuilding5 As Integer = 4
    Public Const AIRoad As Integer = 5
    Public Const AILand As Integer = 6

    '-- Sort Types
    Public Const VisitOrderSort As Integer = 0
    Public Const PopSort As Integer = 1
    Public Const JobSort As Integer = 2
    Public Const CultureSort As Integer = 3
    Public SortType As Integer = 0

    '-- Building Stuff
    Public BuildingGenerator As New BuildingGen()
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

    Function GetCitySquare(ByVal Row As Integer, ByVal Col As Integer) As CitySquare
        If Row < 0 Or Row > GridWidth Or Col < 0 Or Col > GridHeight Then
            Return Nothing
        End If
        Return GridArray(Row, Col)
    End Function

    Public Function GetStatName(ByVal StatType As Integer) As String
        Select Case StatType
            Case StatEnum.Happiness
                Return "Happiness"
            Case StatEnum.Health
                Return "Health"
            Case StatEnum.Employment
                Return "Employment"
            Case StatEnum.Creativity
                Return "Creativity"
            Case StatEnum.Intelligence
                Return "Intelligence"
            Case StatEnum.Criminality
                Return "Criminality"
            Case StatEnum.Drunkenness
                Return "Drunkenness"
            Case Else
                Return "Error"
        End Select
    End Function

    Function GetTerrainName(ByVal terrainIndex As Integer, Optional ByVal coastNotLake As Boolean = False) As String
        Select Case (terrainIndex)
            Case TerrainPlain
                Return "Plain"
            Case TerrainDirt
                Return "Dirt"
            Case TerrainForest
                Return "Forest"
            Case TerrainMountain
                Return "Mountain"
            Case TerrainLake
                If coastNotLake Then
                    Return "Coastal"
                Else
                    Return "Lake"
                End If
            Case TerrainSwamp
                Return "Swamp"
            Case TerrainDesert
                Return "Desert"
            Case TerrainTownship
                Return "Township"
            Case Else
                Return "None"
        End Select

    End Function

#End Region

End Module

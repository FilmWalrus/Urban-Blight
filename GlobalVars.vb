Imports System.Drawing

Module GlobalVars

#Region " Global Variables "

    '--Gameplay
    Public UrbanBlight As New Main()
    Public GameType As Integer = 1
    Public GoalNumber As Integer = 0
    Public LastCityName As String = ""
    Public SortType As Integer = 0

    Public Const RoadCostBase As Integer = 50
    Public Const WipeCostBase As Integer = 100
    Public Const DropCostBase As Integer = 5

    '--Board
    Public Const GridWidth As Integer = 11 '-- 0 to 12
    Public Const GridHeight As Integer = 11 '-- 0 to 12
    Public GridArray(GridWidth, GridHeight) As CitySquare

    '--Players
    Public PlayerCount As Integer = 1
    Public Players As New List(Of Player)
    Public Const MaxPlayers As Integer = 4
    Public CurrentPlayer As Player = Nothing

    '-- Cards (Buildings available)
    Public Cards(CardEnum.BuildingSpecialOrder) As Building
    Public BuildingGenerator As New BuildingGen()

    '--
    Public TimeIncrement As Integer = 3
    Public EventLimit As Integer = 5
    Public Namer As New NameGenerator
    Public Hinter As New HintGenerator
    Public Diary As New EventDiary

    '-- DEBUG MODE
    Public DebugMode As Boolean = False

#End Region

#Region " Enums "

    '--GameTypes
    Public Enum GameEnum
        Score
        Territory
        Population
        Development
        Year
        Infinite
    End Enum

    '--Player Types
    Public Enum PlayerTypeEnum
        None
        Human
        AI
    End Enum

    '--Buttons (Main player actions)
    Public Enum CardEnum
        NoCard = -1
        Building1
        Building2
        Building3
        Building4
        BuildingSpecialOrder
        Road
        Land
        WipeBuildings
        RoadMax
        EndEnum
    End Enum

    '--Terrain (There are 8 types)
    Public Enum TerrainEnum
        Plain
        Dirt
        Forest
        Mountain
        Lake
        Swamp
        Township
        Desert
        EndEnum
    End Enum

    '--Roads
    Public Enum RoadEnum
        None
        Dirt
        Gravel
        Paved
        Highway
        EndEnum
    End Enum

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

    '-- Causes of Death
    Public Enum DeathEnum
        NaturalCauses
        Illness
        TrafficAccident
        Murder
        ResistingArrest
        Unknown
        EnumEnd
    End Enum

    '-- Crimes
    Public Enum CrimeEnum
        Parking_Tickets
        Traffic_Tickets
        Robbery
        Vandalism
        Arson
        Murder
        Unknown
        EnumEnd
    End Enum

    '--Tabs
    Public Enum TabsEnum
        Events
        City
        Building
        Person
        Game
        EnumEnd
    End Enum

    '--Views
    Public Enum ViewEnum
        Population
        Coordinates
        Order
        Terrain
        Buildings
        Roads

        Jobs_Total
        Jobs_Filled
        Jobs_Unfilled
        Jobs_Needed
        Minors
        Elderly

        Employed
        Self_Employed
        Unemployed_Adults
        Unemployed_Total

        Average_Age
        Average_Lifespan
        Oldest_Person

        Average_Happiness
        Average_Health
        Average_Employment
        Average_Intelligence
        Average_Creativity
        Average_Mobility
        Average_Drunkenness
        Average_Criminality

        Average_Adult_Happiness
        Average_Adult_Health
        Average_Adult_Employment
        Average_Adult_Intelligence
        Average_Adult_Creativity
        Average_Adult_Mobility
        Average_Adult_Drunkenness
        Average_Adult_Criminality

        Revenue_This_Turn
        Total_Revenue
        Upkeep_This_Turn
        Total_Upkeep

        Parking_Tickets
        Traffic_Tickets
        Robberies
        Vandalisms
        Arsons
        Murders

        Deaths_by_Natural_Causes
        Deaths_by_Illness
        Deaths_by_Traffic_Accident
        Deaths_by_Murder
        Deaths_by_Resisting_Arrest

        Buildings_owned_by_current_player
        Buildings_owned_by_other_players
        Buildings_owned_by_Player_1
        Buildings_owned_by_Player_2
        Buildings_owned_by_Player_3
        Buildings_owned_by_Player_4

        Buildings_Created
        Buildings_Founded_by_Citizens
        Buildings_Closed

        Athletic_Buildings
        Coffee_Buildings
        Commerce_Buildings
        Criminal_Buildings
        Culture_Buildings
        Entertainment_Buildings
        Food_Buildings
        Franchise_Buildings
        Government_Buildings
        Manufacturing_Buildings
        Medical_Buildings
        Monument_Buildings
        Nature_Buildings
        Power_Buildings
        Science_Buildings
        Security_Buildings
        Transport_Buildings
        Travel_Buildings

        EndEnum
    End Enum


    '-- Sort Types (Add more?)
    Public Enum CitySortEnum
        VisitOrder
        Population
        Jobs
        Culture
    End Enum

#End Region

#Region " Colors "
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
#End Region

#Region " Fonts "
    '--Fonts
    'Dim newBold As New Font(ubEnd.Font.FontFamily, ubEnd.Font.Size, FontStyle.Bold)
    'Dim newRegular As New Font(ubEnd.Font.FontFamily, ubEnd.Font.Size, FontStyle.Regular)
    Public DemoFont As New Font("Franklin Gothic Medium", 18, FontStyle.Regular)
    Public LargeFont As New Font("Franklin Gothic Medium", 14, FontStyle.Regular)
    Public RegularFont As New Font("Franklin Gothic Medium", 12, FontStyle.Regular)
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
        Dim StatString As String = CType(StatType, StatEnum).ToString()
        StatString = StatString.Replace("_", " ")
        Return StatString
    End Function

    Function GetCrimeName(ByVal CrimeType As Integer) As String
        Dim CrimeString As String = CType(CrimeType, CrimeEnum).ToString()
        CrimeString = CrimeString.Replace("_", " ")
        Return CrimeString
    End Function

    Function GetTerrainName(ByVal terrainIndex As Integer, Optional ByVal coastNotLake As Boolean = False) As String
        Dim TerrainString As String = CType(terrainIndex, TerrainEnum).ToString()
        TerrainString = TerrainString.Replace("_", " ")
        Return TerrainString
    End Function

    Public Function GetViewName(ByVal ViewType As Integer) As String
        Dim ViewString As String = CType(ViewType, ViewEnum).ToString()
        ViewString = ViewString.Replace("_", " ")
        Return ViewString
    End Function

#End Region

End Module

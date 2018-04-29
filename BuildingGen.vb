Imports Urban_Blight

Public Class BuildingGen

#Region " Variables "

    Public Const SelfEmployed As Integer = -2

    Public Enum BuildingEnum
        Ad_Agency
        Activism_Organization
        Airport
        Ambulance_Service
        Amusement_Park
        Apartments
        Aquarium
        Architecture_Firm
        'Art_Gallery
        'Bank
        Bar
        Black_Market
        Botanical_Garden
        'Campsite
        Cancer_Hospital
        Cartel
        Casino
        Church
        City_Wall
        Civic_Center
        Coffee_Shop
        Community_Center
        Concert_Venue
        Conglomerate
        Conservation_Area
        Construction_Site
        Correctional_Facility
        Courthouse
        Crime_Ring
        Cult
        Customs_House
        Daycare_Center
        Department_Store
        Detective_Agency
        Embassy
        Emergency_Hospital
        Exurb
        Factory
        Farm
        Fast_Food_Chain
        Fire_Station
        Fishery
        Freeway
        Gas_Station
        Geriatric_Hospital
        Golf_Course
        Government_Bureau
        Graveyard
        Grocery_Store
        Gym
        Harbor
        Hotel
        Laboratory
        Land_Developer
        'Landfill
        Law_Firm
        Library
        Lumber_Mill
        Mall
        Mass_Transit
        Maternity_Hospital
        Mine
        Monument
        Military_Base
        Museum
        Observatory
        Oil_Well
        Office
        Park
        Parking_Garage
        Parking_Lot
        Pediatric_Hospital
        Pharmacy
        Police_Station
        Polling_Place
        'Post_Office
        Power_Plant
        Private_Security_Company
        Ranch
        'Refugee_Camp
        Rehab_Clinic
        Research_Hospital
        Restaurant
        Retirement_Home
        Safe_House
        School
        Shipping_Center
        Sidewalks
        Ski_Resort
        Skyscraper
        Stadium
        Startup_Incubator
        Steel_Mill
        'Suburb
        Tax_Assessor
        Taxi_Service
        Temp_Agency
        Textile_Mill
        Theater
        Think_Tank
        Toll_Booth
        Tourism_Agency
        TV_Station
        University
        Warehouse
        Welfare_Service
        Zoo
        BuildingCount
    End Enum

    Public Enum TagEnum
        Athletic
        Coffee
        Commerce
        Criminal
        Entertainment
        Food
        Franchise
        Government
        Manufacturing
        Medical
        Monument
        Nature
        Science
        Security
        Transportation
    End Enum

#End Region

#Region " Functions "

    Public Function GetName(ByVal bType As Integer) As String
        Dim BuildingString As String = CType(bType, BuildingEnum).ToString()
        BuildingString = BuildingString.Replace("_", " ")
        Return BuildingString
    End Function

    Public Function GetTagName(ByVal Tag As Integer) As String
        Dim TagString As String = CType(Tag, TagEnum).ToString()
        TagString = TagString.Replace("_", " ")
        Return TagString
    End Function

    Public Function GetBaseCost(ByVal bType As Integer) As Integer
        Select Case bType
            Case BuildingEnum.Ad_Agency
                Return 110
            Case BuildingEnum.Activism_Organization
                Return 65
            Case BuildingEnum.Airport
                Return 510
            Case BuildingEnum.Ambulance_Service
                Return 280
            Case BuildingEnum.Amusement_Park
                Return 455
            Case BuildingEnum.Apartments
                Return 360
            Case BuildingEnum.Aquarium
                Return 195
            Case BuildingEnum.Architecture_Firm
                Return 210
            'Case BuildingEnum.Art_Gallery
            '    Return 120
            'Case BuildingEnum.Bank
            '    Return -1
            Case BuildingEnum.Bar
                Return 60
            Case BuildingEnum.Black_Market
                Return 305
            Case BuildingEnum.Botanical_Garden
                Return 260
            'Case BuildingEnum.Campsite
            '    Return -1
            Case BuildingEnum.Cartel
                Return 140
            Case BuildingEnum.Casino
                Return 395
            Case BuildingEnum.Church
                Return 180
            Case BuildingEnum.City_Wall
                Return 100
            Case BuildingEnum.Civic_Center
                Return 635
            Case BuildingEnum.Coffee_Shop
                Return 75
            Case BuildingEnum.Community_Center
                Return 210
            Case BuildingEnum.Concert_Venue
                Return 385
            Case BuildingEnum.Conglomerate
                Return 425
            Case BuildingEnum.Conservation_Area
                Return 65
            Case BuildingEnum.Construction_Site
                Return 160
            Case BuildingEnum.Correctional_Facility
                Return 185
            Case BuildingEnum.Courthouse
                Return 130
            Case BuildingEnum.Crime_Ring
                Return 50
            Case BuildingEnum.Cult
                Return 70
            Case BuildingEnum.Customs_House
                Return 255
            Case BuildingEnum.Daycare_Center
                Return 80
            Case BuildingEnum.Department_Store
                Return 185
            Case BuildingEnum.Detective_Agency
                Return 80
            Case BuildingEnum.Embassy
                Return 215
            Case BuildingEnum.Exurb
                Return 435
            Case BuildingEnum.Factory
                Return 125
            Case BuildingEnum.Farm
                Return 80
            Case BuildingEnum.Fast_Food_Chain
                Return 50
            Case BuildingEnum.Fire_Station
                Return 100
            Case BuildingEnum.Fishery
                Return 165
            Case BuildingEnum.Freeway
                Return 275
            Case BuildingEnum.Gas_Station
                Return 110
            Case BuildingEnum.Golf_Course
                Return 140
            Case BuildingEnum.Government_Bureau
                Return 240
            Case BuildingEnum.Graveyard
                Return 100
            Case BuildingEnum.Grocery_Store
                Return 95
            Case BuildingEnum.Gym
                Return 65
            Case BuildingEnum.Harbor
                Return 95
            Case BuildingEnum.Cancer_Hospital
                Return 270
            Case BuildingEnum.Emergency_Hospital
                Return 240
            Case BuildingEnum.Geriatric_Hospital
                Return 200
            Case BuildingEnum.Maternity_Hospital
                Return 250
            Case BuildingEnum.Pediatric_Hospital
                Return 190
            Case BuildingEnum.Research_Hospital
                Return 260
            Case BuildingEnum.Hotel
                Return 275
            Case BuildingEnum.Laboratory
                Return 205
            Case BuildingEnum.Land_Developer
                Return 350
            'Case BuildingEnum.Landfill
            '    Return -1
            Case BuildingEnum.Law_Firm
                Return 280
            Case BuildingEnum.Library
                Return 105
            Case BuildingEnum.Lumber_Mill
                Return 130
            Case BuildingEnum.Mall
                Return 385
            Case BuildingEnum.Mass_Transit
                Return 175
            Case BuildingEnum.Mine
                Return 55
            Case BuildingEnum.Monument
                Return 85
            Case BuildingEnum.Military_Base
                Return 260
            Case BuildingEnum.Museum
                Return 150
            Case BuildingEnum.Observatory
                Return 95
            Case BuildingEnum.Oil_Well
                Return 445
            Case BuildingEnum.Office
                Return 145
            Case BuildingEnum.Park
                Return 125
            Case BuildingEnum.Parking_Garage
                Return 155
            Case BuildingEnum.Parking_Lot
                Return 50
            Case BuildingEnum.Pharmacy
                Return 70
            Case BuildingEnum.Police_Station
                Return 155
            Case BuildingEnum.Polling_Place
                Return 255
            'Case BuildingEnum.Post_Office
            '    Return -1
            Case BuildingEnum.Power_Plant
                Return 455
            Case BuildingEnum.Private_Security_Company
                Return 205
            Case BuildingEnum.Ranch
                Return 130
            'Case BuildingEnum.Refugee_Camp
            '    Return 80
            Case BuildingEnum.Rehab_Clinic
                Return 145
            Case BuildingEnum.Restaurant
                Return 115
            Case BuildingEnum.Retirement_Home
                Return 130
            Case BuildingEnum.Safe_House
                Return 65
            Case BuildingEnum.School
                Return 160
            Case BuildingEnum.Shipping_Center
                Return 175
            Case BuildingEnum.Sidewalks
                Return 35
            Case BuildingEnum.Ski_Resort
                Return 215
            Case BuildingEnum.Skyscraper
                Return 325
            Case BuildingEnum.Stadium
                Return 310
            Case BuildingEnum.Startup_Incubator
                Return 325
            Case BuildingEnum.Steel_Mill
                Return 505
            'Case BuildingEnum.Suburb
            '    Return -1
            Case BuildingEnum.Tax_Assessor
                Return 125
            Case BuildingEnum.Taxi_Service
                Return 145
            Case BuildingEnum.Temp_Agency
                Return 135
            Case BuildingEnum.Textile_Mill
                Return 295
            Case BuildingEnum.Theater
                Return 180
            Case BuildingEnum.Think_Tank
                Return 275
            Case BuildingEnum.Toll_Booth
                Return 40
            Case BuildingEnum.Tourism_Agency
                Return 70
            Case BuildingEnum.TV_Station
                Return 250
            Case BuildingEnum.University
                Return 370
            Case BuildingEnum.Warehouse
                Return 210
            Case BuildingEnum.Welfare_Service
                Return 100
            Case BuildingEnum.Zoo
                Return 410
            Case Else
                Return -1
        End Select
    End Function

    Public Function CreateBuilding(ByVal bType As Integer) As Building

        Do
            If bType < 0 Then
                bType = GetRandom(0, BuildingEnum.BuildingCount - 1)
            End If

            Select Case bType

                Case BuildingEnum.Ad_Agency
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 20, -2)
                    newBuilding.SetStat(StatEnum.Creativity, 10, 2)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Want to boost the effects of local commercial businesses?  Hire an Ad Agency to get those creative juices flowing.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Activism_Organization
                    Dim newBuilding As New ActivismBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 20, 2)
                    newBuilding.SetStat(StatEnum.Health, 30, 4)
                    newBuilding.SetStat(StatEnum.Intelligence, 15, 1)
                    newBuilding.SetInfo("Our mission is to spread awareness, improve community wellbeing, and fight corporate corruption wherever it lurks!")
                    ' Special ability text set internally
                    '-- Note: Banned buildings could still get built by Construction Sites, Startup Incubator, etc.
                    Return newBuilding
                Case BuildingEnum.Airport
                    Dim newBuilding As New AirportBuilding(bType, GetBaseCost(bType), 6)
                    newBuilding.SetStat(StatEnum.Happiness, 15, -1)
                    newBuilding.SetStat(StatEnum.Mobility, 18, 10)
                    newBuilding.SetStat(StatEnum.Health, 15, -1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.SetInfo("Crowds, queues, and over-priced food that's famously bad, but how else can you reach those far-away destinations that promise relaxation?")
                    newBuilding.SetSpecialAbility("Cities containing Airports are considered adjacent to other citiies containing Airports - both yours and those belonging to other players.")
                    Return newBuilding
                Case BuildingEnum.Ambulance_Service
                    Dim newBuilding As New AmbulanceBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Health, 10, 4)
                    newBuilding.SetStat(StatEnum.Mobility, 10, 1)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("In a medical emergency, the Ambulance Service provides treatment and transport for afflicted individuals.")
                    newBuilding.SetSpecialAbility("The Ambulance Service boosts the effects of all medical buildings within a radius of two adjacent squares.")
                    Return newBuilding
                Case BuildingEnum.Amusement_Park
                    Dim newBuilding As New AmusementBuilding(bType, GetBaseCost(bType), 4, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 16, 7)
                    newBuilding.SetStat(StatEnum.Health, 20, -1)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Remember the excitement (mixed with a little terror) that coursed through you at the top of your first roller coaster?  Relive those experiences at the Amusement Park!")
                    newBuilding.SetSpecialAbility("Minors visit twice as often as adults.")
                    Return newBuilding
                Case BuildingEnum.Apartments
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetInfo("Everyone needs a place to call home.  Apartment-living is cheap and puts you in the middle of the action.")
                    newBuilding.SetSpecialAbility("Increases the threshold by 10 where overpopulation begins to have a negative effect.")
                    Return newBuilding
                Case BuildingEnum.Aquarium
                    Dim newBuilding As New AquariumBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 25, 3)
                    newBuilding.SetStat(StatEnum.Health, 15, 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 15, 1)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("")
                    newBuilding.SetSpecialAbility("+1 max effect for each lake in range 1. +2% odds for each coastline you own.")
                    Return newBuilding
                Case BuildingEnum.Architecture_Firm
                    Dim newBuilding As New ArchitectBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 10, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 18, 4)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Paris. New York. Dubai. Three cities full of culture and architectural wonders.  Should your city join them?")
                    newBuilding.SetSpecialAbility("The Architecture Firm increases the chances that the 'Redraw Above' action will be set to $0.")
                    Return newBuilding
                'Case BuildingEnum.Art_Gallery
                '    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                '    newBuilding.SetStat(StatEnum.Creativity, 33, 4)
                '    newBuilding.SetInfo("Feel inspired by the works of the great paintings, drawings, sculptures, and photography that surround you at the Art Gallery.")
                '    newBuilding.SetSpecialAbility("")
                '    Return newBuilding
                'Case BuildingEnum.Bank

                Case BuildingEnum.Bar
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 30, 4)
                    newBuilding.SetStat(StatEnum.Health, 10, 0)
                    newBuilding.SetStat(StatEnum.Drunkenness, 30, 6)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.SetInfo("Bars provide a social atmosphere to cheer people up but can result in overindulgence.")
                    newBuilding.SetSpecialAbility("Bars double the effect of Stadiums and Colleges on the same square.")
                    Return newBuilding
                Case BuildingEnum.Black_Market
                    Dim newBuilding As New BlackMarketBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Criminality, 50, 3)
                    newBuilding.AddTag(TagEnum.Criminal)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Though dubious in nature, the Black Market can get you what you want.")
                    'Special ability text set internally
                    Return newBuilding
                Case BuildingEnum.Botanical_Garden
                    Dim newBuilding As New BotanicalBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 30, 2)
                    newBuilding.SetStat(StatEnum.Health, 45, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 15, 1)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.SetInfo("Stretch your legs and see what nature has to offer at the Botanical Garden.  Wander around the flowers, trees, and hedges and feel the tranquility set in.")
                    newBuilding.SetSpecialAbility("+1 max effect for each forest in range 1. +2% odds for each forest you own.")
                    Return newBuilding
                'Case BuildingEnum.Campsite

                Case BuildingEnum.Cartel
                    Dim newBuilding As New ManufacturingBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 28, 5)
                    newBuilding.SetStat(StatEnum.Health, 12, -7)
                    newBuilding.SetStat(StatEnum.Drunkenness, 30, 10)
                    newBuilding.SetStat(StatEnum.Criminality, 30, 4)
                    newBuilding.AddTag(TagEnum.Criminal)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("Drugs, sex, and rock 'n' roll. Or at least the drugs... The Cartel can give you the temporary euphoria you crave, but there many be a few consequences.")
                    newBuilding.SetSpecialAbility("The Cartel starts with twice the number of jobs if built on a Dirt tile.")
                    Return newBuilding
                Case BuildingEnum.Casino
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 4) 'Check my Special Ability wording on this one.
                    newBuilding.SetStat(StatEnum.Happiness, 50, 3)
                    newBuilding.SetStat(StatEnum.Drunkenness, 50, 3)
                    newBuilding.SetStat(StatEnum.Criminality, 22, 3)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Roll the dice at the Casino!  Will you hit it big and leave happy or lose it all and drown your sorrows?")
                    newBuilding.SetSpecialAbility("The player will receive a payout for each person that visits the Casino.")
                    Return newBuilding
                Case BuildingEnum.Church
                    Dim newBuilding As New ChurchBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 14, 7)
                    newBuilding.SetStat(StatEnum.Drunkenness, 35, -4)
                    newBuilding.SetStat(StatEnum.Criminality, 16, -3)
                    newBuilding.SetInfo("While not attended by everyone, Churches can have a noticable effect on increasing inner peace and decreasing destructive traits.")
                    newBuilding.SetSpecialAbility("Churches have a slight chance of reducing Criminality and Drunkenness to 0.")
                    Return newBuilding
                Case BuildingEnum.City_Wall
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 0) 'Check the phrasing of Special Ability.
                    newBuilding.SetStat(StatEnum.Mobility, 15, -3)
                    newBuilding.SetStat(StatEnum.Criminality, 15, -3)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("City Walls have been used for centuries as a way to contain and protect inhabitants from unwanted intruders.")
                    newBuilding.SetSpecialAbility("For each adjacent square that is unoccupied, the City Wall will provide one job and boost odds by a multiplier of one.  For each adjacent square that is occupied by an opponent, the City Wall will provide two jobs and boost odds by a multiplier of two.")
                    Return newBuilding
                Case BuildingEnum.Civic_Center
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 8)
                    newBuilding.SetStat(StatEnum.Happiness, 25, 3)
                    newBuilding.SetStat(StatEnum.Intelligence, 25, 3)
                    newBuilding.SetStat(StatEnum.Creativity, 25, 3)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Civic Centers provide public spaces and shared landscapes for the free flow of commerce, art, and culture.")
                    newBuilding.SetSpecialAbility("The Civic Center provides the owner with increased odds of positive random events.")
                    Return newBuilding
                Case BuildingEnum.Coffee_Shop
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 20, 1)
                    newBuilding.SetStat(StatEnum.Health, 15, 0)
                    newBuilding.SetStat(StatEnum.Mobility, 20, 1)
                    newBuilding.SetStat(StatEnum.Drunkenness, 40, -1)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.SetInfo("Coffee Shops perk you up and put a spring in your step. Though caffeine can be addictive, it's not as bad as alcohol.")
                    newBuilding.SetSpecialAbility("Coffee Shops are more effective on Libraries, Offices, Skyscrapers, and at Colleges.")
                    Return newBuilding
                Case BuildingEnum.Community_Center
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2, 14)
                    newBuilding.SetStat(StatEnum.Health, 10, 2)
                    newBuilding.SetStat(StatEnum.Happiness, 10, 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 10, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 10, 2)
                    newBuilding.SetStat(StatEnum.Mobility, 10, 2)
                    newBuilding.SetStat(StatEnum.Drunkenness, 10, -2)
                    newBuilding.SetStat(StatEnum.Criminality, 10, -2)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("Community Centers allow for people of different walks of life to come together for the benefit of society.")
                    newBuilding.SetSpecialAbility("Nullifies the negative effects of Refugee Camps, Correctional Facilities, and Rehab Clinics.  Upkeep costs are required for each visitor.")
                    Return newBuilding
                Case BuildingEnum.Concert_Venue
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 45, 1)
                    newBuilding.SetStat(StatEnum.Creativity, 55, 4)
                    newBuilding.SetStat(StatEnum.Drunkenness, 45, 3)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Whether you jam out in the mosh pit or sway in you seat, Concert Venues can allow for a crazy good time.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Conglomerate
                    Dim newBuilding As New ConglomerateBuilding(bType, GetBaseCost(bType), 7)
                    newBuilding.SetStat(StatEnum.Happiness, 15, -2)
                    newBuilding.SetStat(StatEnum.Drunkenness, 20, 3)
                    newBuilding.SetStat(StatEnum.Creativity, 30, -4)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("") '-- Kelley, got a new one for you
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Conservation_Area
                    Dim newBuilding As New ConservationBuilding(bType, GetBaseCost(bType), 0)
                    newBuilding.SetStat(StatEnum.Health, 15, 1)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.SetInfo("Enjoy the great outdoors and help save it at the same time.")
                    newBuilding.SetSpecialAbility("Conservation Areas nullify negative terrain effects of the square it is built on.")
                    Return newBuilding
                Case BuildingEnum.Construction_Site
                    Dim newBuilding As New ConstructionSiteBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Criminality, 30, 2)
                    newBuilding.SetInfo("")
                    newBuilding.SetInfo("Construction Sites show that a city is prosperous and growing, though the half-finished lots sometimes shelter shady deals.  How quickly the building is finished is up to the crew.")
                    newBuilding.SetSpecialAbility("In 1 to 6 turns, the Construction Site will turn into a new building.  At this point, all people employed by the Construction Site will lose their jobs.")
                    Return newBuilding
                Case BuildingEnum.Correctional_Facility 'Skipped.  Come back to later.
                    Dim newBuilding As New CorrectionalFacilityBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Criminality, 60, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Courthouse
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 12, -5)
                    newBuilding.SetStat(StatEnum.Intelligence, 15, 1)
                    newBuilding.SetStat(StatEnum.Criminality, 25, -3)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("It's usually a bad day if you end up there, but Courthouses serve a purpose: settling tricky matters of justice, laying down the law of the land, and providing a place to pay those pesky parking tickets.")
                    newBuilding.SetSpecialAbility("Courthouses let the owner collect double the money from fines within a two-square adjacency of the building. If the Courthouse is built on a Swamp tile, fines are tripled.")
                    Return newBuilding
                Case BuildingEnum.Crime_Ring
                    Dim newBuilding As New CrimeRingBuilding(bType, GetBaseCost(bType), 4, 10)
                    newBuilding.SetStat(StatEnum.Criminality, 14, 10)
                    newBuilding.AddTag(TagEnum.Criminal)
                    newBuilding.SetInfo("Crime Rings bring plenty of cheap jobs but sharp, sporadic increases in extreme criminal behavior are likely.")
                    newBuilding.SetSpecialAbility("Crimes committed on the square of the Crime Ring result in monetary kickbacks to the owner.")
                    Return newBuilding
                Case BuildingEnum.Cult
                    Dim newBuilding As New CultBuilding(bType, GetBaseCost(bType), 2) 'Skipped.  Come back later.
                    newBuilding.SetStat(StatEnum.Happiness, 5, 20)
                    newBuilding.SetStat(StatEnum.Intelligence, 10, -6)
                    newBuilding.SetStat(StatEnum.Criminality, 25, 3)
                    newBuilding.AddTag(TagEnum.Franchise)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Customs_House
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Creativity, 33, 3)
                    newBuilding.SetStat(StatEnum.Criminality, 10, 2)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Imports and exports all go through the Customs House.  What new book, art piece, narcotic, or exotic animal will come in today?")
                    newBuilding.SetSpecialAbility("Customs Houses generate revenue for the owner and are more effective for each unique player with an adjacent square.")
                    Return newBuilding
                Case BuildingEnum.Daycare_Center
                    Dim newBuilding As New DayCareBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 20, 5)
                    newBuilding.SetStat(StatEnum.Health, 18, 2)
                    newBuilding.SetStat(StatEnum.Criminality, 20, -2)
                    newBuilding.SetInfo("Daycare Centers and after-school programs provide a place for minors while their parents are at work.  They are excellent places for children to learn interpersonal skills while they play.")
                    newBuilding.SetSpecialAbility("The Daycare Center effects only minors.")
                    Return newBuilding
                Case BuildingEnum.Department_Store
                    Dim newBuilding As New DepartmentStoreBuilding(bType, GetBaseCost(bType), 3, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 8, 1)
                    newBuilding.SetStat(StatEnum.Creativity, 12, -1)
                    newBuilding.AddTag(TagEnum.Franchise)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Make errands eazy and fun at the Department Store - the one-stop shop for all your home and clothing needs.")
                    newBuilding.SetSpecialAbility("Department Stores not only open new branches, they sometimes upgrade into malls.")
                    Return newBuilding
                Case BuildingEnum.Detective_Agency
                    Dim newBuilding As New DetectiveBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Criminality, 8, -8)
                    newBuilding.AddTag(TagEnum.Security)
                    newBuilding.SetInfo("Suspicious of a co-worker? Want to know the whereabouts of your lover? Some cases aren't meant for the police. That's where the Detective Agency comes in to play.")
                    newBuilding.SetSpecialAbility("The Detective Agency lets you see where your citizens have been and what they've done on their last turn. This only applies to citizens living on the square with the Detective Agency.")
                    Return newBuilding
                Case BuildingEnum.Embassy
                    Dim newBuilding As New EmbassyBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 10, 8)
                    newBuilding.SetStat(StatEnum.Criminality, 10, 7)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("")
                    newBuilding.SetSpecialAbility("You can build in other player's territory at 120% cost -10% for each additional embassy. You retain ownership, keep any revenue, and pay any upkeep.")
                    Return newBuilding
                Case BuildingEnum.Exurb
                    Dim newBuilding As New ExurbBuilding(bType, GetBaseCost(bType), 0) 'Check phrasing of Exurb special ability text.
                    newBuilding.SetStat(StatEnum.Mobility, 15, 2)
                    newBuilding.SetInfo("Sometimes you just need to escape the city.  Exurbs let you get away, but still remain close to the hustle and bustle of your metropolis.")
                    newBuilding.SetSpecialAbility("The next piece of land you buy can be any unoccupied square on the board and starts with +2 population. Citizens can commute between this building and the exurb.")
                    Return newBuilding
                Case BuildingEnum.Factory
                    Dim newBuilding As New ManufacturingBuilding(bType, GetBaseCost(bType), 5)
                    newBuilding.SetStat(StatEnum.Happiness, 16, -3)
                    newBuilding.SetStat(StatEnum.Health, 33, -6)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Factories provide many needed jobs but their monotony can be depressing and their pollution harmful.")
                    newBuilding.SetSpecialAbility("The effects of a Factory are worse for every 10 population sharing its square.")
                    Return newBuilding
                Case BuildingEnum.Farm
                    Dim newBuilding As New FarmBuilding(bType, GetBaseCost(bType), 1, 12)
                    newBuilding.SetStat(StatEnum.Health, 65, 2)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.SetInfo("Farms are the backbone of any society. They provide fresh produce and fibers to the local community.")
                    newBuilding.SetSpecialAbility("Farms double the effect of any Food buildings on the same square.  Farms expand faster on a Dirt tile.")
                    Return newBuilding
                Case BuildingEnum.Fast_Food_Chain
                    Dim newBuilding As New FastFoodBuilding(bType, GetBaseCost(bType), 1, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 65, 1)
                    newBuilding.SetStat(StatEnum.Health, 65, -2)
                    newBuilding.SetStat(StatEnum.Mobility, 15, 1)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.AddTag(TagEnum.Franchise)
                    newBuilding.SetInfo("Quick and convenient with a side order of grease, Fast Food Chains help satisfy your food cravings and fuel you up for the day to come.")
                    newBuilding.SetSpecialAbility("Fast Food Chains have a small chance of opening another location on an adjacent square.")
                    Return newBuilding
                Case BuildingEnum.Fire_Station 'What range for the special ability?  Clarify in Special Ability text.
                    Dim newBuilding As New FireStationBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Health, 5, 1)
                    newBuilding.AddTag(TagEnum.Security)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("An important part of any society, Fire Stations help stop the spread of local fires and improve general wellbeing.")
                    newBuilding.SetSpecialAbility("Fire Stations reduce the chance of arson and fires.")
                    Return newBuilding
                Case BuildingEnum.Fishery 'I can't come up with anything here.
                    Dim newBuilding As New ManufacturingBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 10, -2)
                    newBuilding.SetStat(StatEnum.Health, 5, 1)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Freeway
                    Dim newBuilding As New FreewayBuilding(bType, GetBaseCost(bType), 0)
                    newBuilding.SetStat(StatEnum.Health, 10, -3)
                    newBuilding.SetStat(StatEnum.Mobility, 20, 6)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Eight lanes of shimmering cement. Smooth, ""safe"", fast. Traffic jams will be a thing of the past.")
                    newBuilding.SetSpecialAbility("Upgrades all roads within a two square adjacency, regardless of owner, by one level.")
                    Return newBuilding
                Case BuildingEnum.Gas_Station
                    Dim newBuilding As New GasStationBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Health, 30, -2)
                    newBuilding.SetStat(StatEnum.Mobility, 38, 3)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.SetInfo("Gas Stations let your citizens drive futher and explore more.  If only vehicles didn't give off pollution.")
                    newBuilding.SetSpecialAbility("When your citizens travel to the Gas Station, their mobility increases by 8. However, fires on the same square as the Gas Station are worse.")
                    Return newBuilding
                Case BuildingEnum.Golf_Course
                    Dim newBuilding As New GolfBuilding(bType, GetBaseCost(bType), 1, 13)
                    newBuilding.SetStat(StatEnum.Happiness, 10, 1)
                    newBuilding.SetStat(StatEnum.Health, 22, 1)
                    newBuilding.SetStat(StatEnum.Drunkenness, 10, 1)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Trees. Grass. Water. Sand. Why go to a park when you can visit a Golf Course? Enjoy the great outdoors and try not to let the beverage cart keep you down.")
                    newBuilding.SetSpecialAbility("+1 health and happiness for the first instance of each of the following in range 1: forest, plain, lake, desert.")
                    Return newBuilding
                Case BuildingEnum.Government_Bureau 'Does special ability just effect owner or does it effect all players?  Can this 10% stack with other Govt. Bureaus?
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 5)
                    newBuilding.SetStat(StatEnum.Health, 20, 1)
                    newBuilding.SetStat(StatEnum.Criminality, 10, 1)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("When navigating the Department of Red Tape, try not to get bogged down in bribes.")
                    newBuilding.SetSpecialAbility("Buildings with a Government tag cost 10% more.")
                    Return newBuilding
                Case BuildingEnum.Graveyard
                    'newBuilding.AddTag(TagEnum.Monument)
                Case BuildingEnum.Grocery_Store
                    Dim newBuilding As New GroceryBuilding(bType, GetBaseCost(bType), 2, 14)
                    newBuilding.SetStat(StatEnum.Health, 75, 1)
                    newBuilding.SetStat(StatEnum.Drunkenness, 15, 1)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.SetInfo("Grocery Stores provide access to fresh meat, vegetables, fruit, dairy, alcohol, and those boxes of almost-instant mac'n'cheese that are so addictive.")
                    newBuilding.SetSpecialAbility("The health bonus of the Grocery Store increases with the population.")
                    Return newBuilding
                Case BuildingEnum.Gym
                    Dim newBuilding As New GymBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Health, 12, 6)
                    newBuilding.SetInfo("Want to look good and feel better?  Put in some time at the Gym.")
                    newBuilding.SetSpecialAbility("Half as effective if a building with Nature tag is present.")
                    Return newBuilding
                Case BuildingEnum.Harbor
                    Dim newBuilding As New HarborBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Mobility, 12, 2)
                    newBuilding.SetStat(StatEnum.Criminality, 12, 2)
                    newBuilding.SetStat(StatEnum.Drunkenness, 20, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Harbors add color and commerce to coastal life.  Passengers travel and sightsee.  Sailors work and carouse.  Goods flow in and out, and a maybe little contraband sneaks through.")
                    newBuilding.SetSpecialAbility("Harbors only provide mobility on Coastal tiles.  The owner can expand their land to anywhere reachable over water from the harbor.  Citizens can similarly sail from the harbor to any coast.")
                    Return newBuilding
                Case BuildingEnum.Cancer_Hospital
                    Dim newBuilding As New HospitalCancerBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 10, -5)
                    newBuilding.SetStat(StatEnum.Health, 30, 5)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("The Cancer Ward specializes in providing care and comfort to all those in need.")
                    newBuilding.SetSpecialAbility("The Cancer Ward reduces the effect of outbreaks and increases the chances of preventing death caused by illness.  Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Emergency_Hospital
                    Dim newBuilding As New HospitalEmergencyBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 25, -2)
                    newBuilding.SetStat(StatEnum.Health, 30, 5)
                    newBuilding.SetStat(StatEnum.Drunkenness, 12, -3)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("Car accident? Second-degree burn? Drunken jigsaw mishap? The Emergency Ward can sort you out and sober you up.")
                    newBuilding.SetSpecialAbility("The Emergency Ward decreases the chances that your citizens will be killed in traffic accidents.  Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Geriatric_Hospital
                    Dim newBuilding As New HospitalGeriatricBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 20, -2)
                    newBuilding.SetStat(StatEnum.Health, 30, 3)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("The Geriatric Ward caters to the elderly of society - giving them a place to get the treatment they need.")
                    newBuilding.SetSpecialAbility("The Geriatric Ward boosts the chances of the elderly at having a longer life. Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Maternity_Hospital
                    Dim newBuilding As New HospitalMaternityBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 20, -2)
                    newBuilding.SetStat(StatEnum.Health, 30, 3)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("When the time comes for your bundle of joy to enter the world, let our years of dedicated service help you experience the joys of parenthood.")
                    newBuilding.SetSpecialAbility("The Maternity Ward increases the birthrate within range one of the building. Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Pediatric_Hospital
                    Dim newBuilding As New HospitalPediatricBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 20, -3)
                    newBuilding.SetStat(StatEnum.Health, 30, 4)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("The youngest members of society can get the specialized care they need at the Pediatric Ward.")
                    newBuilding.SetSpecialAbility("The Pediatric Ward boost the chances of the youths at being saved from death.  Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Research_Hospital
                    Dim newBuilding As New HospitalBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Health, 5, 10)
                    newBuilding.SetStat(StatEnum.Intelligence, 40, 5)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("At the Research Ward we don't treat the illnesses of today, we work to create the medicines of tomorrow.")
                    newBuilding.SetSpecialAbility("Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hotel
                    Dim newBuilding As New HotelBuilding(bType, GetBaseCost(bType), 3)
                    'Used to have Creativity stats. 
                    newBuilding.SetStat(StatEnum.Mobility, 20, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Treat yourself to the luxury of a night away.")
                    newBuilding.SetSpecialAbility("Citizens who stop at the Hotel will rest and recover up to half of their Mobility.")
                    Return newBuilding
                Case BuildingEnum.Laboratory
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Health, 20, -2)
                    newBuilding.SetStat(StatEnum.Intelligence, 16, 8)
                    newBuilding.SetInfo("Laboratories are on the cutting-edge of research and intellectual advancement, but the chemicals they use and experiments they perform can be unhealthy.")
                    newBuilding.SetSpecialAbility("Laboratories may produce a one-time invention that permanently changes the tile stats on its square. Labs also help with outbreak relief.")
                    Return newBuilding
                Case BuildingEnum.Land_Developer 'Come back to this one
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 5)
                    newBuilding.SetStat(StatEnum.Creativity, 10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Law_Firm
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 20, -2)
                    newBuilding.SetStat(StatEnum.Intelligence, 20, 3)
                    newBuilding.SetStat(StatEnum.Criminality, 20, -2)
                    newBuilding.SetInfo("Whether it's a parking ticket or a murder charge, let the Law Firm give you the representation you deserve.")
                    newBuilding.SetSpecialAbility("Law Firms are more effective on Swamp tiles. Criminals also may be able to beat the system and get off scot-free.")
                    Return newBuilding
                Case BuildingEnum.Library
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 14, 1)
                    newBuilding.SetStat(StatEnum.Intelligence, 15, 4)
                    newBuilding.SetStat(StatEnum.Creativity, 10, 1)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("Libraries are nice, quiet places for citizens to read, relax, and learn at their own pace.")
                    newBuilding.SetSpecialAbility("Libaries get a stat boost from Colleges and Schools on the same square.")
                    Return newBuilding
                Case BuildingEnum.Lumber_Mill
                    Dim newBuilding As New ManufacturingBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Health, 15, -2)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("Though not always the safest job, Lumber Mills provide necessary resources to any growing city.")
                    newBuilding.SetSpecialAbility("Lumber Mills start with twice as many jobs if built on a Forest tile.  The terrain they are built on has a chance of turning in a Plain tile.")
                    Return newBuilding
                Case BuildingEnum.Mall
                    Dim newBuilding As New MallBuilding(bType, GetBaseCost(bType), 5, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 35, 3)
                    newBuilding.SetStat(StatEnum.Creativity, 20, -3)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("A mall has something for nearly everyone, but the cookie-cutter nature of stores can stifle creativity and be damaging to small business owners.")
                    newBuilding.SetSpecialAbility("Odds of happiness increase with every other building on the tile.")
                    Return newBuilding
                Case BuildingEnum.Mass_Transit
                    Dim newBuilding As New MassTransitBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Mobility, 32, 5)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Mass Transit allows your citizens to travel around in ways they never would have had without it.")
                    newBuilding.SetSpecialAbility("Mass Transits within range of 3 tiles are considered adjacent to each other.  The price of Mass Transit decreases with each built.")
                    Return newBuilding
                Case BuildingEnum.Military_Base
                    Dim newBuilding As New MilitaryBaseBuilding(bType, GetBaseCost(bType), 5)
                    newBuilding.SetStat(StatEnum.Happiness, 15, -1)
                    newBuilding.SetStat(StatEnum.Health, 15, 1)
                    newBuilding.SetStat(StatEnum.Creativity, 30, -2)
                    newBuilding.SetStat(StatEnum.Drunkenness, 14, 7)
                    newBuilding.SetStat(StatEnum.Criminality, 30, -3)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.AddTag(TagEnum.Security)
                    newBuilding.SetInfo("The Military Base is all about uniformity.  The sameness might squash some of your individuality but at least you can still knock back a few beers with your brothers-in-arms.")
                    newBuilding.SetSpecialAbility("Military Bases help to reduce the effects of disasters.")
                    Return newBuilding
                Case BuildingEnum.Mine
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 18, -4)
                    newBuilding.SetStat(StatEnum.Health, 50, -3)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Mines provide you with the resources any thriving city needs to push itself to the next level.")
                    newBuilding.SetSpecialAbility("Mines give you a 10% rebate on any building that occurs within range 1; range 2 on Mountain tiles.")
                    Return newBuilding
                Case BuildingEnum.Monument
                    Dim newBuilding As New MonumentBuilding(bType, GetBaseCost(bType), 0)
                    newBuilding.SetStat(StatEnum.Happiness, 10, 1)
                    newBuilding.SetStat(StatEnum.Creativity, 16, 3)
                    newBuilding.SetInfo("A bold impressive monument makes citizens proud, happy and inspired to new creative heights... if only slightly.")
                    newBuilding.SetSpecialAbility("Buildings at the same location and with the ""Monument"" tag are 2x likelier to be visited.")
                    Return newBuilding
                Case BuildingEnum.Museum
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Intelligence, 32, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 22, 10)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.SetInfo("Museums are the best. End of story.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Observatory
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Intelligence, 20, 4)
                    newBuilding.SetInfo("Have you ever gazed up at the stars and wondered how small the world really is?  Get lost in the sheer size of the universe at the Observatory.")
                    newBuilding.SetSpecialAbility("Double the effect of the Observatory on Desert and Mountain tiles. They may also warn you of impending danger.")
                    Return newBuilding
                Case BuildingEnum.Oil_Well
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 4)
                    newBuilding.SetStat(StatEnum.Health, 35, -4)
                    newBuilding.SetStat(StatEnum.Mobility, 75, 1)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("It many not be the best for the wellbeing of you or the planet, but if you strike black gold with the Oil Well, the money will come pouring in.")
                    newBuilding.SetSpecialAbility("The Oil Well only works on Desert, Dirt, and Swamp tiles. It generates revenue for you for as long as the oil lasts.")
                    Return newBuilding
                Case BuildingEnum.Office
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 4)
                    newBuilding.SetStat(StatEnum.Creativity, 30, -2)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Offices are a stable sources of jobs but the day-to-day monotony of the cubicle farm tends to wear on the workers.")
                    newBuilding.SetSpecialAbility("It's an Office.  Isn't that enough?")
                    Return newBuilding
                Case BuildingEnum.Park 'no special ability written
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 15, 2)
                    newBuilding.SetStat(StatEnum.Health, 40, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 20, 2)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("With leafy trees and nicely-paved paths, Parks allow those out for a causal stroll to enjoy the great outdoors and admire the beauty around them.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Parking_Garage
                    Dim newBuilding As New ParkingGarageBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Creativity, 20, -1)
                    newBuilding.SetStat(StatEnum.Mobility, 40, 1)
                    newBuilding.SetStat(StatEnum.Criminality, 20, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Parking Garages have a bit of a seedy side, but provide a useful service to other buildings in the area.")
                    newBuilding.SetSpecialAbility("With the Parking Garage, there is a 33% chance that citizens will visit each building on the tile an extra time each turn.")
                    Return newBuilding
                Case BuildingEnum.Parking_Lot
                    Dim newBuilding As New ParkingLotBuilding(bType, GetBaseCost(bType), 0)
                    newBuilding.SetStat(StatEnum.Creativity, 10, -1)
                    newBuilding.SetStat(StatEnum.Mobility, 20, 1)
                    newBuilding.SetStat(StatEnum.Criminality, 10, 1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Less effective than a Garage, Parking Lots provide a place for you to park - attractive to both travelers and petty criminals.")
                    newBuilding.SetSpecialAbility("With the Parking Lot, there is a 67% chance that citizens will visit a building on the tile an additional time each turn.")
                    Return newBuilding
                Case BuildingEnum.Pharmacy
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Health, 50, 1)
                    newBuilding.SetStat(StatEnum.Drunkenness, 5, 5)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("Pharmacies give your citizens a place to stock up on perscriptions and possibly some self-medications.")
                    newBuilding.SetSpecialAbility("Pharmacies are twice as effective on Hospitals, Laboratories, and Grocery Stores.")
                    Return newBuilding
                Case BuildingEnum.Police_Station
                    Dim newBuilding As New PoliceBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 15, -1)
                    newBuilding.SetStat(StatEnum.Criminality, 50, -3)
                    newBuilding.AddTag(TagEnum.Security)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("Police Stations crack down on crime, even if every once in a while they spoil some mostly-harmless fun.")
                    newBuilding.SetSpecialAbility("Police Stations can prevent crimes within a range of 2.")
                    Return newBuilding
                Case BuildingEnum.Polling_Place
                    Dim newBuilding As New PollingBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 25, 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 25, 1)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("Polling Places let your citizens participate in the democratic process - something that always goes their way.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                'Case BuildingEnum.Post_Office
                    'newBuilding.AddTag(TagEnum.Government)
                Case BuildingEnum.Power_Plant 'skipping until variations are ready - want to write all at once
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 3)
                    newBuilding.SetInfo("")
                    'Return newBuilding
                Case BuildingEnum.Private_Security_Company
                    Dim newBuilding As New PrivateSecurityBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Criminality, 12, -5)
                    newBuilding.AddTag(TagEnum.Security)
                    newBuilding.SetInfo("Private Security Companies are excellent at keeping your citizens safe - often at the expense of the potential perpetrator.")
                    newBuilding.SetSpecialAbility("Private Security Companies can prevent crimes, but will kill whomever attempts to carry them out.")
                    Return newBuilding
                Case BuildingEnum.Ranch
                    Dim newBuilding As New RanchBuilding(bType, GetBaseCost(bType), 2, 12)
                    newBuilding.SetStat(StatEnum.Happiness, 30, 1)
                    newBuilding.SetStat(StatEnum.Health, 33, 2)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.SetInfo("Ranches give your citizens a breath of the clean air found good ol' outdoors.  There's nothing like being home on the range.")
                    newBuilding.SetSpecialAbility("Ranches give Food buildings a +1 health effect. The also expand by 2 jobs at a time if build on a Plain tile.  Ranches do not stack.")
                    Return newBuilding
                'Case BuildingEnum.Refugee_Camp
                '    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                '    newBuilding.SetStat(StatEnum.Happiness, 20, -2)
                '    newBuilding.SetStat(StatEnum.Health, 25, -2)
                '    newBuilding.SetStat(StatEnum.Criminality, 25, 3)
                '    newBuilding.SetInfo("Refugee Camps are not ideal for the general health, happiness, and crime rate of a city, but they give people in a dire situation a place where they can escape.")
                '    newBuilding.SetSpecialAbility("Refugee Camps increase the chances of immigrant arrival to the tile on which it is built.")
                '    Return newBuilding
                Case BuildingEnum.Rehab_Clinic
                    Dim newBuilding As New RehabBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Health, 10, 4)
                    newBuilding.SetStat(StatEnum.Drunkenness, 50, -2)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("Soothing, bubbling fountains. The sound of birds calling in the distance. Let yourself rest, relax, recouperate, and sober up at the Rehab Clinic.")
                    newBuilding.SetSpecialAbility("Rehab Clinics have a chance of reducing drunkenness in citizens to 0.  Only citizens with a Drunkenness value greater than 10 can be checked in.  Their Mobility will be decreased by half. More effective on Mountain and Desert tiles.")
                    Return newBuilding
                Case BuildingEnum.Restaurant
                    Dim newBuilding As New RestaurantBuilding(bType, GetBaseCost(bType), 2, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 40, 1)
                    newBuilding.SetStat(StatEnum.Health, 26, 1)
                    newBuilding.SetStat(StatEnum.Drunkenness, 5, 1)
                    newBuilding.AddTag(TagEnum.Food)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Restaurants provide a charming setting for healthy meals and promising dates.")
                    newBuilding.SetSpecialAbility("The more the population drops on a tile with a Restaurant, the more likely it is to shut down, fire all staff, and move to an adjacent tile.")
                    Return newBuilding
                Case BuildingEnum.Retirement_Home
                    Dim newBuilding As New RetirementBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 20, 4)
                    newBuilding.SetStat(StatEnum.Health, 18, 3)
                    newBuilding.SetStat(StatEnum.Mobility, 20, -3)
                    newBuilding.SetStat(StatEnum.Drunkenness, 20, -2)
                    newBuilding.SetInfo("At the Retirement Home, Seniors can spend their days kicking up their heels and enjoying life.  Their knees may have gone, but their ability to party is still very much present.")
                    newBuilding.SetSpecialAbility("Seniors at the Retirement Home do not count towards overpopulation.")
                    Return newBuilding
                Case BuildingEnum.Safe_House
                    Dim newBuilding As New SafeHouseBuilding(bType, GetBaseCost(bType), 0)
                    newBuilding.SetStat(StatEnum.Creativity, 15, -3)
                    newBuilding.SetStat(StatEnum.Mobility, 20, -3)
                    newBuilding.SetStat(StatEnum.Intelligence, 20, 3)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Whether it be protective custody or hiding from a rival crime syndicate, Safe Houses give your citizens need a place to lie low.")
                    newBuilding.SetSpecialAbility("When citizens pass through the Safe House, their Mobility has a chance of temporarily increasing by the numerical value of their Criminality.")
                    Return newBuilding
                Case BuildingEnum.School
                    Dim newBuilding As New SchoolBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 33, -1)
                    newBuilding.SetStat(StatEnum.Intelligence, 50, 4)
                    newBuilding.SetStat(StatEnum.Creativity, 33, 1)
                    newBuilding.SetInfo("Reading, writing, arithmetic, history, art, music, science... the topics seem to go on and on for students at the School.  Too bad recess is so short.")
                    newBuilding.SetSpecialAbility("The effects of the School are double on minors.")
                    Return newBuilding
                Case BuildingEnum.Shipping_Center
                    Dim newBuilding As New ShippingBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Mobility, 12, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("In the land of packages, logistics are key.  Shipping Centers have systems in place to get your parcels from one side of the city to the other.")
                    newBuilding.SetSpecialAbility("Shipping Centers double the number of jobs at Manufacturing buildings on the same tile.")
                    Return newBuilding
                Case BuildingEnum.Sidewalks
                    Dim newBuilding As New SidewalkBuilding(bType, GetBaseCost(bType), 0)
                    newBuilding.SetStat(StatEnum.Happiness, 8, 1)
                    newBuilding.SetStat(StatEnum.Mobility, 30, 1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Sidewalks make it a little easier for pedestrians to get around.")
                    newBuilding.SetSpecialAbility("Sidewalks provide a temporary Mobility boost of 3 for citizens.")
                    Return newBuilding
                Case BuildingEnum.Ski_Resort
                    Dim newBuilding As New SkiResortBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 10, 6)
                    newBuilding.SetStat(StatEnum.Health, 12, 3)
                    newBuilding.SetStat(StatEnum.Mobility, 5, 2)
                    newBuilding.SetStat(StatEnum.Drunkenness, 5, 2)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("The white, fluffy powder; the feel of the wind in your hair; the warmth of a fire in the lodge - Ski Resorts have something for everyone.")
                    newBuilding.SetSpecialAbility("Ski Resorts are only effective on Mountain tiles.")
                    Return newBuilding
                Case BuildingEnum.Skyscraper
                    Dim newBuilding As New SkyscraperBuilding(bType, GetBaseCost(bType), 6)
                    newBuilding.SetStat(StatEnum.Intelligence, 30, 1)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("Skyscrapers provide tons of jobs and a place for smart minds and ambitious career climbers to collaborate.")
                    Return newBuilding
                Case BuildingEnum.Stadium
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 4)
                    newBuilding.SetStat(StatEnum.Happiness, 24, 4)
                    newBuilding.SetStat(StatEnum.Health, 5, 5)
                    newBuilding.SetStat(StatEnum.Drunkenness, 20, 3)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Stadiums bring fun, especially when the home team wins, and a little friendly competition. The players get exercise and the audience gets entertainment and overpriced beer.")
                    Return newBuilding
                Case BuildingEnum.Steel_Mill
                    Dim newBuilding As New ManufacturingBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Health, 36, -3)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Startup_Incubator
                    Dim newBuilding As New StartupIncubatorBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 12, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 10, 5)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("")
                    Return newBuilding
                'Case BuildingEnum.Suburb

                Case BuildingEnum.Tax_Assessor
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 50, -2)
                    newBuilding.SetStat(StatEnum.Intelligence, 10, 2)
                    newBuilding.SetStat(StatEnum.Criminality, 10, 2)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Taxi_Service
                    Dim newBuilding As New TaxiBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Mobility, 8, 4)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Temp_Agency
                    Dim newBuilding As New TempAgencyBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 15, -1)
                    newBuilding.SetStat(StatEnum.Intelligence, 15, -1)
                    newBuilding.AddTag(TagEnum.Commerce)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Textile_Mill
                    Dim newBuilding As New ManufacturingBuilding(bType, GetBaseCost(bType), 2)
                    newBuilding.SetStat(StatEnum.Happiness, 22, -2)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Theater
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 2, 14)
                    newBuilding.SetStat(StatEnum.Happiness, 30, 3)
                    newBuilding.SetStat(StatEnum.Creativity, 25, 3)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("Theaters bring movies of all different types that increase happiness and often possess creative artistic merit too.")
                    Return newBuilding
                Case BuildingEnum.Think_Tank
                    Dim newBuilding As New ThinkTankBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Intelligence, 12, 7)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Toll_Booth
                    Dim newBuilding As New TollBoothBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 25, -1)
                    newBuilding.SetStat(StatEnum.Mobility, 25, -1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Tourism_Agency
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Happiness, 5, 5)
                    newBuilding.SetStat(StatEnum.Health, 5, 1)
                    newBuilding.SetStat(StatEnum.Intelligence, 5, 3)
                    newBuilding.SetStat(StatEnum.Creativity, 5, 4)
                    newBuilding.SetStat(StatEnum.Mobility, 5, 8)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.TV_Station
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 70, 2)
                    newBuilding.SetStat(StatEnum.Creativity, 50, -1)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("The TV station reaches almost house, boosting mindless contentment while subtly stifling creativity.")
                    Return newBuilding
                Case BuildingEnum.University
                    Dim newBuilding As New Building(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Intelligence, 30, 8)
                    newBuilding.SetStat(StatEnum.Creativity, 25, 3)
                    newBuilding.SetStat(StatEnum.Drunkenness, 40, 2)
                    newBuilding.SetInfo("Universities are important bastions of academic learning and discovery but are also known for their wild drunken parties.")
                    newBuilding.SetSpecialAbility("The presence of a University increases chances of employment on the square.")
                    Return newBuilding
                Case BuildingEnum.Warehouse
                    Dim newBuilding As New WarehouseBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Mobility, 20, -2)
                    newBuilding.SetStat(StatEnum.Criminality, 15, 2)
                    newBuilding.SetInfo("")
                    newBuilding.SetSpecialAbility("When buildings on adjacent locations expand, they add an additional job.")
                    Return newBuilding
                Case BuildingEnum.Welfare_Service
                    Dim newBuilding As New WelfareBuilding(bType, GetBaseCost(bType), 1)
                    newBuilding.SetStat(StatEnum.Health, 10, 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 10, -2)
                    newBuilding.SetStat(StatEnum.Creativity, 10, -2)
                    newBuilding.AddTag(TagEnum.Government)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Zoo
                    Dim newBuilding As New ZooBuilding(bType, GetBaseCost(bType), 3)
                    newBuilding.SetStat(StatEnum.Happiness, 26, 2)
                    newBuilding.SetStat(StatEnum.Health, 26, 2)
                    newBuilding.SetStat(StatEnum.Intelligence, 26, 1)
                    newBuilding.SetStat(StatEnum.Creativity, 6, 0)
                    newBuilding.AddTag(TagEnum.Nature)
                    newBuilding.AddTag(TagEnum.Entertainment)
                    newBuilding.SetInfo("")
                    newBuilding.SetSpecialAbility("+1 max effect for each unique terrain type in range 1. +3% odds for each unique terrain type you own.")
                    Return newBuilding

            End Select

            bType = -1

        Loop Until False

        Return New Building()

    End Function

#End Region

End Class

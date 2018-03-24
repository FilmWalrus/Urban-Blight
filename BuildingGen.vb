Public Class BuildingGen

#Region " Variables "

    Public Enum BuildingEnum
        Ad_Agency
        Activism_Organization
        Airport
        Ambulance_Service
        Amusement_Park
        Apartments
        Architecture_Firm
        Art_Gallery
        Bank
        Bar
        Black_Market
        Botanical_Garden
        Campsite
        Cartel
        Casino
        Church
        City_Wall
        Civic_Center
        Coffee_Shop
        College
        Community_Center
        Concert_Venue
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
        Exurb
        Factory
        Farm
        Fast_Food_Chain
        Fire_Station
        Fishery
        Freeway
        Gas_Station
        Golf_Course
        Government_Bureau
        Graveyard
        Grocery_Store
        Gym
        Harbor
        Hospital_Cancer
        Hospital_Emergency
        Hospital_Geriatric
        Hospital_Maternity
        Hospital_Pediatric
        Hospital_Research
        Hotel
        Laboratory
        Land_Developer
        Landfill
        Law_Firm
        Library
        Lottery
        Lumber_Mill
        Mall
        Mass_Transit
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
        Pharmacy
        Police_Station
        Post_Office
        Power_Plant
        Private_Security_Company
        Real_Estate_Developer
        Recycling_Center
        Refugee_Camp
        Rehab_Clinic
        Restaurant
        Retirement_Home
        School
        Shipping_Center
        Sidewalks
        Ski_Resort
        Skyscraper
        Stadium
        Startup_Incubator
        Suburb
        Taxi_Service
        Temp_Agency
        Textile_Mill
        Theater
        Think_Tank
        Toll_Booth
        Tourism_Agency
        TV_Station
        Welfare_Service
        Zoo
        BuildingCount
    End Enum

#End Region

#Region " Functions "

    Public Function CreateBuilding(ByVal bType As Integer) As Building

        Do
            If bType < 0 Then
                bType = GetRandom(0, BuildingEnum.BuildingCount - 1)
            End If

            Select Case bType

                Case BuildingEnum.Ad_Agency
                    Dim newBuilding As New Building(bType, "Ad Agency", 110, 2)
                    newBuilding.SetIntelligence(20, -2)
                    newBuilding.SetCreativity(10, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Activism_Organization
                    Dim newBuilding As New Building(bType, "Activism Organization", 105, 1)
                    newBuilding.SetHappiness(20, 1)
                    newBuilding.SetHealth(30, 4)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Airport
                    Dim newBuilding As New Building(bType, "Airport", 635, 5)
                    newBuilding.SetMobility(18, 10)
                    newBuilding.SetInfo("Airports are not used frequently by people but vastly increase mobility when visited.")
                    Return newBuilding
                Case BuildingEnum.Ambulance_Service
                    Dim newBuilding As New Building(bType, "Ambulance Service", 280, 2)
                    newBuilding.SetHealth(10, 4)
                    newBuilding.SetMobility(10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Amusement_Park
                    Dim newBuilding As New Building(bType, "Amusement Park", 515, 4)
                    newBuilding.SetHappiness(16, 7)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Apartments
                    Dim newBuilding As New Building(bType, "Apartments", 360, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Architecture_Firm
                    Dim newBuilding As New Building(bType, "Architecture Firm", 210, 2)
                    newBuilding.SetIntelligence(10, 2)
                    newBuilding.SetCreativity(18, 4)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Art_Gallery
                    Dim newBuilding As New Building(bType, "Art Gallery", 120, 1)
                    newBuilding.SetCreativity(33, 4)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Bank

                Case BuildingEnum.Bar
                    Dim newBuilding As New Building(bType, "Bar", 60, 1)
                    newBuilding.SetHappiness(30, 4)
                    newBuilding.SetDrunkenness(30, 6)
                    newBuilding.SetInfo("Bars provide a social atmosphere to cheer people up but can cause a serious upsurge in drunkenness.")
                    Return newBuilding
                Case BuildingEnum.Black_Market
                    Dim newBuilding As New Building(bType, "Black Market", 305, 2)
                    newBuilding.SetCriminality(50, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Botanical_Garden
                    Dim newBuilding As New Building(bType, "Botanical Garden", 260, 2)
                    newBuilding.SetHappiness(30, 3)
                    newBuilding.SetHealth(60, 3)
                    newBuilding.SetCreativity(20, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Campsite

                Case BuildingEnum.Cartel
                    Dim newBuilding As New Building(bType, "Cartel", 140, 3)
                    newBuilding.SetHappiness(28, 5)
                    newBuilding.SetHealth(12, -7)
                    newBuilding.SetDrunkenness(30, 10)
                    newBuilding.SetCriminality(30, 4)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Casino
                    Dim newBuilding As New Building(bType, "Casino", 395, 4)
                    newBuilding.SetHappiness(50, 3)
                    newBuilding.SetDrunkenness(50, 3)
                    newBuilding.SetCriminality(22, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Church
                    Dim newBuilding As New Building(bType, "Church", 180, 1)
                    newBuilding.SetHappiness(14, 7)
                    newBuilding.SetDrunkenness(35, -4)
                    newBuilding.SetCriminality(16, -3)
                    newBuilding.SetInfo("While not attended by everyone, churches can have a noticable effect on increasing inner peace and harshly discouraging criminality and drunkenness.")
                    Return newBuilding
                Case BuildingEnum.City_Wall
                    Dim newBuilding As New Building(bType, "City Wall", 160, 0)
                    newBuilding.SetMobility(15, -3)
                    newBuilding.SetCriminality(15, -3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Civic_Center
                    Dim newBuilding As New Building(bType, "Civic Center", 555, 7)
                    newBuilding.SetHappiness(25, 5)
                    newBuilding.SetIntelligence(25, 3)
                    newBuilding.SetCreativity(25, 3)
                    newBuilding.SetInfo("Civic centers provide a vast expanse of public buildings and shared landscapes for the free flow of commerce, art, and culture.")
                    Return newBuilding
                Case BuildingEnum.Coffee_Shop
                    Dim newBuilding As New Building(bType, "Coffee Shop", 75, 1)
                    newBuilding.SetHappiness(20, 1)
                    newBuilding.SetMobility(20, 1)
                    newBuilding.SetDrunkenness(40, -1)
                    newBuilding.SetInfo("Coffee shops provide an alternative to alcohol that still cheers one up a notch and increases vigor and on-the-run mobility.")
                    Return newBuilding
                Case BuildingEnum.College
                    Dim newBuilding As New Building(bType, "College", 370, 3)
                    newBuilding.SetIntelligence(30, 8)
                    newBuilding.SetCreativity(25, 3)
                    newBuilding.SetDrunkenness(40, 2)
                    newBuilding.SetInfo("Colleges are important bastions of intelligence and creativity but also hosts to wild drunken parties.")
                    Return newBuilding
                Case BuildingEnum.Community_Center
                    Dim newBuilding As New Building(bType, "Community Center", 210, 2)
                    newBuilding.SetHealth(10, 2)
                    newBuilding.SetHappiness(10, 2)
                    newBuilding.SetIntelligence(10, 2)
                    newBuilding.SetCreativity(10, 2)
                    newBuilding.SetMobility(10, 2)
                    newBuilding.SetDrunkenness(10, -2)
                    newBuilding.SetCriminality(10, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Concert_Venue
                    Dim newBuilding As New Building(bType, "Concert Venue", 385, 3)
                    newBuilding.SetHappiness(45, 1)
                    newBuilding.SetCreativity(55, 4)
                    newBuilding.SetDrunkenness(45, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Conservation_Area
                    Dim newBuilding As New Building(bType, "Conservation Area", 65, 0)
                    newBuilding.SetHealth(15, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Construction_Site
                    Dim newBuilding As New Building(bType, "Construction Site", 160, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Correctional_Facility
                    Dim newBuilding As New Building(bType, "Correctional Facility", 185, 2)
                    newBuilding.SetCriminality(60, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Courthouse
                    Dim newBuilding As New Building(bType, "Courthouse", 130, 2)
                    newBuilding.SetHappiness(12, -5)
                    newBuilding.SetCriminality(25, -3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Crime_Ring
                    Dim newBuilding As New Building(bType, "Crime Ring", 50, 4)
                    newBuilding.SetCriminality(14, 10)
                    newBuilding.SetInfo("A crime ring brings plenty of cheap jobs but a sharp, if rare, increase in extreme criminal behavior is likely.")
                    Return newBuilding
                Case BuildingEnum.Cult
                    Dim newBuilding As New Building(bType, "Cult", 90, 2)
                    newBuilding.SetHappiness(5, 20)
                    newBuilding.SetIntelligence(10, -6)
                    newBuilding.SetCriminality(25, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Customs_House
                    Dim newBuilding As New Building(bType, "Customs House", 255, 2)
                    newBuilding.SetCreativity(33, 3)
                    newBuilding.SetCriminality(10, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Daycare_Center
                    Dim newBuilding As New Building(bType, "Daycare Center", 90, 1)
                    newBuilding.SetHappiness(20, 5)
                    newBuilding.SetHealth(18, 2)
                    newBuilding.SetCriminality(20, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Department_Store
                    Dim newBuilding As New Building(bType, "Department Store", 115, 3)
                    newBuilding.SetHappiness(8, 1)
                    newBuilding.SetCriminality(12, -1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Detective_Agency
                    Dim newBuilding As New Building(bType, "Detective Agency", 80, 1)
                    newBuilding.SetCriminality(8, -8)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Exurb
                    Dim newBuilding As New Building(bType, "Exurb", 435, 0)
                    newBuilding.SetMobility(15, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Factory
                    Dim newBuilding As New Building(bType, "Factory", 125, 5)
                    newBuilding.SetHappiness(16, -3)
                    newBuilding.SetHealth(33, -6)
                    newBuilding.SetInfo("Factories provide many needed jobs but their monotony can be depressing and their pollution is unhealthy.")
                    Return newBuilding
                Case BuildingEnum.Farm
                    Dim newBuilding As New Building(bType, "Farm", 80, 1)
                    newBuilding.SetHealth(65, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Fast_Food_Chain
                    Dim newBuilding As New Building(bType, "Fast Food Chain", 50, 1)
                    newBuilding.SetHappiness(65, 1)
                    newBuilding.SetHealth(65, -2)
                    newBuilding.SetMobility(15, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Fire_Station
                    Dim newBuilding As New Building(bType, "Fire Station", 100, 2)
                    newBuilding.SetHealth(5, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Fishery
                    Dim newBuilding As New Building(bType, "Fishery", 165, 2)
                    newBuilding.SetHappiness(10, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Freeway
                    Dim newBuilding As New Building(bType, "Freeway", 275, 0)
                    newBuilding.SetMobility(20, 6)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Gas_Station
                    Dim newBuilding As New Building(bType, "Gas Station", 70, 1)
                    newBuilding.SetHealth(30, -1)
                    newBuilding.SetMobility(38, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Golf_Course
                    Dim newBuilding As New Building(bType, "Golf Course", 140, 1)
                    newBuilding.SetHappiness(10, 2)
                    newBuilding.SetHealth(22, 2)
                    newBuilding.SetDrunkenness(10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Government_Bureau
                    Dim newBuilding As New Building(bType, "Government Bureau", 240, 5)
                    newBuilding.SetHealth(20, 1)
                    newBuilding.SetCriminality(10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Graveyard

                Case BuildingEnum.Grocery_Store
                    Dim newBuilding As New Building(bType, "Grocery Store", 95, 2)
                    newBuilding.SetHealth(80, 1)
                    newBuilding.SetDrunkenness(15, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Gym
                    Dim newBuilding As New Building(bType, "Gym", 60, 1)
                    newBuilding.SetHappiness(15, 1)
                    newBuilding.SetHealth(12, 7)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Harbor
                Case BuildingEnum.Hospital_Cancer
                Case BuildingEnum.Hospital_Emergency
                Case BuildingEnum.Hospital_Geriatric
                Case BuildingEnum.Hospital_Maternity
                Case BuildingEnum.Hospital_Pediatric
                Case BuildingEnum.Hospital_Research
                Case BuildingEnum.Hotel
                Case BuildingEnum.Laboratory
                Case BuildingEnum.Land_Developer
                Case BuildingEnum.Landfill
                Case BuildingEnum.Law_Firm
                Case BuildingEnum.Library
                Case BuildingEnum.Lottery
                Case BuildingEnum.Lumber_Mill
                Case BuildingEnum.Mall
                Case BuildingEnum.Mass_Transit
                Case BuildingEnum.Mine
                Case BuildingEnum.Monument
                Case BuildingEnum.Military_Base
                Case BuildingEnum.Museum
                Case BuildingEnum.Observatory
                Case BuildingEnum.Oil_Well
                Case BuildingEnum.Office
                Case BuildingEnum.Park
                Case BuildingEnum.Parking_Garage
                Case BuildingEnum.Parking_Lot
                Case BuildingEnum.Pharmacy
                Case BuildingEnum.Police_Station
                Case BuildingEnum.Post_Office
                Case BuildingEnum.Power_Plant
                Case BuildingEnum.Private_Security_Company
                Case BuildingEnum.Real_Estate_Developer
                Case BuildingEnum.Recycling_Center
                Case BuildingEnum.Refugee_Camp
                Case BuildingEnum.Rehab_Clinic
                Case BuildingEnum.Restaurant
                Case BuildingEnum.Retirement_Home
                Case BuildingEnum.School
                Case BuildingEnum.Shipping_Center
                Case BuildingEnum.Sidewalks
                Case BuildingEnum.Ski_Resort
                Case BuildingEnum.Skyscraper
                Case BuildingEnum.Stadium
                Case BuildingEnum.Startup_Incubator
                Case BuildingEnum.Suburb
                Case BuildingEnum.Taxi_Service
                Case BuildingEnum.Temp_Agency
                Case BuildingEnum.Textile_Mill
                Case BuildingEnum.Theater
                Case BuildingEnum.Think_Tank
                Case BuildingEnum.Toll_Booth
                Case BuildingEnum.Tourism_Agency
                Case BuildingEnum.TV_Station
                Case BuildingEnum.Welfare_Service
                Case BuildingEnum.Zoo



                    'Case 6
                    '    '--Museum
                    '    Type = "Museum"
                    '    Cost = 150
                    '    Jobs = 1
                    '    Intelligence_adj = 2
                    '    Intelligence_odds = 32
                    '    Creativity_adj = 10
                    '    Creativity_odds = 22
                    '    Info = "Museums may be stodgy and boring to some, but they can help increase the intelligence and creativity of those occasional visitors."
                    'Case 7
                    '    '--Hospital
                    '    Type = "Hospital"
                    '    Cost = 240
                    '    Jobs = 3
                    '    Health_adj = 5
                    '    Health_odds = 35
                    '    Drunkenness_adj = -3
                    '    Drunkenness_odds = 12
                    '    Info = "Hospitals are an excellent way of ensuring the health and well-being of your citizens. The doctors advise moderation of fatty foods and strong drinks, but few listen."
                    'Case 8
                    '    '--Library
                    '    Type = "Library"
                    '    Cost = 105
                    '    Jobs = 2
                    '    Intelligence_adj = 4
                    '    Intelligence_odds = 25
                    '    Happiness_adj = 2
                    '    Happiness_odds = 14
                    '    Info = "Libraries are a nice quiet place for citizens to read, relax and learn at their own pace."
                    'Case 9
                    '    '--Mall
                    '    Type = "Mall"
                    '    Cost = 385
                    '    Jobs = 5
                    '    Happiness_adj = 3
                    '    Happiness_odds = 45
                    '    Creativity_adj = -3
                    '    Creativity_odds = 20
                    '    Info = "A mall provides a tiny bit of happiness for nearly everyone, but can tend to stifle creativity and local flavor."
                    'Case 10
                    '    '--Memorial
                    '    Type = "Monument"
                    '    Cost = 85
                    '    Jobs = 0
                    '    Happiness_adj = 3
                    '    Happiness_odds = 16
                    '    Creativity_adj = 3
                    '    Creativity_odds = 16
                    '    Info = "A bold impressive monument that makes citizen proud, happy and inspired to new creative heights... if only slightly."
                    'Case 11
                    '    '--Office
                    '    Type = "Office"
                    '    Cost = 145
                    '    Jobs = 4
                    '    Creativity_adj = -2
                    '    Creativity_odds = 30
                    '    Info = "Offices are a simple source of jobs and infrastructure that tends not to affect citizens noticably."
                    'Case 12
                    '    '--Park
                    '    Type = "Park"
                    '    Cost = 145
                    '    Jobs = 1
                    '    Happiness_adj = 3
                    '    Happiness_odds = 15
                    '    Creativity_adj = 3
                    '    Creativity_odds = 20
                    '    Health_adj = 3
                    '    Health_odds = 40
                    '    Info = "Attractive parks allow the casual stroller to engage in happy, healthy and creative exercise and meditation."
                    'Case 13
                    '    '--Police Station
                    '    Type = "Police Station"
                    '    Cost = 155
                    '    Jobs = 2
                    '    Criminality_adj = -2
                    '    Criminality_odds = 50
                    '    Happiness_adj = -1
                    '    Happiness_odds = 15
                    '    Info = "Police stations are the best way to crack down on crime, even if every once in a while they spoil some harmless fun."
                    'Case 14
                    '    '--Sidewalks
                    '    Type = "Sidewalks"
                    '    Cost = 80
                    '    Jobs = 0
                    '    Mobility_adj = 2
                    '    Mobility_odds = 40
                    '    Happiness_adj = 1
                    '    Happiness_odds = 18
                    '    Info = "Sidewalks give a little mobility to almost everyone and even a touch of happiness for friendly pedestrians."
                    'Case 15
                    '    '--Skyscaper
                    '    Type = "Skyscaper"
                    '    Cost = 275
                    '    Jobs = 6
                    '    Info = "Skyscrapers provide tons of jobs but have little other effect."
                    'Case 16
                    '    '--Stadium
                    '    Type = "Stadium"
                    '    Cost = 220
                    '    Jobs = 3
                    '    Happiness_adj = 6
                    '    Happiness_odds = 24
                    '    Health_adj = 5
                    '    Health_odds = 5
                    '    Drunkenness_adj = 3
                    '    Drunkenness_odds = 20
                    '    Info = "Stadiums can bring lots of fun and happiness, especially when the home team wins. The players get exercise and the audience gets entertainment and overpriced beer."
                    'Case 17
                    '    '--Mass Transit
                    '    Type = "Mass Transit"
                    '    Cost = 175
                    '    Jobs = 1
                    '    Mobility_adj = 5
                    '    Mobility_odds = 32
                    '    Info = "Mass Transit allows many of your citizens to gain mobility they never would have had without it."
                    'Case 18
                    '    '--Restaurant
                    '    Type = "Restaurant"
                    '    Cost = 120
                    '    Jobs = 2
                    '    Happiness_adj = 1
                    '    Happiness_odds = 40
                    '    Health_adj = 3
                    '    Health_odds = 26
                    '    Info = "Restaurants provide a charming setting for healthy meals and happy dates."
                    'Case 19
                    '    '--Theater
                    '    Type = "Theater"
                    '    Cost = 200
                    '    Jobs = 2
                    '    Happiness_adj = 4
                    '    Happiness_odds = 30
                    '    Creativity_adj = 2
                    '    Creativity_odds = 25
                    '    Info = "Theaters bring movies of all different types that increase happiness and often possess creative artistic merit too."
                    'Case 20
                    '    '--TV Station
                    '    Type = "TV Station"
                    '    Cost = 250
                    '    Jobs = 3
                    '    Happiness_adj = 2
                    '    Happiness_odds = 70
                    '    Creativity_adj = -1
                    '    Creativity_odds = 50
                    '    Info = "The TV station reaches almost house in a city, subtly boosting happiness and equally subtly stifling creativity."
                    'Case 22
                    '    '--Laboratory
                    '    Type = "Laboratory"
                    '    Cost = 205
                    '    Jobs = 2
                    '    Intelligence_adj = 8
                    '    Intelligence_odds = 16
                    '    Health_adj = -2
                    '    Health_odds = 20
                    '    Info = "Laboratories are a key source of research and intellectual advancement, but their chemicals and experiments can be unhealthy."
            End Select

            bType = -1

        Loop Until False

        Return New Building()

    End Function

#End Region
End Class

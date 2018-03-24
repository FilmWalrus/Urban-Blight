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
                    Dim newBuilding As New Building(bType, "Harbor", 80, 2)
                    newBuilding.SetMobility(12, 2)
                    newBuilding.SetCriminality(12, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Hospital_Cancer
                    Dim newBuilding As New Building(bType, "Hospital - Cancer", 270, 3)
                    newBuilding.SetHealth(30, 5)
                    newBuilding.SetInfo("Hospitals are an excellent way of ensuring the health and well-being of your citizens.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Emergency
                    Dim newBuilding As New Building(bType, "Hospital - Emergency", 240, 3)
                    newBuilding.SetHealth(30, 5)
                    newBuilding.SetDrunkenness(12, -3)
                    newBuilding.SetInfo("Hospitals are an excellent way of ensuring the health and well-being of your citizens.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Geriatric
                    Dim newBuilding As New Building(bType, "Hospital - Geriatric", 200, 3)
                    newBuilding.SetHealth(30, 3)
                    newBuilding.SetInfo("Hospitals are an excellent way of ensuring the health and well-being of your citizens.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Maternity
                    Dim newBuilding As New Building(bType, "Hospital - Maternity", 250, 3)
                    newBuilding.SetHealth(30, 3)
                    newBuilding.SetInfo("Hospitals are an excellent way of ensuring the health and well-being of your citizens.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Pediatric
                    Dim newBuilding As New Building(bType, "Hospital - Pediatric", 190, 3)
                    newBuilding.SetHealth(30, 4)
                    newBuilding.SetInfo("Hospitals are an excellent way of ensuring the health and well-being of your citizens.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Research
                    Dim newBuilding As New Building(bType, "Hospital - Research", 260, 3)
                    newBuilding.SetHealth(5, 10)
                    newBuilding.SetIntelligence(40, 5)
                    newBuilding.SetInfo("Hospitals are an excellent way of ensuring the health and well-being of your citizens.")
                    Return newBuilding
                Case BuildingEnum.Hotel
                    Dim newBuilding As New Building(bType, "Hotel", 275, 3)
                    newBuilding.SetCreativity(15, 2)
                    newBuilding.SetMobility(20, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Laboratory
                    Dim newBuilding As New Building(bType, "Laboratory", 205, 2)
                    newBuilding.SetHealth(20, -2)
                    newBuilding.SetIntelligence(16, 8)
                    newBuilding.SetInfo("Laboratories are a key source of research and intellectual advancement, but their chemicals and experiments can be unhealthy.")
                    Return newBuilding
                Case BuildingEnum.Land_Developer
                    Dim newBuilding As New Building(bType, "Land Developer", 350, 5)
                    newBuilding.SetCreativity(10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Landfill
                Case BuildingEnum.Law_Firm
                    Dim newBuilding As New Building(bType, "Law Firm", 280, 3)
                    newBuilding.SetHappiness(20, -2)
                    newBuilding.SetIntelligence(20, 3)
                    newBuilding.SetCriminality(20, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Library
                    Dim newBuilding As New Building(bType, "Library", 105, 2)
                    newBuilding.SetHappiness(14, 1)
                    newBuilding.SetIntelligence(15, 4)
                    newBuilding.SetCreativity(10, 1)
                    newBuilding.SetInfo("Libraries are a nice quiet place for citizens to read, relax and learn at their own pace.")
                    Return newBuilding
                Case BuildingEnum.Lottery

                Case BuildingEnum.Lumber_Mill
                    Dim newBuilding As New Building(bType, "Lumber Mill", 130, 2)
                    newBuilding.SetHealth(15, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Mall
                    Dim newBuilding As New Building(bType, "Mall", 385, 5)
                    newBuilding.SetHappiness(45, 3)
                    newBuilding.SetCreativity(20, -3)
                    newBuilding.SetInfo("A mall provides a tiny bit of happiness for nearly everyone, but can tend to stifle creativity and local flavor.")
                    Return newBuilding
                Case BuildingEnum.Mass_Transit
                    Dim newBuilding As New Building(bType, "Mass Transit", 175, 1)
                    newBuilding.SetMobility(32, 5)
                    newBuilding.SetInfo("Mass Transit allows many of your citizens to gain mobility they never would have had without it.")
                    Return newBuilding
                Case BuildingEnum.Mine
                    Dim newBuilding As New Building(bType, "Mine", 55, 2)
                    newBuilding.SetHappiness(10, -2)
                    newBuilding.SetHealth(50, -3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Monument
                    Dim newBuilding As New Building(bType, "Monument", 85, 0)
                    newBuilding.SetHappiness(10, 1)
                    newBuilding.SetCreativity(16, 3)
                    newBuilding.SetInfo("A bold impressive monument that makes citizen proud, happy and inspired to new creative heights... if only slightly.")
                    Return newBuilding
                Case BuildingEnum.Military_Base
                    Dim newBuilding As New Building(bType, "Military Base", 260, 5)
                    newBuilding.SetHappiness(15, -1)
                    newBuilding.SetHealth(15, 1)
                    newBuilding.SetCreativity(30, -2)
                    newBuilding.SetDrunkenness(14, 7)
                    newBuilding.SetCriminality(30, -3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Museum
                    Dim newBuilding As New Building(bType, "Museum", 150, 1)
                    newBuilding.SetIntelligence(32, 2)
                    newBuilding.SetCreativity(22, 10)
                    newBuilding.SetInfo("Museums may be stodgy and boring to some, but they can help increase the intelligence and creativity of those occasional visitors.")
                    Return newBuilding
                Case BuildingEnum.Observatory
                    Dim newBuilding As New Building(bType, "Observatory", 95, 1)
                    newBuilding.SetIntelligence(20, 4)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Oil_Well
                    Dim newBuilding As New Building(bType, "Oil Well", 445, 4)
                    newBuilding.SetHealth(35, -4)
                    newBuilding.SetMobility(75, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Office
                    Dim newBuilding As New Building(bType, "Office", 145, 4)
                    newBuilding.SetCreativity(30, -2)
                    newBuilding.SetInfo("Offices are a simple source of jobs and infrastructure that tends not to affect citizens noticably.")
                    Return newBuilding
                Case BuildingEnum.Park
                    Dim newBuilding As New Building(bType, "Park", 125, 1)
                    newBuilding.SetHappiness(15, 2)
                    newBuilding.SetHealth(40, 2)
                    newBuilding.SetCreativity(20, 2)
                    newBuilding.SetInfo("Attractive parks allow the casual stroller to engage in happy, healthy and creative exercise and meditation.")
                    Return newBuilding
                Case BuildingEnum.Parking_Garage
                    Dim newBuilding As New Building(bType, "Parking Garage", 155, 1)
                    newBuilding.SetCreativity(20, -1)
                    newBuilding.SetMobility(40, 1)
                    newBuilding.SetCriminality(20, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Parking_Lot
                    Dim newBuilding As New Building(bType, "Parking Lot", 50, 0)
                    newBuilding.SetCreativity(10, -1)
                    newBuilding.SetMobility(20, 1)
                    newBuilding.SetCriminality(10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Pharmacy
                    Dim newBuilding As New Building(bType, "Pharmacy", 70, 1)
                    newBuilding.SetHealth(50, 1)
                    newBuilding.SetDrunkenness(5, 5)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Police_Station
                    Dim newBuilding As New Building(bType, "Police Station", 155, 2)
                    newBuilding.SetHappiness(15, -1)
                    newBuilding.SetCriminality(50, -3)
                    newBuilding.SetInfo("Police stations are the best way to crack down on crime, even if every once in a while they spoil some harmless fun.")
                    Return newBuilding
                Case BuildingEnum.Post_Office

                Case BuildingEnum.Power_Plant
                    Dim newBuilding As New Building(bType, "Power Plant", 455, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Private_Security_Company
                    Dim newBuilding As New Building(bType, "Private Security Company", 300, 2)
                    newBuilding.SetCriminality(12, -5)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Real_Estate_Developer

                Case BuildingEnum.Recycling_Center

                Case BuildingEnum.Refugee_Camp
                    Dim newBuilding As New Building(bType, "Refugee Camp", 80, 1)
                    newBuilding.SetHappiness(20, -2)
                    newBuilding.SetHealth(25, -2)
                    newBuilding.SetCriminality(25, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Rehab_Clinic
                    Dim newBuilding As New Building(bType, "Rehab Clinic", 145, 1)
                    newBuilding.SetHealth(10, 4)
                    newBuilding.SetDrunkenness(50, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Restaurant
                    Dim newBuilding As New Building(bType, "Restaurant", 105, 2)
                    newBuilding.SetHappiness(40, 1)
                    newBuilding.SetHealth(26, 1)
                    newBuilding.SetDrunkenness(5, 1)
                    newBuilding.SetInfo("Restaurants provide a charming setting for healthy meals and happy dates.")
                    Return newBuilding
                Case BuildingEnum.Retirement_Home
                    Dim newBuilding As New Building(bType, "Retirement Home", 130, 1)
                    newBuilding.SetHappiness(20, 4)
                    newBuilding.SetHealth(18, 3)
                    newBuilding.SetMobility(20, -3)
                    newBuilding.SetDrunkenness(20, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.School
                    Dim newBuilding As New Building(bType, "School", 160, 2)
                    newBuilding.SetHappiness(33, -1)
                    newBuilding.SetIntelligence(50, 4)
                    newBuilding.SetCreativity(33, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Shipping_Center
                    Dim newBuilding As New Building(bType, "Shipping Center", 175, 1)
                    newBuilding.SetMobility(12, 2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Sidewalks
                    Dim newBuilding As New Building(bType, "Sidewalks", 215, 0)
                    newBuilding.SetHappiness(8, 1)
                    newBuilding.SetMobility(40, 1)
                    newBuilding.SetInfo("Sidewalks give a little mobility to almost everyone and even a touch of happiness for friendly pedestrians.")
                    Return newBuilding
                Case BuildingEnum.Ski_Resort
                    Dim newBuilding As New Building(bType, "Ski Resort", 25, 0)
                    newBuilding.SetHappiness(8, 1)
                    newBuilding.SetMobility(40, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Skyscraper
                    Dim newBuilding As New Building(bType, "Skyscraper", 325, 6)
                    newBuilding.SetIntelligence(30, 1)
                    newBuilding.SetInfo("Skyscrapers provide tons of jobs and a place for smart minds and ambitious career climbers to collaborate.")
                    Return newBuilding
                Case BuildingEnum.Stadium
                    Dim newBuilding As New Building(bType, "Stadium", 310, 4)
                    newBuilding.SetHappiness(24, 4)
                    newBuilding.SetHealth(5, 5)
                    newBuilding.SetDrunkenness(20, 3)
                    newBuilding.SetInfo("Stadiums bring fun, especially when the home team wins, and a little friendly competition. The players get exercise and the audience gets entertainment and overpriced beer.")
                    Return newBuilding
                Case BuildingEnum.Startup_Incubator
                    Dim newBuilding As New Building(bType, "Startup Incubator", 325, 1)
                    newBuilding.SetHappiness(12, 2)
                    newBuilding.SetCreativity(10, 5)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Suburb

                Case BuildingEnum.Taxi_Service

                Case BuildingEnum.Temp_Agency
                    Dim newBuilding As New Building(bType, "Temp Agency", 135, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Textile_Mill
                    Dim newBuilding As New Building(bType, "Textile Mill", 295, 2)
                    newBuilding.SetHappiness(22, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Theater
                    Dim newBuilding As New Building(bType, "Theater", 180, 2)
                    newBuilding.SetHappiness(30, 3)
                    newBuilding.SetCreativity(25, 3)
                    newBuilding.SetInfo("Theaters bring movies of all different types that increase happiness and often possess creative artistic merit too.")
                    Return newBuilding
                Case BuildingEnum.Think_Tank
                    Dim newBuilding As New Building(bType, "Think Tank", 275, 1)
                    newBuilding.SetIntelligence(12, 7)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Toll_Booth
                    Dim newBuilding As New Building(bType, "Toll Booth", 40, 1)
                    newBuilding.SetHappiness(25, -1)
                    newBuilding.SetMobility(25, -1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Tourism_Agency
                    Dim newBuilding As New Building(bType, "Tourism Agency", 70, 1)
                    newBuilding.SetHappiness(5, 5)
                    newBuilding.SetHealth(5, 1)
                    newBuilding.SetIntelligence(5, 3)
                    newBuilding.SetCreativity(5, 4)
                    newBuilding.SetMobility(5, 8)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.TV_Station
                    Dim newBuilding As New Building(bType, "TV Station", 250, 3)
                    newBuilding.SetHappiness(70, 2)
                    newBuilding.SetCreativity(50, -1)
                    newBuilding.SetInfo("The TV station reaches almost house In a city, subtly boosting happiness And equally subtly stifling creativity.")
                Case BuildingEnum.Welfare_Service
                    Dim newBuilding As New Building(bType, "Welfare Service", 100, 1)
                    newBuilding.SetHealth(10, 2)
                    newBuilding.SetIntelligence(10, -2)
                    newBuilding.SetCreativity(10, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Zoo
                    Dim newBuilding As New Building(bType, "Zoo", 410, 3)
                    newBuilding.SetHappiness(50, 3)
                    newBuilding.SetHealth(50, 3)
                    newBuilding.SetIntelligence(50, 2)
                    newBuilding.SetCreativity(30, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding

            End Select

            bType = -1

        Loop Until False

        Return New Building()

    End Function

#End Region

End Class

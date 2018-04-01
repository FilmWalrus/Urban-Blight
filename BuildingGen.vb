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
        Embassy
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
        Polling_Place
        Post_Office
        Power_Plant
        Private_Security_Company
        Real_Estate_Developer
        Recycling_Center
        Refugee_Camp
        Rehab_Clinic
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

    Public Enum TagEnum
        Ad
        Athletic
        Coffee
        Criminal
        Food
        Government
        Manufacturing
        Medical
        Monument
        Nature
        Science
        Transportation
    End Enum

#End Region

#Region " Functions "

    Public Function GetName(ByVal bType As Integer) As String
        Select Case bType
            Case BuildingEnum.Ad_Agency
                Return "Ad Agency"
            Case BuildingEnum.Activism_Organization
                Return "Activism Organization"
            Case BuildingEnum.Airport
                Return "Airport"
            Case BuildingEnum.Ambulance_Service
                Return "Ambulance Service"
            Case BuildingEnum.Amusement_Park
                Return "Amusement Park"
            Case BuildingEnum.Apartments
                Return "Apartments"
            Case BuildingEnum.Architecture_Firm
                Return "Architecture Firm"
            Case BuildingEnum.Art_Gallery
                Return "Art Gallery"
            Case BuildingEnum.Bank
                Return "Bank"
            Case BuildingEnum.Bar
                Return "Bar"
            Case BuildingEnum.Black_Market
                Return "Black Market"
            Case BuildingEnum.Botanical_Garden
                Return "Botanical Garden"
            Case BuildingEnum.Campsite
                Return "Campsite"
            Case BuildingEnum.Cartel
                Return "Cartel"
            Case BuildingEnum.Casino
                Return "Casino"
            Case BuildingEnum.Church
                Return "Church"
            Case BuildingEnum.City_Wall
                Return "City Wall"
            Case BuildingEnum.Civic_Center
                Return "Civic Center"
            Case BuildingEnum.Coffee_Shop
                Return "Coffee Shop"
            Case BuildingEnum.College
                Return "College"
            Case BuildingEnum.Community_Center
                Return "Community Center"
            Case BuildingEnum.Concert_Venue
                Return "Concert Venue"
            Case BuildingEnum.Conservation_Area
                Return "Conservation Area"
            Case BuildingEnum.Construction_Site
                Return "Construction Site"
            Case BuildingEnum.Correctional_Facility
                Return "Correctional Facility"
            Case BuildingEnum.Courthouse
                Return "Courthouse"
            Case BuildingEnum.Crime_Ring
                Return "Crime Ring"
            Case BuildingEnum.Cult
                Return "Cult"
            Case BuildingEnum.Customs_House
                Return "Customs House"
            Case BuildingEnum.Daycare_Center
                Return "Daycare Center"
            Case BuildingEnum.Department_Store
                Return "Department Store"
            Case BuildingEnum.Detective_Agency
                Return "Detective Agency"
            Case BuildingEnum.Embassy
                Return "Embassy"
            Case BuildingEnum.Exurb
                Return "Exurb"
            Case BuildingEnum.Factory
                Return "Factory"
            Case BuildingEnum.Farm
                Return "Farm"
            Case BuildingEnum.Fast_Food_Chain
                Return "Fast Food Chain"
            Case BuildingEnum.Fire_Station
                Return "Fire Station"
            Case BuildingEnum.Fishery
                Return "Fishery"
            Case BuildingEnum.Freeway
                Return "Freeway"
            Case BuildingEnum.Gas_Station
                Return "Gas Station"
            Case BuildingEnum.Golf_Course
                Return "Golf Course"
            Case BuildingEnum.Government_Bureau
                Return "Government Bureau"
            Case BuildingEnum.Graveyard
                Return "Graveyard"
            Case BuildingEnum.Grocery_Store
                Return "Grocery Store"
            Case BuildingEnum.Gym
                Return "Gym"
            Case BuildingEnum.Harbor
                Return "Harbor"
            Case BuildingEnum.Hospital_Cancer
                Return "Hospital - Cancer Ward"
            Case BuildingEnum.Hospital_Emergency
                Return "Hospital - Emergency Ward"
            Case BuildingEnum.Hospital_Geriatric
                Return "Hospital - Geriatric Ward"
            Case BuildingEnum.Hospital_Maternity
                Return "Hospital - Maternity Ward"
            Case BuildingEnum.Hospital_Pediatric
                Return "Hospital - Pediatric Ward"
            Case BuildingEnum.Hospital_Research
                Return "Hospital - Research"
            Case BuildingEnum.Hotel
                Return "Hotel"
            Case BuildingEnum.Laboratory
                Return "Laboratory"
            Case BuildingEnum.Land_Developer
                Return "Land Developer"
            Case BuildingEnum.Landfill
                Return "Landfill"
            Case BuildingEnum.Law_Firm
                Return "Law Firm"
            Case BuildingEnum.Library
                Return "Library"
            Case BuildingEnum.Lottery
                Return "Lottery"
            Case BuildingEnum.Lumber_Mill
                Return "Lumber Mill"
            Case BuildingEnum.Mall
                Return "Mall"
            Case BuildingEnum.Mass_Transit
                Return "Mass Transit"
            Case BuildingEnum.Mine
                Return "Mine"
            Case BuildingEnum.Monument
                Return "Monument"
            Case BuildingEnum.Military_Base
                Return "Military Base"
            Case BuildingEnum.Museum
                Return "Museum"
            Case BuildingEnum.Observatory
                Return "Observatory"
            Case BuildingEnum.Oil_Well
                Return "Oil Well"
            Case BuildingEnum.Office
                Return "Office"
            Case BuildingEnum.Park
                Return "Park"
            Case BuildingEnum.Parking_Garage
                Return "Parking Garage"
            Case BuildingEnum.Parking_Lot
                Return "Parking Lot"
            Case BuildingEnum.Pharmacy
                Return "Pharmacy"
            Case BuildingEnum.Police_Station
                Return "Police Station"
            Case BuildingEnum.Polling_Place
                Return "Polling Place"
            Case BuildingEnum.Post_Office
                Return "Post Office"
            Case BuildingEnum.Power_Plant
                Return "Power Plant"
            Case BuildingEnum.Private_Security_Company
                Return "Private Security Company"
            Case BuildingEnum.Real_Estate_Developer
                Return "Real Estate Developer"
            Case BuildingEnum.Recycling_Center
                Return "Recycling_Center"
            Case BuildingEnum.Refugee_Camp
                Return "Refugee Camp"
            Case BuildingEnum.Rehab_Clinic
                Return "Rehab Clinic"
            Case BuildingEnum.Restaurant
                Return "Restaurant"
            Case BuildingEnum.Retirement_Home
                Return "Retirement Home"
            Case BuildingEnum.Safe_House
                Return "Safe House"
            Case BuildingEnum.School
                Return "School"
            Case BuildingEnum.Shipping_Center
                Return "Shipping Center"
            Case BuildingEnum.Sidewalks
                Return "Sidewalks"
            Case BuildingEnum.Ski_Resort
                Return "Ski Resort"
            Case BuildingEnum.Skyscraper
                Return "Skyscraper"
            Case BuildingEnum.Stadium
                Return "Stadium"
            Case BuildingEnum.Startup_Incubator
                Return "Startup Incubator"
            Case BuildingEnum.Steel_Mill
                Return "Steel Mill"
            Case BuildingEnum.Suburb
                Return "Suburb"
            Case BuildingEnum.Taxi_Service
                Return "Taxi Service"
            Case BuildingEnum.Temp_Agency
                Return "Temp Agency"
            Case BuildingEnum.Textile_Mill
                Return "Textile Mill"
            Case BuildingEnum.Theater
                Return "Theater"
            Case BuildingEnum.Think_Tank
                Return "Think Tank"
            Case BuildingEnum.Toll_Booth
                Return "Toll Booth"
            Case BuildingEnum.Tourism_Agency
                Return "Tourism Agency"
            Case BuildingEnum.TV_Station
                Return "TV Station"
            Case BuildingEnum.Welfare_Service
                Return "Welfare Service"
            Case BuildingEnum.Zoo
                Return "Zoo"
            Case Else
                Return ""
        End Select
    End Function

    Public Function GetTagName(ByVal Tag As Integer) As String
        Select Case Tag
            Case TagEnum.Ad
                Return "Advertises"
            Case TagEnum.Athletic
                Return "Athletic"
            Case TagEnum.Coffee
                Return "Coffee"
            Case TagEnum.Criminal
                Return "Criminal"
            Case TagEnum.Food
                Return "Food"
            Case TagEnum.Government
                Return "Government"
            Case TagEnum.Manufacturing
                Return "Manufacturing"
            Case TagEnum.Medical
                Return "Medical"
            Case TagEnum.Monument
                Return "Monument"
            Case TagEnum.Nature
                Return "Nature"
            Case TagEnum.Science
                Return "Science"
            Case TagEnum.Transportation
                Return "Transportation"
            Case Else
                Return ""
        End Select
    End Function

    Public Function CreateBuilding(ByVal bType As Integer) As Building

        Do
            If bType < 0 Then
                bType = GetRandom(0, BuildingEnum.BuildingCount - 1)
            End If

            Select Case bType

                Case BuildingEnum.Ad_Agency
                    Dim newBuilding As New Building(bType, 110, 2)
                    newBuilding.SetIntelligence(20, -2)
                    newBuilding.SetCreativity(10, 2)
                    newBuilding.SetInfo("Want to boost the effects of local commercial businesses?  Hire an Ad Agency to get those creative juices flowing.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Activism_Organization 'Brian to fill in the brackets under Special Ability
                    Dim newBuilding As New Building(bType, 105, 1)
                    newBuilding.SetHappiness(20, 1)
                    newBuilding.SetHealth(30, 4)
                    newBuilding.SetInfo("It is our mission to improve the wellbeing of the community, one person at a time.")
                    newBuilding.SetSpecialAbility("Permanently bans the user from building [] ")
                    Return newBuilding
                Case BuildingEnum.Airport
                    Dim newBuilding As New AirportBuilding(bType, 560, 5)
                    newBuilding.SetMobility(18, 10)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Though a more expensive option, Airports allow for travel to far-reaching destinations.")
                    newBuilding.SetSpecialAbility("Cities containing Airports are considered adjacent to other citiies containing Airports - both yours and those belonging to other players.")
                    Return newBuilding
                Case BuildingEnum.Ambulance_Service
                    Dim newBuilding As New AmbulanceBuilding(bType, 280, 2)
                    newBuilding.SetHealth(10, 4)
                    newBuilding.SetMobility(10, 1)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("In a medical emergency, the Ambulance Service provides treatment and transport to afflicted individuals.")
                    newBuilding.SetSpecialAbility("The Ambulance Service boosts the effects of all medical buildings within a radius of two adjacent squares.")
                    Return newBuilding
                Case BuildingEnum.Amusement_Park
                    Dim newBuilding As New Building(bType, 515, 4)
                    newBuilding.SetHappiness(16, 7)
                    newBuilding.SetInfo("Remember the excitement (mixed with a little terror) that coursed through you at the top of your first roller coaster?  Relive those experiences at the Amusement Park!")
                    newBuilding.SetSpecialAbility("Positive effects are doubled for minors.")
                    Return newBuilding
                Case BuildingEnum.Apartments 'I'm also going to let you write this Special Ability.  I get what you mean but can't figure out a way to phrase it.
                    Dim newBuilding As New Building(bType, 360, 1)
                    newBuilding.SetInfo("Everyone needs a place to call home.  Apartment-living is cheap and puts you in the middle of the action.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Architecture_Firm
                    Dim newBuilding As New Building(bType, 210, 2)
                    newBuilding.SetIntelligence(10, 2)
                    newBuilding.SetCreativity(18, 4)
                    newBuilding.SetInfo("Paris. New York. Dubai. Three cities full of culture and architectural wonders.  Should your city join them?")
                    newBuilding.SetSpecialAbility("The Architecture Firm increases the chances that the 'Wipe Cards' action will cost $0.")
                    Return newBuilding
                Case BuildingEnum.Art_Gallery
                    Dim newBuilding As New Building(bType, 120, 1)
                    newBuilding.SetCreativity(33, 4)
                    newBuilding.SetInfo("Feel inspired by the works of the great paintings, drawings, sculptures, and photography that surround you at the Art Gallery.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Bank

                Case BuildingEnum.Bar
                    Dim newBuilding As New Building(bType, 60, 1)
                    newBuilding.SetHappiness(30, 4)
                    newBuilding.SetDrunkenness(30, 6)
                    newBuilding.SetInfo("Bars provide a social atmosphere to cheer people up but can result in overindulgence.")
                    newBuilding.SetSpecialAbility("Bars double the effect of Stadiums and Colleges on the same square.")
                    Return newBuilding
                Case BuildingEnum.Black_Market
                    Dim newBuilding As New Building(bType, 305, 2)
                    newBuilding.SetCriminality(50, 3)
                    newBuilding.SetInfo("Though dubious in nature, the Black Market can get you what you want.")
                    newBuilding.SetSpecialAbility("Gives owner a permanent 10% cost reduction to a randomly-selected building card (i.e. top right, top left, bottom right, bottom left).")
                    Return newBuilding
                Case BuildingEnum.Botanical_Garden
                    Dim newBuilding As New Building(bType, 260, 2)
                    newBuilding.SetHappiness(30, 3)
                    newBuilding.SetHealth(60, 3)
                    newBuilding.SetCreativity(20, 2)
                    newBuilding.SetInfo("Stretch your legs and see what nature has to offer at the Botanical Garden.  Wander around the flowers, trees, and hedges and feel the tranquility set in.")
                    newBuilding.SetSpecialAbility("Botanical Gardens are more effective if built on a Forest tile.")
                    Return newBuilding
                Case BuildingEnum.Campsite

                Case BuildingEnum.Cartel
                    Dim newBuilding As New ManufacturingBuilding(bType, 140, 3)
                    newBuilding.SetHappiness(28, 5)
                    newBuilding.SetHealth(12, -7)
                    newBuilding.SetDrunkenness(30, 10)
                    newBuilding.SetCriminality(30, 4)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("Drugs, sex, and rock 'n' roll. Or at least the drugs... The Cartel can give you the temporary euphoria you crave, but there many be a few consequences.")
                    newBuilding.SetSpecialAbility("The Cartel starts with twice the number of jobs if built on a Dirt tile.")
                    Return newBuilding
                Case BuildingEnum.Casino
                    Dim newBuilding As New Building(bType, 395, 4) 'Check my Special Ability wording on this one.
                    newBuilding.SetHappiness(50, 3)
                    newBuilding.SetDrunkenness(50, 3)
                    newBuilding.SetCriminality(22, 3)
                    newBuilding.SetInfo("Roll the dice at the Casino!  Will you hit it big and leave happy or lose it all and drown your sorrows?")
                    newBuilding.SetSpecialAbility("The player will receive a payout for each person that visits the Casino.")
                    Return newBuilding
                Case BuildingEnum.Church
                    Dim newBuilding As New ChurchBuilding(bType, 180, 1)
                    newBuilding.SetHappiness(14, 7)
                    newBuilding.SetDrunkenness(35, -4)
                    newBuilding.SetCriminality(16, -3)
                    newBuilding.SetInfo("While not attended by everyone, Churches can have a noticable effect on increasing inner peace and decreasing destructive traits.")
                    newBuilding.SetSpecialAbility("Churches have a slight chance of reducing Criminality and Drunkenness to 0.")
                    Return newBuilding
                Case BuildingEnum.City_Wall
                    Dim newBuilding As New Building(bType, 160, 0) 'Check the phrasing of Special Ability.
                    newBuilding.SetMobility(15, -3)
                    newBuilding.SetCriminality(15, -3)
                    newBuilding.SetInfo("City Walls have been used for centuries as a way to contain and protect inhabitants from unwanted intruders.")
                    newBuilding.SetSpecialAbility("For each adjacent square that is unoccupied, the City Wall will provide one job and boost odds by a multiplier of one.  For each adjacent square that is occupied by an opponent, the City Wall will provide two jobs and boost odds by a multiplier of two.")
                    Return newBuilding
                Case BuildingEnum.Civic_Center
                    Dim newBuilding As New Building(bType, 635, 8)
                    newBuilding.SetHappiness(25, 5)
                    newBuilding.SetIntelligence(25, 3)
                    newBuilding.SetCreativity(25, 3)
                    newBuilding.SetInfo("Civic Centers provide public spaces and shared landscapes for the free flow of commerce, art, and culture.")
                    newBuilding.SetSpecialAbility("The Civic Center provides the owner with increased odds of positive random events.")
                    Return newBuilding
                Case BuildingEnum.Coffee_Shop
                    Dim newBuilding As New Building(bType, 75, 1)
                    newBuilding.SetHappiness(20, 1)
                    newBuilding.SetMobility(20, 1)
                    newBuilding.SetDrunkenness(40, -1)
                    newBuilding.SetInfo("Coffee Shops perk you up and put a spring in your step. Though caffeine can be addictive, it's not as bad as alcohol.")
                    newBuilding.SetSpecialAbility("Coffee Shops are more effective on Libraries, Offices, Skyscrapers, and at Colleges.")
                    Return newBuilding
                Case BuildingEnum.College
                    Dim newBuilding As New Building(bType, 370, 3)
                    newBuilding.SetIntelligence(30, 8)
                    newBuilding.SetCreativity(25, 3)
                    newBuilding.SetDrunkenness(40, 2)
                    newBuilding.SetInfo("Colleges are important bastions of academic learning and discovery but are also known for their wild drunken parties.")
                    newBuilding.SetSpecialAbility("The presence of a College increases chances of employment on the square.")
                    Return newBuilding
                Case BuildingEnum.Community_Center
                    Dim newBuilding As New Building(bType, 210, 2)
                    newBuilding.SetHealth(10, 2)
                    newBuilding.SetHappiness(10, 2)
                    newBuilding.SetIntelligence(10, 2)
                    newBuilding.SetCreativity(10, 2)
                    newBuilding.SetMobility(10, 2)
                    newBuilding.SetDrunkenness(10, -2)
                    newBuilding.SetCriminality(10, -2)
                    newBuilding.SetInfo("Community Centers allow for people of different walks of life to come together for the benefit of society.")
                    newBuilding.SetSpecialAbility("Nullifies the negative effects of Refugee Camps, Correctional Facilities, and Rehab Clinics.  Upkeep costs are required for each visitor.")
                    Return newBuilding
                Case BuildingEnum.Concert_Venue
                    Dim newBuilding As New Building(bType, 385, 3)
                    newBuilding.SetHappiness(45, 1)
                    newBuilding.SetCreativity(55, 4)
                    newBuilding.SetDrunkenness(45, 3)
                    newBuilding.SetInfo("Whether you jam out in the mosh pit or sway in you seat, Concert Venues can allow for a crazy good time.")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Conservation_Area
                    Dim newBuilding As New Building(bType, 65, 0)
                    newBuilding.SetHealth(15, 1)
                    newBuilding.SetInfo("Enjoy the great outdoors and help save it at the same time.")
                    newBuilding.SetSpecialAbility("Conservation Areas nullify negative terrain effects of the square it is built on.")
                    Return newBuilding
                Case BuildingEnum.Construction_Site
                    Dim newBuilding As New ConstructionSiteBuilding(bType, 165, 3)
                    newBuilding.SetCriminality(30, 2)
                    newBuilding.SetInfo("")
                    newBuilding.SetInfo("Construction Sites show that a city is prosperous and growing, though the half-finished lots sometimes shelter shady deals.  How quickly the building is finished is up to the crew.")
                    newBuilding.SetSpecialAbility("In 1 to 6 turns, the Construction Site will turn into a new building.  At this point, all people employed by the Construction Site will lose their jobs.")
                    Return newBuilding
                Case BuildingEnum.Correctional_Facility 'Skipped.  Come back to later.
                    Dim newBuilding As New Building(bType, 185, 2)
                    newBuilding.SetCriminality(60, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Courthouse
                    Dim newBuilding As New Building(bType, 130, 2)
                    newBuilding.SetHappiness(12, -5)
                    newBuilding.SetIntelligence(15, 1)
                    newBuilding.SetCriminality(25, -3)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.SetInfo("It's usually a bad day if you end up there, but Courthouses serve a purpose: settling tricky matters of justice, laying down the law of the land, and providing a place to pay those pesky parking tickets.")
                    newBuilding.SetSpecialAbility("Courthouses let the owner collect double the money from fines within a two-square adjacency of the building. If the Courthouse is built on a Swamp tile, fines are tripled.")
                    Return newBuilding
                Case BuildingEnum.Crime_Ring
                    Dim newBuilding As New Building(bType, 50, 4)
                    newBuilding.SetCriminality(14, 10)
                    newBuilding.SetInfo("Crime Rings bring plenty of cheap jobs but sharp, if rare, increases in extreme criminal behavior are likely.")
                    newBuilding.SetSpecialAbility("Crimes committed on the square of the Crime Ring result in monetary kickbacks to the owner.")
                    Return newBuilding
                Case BuildingEnum.Cult
                    Dim newBuilding As New Building(bType, 90, 2) 'Skipped.  Come back later.
                    newBuilding.SetHappiness(5, 20)
                    newBuilding.SetIntelligence(10, -6)
                    newBuilding.SetCriminality(25, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Customs_House
                    Dim newBuilding As New Building(bType, 255, 2)
                    newBuilding.SetCreativity(33, 3)
                    newBuilding.SetCriminality(10, 2)
                    newBuilding.SetInfo("Imports and exports all go through the Customs House.  What new book, art piece, narcotic, or exotic animal will come in today?")
                    newBuilding.SetSpecialAbility("Customs Houses generate revenue for the owner and are more effective for each unique player with an adjacent square.")
                    Return newBuilding
                Case BuildingEnum.Daycare_Center
                    Dim newBuilding As New DayCareBuilding(bType, 90, 1) 'Daycare Centers traditionally serve younger kids who aren't going to school yet.  Maybe under 7?
                    newBuilding.SetHappiness(20, 5)
                    newBuilding.SetHealth(18, 2)
                    newBuilding.SetCriminality(20, -2)
                    newBuilding.SetInfo("Daycare Centers give the little ones a place to go while the adults are at work.  They are excellent places for children to learn interpersonal skills while they play.")
                    newBuilding.SetSpecialAbility("The Daycare Center effects only minors.")
                    Return newBuilding
                Case BuildingEnum.Department_Store
                    Dim newBuilding As New Building(bType, 115, 3)
                    newBuilding.SetHappiness(8, 1)
                    newBuilding.SetCreativity(12, -1)
                    newBuilding.SetInfo("Make errands eazy and fun at the Department Store - the one-stop shop for all your home and clothing needs.")
                    newBuilding.SetSpecialAbility("Department Stores have a small chance of opening another of their chain on an adjacent square.")
                    Return newBuilding
                Case BuildingEnum.Detective_Agency
                    Dim newBuilding As New Building(bType, 80, 1)
                    newBuilding.SetCriminality(8, -8)
                    newBuilding.SetInfo("Suspicious of a co-worker? Want to know the whereabouts of your lover? Some cases aren't meant for the police. That's where the Detective Agency comes in to play.")
                    newBuilding.SetSpecialAbility("The Detective Agency lets you see where your citizens have been and what they've done on their last turn. This only applies to citizens living on the square with the Detective Agency.")
                    Return newBuilding
                Case BuildingEnum.Embassy
                    Dim newBuilding As New Building(bType, 215, 2)
                    newBuilding.SetIntelligence(10, 8)
                    newBuilding.SetCriminality(10, 7)
                    newBuilding.SetInfo("")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Exurb
                    Dim newBuilding As New Building(bType, 435, 0) 'Check phrasing of Exurb special ability text.
                    newBuilding.SetMobility(15, 2)
                    newBuilding.SetInfo("Sometimes you just need to escape the city.  Exurbs let you get away, but still remain close to the hustle and bustle of your metropolis.")
                    newBuilding.SetSpecialAbility("After purchasing an Exurbs, the next piece of land you buy can be any unoccupied square on the board. This square will be considered adjacent to the tile where you placed the Exurb.")
                    Return newBuilding
                Case BuildingEnum.Factory
                    Dim newBuilding As New ManufacturingBuilding(bType, 125, 5)
                    newBuilding.SetHappiness(16, -3)
                    newBuilding.SetHealth(33, -6)
                    newBuilding.SetInfo("Factories provide many needed jobs but their monotony can be depressing and their pollution harmful.")
                    newBuilding.SetSpecialAbility("The effects of a Factory are worse for every 10 population sharing its square.")
                    Return newBuilding
                Case BuildingEnum.Farm
                    Dim newBuilding As New Building(bType, 80, 1)
                    newBuilding.SetHealth(65, 2)
                    newBuilding.SetInfo("Farms are the backbone of any society. They provide fresh produce and fibers to the local community.")
                    newBuilding.SetSpecialAbility("Farms double the effect of any Food buildings on the same square.  Farms expand faster on a Dirt tile.")
                    Return newBuilding
                Case BuildingEnum.Fast_Food_Chain
                    Dim newBuilding As New Building(bType, 50, 1)
                    newBuilding.SetHappiness(65, 1)
                    newBuilding.SetHealth(65, -2)
                    newBuilding.SetMobility(15, 1)
                    newBuilding.SetInfo("Quick and convenient with a side order of grease, Fast Food Chains help satisfy your food cravings and fuel you up for the day to come.")
                    newBuilding.SetSpecialAbility("Fast Food Chains have a small chance of opening another location on an adjacent square.")
                    Return newBuilding
                Case BuildingEnum.Fire_Station 'What range for the special ability?  Clarify in Special Ability text.
                    Dim newBuilding As New Building(bType, 100, 2)
                    newBuilding.SetHealth(5, 1)
                    newBuilding.SetInfo("An important part of any society, Fire Stations help stop the spread of local fires and improve general wellbeing.")
                    newBuilding.SetSpecialAbility("Fire Stations reduce the chance of arson and fires.")
                    Return newBuilding
                Case BuildingEnum.Fishery 'I can't come up with anything here.
                    Dim newBuilding As New ManufacturingBuilding(bType, 165, 2)
                    newBuilding.SetHappiness(10, -2)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Freeway
                    Dim newBuilding As New FreewayBuilding(bType, 275, 0)
                    newBuilding.SetHealth(10, -3)
                    newBuilding.SetMobility(20, 6)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Eight lanes of shimmering cement. Smooth, ""safe"", fast. Traffic jams will be a thing of the past.")
                    newBuilding.SetSpecialAbility("Upgrades all roads within a two square adjacency, regardless of owner, by one level.")
                    Return newBuilding
                Case BuildingEnum.Gas_Station
                    Dim newBuilding As New GasStationBuilding(bType, 110, 1)
                    newBuilding.SetHealth(30, -2)
                    newBuilding.SetMobility(38, 3)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Gas Stations let your citizens drive futher and explore more.  If only vehicles didn't give off pollution.")
                    newBuilding.SetSpecialAbility("When your citizens travel to the Gas Station, their mobility increases by 8. However, fires on the same square as the Gas Station are worse.")
                    Return newBuilding
                Case BuildingEnum.Golf_Course
                    Dim newBuilding As New Building(bType, 140, 1)
                    newBuilding.SetHappiness(10, 2)
                    newBuilding.SetHealth(22, 2)
                    newBuilding.SetDrunkenness(10, 1)
                    newBuilding.SetInfo("Trees. Grass. Water. Sand. Why go to a park when you can visit a Golf Course? Enjoy the great outdoors and try not to let the beverage cart keep you down.")
                    newBuilding.SetSpecialAbility("All effects of the Golf Course are doubled if built on a Plain tile.")
                    Return newBuilding
                Case BuildingEnum.Government_Bureau 'Does special ability just effect owner or does it effect all players?  Can this 10% stack with other Govt. Bureaus?
                    Dim newBuilding As New Building(bType, 240, 5)
                    newBuilding.SetHealth(20, 1)
                    newBuilding.SetCriminality(10, 1)
                    newBuilding.SetInfo("When navigating the Department of Red Tape, try not to get bogged down in bribes.")
                    newBuilding.SetSpecialAbility("Buildings with a Government tag cost 10% more.")
                    Return newBuilding
                Case BuildingEnum.Graveyard
                    'newBuilding.AddTag(TagEnum.Monument)
                Case BuildingEnum.Grocery_Store
                    Dim newBuilding As New Building(bType, 95, 2)
                    newBuilding.SetHealth(80, 1)
                    newBuilding.SetDrunkenness(15, 1)
                    newBuilding.SetInfo("Grocery Stores provide access to fresh meat, vegetables, fruit, dairy, alcohol, and those boxes of almost-instant mac'n'cheese that are so addictive.")
                    newBuilding.SetSpecialAbility("The effect of the Grocery Store increases with the population.")
                    Return newBuilding
                Case BuildingEnum.Gym 'Added Special Ability text, but it did not look final.
                    Dim newBuilding As New Building(bType, 60, 1)
                    newBuilding.SetHappiness(15, 1)
                    newBuilding.SetHealth(12, 7)
                    newBuilding.SetInfo("Want to look good and feel better?  Put in some time at the Gym.")
                    newBuilding.SetSpecialAbility("Effect boost if the Gym is on the same square as a Park or a Botanical Garden.")
                    Return newBuilding
                Case BuildingEnum.Harbor
                    Dim newBuilding As New HarborBuilding(bType, 95, 2)
                    newBuilding.SetMobility(12, 2)
                    newBuilding.SetCriminality(12, 2)
                    newBuilding.SetDrunkenness(20, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Harbors add color and commerce to coastal life.  Passengers travel and sightsee.  Sailors work and carouse.  Goods flow in and out, and a maybe little contraband sneaks through.")
                    newBuilding.SetSpecialAbility("Harbors only provide mobility on Coastal tiles.  The owner can expand their land to anywhere reachable over water from the harbor.  Citizens can similarly sail from the harbor to any coast.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Cancer
                    Dim newBuilding As New HospitalCancerBuilding(bType, 270, 3)
                    newBuilding.SetHealth(30, 5)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("The Cancer Ward specializes in providing care and comfort to all those in need.")
                    newBuilding.SetSpecialAbility("The Cancer Ward reduces the effect of outbreaks and increases the chances of preventing death caused by illness.  Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Emergency
                    Dim newBuilding As New HospitalEmergencyBuilding(bType, 240, 3)
                    newBuilding.SetHealth(30, 5)
                    newBuilding.SetDrunkenness(12, -3)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("Car accident? Second-degree burn? Drunken jigsaw mishap? The Emergency Ward can sort you out and sober you up.")
                    newBuilding.SetSpecialAbility("The Emergency Ward decreases the chances that your citizens will be killed in traffic accidents.  Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Geriatric
                    Dim newBuilding As New HospitalGeriatricBuilding(bType, 200, 3)
                    newBuilding.SetHealth(30, 3)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("The Geriatric Ward caters to the elderly of society - giving them a place to get the treatment they need.")
                    newBuilding.SetSpecialAbility("The Geriatric Ward boosts the chances of the elderly at having a longer life. Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Maternity
                    Dim newBuilding As New HospitalMaternityBuilding(bType, 250, 3)
                    newBuilding.SetHealth(30, 3)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("When the time comes for your bundle of joy to enter the world, let our years of dedicated service help you experience the joys of parenthood.")
                    newBuilding.SetSpecialAbility("The Maternity Ward increases the birthrate within range one of the building. Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Pediatric
                    Dim newBuilding As New HospitalPediatricBuilding(bType, 190, 3)
                    newBuilding.SetHealth(30, 4)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("The youngest members of society can get the specialized care they need at the Pediatric Ward.")
                    newBuilding.SetSpecialAbility("The Pediatric Ward boost the chances of the youths at being saved from death.  Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hospital_Research
                    Dim newBuilding As New HospitalBuilding(bType, 260, 3)
                    newBuilding.SetHealth(5, 10)
                    newBuilding.SetIntelligence(40, 5)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("At the Research Ward we don't treat the illnesses of today, we work to create the medicines of tomorrow.")
                    newBuilding.SetSpecialAbility("Stacking hospitals of different types on the same square boosts health.")
                    Return newBuilding
                Case BuildingEnum.Hotel
                    Dim newBuilding As New HotelBuilding(bType, 275, 3)
                    'Used to have Creativity stats. 
                    newBuilding.SetMobility(20, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Treat yourself to the luxury of a night away.")
                    newBuilding.SetSpecialAbility("Citizens who stop at the Hotel will rest and recover up to half of their Mobility.")
                    Return newBuilding
                Case BuildingEnum.Laboratory
                    Dim newBuilding As New Building(bType, 205, 2)
                    newBuilding.SetHealth(20, -2)
                    newBuilding.SetIntelligence(16, 8)
                    newBuilding.SetInfo("Laboratories are on the cutting-edge of research and intellectual advancement, but the chemicals they use and experiments they perform can be unhealthy.")
                    newBuilding.SetSpecialAbility("Laboratories may produce a one-time invention that permanently changes the tile stats on its square. Labs also help with outbreak relief.")
                    Return newBuilding
                Case BuildingEnum.Land_Developer 'Come back to this one
                    Dim newBuilding As New Building(bType, 350, 5)
                    newBuilding.SetCreativity(10, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Landfill
                Case BuildingEnum.Law_Firm
                    Dim newBuilding As New Building(bType, 280, 3)
                    newBuilding.SetHappiness(20, -2)
                    newBuilding.SetIntelligence(20, 3)
                    newBuilding.SetCriminality(20, -2)
                    newBuilding.SetInfo("Whether it's a parking ticket or a murder charge, let the Law Firm give you the representation you deserve.")
                    newBuilding.SetSpecialAbility("Law Firms are more effective on Swamp tiles. Criminals also may be able to beat the system and get off scot-free.")
                    Return newBuilding
                Case BuildingEnum.Library
                    Dim newBuilding As New Building(bType, 105, 2)
                    newBuilding.SetHappiness(14, 1)
                    newBuilding.SetIntelligence(15, 4)
                    newBuilding.SetCreativity(10, 1)
                    newBuilding.SetInfo("Libraries are nice, quiet places for citizens to read, relax, and learn at their own pace.")
                    newBuilding.SetSpecialAbility("Libaries get a stat boost from Colleges and Schools on the same square.")
                    Return newBuilding
                Case BuildingEnum.Lottery

                Case BuildingEnum.Lumber_Mill
                    Dim newBuilding As New ManufacturingBuilding(bType, 130, 2)
                    newBuilding.SetHealth(15, -2)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("Though not always the safest job, Lumber Mills provide necessary resources to any growing city.")
                    newBuilding.SetSpecialAbility("Lumber Mills start with twice as many jobs if built on a Forest tile.  The terrain they are built on has a chance of turning in a Plain tile.")
                    Return newBuilding
                Case BuildingEnum.Mall
                    Dim newBuilding As New Building(bType, 385, 5)
                    newBuilding.SetHappiness(45, 3)
                    newBuilding.SetCreativity(20, -3)
                    newBuilding.SetInfo("A mall provides a tiny bit of happiness for nearly everyone, but can tend to stifle creativity and local flavor.")
                    Return newBuilding
                Case BuildingEnum.Mass_Transit
                    Dim newBuilding As New MassTransitBuilding(bType, 175, 1)
                    newBuilding.SetMobility(32, 5)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Mass Transit allows many of your citizens to gain mobility they never would have had without it.")
                    Return newBuilding
                Case BuildingEnum.Military_Base
                    Dim newBuilding As New Building(bType, 260, 5)
                    newBuilding.SetHappiness(15, -1)
                    newBuilding.SetHealth(15, 1)
                    newBuilding.SetCreativity(30, -2)
                    newBuilding.SetDrunkenness(14, 7)
                    newBuilding.SetCriminality(30, -3)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Mine
                    Dim newBuilding As New Building(bType, 55, 2)
                    newBuilding.SetHappiness(10, -2)
                    newBuilding.SetHealth(50, -3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Monument
                    Dim newBuilding As New MonumentBuilding(bType, 85, 0)
                    newBuilding.SetHappiness(10, 1)
                    newBuilding.SetCreativity(16, 3)
                    newBuilding.SetInfo("A bold impressive monument that makes citizen proud, happy and inspired to new creative heights... if only slightly.")
                    newBuilding.SetSpecialAbility("Buildings at the same location and with the ""Monument"" tag are 2x likelier to be visited.")
                    Return newBuilding
                Case BuildingEnum.Museum
                    Dim newBuilding As New Building(bType, 150, 1)
                    newBuilding.SetIntelligence(32, 2)
                    newBuilding.SetCreativity(22, 10)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.SetInfo("Museums may be stodgy and boring to some, but they can help increase the intelligence and creativity of those occasional visitors.")
                    Return newBuilding
                Case BuildingEnum.Observatory
                    Dim newBuilding As New Building(bType, 95, 1)
                    newBuilding.SetIntelligence(20, 4)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Oil_Well
                    Dim newBuilding As New Building(bType, 445, 4)
                    newBuilding.SetHealth(35, -4)
                    newBuilding.SetMobility(75, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Office
                    Dim newBuilding As New Building(bType, 145, 4)
                    newBuilding.SetCreativity(30, -2)
                    newBuilding.SetInfo("Offices are a simple source of jobs and infrastructure that tends not to affect citizens noticably.")
                    Return newBuilding
                Case BuildingEnum.Park
                    Dim newBuilding As New Building(bType, 125, 1)
                    newBuilding.SetHappiness(15, 2)
                    newBuilding.SetHealth(40, 2)
                    newBuilding.SetCreativity(20, 2)
                    newBuilding.AddTag(TagEnum.Monument)
                    newBuilding.SetInfo("Attractive parks allow the casual stroller to engage in happy, healthy and creative exercise and meditation.")
                    Return newBuilding
                Case BuildingEnum.Parking_Garage
                    Dim newBuilding As New ParkingGarageBuilding(bType, 155, 1)
                    newBuilding.SetCreativity(20, -1)
                    newBuilding.SetMobility(40, 1)
                    newBuilding.SetCriminality(20, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Parking_Lot
                    Dim newBuilding As New ParkingLotBuilding(bType, 50, 0)
                    newBuilding.SetCreativity(10, -1)
                    newBuilding.SetMobility(20, 1)
                    newBuilding.SetCriminality(10, 1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Pharmacy
                    Dim newBuilding As New Building(bType, 70, 1)
                    newBuilding.SetHealth(50, 1)
                    newBuilding.SetDrunkenness(5, 5)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Police_Station
                    Dim newBuilding As New Building(bType, 155, 2)
                    newBuilding.SetHappiness(15, -1)
                    newBuilding.SetCriminality(50, -3)
                    newBuilding.SetInfo("Police stations are the best way to crack down on crime, even if every once in a while they spoil some harmless fun.")
                    Return newBuilding
                Case BuildingEnum.Polling_Place
                    Dim newBuilding As New Building(bType, 255, 1)
                    newBuilding.SetHappiness(25, 2)
                    newBuilding.SetIntelligence(25, 1)
                    newBuilding.SetInfo("")
                    newBuilding.SetSpecialAbility("")
                    Return newBuilding
                Case BuildingEnum.Post_Office

                Case BuildingEnum.Power_Plant
                    Dim newBuilding As New Building(bType, 455, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Private_Security_Company
                    Dim newBuilding As New Building(bType, 300, 2)
                    newBuilding.SetCriminality(12, -5)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Real_Estate_Developer

                Case BuildingEnum.Recycling_Center

                Case BuildingEnum.Refugee_Camp
                    Dim newBuilding As New Building(bType, 80, 1)
                    newBuilding.SetHappiness(20, -2)
                    newBuilding.SetHealth(25, -2)
                    newBuilding.SetCriminality(25, 3)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Rehab_Clinic
                    Dim newBuilding As New Building(bType, 145, 1)
                    newBuilding.SetHealth(10, 4)
                    newBuilding.SetDrunkenness(50, -2)
                    newBuilding.AddTag(TagEnum.Medical)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Restaurant
                    Dim newBuilding As New Building(bType, 105, 2)
                    newBuilding.SetHappiness(40, 1)
                    newBuilding.SetHealth(26, 1)
                    newBuilding.SetDrunkenness(5, 1)
                    newBuilding.SetInfo("Restaurants provide a charming setting for healthy meals and happy dates.")
                    Return newBuilding
                Case BuildingEnum.Retirement_Home
                    Dim newBuilding As New RetirementBuilding(bType, 130, 1)
                    newBuilding.SetHappiness(20, 4)
                    newBuilding.SetHealth(18, 3)
                    newBuilding.SetMobility(20, -3)
                    newBuilding.SetDrunkenness(20, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Safe_House
                    Dim newBuilding As New SafeHouseBuilding(bType, 65, 0)
                    newBuilding.SetCreativity(15, -3)
                    newBuilding.SetMobility(20, -3)
                    newBuilding.SetIntelligence(20, 3)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.School
                    Dim newBuilding As New SchoolBuilding(bType, 160, 2)
                    newBuilding.SetHappiness(33, -1)
                    newBuilding.SetIntelligence(50, 4)
                    newBuilding.SetCreativity(33, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Shipping_Center
                    Dim newBuilding As New ShippingBuilding(bType, 175, 1)
                    newBuilding.SetMobility(12, 2)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Sidewalks
                    Dim newBuilding As New SidewalkBuilding(bType, 35, 0)
                    newBuilding.SetHappiness(8, 1)
                    newBuilding.SetMobility(30, 1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("Sidewalks give a little mobility to almost everyone and even a touch of happiness for friendly pedestrians.")
                    Return newBuilding
                Case BuildingEnum.Ski_Resort
                    Dim newBuilding As New Building(bType, 215, 0)
                    newBuilding.SetHappiness(8, 1)
                    newBuilding.SetMobility(40, 1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Skyscraper
                    Dim newBuilding As New SkyscraperBuilding(bType, 325, 6)
                    newBuilding.SetIntelligence(30, 1)
                    newBuilding.SetInfo("Skyscrapers provide tons of jobs and a place for smart minds and ambitious career climbers to collaborate.")
                    Return newBuilding
                Case BuildingEnum.Stadium
                    Dim newBuilding As New Building(bType, 310, 4)
                    newBuilding.SetHappiness(24, 4)
                    newBuilding.SetHealth(5, 5)
                    newBuilding.SetDrunkenness(20, 3)
                    newBuilding.SetInfo("Stadiums bring fun, especially when the home team wins, and a little friendly competition. The players get exercise and the audience gets entertainment and overpriced beer.")
                    Return newBuilding
                Case BuildingEnum.Steel_Mill
                    Dim newBuilding As New ManufacturingBuilding(bType, 505, 3)
                    newBuilding.SetHealth(36, -3)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Startup_Incubator
                    Dim newBuilding As New StartupIncubatorBuilding(bType, 325, 1)
                    newBuilding.SetHappiness(12, 2)
                    newBuilding.SetCreativity(10, 5)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Suburb

                Case BuildingEnum.Taxi_Service
                    Dim newBuilding As New TaxiBuilding(bType, 145, 1)
                    newBuilding.SetMobility(8, 4)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Temp_Agency
                    Dim newBuilding As New Building(bType, 135, 1)
                    newBuilding.SetHappiness(15, -1)
                    newBuilding.SetIntelligence(15, -1)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Textile_Mill
                    Dim newBuilding As New ManufacturingBuilding(bType, 295, 2)
                    newBuilding.SetHappiness(22, -2)
                    newBuilding.AddTag(TagEnum.Manufacturing)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Theater
                    Dim newBuilding As New Building(bType, 180, 2)
                    newBuilding.SetHappiness(30, 3)
                    newBuilding.SetCreativity(25, 3)
                    newBuilding.SetInfo("Theaters bring movies of all different types that increase happiness and often possess creative artistic merit too.")
                    Return newBuilding
                Case BuildingEnum.Think_Tank
                    Dim newBuilding As New Building(bType, 275, 1)
                    newBuilding.SetIntelligence(12, 7)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Toll_Booth
                    Dim newBuilding As New TollBoothBuilding(bType, 40, 1)
                    newBuilding.SetHappiness(25, -1)
                    newBuilding.SetMobility(25, -1)
                    newBuilding.AddTag(TagEnum.Transportation)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Tourism_Agency
                    Dim newBuilding As New Building(bType, 70, 1)
                    newBuilding.SetHappiness(5, 5)
                    newBuilding.SetHealth(5, 1)
                    newBuilding.SetIntelligence(5, 3)
                    newBuilding.SetCreativity(5, 4)
                    newBuilding.SetMobility(5, 8)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.TV_Station
                    Dim newBuilding As New Building(bType, 250, 3)
                    newBuilding.SetHappiness(70, 2)
                    newBuilding.SetCreativity(50, -1)
                    newBuilding.SetInfo("The TV station reaches almost house In a city, subtly boosting happiness And equally subtly stifling creativity.")
                    Return newBuilding
                Case BuildingEnum.Welfare_Service
                    Dim newBuilding As New Building(bType, 100, 1)
                    newBuilding.SetHealth(10, 2)
                    newBuilding.SetIntelligence(10, -2)
                    newBuilding.SetCreativity(10, -2)
                    newBuilding.SetInfo("")
                    Return newBuilding
                Case BuildingEnum.Zoo
                    Dim newBuilding As New Building(bType, 410, 3)
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

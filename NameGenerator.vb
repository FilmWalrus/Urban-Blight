Public Class NameGenerator

#Region " Variables "
    Dim PersonTitle As New ArrayList

    Dim FirstSyllable As New ArrayList
    Dim Middle As New ArrayList
    Dim Ending As New ArrayList
    Dim Vowels As New ArrayList
    Dim VowelsPlus As New ArrayList

    Dim TownStart As New ArrayList
    Dim TownEnding As New ArrayList
    Dim TownAdjective As New ArrayList
    Dim TownPlaces As New ArrayList

#End Region

#Region " Functions "

    Public Sub FillLists()
        FillPersonLists()
        FillPlaceLists()
    End Sub

    Public Sub FillPersonLists()
        '--Cleanup
        FirstSyllable.Clear()
        Middle.Clear()
        Ending.Clear()
        Vowels.Clear()
        VowelsPlus.Clear()

        PersonTitle.Add("St. ")
        PersonTitle.Add("Sir ")
        PersonTitle.Add("Dame ")
        PersonTitle.Add("Duke ")
        PersonTitle.Add("Duchess ")
        PersonTitle.Add("Prince ")
        PersonTitle.Add("Princess ")
        PersonTitle.Add("Baron ")
        PersonTitle.Add("Baroness ")
        PersonTitle.Add("Lord ")
        PersonTitle.Add("Lady ")
        PersonTitle.Add("Mr. ")
        PersonTitle.Add("Mrs. ")
        PersonTitle.Add("Mdm. ")
        PersonTitle.Add("Dr. ")
        PersonTitle.Add("Prof. ")

        '--Vowels
        Vowels.Add("a")
        Vowels.Add("e")
        Vowels.Add("i")
        Vowels.Add("o")
        Vowels.Add("u")
        VowelsPlus.Add("ai")
        VowelsPlus.Add("ea")
        VowelsPlus.Add("au")
        VowelsPlus.Add("oa")
        VowelsPlus.Add("oi")
        VowelsPlus.Add("ou")
        VowelsPlus.Add("oo")
        VowelsPlus.Add("ee")

        '--FirstSyllable
        FirstSyllable.Add("B")
        FirstSyllable.Add("Br")
        FirstSyllable.Add("Bl")
        FirstSyllable.Add("C")
        FirstSyllable.Add("Cr")
        FirstSyllable.Add("Cl")
        FirstSyllable.Add("Ch")
        FirstSyllable.Add("Chr")
        FirstSyllable.Add("Cz")
        FirstSyllable.Add("D")
        FirstSyllable.Add("Dr")
        FirstSyllable.Add("F")
        FirstSyllable.Add("Fr")
        FirstSyllable.Add("Fl")
        FirstSyllable.Add("G")
        FirstSyllable.Add("Gr")
        FirstSyllable.Add("Gl")
        FirstSyllable.Add("Gn")
        FirstSyllable.Add("H")
        FirstSyllable.Add("J")
        FirstSyllable.Add("K")
        FirstSyllable.Add("Kl")
        FirstSyllable.Add("Kn")
        FirstSyllable.Add("Kr")
        FirstSyllable.Add("L")
        FirstSyllable.Add("M")
        FirstSyllable.Add("Mc")
        FirstSyllable.Add("Mac")
        FirstSyllable.Add("N")
        FirstSyllable.Add("O'")
        FirstSyllable.Add("P")
        FirstSyllable.Add("Ph")
        FirstSyllable.Add("Pl")
        FirstSyllable.Add("Pr")
        FirstSyllable.Add("Ph")
        FirstSyllable.Add("Qu")
        FirstSyllable.Add("R")
        FirstSyllable.Add("Rh")
        FirstSyllable.Add("S")
        FirstSyllable.Add("St")
        FirstSyllable.Add("Sh")
        FirstSyllable.Add("Sc")
        FirstSyllable.Add("Sk")
        FirstSyllable.Add("Scr")
        FirstSyllable.Add("Shr")
        FirstSyllable.Add("Sn")
        FirstSyllable.Add("Sm")
        FirstSyllable.Add("Sv")
        FirstSyllable.Add("T")
        FirstSyllable.Add("Tr")
        FirstSyllable.Add("Th")
        FirstSyllable.Add("V")
        FirstSyllable.Add("W")
        FirstSyllable.Add("Wr")
        FirstSyllable.Add("Wh")
        FirstSyllable.Add("X")
        FirstSyllable.Add("Y")
        FirstSyllable.Add("Z")

        '--Middle
        Middle.Add("b")
        Middle.Add("bb")
        Middle.Add("c")
        Middle.Add("ck")
        Middle.Add("ch")
        Middle.Add("cr")
        Middle.Add("cc")
        Middle.Add("d")
        Middle.Add("dd")
        Middle.Add("dr")
        Middle.Add("f")
        Middle.Add("ff")
        Middle.Add("fr")
        Middle.Add("g")
        Middle.Add("gr")
        Middle.Add("gg")
        Middle.Add("kk")
        Middle.Add("l")
        Middle.Add("ll")
        Middle.Add("m")
        Middle.Add("mm")
        Middle.Add("n")
        Middle.Add("nn")
        Middle.Add("p")
        Middle.Add("pp")
        Middle.Add("pr")
        Middle.Add("pl")
        Middle.Add("r")
        Middle.Add("rr")
        Middle.Add("s")
        Middle.Add("ss")
        Middle.Add("sh")
        Middle.Add("sc")
        Middle.Add("t")
        Middle.Add("tt")
        Middle.Add("th")
        Middle.Add("tr")
        Middle.Add("v")
        Middle.Add("w")

        '--Endings
        Ending.Add("b")
        Ending.Add("ck")
        Ending.Add("ch")
        Ending.Add("d")
        Ending.Add("f")
        Ending.Add("ff")
        Ending.Add("g")
        Ending.Add("ght")
        Ending.Add("ghton")
        Ending.Add("h")
        Ending.Add("ht")
        Ending.Add("k")
        Ending.Add("l")
        Ending.Add("ll")
        Ending.Add("ler")
        Ending.Add("lm")
        Ending.Add("lt")
        Ending.Add("lp")
        Ending.Add("m")
        Ending.Add("man")
        Ending.Add("m")
        Ending.Add("n")
        Ending.Add("ner")
        Ending.Add("p")
        Ending.Add("que")
        Ending.Add("r")
        Ending.Add("rt")
        Ending.Add("rn")
        Ending.Add("rch")
        Ending.Add("s")
        Ending.Add("ss")
        Ending.Add("st")
        Ending.Add("son")
        Ending.Add("sh")
        Ending.Add("t")
        Ending.Add("tt")
        Ending.Add("tch")
        Ending.Add("th")
        Ending.Add("ter")
        Ending.Add("ton")
        Ending.Add("vich")
        'Ending.Add("vna")
        Ending.Add("w")
        Ending.Add("x")
        Ending.Add("y")
        Ending.Add("z")
    End Sub

    Public Sub FillPlaceLists()
        TownStart.Add("New ")
        TownStart.Add("New ")
        TownStart.Add("Old ")
        TownStart.Add("Old ")
        TownStart.Add("Republic of ")
        TownStart.Add("Commonwealth of ")
        TownStart.Add("Monarchy of ")
        TownStart.Add("Duchy of ")
        TownStart.Add("Land of ")
        TownStart.Add("City of ")
        TownStart.Add("Rio de ")
        TownStart.Add("Casa de ")
        TownStart.Add("Mt. ")
        TownStart.Add("Fort ")


        TownAdjective.Add("Black ")
        TownAdjective.Add("White ")
        TownAdjective.Add("Crimson ")
        TownAdjective.Add("Red ")
        TownAdjective.Add("Yellow ")
        TownAdjective.Add("Golden ")
        TownAdjective.Add("Silver ")
        TownAdjective.Add("Green ")
        TownAdjective.Add("Gray ")
        TownAdjective.Add("Smoky ")
        TownAdjective.Add("Blue ")
        TownAdjective.Add("Azure ")
        TownAdjective.Add("Purple ")
        TownAdjective.Add("Prismatic ")

        TownAdjective.Add("Ruby ")
        TownAdjective.Add("Emerald ")
        TownAdjective.Add("Sapphire ")
        TownAdjective.Add("Crystal ")
        TownAdjective.Add("Pearl ")
        TownAdjective.Add("Opal ")
        TownAdjective.Add("Jade ")
        TownAdjective.Add("Onyx ")

        TownAdjective.Add("Steel ")
        TownAdjective.Add("Bronze ")
        TownAdjective.Add("Iron ")
        TownAdjective.Add("Copper ")

        TownAdjective.Add("North ")
        TownAdjective.Add("West ")
        TownAdjective.Add("South ")
        TownAdjective.Add("East ")

        TownAdjective.Add("First ")
        TownAdjective.Add("Last ")
        TownAdjective.Add("High ")
        TownAdjective.Add("Low ")

        TownAdjective.Add("Solitary ")
        TownAdjective.Add("Twin ")
        'TownAdjective.Add("Three ")
        'TownAdjective.Add("Four ")
        'TownAdjective.Add("Five ")
        'TownAdjective.Add("Six ")
        'TownAdjective.Add("Seven ")
        'TownAdjective.Add("Eight ")
        'TownAdjective.Add("Nine ")
        'TownAdjective.Add("Ten ")

        TownAdjective.Add("Dark ")
        TownAdjective.Add("Bright ")
        TownAdjective.Add("Sunny ")
        TownAdjective.Add("Rainy ")
        TownAdjective.Add("Cloudy ")
        TownAdjective.Add("Stormy ")
        TownAdjective.Add("Blustery ")
        TownAdjective.Add("Windy ")
        TownAdjective.Add("Breezy ")
        TownAdjective.Add("Chilly ")
        TownAdjective.Add("Warm ")
        TownAdjective.Add("Hot ")
        TownAdjective.Add("Broiling ")
        TownAdjective.Add("Wet ")
        TownAdjective.Add("Humid ")
        TownAdjective.Add("Dry ")
        TownAdjective.Add("Burnt ")
        TownAdjective.Add("Arid ")
        TownAdjective.Add("Cold ")
        TownAdjective.Add("Frigid ")
        TownAdjective.Add("Frozen ")

        TownAdjective.Add("Muddy ")
        TownAdjective.Add("Grassy ")
        TownAdjective.Add("Dirty ")
        TownAdjective.Add("Leafy ")
        TownAdjective.Add("Verdant ")
        TownAdjective.Add("Shady ")
        TownAdjective.Add("Jagged ")
        TownAdjective.Add("Rocky ")
        TownAdjective.Add("Stony ")
        TownAdjective.Add("Sandy ")
        TownAdjective.Add("Wooded ")
        TownAdjective.Add("Sylvan ")
        TownAdjective.Add("Foggy ")
        TownAdjective.Add("Fertile ")

        TownAdjective.Add("Fair ")
        TownAdjective.Add("Lovely ")
        TownAdjective.Add("Beautiful ")
        TownAdjective.Add("Esteemed ")
        TownAdjective.Add("Good ")
        TownAdjective.Add("Great ")
        TownAdjective.Add("Grand ")
        TownAdjective.Add("Glorious ")
        TownAdjective.Add("Majestic ")
        TownAdjective.Add("Worthy ")
        TownAdjective.Add("Lucky ")
        TownAdjective.Add("Sacred ")
        TownAdjective.Add("Holy ")
        TownAdjective.Add("Blessed ")
        TownAdjective.Add("Ancient ")
        TownAdjective.Add("Royal ")
        TownAdjective.Add("Pure ")
        TownAdjective.Add("Rich ")
        TownAdjective.Add("Brave ")
        TownAdjective.Add("True ")
        TownAdjective.Add("Festive ")

        TownAdjective.Add("Grim ")
        TownAdjective.Add("Dire ")
        TownAdjective.Add("Dread ")
        TownAdjective.Add("Quiet ")
        TownAdjective.Add("Lonely ")
        TownAdjective.Add("Lost ")
        TownAdjective.Add("Forsaken ")
        TownAdjective.Add("Unlucky ")
        TownAdjective.Add("Broken ")
        TownAdjective.Add("Split ")
        TownAdjective.Add("Dead Man's ")
        TownAdjective.Add("Doomed ")
        TownAdjective.Add("Bloody ")
        TownAdjective.Add("Blasted ")
        TownAdjective.Add("Barren ")
        TownAdjective.Add("Treacherous ")
        TownAdjective.Add("Corrupt ")
        TownAdjective.Add("Evil ")
        TownAdjective.Add("Foul ")
        TownAdjective.Add("Poor ")
        TownAdjective.Add("False ")
        TownAdjective.Add("Sunken ")
        TownAdjective.Add("Ugly ")
        TownAdjective.Add("Wicked ")
        TownAdjective.Add("Blighted ")
        TownAdjective.Add("Unworthy ")



        TownEnding.Add("ville")
        TownEnding.Add("town")
        TownEnding.Add("polis")
        TownEnding.Add("grad")
        TownEnding.Add("istan")
        TownEnding.Add("let")
        TownEnding.Add("land")
        TownEnding.Add("burg")

        '  TerrainPlain As Integer = 0
        '  TerrainDirt As Integer = 1
        '  TerrainForest As Integer = 2
        '  TerrainMountain As Integer = 3
        '  TerrainLake As Integer = 4
        '  TerrainSwamp As Integer = 5
        '  TerrainTownship As Integer = 6
        '  TerrainDesert As Integer = 7

        Dim TownPlacePlain As New ArrayList
        For i As Integer = 0 To 8
            TownPlacePlain.Add("City")
        Next
        For i As Integer = 0 To 6
            TownPlacePlain.Add("Town")
        Next
        For i As Integer = 0 To 4
            TownPlacePlain.Add("Village")
        Next
        TownPlacePlain.Add("Farm")
        TownPlacePlain.Add("Ranch")
        TownPlacePlain.Add("Garden")
        TownPlacePlain.Add("Park")
        TownPlacePlain.Add("Valley")
        TownPlacePlain.Add("Hamlet")
        TownPlacePlain.Add("Acres")
        TownPlacePlain.Add("Meadow")
        TownPlacePlain.Add("Plains")
        TownPlacePlain.Add("Field")
        TownPlacePlain.Add("Domain")
        TownPlacePlain.Add("Realm")
        TownPlacePlain.Add("Territory")
        TownPlacePlain.Add("Province")
        TownPlacePlain.Add("Manor")
        TownPlacePlain.Add("Castle")
        TownPlacePlain.Add("Keep")
        TownPlacePlain.Add("Estate")
        TownPlacePlain.Add("Heath")
        TownPlacePlain.Add("Moor")
        TownPlacePlain.Add("Pasture")
        TownPlacePlain.Add("Savannah")
        TownPlacePlain.Add("Prairie")
        TownPlacePlain.Add("Grassland")
        TownPlacePlain.Add("Shrubland")
        TownPlacePlain.Add("Feld")
        TownPlacePlain.Add("Croft")
        TownPlacePlain.Add("Crops")
        TownPlacePlain.Add("Steppe")
        TownPlacePlain.Add("Veldt")
        TownPlacePlain.Add("Tract")
        TownPlacePlain.Add("Region")
        TownPlacePlain.Add("Tower")
        TownPlacePlain.Add("Spire")
        TownPlaces.Add(TownPlacePlain)

        Dim TownPlaceDirt As New ArrayList
        TownPlaceDirt.Add("Downs")
        TownPlaceDirt.Add("Mound")
        TownPlaceDirt.Add("Hills")
        TownPlaceDirt.Add("Hill")
        TownPlaceDirt.Add("Flats")
        TownPlaceDirt.Add("Crossroads")
        TownPlaceDirt.Add("Crossing")
        TownPlaceDirt.Add("Road")
        TownPlaceDirt.Add("Lane")
        TownPlaceDirt.Add("Passage")
        TownPlaceDirt.Add("Way")
        TownPlaceDirt.Add("Byway")
        TownPlaceDirt.Add("Route")
        TownPlaceDirt.Add("Tundra")
        TownPlaceDirt.Add("Butte")
        TownPlaceDirt.Add("Knoll")
        TownPlaces.Add(TownPlaceDirt)

        Dim TownPlaceForest As New ArrayList
        TownPlaceForest.Add("Wood")
        TownPlaceForest.Add("Woods")
        TownPlaceForest.Add("Pines")
        TownPlaceForest.Add("Forest")
        TownPlaceForest.Add("Glade")
        TownPlaceForest.Add("Grotto")
        TownPlaceForest.Add("Clearing")
        TownPlaceForest.Add("Elms")
        TownPlaceForest.Add("Oaks")
        TownPlaceForest.Add("Maples")
        TownPlaceForest.Add("Birch")
        TownPlaceForest.Add("Hollow")
        TownPlaceForest.Add("Wilderness")
        TownPlaceForest.Add("Mushrooms")
        TownPlaceForest.Add("Stumps")
        TownPlaceForest.Add("Timberland")
        TownPlaceForest.Add("Copse")
        TownPlaceForest.Add("Thicket")
        TownPlaceForest.Add("Weald")
        TownPlaceForest.Add("Jungle")
        TownPlaceForest.Add("Rainforest")
        TownPlaces.Add(TownPlaceForest)

        Dim TownPlaceMountain As New ArrayList
        TownPlaceMountain.Add("Cliffs")
        TownPlaceMountain.Add("Mountain")
        TownPlaceMountain.Add("Mount")
        TownPlaceMountain.Add("Peaks")
        TownPlaceMountain.Add("Ridge")
        TownPlaceMountain.Add("View")
        TownPlaceMountain.Add("Deep")
        TownPlaceMountain.Add("Leap")
        TownPlaceMountain.Add("Caves")
        TownPlaceMountain.Add("Cavern")
        TownPlaceMountain.Add("Ravine")
        TownPlaceMountain.Add("Outlook")
        TownPlaceMountain.Add("Mine")
        TownPlaceMountain.Add("Pass")
        TownPlaceMountain.Add("Falls")
        TownPlaceMountain.Add("Chasm")
        TownPlaceMountain.Add("Snowcaps")
        TownPlaceMountain.Add("Bluff")
        TownPlaces.Add(TownPlaceMountain)

        Dim TownPlaceLake As New ArrayList
        TownPlaceLake.Add("Lake")
        TownPlaceLake.Add("Beach")
        TownPlaceLake.Add("Shore")
        TownPlaceLake.Add("Shoals")
        TownPlaceLake.Add("by the Sea")
        TownPlaceLake.Add("Docks")
        TownPlaceLake.Add("River")
        TownPlaceLake.Add("Brook")
        TownPlaceLake.Add("Creek")
        TownPlaceLake.Add("Stream")
        TownPlaceLake.Add("Coast")
        TownPlaceLake.Add("Tides")
        TownPlaceLake.Add("Harbor")
        TownPlaceLake.Add("Landing")
        TownPlaceLake.Add("Delta")
        TownPlaceLake.Add("Port")
        TownPlaceLake.Add("Dam")
        TownPlaceLake.Add("Reservoir")
        TownPlaceLake.Add("Bay")
        TownPlaceLake.Add("Lagoon")
        TownPlaceLake.Add("Pond")
        TownPlaceLake.Add("Fjord")
        TownPlaceLake.Add("Ferry")
        TownPlaceLake.Add("Cape")
        TownPlaceLake.Add("Inlet")
        TownPlaceLake.Add("Strait")
        TownPlaceLake.Add("Pools")
        TownPlaceLake.Add("Bridge")
        TownPlaces.Add(TownPlaceLake)

        Dim TownPlaceSwamp As New ArrayList
        TownPlaceSwamp.Add("Folly")
        TownPlaceSwamp.Add("Swamp")
        TownPlaceSwamp.Add("Marsh")
        TownPlaceSwamp.Add("Pit")
        TownPlaceSwamp.Add("Bog")
        TownPlaceSwamp.Add("End")
        TownPlaceSwamp.Add("Peat")
        TownPlaceSwamp.Add("Slime")
        TownPlaceSwamp.Add("Ooze")
        TownPlaceSwamp.Add("Cesspool")
        TownPlaceSwamp.Add("Dump")
        TownPlaceSwamp.Add("Basin")
        TownPlaceSwamp.Add("Everglade")
        TownPlaceSwamp.Add("Fen")
        TownPlaceSwamp.Add("Wetland")
        TownPlaceSwamp.Add("Quagmire")
        TownPlaceSwamp.Add("Morass")
        TownPlaces.Add(TownPlaceSwamp)

        Dim TownPlaceTownship As New ArrayList
        TownPlaceTownship.Add("Township")
        TownPlaceTownship.Add("Subdivision")
        TownPlaceTownship.Add("Plantation")
        TownPlaceTownship.Add("Station")
        TownPlaceTownship.Add("Stable")
        TownPlaceTownship.Add("Trading Post")
        TownPlaceTownship.Add("Market")
        TownPlaceTownship.Add("Bazaar")
        TownPlaceTownship.Add("Inn")
        TownPlaceTownship.Add("Grounds")
        TownPlaceTownship.Add("Zone")
        TownPlaceTownship.Add("Square")
        TownPlaceTownship.Add("Monastery")
        TownPlaceTownship.Add("Abbey")
        TownPlaceTownship.Add("Commune")
        TownPlaceTownship.Add("Ruins")
        TownPlaceTownship.Add("Reservation")
        TownPlaces.Add(TownPlaceTownship)

        Dim TownPlaceDesert As New ArrayList
        TownPlaceDesert.Add("Desert")
        TownPlaceDesert.Add("Sands")
        TownPlaceDesert.Add("Dunes")
        TownPlaceDesert.Add("Oasis")
        TownPlaceDesert.Add("Temple")
        TownPlaceDesert.Add("Palms")
        TownPlaceDesert.Add("Wastes")
        TownPlaceDesert.Add("Wasteland")
        TownPlaceDesert.Add("Badland")
        TownPlaces.Add(TownPlaceDesert)




    End Sub

    Public Function GenerateCityName(ByRef theLocation As CitySquare) As String
        Dim nameStr As String = ""

        '-- Front text
        If GetRandom(0, 7) = 0 Then
            nameStr += TownStart(GetRandom(0, TownStart.Count - 1))
        End If

        Dim requirePlaceName As Boolean = False
        If GetRandom(0, 2) = 0 Then
            '-- Adjective
            nameStr += TownAdjective(GetRandom(0, TownAdjective.Count - 1))
            requirePlaceName = True

            If GetRandom(0, 9) = 0 Then
                '-- Rare double adjective
                nameStr += TownAdjective(GetRandom(0, TownAdjective.Count - 1))
            End If
        Else
            '-- Title
            Dim cityEnding As Integer = GetRandom(0, 6)
            If cityEnding = 0 Then
                nameStr += PersonTitle(GetRandom(0, PersonTitle.Count - 1))
            End If

            '-- Random name
            nameStr += GeneratePersonName()

            If cityEnding = 0 Then
                '-- Posessive
                nameStr += "'s "
                requirePlaceName = True
            ElseIf cityEnding = 1 Or cityEnding = 2 Then
                '-- Classic endings
                nameStr += TownEnding(GetRandom(0, TownEnding.Count - 1))
            End If
        End If

        If GetRandom(0, 1) = 0 Or requirePlaceName Then
            If Not requirePlaceName Then
                nameStr += " "
            End If

            '-- Get place name based on terrain type
            Dim terrainIndex As Integer = theLocation.Terrain
            If theLocation.Coastal Then
                If GetRandom(0, 1) = 0 Then
                    terrainIndex = TerrainLake
                End If
            End If

            Dim placeList As ArrayList = TownPlaces(terrainIndex)
            nameStr += placeList(GetRandom(0, placeList.Count - 1))

        End If

        Return nameStr

    End Function

    Public Function GeneratePersonName() As String
        Dim nameStr As String = ""

        '--First Syllable
        If GetRandom(0, 100) <= 15 Then
            '-- Start with a vowel
            nameStr += Vowels(GetRandom(0, Vowels.Count - 1))
        Else
            nameStr += FirstSyllable(GetRandom(0, FirstSyllable.Count - 1))

            '--First Vowel
            If GetRandom(0, 2) <= 1 Then
                nameStr += Vowels(GetRandom(0, Vowels.Count - 1))
            Else
                nameStr += VowelsPlus(GetRandom(0, VowelsPlus.Count - 1))
            End If

            '-- Super short name
            If GetRandom(0, 15) = 0 Then
                Return nameStr
            End If
        End If

        '-- Capitalize first letter
        nameStr = nameStr.Substring(0, 1).ToUpper() + nameStr.Substring(1)

        '--Second Syllable
        If GetRandom(0, 1) = 0 Then
            nameStr += Middle(GetRandom(0, Middle.Count - 1))
        Else
            'Last Syllable
            nameStr += Ending(GetRandom(0, Ending.Count - 1))
            '--Final Vowel
            If GetRandom(0, 3) = 0 Then
                nameStr += Vowels(GetRandom(0, Vowels.Count - 1))
            End If
            Return nameStr
        End If

        '--Second Vowel
        If GetRandom(0, 2) <= 1 Then
            nameStr += Vowels(GetRandom(0, Vowels.Count - 1))
        Else
            nameStr += VowelsPlus(GetRandom(0, VowelsPlus.Count - 1))
        End If

        '--Third Syllable
        nameStr += Ending(GetRandom(0, Ending.Count - 1))
        '--Final Vowel
        If GetRandom(0, 3) = 0 Then
            nameStr += Vowels(GetRandom(0, Vowels.Count - 1))
        End If

        Return nameStr
    End Function

#End Region
End Class

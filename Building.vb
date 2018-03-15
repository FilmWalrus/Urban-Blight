Public Class Building

#Region " Variables "
    Public Type As String = ""
    Public Cost As Integer = 0
    Public Jobs As Integer = 0
    Public Filled As Integer = 0
    Public Success As Integer = 0
    Public Info As String = ""
    Public Location As CitySquare = Nothing

    '-- Effect Change
    Public Happiness_adj As Integer = 0
    Public Health_adj As Integer = 0 '(0 dies, higher reproduces)
    Public Employment_adj As Integer = 0 '(0 for unemployed)
    Public Intelligence_adj As Integer = 0
    Public Creativity_adj As Integer = 0
    Public Mobility_adj As Integer = 0 '(0 Is stationary)
    Public Drunkenness_adj As Integer = 0
    Public Criminality_adj As Integer = 0

    '-- Effect Odds
    Public Happiness_odds As Integer = 0
    Public Health_odds As Integer = 0 '(0 dies, higher reproduces)
    Public Employment_odds As Integer = 0 '(0 for unemployed)
    Public Intelligence_odds As Integer = 0
    Public Creativity_odds As Integer = 0
    Public Mobility_odds As Integer = 0 '(0 Is stationary)
    Public Drunkenness_odds As Integer = 0
    Public Criminality_odds As Integer = 0

    '-- Occurances of effect
    '***********
    ' Occurances will be handled for each person on the square based on total reachable from 
    ' square using roads and mobility
    '***********
    'Public Happiness_count As Integer = 0
    'Public Health_count As Integer = 0 '(0 dies, higher reproduces)
    'Public Employment_count As Integer = 0 '(0 for unemployed)
    'Public Intelligence_count As Integer = 0
    'Public Creativity_count As Integer = 0
    'Public Mobility_count As Integer = 0 '(0 Is stationary)
    'Public Drunkenness_count As Integer = 0
    'Public Criminality_count As Integer = 0


#End Region

#Region " Functions "

    Sub New(ByVal Bnum As Integer)

        If Bnum < 0 Then
            Bnum = GetRandom(0, 23)
        End If

        Bnum = GetRandom(0, 23)

        Select Case Bnum

            Case 0
                '--Airport
                Type = "Airport"
                Cost = 325
                Jobs = 3
                Mobility_adj = 15
                Mobility_odds = 10
                Info = "Airports are not used frequently by people but vastly increase mobility when visited."
            Case 1
                '--Bar
                Type = "Bar"
                Cost = 60
                Jobs = 1
                Happiness_adj = 4
                Happiness_odds = 30
                Drunkenness_adj = 6
                Drunkenness_odds = 26
                Info = "Bars provide a social atmosphere to cheer people up but can cause a serious upsurge in drunkenness."
            Case 2
                '--Church
                Type = "Church"
                Cost = 180
                Jobs = 1
                Happiness_adj = 7
                Happiness_odds = 14
                Criminality_adj = -3
                Criminality_odds = 16
                Drunkenness_adj = -4
                Drunkenness_odds = 35
                Info = "While not attended by everyone, churches can have a noticable effect on increasing inner peace and harshly discouraging criminality and drunkenness."
            Case 3
                '--College
                Type = "College"
                Cost = 320
                Jobs = 2
                Drunkenness_adj = 2
                Drunkenness_odds = 40
                Intelligence_adj = 6
                Intelligence_odds = 30
                Creativity_adj = 3
                Creativity_odds = 25
                Info = "Colleges are important bastions of intelligence and creativity but also subject to wild drunken parties."
            Case 4
                '--Crime Ring
                Type = "Crime Ring"
                Cost = 50
                Jobs = 4
                Criminality_adj = 10
                Criminality_odds = 14
                Info = "A crime ring brings plenty of cheap jobs but a sharp, if rare, increase in extreme criminal behavior is likely."
            Case 5
                '--Factory
                Type = "Factory"
                Cost = 125
                Jobs = 5
                Health_adj = -3
                Health_odds = 20
                Happiness_adj = -2
                Happiness_odds = 16
                Info = "Factories provide many needed jobs but their monotony can be depressing and their pollution is unhealthy."
            Case 6
                '--Museum
                Type = "Museum"
                Cost = 150
                Jobs = 1
                Intelligence_adj = 2
                Intelligence_odds = 32
                Creativity_adj = 10
                Creativity_odds = 22
                Info = "Museums may be stodgy and boring to some, but they can help increase the intelligence and creativity of those occasional visitors."
            Case 7
                '--Hospital
                Type = "Hospital"
                Cost = 240
                Jobs = 3
                Health_adj = 5
                Health_odds = 35
                Drunkenness_adj = -3
                Drunkenness_odds = 12
                Info = "Hospitals are an excellent way of ensuring the health and well-being of your citizens. The doctors advise moderation of fatty foods and strong drinks, but few listen."
            Case 8
                '--Library
                Type = "Library"
                Cost = 105
                Jobs = 2
                Intelligence_adj = 4
                Intelligence_odds = 25
                Happiness_adj = 2
                Happiness_odds = 14
                Info = "Libraries are a nice quiet place for citizens to read, relax and learn at their own pace."
            Case 9
                '--Mall
                Type = "Mall"
                Cost = 385
                Jobs = 5
                Happiness_adj = 3
                Happiness_odds = 45
                Creativity_adj = -3
                Creativity_odds = 20
                Info = "A mall provides a tiny bit of happiness for nearly everyone, but can tend to stifle creativity and local flavor."
            Case 10
                '--Memorial
                Type = "Monument"
                Cost = 85
                Jobs = 0
                Happiness_adj = 3
                Happiness_odds = 16
                Creativity_adj = 3
                Creativity_odds = 16
                Info = "A bold impressive monument that makes citizen proud, happy and inspired to new creative heights... if only slightly."
            Case 11
                '--Office
                Type = "Office"
                Cost = 145
                Jobs = 4
                Creativity_adj = -2
                Creativity_odds = 30
                Info = "Offices are a simple source of jobs and infrastructure that tends not to affect citizens noticably."
            Case 12
                '--Park
                Type = "Park"
                Cost = 145
                Jobs = 1
                Happiness_adj = 3
                Happiness_odds = 15
                Creativity_adj = 3
                Creativity_odds = 20
                Health_adj = 3
                Health_odds = 40
                Info = "Attractive parks allow the casual stroller to engage in happy, healthy and creative exercise and meditation."
            Case 13
                '--Police Station
                Type = "Police Station"
                Cost = 155
                Jobs = 2
                Criminality_adj = -2
                Criminality_odds = 50
                Happiness_adj = -1
                Happiness_odds = 15
                Info = "Police stations are the best way to crack down on crime, even if every once in a while they spoil some harmless fun."
            Case 14
                '--Sidewalks
                Type = "Sidewalks"
                Cost = 80
                Jobs = 0
                Mobility_adj = 2
                Mobility_odds = 40
                Happiness_adj = 1
                Happiness_odds = 18
                Info = "Sidewalks give a little mobility to almost everyone and even a touch of happiness for friendly pedestrians."
            Case 15
                '--Skyscaper
                Type = "Skyscaper"
                Cost = 275
                Jobs = 6
                Info = "Skyscrapers provide tons of jobs but have little other effect."
            Case 16
                '--Stadium
                Type = "Stadium"
                Cost = 220
                Jobs = 3
                Happiness_adj = 6
                Happiness_odds = 24
                Health_adj = 5
                Health_odds = 5
                Drunkenness_adj = 3
                Drunkenness_odds = 20
                Info = "Stadiums can bring lots of fun and happiness, especially when the home team wins. The players get exercise and the audience gets entertainment and overpriced beer."
            Case 17
                '--Mass Transit
                Type = "Mass Transit"
                Cost = 175
                Jobs = 1
                Mobility_adj = 5
                Mobility_odds = 32
                Info = "Mass Transit allows many of your citizens to gain mobility they never would have had without it."
            Case 18
                '--Restaurant
                Type = "Restaurant"
                Cost = 120
                Jobs = 2
                Happiness_adj = 1
                Happiness_odds = 40
                Health_adj = 3
                Health_odds = 26
                Info = "Restaurants provide a charming setting for healthy meals and happy dates."
            Case 19
                '--Theater
                Type = "Theater"
                Cost = 200
                Jobs = 2
                Happiness_adj = 4
                Happiness_odds = 30
                Creativity_adj = 2
                Creativity_odds = 25
                Info = "Theaters bring movies of all different types that increase happiness and often possess creative artistic merit too."
            Case 20
                '--TV Station
                Type = "TV Station"
                Cost = 250
                Jobs = 3
                Happiness_adj = 2
                Happiness_odds = 70
                Creativity_adj = -1
                Creativity_odds = 50
                Info = "The TV station reaches almost house in a city, subtly boosting happiness and equally subtly stifling creativity."
            Case 21
                '--Coffee Shop
                Type = "Coffee Shop"
                Cost = 105
                Jobs = 1
                Happiness_adj = 2
                Happiness_odds = 20
                Mobility_adj = 1
                Mobility_odds = 20
                Drunkenness_adj = -2
                Drunkenness_odds = 40
                Info = "Coffee shops provide an alternative to alcohol that still cheers one up a notch and increases vigor and on-the-run mobility."
            Case 22
                '--Laboratory
                Type = "Laboratory"
                Cost = 205
                Jobs = 2
                Intelligence_adj = 8
                Intelligence_odds = 16
                Health_adj = -2
                Health_odds = 20
                Info = "Laboratories are a key source of research and intellectual advancement, but their chemicals and experiments can be unhealthy."
            Case 23
                '--Civic Center
                Type = "Civic Center"
                Cost = 505
                Jobs = 7
                Happiness_adj = 5
                Happiness_odds = 25
                Intelligence_adj = 3
                Intelligence_odds = 25
                Creativity_adj = 3
                Creativity_odds = 25
                Criminality_adj = -2
                Criminality_odds = 15
                Info = "Civic centers provide a vast expanse of public buildings and marketplaces for the free flow of cheerful commerce, progressive law, creative art and intellectual ideas."
        End Select

    End Sub

    Public Function GetNameAndAddress() As String
        Return Type.ToString() + " at " + Location.GetName()
    End Function

    Public Function AffectPerson(ByRef thePerson As Person) As Person
        If Happiness_odds > 0 Then
            If GetRandom(0, 100) <= Happiness_odds Then
                If Happiness_adj < 0 Then
                    thePerson.Happiness -= GetRandom(Happiness_adj, -1)
                Else
                    thePerson.Happiness += GetRandom(1, Happiness_adj)
                End If
            End If
        End If
        If Health_odds > 0 Then
            If GetRandom(0, 100) <= Health_odds Then
                If Health_adj < 0 Then
                    thePerson.Health += GetRandom(Health_adj, -1)
                Else
                    thePerson.Health += GetRandom(1, Health_adj)
                End If
            End If
        End If
        If Employment_odds > 0 Then
            If GetRandom(0, 100) <= Employment_odds Then
                thePerson.Employment += GetRandom(1, Employment_adj)
            End If
        End If
        If Intelligence_odds > 0 Then
            If GetRandom(0, 100) <= Intelligence_odds Then
                If Intelligence_adj < 0 Then
                    thePerson.Intelligence += GetRandom(Intelligence_adj, -1)
                Else
                    thePerson.Intelligence += GetRandom(1, Intelligence_adj)
                End If
            End If
        End If
        If Creativity_odds > 0 Then
            If GetRandom(0, 100) <= Creativity_odds Then
                If Creativity_adj < 0 Then
                    thePerson.Creativity += GetRandom(Creativity_adj, -1)
                Else
                    thePerson.Creativity += GetRandom(1, Creativity_adj)
                End If
            End If
        End If
        If Mobility_odds > 0 Then
            If GetRandom(0, 100) <= Mobility_odds Then
                thePerson.Mobility += GetRandom(1, Mobility_adj)
            End If
        End If
        If Drunkenness_odds > 0 Then
            If GetRandom(0, 100) <= Drunkenness_odds Then
                If Drunkenness_adj < 0 Then
                    thePerson.Drunkenness += GetRandom(Drunkenness_adj, -1)
                Else
                    thePerson.Drunkenness += GetRandom(1, Drunkenness_adj)
                End If
            End If
        End If
        If Criminality_odds > 0 Then
            If GetRandom(0, 100) <= Criminality_odds Then
                If Criminality_adj < 0 Then
                    thePerson.Criminality += GetRandom(Criminality_adj, -1)
                Else
                    thePerson.Criminality += GetRandom(1, Criminality_adj)
                End If
            End If
        End If
        Return thePerson
    End Function

    Public Function Hiring() As Boolean
        If Filled < Jobs Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

End Class

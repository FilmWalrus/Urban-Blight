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
    Public Function AffectPerson(ByVal thePerson As Person) As Person
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

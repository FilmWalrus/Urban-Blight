Public Class Person

#Region " Variables "
    Public Name As String = ""
    Public JobLocation As New Point(-1, -1)
    Public JobIndex As Integer = -1

    '-- Traits
    Public Happiness As Integer = 0
    Public Health As Integer = 0 '(0 dies, higher reproduces)
    Public Employment As Integer = 0 '(0 for unemployed)
    Public Intelligence As Integer = 0
    Public Creativity As Integer = 0
    Public Mobility As Integer = 0 '(0 Is stationary)
    Public Drunkenness As Integer = 0
    Public Criminality As Integer = 0
    Public Age As Integer = 1

    '-- Mark
    Public TouchedKey As Integer = 0
#End Region

#Region " New "
    Public Sub New()
        '-- Create randomly
        Name = Namer.GenerateName()
        Happiness = GetRandom(25, 35)
        Health = GetRandom(40, 50)
        Employment = 0
        Intelligence = GetRandom(3, 10)
        Creativity = GetRandom(3, 10)
        Mobility = GetRandom(0, 5)
        Drunkenness = 0
        Criminality = GetRandom(0, 10)
        Age = 1
    End Sub

    Public Sub New(ByVal Parent As Person)
        '-- Create randomly with heriditary influence
        Name = Namer.GenerateName()
        Happiness = GetRandom(20, 30) + (Parent.Happiness / 9.0)
        Health = GetRandom(Math.Min(40, Parent.Health), 50)
        Employment = 0
        Intelligence = GetRandom(3, 8 + (Parent.Intelligence / 16.5))
        Creativity = GetRandom(3, 8 + (Parent.Creativity / 16.5))
        Mobility = GetRandom(0, 5)
        Drunkenness = GetRandom(0, Math.Max(12, Parent.Drunkenness))
        Criminality = GetRandom(0, 8 + (Parent.Criminality / 10.0))
        Age = 1
    End Sub

#End Region

#Region " Manipulate "
    Sub Cap()
        '-- Tops
        If Happiness > 100 Then
            Happiness = 100
        End If
        If Health > 100 Then
            Health = 100
        End If
        If Employment > 100 Then
            Employment = 100
        End If
        If Intelligence > 100 Then
            Intelligence = 100
        End If
        If Creativity > 100 Then
            Creativity = 100
        End If
        If Mobility > 100 Then
            Mobility = 100
        End If
        If Drunkenness > 100 Then
            'Death from alcohol poisoning
            Drunkenness = 100
        End If
        If Criminality > 100 Then
            Criminality = 100
        End If

        '-- Bottoms
        If Happiness < 0 Then
            Happiness = 0
        End If
        If Health < 0 Then
            'Death from sickness
            Health = 0
        End If
        If Employment < 0 Then
            Employment = 0
        End If
        If Intelligence < 0 Then
            Intelligence = 0
        End If
        If Creativity < 0 Then
            Creativity = 0
        End If
        If Mobility < 0 Then
            Mobility = 0
        End If
        If Drunkenness < 0 Then
            Drunkenness = 0
        End If
        If Criminality < 0 Then
            Criminality = 0
        End If
    End Sub

    Public Function UpdateInternal(ByVal thePop As Integer, ByVal theTerrain As Integer, ByVal theRoad As Integer)
        Dim maxBonus, maxLoss As Double

        '--Health
        If Health < 15 Then
            '-- Deteriation
            Health -= 1
            If Employment = 0 Then
                '-- Starving artist
                Creativity += GetRandom(0, 3)
            End If
        End If

        '--Happiness
        If Happiness >= 70 Then
            '-- Happiness improves health
            maxBonus = (Happiness - 60.0) / 10.0
            Health += GetRandom(0, maxBonus)
        End If
        If Happiness <= 10 Then
            '-- Depression sickness
            Health -= GetRandom(1, 3)
        End If
        If Happiness <= 15 Then
            '-- Unhappy people lash out at society
            Criminality += GetRandom(0, 2)
        End If

        '-- Age
        Age = Age + 3
        If Age <= 28 Then
            '-- Upslope
            Health += 1
        End If
        If Age >= 45 Then
            '-- Downslope
            maxLoss = (Age - 50.0) / 10.0
            If maxLoss < 0 Then
                maxLoss = 0
            End If
            Health -= GetRandom(maxLoss, maxLoss + 2)
        End If

        '--Employment
        If Employment > 0 Then
            '-- Success leads to promotions
            maxBonus = (Intelligence / 8.0) + (Creativity / 9.0)
            Employment += GetRandom(0, maxBonus)

            '-- Criminality drops
            Criminality -= GetRandom(0, 1)
        Else
            If Age >= 16 Then
                '-- Unemployment is depressing and encourages a life of crime
                Happiness -= GetRandom(0, 3)
                Criminality += GetRandom(0, 2)
            End If
        End If
        If Employment > 50 Then
            '-- Fast track
            maxBonus = ((Employment - 40.0) / 10.0)
            Happiness += GetRandom(0, maxBonus)
        End If

        '--Intelligence and Creativity
        If Age <= 35 Then '-- Occurs 11 times
            '-- Personal drive
            Intelligence += GetRandom(0, SafeDivide(Intelligence, 15.0))
            Creativity += GetRandom(0, SafeDivide(Creativity, 15.0))
        End If
        If Age <= 18 Then '-- Occurs 5 times
            '-- Street smarts
            maxBonus = GetRandom(0, thePop / 8.0)
            '-- Primary school
            Intelligence += GetRandom(2, 5 + maxBonus)
            Creativity += GetRandom(2, 4 + maxBonus)
        End If
        If Age >= 18 And Age <= 25 Then '-- Occurs 3 times
            If Intelligence >= 30 + (thePop / 5.0) Then
                '-- Higher education. Gets more competitive with population.
                Intelligence += GetRandom(1, 5)
                Creativity += GetRandom(1, 5)
            Else
                Intelligence += GetRandom(0, 2)
                Creativity += GetRandom(0, 2)
            End If
        End If

        '-- Mobility and transportation
        maxBonus += GetRandom(theRoad / 2.0, theRoad)
        If Age <= 19 Then
            '-- Learn to walk, then to run
            Mobility += GetRandom(1, 3)
        ElseIf Age >= 50 Then
            '-- Arthritis
            maxLoss = (Age - 40.0) / 8.5
            Mobility -= GetRandom(0, maxLoss)
        End If
        If Age = 16 Then
            '-- Learn to drive
            If Employment > 0 Then
                '-- Buy a hotrod
                Mobility += GetRandom(6, 12)
            Else
                Mobility += GetRandom(3, 8)
            End If
        End If


        '-- Drunkenness
        If Drunkenness >= 10 Then
            '-- Addiction
            maxBonus = Drunkenness / 10.0
            Drunkenness += GetRandom(0, maxBonus)
        End If
        If Drunkenness >= 2 And Drunkenness <= 30 Then
            '-- Pleasant buzz
            Happiness += GetRandom(0, 2)
        End If
        If Drunkenness >= 25 Then
            '-- Liver damage
            maxLoss = Drunkenness / 13.0
            Health -= GetRandom(0, maxLoss)
        End If
        If Drunkenness >= 40 Then
            '-- Destructive lifestyle
            Happiness -= GetRandom(0, 2)
        End If
        If Drunkenness >= 40 And Health <= 12 And GetRandom(0, 100) <= 15 Then
            '-- Go cold turkey
            Drunkenness = 0
        End If

        '-- Population
        If thePop >= 5 Then
            maxBonus = SafeDivide(thePop, 3.0)
            Dim switchman As Integer = GetRandom(0, 2)
            '-- Crowded areas reduces health and happiness and increased crime
            If switchman = 0 Then
                Criminality += GetRandom(0, maxBonus)
            ElseIf switchman = 1 Then
                Happiness -= GetRandom(0, maxBonus)
            Else
                Health -= GetRandom(0, maxBonus)
            End If
        End If

        '-- Terrain
        If theTerrain = TerrainForest Then
            Happiness += GetRandom(1, 3)
            Health += GetRandom(1, 3)
        End If

        Cap()
    End Function

    Function WillReproduce() As Boolean
        'Remove happiness constraint?
        If Age >= 16 And Age <= 49 And Health > 20 And Happiness > 10 Then
            Dim Odds As Double = 0
            Odds += (25.0 - Math.Abs(25.0 - Age))
            Odds += (Health / 7.0)
            Odds += (Happiness / 10.0)
            Odds += Math.Min(5, Drunkenness / 6.0)
            Odds += (Employment / 20.0)
            If GetRandom(0, 100) <= Odds Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Function WillDie() As Boolean
        If Health = 0 Then
            Return True
        End If
        If Health <= 5 Or Age > 70 Then
            If GetRandom(0, 100) <= 25 Then
                Return True
            End If
        End If
        Return False
    End Function
    Function WillEmploy() As Boolean
        If Employment > 0 Then
            Return False
        ElseIf Age >= 13 And Intelligence >= 5 Then
            Dim Odds As Double = 20
            Odds = Odds + (100.0 - Age) / 12.0
            Odds = Odds + (Health / 9.0)
            Odds = Odds + (Happiness / 15.0)
            Odds = Odds - (Drunkenness / 6.0)
            Odds = Odds - (Criminality / 5.0)
            Odds = Odds + (Intelligence / 4.5)
            Odds = Odds + (Creativity / 5.5)
            Odds = Odds + (Mobility / 15.0)
            If GetRandom(0, 100) <= Odds Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
#End Region

#Region " Support "
    Public Overrides Function toString() As String
        Dim PersonString As String = ""
        PersonString += "Name: " + Name.ToString + ControlChars.NewLine
        PersonString += "Age: " + Age.ToString + ControlChars.NewLine
        PersonString += "Health: " + Health.ToString + ControlChars.NewLine
        PersonString += "Happiness: " + Happiness.ToString + ControlChars.NewLine
        PersonString += "Employment: " + Employment.ToString + ControlChars.NewLine
        PersonString += "Intelligence: " + Intelligence.ToString + ControlChars.NewLine
        PersonString += "Creativity: " + Creativity.ToString + ControlChars.NewLine
        PersonString += "Mobility: " + Mobility.ToString + ControlChars.NewLine
        PersonString += "Drunkenness: " + Drunkenness.ToString + ControlChars.NewLine
        PersonString += "Criminality: " + Criminality.ToString + ControlChars.NewLine
        PersonString += ControlChars.NewLine
        If Age < 16 Then
            PersonString += "Minor."
        ElseIf JobIndex = -1 Then
            PersonString += "Currently unemployed."
        Else
            PersonString += "Employed by the " + BoxInfo(JobLocation.X, JobLocation.Y).Buildings(JobIndex).Type + " at (" + (JobLocation.X + 1).ToString + "," + (JobLocation.Y + 1).ToString + ")" + ControlChars.NewLine
        End If

        Return PersonString
    End Function
#End Region

End Class

Public Class Player

#Region " Variables "
    Public PlayerType As Integer = PlayerHuman
    Public ID As Integer = 0
    Public Score As Integer = 0
    Public Flag As Color = Color.Black

    '--
    Public TotalMoney As Integer = 0
    Public TotalPopulation As Integer = 0
    Public TotalJobs As Integer = 0
    Public TotalEmployed As Integer = 0
    Public TotalTerritory As Integer = 0
    Public TotalDevelopment As Integer = 0
    Public TotalScore As Integer = 0
#End Region

#Region " New "
    Public Sub New(ByVal myID As Integer)
        ID = myID
        Score = 0
        TotalMoney = 110
    End Sub
#End Region

#Region " Functions "

    Sub UpdateCensusData()

        '-- Set Census values to 0
        TotalTerritory = 0
        TotalPopulation = 0
        TotalDevelopment = 0
        TotalEmployed = 0
        TotalJobs = 0
        TotalScore = 0

        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)

                If thisLocation.OwnerID = ID Then

                    '-- Update player territory, population, development, employees, and jobs
                    TotalTerritory += 1
                    TotalPopulation += thisLocation.getPopulation()
                    TotalDevelopment += thisLocation.getDevelopment()
                    TotalEmployed += thisLocation.getJobsFilled()
                    TotalJobs += thisLocation.getJobsTotal()

                    '-- Update player score for their citizens
                    For k As Integer = 0 To thisLocation.getPopulation() - 1
                        Dim currentCitizen As Person = thisLocation.People(k)

                        '-- Computation of individual's value
                        Dim personPoints As Integer = 0
                        personPoints += (currentCitizen.Happiness * 2.5)
                        personPoints += currentCitizen.Health
                        personPoints += (currentCitizen.Employment * 1.8)
                        personPoints += currentCitizen.Intelligence
                        personPoints += currentCitizen.Creativity
                        personPoints += (currentCitizen.Mobility * 0.5)
                        personPoints -= (currentCitizen.Criminality * 2.0)
                        personPoints -= (currentCitizen.Drunkenness * 1.3)
                        personPoints = SafeDivide(personPoints, 180.0)
                        If personPoints > 0 Then
                            personPoints = personPoints ^ 1.6
                        End If
                        TotalScore += personPoints
                    Next


                End If
            Next
        Next

        '-- Update player score for their territory and development
        TotalScore += (TotalDevelopment * 4.0)
        TotalScore += (TotalTerritory * 12.0)

        '-- Update player score for their employment ratio (Up to 20% bonus)
        TotalScore += (SafeDivide(TotalEmployed, TotalPopulation) * TotalScore * 0.2)
    End Sub

    Function GetPlayerName() As String
        Dim playerName As String = "Player " + (ID + 1).ToString()
        If PlayerType = PlayerHuman Then
            playerName += ", Human"
        ElseIf PlayerType = PlayerAI Then
            playerName += ", AI"
        Else
            playerName += ", ?"
        End If

        Return playerName
    End Function

    Function GetPlayerPopulation() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = ID Then
                    sum = sum + GridArray(i, j).getPopulation()
                End If
            Next
        Next
        TotalPopulation = sum
        Return sum
    End Function

    Function GetPlayerTerritory() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = ID Then
                    sum = sum + 1
                End If
            Next
        Next
        TotalTerritory = sum
        Return sum
    End Function

    Function GetPlayerDevelopment() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = ID Then
                    sum = sum + GridArray(i, j).getDevelopment()
                End If
            Next
        Next
        TotalDevelopment = sum
        Return sum
    End Function

    Function GetPlayerScore() As Integer
        '--Must call getplayer territory and development first
        Dim sum As Double = 0
        Dim personPoints As Double
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = ID Then
                    For k As Integer = 0 To GridArray(i, j).People.Count - 1
                        '-- Computation of individual's value
                        personPoints = 0
                        personPoints += (GridArray(i, j).People(k).Happiness * 2.5)
                        personPoints += GridArray(i, j).People(k).Health
                        personPoints += (GridArray(i, j).People(k).Employment * 1.8)
                        personPoints += GridArray(i, j).People(k).Intelligence
                        personPoints += GridArray(i, j).People(k).Creativity
                        personPoints += (GridArray(i, j).People(k).Mobility * 0.5)
                        personPoints -= (GridArray(i, j).People(k).Criminality * 2.0)
                        personPoints -= (GridArray(i, j).People(k).Drunkenness * 1.3)
                        personPoints = SafeDivide(personPoints, 180.0)
                        If personPoints > 0 Then
                            personPoints = personPoints ^ 1.6
                        End If
                        sum += personPoints
                    Next
                End If
            Next
        Next

        '-- Computation of total value
        sum += (TotalDevelopment * 4.0)
        sum += (TotalTerritory * 12.0)
        sum += (SafeDivide(TotalEmployed, TotalPopulation) * sum * 0.2)
        TotalScore = sum
        Return sum
    End Function

    Function GetPlayerLandCost() As Integer
        Dim landCost As Integer = 50
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim theLocation As CitySquare = GridArray(i, j)
                If theLocation.OwnerID = ID Then
                    If theLocation.Terrain <> TerrainSwamp Then
                        landCost += 20
                    End If
                End If
            Next
        Next
        Return landCost
    End Function

    Function OwnedAdjacent(ByVal theLocation As CitySquare) As Boolean

        '-- Check if this player owns a neighboring location
        Dim adjacentList As ArrayList = theLocation.GetAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            Dim neighborLocation As CitySquare = adjacentList(i)
            If neighborLocation.OwnerID = ID Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Overrides Function toString() As String
        Dim textString As String = ""
        ' textString += GetPlayerName().ToString() + ControlChars.NewLine
        textString += "Money: " + TotalMoney.ToString() + ControlChars.NewLine
        textString += "Pop: " + TotalPopulation.ToString() + ControlChars.NewLine
        textString += "Jobs: " + TotalEmployed.ToString() + "/" + TotalJobs.ToString() + ControlChars.NewLine
        textString += "Territory: " + TotalTerritory.ToString() + ControlChars.NewLine
        textString += "Buildings: " + TotalDevelopment.ToString() + ControlChars.NewLine
        textString += "Score: " + TotalScore.ToString()

        Return textString
    End Function
#End Region

End Class

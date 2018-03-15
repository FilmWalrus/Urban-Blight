Public Class Player

#Region " Variables "
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
                Dim thisLocation As CitySquare = BoxInfo(i, j)

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
#End Region

End Class

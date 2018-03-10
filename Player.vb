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
End Class

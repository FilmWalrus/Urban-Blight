Public Class NatureBuilding
    Inherits Building

    Public NatureBonus As Double = 0.0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Sub UpdateAdjNatureBonus()

        Dim AdjNatureCount As Integer = 0
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        For Each theLocation As CitySquare In AdjLocations
            AdjNatureCount += 1
        Next
        '-- Add 10% to the odds of improving stats for each adj. location with the Nature tag.
        NatureBonus = AdjNatureCount * 10.0
    End Sub

    Public Overrides Function GetHappinessOdds() As Integer
        Return MyBase.GetHappinessOdds() + NatureBonus
    End Function

    Public Overrides Function GetHealthOdds() As Integer
        Return MyBase.GetHealthOdds() + NatureBonus
    End Function

    Public Overrides Function GetCreativityOdds() As Integer
        Return MyBase.GetCreativityOdds() + NatureBonus
    End Function

    Public Overrides Function GetIntelligenceOdds() As Integer
        Return MyBase.GetIntelligenceOdds() + NatureBonus
    End Function

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Before affecting citizens, calculate the nature bonus for stat changes
        UpdateAdjNatureBonus()
        MyBase.AffectPerson(thePerson)
    End Sub

End Class

Public Class BotanicalBuilding
    Inherits NatureBuilding

    Public BotanicalAdjBonus As Double = 0.0
    Public BotanicalOddsBonus As Double = 0.0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function GetHappinessOdds() As Integer
        Return MyBase.GetHappinessOdds() + BotanicalOddsBonus
    End Function

    Public Overrides Function GetHealthOdds() As Integer
        Return MyBase.GetHealthOdds() + BotanicalOddsBonus
    End Function

    Public Overrides Function GetCreativityOdds() As Integer
        Return MyBase.GetCreativityOdds() + BotanicalOddsBonus
    End Function

    Public Overrides Function GetIntelligenceOdds() As Integer
        Return MyBase.GetIntelligenceOdds() + BotanicalOddsBonus
    End Function

    Public Overrides Function GetHappinessAdj() As Integer
        Return MyBase.GetHappinessAdj() + BotanicalAdjBonus
    End Function

    Public Overrides Function GetHealthAdj() As Integer
        Return MyBase.GetHealthAdj() + BotanicalAdjBonus
    End Function

    Public Overrides Function GetCreativityAdj() As Integer
        Return MyBase.GetCreativityAdj() + BotanicalAdjBonus
    End Function

    Public Overrides Function GetIntelligenceAdj() As Integer
        Return MyBase.GetIntelligenceAdj() + BotanicalAdjBonus
    End Function

    Public Sub UpdateBotanicalBonuses()

        '-- Botanical gardens provide a +1 effect for each forest on or adj
        Dim AdjForestCount As Integer = 0
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        AdjLocations.Add(Location)
        For Each theLocation As CitySquare In AdjLocations
            AdjForestCount += 1
        Next
        BotanicalAdjBonus = AdjForestCount

        '-- Add 2% to the odds of improving stats for each forest owned
        Dim ForestCount As Integer = 0
        For Each theLocation As CitySquare In GridArray
            If theLocation.IsOwned(Me.OwnerID) Then
                If theLocation.Terrain = TerrainForest Then
                    ForestCount += 1
                End If
            End If
        Next
        BotanicalOddsBonus = ForestCount * 2.0

    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Before affecting citizens, calculate the nature bonus for stat changes
        UpdateBotanicalBonuses()
        MyBase.AffectPerson(thePerson)
    End Sub

End Class

Public Class ConservationBuilding
    Inherits NatureBuilding


    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Change the location terrain type to forest
        Location.SetTerrain(TerrainForest)
    End Sub
End Class

Public Class ZooBuilding
    Inherits NatureBuilding

    Public ZooAdjBonus As Double = 0.0
    Public ZooOddsBonus As Double = 0.0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function GetHappinessOdds() As Integer
        Return MyBase.GetHappinessOdds() + ZooOddsBonus
    End Function

    Public Overrides Function GetHealthOdds() As Integer
        Return MyBase.GetHealthOdds() + ZooOddsBonus
    End Function

    Public Overrides Function GetCreativityOdds() As Integer
        Return MyBase.GetCreativityOdds() + ZooOddsBonus
    End Function

    Public Overrides Function GetIntelligenceOdds() As Integer
        Return MyBase.GetIntelligenceOdds() + ZooOddsBonus
    End Function

    Public Overrides Function GetHappinessAdj() As Integer
        Return MyBase.GetHappinessAdj() + ZooAdjBonus
    End Function

    Public Overrides Function GetHealthAdj() As Integer
        Return MyBase.GetHealthAdj() + ZooAdjBonus
    End Function

    Public Overrides Function GetCreativityAdj() As Integer
        Return MyBase.GetCreativityAdj() + ZooAdjBonus
    End Function

    Public Overrides Function GetIntelligenceAdj() As Integer
        Return MyBase.GetIntelligenceAdj() + ZooAdjBonus
    End Function

    Public Sub UpdateBotanicalBonuses()

        '-- Botanical gardens provide a +1 effect for each forest on or adj
        Dim AdjForestCount As Integer = 0
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        AdjLocations.Add(Location)
        For Each theLocation As CitySquare In AdjLocations
            AdjForestCount += 1
        Next
        ZooAdjBonus = AdjForestCount

        '-- Add 2% to the odds of improving stats for each forest owned
        Dim ForestCount As Integer = 0
        For Each theLocation As CitySquare In GridArray
            If theLocation.IsOwned(Me.OwnerID) Then
                If theLocation.Terrain = TerrainForest Then
                    ForestCount += 1
                End If
            End If
        Next
        ZooOddsBonus = ForestCount * 2.0

    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Before affecting citizens, calculate the nature bonus for stat changes
        UpdateBotanicalBonuses()
        MyBase.AffectPerson(thePerson)
    End Sub

End Class

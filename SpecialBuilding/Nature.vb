﻿Public Class NatureBuilding
    Inherits Building

    Public NatureBonus As Double = 0.0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
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

    Public Overridable Sub UpdateNatureBonuses()
        Dim AdjNatureCount As Integer = 0
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        For Each theLocation As CitySquare In AdjLocations
            If theLocation.CountBuildingsByTag(BuildingGen.TagEnum.Nature) Then
                AdjNatureCount += 1
            End If
        Next
        '-- Add 10% to the odds of improving stats for each adj. location with the Nature tag.
        NatureBonus = AdjNatureCount * 10.0
    End Sub

    Public Overrides Sub UpdateBuildingEffects()
        MyBase.UpdateBuildingEffects()
        UpdateNatureBonuses()
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()
        UpdateNatureBonuses()
    End Sub

End Class

Public Class AquariumBuilding
    Inherits NatureBuilding

    Public AquariumAdjBonus As Double = 0.0
    Public AquariumOddsBonus As Double = 0.0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function GetHappinessOdds() As Integer
        Return MyBase.GetHappinessOdds() + AquariumOddsBonus
    End Function

    Public Overrides Function GetHealthOdds() As Integer
        Return MyBase.GetHealthOdds() + AquariumOddsBonus
    End Function

    Public Overrides Function GetCreativityOdds() As Integer
        Return MyBase.GetCreativityOdds() + AquariumOddsBonus
    End Function

    Public Overrides Function GetIntelligenceOdds() As Integer
        Return MyBase.GetIntelligenceOdds() + AquariumOddsBonus
    End Function

    Public Overrides Function GetHappinessAdj() As Integer
        Return MyBase.GetHappinessAdj() + AquariumAdjBonus
    End Function

    Public Overrides Function GetHealthAdj() As Integer
        Return MyBase.GetHealthAdj() + AquariumAdjBonus
    End Function

    Public Overrides Function GetCreativityAdj() As Integer
        Return MyBase.GetCreativityAdj() + AquariumAdjBonus
    End Function

    Public Overrides Function GetIntelligenceAdj() As Integer
        Return MyBase.GetIntelligenceAdj() + AquariumAdjBonus
    End Function

    Public Overrides Sub UpdateNatureBonuses()
        MyBase.UpdateNatureBonuses()

        '-- Aquariums provide a +1 effect for each lake on or adj
        Dim AdjLakeCount As Integer = 0
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        AdjLocations.Add(Location)
        For Each theLocation As CitySquare In AdjLocations
            If theLocation.Terrain = TerrainLake Then
                AdjLakeCount += 1
            End If
        Next
        AquariumAdjBonus = AdjLakeCount

        '-- Add 2% to the odds of improving stats for each coastline (coast edge) you own
        Dim CoastCount As Integer = 0
        For Each theLocation As CitySquare In GridArray
            If theLocation.IsOwned(Me.OwnerID) Then
                Dim AdjLocations2 As List(Of CitySquare) = theLocation.GetTrueAdjacents()
                For Each theLocation2 As CitySquare In AdjLocations2
                    If theLocation2.Terrain = TerrainLake Then
                        CoastCount += 1
                    End If
                Next
            End If
        Next
        AquariumOddsBonus = CoastCount * 2.0
    End Sub

    Public Overrides Sub UpdateBuildingEffects()
        MyBase.UpdateBuildingEffects()
        UpdateNatureBonuses()
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()
        UpdateNatureBonuses()
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

    Public Overrides Sub UpdateNatureBonuses()
        MyBase.UpdateNatureBonuses()

        '-- Botanical gardens provide a +1 effect for each forest on or adj
        Dim AdjForestCount As Integer = 0
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        AdjLocations.Add(Location)
        For Each theLocation As CitySquare In AdjLocations
            If theLocation.Terrain = TerrainForest Then
                AdjForestCount += 1
            End If
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

    Public Overrides Sub UpdateBuildingEffects()
        MyBase.UpdateBuildingEffects()
        UpdateNatureBonuses()
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()
        UpdateNatureBonuses()
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

Public Class FarmBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        If Location.Terrain = TerrainDirt Then '-- Expand at a rate of 2 if on dirt
            ExpandRate += 1
        End If

        '-- Make sure there isn't another building of the same type already here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- +1 max health to all Food buildings
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Food)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.Health_adj += 1
        Next
    End Sub

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another building of the same type here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- +1 max health to all Food buildings
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Food)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.Health_adj -= 1
        Next

        MyBase.Destroy()
    End Sub
End Class

Public Class RanchBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        If Location.Terrain = TerrainPlain Then '-- Expand at a rate of 2 if on plains
            ExpandRate += 1
        End If

        '-- Make sure there isn't another building of the same type already here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- +1 max health to all Food buildings
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Food)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.Health_adj += 1
        Next
    End Sub

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another building of the same type here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- +1 max health to all Food buildings
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Food)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.Health_adj -= 1
        Next

        MyBase.Destroy()
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

    Public Overrides Sub UpdateNatureBonuses()

        MyBase.UpdateNatureBonuses()

        '-- Zoos provide a +1 effect for unique terrain type on or adj
        Dim AdjTerrainTypes As New List(Of Integer)
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        AdjLocations.Add(Location)
        For Each theLocation As CitySquare In AdjLocations
            If Not AdjTerrainTypes.Contains(theLocation.Terrain) Then
                AdjTerrainTypes.Add(theLocation.Terrain)
            End If
        Next
        ZooAdjBonus = AdjTerrainTypes.Count

        '-- Add 3% to the odds of improving stats for each unique terrain type you own (for a total of 24% max)
        Dim OwnedTerrainTypes As New List(Of Integer)
        For Each theLocation As CitySquare In GridArray
            If theLocation.IsOwned(Me.OwnerID) Then
                If Not OwnedTerrainTypes.Contains(theLocation.Terrain) Then
                    OwnedTerrainTypes.Add(theLocation.Terrain)
                End If
            End If
        Next
        ZooOddsBonus = OwnedTerrainTypes.Count * 3.0
    End Sub

    Public Overrides Sub UpdateBuildingEffects()
        MyBase.UpdateBuildingEffects()
        UpdateNatureBonuses()
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()
        UpdateNatureBonuses()
    End Sub

End Class

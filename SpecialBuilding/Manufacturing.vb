﻿'-- This file contains classes for Manufacturing-type buildings

Public Class ManufacturingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Double the number of manufacturing jobs if on the correct terrain type.
        Dim JobMultiplier As Integer = 1
        If Type = BuildingGen.BuildingEnum.Cartel And Location.Terrain = TerrainEnum.Dirt Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Fishery And Location.Coastal Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Lumber_Mill And Location.Terrain = TerrainEnum.Forest Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Steel_Mill And Location.Terrain = TerrainEnum.Mountain Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Textile_Mill And Location.Terrain = TerrainEnum.Plain Then
            JobMultiplier *= 2
        End If

        '-- Double the number of jobs (potentially a 2nd time) if on a shipping center.
        If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Shipping_Center) > 0 Then
            JobMultiplier *= 2
        End If

        Jobs *= JobMultiplier
    End Sub
End Class

Public Class MineBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        EffectText = "saved w/ mining rebates"
    End Sub

    Function ApplyMineRebate(ByRef NewBuilding As Building) As Integer

        '-- The mine rebate rate increases if the mine or new construction on a mountain
        Dim MineRebateRate As Double = 0.1
        If Location.Terrain = TerrainEnum.Mountain Then
            MineRebateRate += 0.1
        End If
        If NewBuilding.Location.Terrain = TerrainEnum.Mountain Then
            MineRebateRate += 0.1
        End If

        Dim MineRebate As Integer = NewBuilding.PurchasePrice * MineRebateRate
        CurrentPlayer.TotalMoney += MineRebate
        AddEffects(MineRebate)

    End Function
End Class

Public Class ShippingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Make sure there isn't another building of the same type already here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Double the number of jobs at each manufacturing building on this square
        Dim mfgBuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Manufacturing)
        For i As Integer = 0 To mfgBuildingList.Count - 1
            Dim thisBuilding As Building = mfgBuildingList(i)
            thisBuilding.Jobs *= 2
        Next
    End Sub

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another a shipping center here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Half the number of jobs at each manufacturing building on this square
        Dim mfgBuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Manufacturing)
        For i As Integer = 0 To mfgBuildingList.Count - 1
            Dim thisBuilding As Building = mfgBuildingList(i)
            thisBuilding.Jobs = CInt(thisBuilding.Jobs / 2)
        Next

        MyBase.Destroy()
    End Sub
End Class

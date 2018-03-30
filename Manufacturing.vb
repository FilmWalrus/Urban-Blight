Public Class ManufacturingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        '-- Double the number of manufacturing jobs if on the correct terrain type.
        Dim JobMultiplier As Integer = 1
        If Type = BuildingGen.BuildingEnum.Cartel And Location.Terrain = TerrainDirt Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Fishery And Location.Coastal Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Lumber_Mill And Location.Terrain = TerrainForest Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Steel_Mill And Location.Terrain = TerrainMountain Then
            JobMultiplier *= 2
        ElseIf Type = BuildingGen.BuildingEnum.Textile_Mill And Location.Terrain = TerrainPlain Then
            JobMultiplier *= 2
        End If

        '-- Double the number of jobs (potentially a 2nd time) if on a shipping center.
        If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Shipping_Center) > 0 Then
            JobMultiplier *= 2
        End If

        Jobs *= JobMultiplier
    End Sub
End Class

Public Class ShippingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()

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

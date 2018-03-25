Public Class DayCareBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bName As String, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bName, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        If thePerson.Age <= 16 Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub
End Class

Public Class ManufacturingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bName As String, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bName, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
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

        If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Shipping_Center) > 0 Then
            JobMultiplier *= 2
        End If

        Jobs *= JobMultiplier
    End Sub
End Class

Public Class RetirementBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bName As String, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bName, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        If thePerson.Age > 50 Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub
End Class

Public Class SchoolBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bName As String, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bName, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        '-- Run the regular building stat changes and then run it again on minors
        MyBase.AffectPerson(thePerson)
        If thePerson.IsMinor() Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub
End Class

Public Class ShippingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bName As String, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bName, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()

        Dim mfgBuildingList As ArrayList = Location.GetBuildingsByTag("Manufacturing")

        For i As Integer = 0 To mfgBuildingList.Count - 1
            Dim thisBuilding As Building = mfgBuildingList(i)
            thisBuilding.Jobs *= 2
        Next
    End Sub
End Class


'-- This file contains classes for Construction-type buildings

Public Class ConstructionSiteBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function UpdateInternal() As Boolean
        MyBase.UpdateInternal()

        If GetRandom(1, 5) = 1 Then
            Dim newBuilding As Building = BuildingGenerator.CreateBuilding(-1)
            Location.AddBuilding(newBuilding, OwnerID)
            Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " is now a " + newBuilding.GetName())
            Return False
        Else
            Return True
        End If
    End Function
End Class

Public Class SkyscraperBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Make sure there IS another building of the same type already here
        If Not DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- If multiple skyscrapers, 50% chance of creating a park, 50% chance of creating a crime ring
        Dim newBuilding As Building = Nothing
        If GetRandom(0, 1) = 0 Then
            newBuilding = BuildingGenerator.CreateBuilding(BuildingGen.BuildingEnum.Crime_Ring)
        Else
            newBuilding = BuildingGenerator.CreateBuilding(BuildingGen.BuildingEnum.Park)
        End If
        Location.AddBuilding(newBuilding, OwnerID)
    End Sub
End Class

Public Class StartupIncubatorBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "buildings launched"
    End Sub

    Public Overrides Function UpdateInternal() As Boolean
        MyBase.UpdateInternal()

        If GetRandom(1, 100) <= 15 Then '-- 15% chance to spawn a new building
            Dim newBuilding As Building = BuildingGenerator.CreateBuilding(-1)
            Location.AddBuilding(newBuilding, OwnerID)
            Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " launched " + newBuilding.GetName())
            AddEffects(1)
        End If

        If GetRandom(1, 100) <= 5 Then '-- 5% chance of failing
            Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " declared bankruptcy")
            Return False
        Else
            Return True
        End If
    End Function
End Class
Imports Urban_Blight

Public Class ChurchBuilding
    Inherits Building

    Public defaultOdds As Integer = 1

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "religious epiphanies inspired"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Small chance of reducing a person's criminality or drunkenness to 0
        Dim odds As Integer = defaultOdds
        odds += SafeDivide(thePerson.Criminality, 20.0)
        If GetRandom(1, 100) = 1 Then
            thePerson.Criminality = 0
            thePerson.AddEvent("Religious epiphany reset criminality to 0")
            AddEffects(1)
        End If

        odds = defaultOdds
        odds += SafeDivide(thePerson.Drunkenness, 20.0)
        If GetRandom(1, 100) = 1 Then
            thePerson.Drunkenness = 0
            thePerson.AddEvent("Religious epiphany reset drunkenness to 0")
            AddEffects(1)
        End If
    End Sub
End Class

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

Public Class CorrectionalFacilityBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "criminals rehabilitated"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Small chance of reducing a person's criminality to 0 (and mobility to 0 as well)
        If thePerson.Criminality > 10 Then
            Dim odds As Integer = 1
            odds += SafeDivide(thePerson.Criminality, 20.0)
            If GetRandom(1, 10) <= odds Then
                thePerson.Criminality = 0
                thePerson.Mobility = 0
                thePerson.AddEvent("Thrown in jail: criminality and mobility set to 0")
                AddEffects(1)
            End If
        End If
    End Sub
End Class

Public Class DayCareBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Only affect citizens under the age of 17
        If thePerson.IsMinor() Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub
End Class

Public Class MonumentBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Make sure there isn't another building of the same type already here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Double the odds of visitors
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Monument)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.UpdateAllOdds(2.0, True)
        Next
    End Sub

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another building of the same type here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Half the odds of visitors
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Manufacturing)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.UpdateAllOdds(0.5, True)
        Next

        MyBase.Destroy()
    End Sub
End Class

Public Class RehabBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "addicts rehabilitated"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Small chance of reducing a person's drunkenness to 0 (and mobility to 0 as well)
        If thePerson.Drunkenness > 10 Then
            Dim odds As Integer = 1
            odds += SafeDivide(thePerson.Drunkenness, 10.0)
            If GetRandom(1, 10) <= odds Then
                thePerson.Drunkenness = 0
                thePerson.Mobility = SafeDivide(thePerson.Mobility, 2.0)
                thePerson.AddEvent("Admitted to rehab: drunkenness reset to 0 and mobility halved")
                AddEffects(1)
            End If
        End If
    End Sub
End Class

Public Class RetirementBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Only affect citizens over the age of 50
        If thePerson.IsElderly() Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub
End Class

Public Class SchoolBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "children taught"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Run the regular building stat changes and then run it again on minors
        MyBase.AffectPerson(thePerson)
        If thePerson.IsMinor() Then
            MyBase.AffectPerson(thePerson)
            AddEffects(1)
        End If
    End Sub
End Class

Public Class SkiResortBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Only affect citizens if built on mountain
        If Location.Terrain = TerrainMountain Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub

    Public Overrides Function WillHire(ByRef Candidate As Citizen) As Boolean
        '-- Only hire citizens if built on mountain
        If Location.Terrain = TerrainMountain Then
            Return MyBase.WillHire(Candidate)
        Else
            Return False
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

Public Class WelfareBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "welfare recipients"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Only affect unemployed citizens
        If thePerson.JobBuilding IsNot Nothing Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub

End Class

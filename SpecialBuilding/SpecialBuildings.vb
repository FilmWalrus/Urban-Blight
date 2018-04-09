﻿'-- This file contains classes for miscellaneous special buildings

Public Class ActivismBuilding
    Inherits Building

    Public BannedBuilding As Integer = -1

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "buildings banned"

        BannedBuilding = GetRandom(0, BuildingGen.BuildingEnum.BuildingCount - 1)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Add to the owner's list of banned buildings
        '-- This is correct even if it results in a building appearing multiple times
        Players(OwnerID).BannedBuildings.Add(BannedBuilding)
    End Sub

    Public Overrides Sub Destroy()

        '-- Remove this banned building (removes only 1 copy so we are ok if there are multiple)
        Players(OwnerID).BannedBuildings.Remove(BannedBuilding)

        MyBase.Destroy()
    End Sub

End Class

Public Class ChurchBuilding
    Inherits Building

    Public defaultOdds As Integer = 1

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "religious epiphanies inspired"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        MyBase.AffectPerson(thePerson)

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

Public Class CrimeRingBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "kickbacks generated"
    End Sub
End Class

Public Class CorrectionalFacilityBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "criminals rehabilitated"
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        MyBase.AffectPerson(thePerson)

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

Public Class MallBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function GetHappinessOdds() As Integer
        Dim DevelopmentBonus As Integer = (Location.getDevelopment() - 1) * 3
        Return Happiness_odds + DevelopmentBonus
    End Function
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
        MyBase.AffectPerson(thePerson)

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

    Public Overrides Function GetHappinessOdds() As Integer
        If Location IsNot Nothing Then
            If Location.Terrain <> TerrainMountain Then
                Return 0
            End If
        End If
        Return MyBase.GetHappinessOdds()
    End Function

    Public Overrides Function GetHealthOdds() As Integer
        If Location IsNot Nothing Then
            If Location.Terrain <> TerrainMountain Then
                Return 0
            End If
        End If
        Return MyBase.GetHealthOdds()
    End Function

    Public Overrides Function GetMobilityOdds() As Integer
        If Location IsNot Nothing Then
            If Location.Terrain <> TerrainMountain Then
                Return 0
            End If
        End If
        Return MyBase.GetMobilityOdds()
    End Function

    Public Overrides Function GetDrunkennessOdds() As Integer
        If Location IsNot Nothing Then
            If Location.Terrain <> TerrainMountain Then
                Return 0
            End If
        End If
        Return MyBase.GetDrunkennessOdds()
    End Function

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

Public Class TempAgencyBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "temp positions created"
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Add jobs to all buildings at this location
        For i As Integer = 0 To Location.Buildings.Count - 1
            Dim thisBuilding As Building = Location.Buildings(i)
            If Not thisBuilding.Equals(Me) Then
                thisBuilding.Jobs += 1
                AddEffects(1)
            End If
        Next
    End Sub

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

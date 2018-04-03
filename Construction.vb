﻿'-- This file contains classes for Construction-type buildings

Public Class SpreadableBuilding
    Inherits Building

    Public SpreadOdds As Double = 5.0
    Public PopulationRatio As Double = 5.0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        EffectText = "branches opened"
    End Sub

    Public Sub SpreadToAdjacent()

        '-- Find a random adjacent location. 
        Dim AdjLocations As List(Of CitySquare) = Location.GetAdjacents()
        Dim RandomNeighbor As CitySquare = AdjLocations(GetRandom(0, AdjLocations.Count - 1))
        If Not RandomNeighbor.IsOwned() Then
            Return
        End If

        Dim CountExisting As Integer = RandomNeighbor.CountBuildingsByType(Type)
        Dim MaxExisting As Integer = Math.Floor(SafeDivide(RandomNeighbor.getPopulation(), PopulationRatio)) + 1

        '-- If it is occupied and population of adj city can sustain it, spread to that location.
        If CountExisting < MaxExisting Then
            Dim newBuilding As Building = BuildingGenerator.CreateBuilding(Type)
            RandomNeighbor.AddBuilding(newBuilding, OwnerID)
            Diary.SpecialBuildingEvents.AddEventNoLimit(GetName() + " has opened a new location at " + RandomNeighbor.GetName())
            AddEffects(1)
        End If
    End Sub

    Public Overrides Function UpdateInternal() As Boolean
        MyBase.UpdateInternal()

        If GetRandom(1, 100) <= SpreadOdds Then
            SpreadToAdjacent()
        End If

        Return True
    End Function

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

Public Class CultBuilding
    Inherits SpreadableBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SpreadOdds = 15.0
        PopulationRatio = 12.0
        EffectText = "chapters opened"
    End Sub

    Public Overrides Function UpdateInternal() As Boolean
        MyBase.UpdateInternal()

        If GetEmployeeCount() < Jobs Then
            '-- If there is an opening at the cult steal an employee of another building and brainwash him
            For i As Integer = 0 To 10
                Dim RandomBuilding As Building = Location.Buildings(GetRandom(0, Location.Buildings.Count - 1))
                If Not RandomBuilding.Equals(Me) And RandomBuilding.Employees.Count > 0 Then
                    Dim RandomEmployee As Citizen = RandomBuilding.Employees(GetRandom(0, RandomBuilding.Employees.Count - 1))
                    RandomEmployee.Intelligence -= 10 '-- Brainwashed
                    HireEmployee(RandomEmployee)
                    Diary.CultEvents.AddEvent(GetNameAndAddress() + " lured in " + RandomEmployee.Name)
                    Exit For
                End If
            Next
        End If

        Return True
    End Function

End Class

Public Class DepartmentStoreBuilding
    Inherits SpreadableBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SpreadOdds = 5.0
        PopulationRatio = 7.5
        EffectText = "branches opened"
    End Sub

    Public Overrides Function UpdateInternal() As Boolean
        MyBase.UpdateInternal()

        If GetRandom(1, 100) <= 3 Then
            '-- Create a mall
            Dim newBuilding As Building = BuildingGenerator.CreateBuilding(BuildingGen.BuildingEnum.Mall)
            Location.AddBuilding(newBuilding, OwnerID)
            Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " upgraded to a " + newBuilding.GetName())

            '-- Transfer over all employees
            newBuilding.Jobs = Math.Max(newBuilding.Jobs, Jobs + 2)
            newBuilding.TransferEmployees(Me)

            '-- Get rid of the department store
            Return False
        Else
            Return True
        End If
    End Function
End Class

Public Class FastFoodBuilding
    Inherits SpreadableBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SpreadOdds = 10.0
        PopulationRatio = 4.0
        EffectText = "franchises opened"
    End Sub
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
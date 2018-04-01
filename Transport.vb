﻿Imports Urban_Blight

Public Class AirportBuilding
    Inherits Building

    Public Shared DestinationList As New List(Of CitySquare)

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Sub UpdateDestinationList(ByRef Destination As CitySquare)
        If Not DestinationList.Contains(Destination) Then
            DestinationList.Add(Destination)
        End If
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Add yourself to the list of destinations
        UpdateDestinationList(Location)
    End Sub

    Public Overrides Function GetAdjacentLocations() As List(Of CitySquare)
        Return DestinationList

        '-- Airports are adjacent to all other airports (but not themselves)
        Dim ValidDestinationList As New List(Of CitySquare)
        ValidDestinationList.AddRange(DestinationList)
        ValidDestinationList.Remove(Location)
        Return ValidDestinationList
    End Function

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another building of the same type here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Remove this location from the destination list
        DestinationList.Remove(Location)

        MyBase.Destroy()
    End Sub

End Class

Public Class FreewayBuilding
    Inherits Building

    Public Const EnduranceBoost As Integer = 10

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        Range = 2
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Upgrade all roads within range 2
        Dim CurrentRange As Integer = GetRange()
        For i As Integer = Location.RowID - CurrentRange To Location.RowID + CurrentRange
            For j As Integer = Location.ColID - CurrentRange To Location.ColID + CurrentRange
                Dim FreewayDestination As CitySquare = GetCitySquare(i, j)
                If FreewayDestination IsNot Nothing Then
                    Dim CurrentDistance As Integer = Location.GetDistance(FreewayDestination)
                    If FreewayDestination.IsOwned() And CurrentDistance <= CurrentRange Then
                        FreewayDestination.AddRoad()
                    End If
                End If
            Next
        Next
    End Sub

End Class

Public Class GasStationBuilding
    Inherits Building

    Public Const EnduranceBoost As Integer = 10

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub UpdateEndurance(ByRef Endurance As Integer, ByRef thePerson As Person)
        '-- Gas station restores up to 10 endurance, but not to exceed the person's starting mobility plus 10
        Endurance = Math.Min(Endurance + EnduranceBoost, thePerson.Mobility + EnduranceBoost)
        thePerson.AddEvent("Fueled up at gas station before continuing on")
    End Sub

End Class

Public Class HarborBuilding
    Inherits Building

    Public DestinationList As New List(Of CitySquare)

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectMobility(ByRef thePerson As Person)
        If Location.Coastal Then '-- Harbors only work on coastal areas
            MyBase.AffectMobility(thePerson)
        End If
    End Sub

    Public Sub UpdateDestinationList()
        '-- Harbors are adjacent to all coastss reachable by a water route (but not themselves)
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        For i As Integer = 0 To AdjLocations.Count - 1
            GatherCoast(AdjLocations(i))
        Next
    End Sub

    Public Sub UpdateDestinationList(ByRef Destination As CitySquare)
        If Not DestinationList.Contains(Destination) And Not Destination.Equals(Location) Then
            DestinationList.Add(Destination)
        End If
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        UpdateDestinationList()

        '-- Add this building to the owner's list of special land option buildings
        Players(OwnerID).LandOptionBuildings.Add(Me)
    End Sub

    Public Sub GatherCoast(ByRef theLocation As CitySquare)
        '-- Travel only over water we have not yet visited
        If theLocation.Terrain <> TerrainLake Or theLocation.VisitedKey > 0 Then
            Return
        End If
        theLocation.VisitedKey = 1

        Dim AdjLocations As List(Of CitySquare) = theLocation.GetTrueAdjacents()
        For i As Integer = 0 To AdjLocations.Count - 1
            Dim AdjLocation As CitySquare = AdjLocations(i)
            If AdjLocation.Terrain = TerrainLake Then
                '-- If adjacent to water keep sailing
                GatherCoast(AdjLocation)
            Else
                '-- If adjacent to land, add it to the destination list
                UpdateDestinationList(AdjLocation)
            End If
        Next

    End Sub

    Public Overloads Function GetAdjacentLocations(ByVal OwnedAdjacent As Boolean) As List(Of CitySquare)
        Dim ValidDestinations As New List(Of CitySquare)
        For i As Integer = 0 To DestinationList.Count - 1
            Dim Destination As CitySquare = DestinationList(i)
            If Destination.IsOwned() = OwnedAdjacent Then
                ValidDestinations.Add(Destination)
            End If
        Next
        Return ValidDestinations
    End Function

    Public Overrides Function GetAdjacentLocations() As List(Of CitySquare)
        Return GetAdjacentLocations(True)
    End Function

    Public Overrides Function IsLandExpansionOption(ByRef testLocation As CitySquare) As Boolean
        Dim ValidDestinations As List(Of CitySquare) = GetAdjacentLocations(False)
        Return ValidDestinations.Contains(testLocation)
    End Function

    Public Overrides Sub Destroy()
        '-- Remove this building from the list of the player's special land option buildings
        Players(OwnerID).LandOptionBuildings.Remove(Me)

        MyBase.Destroy()
    End Sub
End Class

Public Class HotelBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub UpdateEndurance(ByRef Endurance As Integer, ByRef thePerson As Person)
        '-- Hotel restores a person to half the mobility
        Endurance = Math.Max(Endurance, SafeDivide(thePerson.Mobility, 2.0))
        thePerson.AddEvent("Rested up at hotel before continuing on")
    End Sub

End Class

Public Class MassTransitBuilding
    Inherits Building

    Public Shared DestinationList As New List(Of CitySquare)

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SetRange(3) '-- Default mass transit range is 3
    End Sub

    Public Sub UpdateDestinationList(ByRef Destination As CitySquare)
        If Not DestinationList.Contains(Destination) Then
            DestinationList.Add(Destination)
        End If
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Add yourself to the list of destinations
        UpdateDestinationList(Location)
    End Sub

    Public Overrides Function GetAdjacentLocations() As List(Of CitySquare)
        '-- Mass transits are adjacent to other mass transits within range
        Dim ValidDestinationList As New List(Of CitySquare)
        For i As Integer = 0 To DestinationList.Count - 1
            Dim thisDistance As Integer = Location.GetDistance(DestinationList(i))
            If thisDistance > 0 And thisDistance <= GetRange() Then
                ValidDestinationList.Add(DestinationList(i))
            End If
        Next
        Return ValidDestinationList
    End Function

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another building of the same type here
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Remove this location from the destination list
        DestinationList.Remove(Location)

        MyBase.Destroy()
    End Sub

End Class

Public Class ParkingGarageBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        MyBase.AffectPerson(thePerson)

        '-- Parking lot gives you a 1/3 chance of visiting each building on this location an extra time.
        For i As Integer = 0 To Location.Buildings.Count - 1
            If Location.Buildings(i).Type <> BuildingGen.BuildingEnum.Parking_Garage And GetRandom(1, 100) <= 33 Then
                Location.Buildings(i).AffectPerson(thePerson)
            End If
        Next
    End Sub
End Class

Public Class ParkingLotBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        MyBase.AffectPerson(thePerson)

        '-- Parking lot gives you a 2/3 chance of visiting a random building on this location an extra time.
        If GetRandom(1, 100) <= 67 Then
            Dim BuildingIndex As Integer = GetRandom(0, Location.Buildings.Count - 1)
            If Location.Buildings(BuildingIndex).Type <> BuildingGen.BuildingEnum.Parking_Lot Then
                Location.Buildings(BuildingIndex).AffectPerson(thePerson)
            End If
        End If
    End Sub
End Class

Public Class SafeHouseBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub UpdateEndurance(ByRef Endurance As Integer, ByRef thePerson As Person)
        '-- Safe house has a chance to add criminality to current endurance, but only up to the sum of the two
        If GetRandom(1, 100) <= 30 Then
            Endurance = Math.Min(Endurance + thePerson.Criminality, thePerson.Mobility + thePerson.Criminality)
            thePerson.AddEvent("Laid low at safe house before continuing on")
        End If
    End Sub

End Class

Public Class SidewalkBuilding
    Inherits Building

    Public Const EnduranceBoost As Integer = 3

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub UpdateEndurance(ByRef Endurance As Integer, ByRef thePerson As Person)
        '-- Gas station restores up to 3 endurance, but not to exceed the person's starting mobility plus 3
        Endurance = Math.Min(Endurance + EnduranceBoost, thePerson.Mobility + EnduranceBoost)
        thePerson.AddEvent("Strolled along the sidewalk")
    End Sub

End Class

Public Class TaxiBuilding
    Inherits Building

    Public Const MaxTaxiTrips As Integer = 3

    Public Shared DestinationList As New List(Of CitySquare)

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SetRange(3) '-- Default taxi range is 3
    End Sub

    Public Overrides Function GetAdjacentLocations() As List(Of CitySquare)

        '-- The more successful this taxi service, the more taxi trips you can take
        Dim TaxiTrips As Integer = GetRandom(1, Math.Min(MaxTaxiTrips, Jobs))

        Dim CurrentRange As Integer = GetRange()

        '-- Taxi service can connects you to random location in range 3
        Dim ValidDestinationList As New List(Of CitySquare)
        For i As Integer = 0 To 10
            Dim RandomRow As Integer = GetRandom(-CurrentRange, CurrentRange)
            Dim RandomCol As Integer = GetRandom(-CurrentRange, CurrentRange)

            Dim TaxiDestination As CitySquare = GetCitySquare(RandomRow, RandomCol)
            If TaxiDestination IsNot Nothing Then
                Dim CurrentDistance As Integer = Location.GetDistance(TaxiDestination)
                If TaxiDestination.IsOwned() And CurrentDistance > 1 And CurrentDistance < CurrentRange Then
                    ValidDestinationList.Add(TaxiDestination)

                    If ValidDestinationList.Count >= TaxiTrips Then
                        '-- If the full number of taxi trips were found, time to exit
                        Exit For
                    End If
                End If
            End If
        Next
        Return ValidDestinationList
    End Function

End Class

Public Class TollBoothBuilding
    Inherits Building

    Public TollList As New List(Of Person)

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub UpdateEndurance(ByRef Endurance As Integer, ByRef thePerson As Person)

        Dim MaxTollCost As Integer = Location.Transportation

        '-- Toll Booth slows people down
        Endurance -= MaxTollCost

        '-- But you get income from it
        Dim TollCost As Integer = GetRandom(0, MaxTollCost)
        If Not TollList.Contains(thePerson) And TollCost > 0 Then
            TollList.Add(thePerson)

            thePerson.UnpaidFines += TollCost
            thePerson.AddEvent("Paid toll of $" + TollCost.ToString())
        End If

    End Sub

    Public Overrides Sub ResetBuilding()
        TollList.Clear()
    End Sub

End Class
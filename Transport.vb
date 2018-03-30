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
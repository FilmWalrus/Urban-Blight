Public Class PowerPlantBuilding
    Inherits Building

    Public RequiredTerrain As Integer = -1
    Public PowerLevel As Integer = 5

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(1)
        'EffectText = "buildings powered"
    End Sub

    Public Sub ChangePowerLevel(Optional ByVal Increase As Boolean = True)
        '-- Most power plants only work on certain terrain types
        If RequiredTerrain >= 0 Then
            If RequiredTerrain = TerrainEnum.Lake Then
                If Not Location.Coastal Then
                    Return
                End If
            ElseIf RequiredTerrain <> Location.Terrain Then
                Return
            End If
        End If

        Dim PowerChange As Integer = PowerLevel
        If Not Increase Then
            PowerChange = -PowerLevel
        End If

        '-- Increase the power level of city squares within range
        Dim LocationsInRange As New List(Of CitySquare)
        Location.GetLocationsInRange(GetRange(), LocationsInRange)
        For Each thisLocation As CitySquare In LocationsInRange
            thisLocation.PowerCount += PowerChange
        Next
    End Sub

    Public Overrides Sub ConstructionEffects()
        ChangePowerLevel(True)

        MyBase.ConstructionEffects()
    End Sub

    Public Overrides Sub Destroy()
        ChangePowerLevel(False)

        MyBase.Destroy()
    End Sub

End Class

Public Class CoalPowerBuilding
    Inherits PowerPlantBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(2)
        RequiredTerrain = TerrainEnum.Mountain
        PowerLevel = 10
    End Sub

End Class

Public Class GasPowerBuilding
    Inherits PowerPlantBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(3)
        RequiredTerrain = TerrainEnum.Dirt
        PowerLevel = 4
    End Sub

End Class

Public Class HydroPowerBuilding
    Inherits PowerPlantBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(1)
        RequiredTerrain = TerrainEnum.Lake
        PowerLevel = 12
    End Sub

End Class

Public Class NuclearPowerBuilding
    Inherits PowerPlantBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(3)
        RequiredTerrain = -1
        PowerLevel = 8
    End Sub

    Public Overrides Sub UpdateInternal(ByRef DestroyList As List(Of Building))
        MyBase.UpdateInternal(DestroyList)

        If GetRandom(1, 300) = 1 Then
            Diary.SpecialBuildingEvents.AddEventNoLimit("Nuclear meltdown destroys everything at " + Location.GetName())

            '-- Nuclear meltdown kills everyone in city
            Dim MeltdownCasualties As New List(Of Citizen)
            For i As Integer = 0 To Location.People.Count - 1
                MeltdownCasualties.Add(Location.People(i))
            Next
            For i As Integer = 0 To MeltdownCasualties.Count - 1
                MeltdownCasualties(i).Die(DeathEnum.NuclearMeltdown)
            Next

            '-- Destroy all the buildings at this location
            For Each theBuilding As Building In Location.Buildings
                DestroyList.Add(theBuilding)
            Next

            '-- Destroy all roads
            Location.Transportation = RoadEnum.None
        End If
    End Sub

End Class

Public Class SolarPowerBuilding
    Inherits PowerPlantBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(1)
        RequiredTerrain = TerrainEnum.Desert
        PowerLevel = 3
    End Sub

End Class

Public Class WindPowerBuilding
    Inherits PowerPlantBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        SetRange(1)
        RequiredTerrain = TerrainEnum.Plain
        PowerLevel = 5
    End Sub

End Class

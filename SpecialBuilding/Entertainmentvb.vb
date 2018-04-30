Public Class AmusementBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
        EffectText = "children amused"
    End Sub

    Public Overrides Sub AffectStat(ByVal StatType As Integer, ByRef thePerson As Citizen)
        Dim StatOdds As Integer = GetStatOdds(StatType)

        '-- Double the odds of affecting minors
        If thePerson.IsMinor() Then
            StatOdds *= 2.0
        End If

        If StatOdds > 0 Then
            If GetRandom(0, 100) <= StatOdds Then
                Dim statChange As Integer = GetStatChange(GetStatAdjust(StatType))
                thePerson.OffsetStat(StatType, statChange, "Visited " + GetName())

                If thePerson.IsMinor() Then
                    AddEffects(1)
                End If
            End If
        End If
    End Sub
End Class

Public Class CasinoBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
    End Sub

    Public Overrides Function CollectRevenue() As Integer
        '-- Casino revenue is much higher than regular buildings
        AddRevenue(SafeDivide(CurrentVisitors, 1.0))
        Return CurrentRevenue
    End Function
End Class

Public Class MallBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
    End Sub

    Public Overrides Function GetStatOdds(ByVal StatType As Integer) As Integer
        If StatType = StatEnum.Happiness Then
            If Location IsNot Nothing Then
                Dim DevelopmentBonus As Integer = (Location.getDevelopment() - 1) * 3
                Return MyBase.GetStatOdds(StatType) + DevelopmentBonus
            End If
        End If
        Return MyBase.GetStatOdds(StatType)
    End Function
End Class

Public Class SkiResortBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(bType, bCost, bJobs, bMinAge)
    End Sub

    Public Overrides Function GetStatOdds(ByVal StatType As Integer) As Integer
        If Location IsNot Nothing Then
            If Location.Terrain <> TerrainEnum.Mountain Then
                Return 0
            End If
        End If
        Return MyBase.GetStatOdds(StatType)
    End Function

    Public Overrides Sub AffectPerson(ByRef thePerson As Citizen)
        '-- Only affect citizens if built on mountain
        If Location.Terrain = TerrainEnum.Mountain Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub

    Public Overrides Function WillHire(ByRef Candidate As Citizen) As Boolean
        '-- Only hire citizens if built on mountain
        If Location.Terrain = TerrainEnum.Mountain Then
            Return MyBase.WillHire(Candidate)
        Else
            Return False
        End If
    End Function
End Class
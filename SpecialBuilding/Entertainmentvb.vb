Public Class AmusementBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
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

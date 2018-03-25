Public Class DayCareBuilding
    Inherits Building

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        If thePerson.Age <= 16 Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub

End Class

Public Class RetirementBuilding
    Inherits Building

    Public Overrides Sub AffectPerson(ByRef thePerson As Person)
        If thePerson.Age > 50 Then
            MyBase.AffectPerson(thePerson)
        End If
    End Sub

End Class

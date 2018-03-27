Public Class EventDiary

#Region " Variables "

    Private EventString As String = ""

    Public TaxEvents As String = ""
    Public AIEvents As String = ""
    Public BirthEvents As String = ""
    Public DeathEvents As String = ""
    Public MoveEvents As String = ""
    Public ExpansionEvents As String = ""
    Public HireEvents As String = ""
    Public CrimeEvents As String = ""
    Public SpecialBuildingEvents As String = ""


#End Region

#Region " Functions "

    Public Sub ClearEvents()
        EventString = ""

        TaxEvents = ""
        AIEvents = ""
        BirthEvents = ""
        DeathEvents = ""
        CrimeEvents = ""
        MoveEvents = ""
        HireEvents = ""
        ExpansionEvents = ""
        SpecialBuildingEvents = ""
    End Sub

    Public Sub PrintEvent(ByVal thisEvent As String, ByVal Optional lineBreak As Boolean = False)
        If thisEvent.Length > 0 Then
            EventString += thisEvent
            If lineBreak Then
                EventString += ControlChars.NewLine
            End If
        End If
    End Sub

    Public Overrides Function toString() As String

        PrintEvent(TaxEvents, True)

        PrintEvent(AIEvents, True)

        PrintEvent(BirthEvents, True)

        PrintEvent(DeathEvents, True)

        PrintEvent(MoveEvents, True)

        PrintEvent(CrimeEvents, True)

        PrintEvent(HireEvents)
        PrintEvent(ExpansionEvents)
        PrintEvent(SpecialBuildingEvents, True)

        Return EventString

    End Function

#End Region

End Class

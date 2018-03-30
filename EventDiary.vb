Public Class DiaryPage

    Public diaryText As String = ""
    Public defaultText As String = ""
    Public lineCount As Integer = 0

    Sub New(ByVal theDefault As String)
        defaultText = theDefault
    End Sub

    Sub AddEvent(ByVal theText As String)
        lineCount += 1
        If lineCount < EventLimit Then
            diaryText += theText + "." + ControlChars.NewLine
        End If
    End Sub

    Sub AddEventNoLimit(ByVal theText As String)
        diaryText += theText + "." + ControlChars.NewLine
    End Sub

    Sub ClearPage()
        lineCount = 0
        diaryText = ""
    End Sub


    Public Overrides Function toString() As String
        If lineCount < EventLimit Then
            Return diaryText
        Else
            Return lineCount.ToString() + " " + defaultText + ControlChars.NewLine
        End If
    End Function

End Class

Public Class AIDiaryPage
    Inherits DiaryPage

    Sub New(ByVal theDefault As String)
        MyBase.New(theDefault)
    End Sub

    Public Overrides Function toString() As String
        If lineCount < EventLimit Then
            Return diaryText
        Else
            Dim defaultCopy As String = defaultText
            defaultCopy.Replace("@", lineCount.ToString())
            Return defaultText + ControlChars.NewLine
        End If

    End Function
End Class

Public Class EventDiary

#Region " Variables "

    Private EventString As String = ""

    Public ExpansionEvents As New DiaryPage("businesses expanded.")

    Public BirthEvents As New DiaryPage("citizens had children.")
    Public TwinEvents As New DiaryPage("citizens had twins.")

    Public RescueEvents As New DiaryPage("lives were saved by hospitals.")
    Public DeathNaturalEvents As New DiaryPage("citizens died of natural causes.")
    Public DeathIllnessEvents As New DiaryPage("citizens died of illness.")
    Public DeathTrafficEvents As New DiaryPage("citizens died in traffic accidents.")

    Public MoveEvents As New DiaryPage("citizens moved.")
    Public EmigrationEvents As New DiaryPage("citizens emigrated.")

    Public HireEvents As New DiaryPage("citizens got new jobs.")
    Public SpecialBuildingEvents As New DiaryPage("")

    Public TheftEvents As New DiaryPage("citizens stole from you.")
    Public ArsonEvents As New DiaryPage("buildings were torched.")
    Public MurderEvents As New DiaryPage("citizens were murdered.")

    Public TaxEvents As New DiaryPage("")

    Public AILandEvents As New DiaryPage("AI founded @ new cities")
    Public AIBuildEvents As New DiaryPage("AI created @ new buildings")
    Public AIRoadEvents As New DiaryPage("AI upgraded roads @ times")

    Public SectionHasContent As Boolean = False

#End Region

#Region " Functions "

    Public Sub ClearEvents()
        SectionHasContent = False
        EventString = ""

        ExpansionEvents.ClearPage()

        BirthEvents.ClearPage()
        TwinEvents.ClearPage()

        RescueEvents.ClearPage()
        DeathNaturalEvents.ClearPage()
        DeathIllnessEvents.ClearPage()
        DeathTrafficEvents.ClearPage()

        MoveEvents.ClearPage()
        EmigrationEvents.ClearPage()

        HireEvents.ClearPage()
        SpecialBuildingEvents.ClearPage()

        TheftEvents.ClearPage()
        ArsonEvents.ClearPage()
        MurderEvents.ClearPage()

        TaxEvents.ClearPage()

        AILandEvents.ClearPage()
        AIBuildEvents.ClearPage()
        AIRoadEvents.ClearPage()
    End Sub

    Public Sub PrintEvent(ByVal thisEvent As String, ByVal Optional lineBreak As Boolean = False)
        If thisEvent.Length > 0 Then
            SectionHasContent = True
            EventString += thisEvent
        End If

        '-- Start a new section, but only if the previous section actually had text
        If lineBreak And SectionHasContent Then
            EventString += ControlChars.NewLine
            SectionHasContent = False
        End If
    End Sub

    Public Overrides Function toString() As String

        PrintEvent(TaxEvents.toString, True)

        PrintEvent(AILandEvents.toString())
        PrintEvent(AIBuildEvents.toString())
        PrintEvent(AIRoadEvents.toString(), True)

        PrintEvent(BirthEvents.toString)
        PrintEvent(TwinEvents.toString, True)

        PrintEvent(RescueEvents.toString())
        PrintEvent(DeathNaturalEvents.toString())
        PrintEvent(DeathIllnessEvents.toString())
        PrintEvent(DeathTrafficEvents.toString(), True)

        PrintEvent(EmigrationEvents.toString())
        PrintEvent(MoveEvents.toString(), True)

        PrintEvent(TheftEvents.toString())
        PrintEvent(ArsonEvents.toString())
        PrintEvent(MurderEvents.toString(), True)

        PrintEvent(SpecialBuildingEvents.toString())
        PrintEvent(ExpansionEvents.toString())
        PrintEvent(HireEvents.toString(), True)

        Return EventString

    End Function

#End Region

End Class



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
            Dim defaultCopy As String = defaultText.Replace("@", lineCount.ToString())
            Return defaultCopy + ControlChars.NewLine
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
    Public SelfEmployEvents As New DiaryPage("citizens self-employed.")
    Public CultEvents As New DiaryPage("lured in by cults")
    Public SpecialBuildingEvents As New DiaryPage("")

    Public CrimesPeventedEvents As New DiaryPage("crimes prevented")
    Public ResistingArrestEvents As New DiaryPage("criminals died resisting arrest.")
    Public TheftEvents As New DiaryPage("citizens stole public funds.")
    Public ArsonEvents As New DiaryPage("buildings torched.")
    Public VandalismEvents As New DiaryPage("buildings vandalized.")
    Public MurderEvents As New DiaryPage("citizens murdered.")

    Public TaxEvents As New DiaryPage("")

    Public AILandEvents As New AIDiaryPage("AI founded @ new cities")
    Public AIBuildEvents As New AIDiaryPage("AI created @ new buildings")
    Public AIRoadEvents As New AIDiaryPage("AI upgraded roads @ times")

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
        SelfEmployEvents.ClearPage()
        CultEvents.ClearPage()
        SpecialBuildingEvents.ClearPage()

        CrimesPeventedEvents.ClearPage()
        ResistingArrestEvents.ClearPage()
        TheftEvents.ClearPage()
        VandalismEvents.ClearPage()
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

        PrintEvent(CrimesPeventedEvents.toString())
        PrintEvent(ResistingArrestEvents.toString())
        PrintEvent(TheftEvents.toString())
        PrintEvent(VandalismEvents.toString())
        PrintEvent(ArsonEvents.toString())
        PrintEvent(MurderEvents.toString(), True)

        PrintEvent(SpecialBuildingEvents.toString())
        PrintEvent(ExpansionEvents.toString())
        PrintEvent(CultEvents.toString(), True)

        PrintEvent(SelfEmployEvents.toString())
        PrintEvent(HireEvents.toString(), True)


        Return EventString

    End Function

#End Region

End Class



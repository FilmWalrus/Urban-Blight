Public Class PollingScreen

    Public BuildingList As New List(Of Building)
    Public BuildingChoice As Integer = -1

    Public Sub New(ByVal PollCount As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For i As Integer = 0 To PollCount - 1
            Dim BuildingOption As Building = BuildingGenerator.CreateBuilding(-1)
            BuildingList.Add(BuildingOption)
            PollCombo.Items.Add(BuildingOption.GetName())
        Next

        '-- Initialize the GUI with a random option among those available
        Dim RandomChoice As Integer = GetRandom(0, PollCount - 1)
        PollCombo.SelectedIndex = RandomChoice
    End Sub

    Private Sub PollingScreenvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildingChoice = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PollCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PollCombo.SelectedIndexChanged
        Dim BuildingSelectionID As Integer = PollCombo.SelectedIndex
        Dim SelectedBuilding As Building = BuildingList(BuildingSelectionID)

        '-- Display selected building description
        Dim BuildingDescription As String = SelectedBuilding.toString()
        BuildingDescriptionTextbox.Text = BuildingDescription

        BuildingChoice = SelectedBuilding.Type
    End Sub
End Class
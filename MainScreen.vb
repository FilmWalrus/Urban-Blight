Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Variables "
    '-- Location Variables
    Dim LeftStart As Integer = 16
    Dim LeftIncrement As Integer = 48
    Dim TopStart As Integer = 32
    Dim TopIncrement As Integer = 48
    '--
    Dim Points As New ArrayList
    Dim BigFont As Integer = 12
    Dim SmallFont As Integer = 10
    '--
    Dim LastClickedX As Integer = 0
    Dim LastClickedY As Integer = 0
    '--
    Dim Players As ArrayList
    Dim CurrentPlayer As Player = Nothing
    Dim CurrentPlayerIndex As Integer = 0
    Dim WinFlag As Boolean = False
    '--
    Dim StartPop As Integer = 4
    Dim CardCount As Integer = 4
    Dim Cards As New ArrayList
    Dim RoadCard As Integer = 4
    Dim LandCard As Integer = 5
    Dim SelectedCard As Integer = -1
    Dim LandCost As Integer = 0
    Dim RoadCost As Integer = 50
    '--
    Dim CurrentPerson As Integer = -1
    Dim CurrentView As Integer = 0

    '--
    Dim theYear As Integer = 1
    '--
    Dim EventString As String = ""

    Friend WithEvents UltraTab1 As TabControl
    Friend WithEvents UltraTab2 As TabControl
    Friend WithEvents UltraTab3 As TabControl
    Friend WithEvents UltraTab4 As TabControl
    Friend WithEvents UltraTab5 As TabControl
    Friend WithEvents UltraTab6 As TabControl
    '--
    Dim init As Boolean = False

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ubcard1 As System.Windows.Forms.Button
    Friend WithEvents ubcard2 As System.Windows.Forms.Button
    Friend WithEvents ubcard3 As System.Windows.Forms.Button
    Friend WithEvents ubcard4 As System.Windows.Forms.Button
    Friend WithEvents gbP1 As GroupBox
    Friend WithEvents gbP2 As GroupBox
    Friend WithEvents gbP3 As GroupBox
    Friend WithEvents gbP4 As GroupBox
    Friend WithEvents UltraTabSharedControlsPage1 As TabPage
    Friend WithEvents Infotab As TabControl
    Friend WithEvents UltraTabPageControl1 As TabPage
    Friend WithEvents UltraTabPageControl2 As TabPage
    Friend WithEvents UltraTabPageControl3 As TabPage
    Friend WithEvents UltraTabPageControl4 As TabPage
    Friend WithEvents txt_event As System.Windows.Forms.TextBox
    Friend WithEvents txt_card As System.Windows.Forms.TextBox
    Friend WithEvents txt_person As System.Windows.Forms.TextBox
    Friend WithEvents txt_city As System.Windows.Forms.TextBox
    Friend WithEvents ubBack As System.Windows.Forms.Button
    Friend WithEvents ubForward As System.Windows.Forms.Button
    Friend WithEvents lblPerson As Label
    Friend WithEvents txtP1 As System.Windows.Forms.TextBox
    Friend WithEvents txtP2 As System.Windows.Forms.TextBox
    Friend WithEvents txtP3 As System.Windows.Forms.TextBox
    Friend WithEvents txtP4 As System.Windows.Forms.TextBox
    Friend WithEvents ubroad As System.Windows.Forms.Button
    Friend WithEvents ubland As System.Windows.Forms.Button
    Friend WithEvents ubEnd As System.Windows.Forms.Button
    Friend WithEvents UltraTabPageControl5 As TabPage
    Friend WithEvents ubPopView As System.Windows.Forms.Button
    Friend WithEvents ubLocView As System.Windows.Forms.Button
    Friend WithEvents ubCriminality As System.Windows.Forms.Button
    Friend WithEvents ubMobility As System.Windows.Forms.Button
    Friend WithEvents ubDrunkenness As System.Windows.Forms.Button
    Friend WithEvents ubCreativity As System.Windows.Forms.Button
    Friend WithEvents ubIntelligence As System.Windows.Forms.Button
    Friend WithEvents ubEmployment As System.Windows.Forms.Button
    Friend WithEvents ubHealth As System.Windows.Forms.Button
    Friend WithEvents ubHappiness As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ubJobView As System.Windows.Forms.Button
    Friend WithEvents ubRoads As System.Windows.Forms.Button
    Friend WithEvents lblYear As Label
    Friend WithEvents lblView As Label
    Friend WithEvents lblGoal As Label
    Friend WithEvents ubName As System.Windows.Forms.Button
    Friend WithEvents UltraTabPageControl6 As TabPage
    Friend WithEvents ubNew As System.Windows.Forms.Button
    Friend WithEvents ubQuit As System.Windows.Forms.Button
    Friend WithEvents ubHint As System.Windows.Forms.Button
    Friend WithEvents txtHint As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.UltraTab1 = New System.Windows.Forms.TabControl()
        Me.UltraTabPageControl1 = New System.Windows.Forms.TabPage()
        Me.txt_event = New System.Windows.Forms.TextBox()
        Me.UltraTab2 = New System.Windows.Forms.TabControl()
        Me.UltraTabPageControl2 = New System.Windows.Forms.TabPage()
        Me.txt_card = New System.Windows.Forms.TextBox()
        Me.UltraTab3 = New System.Windows.Forms.TabControl()
        Me.UltraTabPageControl3 = New System.Windows.Forms.TabPage()
        Me.ubName = New System.Windows.Forms.Button()
        Me.txt_city = New System.Windows.Forms.TextBox()
        Me.UltraTab4 = New System.Windows.Forms.TabControl()
        Me.UltraTabPageControl4 = New System.Windows.Forms.TabPage()
        Me.lblPerson = New System.Windows.Forms.Label()
        Me.ubForward = New System.Windows.Forms.Button()
        Me.ubBack = New System.Windows.Forms.Button()
        Me.txt_person = New System.Windows.Forms.TextBox()
        Me.UltraTab5 = New System.Windows.Forms.TabControl()
        Me.UltraTabPageControl5 = New System.Windows.Forms.TabPage()
        Me.ubRoads = New System.Windows.Forms.Button()
        Me.ubJobView = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ubEmployment = New System.Windows.Forms.Button()
        Me.ubHappiness = New System.Windows.Forms.Button()
        Me.ubDrunkenness = New System.Windows.Forms.Button()
        Me.ubIntelligence = New System.Windows.Forms.Button()
        Me.ubCreativity = New System.Windows.Forms.Button()
        Me.ubCriminality = New System.Windows.Forms.Button()
        Me.ubMobility = New System.Windows.Forms.Button()
        Me.ubHealth = New System.Windows.Forms.Button()
        Me.ubLocView = New System.Windows.Forms.Button()
        Me.ubPopView = New System.Windows.Forms.Button()
        Me.UltraTab6 = New System.Windows.Forms.TabControl()
        Me.UltraTabPageControl6 = New System.Windows.Forms.TabPage()
        Me.txtHint = New System.Windows.Forms.TextBox()
        Me.ubHint = New System.Windows.Forms.Button()
        Me.ubQuit = New System.Windows.Forms.Button()
        Me.ubNew = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ubcard1 = New System.Windows.Forms.Button()
        Me.ubcard2 = New System.Windows.Forms.Button()
        Me.ubcard3 = New System.Windows.Forms.Button()
        Me.ubcard4 = New System.Windows.Forms.Button()
        Me.ubroad = New System.Windows.Forms.Button()
        Me.gbP1 = New System.Windows.Forms.GroupBox()
        Me.txtP1 = New System.Windows.Forms.TextBox()
        Me.gbP2 = New System.Windows.Forms.GroupBox()
        Me.txtP2 = New System.Windows.Forms.TextBox()
        Me.gbP4 = New System.Windows.Forms.GroupBox()
        Me.txtP4 = New System.Windows.Forms.TextBox()
        Me.gbP3 = New System.Windows.Forms.GroupBox()
        Me.txtP3 = New System.Windows.Forms.TextBox()
        Me.Infotab = New System.Windows.Forms.TabControl()
        Me.ubland = New System.Windows.Forms.Button()
        Me.ubEnd = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblView = New System.Windows.Forms.Label()
        Me.lblGoal = New System.Windows.Forms.Label()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.UltraTabPageControl5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        Me.gbP1.SuspendLayout()
        Me.gbP2.SuspendLayout()
        Me.gbP4.SuspendLayout()
        Me.gbP3.SuspendLayout()
        Me.Infotab.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTab1
        '
        Me.UltraTab1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTab1.Name = "UltraTab1"
        Me.UltraTab1.SelectedIndex = 0
        Me.UltraTab1.Size = New System.Drawing.Size(200, 100)
        Me.UltraTab1.TabIndex = 0
        Me.UltraTab1.Text = "Events"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.txt_event)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(4, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(272, 326)
        Me.UltraTabPageControl1.TabIndex = 0
        Me.UltraTabPageControl1.Text = "Events"
        '
        'txt_event
        '
        Me.txt_event.AcceptsReturn = True
        Me.txt_event.AcceptsTab = True
        Me.txt_event.Location = New System.Drawing.Point(16, 16)
        Me.txt_event.Multiline = True
        Me.txt_event.Name = "txt_event"
        Me.txt_event.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_event.Size = New System.Drawing.Size(248, 296)
        Me.txt_event.TabIndex = 1
        '
        'UltraTab2
        '
        Me.UltraTab2.Location = New System.Drawing.Point(0, 0)
        Me.UltraTab2.Name = "UltraTab2"
        Me.UltraTab2.SelectedIndex = 0
        Me.UltraTab2.Size = New System.Drawing.Size(200, 100)
        Me.UltraTab2.TabIndex = 0
        Me.UltraTab2.Text = "Card"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txt_card)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(4, 22)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(272, 326)
        Me.UltraTabPageControl2.TabIndex = 0
        Me.UltraTabPageControl2.Text = "Card"
        '
        'txt_card
        '
        Me.txt_card.AcceptsReturn = True
        Me.txt_card.AcceptsTab = True
        Me.txt_card.Location = New System.Drawing.Point(16, 15)
        Me.txt_card.Multiline = True
        Me.txt_card.Name = "txt_card"
        Me.txt_card.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_card.Size = New System.Drawing.Size(248, 297)
        Me.txt_card.TabIndex = 1
        '
        'UltraTab3
        '
        Me.UltraTab3.Location = New System.Drawing.Point(0, 0)
        Me.UltraTab3.Name = "UltraTab3"
        Me.UltraTab3.SelectedIndex = 0
        Me.UltraTab3.Size = New System.Drawing.Size(200, 100)
        Me.UltraTab3.TabIndex = 0
        Me.UltraTab3.Text = "City"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.ubName)
        Me.UltraTabPageControl3.Controls.Add(Me.txt_city)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(4, 22)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(272, 326)
        Me.UltraTabPageControl3.TabIndex = 0
        Me.UltraTabPageControl3.Text = "City"
        '
        'ubName
        '
        Me.ubName.Location = New System.Drawing.Point(208, 24)
        Me.ubName.Name = "ubName"
        Me.ubName.Size = New System.Drawing.Size(48, 24)
        Me.ubName.TabIndex = 21
        Me.ubName.Text = "Name"
        '
        'txt_city
        '
        Me.txt_city.AcceptsReturn = True
        Me.txt_city.AcceptsTab = True
        Me.txt_city.Location = New System.Drawing.Point(16, 15)
        Me.txt_city.Multiline = True
        Me.txt_city.Name = "txt_city"
        Me.txt_city.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_city.Size = New System.Drawing.Size(248, 297)
        Me.txt_city.TabIndex = 1
        '
        'UltraTab4
        '
        Me.UltraTab4.Location = New System.Drawing.Point(0, 0)
        Me.UltraTab4.Name = "UltraTab4"
        Me.UltraTab4.SelectedIndex = 0
        Me.UltraTab4.Size = New System.Drawing.Size(200, 100)
        Me.UltraTab4.TabIndex = 0
        Me.UltraTab4.Text = "Person"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.lblPerson)
        Me.UltraTabPageControl4.Controls.Add(Me.ubForward)
        Me.UltraTabPageControl4.Controls.Add(Me.ubBack)
        Me.UltraTabPageControl4.Controls.Add(Me.txt_person)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(4, 22)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(272, 326)
        Me.UltraTabPageControl4.TabIndex = 0
        Me.UltraTabPageControl4.Text = "Person"
        '
        'lblPerson
        '
        Me.lblPerson.Location = New System.Drawing.Point(16, 296)
        Me.lblPerson.Name = "lblPerson"
        Me.lblPerson.Size = New System.Drawing.Size(136, 16)
        Me.lblPerson.TabIndex = 4
        Me.lblPerson.Text = "Displaying X of Y"
        '
        'ubForward
        '
        Me.ubForward.Location = New System.Drawing.Point(216, 296)
        Me.ubForward.Name = "ubForward"
        Me.ubForward.Size = New System.Drawing.Size(48, 23)
        Me.ubForward.TabIndex = 3
        Me.ubForward.Text = ">>>"
        '
        'ubBack
        '
        Me.ubBack.Location = New System.Drawing.Point(160, 296)
        Me.ubBack.Name = "ubBack"
        Me.ubBack.Size = New System.Drawing.Size(48, 23)
        Me.ubBack.TabIndex = 2
        Me.ubBack.Text = "<<<"
        '
        'txt_person
        '
        Me.txt_person.AcceptsReturn = True
        Me.txt_person.AcceptsTab = True
        Me.txt_person.Location = New System.Drawing.Point(16, 16)
        Me.txt_person.Multiline = True
        Me.txt_person.Name = "txt_person"
        Me.txt_person.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_person.Size = New System.Drawing.Size(248, 264)
        Me.txt_person.TabIndex = 1
        '
        'UltraTab5
        '
        Me.UltraTab5.Location = New System.Drawing.Point(0, 0)
        Me.UltraTab5.Name = "UltraTab5"
        Me.UltraTab5.SelectedIndex = 0
        Me.UltraTab5.Size = New System.Drawing.Size(200, 100)
        Me.UltraTab5.TabIndex = 0
        Me.UltraTab5.Text = "View"
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.ubRoads)
        Me.UltraTabPageControl5.Controls.Add(Me.ubJobView)
        Me.UltraTabPageControl5.Controls.Add(Me.GroupBox1)
        Me.UltraTabPageControl5.Controls.Add(Me.ubLocView)
        Me.UltraTabPageControl5.Controls.Add(Me.ubPopView)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(4, 22)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(272, 326)
        Me.UltraTabPageControl5.TabIndex = 0
        Me.UltraTabPageControl5.Text = "View"
        '
        'ubRoads
        '
        Me.ubRoads.Location = New System.Drawing.Point(16, 72)
        Me.ubRoads.Name = "ubRoads"
        Me.ubRoads.Size = New System.Drawing.Size(112, 32)
        Me.ubRoads.TabIndex = 17
        Me.ubRoads.Text = "Roads"
        '
        'ubJobView
        '
        Me.ubJobView.Location = New System.Drawing.Point(152, 24)
        Me.ubJobView.Name = "ubJobView"
        Me.ubJobView.Size = New System.Drawing.Size(112, 32)
        Me.ubJobView.TabIndex = 16
        Me.ubJobView.Text = "Jobs"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSlateGray
        Me.GroupBox1.Controls.Add(Me.ubEmployment)
        Me.GroupBox1.Controls.Add(Me.ubHappiness)
        Me.GroupBox1.Controls.Add(Me.ubDrunkenness)
        Me.GroupBox1.Controls.Add(Me.ubIntelligence)
        Me.GroupBox1.Controls.Add(Me.ubCreativity)
        Me.GroupBox1.Controls.Add(Me.ubCriminality)
        Me.GroupBox1.Controls.Add(Me.ubMobility)
        Me.GroupBox1.Controls.Add(Me.ubHealth)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 184)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Averages"
        '
        'ubEmployment
        '
        Me.ubEmployment.Location = New System.Drawing.Point(16, 64)
        Me.ubEmployment.Name = "ubEmployment"
        Me.ubEmployment.Size = New System.Drawing.Size(96, 23)
        Me.ubEmployment.TabIndex = 11
        Me.ubEmployment.Text = "Employment"
        '
        'ubHappiness
        '
        Me.ubHappiness.Location = New System.Drawing.Point(16, 24)
        Me.ubHappiness.Name = "ubHappiness"
        Me.ubHappiness.Size = New System.Drawing.Size(96, 23)
        Me.ubHappiness.TabIndex = 13
        Me.ubHappiness.Text = "Happiness"
        '
        'ubDrunkenness
        '
        Me.ubDrunkenness.Location = New System.Drawing.Point(16, 144)
        Me.ubDrunkenness.Name = "ubDrunkenness"
        Me.ubDrunkenness.Size = New System.Drawing.Size(96, 23)
        Me.ubDrunkenness.TabIndex = 8
        Me.ubDrunkenness.Text = "Drunkenness"
        '
        'ubIntelligence
        '
        Me.ubIntelligence.Location = New System.Drawing.Point(136, 64)
        Me.ubIntelligence.Name = "ubIntelligence"
        Me.ubIntelligence.Size = New System.Drawing.Size(96, 23)
        Me.ubIntelligence.TabIndex = 10
        Me.ubIntelligence.Text = "Intelligence"
        '
        'ubCreativity
        '
        Me.ubCreativity.Location = New System.Drawing.Point(16, 104)
        Me.ubCreativity.Name = "ubCreativity"
        Me.ubCreativity.Size = New System.Drawing.Size(96, 23)
        Me.ubCreativity.TabIndex = 9
        Me.ubCreativity.Text = "Creativity"
        '
        'ubCriminality
        '
        Me.ubCriminality.Location = New System.Drawing.Point(136, 144)
        Me.ubCriminality.Name = "ubCriminality"
        Me.ubCriminality.Size = New System.Drawing.Size(96, 23)
        Me.ubCriminality.TabIndex = 6
        Me.ubCriminality.Text = "Criminality"
        '
        'ubMobility
        '
        Me.ubMobility.Location = New System.Drawing.Point(136, 104)
        Me.ubMobility.Name = "ubMobility"
        Me.ubMobility.Size = New System.Drawing.Size(96, 23)
        Me.ubMobility.TabIndex = 7
        Me.ubMobility.Text = "Mobility"
        '
        'ubHealth
        '
        Me.ubHealth.Location = New System.Drawing.Point(136, 24)
        Me.ubHealth.Name = "ubHealth"
        Me.ubHealth.Size = New System.Drawing.Size(96, 23)
        Me.ubHealth.TabIndex = 12
        Me.ubHealth.Text = "Health"
        '
        'ubLocView
        '
        Me.ubLocView.Location = New System.Drawing.Point(152, 72)
        Me.ubLocView.Name = "ubLocView"
        Me.ubLocView.Size = New System.Drawing.Size(112, 32)
        Me.ubLocView.TabIndex = 5
        Me.ubLocView.Text = "Location"
        '
        'ubPopView
        '
        Me.ubPopView.Location = New System.Drawing.Point(16, 24)
        Me.ubPopView.Name = "ubPopView"
        Me.ubPopView.Size = New System.Drawing.Size(112, 32)
        Me.ubPopView.TabIndex = 4
        Me.ubPopView.Text = "Population"
        '
        'UltraTab6
        '
        Me.UltraTab6.Location = New System.Drawing.Point(0, 0)
        Me.UltraTab6.Name = "UltraTab6"
        Me.UltraTab6.SelectedIndex = 0
        Me.UltraTab6.Size = New System.Drawing.Size(200, 100)
        Me.UltraTab6.TabIndex = 0
        Me.UltraTab6.Text = "Game"
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.txtHint)
        Me.UltraTabPageControl6.Controls.Add(Me.ubHint)
        Me.UltraTabPageControl6.Controls.Add(Me.ubQuit)
        Me.UltraTabPageControl6.Controls.Add(Me.ubNew)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(4, 22)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(272, 326)
        Me.UltraTabPageControl6.TabIndex = 0
        Me.UltraTabPageControl6.Text = "Game"
        '
        'txtHint
        '
        Me.txtHint.AcceptsReturn = True
        Me.txtHint.AcceptsTab = True
        Me.txtHint.Location = New System.Drawing.Point(14, 16)
        Me.txtHint.Multiline = True
        Me.txtHint.Name = "txtHint"
        Me.txtHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHint.Size = New System.Drawing.Size(250, 136)
        Me.txtHint.TabIndex = 19
        '
        'ubHint
        '
        Me.ubHint.Location = New System.Drawing.Point(80, 168)
        Me.ubHint.Name = "ubHint"
        Me.ubHint.Size = New System.Drawing.Size(112, 48)
        Me.ubHint.TabIndex = 18
        Me.ubHint.Text = "Hint"
        '
        'ubQuit
        '
        Me.ubQuit.Location = New System.Drawing.Point(152, 264)
        Me.ubQuit.Name = "ubQuit"
        Me.ubQuit.Size = New System.Drawing.Size(112, 48)
        Me.ubQuit.TabIndex = 17
        Me.ubQuit.Text = "Quit"
        '
        'ubNew
        '
        Me.ubNew.Location = New System.Drawing.Point(16, 264)
        Me.ubNew.Name = "ubNew"
        Me.ubNew.Size = New System.Drawing.Size(112, 48)
        Me.ubNew.TabIndex = 16
        Me.ubNew.Text = "New Game"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 480)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Board"
        Me.Label1.Visible = False
        '
        'ubcard1
        '
        Me.ubcard1.BackColor = System.Drawing.SystemColors.Control
        Me.ubcard1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubcard1.Location = New System.Drawing.Point(512, 32)
        Me.ubcard1.Name = "ubcard1"
        Me.ubcard1.Size = New System.Drawing.Size(136, 48)
        Me.ubcard1.TabIndex = 1
        Me.ubcard1.Text = "Card1"
        Me.ubcard1.UseVisualStyleBackColor = True
        '
        'ubcard2
        '
        Me.ubcard2.Location = New System.Drawing.Point(656, 32)
        Me.ubcard2.Name = "ubcard2"
        Me.ubcard2.Size = New System.Drawing.Size(136, 48)
        Me.ubcard2.TabIndex = 2
        Me.ubcard2.Text = "Card2"
        '
        'ubcard3
        '
        Me.ubcard3.Location = New System.Drawing.Point(512, 96)
        Me.ubcard3.Name = "ubcard3"
        Me.ubcard3.Size = New System.Drawing.Size(136, 48)
        Me.ubcard3.TabIndex = 3
        Me.ubcard3.Text = "Card3"
        '
        'ubcard4
        '
        Me.ubcard4.Location = New System.Drawing.Point(656, 96)
        Me.ubcard4.Name = "ubcard4"
        Me.ubcard4.Size = New System.Drawing.Size(136, 48)
        Me.ubcard4.TabIndex = 4
        Me.ubcard4.Text = "Card4"
        '
        'ubroad
        '
        Me.ubroad.Location = New System.Drawing.Point(512, 168)
        Me.ubroad.Name = "ubroad"
        Me.ubroad.Size = New System.Drawing.Size(136, 32)
        Me.ubroad.TabIndex = 5
        Me.ubroad.Text = "Road, Cost: 50"
        '
        'gbP1
        '
        Me.gbP1.Controls.Add(Me.txtP1)
        Me.gbP1.Location = New System.Drawing.Point(16, 520)
        Me.gbP1.Name = "gbP1"
        Me.gbP1.Size = New System.Drawing.Size(104, 112)
        Me.gbP1.TabIndex = 11
        Me.gbP1.TabStop = False
        Me.gbP1.Text = "Player 1"
        Me.gbP1.Visible = False
        '
        'txtP1
        '
        Me.txtP1.Location = New System.Drawing.Point(8, 16)
        Me.txtP1.Multiline = True
        Me.txtP1.Name = "txtP1"
        Me.txtP1.Size = New System.Drawing.Size(88, 88)
        Me.txtP1.TabIndex = 2
        '
        'gbP2
        '
        Me.gbP2.Controls.Add(Me.txtP2)
        Me.gbP2.Location = New System.Drawing.Point(136, 520)
        Me.gbP2.Name = "gbP2"
        Me.gbP2.Size = New System.Drawing.Size(104, 112)
        Me.gbP2.TabIndex = 12
        Me.gbP2.TabStop = False
        Me.gbP2.Text = "Player 2"
        Me.gbP2.Visible = False
        '
        'txtP2
        '
        Me.txtP2.Location = New System.Drawing.Point(8, 16)
        Me.txtP2.Multiline = True
        Me.txtP2.Name = "txtP2"
        Me.txtP2.Size = New System.Drawing.Size(88, 88)
        Me.txtP2.TabIndex = 3
        '
        'gbP4
        '
        Me.gbP4.Controls.Add(Me.txtP4)
        Me.gbP4.Location = New System.Drawing.Point(376, 520)
        Me.gbP4.Name = "gbP4"
        Me.gbP4.Size = New System.Drawing.Size(104, 112)
        Me.gbP4.TabIndex = 13
        Me.gbP4.TabStop = False
        Me.gbP4.Text = "Player 4"
        Me.gbP4.Visible = False
        '
        'txtP4
        '
        Me.txtP4.Location = New System.Drawing.Point(8, 16)
        Me.txtP4.Multiline = True
        Me.txtP4.Name = "txtP4"
        Me.txtP4.Size = New System.Drawing.Size(88, 88)
        Me.txtP4.TabIndex = 3
        '
        'gbP3
        '
        Me.gbP3.Controls.Add(Me.txtP3)
        Me.gbP3.Location = New System.Drawing.Point(256, 520)
        Me.gbP3.Name = "gbP3"
        Me.gbP3.Size = New System.Drawing.Size(104, 112)
        Me.gbP3.TabIndex = 14
        Me.gbP3.TabStop = False
        Me.gbP3.Text = "Player 3"
        Me.gbP3.Visible = False
        '
        'txtP3
        '
        Me.txtP3.Location = New System.Drawing.Point(8, 16)
        Me.txtP3.Multiline = True
        Me.txtP3.Name = "txtP3"
        Me.txtP3.Size = New System.Drawing.Size(88, 88)
        Me.txtP3.TabIndex = 3
        '
        'Infotab
        '
        Me.Infotab.Controls.Add(Me.UltraTabPageControl1)
        Me.Infotab.Controls.Add(Me.UltraTabPageControl2)
        Me.Infotab.Controls.Add(Me.UltraTabPageControl3)
        Me.Infotab.Controls.Add(Me.UltraTabPageControl4)
        Me.Infotab.Controls.Add(Me.UltraTabPageControl5)
        Me.Infotab.Controls.Add(Me.UltraTabPageControl6)
        Me.Infotab.Location = New System.Drawing.Point(512, 280)
        Me.Infotab.Name = "Infotab"
        Me.Infotab.SelectedIndex = 0
        Me.Infotab.Size = New System.Drawing.Size(280, 352)
        Me.Infotab.TabIndex = 15
        '
        'ubland
        '
        Me.ubland.Location = New System.Drawing.Point(656, 168)
        Me.ubland.Name = "ubland"
        Me.ubland.Size = New System.Drawing.Size(136, 32)
        Me.ubland.TabIndex = 16
        Me.ubland.Text = "Land"
        '
        'ubEnd
        '
        Me.ubEnd.Location = New System.Drawing.Point(568, 224)
        Me.ubEnd.Name = "ubEnd"
        Me.ubEnd.Size = New System.Drawing.Size(168, 32)
        Me.ubEnd.TabIndex = 17
        Me.ubEnd.Text = "END TURN"
        '
        'lblYear
        '
        Me.lblYear.Location = New System.Drawing.Point(16, 8)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(96, 16)
        Me.lblYear.TabIndex = 18
        Me.lblYear.Text = "Year: "
        '
        'lblView
        '
        Me.lblView.Location = New System.Drawing.Point(112, 8)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(184, 16)
        Me.lblView.TabIndex = 19
        Me.lblView.Text = "Current View:"
        '
        'lblGoal
        '
        Me.lblGoal.Location = New System.Drawing.Point(296, 8)
        Me.lblGoal.Name = "lblGoal"
        Me.lblGoal.Size = New System.Drawing.Size(184, 16)
        Me.lblGoal.TabIndex = 20
        Me.lblGoal.Text = "Goal:"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(810, 648)
        Me.Controls.Add(Me.ubEnd)
        Me.Controls.Add(Me.ubland)
        Me.Controls.Add(Me.Infotab)
        Me.Controls.Add(Me.gbP3)
        Me.Controls.Add(Me.gbP4)
        Me.Controls.Add(Me.gbP1)
        Me.Controls.Add(Me.ubroad)
        Me.Controls.Add(Me.ubcard4)
        Me.Controls.Add(Me.ubcard3)
        Me.Controls.Add(Me.ubcard2)
        Me.Controls.Add(Me.ubcard1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbP2)
        Me.Controls.Add(Me.lblView)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblGoal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Urban Blight"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.UltraTabPageControl6.PerformLayout()
        Me.gbP1.ResumeLayout(False)
        Me.gbP1.PerformLayout()
        Me.gbP2.ResumeLayout(False)
        Me.gbP2.PerformLayout()
        Me.gbP4.ResumeLayout(False)
        Me.gbP4.PerformLayout()
        Me.gbP3.ResumeLayout(False)
        Me.gbP3.PerformLayout()
        Me.Infotab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Initialization "
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StartGame()
    End Sub

    Sub StartGame()
        '-- Get player count and game type
        Dim Introduction As New Intro
        If Introduction.ShowDialog() <> DialogResult.OK Then
            Me.DialogResult = DialogResult.No
            Me.Close()
        End If

        Players = New ArrayList(PlayerCount)
        Namer.FillLists()
        Select Case (GameType)
            Case ScoreGame
                lblGoal.Text = "Goal: Score " + GoalNumber.ToString
            Case TerritoryGame
                lblGoal.Text = "Goal: Territory " + GoalNumber.ToString
            Case PopulationGame
                lblGoal.Text = "Goal: Population " + GoalNumber.ToString
            Case DevelopmentGame
                lblGoal.Text = "Goal: Development " + GoalNumber.ToString
            Case YearGame
                lblGoal.Text = "Goal: Year " + GoalNumber.ToString
            Case InfiniteGame
                lblGoal.Text = "Goal: None"
        End Select
        CreateBoxes()
        CreateOpeningCities()
        UpdatePlayers()
        CurrentPlayerIndex = -1
        UpdateYear()
        init = True
        NextPlayer()
    End Sub

    Sub StartNewGame()
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Sub CreateOpeningCities()
        Dim wallBuffer As Integer = 2
        Dim i As Integer
        For i = 0 To PlayerCount - 1
            '-- Initialize players
            Dim newPlayer As New Player(i)
            Players.Add(newPlayer)
            If i = 0 Then
                Players(i).Flag = Flag1
                gbP1.Visible = True
                gbP1.BackColor = Players(i).Flag
            ElseIf i = 1 Then
                Players(i).Flag = Flag2
                gbP2.Visible = True
                gbP2.BackColor = Players(i).Flag
            ElseIf i = 2 Then
                Players(i).Flag = Flag3
                gbP3.Visible = True
                gbP3.BackColor = Players(i).Flag
            ElseIf i = 3 Then
                Players(i).Flag = Flag4
                gbP4.Visible = True
                gbP4.BackColor = Players(i).Flag
            End If

            '-- Found opening cities
            While (True)
                Dim startX As Integer = GetRandom(wallBuffer, GridWidth - wallBuffer)
                Dim startY As Integer = GetRandom(wallBuffer, GridWidth - wallBuffer)
                If (BoxInfo(startX, startY).OwnerID < 0 And BoxInfo(startX + 1, startY).OwnerID < 0 And BoxInfo(startX - 1, startY).OwnerID < 0 And BoxInfo(startX, startY - 1).OwnerID < 0 And BoxInfo(startX, startY + 1).OwnerID < 0) Then
                    BoxInfo(startX, startY).OwnerID = i
                    BoxInfo(startX, startY).Terrain = TerrainPlain

                    ' Create starting population
                    Dim j As Integer
                    For j = 0 To StartPop - 1
                        Dim founder As New Person(True)
                        BoxInfo(startX, startY).AddPerson(founder)
                    Next

                    TheBoxes(startX, startY).BackColor = Players(i).Flag
                    Exit While
                End If
            End While

        Next
        UpdateGrid()
    End Sub

    Sub CreateBoxes()
        Dim CurrentX As Integer = LeftStart
        Dim CurrentY As Integer = TopStart
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                '--Create boxinfo
                BoxInfo(i, j) = New CitySquare(i, j)

                Dim NewBox As New Label
                NewBox.BorderStyle = BorderStyle.FixedSingle
                NewBox.Location = New System.Drawing.Point(CurrentX, CurrentY)
                CurrentX += LeftIncrement
                NewBox.Name = "NewBox"
                NewBox.Tag = i & "," & j
                'NewBox.ContextMenu = ctxTerrain 'Return this if context menu is used
                NewBox.Size = New System.Drawing.Size(LeftIncrement, TopIncrement)
                NewBox.TabStop = False
                'NewBox.Appearance.FontData.SizeInPoints = SmallFont
                Select Case (BoxInfo(i, j).Terrain)
                    Case TerrainPlain
                        NewBox.BackColor = ColorPlain
                    Case TerrainDirt
                        NewBox.BackColor = ColorDirt
                    Case TerrainForest
                        NewBox.BackColor = ColorForest
                    Case TerrainMountain
                        NewBox.BackColor = ColorMountain
                    Case TerrainLake
                        NewBox.BackColor = ColorOcean
                    Case TerrainSwamp
                        NewBox.BackColor = ColorSwamp
                    Case TerrainTownship
                        NewBox.BackColor = ColorTownship
                    Case TerrainDesert
                        NewBox.BackColor = ColorDesert
                End Select
                NewBox.TextAlign = ContentAlignment.MiddleCenter
                NewBox.Text = "0"
                'AddHandler NewBox.Click, AddressOf LabelClick
                'AddHandler NewBox.MouseEnter, AddressOf LabelMouseOver
                AddHandler NewBox.MouseUp, AddressOf LabelMouseUp
                TheBoxes(i, j) = NewBox
                Me.Controls.Add(NewBox)
            Next
            CurrentX = LeftStart
            CurrentY += TopIncrement
        Next

        UpdateCoastline()
    End Sub

    Private Sub LabelMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'Dim TheBox As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)
        Dim TheBox As Label = CType(sender, Label)
        Dim X, Y As Integer
        GetCoords(X, Y, TheBox.Tag)
        TheBoxes(LastClickedX, LastClickedY).BorderStyle = BorderStyle.FixedSingle
        LastClickedX = X
        LastClickedY = Y
        TheBoxes(LastClickedX, LastClickedY).BorderStyle = BorderStyle.Fixed3D
        If Infotab.SelectedIndex = CityTab And BoxInfo(LastClickedX, LastClickedY).OwnerID = CurrentPlayerIndex Then
            ubName.Visible = True
        Else
            ubName.Visible = False
        End If
        '--
        If e.Button = MouseButtons.Left Then
            'TheBox.Text = BoxInfo(X, Y).ShowID()
            Build()
            UpdateTabs()
            Infotab.SelectedTab = Infotab.TabPages(CityTab)
        ElseIf e.Button = MouseButtons.Right Then
            '-- Currently used for view mode
            UpdateTabs()
            If BoxInfo(X, Y).OwnerID < 0 Or Infotab.SelectedIndex <> PersonTab Then
                Infotab.SelectedTab = Infotab.TabPages(CityTab)
            End If

        End If
        'TheBox.Appearance.BackColor2 = BoxInfo(X, Y).GetTerrainColor

    End Sub

    Sub GetCoords(ByRef TheX As Integer, ByRef TheY As Integer, ByVal TheTag As String)
        Try
            Dim TheSections(1) As String
            TheSections = TheTag.Split(",")
            TheX = CType(TheSections(0), Integer)
            TheY = CType(TheSections(1), Integer)
        Catch ex As Exception
            MsgBox("Error getting coords.", , "Error")
        End Try

    End Sub
#End Region

#Region " Game Loop "
    Sub NextPlayer()
        '-- Cleanup
        TheBoxes(LastClickedX, LastClickedY).BorderStyle = BorderStyle.FixedSingle
        ClearSuccess()
        SelectedCard = -1
        CurrentPerson = -1
        EventString = ""
        txt_event.Text = ""
        txt_card.Text = ""
        txt_city.Text = ""
        txt_person.Text = ""
        lblPerson.Text = "Displaying 0 of 0"
        CurrentView = PopView

        '--Advance to next player
        CurrentPlayerIndex = CurrentPlayerIndex + 1
        If CurrentPlayerIndex = Players.Count Then
            CurrentPlayerIndex = 0
            theYear += TimeIncrement
            If (GameType = YearGame And theYear >= GoalNumber) Or WinFlag = True Then
                FindWinner()
            End If
            UpdateYear()
        End If

        CurrentPlayer = Players(CurrentPlayerIndex)
        CurrentPlayer.UpdateCensusData()

        '--Highlight current player
        txtP1.BackColor = ColorPlayerUnselected
        txtP2.BackColor = ColorPlayerUnselected
        txtP3.BackColor = ColorPlayerUnselected
        txtP4.BackColor = ColorPlayerUnselected

        If CurrentPlayerIndex = 0 Then
            txtP1.BackColor = ColorPlayerSelected
        ElseIf CurrentPlayerIndex = 1 Then
            txtP2.BackColor = ColorPlayerSelected
        ElseIf CurrentPlayerIndex = 2 Then
            txtP3.BackColor = ColorPlayerSelected
        ElseIf CurrentPlayerIndex = 3 Then
            txtP4.BackColor = ColorPlayerSelected
        End If

        '-- Display new hint
        DisplayHint()

        '-- Refill Hand and Update Costs
        UpdateCards()

        '-- Handle Population growth, movement, employment and taxation
        UpdatePeople()

        '-- Update averages for views and successes for businesses
        UpdateAverages()

        '-- Successful buildings expand
        BuildingsExpand()

        '-- Display event messages
        txt_event.Text = EventString
        Infotab.SelectedTab = Infotab.TabPages(EventTab)

        '-- Update grid appearence and texts
        UpdateGrid()

        '-- Update player info
        UpdatePlayers()
    End Sub

    Sub Build()
        Dim UpdateNeeded As Boolean = False
        Dim SpendingMoney As Integer = Players(CurrentPlayerIndex).TotalMoney
        Dim ClickLocation As CitySquare = BoxInfo(LastClickedX, LastClickedY)

        If SelectedCard >= 0 And ClickLocation.OwnerID = CurrentPlayerIndex Then
            'Owned by current player
            If SelectedCard = RoadCard And SpendingMoney >= RoadCost And ClickLocation.Transportation < RoadHighway Then
                '-- Build road
                ClickLocation.AddRoad()

                '-- Pay for road
                Players(CurrentPlayerIndex).TotalMoney = SpendingMoney - RoadCost
                UpdateNeeded = True
            ElseIf SelectedCard < CardCount Then
                '-- Build building
                Dim newBuilding As Building = Cards(SelectedCard)
                If SpendingMoney >= newBuilding.Cost Then
                    newBuilding.Location = ClickLocation
                    ClickLocation.AddBuilding(newBuilding)

                    '-- Pay for building card
                    Players(CurrentPlayerIndex).TotalMoney = SpendingMoney - newBuilding.Cost
                    '-- Remove building card
                    Cards.RemoveAt(SelectedCard)
                    UpdateNeeded = True
                End If
            End If
        End If
        If SelectedCard = LandCard And ClickLocation.Terrain <> TerrainLake And OwnedAdjacent(CurrentPlayerIndex) And SpendingMoney >= LandCost And ClickLocation.OwnerID < 0 Then
            '-- Expand territory
            ClickLocation.OwnerID = CurrentPlayerIndex

            '-- Pay for land
            Players(CurrentPlayerIndex).TotalMoney -= LandCost
            If ClickLocation.Terrain = TerrainDirt Then
                '-- Dirt effect: rebate
                Players(CurrentPlayerIndex).TotalMoney += SafeDivide(LandCost, 4)
                ClickLocation.Transportation = RoadDirt
            ElseIf ClickLocation.Terrain = TerrainMountain Then
                '-- Rock effect: free building
                Dim randNum As Integer = GetRandom(0, CardCount - 1)
                Dim newBuilding As Building = Cards(randNum)
                newBuilding.Location = ClickLocation
                ClickLocation.AddBuilding(newBuilding)
                Cards.RemoveAt(randNum)
            End If
            UpdateNeeded = True
        End If

        If UpdateNeeded Then
            UpdateGrid()
            UpdatePlayers()
            UpdateCards()
        End If

    End Sub

    Public Sub FindWinner()
        Dim WinningString As String = ""
        Dim i As Integer
        Select Case GameType
            Case ScoreGame
                WinningString += "Scores: " + ControlChars.NewLine
                For i = 0 To PlayerCount - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalScore.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case TerritoryGame
                WinningString += "Territory: " + ControlChars.NewLine
                For i = 0 To PlayerCount - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalTerritory.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case PopulationGame
                WinningString += "Population: " + ControlChars.NewLine
                For i = 0 To PlayerCount - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalPopulation.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case DevelopmentGame
                WinningString += "Development: " + ControlChars.NewLine
                For i = 0 To PlayerCount - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalDevelopment.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case YearGame
                Dim max As Integer = 0
                Dim winningPlayer As Integer = -1
                WinningString += "Scores: " + ControlChars.NewLine
                For i = 0 To PlayerCount - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalScore.ToString + ControlChars.NewLine
                    If Players(i).TotalScore > max Then
                        max = Players(i).TotalScore
                        winningPlayer = i + 1
                    End If
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + winningPlayer.ToString + ControlChars.NewLine
        End Select
        Dim EndingScreen As New GameOver(WinningString)
        If EndingScreen.ShowDialog = DialogResult.Yes Then
            StartNewGame()
        ElseIf EndingScreen.DialogResult = DialogResult.No Then
            Me.DialogResult = DialogResult.No
            Me.Close()
        Else
            WinFlag = False
            GameType = InfiniteGame
        End If

        'WinningString += ControlChars.NewLine + "Play Again?"
        'If MsgBox(WinningString, MsgBoxStyle.YesNo, "Game Over!") = MsgBoxResult.Yes Then
        '    StartNewGame()
        'Else
        '    Me.DialogResult = DialogResult.No
        '    Me.Close()
        'End If
    End Sub
#End Region

#Region " People "
    Sub UpdatePeople()

        Dim PersonEvents As New EventsP(CurrentPlayer, theYear)

        EventString += PersonEvents.UpdatePeople()
    End Sub

#End Region

#Region " Support "
    '-- Globalized
    'Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
    '    Randomize(Date.Now.Millisecond)
    '    Max += 1
    '    Dim TheResult As Integer = Int(Min + (Rnd() * (Max - Min)))
    '    Return TheResult
    'End Function

    Sub UpdateGrid()
        Dim i, j As Integer
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                Dim Owner As Integer = BoxInfo(i, j).OwnerID
                If Owner >= 0 Or CurrentView = LocView Then
                    If Owner >= 0 Then
                        TheBoxes(i, j).BackColor = Players(BoxInfo(i, j).OwnerID).Flag
                    End If
                    'TheBoxes(i, j).Appearance.FontData.SizeInPoints = BigFont
                    Select Case (CurrentView)
                        Case PopView
                            TheBoxes(i, j).Text = BoxInfo(i, j).getPopulation().ToString
                        Case LocView
                            'TheBoxes(i, j).Appearance.FontData.SizeInPoints = SmallFont
                            TheBoxes(i, j).Text = (BoxInfo(i, j).ColID + 1).ToString() + "," + (BoxInfo(i, j).RowID + 1).ToString()
                        Case HappinessView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgHappiness.ToString()
                        Case HealthView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgHealth.ToString()
                        Case EmploymentView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgEmployment.ToString()
                        Case IntelligenceView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgIntelligence.ToString()
                        Case CreativityView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgCreativity.ToString()
                        Case MobilityView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgMobility.ToString()
                        Case DrunkennessView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgDrunkenness.ToString()
                        Case CriminalityView
                            TheBoxes(i, j).Text = BoxInfo(i, j).AvgCriminality.ToString()
                        Case JobView
                            'TheBoxes(i, j).Appearance.FontData.SizeInPoints = SmallFont
                            TheBoxes(i, j).Text = BoxInfo(i, j).TempJobsFilled.ToString + "/" + BoxInfo(i, j).TempJobsTotal.ToString
                        Case RoadView
                            TheBoxes(i, j).Text = BoxInfo(i, j).Transportation.ToString
                    End Select
                Else
                    'TheBoxes(i, j).Appearance.BackColor2 = Color.LightGray
                    TheBoxes(i, j).Text = "0"
                End If
            Next
        Next
    End Sub

    Sub UpdateCards()
        '--Increase hand to full
        While (Cards.Count < 4)
            Cards.Add(NewCard())
        End While
        '--Reduce Cost
        Dim i, currentCost As Integer
        For i = 0 To CardCount - 1
            If Cards(i).cost = 0 And GetRandom(0, 4) = 0 Then
                Cards(i) = NewCard()
            End If
            Cards(i).cost = Math.Max(Cards(i).cost - 5, 0)
        Next
        '--Update text
        ubcard1.Text = Cards(0).type + ControlChars.NewLine + "Jobs: " + Cards(0).jobs.ToString() + "  Cost: " + Cards(0).cost.ToString()
        ubcard2.Text = Cards(1).type + ControlChars.NewLine + "Jobs: " + Cards(1).jobs.ToString() + "  Cost: " + Cards(1).cost.ToString()
        ubcard3.Text = Cards(2).type + ControlChars.NewLine + "Jobs: " + Cards(2).jobs.ToString() + "  Cost: " + Cards(2).cost.ToString()
        ubcard4.Text = Cards(3).type + ControlChars.NewLine + "Jobs: " + Cards(3).jobs.ToString() + "  Cost: " + Cards(3).cost.ToString()
        '--Land Cost
        LandCost = (50 + (CurrentPlayer.TotalTerritory * 20))
        ubland.Text = "Land, Cost: " + LandCost.ToString()
    End Sub

    Sub UpdatePlayers()

        For i As Integer = 0 To Players.Count - 1
            RefreshPlayerStats(i)

            Dim textString As String = ""
            textString += "Money: " + Players(i).TotalMoney.ToString() + ControlChars.NewLine
            textString += "Pop: " + Players(i).TotalPopulation.ToString() + ControlChars.NewLine
            textString += "Jobs: " + Players(i).TotalEmployed.ToString() + "/" + Players(i).TotalJobs.ToString() + ControlChars.NewLine
            textString += "Territory: " + Players(i).TotalTerritory.ToString() + ControlChars.NewLine
            textString += "Buildings: " + Players(i).TotalDevelopment.ToString() + ControlChars.NewLine
            textString += "Score: " + Players(i).TotalScore.ToString() + ControlChars.NewLine
            If i = 0 Then
                txtP1.Text = textString
            ElseIf i = 1 Then
                txtP2.Text = textString
            ElseIf i = 2 Then
                txtP3.Text = textString
            ElseIf i = 3 Then
                txtP4.Text = textString
            End If
        Next
    End Sub

    Sub UpdateTabs()
        Dim X As Integer = LastClickedX
        Dim Y As Integer = LastClickedY
        txt_city.Text = BoxInfo(X, Y).toString()
        Dim currentPop As Integer = BoxInfo(X, Y).getPopulation()
        If currentPop > 0 Then
            CurrentPerson = 0
            txt_person.Text = BoxInfo(X, Y).People(0).ToString()
            lblPerson.Text = "Displaying 1 of " + currentPop.ToString()
        Else
            txt_person.Text = ""
            lblPerson.Text = "Displaying 0 of 0"
        End If

    End Sub

    Sub UpdateAverages()
        Dim i, j, sum As Integer
        sum = 0
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = CurrentPlayerIndex Then
                    'Also updates success
                    BoxInfo(i, j).ComputeAverages()
                End If
            Next
        Next
    End Sub

    Sub UpdateYear()
        'Me.Text = "Urban Blight      Year: " + theYear.ToString
        lblYear.Text = "Year: " + theYear.ToString
    End Sub

    Function GetPlayerPopulation(ByVal thePlayer As Integer) As Integer
        Dim i, j, sum As Integer
        sum = 0
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = thePlayer Then
                    sum = sum + BoxInfo(i, j).getPopulation()
                End If
            Next
        Next
        Players(thePlayer).TotalPopulation = sum
        Return sum
    End Function

    Function GetPlayerTerritory(ByVal thePlayer As Integer) As Integer
        Dim i, j, sum As Integer
        sum = 0
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = thePlayer Then
                    sum = sum + 1
                End If
            Next
        Next
        Players(thePlayer).TotalTerritory = sum
        Return sum
    End Function

    Function GetPlayerDevelopment(ByVal thePlayer As Integer) As Integer
        Dim i, j, sum As Integer
        sum = 0
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = thePlayer Then
                    sum = sum + BoxInfo(i, j).getDevelopment()
                End If
            Next
        Next
        Players(thePlayer).TotalDevelopment = sum
        Return sum
    End Function

    Function GetPlayerJobsAndEmployment(ByVal thePlayer As Integer) As Integer
        Dim i, j, sum, sum2 As Integer
        sum = 0
        sum2 = 0
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = thePlayer Then
                    sum = sum + BoxInfo(i, j).getJobsFilled()
                    sum2 = sum2 + BoxInfo(i, j).getJobsTotal()
                End If
            Next
        Next
        Players(thePlayer).TotalEmployed = sum
        Players(thePlayer).TotalJobs = sum2
        Return sum
    End Function

    Function GetPlayerScore(ByVal thePlayer As Integer) As Integer
        '--Must call getplayer territory and development first
        Dim i, j, k As Integer
        Dim sum As Double = 0
        Dim personPoints As Double
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = thePlayer Then
                    For k = 0 To BoxInfo(i, j).People.Count - 1
                        '-- Computation of individual's value
                        personPoints = 0
                        personPoints += (BoxInfo(i, j).People(k).Happiness * 2.5)
                        personPoints += BoxInfo(i, j).People(k).Health
                        personPoints += (BoxInfo(i, j).People(k).Employment * 1.8)
                        personPoints += BoxInfo(i, j).People(k).Intelligence
                        personPoints += BoxInfo(i, j).People(k).Creativity
                        personPoints += (BoxInfo(i, j).People(k).Mobility * 0.5)
                        personPoints -= (BoxInfo(i, j).People(k).Criminality * 2.0)
                        personPoints -= (BoxInfo(i, j).People(k).Drunkenness * 1.3)
                        personPoints = SafeDivide(personPoints, 180.0)
                        If personPoints > 0 Then
                            personPoints = personPoints ^ 1.6
                        End If
                        sum += personPoints
                    Next
                End If
            Next
        Next
        Dim thisPlayer As Player = Players(thePlayer)
        '-- Computation of total value
        sum += (thisPlayer.TotalDevelopment * 4.0)
        sum += (thisPlayer.TotalTerritory * 12.0)
        sum += (SafeDivide(thisPlayer.TotalEmployed, thisPlayer.TotalPopulation) * sum * 0.2)
        Players(thePlayer).TotalScore = sum
        Return sum
    End Function

    Function OwnedAdjacent(ByVal thePlayerID As Integer) As Boolean

        Dim clickLocation As CitySquare = BoxInfo(LastClickedX, LastClickedY)

        '-- Check if the input player owns a neighboring location
        Dim adjacentList As ArrayList = clickLocation.GetAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            Dim neighborLocation As CitySquare = adjacentList(i)
            If neighborLocation.OwnerID = thePlayerID Then
                Return True
            End If
        Next
        Return False
    End Function

    Sub UpdateCoastline()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim location As CitySquare = BoxInfo(i, j)
                location.UpdateCoastline()
            Next
        Next
    End Sub

    Function GetCityName(ByVal i As Integer, ByVal j As Integer) As String
        If String.Compare(BoxInfo(i, j).CityName, "") = 0 Then
            Return "(" + (i + 1).ToString + "," + (j + 1).ToString + ")"
        Else
            Return BoxInfo(i, j).CityName
        End If
    End Function

    Sub RefreshPlayerStats(ByVal playerIndex As Integer)
        '-- Updates player info
        Dim thisPlayer As Player = Players(playerIndex)
        thisPlayer.UpdateCensusData()

        If GameType = ScoreGame And thisPlayer.TotalScore >= GoalNumber Then
            WinFlag = True
        End If
        If GameType = TerritoryGame And thisPlayer.TotalTerritory >= GoalNumber Then
            WinFlag = True
        End If
        If GameType = PopulationGame And thisPlayer.TotalPopulation >= GoalNumber Then
            WinFlag = True
        End If
        If GameType = DevelopmentGame And thisPlayer.TotalDevelopment >= GoalNumber Then
            WinFlag = True
        End If
    End Sub

#End Region

#Region " Buildings "

    Public Sub ClearSuccess()
        Dim i, j, k, bMax As Integer
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = CurrentPlayerIndex Then
                    bMax = BoxInfo(i, j).Buildings.Count - 1
                    For k = 0 To bMax
                        BoxInfo(i, j).Buildings(k).Success = 0
                    Next
                End If
            Next
        Next
    End Sub

    Sub BuildingsExpand()
        Dim EventCount As Integer = 0
        Dim LocalEvent As String = ""
        Dim i, j, k, odds As Integer
        Dim theBuilding As Building
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                If BoxInfo(i, j).OwnerID = CurrentPlayerIndex Then
                    For k = 0 To BoxInfo(i, j).Buildings.Count - 1
                        theBuilding = BoxInfo(i, j).Buildings(k)
                        If theBuilding.Filled = theBuilding.Jobs Then
                            '--Must be full
                            odds = 0
                            odds += SafeDivide(theBuilding.Success, theBuilding.Filled * 2)
                            If GetRandom(0, 100) <= odds Then
                                '--Buildings expand
                                theBuilding.Jobs += 1

                                '--Post Event
                                EventCount += 1
                                If EventCount >= EventLimit Then
                                    LocalEvent = EventCount.ToString() + " businesses expanded." + ControlChars.NewLine
                                Else
                                    LocalEvent += theBuilding.GetNameAndAddress() + " expanded to capacity " + theBuilding.Jobs.ToString + "." + ControlChars.NewLine
                                End If

                                BoxInfo(i, j).Buildings(k) = theBuilding
                            End If
                        End If
                    Next
                End If
            Next
        Next
        EventString += LocalEvent
    End Sub

    Public Function NewCard() As Building
        Dim newBuilding As New Building
        Dim Bnum As Integer = GetRandom(0, 23)
        Select Case Bnum
            Case 0
                '--Airport
                newBuilding.Type = "Airport"
                newBuilding.Cost = 325
                newBuilding.Jobs = 3
                newBuilding.Mobility_adj = 15
                newBuilding.Mobility_odds = 10
                newBuilding.Info = "Airports are not used frequently by people but vastly increase mobility when visited."
            Case 1
                '--Bar
                newBuilding.Type = "Bar"
                newBuilding.Cost = 60
                newBuilding.Jobs = 1
                newBuilding.Happiness_adj = 4
                newBuilding.Happiness_odds = 30
                newBuilding.Drunkenness_adj = 6
                newBuilding.Drunkenness_odds = 26
                newBuilding.Info = "Bars provide a social atmosphere to cheer people up but can cause a serious upsurge in drunkenness."
            Case 2
                '--Church
                newBuilding.Type = "Church"
                newBuilding.Cost = 180
                newBuilding.Jobs = 1
                newBuilding.Happiness_adj = 7
                newBuilding.Happiness_odds = 14
                newBuilding.Criminality_adj = -3
                newBuilding.Criminality_odds = 16
                newBuilding.Drunkenness_adj = -4
                newBuilding.Drunkenness_odds = 35
                newBuilding.Info = "While not attended by everyone, churches can have a noticable effect on increasing inner peace and harshly discouraging criminality and drunkenness."
            Case 3
                '--College
                newBuilding.Type = "College"
                newBuilding.Cost = 320
                newBuilding.Jobs = 2
                newBuilding.Drunkenness_adj = 2
                newBuilding.Drunkenness_odds = 40
                newBuilding.Intelligence_adj = 6
                newBuilding.Intelligence_odds = 30
                newBuilding.Creativity_adj = 3
                newBuilding.Creativity_odds = 25
                newBuilding.Info = "Colleges are important bastions of intelligence and creativity but also subject to wild drunken parties."
            Case 4
                '--Crime Ring
                newBuilding.Type = "Crime Ring"
                newBuilding.Cost = 50
                newBuilding.Jobs = 4
                newBuilding.Criminality_adj = 10
                newBuilding.Criminality_odds = 14
                newBuilding.Info = "A crime ring brings plenty of cheap jobs but a sharp, if rare, increase in extreme criminal behavior is likely."
            Case 5
                '--Factory
                newBuilding.Type = "Factory"
                newBuilding.Cost = 125
                newBuilding.Jobs = 5
                newBuilding.Health_adj = -3
                newBuilding.Health_odds = 20
                newBuilding.Happiness_adj = -2
                newBuilding.Happiness_odds = 16
                newBuilding.Info = "Factories provide many needed jobs but their monotony can be depressing and their pollution is unhealthy."
            Case 6
                '--Museum
                newBuilding.Type = "Museum"
                newBuilding.Cost = 150
                newBuilding.Jobs = 1
                newBuilding.Intelligence_adj = 2
                newBuilding.Intelligence_odds = 32
                newBuilding.Creativity_adj = 10
                newBuilding.Creativity_odds = 22
                newBuilding.Info = "Museums may be stodgy and boring to some, but they can help increase the intelligence and creativity of those occasional visitors."
            Case 7
                '--Hospital
                newBuilding.Type = "Hospital"
                newBuilding.Cost = 240
                newBuilding.Jobs = 3
                newBuilding.Health_adj = 5
                newBuilding.Health_odds = 35
                newBuilding.Drunkenness_adj = -3
                newBuilding.Drunkenness_odds = 12
                newBuilding.Info = "Hospitals are an excellent way of ensuring the health and well-being of your citizens. The doctors advise moderation of fatty foods and strong drinks, but few listen."
            Case 8
                '--Library
                newBuilding.Type = "Library"
                newBuilding.Cost = 105
                newBuilding.Jobs = 2
                newBuilding.Intelligence_adj = 4
                newBuilding.Intelligence_odds = 25
                newBuilding.Happiness_adj = 2
                newBuilding.Happiness_odds = 14
                newBuilding.Info = "Libraries are a nice quiet place for citizens to read, relax and learn at their own pace."
            Case 9
                '--Mall
                newBuilding.Type = "Mall"
                newBuilding.Cost = 385
                newBuilding.Jobs = 5
                newBuilding.Happiness_adj = 3
                newBuilding.Happiness_odds = 45
                newBuilding.Creativity_adj = -3
                newBuilding.Creativity_odds = 20
                newBuilding.Info = "A mall provides a tiny bit of happiness for nearly everyone, but can tend to stifle creativity and local flavor."
            Case 10
                '--Memorial
                newBuilding.Type = "Monument"
                newBuilding.Cost = 85
                newBuilding.Jobs = 0
                newBuilding.Happiness_adj = 3
                newBuilding.Happiness_odds = 16
                newBuilding.Creativity_adj = 3
                newBuilding.Creativity_odds = 16
                newBuilding.Info = "A bold impressive monument that makes citizen proud, happy and inspired to new creative heights... if only slightly."
            Case 11
                '--Office
                newBuilding.Type = "Office"
                newBuilding.Cost = 145
                newBuilding.Jobs = 4
                newBuilding.Creativity_adj = -2
                newBuilding.Creativity_odds = 30
                newBuilding.Info = "Offices are a simple source of jobs and infrastructure that tends not to affect citizens noticably."
            Case 12
                '--Park
                newBuilding.Type = "Park"
                newBuilding.Cost = 145
                newBuilding.Jobs = 1
                newBuilding.Happiness_adj = 3
                newBuilding.Happiness_odds = 15
                newBuilding.Creativity_adj = 3
                newBuilding.Creativity_odds = 20
                newBuilding.Health_adj = 3
                newBuilding.Health_odds = 40
                newBuilding.Info = "Attractive parks allow the casual stroller to engage in happy, healthy and creative exercise and meditation."
            Case 13
                '--Police Station
                newBuilding.Type = "Police Station"
                newBuilding.Cost = 155
                newBuilding.Jobs = 2
                newBuilding.Criminality_adj = -2
                newBuilding.Criminality_odds = 50
                newBuilding.Happiness_adj = -1
                newBuilding.Happiness_odds = 15
                newBuilding.Info = "Police stations are the best way to crack down on crime, even if every once in a while they spoil some harmless fun."
            Case 14
                '--Sidewalks
                newBuilding.Type = "Sidewalks"
                newBuilding.Cost = 80
                newBuilding.Jobs = 0
                newBuilding.Mobility_adj = 2
                newBuilding.Mobility_odds = 40
                newBuilding.Happiness_adj = 1
                newBuilding.Happiness_odds = 18
                newBuilding.Info = "Sidewalks give a little mobility to almost everyone and even a touch of happiness for friendly pedestrians."
            Case 15
                '--Skyscaper
                newBuilding.Type = "Skyscaper"
                newBuilding.Cost = 275
                newBuilding.Jobs = 6
                newBuilding.Info = "Skyscrapers provide tons of jobs but have little other effect."
            Case 16
                '--Stadium
                newBuilding.Type = "Stadium"
                newBuilding.Cost = 220
                newBuilding.Jobs = 3
                newBuilding.Happiness_adj = 6
                newBuilding.Happiness_odds = 24
                newBuilding.Health_adj = 5
                newBuilding.Health_odds = 5
                newBuilding.Drunkenness_adj = 3
                newBuilding.Drunkenness_odds = 20
                newBuilding.Info = "Stadiums can bring lots of fun and happiness, especially when the home team wins. The players get exercise and the audience gets entertainment and overpriced beer."
            Case 17
                '--Mass Transit
                newBuilding.Type = "Mass Transit"
                newBuilding.Cost = 175
                newBuilding.Jobs = 1
                newBuilding.Mobility_adj = 5
                newBuilding.Mobility_odds = 32
                newBuilding.Info = "Mass Transit allows many of your citizens to gain mobility they never would have had without it."
            Case 18
                '--Restaurant
                newBuilding.Type = "Restaurant"
                newBuilding.Cost = 120
                newBuilding.Jobs = 2
                newBuilding.Happiness_adj = 1
                newBuilding.Happiness_odds = 40
                newBuilding.Health_adj = 3
                newBuilding.Health_odds = 26
                newBuilding.Info = "Restaurants provide a charming setting for healthy meals and happy dates."
            Case 19
                '--Theater
                newBuilding.Type = "Theater"
                newBuilding.Cost = 200
                newBuilding.Jobs = 2
                newBuilding.Happiness_adj = 4
                newBuilding.Happiness_odds = 30
                newBuilding.Creativity_adj = 2
                newBuilding.Creativity_odds = 25
                newBuilding.Info = "Theaters bring movies of all different types that increase happiness and often possess creative artistic merit too."
            Case 20
                '--TV Station
                newBuilding.Type = "TV Station"
                newBuilding.Cost = 250
                newBuilding.Jobs = 3
                newBuilding.Happiness_adj = 2
                newBuilding.Happiness_odds = 70
                newBuilding.Creativity_adj = -1
                newBuilding.Creativity_odds = 50
                newBuilding.Info = "The TV station reaches almost house in a city, subtly boosting happiness and equally subtly stifling creativity."
            Case 21
                '--Coffee Shop
                newBuilding.Type = "Coffee Shop"
                newBuilding.Cost = 105
                newBuilding.Jobs = 1
                newBuilding.Happiness_adj = 2
                newBuilding.Happiness_odds = 20
                newBuilding.Mobility_adj = 1
                newBuilding.Mobility_odds = 20
                newBuilding.Drunkenness_adj = -2
                newBuilding.Drunkenness_odds = 40
                newBuilding.Info = "Coffee shops provide an alternative to alcohol that still cheers one up a notch and increases vigor and on-the-run mobility."
            Case 22
                '--Laboratory
                newBuilding.Type = "Laboratory"
                newBuilding.Cost = 205
                newBuilding.Jobs = 2
                newBuilding.Intelligence_adj = 8
                newBuilding.Intelligence_odds = 16
                newBuilding.Health_adj = -2
                newBuilding.Health_odds = 20
                newBuilding.Info = "Laboratories are a key source of research and intellectual advancement, but their chemicals and experiments can be unhealthy."
            Case 23
                '--Civic Center
                newBuilding.Type = "Civic Center"
                newBuilding.Cost = 505
                newBuilding.Jobs = 7
                newBuilding.Happiness_adj = 5
                newBuilding.Happiness_odds = 25
                newBuilding.Intelligence_adj = 3
                newBuilding.Intelligence_odds = 25
                newBuilding.Creativity_adj = 3
                newBuilding.Creativity_odds = 25
                newBuilding.Criminality_adj = -2
                newBuilding.Criminality_odds = 15
                newBuilding.Info = "Civic centers provide a vast expanse of public buildings and marketplaces for the free flow of cheerful commerce, progressive law, creative art and intellectual ideas."
        End Select
        Return newBuilding
    End Function

#End Region

#Region " Text "
    Public Sub DisplayInstructions()

    End Sub

    Public Sub DisplayHint()
        Dim Hint As String = ""
        '-- Citizens
        Hint += "Many traits are partially hereditary, like intelligence and creativity. Predispositions towards crime and alcohal can also be passed on.@"
        Hint += "Each turn your citizens go through six phases: (1) Aging, internal changes and possibly death, (2) Reproduction, (3) Travel, (4) Leisure, visiting building and applying for jobs, (5) Crime and accidents, (6) Taxation.@"
        Hint += "The numbers for all eight citizen trait range from 0 to 100.@"
        '-- Population
        Hint += "Dense, crowded cities can be unhygenic and depressing, lowering health and happiness.@"
        Hint += "Crowded cities encourage crime, in addition to having other detrimental effects. However, kids who grow up in densily populated cities gain extra street smarts.@"
        '-- Health
        Hint += "Umemployed citizens with low health will often take the starving artist path and call up creative reserves to survive.@"
        Hint += "Health is the single most important factor in whether your citizen will reproduce, but many other factors are involved.@"
        Hint += "Your citizens will die if their health becomes low or their age becomes very high. They can also die for other reasons.@"
        '-- Intelligence and Creativity
        Hint += "All citizens attend primary school, but must apply to get higher education. To be accepted, students must have increase their intelligence rapidly while still fairly young. Entrance standards are higher in larger cities. Keep in mind that higher education does not require college buildings.@"
        '-- Employment
        Hint += "Your citizens must apply for jobs based on their traits. Once employed, their 'employment' trait will go to 1 and then will gradually increase.@"
        Hint += "Once employed, citizens will succeed in their jobs based on their intelligence and creativity. If a business is fully staffed and highly successful, it may expand to hire more employees.@"
        Hint += "Unemployed citizens that are not minors will get ever more depressed and will gradually turn to crime.@"
        Hint += "Citizens who are very successful at their employment are happier and more fulfilled.@"
        Hint += "Citizens normally pay $5 in tax (even dependents) but must pay an extra $2 after getting employed.@"
        '-- Mobility and Transportation
        Hint += "Babies are born with almost no mobility, but it increases rapidly as they learn to walk, run and bike. At the age of 16 citizens learn to drive and if they already have a job, they'll buy a hotrod and get an extra mobility boost.@"
        Hint += "Citizens move around within your kingdom for three reasons: (1) To escape urban crowds and crime, (2) To find jobs if unemployed, (3) To seek out culture and fun in highly developed areas.@"
        Hint += "Citizens with high mobility are more likely to get into car crashes. However, better roads reduce the risk.@"
        Hint += "The mobility of your citizens increases based on the quality of the roads where they are living.@"
        Hint += "Better roads allow far ranging movement for your citizens. With highways and highly mobile citizens, movement can be virtually unlimited.@"
        Hint += "Roads are best improved in centrally located areas, to maximize their use.@"
        Hint += "The road quality of a destination city does not affect the journey to it, only the journey beyond it.@"
        '-- Emigration & Rivalry
        Hint += "Citizens can emigrate between rival kingdoms or visit foreign buildings that are within physical contact.@"
        Hint += "Happy citizens are more patriotic and are less inclined to emigrate to rival cities. However, nothing stop them from benefitting from a rival's buildings if these are within their mobility range.@"
        Hint += "Place buildings with negative qualities (like crime rings, bars and factories) just outside the borders of rival players to make sure they share the detrimental effects.@"
        Hint += "Create job opportunities and highly-developed cultural centers on the borders to rival cities to seduce their citizens into emigrating.@"
        Hint += "If you are far behind in population, try connecting your kingdom to a crowded rival to nab immigrants.@"
        '-- Drunkenness
        Hint += "Drunkenness makes your citizens happier and more sexual free, but it does have negative side-effects. It can make it harder for your citizens to get hired for jobs and increases the chance of car accidents and crimes of passion.@"
        Hint += "Bars, Stadiums and Colleges increase drunkenness. Police stations, churches, hospitals and coffee shops decrease it.@"
        Hint += "After drunkenness reaches a certain point, it becomes addictive for a citizen. High amounts of alcohal can be unhealthy for them and lead to depressions. If the addiction becomes life threatening rare citizens have the will power to go cold turkey.@"
        '-- Criminality
        Hint += "Citizens steal from the national treasury and commit murder as their criminality increases.@"
        Hint += "Some murderers develop a taste for crime and become more likely to strike after every kill, especially if the victim was rich and well-employed.@"
        Hint += "When citizens steal, they always take an amount equal to their current criminality stat.@"
        '-- Buildings
        Hint += "Citizens regularly visit buildings in nearby cities and experience their effects if their mobility allows.@"
        Hint += "Buildings only affect the character traits of your population. They have no special abilities.@"
        Hint += "All buildings drop in price by $5 after every purchase and at the end of turns. Making all your land and road purchases at the beginning of your turn will save you money on buildings.@"
        Hint += "If a building reaches a cost of $0 and is still not purchased, it will eventually be replaced.@"
        '-- Score
        Hint += "Your score is determined by a combination of population (based on their traits), building development, territory and employment ratio.@"
        Hint += "Each citizen contributes to your overall score, but not all citizens are counted equally. Increasing the right traits for your citizens will result in better-than-linear improvement.@"
        Hint += "The happiness of your citizens is the most important aspect of determining their worth for your total score.@"
        Hint += "A winner is not determined until all players have taken the same number of turns, so don't think that going first has any special advantage.@"
        '-- Terrain
        Hint += "Buying rock terrain provides a free building on the plot selected at random from the buildings currently available. Time your expansion wisely to take maximum advantage of this bonus by buying only when expensive, beneficial buildings are available.@"
        Hint += "Buying dirt terrain is best near the very beginning when roads are highly needed and late in the game when land is very expensive.@"
        Hint += "Savvy expansion can cut your rivals off from beneficial terrain and room for expansion. Use the lake terrain to your advantage when blocking rivals.@"
        Hint += "You can not buy land already owned, on lakes or not adjacent to your own territory.@"
        Hint += "Buildings in cities against edges or lakes are unlikely to be used as often as buildings located in central regions.@"
        Hint += "You must pay $10 per city in upkeep once you have a territory of four or more. This does not apply if the upkeep would consume more than half your income.@"
        '-- General
        Hint += "Use the buttons on the 'View' tab to get a general ideas of your current status and needs.@"
        Hint += "Right-click on cities or open terrain to see more details in the 'City' tab.@"
        Hint += "You can give your cities personalized names if you click on them twice and then press the 'Name' button.@"
        Hint += "Right-click on a city and then go to the 'Person' tab to view the traits for each of the local citizens.@"
        Hint += "Left-click on a button on the right side of the screen to see more details in the 'Card' tab.@"

        Dim HintArray As Array = Hint.Split("@")
        Dim i As Integer = GetRandom(0, HintArray.Length - 1)
        txtHint.text = HintArray(i)
    End Sub
#End Region

#Region " Buttons "
    Private Sub ubcard1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard1.Click
        SelectedCard = 0
        CardClick()
    End Sub
    Private Sub ubcard2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard2.Click
        SelectedCard = 1
        CardClick()
    End Sub
    Private Sub ubcard3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard3.Click
        SelectedCard = 2
        CardClick()
    End Sub
    Private Sub ubcard4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard4.Click
        SelectedCard = 3
        CardClick()
    End Sub
    Private Sub ubroad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubroad.Click
        SelectedCard = RoadCard
        txt_card.Text = "Roads help increase the mobility of you population and allows them to reach nearby squares within your kingdom. Roads always cost " + RoadCost.ToString()
        CardClick()
    End Sub

    Private Sub ubland_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubland.Click
        SelectedCard = LandCard
        txt_card.Text = "Land can only be bought adjacent to land you already own. The cost increases by 20 after every time you buy."
        CardClick()
    End Sub

    Public Sub CardClick()
        If (SelectedCard < CardCount) Then
            txt_card.Text = Cards(SelectedCard).Info
        End If
        Infotab.SelectedTab = Infotab.TabPages(CardTab)
    End Sub

    Private Sub ubEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubEnd.Click
        NextPlayer()
    End Sub

    '-- Person viewing
    Private Sub ubBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubBack.Click
        Dim selectedPop As Integer = BoxInfo(LastClickedX, LastClickedY).getPopulation()
        If selectedPop > 0 And CurrentPerson > 0 Then
            CurrentPerson = CurrentPerson - 1
            lblPerson.Text = "Displaying " + (CurrentPerson + 1).ToString() + " of " + selectedPop.ToString()
            If CurrentPerson < selectedPop Then
                txt_person.Text = BoxInfo(LastClickedX, LastClickedY).People(CurrentPerson).ToString()
            End If
        End If
    End Sub

    Private Sub ubForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubForward.Click
        Dim selectedPop As Integer = BoxInfo(LastClickedX, LastClickedY).getPopulation()
        If selectedPop > 0 And CurrentPerson < selectedPop - 1 Then
            CurrentPerson = CurrentPerson + 1
            lblPerson.Text = "Displaying " + (CurrentPerson + 1).ToString() + " of " + selectedPop.ToString()
            txt_person.Text = BoxInfo(LastClickedX, LastClickedY).People(CurrentPerson).ToString()
        End If
    End Sub

    Private Sub ubNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubNew.Click
        If MsgBox("Are you sure you want to start a new game?", MsgBoxStyle.YesNo, "Restart Game") = MsgBoxResult.Yes Then
            StartNewGame()
        End If
    End Sub

    Private Sub ubQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubQuit.Click
        If MsgBox("Are you sure you want to quit Urban Blight?", MsgBoxStyle.YesNo, "Quit Game") = MsgBoxResult.Yes Then
            Me.DialogResult = DialogResult.No
            Me.Close()
        End If
    End Sub

#Region " Views "
    Private Sub ubPopView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubPopView.Click
        CurrentView = PopView
        lblView.Text = "Current View: Population"
        UpdateGrid()
    End Sub

    Private Sub ubLocView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubLocView.Click
        CurrentView = LocView
        lblView.Text = "Current View: Location"
        UpdateGrid()
    End Sub

    Private Sub ubJobView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubJobView.Click
        CurrentView = JobView
        lblView.Text = "Current View: Jobs"
        UpdateGrid()
    End Sub

    Private Sub ubRoads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubRoads.Click
        CurrentView = RoadView
        lblView.Text = "Current View: Roads"
        UpdateGrid()
    End Sub

    Private Sub ubHappiness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubHappiness.Click
        CurrentView = HappinessView
        lblView.Text = "Current View: Happiness"
        UpdateGrid()
    End Sub

    Private Sub ubHealth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubHealth.Click
        CurrentView = HealthView
        lblView.Text = "Current View: Health"
        UpdateGrid()
    End Sub

    Private Sub ubEmployment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubEmployment.Click
        CurrentView = EmploymentView
        lblView.Text = "Current View: Employment"
        UpdateGrid()
    End Sub

    Private Sub ubIntelligence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubIntelligence.Click
        CurrentView = IntelligenceView
        lblView.Text = "Current View: Intelligence"
        UpdateGrid()
    End Sub

    Private Sub ubCreativity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubCreativity.Click
        CurrentView = CreativityView
        lblView.Text = "Current View: Creativity"
        UpdateGrid()
    End Sub

    Private Sub ubMobility_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubMobility.Click
        CurrentView = MobilityView
        UpdateGrid()
    End Sub

    Private Sub ubDrunkenness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubDrunkenness.Click
        CurrentView = DrunkennessView
        lblView.Text = "Current View: Drunkenness"
        UpdateGrid()
    End Sub

    Private Sub ubCriminality_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubCriminality.Click
        CurrentView = CriminalityView
        lblView.Text = "Current View: Criminality"
        UpdateGrid()
    End Sub
#End Region

    Private Sub Infotab_SelectedTabChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Infotab.TabIndexChanged
        If init Then
            If Not (CurrentView = RoadView And SelectedCard = RoadCard) Then
                CurrentView = PopView
                lblView.Text = "Current View: Population"
                UpdateGrid()
            End If
        End If
    End Sub

    Private Sub ubName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubName.Click
        Dim CName As New CityNamer
        CName.ShowDialog()
        BoxInfo(LastClickedX, LastClickedY).CityName = LastCityName
        UpdateTabs()
    End Sub

    Private Sub ubHint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubHint.Click
        DisplayHint()
    End Sub
#End Region


End Class

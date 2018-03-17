Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Variables "
    '--
    Dim Points As New ArrayList
    Dim BigFont As Integer = 12
    Dim SmallFont As Integer = 10

    '--
    Dim ClickCity As CitySquare = Nothing

    '--
    Public CurrentPlayer As Player = Nothing
    Public CurrentPlayerIndex As Integer = 0

    '--
    Dim WinFlag As Boolean = False

    '--
    Dim NoCard As Integer = -1
    Dim CardCount As Integer = 4
    Dim Cards As New ArrayList
    Dim RoadCard As Integer = CardCount
    Dim LandCard As Integer = RoadCard + 1
    Dim SelectedCard As Integer = NoCard
    Dim RoadCost As Integer = 50

    '--
    Dim CurrentPerson As Integer = -1
    Dim CurrentView As Integer = 0

    '--
    Dim theYear As Integer = 1
    Dim StartPop As Integer = 4

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
        Me.txt_event.Location = New System.Drawing.Point(13, 15)
        Me.txt_event.Multiline = True
        Me.txt_event.Name = "txt_event"
        Me.txt_event.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_event.Size = New System.Drawing.Size(248, 299)
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
        Me.txt_card.Location = New System.Drawing.Point(13, 15)
        Me.txt_card.Multiline = True
        Me.txt_card.Name = "txt_card"
        Me.txt_card.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_card.Size = New System.Drawing.Size(248, 299)
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
        Me.txt_city.Location = New System.Drawing.Point(13, 15)
        Me.txt_city.Multiline = True
        Me.txt_city.Name = "txt_city"
        Me.txt_city.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_city.Size = New System.Drawing.Size(248, 299)
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
        Me.lblPerson.Location = New System.Drawing.Point(16, 299)
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
        Me.txt_person.Location = New System.Drawing.Point(13, 15)
        Me.txt_person.Multiline = True
        Me.txt_person.Name = "txt_person"
        Me.txt_person.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_person.Size = New System.Drawing.Size(248, 275)
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
        Me.txtHint.Location = New System.Drawing.Point(11, 15)
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
        Me.ubcard1.UseVisualStyleBackColor = False
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
        Me.gbP1.Location = New System.Drawing.Point(16, 527)
        Me.gbP1.Name = "gbP1"
        Me.gbP1.Size = New System.Drawing.Size(104, 130)
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
        Me.txtP1.Size = New System.Drawing.Size(88, 108)
        Me.txtP1.TabIndex = 2
        '
        'gbP2
        '
        Me.gbP2.Controls.Add(Me.txtP2)
        Me.gbP2.Location = New System.Drawing.Point(136, 527)
        Me.gbP2.Name = "gbP2"
        Me.gbP2.Size = New System.Drawing.Size(104, 130)
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
        Me.txtP2.Size = New System.Drawing.Size(88, 108)
        Me.txtP2.TabIndex = 3
        '
        'gbP4
        '
        Me.gbP4.Controls.Add(Me.txtP4)
        Me.gbP4.Location = New System.Drawing.Point(376, 527)
        Me.gbP4.Name = "gbP4"
        Me.gbP4.Size = New System.Drawing.Size(104, 130)
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
        Me.txtP4.Size = New System.Drawing.Size(88, 108)
        Me.txtP4.TabIndex = 3
        '
        'gbP3
        '
        Me.gbP3.Controls.Add(Me.txtP3)
        Me.gbP3.Location = New System.Drawing.Point(256, 527)
        Me.gbP3.Name = "gbP3"
        Me.gbP3.Size = New System.Drawing.Size(104, 130)
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
        Me.txtP3.Size = New System.Drawing.Size(88, 108)
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
        Me.Infotab.Location = New System.Drawing.Point(512, 305)
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
        Me.ubEnd.Location = New System.Drawing.Point(568, 256)
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
        Me.ClientSize = New System.Drawing.Size(810, 678)
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
        '-- Urban Blight begins HERE
        StartGame()
    End Sub

    Sub StartGame()
        '-- Get player count and game type
        Dim Introduction As New Intro
        If Introduction.ShowDialog() <> DialogResult.OK Then
            Me.DialogResult = DialogResult.No
            Me.Close()
        End If

        '-- Run setup on the NameGenerator and HintGenerator
        Namer.FillLists()
        Hinter.FillLists()

        '-- Display game goal
        UpdateGoal()

        '-- Display the starting year
        UpdateYear()

        '-- Create players
        CreatePlayers()

        '-- Create the map
        CreateMapGrid()
        CreateOpeningCities()

        '-- Display initial player info
        UpdatePlayers()
        CurrentPlayerIndex = -1

        '-- Finish initialization
        init = True

        '-- First player's turn
        NextPlayer()
    End Sub

    Sub StartNewGame()
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Sub CreatePlayers()
        Players.Clear()

        '-- Initialize players
        For i As Integer = 0 To MaxPlayers - 1
            Dim newPlayer As New Player(i)
            If i < PlayerCount Then
                newPlayer.PlayerType = PlayerHuman
            Else
                newPlayer.PlayerType = PlayerNone 'PlayerAI
            End If

            Players.Add(newPlayer)
        Next

        PlayerCount = MaxPlayers

        '-- Display Player Info GUIs for active players
        For i As Integer = 0 To Players.Count - 1
            Dim thisPlayer As Player = Players(i)

            '-- Display player Info GUIs for active players
            If thisPlayer.PlayerType <> PlayerNone Then
                If i = 0 Then
                    Players(i).Flag = Flag1
                    gbP1.Visible = True
                    gbP1.Text = thisPlayer.GetPlayerName()
                    gbP1.BackColor = Players(i).Flag
                ElseIf i = 1 Then
                    Players(i).Flag = Flag2
                    gbP2.Visible = True
                    gbP2.Text = thisPlayer.GetPlayerName()
                    gbP2.BackColor = Players(i).Flag
                ElseIf i = 2 Then
                    Players(i).Flag = Flag3
                    gbP3.Visible = True
                    gbP3.Text = thisPlayer.GetPlayerName()
                    gbP3.BackColor = Players(i).Flag
                ElseIf i = 3 Then
                    Players(i).Flag = Flag4
                    gbP4.Visible = True
                    gbP4.Text = thisPlayer.GetPlayerName()
                    gbP4.BackColor = Players(i).Flag
                End If
            End If
        Next


    End Sub

    Sub CreateMapGrid()

        '-- Location Variables
        Dim LeftStart As Integer = 16
        Dim LeftIncrement As Integer = 48
        Dim TopStart As Integer = 32
        Dim TopIncrement As Integer = 48

        '-- Create grid of colored labels
        Dim CurrentX As Integer = LeftStart
        Dim CurrentY As Integer = TopStart
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight

                Dim newLocation As New CitySquare(i, j)
                GridArray(i, j) = newLocation

                '-- Set position and size of grid squares
                Dim gridSquare As Label = newLocation.GridSquare
                gridSquare.Location = New System.Drawing.Point(CurrentX, CurrentY)
                gridSquare.Size = New System.Drawing.Size(LeftIncrement, TopIncrement)

                'ClickBox.Appearance.FontData.SizeInPoints = SmallFont
                'ClickBox.ContextMenu = ctxTerrain 'Return this if context menu is used

                '-- Add handlers
                'AddHandler ClickBox.Click, AddressOf LabelClick
                'AddHandler ClickBox.MouseEnter, AddressOf LabelMouseOver
                AddHandler gridSquare.MouseUp, AddressOf MapMouseUp

                '-- Add this grid square to the main GUI
                Me.Controls.Add(gridSquare)

                CurrentX += LeftIncrement
            Next
            CurrentX = LeftStart
            CurrentY += TopIncrement
        Next

        '-- Mark terrain by water
        UpdateCoastline()
    End Sub

    Sub CreateOpeningCities()
        Dim wallBuffer As Integer = 2
        For i As Integer = 0 To Players.Count - 1

            '-- Make sure this player exists
            Dim thisPlayer As Player = Players(i)
            If thisPlayer.PlayerType = PlayerNone Then
                Continue For
            End If

            '-- Found opening cities
            While (True)
                Dim startX As Integer = GetRandom(wallBuffer, GridWidth - wallBuffer)
                Dim startY As Integer = GetRandom(wallBuffer, GridWidth - wallBuffer)
                Dim theLocation As CitySquare = GridArray(startX, startY)

                '-- Starting cities can't be on or adjacent to another city
                If (theLocation.OwnerID < 0 And GridArray(startX + 1, startY).OwnerID < 0 And GridArray(startX - 1, startY).OwnerID < 0 And GridArray(startX, startY - 1).OwnerID < 0 And GridArray(startX, startY + 1).OwnerID < 0) Then
                    theLocation.OwnerID = i

                    '-- Starting cities are always on Plain terrain
                    theLocation.Terrain = TerrainPlain

                    '-- Generate random city name
                    theLocation.CityName = Namer.GenerateCityName(theLocation)

                    ' Create starting population
                    Dim j As Integer
                    For j = 0 To StartPop - 1
                        Dim founder As New Person(True)
                        GridArray(startX, startY).AddPerson(founder)
                    Next

                    GridArray(startX, startY).GridSquare.BackColor = thisPlayer.Flag
                    Exit While
                End If
            End While

        Next
        UpdateGrid()
    End Sub

    Private Sub MapMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim TheBox As Label = CType(sender, Label)
        Dim X, Y As Integer
        GetCoords(X, Y, TheBox.Tag)

        '-- Deselect the previous grid box
        If ClickCity IsNot Nothing Then
            ClickCity.GridSquare.BorderStyle = BorderStyle.FixedSingle
        End If

        '-- Update the most recently clicked on box and its info
        ClickCity = GridArray(X, Y)

        '-- Select the newly clicked on grid box
        ClickCity.GridSquare.BorderStyle = BorderStyle.Fixed3D

        '-- Don't let players rename each other's cities!
        If ClickCity.OwnerID = CurrentPlayerIndex Then
            ubName.Visible = True
        Else
            ubName.Visible = False
        End If
        '--
        If e.Button = MouseButtons.Left Then
            'TheBox.Text = GridArray(X, Y).ShowID()
            Build()
            UpdateTabs()
            Infotab.SelectedTab = Infotab.TabPages(CityTab)
        ElseIf e.Button = MouseButtons.Right Then
            '-- Currently used for view mode
            UpdateTabs()
            If GridArray(X, Y).OwnerID < 0 Or Infotab.SelectedIndex <> PersonTab Then
                Infotab.SelectedTab = Infotab.TabPages(CityTab)
            End If

        End If
        'TheBox.Appearance.BackColor2 = GridArray(X, Y).GetTerrainColor

    End Sub
#End Region

#Region " Game Loop "
    Sub NextPlayer()
        '-- Cleanup
        ResetForNewTurn()

        '--Advance to next player (If last player in round and end condition is met, show Game Over screen)
        AdvanceToNextPlayer()

        '-- Refill Hand and Update Costs
        UpdateCards()

        '-- Handle Population growth, movement, employment and taxation
        UpdatePeople()

        '-- Update averages for views and successes for businesses
        UpdateAverages()

        '-- Successful buildings expand
        BuildingsExpand()

        '-- Display event messages
        UpdateTextBox(txt_event, EventString)
        Infotab.SelectedTab = Infotab.TabPages(EventTab)

        '-- Update grid appearence and texts
        UpdateGrid()

        '-- Update player info
        UpdatePlayers()
    End Sub

    Sub AdvanceToNextPlayer()
        '-- Move to next human or AI player. 
        Do
            CurrentPlayerIndex += 1
            If CurrentPlayerIndex = Players.Count Then
                CurrentPlayerIndex = 0

                '-- If this was the end of the round, advance the clock
                theYear += TimeIncrement
                UpdateYear()

                '-- Check for a winner
                If (GameType = YearGame And theYear >= GoalNumber) Or WinFlag = True Then
                    GameOver()
                End If
            End If
            CurrentPlayer = Players(CurrentPlayerIndex)
        Loop While CurrentPlayer.PlayerType = PlayerNone

        '-- Highlight current player
        HighlightCurrentPlayer()

        '-- Update player info
        CurrentPlayer.UpdateCensusData()
    End Sub

#End Region

#Region " People "
    Sub UpdatePeople()

        Dim PersonEvents As New EventsP(CurrentPlayer, theYear)

        EventString += PersonEvents.UpdatePeople()
    End Sub

#End Region

#Region " Buildings "

    Sub Build()
        Dim UpdateNeeded As Boolean = False
        Dim SpendingMoney As Integer = Players(CurrentPlayerIndex).TotalMoney

        '-- What is the cost of this card?
        Dim CardCost As Integer = 0
        If SelectedCard = RoadCard Then
            CardCost = RoadCost
        ElseIf SelectedCard = LandCard Then
            If ClickCity.Terrain = TerrainSwamp Then
                CardCost = 0 '-- Swamps are free!
            Else
                CardCost = CurrentPlayer.GetPlayerLandCost()
            End If
        ElseIf SelectedCard >= 0 And SelectedCard < CardCount Then
            CardCost = Cards(SelectedCard).Cost
        Else
            Return
        End If

        '-- Can the player afford it?
        If CardCost > SpendingMoney Then
            Return
        End If

        '-- Was the selected CitySquare valid?
        If SelectedCard = LandCard Then
            '-- For Land cards they must be unowned, adjacent to land the player already owns, and not a lake
            If ClickCity.OwnerID >= 0 Or ClickCity.Terrain = TerrainLake Or (Not CurrentPlayer.OwnedAdjacent(ClickCity)) Then
                Return
            End If
        Else
            '-- For Roads and Buildings the player must already own the land
            If ClickCity.OwnerID <> CurrentPlayerIndex Then
                Return
            End If

            '-- Roads can't be built if highway is already present
            If SelectedCard = RoadCard And ClickCity.Transportation = RoadHighway Then
                Return
            End If
        End If

        '-- Pay for construction
        Players(CurrentPlayerIndex).TotalMoney -= CardCost
        UpdateNeeded = True

        '-- Do construction
        If SelectedCard = RoadCard Then
            '-- Upgrade Road
            ClickCity.AddRoad()
        ElseIf SelectedCard = LandCard Then
            '-- Expand Territory
            ClickCity.OwnerID = CurrentPlayerIndex

            '-- Generate random name
            ClickCity.CityName = Namer.GenerateCityName(ClickCity)

            '-- Handle special terrain bonuses
            If ClickCity.Terrain = TerrainDirt Then
                '-- Desert effect: rebate
                Players(CurrentPlayerIndex).TotalMoney += SafeDivide(CardCost, 2)
            ElseIf ClickCity.Terrain = TerrainDirt Then
                '-- Dirt effect: free road
                ClickCity.Transportation = RoadDirt
            ElseIf ClickCity.Terrain = TerrainMountain Then
                '-- Rock effect: free building
                Dim randNum As Integer = GetRandom(0, CardCount - 1)
                Dim newBuilding As Building = Cards(randNum)
                newBuilding.Location = ClickCity
                ClickCity.AddBuilding(newBuilding)
                Cards.RemoveAt(randNum)
            ElseIf ClickCity.Terrain = TerrainTownship Then
                '-- Township effect: free population
                Dim maxFreePopulation As Integer = Math.Min(10, Math.Floor(SafeDivide(CurrentPlayer.GetPlayerPopulation(), 15.0)) + 2)
                Dim randNum As Integer = GetRandom(2, maxFreePopulation)
                For i As Integer = 0 To randNum - 1
                    Dim founder As New Person(True)
                    ClickCity.AddPerson(founder)
                Next
            End If
        ElseIf SelectedCard >= 0 And SelectedCard < CardCount Then
            '-- Create Building
            ClickCity.AddBuilding(Cards(SelectedCard))
            Cards.RemoveAt(SelectedCard)
        End If

        '-- Update grid, cards, and players
        If UpdateNeeded Then
            UpdateGrid()
            UpdatePlayers()
            UpdateCards()

            SelectedCard = NoCard
            UpdateCardSelection()
        End If

    End Sub

    Public Sub ClearSuccess()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = CurrentPlayerIndex Then
                    For k As Integer = 0 To GridArray(i, j).Buildings.Count - 1
                        GridArray(i, j).Buildings(k).Success = 0
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
                If GridArray(i, j).OwnerID = CurrentPlayerIndex Then
                    For k = 0 To GridArray(i, j).Buildings.Count - 1
                        theBuilding = GridArray(i, j).Buildings(k)
                        If theBuilding.GetEmployeeCount() = theBuilding.Jobs Then
                            '--Must be full
                            odds = 0
                            odds += SafeDivide(theBuilding.Success, theBuilding.GetEmployeeCount() * 2)
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

                                GridArray(i, j).Buildings(k) = theBuilding
                            End If
                        End If
                    Next
                End If
            Next
        Next
        EventString += LocalEvent
    End Sub

#End Region

#Region " Update Info "
    Sub UpdateGrid()
        Dim i, j As Integer
        For i = 0 To GridWidth
            For j = 0 To GridHeight
                GridArray(i, j).UpdateGridSquare(CurrentView)
            Next
        Next
    End Sub

    Sub UpdateCards()
        '--Increase hand to full
        While (Cards.Count < 4)
            Dim newBuilding As New Building(-1)
            Cards.Add(newBuilding)
        End While

        '--Reduce Cost of Available Buildings
        Dim i As Integer
        For i = 0 To CardCount - 1

            Dim CardBuilding As Building = Cards(i)
            If CardBuilding.Cost = 0 Then
                If CardBuilding.RejectionCount >= Players.Count Then
                    '-- If no one has bought this building even for free, replace it
                    Cards.RemoveAt(i)
                    Dim newBuilding As New Building(-1)
                    Cards.Add(newBuilding)
                Else
                    '-- No one bought this building even though it was free. Escallate its rejection level
                    CardBuilding.RejectionCount += 1
                End If
            End If

            CardBuilding.Cost = Math.Max(CardBuilding.Cost - 5, 0)
        Next

        '--Update text
        ubcard1.Text = Cards(0).type + ControlChars.NewLine + "Jobs: " + Cards(0).jobs.ToString() + "  Cost: " + Cards(0).cost.ToString()
        ubcard2.Text = Cards(1).type + ControlChars.NewLine + "Jobs: " + Cards(1).jobs.ToString() + "  Cost: " + Cards(1).cost.ToString()
        ubcard3.Text = Cards(2).type + ControlChars.NewLine + "Jobs: " + Cards(2).jobs.ToString() + "  Cost: " + Cards(2).cost.ToString()
        ubcard4.Text = Cards(3).type + ControlChars.NewLine + "Jobs: " + Cards(3).jobs.ToString() + "  Cost: " + Cards(3).cost.ToString()

        '--Land Cost
        Dim LandCost As Integer = CurrentPlayer.GetPlayerLandCost()
        ubland.Text = "Land, Cost: " + LandCost.ToString()
    End Sub

    Sub UpdatePlayers()

        For i As Integer = 0 To Players.Count - 1
            '-- Updates player stats
            Dim thisPlayer As Player = Players(i)
            thisPlayer.UpdateCensusData()

            '-- Display current player stats
            Dim textString As String = thisPlayer.toString()
            If i = 0 Then
                txtP1.Text = textString
            ElseIf i = 1 Then
                txtP2.Text = textString
            ElseIf i = 2 Then
                txtP3.Text = textString
            ElseIf i = 3 Then
                txtP4.Text = textString
            End If

            '-- Check if player won
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
        Next
    End Sub

    Sub UpdateTabs()
        '-- Update the city tab
        UpdateTextBox(txt_city, ClickCity.toString())

        Dim personText As String = ""
        Dim currentPop As Integer = ClickCity.getPopulation()
        If currentPop > 0 Then
            CurrentPerson = 0
            personText = ClickCity.People(0).ToString()
            lblPerson.Text = "Displaying 1 of " + currentPop.ToString()
        Else
            personText = ""
            lblPerson.Text = "Displaying 0 of 0"
        End If
        UpdateTextBox(txt_person, personText)
    End Sub

    Sub UpdateAverages()
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).OwnerID = CurrentPlayerIndex Then
                    'Also updates success
                    GridArray(i, j).ComputeAverages()
                End If
            Next
        Next
    End Sub

    Sub UpdateYear()
        lblYear.Text = "Year: " + theYear.ToString
    End Sub

    Sub UpdateGoal()
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
    End Sub

    Sub UpdateCoastline()
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim location As CitySquare = GridArray(i, j)
                location.UpdateCoastline()
            Next
        Next
    End Sub

#End Region

#Region " Game Over "
    Public Sub GameOver()
        Dim WinningString As String = ""
        Dim i As Integer
        Select Case GameType
            Case ScoreGame
                WinningString += "Scores: " + ControlChars.NewLine
                For i = 0 To Players.Count - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalScore.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case TerritoryGame
                WinningString += "Territory: " + ControlChars.NewLine
                For i = 0 To Players.Count - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalTerritory.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case PopulationGame
                WinningString += "Population: " + ControlChars.NewLine
                For i = 0 To Players.Count - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalPopulation.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case DevelopmentGame
                WinningString += "Development: " + ControlChars.NewLine
                For i = 0 To Players.Count - 1
                    WinningString += "Player " + (i + 1).ToString + ": " + Players(i).TotalDevelopment.ToString + ControlChars.NewLine
                Next
                WinningString += ControlChars.NewLine + "The winner is: Player " + (CurrentPlayerIndex + 1).ToString + ControlChars.NewLine
            Case YearGame
                Dim max As Integer = 0
                Dim winningPlayer As Integer = -1
                WinningString += "Scores: " + ControlChars.NewLine
                For i = 0 To Players.Count - 1
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
    End Sub
#End Region

#Region " Support "

    Function GetCityName(ByVal i As Integer, ByVal j As Integer) As String
        If String.Compare(GridArray(i, j).CityName, "") = 0 Then
            Return "(" + (i + 1).ToString + "," + (j + 1).ToString + ")"
        Else
            Return GridArray(i, j).CityName
        End If
    End Function

    Sub ResetForNewTurn()
        If ClickCity IsNot Nothing Then
            ClickCity.GridSquare.BorderStyle = BorderStyle.FixedSingle
        End If

        SelectedCard = NoCard
        CurrentPerson = -1
        EventString = ""
        UpdateTextBox(txt_event, "")
        UpdateTextBox(txt_card, "")
        UpdateTextBox(txt_city, "")
        UpdateTextBox(txt_person, "")
        lblPerson.Text = "Displaying 0 of 0"
        CurrentView = PopView

        '-- Display new hint
        DisplayHint()

        '-- Reset all buildings to success = 0 (not sure why?)
        ClearSuccess()
    End Sub

    Sub HighlightCurrentPlayer()
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

#Region " Text "

    Public Sub UpdateTextBox(ByRef textBox As TextBox, ByVal displayString As String)
        '-- Update the textbox to display text and then deselect it.
        textBox.Text = displayString.Trim()
        textBox.Select(textBox.Text.Length, 0)
    End Sub

    Public Sub DisplayInstructions()

    End Sub

    Public Sub DisplayHint()
        txtHint.Text = Hinter.GenerateHint()
    End Sub
#End Region

#Region " Buttons "
    Private Sub ubcard1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard1.Click
        CardClick(0)
    End Sub
    Private Sub ubcard2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard2.Click
        CardClick(1)
    End Sub
    Private Sub ubcard3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard3.Click
        CardClick(2)
    End Sub
    Private Sub ubcard4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard4.Click
        CardClick(3)
    End Sub
    Private Sub ubroad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubroad.Click
        CardClick(RoadCard)
    End Sub

    Private Sub ubland_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubland.Click
        CardClick(LandCard)
    End Sub

    Public Sub CardClick(ByVal CardNumber As Integer)

        '-- Select the clicked card. If they click on it a second time, deselect it.
        If SelectedCard = CardNumber Then
            SelectedCard = NoCard
        Else
            SelectedCard = CardNumber
        End If

        UpdateCardSelection()

        '-- Display the card text
        Dim cardText As String = ""
        If (SelectedCard >= 0 And SelectedCard < CardCount) Then
            cardText = Cards(SelectedCard).Info
        ElseIf SelectedCard = RoadCard Then
            cardText = "Roads help increase the mobility of you population and allows them to reach nearby squares within your kingdom. Roads always cost " + RoadCost.ToString()
        ElseIf SelectedCard = LandCard Then
            cardText = "Land can only be bought adjacent to land you already own. The cost increases by 20 after every time you buy."
        End If
        UpdateTextBox(txt_card, cardText)

        Infotab.SelectedTab = Infotab.TabPages(CardTab)
    End Sub

    Public Sub UpdateCardSelection()

        Dim newBold As New Font(ubEnd.Font.FontFamily, ubEnd.Font.Size, FontStyle.Bold)
        Dim newRegular As New Font(ubEnd.Font.FontFamily, ubEnd.Font.Size, FontStyle.Regular)

        ubcard1.Font = newRegular
        ubcard2.Font = newRegular
        ubcard3.Font = newRegular
        ubcard4.Font = newRegular
        ubroad.Font = newRegular
        ubland.Font = newRegular

        Select Case SelectedCard
            Case 0
                ubcard1.Font = newBold
            Case 1
                ubcard2.Font = newBold
            Case 2
                ubcard3.Font = newBold
            Case 3
                ubcard4.Font = newBold
            Case RoadCard
                ubroad.Font = newBold
            Case LandCard
                ubland.Font = newBold
        End Select

    End Sub

    Private Sub ubEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubEnd.Click
        SelectedCard = NoCard
        UpdateCardSelection()
        NextPlayer()
    End Sub

    '-- Person viewing
    Private Sub ubBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubBack.Click
        Dim selectedPop As Integer = ClickCity.getPopulation()
        If selectedPop > 0 And CurrentPerson > 0 Then
            CurrentPerson = CurrentPerson - 1
            lblPerson.Text = "Displaying " + (CurrentPerson + 1).ToString() + " of " + selectedPop.ToString()
            If CurrentPerson < selectedPop Then
                txt_person.Text = ClickCity.People(CurrentPerson).ToString()
            End If
        End If
    End Sub

    Private Sub ubForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubForward.Click
        Dim selectedPop As Integer = ClickCity.getPopulation()
        If selectedPop > 0 And CurrentPerson < selectedPop - 1 Then
            CurrentPerson = CurrentPerson + 1
            lblPerson.Text = "Displaying " + (CurrentPerson + 1).ToString() + " of " + selectedPop.ToString()
            txt_person.Text = ClickCity.People(CurrentPerson).ToString()
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
        ClickCity.CityName = LastCityName
        UpdateTabs()
    End Sub

    Private Sub ubHint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubHint.Click
        DisplayHint()
    End Sub
#End Region

End Class

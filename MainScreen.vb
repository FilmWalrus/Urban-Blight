Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Variables "
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
    Dim RoadCard As Integer = CardCount
    Dim LandCard As Integer = RoadCard + 1
    Dim WipeCard As Integer = LandCard + 1
    Dim RoadMaxCard As Integer = WipeCard + 1
    Dim SelectedCard As Integer = NoCard

    '--
    Dim SelectedPerson As Integer = -1
    Dim SelectedBuilding As Integer = -1
    Dim CurrentView As Integer = 0

    '--
    Dim theYear As Integer = 1
    Dim StartPop As Integer = 4

    Friend WithEvents UltraTab1 As TabControl
    Friend WithEvents UltraTab2 As TabControl
    Friend WithEvents UltraTab3 As TabControl
    Friend WithEvents UltraTab4 As TabControl
    Friend WithEvents UltraTab5 As TabControl
    Friend WithEvents UltraTab6 As TabControl
    Friend WithEvents p1_details As Button
    Friend WithEvents p2_details As Button
    Friend WithEvents p4_details As Button
    Friend WithEvents p3_details As Button
    Friend WithEvents ubWipe As Button
    Friend WithEvents TabPageBuilding As TabPage
    Friend WithEvents lblBuilding As Label
    Friend WithEvents ubBForward As Button
    Friend WithEvents ubBBack As Button
    Friend WithEvents txt_building As TextBox
    Friend WithEvents BuildingDropdown As ComboBox
    Friend WithEvents btnCheat As Button
    Friend WithEvents ubroadmax As Button
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
    Friend WithEvents TabPageEvents As TabPage
    Friend WithEvents TabPageCard As TabPage
    Friend WithEvents TabPageCity As TabPage
    Friend WithEvents TabPagePerson As TabPage
    Friend WithEvents txt_event As System.Windows.Forms.TextBox
    Friend WithEvents txt_card As System.Windows.Forms.TextBox
    Friend WithEvents txt_person As System.Windows.Forms.TextBox
    Friend WithEvents txt_city As System.Windows.Forms.TextBox
    Friend WithEvents ubPBack As System.Windows.Forms.Button
    Friend WithEvents ubPForward As System.Windows.Forms.Button
    Friend WithEvents lblPerson As Label
    Friend WithEvents txtP1 As System.Windows.Forms.TextBox
    Friend WithEvents txtP2 As System.Windows.Forms.TextBox
    Friend WithEvents txtP3 As System.Windows.Forms.TextBox
    Friend WithEvents txtP4 As System.Windows.Forms.TextBox
    Friend WithEvents ubroad As System.Windows.Forms.Button
    Friend WithEvents ubland As System.Windows.Forms.Button
    Friend WithEvents ubEnd As System.Windows.Forms.Button
    Friend WithEvents TabPageView As TabPage
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
    Friend WithEvents TabPageGame As TabPage
    Friend WithEvents ubNew As System.Windows.Forms.Button
    Friend WithEvents ubQuit As System.Windows.Forms.Button
    Friend WithEvents ubHint As System.Windows.Forms.Button
    Friend WithEvents txtHint As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.UltraTab1 = New System.Windows.Forms.TabControl()
        Me.TabPageEvents = New System.Windows.Forms.TabPage()
        Me.txt_event = New System.Windows.Forms.TextBox()
        Me.UltraTab2 = New System.Windows.Forms.TabControl()
        Me.TabPageCard = New System.Windows.Forms.TabPage()
        Me.txt_card = New System.Windows.Forms.TextBox()
        Me.UltraTab3 = New System.Windows.Forms.TabControl()
        Me.TabPageCity = New System.Windows.Forms.TabPage()
        Me.ubName = New System.Windows.Forms.Button()
        Me.txt_city = New System.Windows.Forms.TextBox()
        Me.UltraTab4 = New System.Windows.Forms.TabControl()
        Me.TabPagePerson = New System.Windows.Forms.TabPage()
        Me.lblPerson = New System.Windows.Forms.Label()
        Me.ubPForward = New System.Windows.Forms.Button()
        Me.ubPBack = New System.Windows.Forms.Button()
        Me.txt_person = New System.Windows.Forms.TextBox()
        Me.UltraTab5 = New System.Windows.Forms.TabControl()
        Me.TabPageView = New System.Windows.Forms.TabPage()
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
        Me.TabPageGame = New System.Windows.Forms.TabPage()
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
        Me.p1_details = New System.Windows.Forms.Button()
        Me.txtP1 = New System.Windows.Forms.TextBox()
        Me.gbP2 = New System.Windows.Forms.GroupBox()
        Me.p2_details = New System.Windows.Forms.Button()
        Me.txtP2 = New System.Windows.Forms.TextBox()
        Me.gbP4 = New System.Windows.Forms.GroupBox()
        Me.p4_details = New System.Windows.Forms.Button()
        Me.txtP4 = New System.Windows.Forms.TextBox()
        Me.gbP3 = New System.Windows.Forms.GroupBox()
        Me.p3_details = New System.Windows.Forms.Button()
        Me.txtP3 = New System.Windows.Forms.TextBox()
        Me.Infotab = New System.Windows.Forms.TabControl()
        Me.TabPageBuilding = New System.Windows.Forms.TabPage()
        Me.lblBuilding = New System.Windows.Forms.Label()
        Me.ubBForward = New System.Windows.Forms.Button()
        Me.ubBBack = New System.Windows.Forms.Button()
        Me.txt_building = New System.Windows.Forms.TextBox()
        Me.ubland = New System.Windows.Forms.Button()
        Me.ubEnd = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblView = New System.Windows.Forms.Label()
        Me.lblGoal = New System.Windows.Forms.Label()
        Me.ubWipe = New System.Windows.Forms.Button()
        Me.BuildingDropdown = New System.Windows.Forms.ComboBox()
        Me.btnCheat = New System.Windows.Forms.Button()
        Me.ubroadmax = New System.Windows.Forms.Button()
        Me.TabPageEvents.SuspendLayout()
        Me.TabPageCard.SuspendLayout()
        Me.TabPageCity.SuspendLayout()
        Me.TabPagePerson.SuspendLayout()
        Me.TabPageView.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPageGame.SuspendLayout()
        Me.gbP1.SuspendLayout()
        Me.gbP2.SuspendLayout()
        Me.gbP4.SuspendLayout()
        Me.gbP3.SuspendLayout()
        Me.Infotab.SuspendLayout()
        Me.TabPageBuilding.SuspendLayout()
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
        'TabPageEvents
        '
        Me.TabPageEvents.Controls.Add(Me.txt_event)
        Me.TabPageEvents.Location = New System.Drawing.Point(4, 22)
        Me.TabPageEvents.Name = "TabPageEvents"
        Me.TabPageEvents.Size = New System.Drawing.Size(272, 326)
        Me.TabPageEvents.TabIndex = 0
        Me.TabPageEvents.Text = "Events"
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
        'TabPageCard
        '
        Me.TabPageCard.Controls.Add(Me.txt_card)
        Me.TabPageCard.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCard.Name = "TabPageCard"
        Me.TabPageCard.Size = New System.Drawing.Size(272, 326)
        Me.TabPageCard.TabIndex = 0
        Me.TabPageCard.Text = "Card"
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
        'TabPageCity
        '
        Me.TabPageCity.Controls.Add(Me.ubName)
        Me.TabPageCity.Controls.Add(Me.txt_city)
        Me.TabPageCity.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCity.Name = "TabPageCity"
        Me.TabPageCity.Size = New System.Drawing.Size(272, 326)
        Me.TabPageCity.TabIndex = 0
        Me.TabPageCity.Text = "City"
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
        'TabPagePerson
        '
        Me.TabPagePerson.Controls.Add(Me.lblPerson)
        Me.TabPagePerson.Controls.Add(Me.ubPForward)
        Me.TabPagePerson.Controls.Add(Me.ubPBack)
        Me.TabPagePerson.Controls.Add(Me.txt_person)
        Me.TabPagePerson.Location = New System.Drawing.Point(4, 22)
        Me.TabPagePerson.Name = "TabPagePerson"
        Me.TabPagePerson.Size = New System.Drawing.Size(272, 326)
        Me.TabPagePerson.TabIndex = 0
        Me.TabPagePerson.Text = "Person"
        '
        'lblPerson
        '
        Me.lblPerson.Location = New System.Drawing.Point(16, 299)
        Me.lblPerson.Name = "lblPerson"
        Me.lblPerson.Size = New System.Drawing.Size(136, 16)
        Me.lblPerson.TabIndex = 4
        Me.lblPerson.Text = "Displaying X of Y"
        '
        'ubPForward
        '
        Me.ubPForward.Location = New System.Drawing.Point(216, 296)
        Me.ubPForward.Name = "ubPForward"
        Me.ubPForward.Size = New System.Drawing.Size(48, 23)
        Me.ubPForward.TabIndex = 3
        Me.ubPForward.Text = ">>>"
        '
        'ubPBack
        '
        Me.ubPBack.Location = New System.Drawing.Point(160, 296)
        Me.ubPBack.Name = "ubPBack"
        Me.ubPBack.Size = New System.Drawing.Size(48, 23)
        Me.ubPBack.TabIndex = 2
        Me.ubPBack.Text = "<<<"
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
        'TabPageView
        '
        Me.TabPageView.Controls.Add(Me.ubRoads)
        Me.TabPageView.Controls.Add(Me.ubJobView)
        Me.TabPageView.Controls.Add(Me.GroupBox1)
        Me.TabPageView.Controls.Add(Me.ubLocView)
        Me.TabPageView.Controls.Add(Me.ubPopView)
        Me.TabPageView.Location = New System.Drawing.Point(4, 22)
        Me.TabPageView.Name = "TabPageView"
        Me.TabPageView.Size = New System.Drawing.Size(272, 326)
        Me.TabPageView.TabIndex = 0
        Me.TabPageView.Text = "View"
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
        'TabPageGame
        '
        Me.TabPageGame.Controls.Add(Me.txtHint)
        Me.TabPageGame.Controls.Add(Me.ubHint)
        Me.TabPageGame.Controls.Add(Me.ubQuit)
        Me.TabPageGame.Controls.Add(Me.ubNew)
        Me.TabPageGame.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGame.Name = "TabPageGame"
        Me.TabPageGame.Size = New System.Drawing.Size(272, 326)
        Me.TabPageGame.TabIndex = 0
        Me.TabPageGame.Text = "Game"
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
        Me.ubcard1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard1.Location = New System.Drawing.Point(512, 32)
        Me.ubcard1.Name = "ubcard1"
        Me.ubcard1.Size = New System.Drawing.Size(136, 48)
        Me.ubcard1.TabIndex = 1
        Me.ubcard1.Text = "Card1"
        Me.ubcard1.UseVisualStyleBackColor = False
        '
        'ubcard2
        '
        Me.ubcard2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard2.Location = New System.Drawing.Point(656, 32)
        Me.ubcard2.Name = "ubcard2"
        Me.ubcard2.Size = New System.Drawing.Size(136, 48)
        Me.ubcard2.TabIndex = 2
        Me.ubcard2.Text = "Card2"
        '
        'ubcard3
        '
        Me.ubcard3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard3.Location = New System.Drawing.Point(512, 96)
        Me.ubcard3.Name = "ubcard3"
        Me.ubcard3.Size = New System.Drawing.Size(136, 48)
        Me.ubcard3.TabIndex = 3
        Me.ubcard3.Text = "Card3"
        '
        'ubcard4
        '
        Me.ubcard4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard4.Location = New System.Drawing.Point(656, 96)
        Me.ubcard4.Name = "ubcard4"
        Me.ubcard4.Size = New System.Drawing.Size(136, 48)
        Me.ubcard4.TabIndex = 4
        Me.ubcard4.Text = "Card4"
        '
        'ubroad
        '
        Me.ubroad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubroad.Location = New System.Drawing.Point(512, 206)
        Me.ubroad.Name = "ubroad"
        Me.ubroad.Size = New System.Drawing.Size(87, 32)
        Me.ubroad.TabIndex = 5
        Me.ubroad.Text = "Road"
        '
        'gbP1
        '
        Me.gbP1.Controls.Add(Me.p1_details)
        Me.gbP1.Controls.Add(Me.txtP1)
        Me.gbP1.Location = New System.Drawing.Point(16, 527)
        Me.gbP1.Name = "gbP1"
        Me.gbP1.Size = New System.Drawing.Size(104, 130)
        Me.gbP1.TabIndex = 11
        Me.gbP1.TabStop = False
        Me.gbP1.Text = "Player 1"
        Me.gbP1.Visible = False
        '
        'p1_details
        '
        Me.p1_details.Location = New System.Drawing.Point(77, 102)
        Me.p1_details.Name = "p1_details"
        Me.p1_details.Size = New System.Drawing.Size(19, 22)
        Me.p1_details.TabIndex = 3
        Me.p1_details.Text = "?"
        Me.p1_details.UseVisualStyleBackColor = True
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
        Me.gbP2.Controls.Add(Me.p2_details)
        Me.gbP2.Controls.Add(Me.txtP2)
        Me.gbP2.Location = New System.Drawing.Point(136, 527)
        Me.gbP2.Name = "gbP2"
        Me.gbP2.Size = New System.Drawing.Size(104, 130)
        Me.gbP2.TabIndex = 12
        Me.gbP2.TabStop = False
        Me.gbP2.Text = "Player 2"
        Me.gbP2.Visible = False
        '
        'p2_details
        '
        Me.p2_details.Location = New System.Drawing.Point(77, 102)
        Me.p2_details.Name = "p2_details"
        Me.p2_details.Size = New System.Drawing.Size(19, 22)
        Me.p2_details.TabIndex = 4
        Me.p2_details.Text = "?"
        Me.p2_details.UseVisualStyleBackColor = True
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
        Me.gbP4.Controls.Add(Me.p4_details)
        Me.gbP4.Controls.Add(Me.txtP4)
        Me.gbP4.Location = New System.Drawing.Point(376, 527)
        Me.gbP4.Name = "gbP4"
        Me.gbP4.Size = New System.Drawing.Size(104, 130)
        Me.gbP4.TabIndex = 13
        Me.gbP4.TabStop = False
        Me.gbP4.Text = "Player 4"
        Me.gbP4.Visible = False
        '
        'p4_details
        '
        Me.p4_details.Location = New System.Drawing.Point(77, 102)
        Me.p4_details.Name = "p4_details"
        Me.p4_details.Size = New System.Drawing.Size(19, 22)
        Me.p4_details.TabIndex = 6
        Me.p4_details.Text = "?"
        Me.p4_details.UseVisualStyleBackColor = True
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
        Me.gbP3.Controls.Add(Me.p3_details)
        Me.gbP3.Controls.Add(Me.txtP3)
        Me.gbP3.Location = New System.Drawing.Point(256, 527)
        Me.gbP3.Name = "gbP3"
        Me.gbP3.Size = New System.Drawing.Size(104, 130)
        Me.gbP3.TabIndex = 14
        Me.gbP3.TabStop = False
        Me.gbP3.Text = "Player 3"
        Me.gbP3.Visible = False
        '
        'p3_details
        '
        Me.p3_details.Location = New System.Drawing.Point(79, 102)
        Me.p3_details.Name = "p3_details"
        Me.p3_details.Size = New System.Drawing.Size(19, 22)
        Me.p3_details.TabIndex = 5
        Me.p3_details.Text = "?"
        Me.p3_details.UseVisualStyleBackColor = True
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
        Me.Infotab.Controls.Add(Me.TabPageEvents)
        Me.Infotab.Controls.Add(Me.TabPageCard)
        Me.Infotab.Controls.Add(Me.TabPageCity)
        Me.Infotab.Controls.Add(Me.TabPagePerson)
        Me.Infotab.Controls.Add(Me.TabPageBuilding)
        Me.Infotab.Controls.Add(Me.TabPageView)
        Me.Infotab.Controls.Add(Me.TabPageGame)
        Me.Infotab.Location = New System.Drawing.Point(512, 305)
        Me.Infotab.Name = "Infotab"
        Me.Infotab.SelectedIndex = 0
        Me.Infotab.Size = New System.Drawing.Size(280, 352)
        Me.Infotab.TabIndex = 15
        '
        'TabPageBuilding
        '
        Me.TabPageBuilding.Controls.Add(Me.lblBuilding)
        Me.TabPageBuilding.Controls.Add(Me.ubBForward)
        Me.TabPageBuilding.Controls.Add(Me.ubBBack)
        Me.TabPageBuilding.Controls.Add(Me.txt_building)
        Me.TabPageBuilding.Location = New System.Drawing.Point(4, 22)
        Me.TabPageBuilding.Name = "TabPageBuilding"
        Me.TabPageBuilding.Size = New System.Drawing.Size(272, 326)
        Me.TabPageBuilding.TabIndex = 1
        Me.TabPageBuilding.Text = "Building"
        '
        'lblBuilding
        '
        Me.lblBuilding.Location = New System.Drawing.Point(16, 299)
        Me.lblBuilding.Name = "lblBuilding"
        Me.lblBuilding.Size = New System.Drawing.Size(136, 16)
        Me.lblBuilding.TabIndex = 8
        Me.lblBuilding.Text = "Displaying X of Y"
        '
        'ubBForward
        '
        Me.ubBForward.Location = New System.Drawing.Point(216, 296)
        Me.ubBForward.Name = "ubBForward"
        Me.ubBForward.Size = New System.Drawing.Size(48, 23)
        Me.ubBForward.TabIndex = 7
        Me.ubBForward.Text = ">>>"
        '
        'ubBBack
        '
        Me.ubBBack.Location = New System.Drawing.Point(160, 296)
        Me.ubBBack.Name = "ubBBack"
        Me.ubBBack.Size = New System.Drawing.Size(48, 23)
        Me.ubBBack.TabIndex = 6
        Me.ubBBack.Text = "<<<"
        '
        'txt_building
        '
        Me.txt_building.AcceptsReturn = True
        Me.txt_building.AcceptsTab = True
        Me.txt_building.Location = New System.Drawing.Point(13, 15)
        Me.txt_building.Multiline = True
        Me.txt_building.Name = "txt_building"
        Me.txt_building.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_building.Size = New System.Drawing.Size(248, 275)
        Me.txt_building.TabIndex = 5
        '
        'ubland
        '
        Me.ubland.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubland.Location = New System.Drawing.Point(656, 206)
        Me.ubland.Name = "ubland"
        Me.ubland.Size = New System.Drawing.Size(136, 32)
        Me.ubland.TabIndex = 16
        Me.ubland.Text = "Land"
        '
        'ubEnd
        '
        Me.ubEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'ubWipe
        '
        Me.ubWipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubWipe.Location = New System.Drawing.Point(512, 159)
        Me.ubWipe.Name = "ubWipe"
        Me.ubWipe.Size = New System.Drawing.Size(136, 32)
        Me.ubWipe.TabIndex = 21
        Me.ubWipe.Text = "Clear Above"
        '
        'BuildingDropdown
        '
        Me.BuildingDropdown.FormattingEnabled = True
        Me.BuildingDropdown.Location = New System.Drawing.Point(656, 159)
        Me.BuildingDropdown.Name = "BuildingDropdown"
        Me.BuildingDropdown.Size = New System.Drawing.Size(136, 21)
        Me.BuildingDropdown.TabIndex = 22
        '
        'btnCheat
        '
        Me.btnCheat.Location = New System.Drawing.Point(747, 256)
        Me.btnCheat.Name = "btnCheat"
        Me.btnCheat.Size = New System.Drawing.Size(45, 23)
        Me.btnCheat.TabIndex = 23
        Me.btnCheat.Text = "Cheat"
        Me.btnCheat.UseVisualStyleBackColor = True
        '
        'ubroadmax
        '
        Me.ubroadmax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubroadmax.Location = New System.Drawing.Point(605, 206)
        Me.ubroadmax.Name = "ubroadmax"
        Me.ubroadmax.Size = New System.Drawing.Size(43, 32)
        Me.ubroadmax.TabIndex = 24
        Me.ubroadmax.Text = "Max"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(810, 678)
        Me.Controls.Add(Me.ubroadmax)
        Me.Controls.Add(Me.btnCheat)
        Me.Controls.Add(Me.BuildingDropdown)
        Me.Controls.Add(Me.ubWipe)
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
        Me.TabPageEvents.ResumeLayout(False)
        Me.TabPageEvents.PerformLayout()
        Me.TabPageCard.ResumeLayout(False)
        Me.TabPageCard.PerformLayout()
        Me.TabPageCity.ResumeLayout(False)
        Me.TabPageCity.PerformLayout()
        Me.TabPagePerson.ResumeLayout(False)
        Me.TabPagePerson.PerformLayout()
        Me.TabPageView.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPageGame.ResumeLayout(False)
        Me.TabPageGame.PerformLayout()
        Me.gbP1.ResumeLayout(False)
        Me.gbP1.PerformLayout()
        Me.gbP2.ResumeLayout(False)
        Me.gbP2.PerformLayout()
        Me.gbP4.ResumeLayout(False)
        Me.gbP4.PerformLayout()
        Me.gbP3.ResumeLayout(False)
        Me.gbP3.PerformLayout()
        Me.Infotab.ResumeLayout(False)
        Me.TabPageBuilding.ResumeLayout(False)
        Me.TabPageBuilding.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Initialization "
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- Urban Blight begins HERE
        SetDebugMode(True)

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

        '-- Fill building dropdown
        FillBuildingDropdown()

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

        '-- Display Player Info GUIs for active players
        For i As Integer = 0 To Players.Count - 1
            Dim thisPlayer As Player = Players(i)

            '-- Display player Info GUIs for active players
            If thisPlayer.PlayerType <> PlayerNone Then
                If i = 0 Then
                    Players(i).Flag = Flag1
                    gbP1.Visible = True
                    gbP1.Text = thisPlayer.GetPlayerName()
                    gbP1.BackColor = thisPlayer.Flag
                    If thisPlayer.PlayerType = PlayerHuman Then
                        p1_details.Visible = False
                    End If
                ElseIf i = 1 Then
                    Players(i).Flag = Flag2
                    gbP2.Visible = True
                    gbP2.Text = thisPlayer.GetPlayerName()
                    gbP2.BackColor = thisPlayer.Flag
                    If thisPlayer.PlayerType = PlayerHuman Then
                        p2_details.Visible = False
                    End If
                ElseIf i = 2 Then
                    Players(i).Flag = Flag3
                    gbP3.Visible = True
                    gbP3.Text = thisPlayer.GetPlayerName()
                    gbP3.BackColor = thisPlayer.Flag
                    If thisPlayer.PlayerType = PlayerHuman Then
                        p3_details.Visible = False
                    End If
                ElseIf i = 3 Then
                    Players(i).Flag = Flag4
                    gbP4.Visible = True
                    gbP4.Text = thisPlayer.GetPlayerName()
                    gbP4.BackColor = thisPlayer.Flag
                    If thisPlayer.PlayerType = PlayerHuman Then
                        p4_details.Visible = False
                    End If
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

        '-- Mark terrain by water (has to be after opening cities are founded in case they were on a lake)
        UpdateCoastline()

        '-- Redraw the grid
        UpdateGrid()
    End Sub

#End Region

#Region " Player Actions "

    Private Sub MapMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim TheBox As Label = CType(sender, Label)
        Dim X, Y As Integer
        GetCoords(X, Y, TheBox.Tag)

        '-- Deselect the previous grid box
        Dim DoubleClick As Boolean = False
        If ClickCity IsNot Nothing Then
            ClickCity.GridSquare.BorderStyle = BorderStyle.FixedSingle
            If ClickCity.Equals(GridArray(X, Y)) Then
                DoubleClick = True
            End If
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

        '-- Don't switch to the city tab by default if user was looking at people or buildings
        Dim DontSwitch As Boolean = False
        If ClickCity.OwnerID >= 0 Then
            If Infotab.SelectedIndex = PersonTab Or Infotab.SelectedIndex = BuildingTab Then
                DontSwitch = True
            End If
        End If

        '-- Switch to the city tab when the user clicks on a grid square
        If e.Button = MouseButtons.Left Then
            Dim BuildSuccess As Boolean = Build()
            UpdateTabs()
            If DoubleClick Or BuildSuccess Or (Not DontSwitch) Then
                Infotab.SelectedTab = Infotab.TabPages(CityTab)
            End If
        ElseIf e.Button = MouseButtons.Right Then
            '-- Use for view mode?
        End If

    End Sub

    Function Build() As Boolean
        Dim UpdateNeeded As Boolean = False
        Dim SpendingMoney As Integer = Players(CurrentPlayerIndex).TotalMoney

        '-- What is the cost of this card?
        Dim CardCost As Integer = 0
        If SelectedCard = RoadCard Then
            CardCost = RoadCostBase
        ElseIf SelectedCard = RoadMaxCard Then
            CardCost = RoadCostBase * (RoadHighway - ClickCity.Transportation)
        ElseIf SelectedCard = LandCard Then
            If ClickCity.Terrain = TerrainSwamp Then
                CardCost = 0 '-- Swamps are free!
            Else
                CardCost = CurrentPlayer.GetPlayerLandCost()
            End If
        ElseIf SelectedCard = WipeCard Then
            CardCost = CurrentPlayer.GetPlayerWipeCost()
        ElseIf SelectedCard >= 0 And SelectedCard < CardCount Then
            CardCost = Cards(SelectedCard).Cost
        Else
            Return False
        End If

        '-- Can the player afford it?
        If CardCost > SpendingMoney Then
            Return False
        End If

        '-- Was the selected CitySquare valid?
        If SelectedCard = LandCard Then
            '-- For Land cards they must be unowned, adjacent to land the player already owns, and not a lake
            If ClickCity.OwnerID >= 0 Or ClickCity.Terrain = TerrainLake Or (Not CurrentPlayer.OwnedAdjacent(ClickCity)) Then
                Return False
            End If
        ElseIf SelectedCard <> WipeCard Then
            '-- For Roads and Buildings the player must already own the land
            If ClickCity.OwnerID <> CurrentPlayerIndex Then
                Return False
            End If

            '-- Roads can't be built if highway is already present
            If (SelectedCard = RoadCard Or SelectedCard = RoadMaxCard) And ClickCity.Transportation = RoadHighway Then
                Return False
            End If
        End If

        '-- Pay for construction
        Players(CurrentPlayerIndex).TotalMoney -= CardCost
        UpdateNeeded = True

        '-- Do construction
        If SelectedCard = RoadCard Then
            '-- Upgrade Road
            ClickCity.AddRoad()
        ElseIf SelectedCard = RoadMaxCard Then
            '-- Upgrade Road to Max
            ClickCity.Transportation = RoadHighway
        ElseIf SelectedCard = LandCard Then
            '-- Expand Territory
            ClickCity.OwnerID = CurrentPlayerIndex

            '-- Generate random name
            ClickCity.CityName = Namer.GenerateCityName(ClickCity)

            '-- Handle special terrain bonuses
            If ClickCity.Terrain = TerrainDesert Then
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
                Dim maxFreePopulation As Integer = Math.Min(10, Math.Floor(SafeDivide(CurrentPlayer.GetPlayerPopulationCount(), 15.0)) + 2)
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
        ElseIf SelectedCard = WipeCard Then
            Cards.Clear()
            CurrentPlayer.WipeCost = WipeCostBase + 5
        End If

        '-- Update grid, cards, and players
        If UpdateNeeded Then
            UpdateGrid()
            UpdatePlayers()
            UpdateCards()

            SelectedCard = NoCard
            UpdateCardSelection()
        End If

        Return True
    End Function

#End Region

#Region " Game Loop "
    Sub NextPlayer()
        '-- Cleanup
        ResetForNewTurn()

        '--Advance to next player (If last player in round and end condition is met, show Game Over screen)
        AdvanceToNextPlayer()

        '-- Refill Hand and Update Costs
        UpdateCards()

        '-- Handle events: births, deaths, movement, employment, crime, taxation, and business expansion
        EventsHappen()

        '-- Update averages for views and successes for businesses
        UpdateAverages()

        '-- Update grid appearence and texts
        UpdateGrid()

        '-- Update player info
        UpdatePlayers()

        '-- Take turn automatically if AI
        RunAI()

        '-- Display event messages
        UpdateTextBox(txt_event, Diary.toString())
        Infotab.SelectedTab = Infotab.TabPages(EventTab)

    End Sub

    Sub RunAI()

        '-- Toggle the buttons so humans can't play for the computer
        Dim toggleButtons As Boolean = True
        If CurrentPlayer.PlayerType = PlayerAI Then
            toggleButtons = False
        End If
        ubcard1.Enabled = toggleButtons
        ubcard2.Enabled = toggleButtons
        ubcard3.Enabled = toggleButtons
        ubcard4.Enabled = toggleButtons
        ubroad.Enabled = toggleButtons
        ubroadmax.Enabled = toggleButtons
        ubland.Enabled = toggleButtons
        ubWipe.Enabled = toggleButtons

        '-- If not an AI bail at this point
        If CurrentPlayer.PlayerType <> PlayerAI Then
            Return
        End If

        Dim AIActionEvents As String = ""
        Dim AIActionCount As Integer = 0

        '-- Loop until the AI does not have enough money for the action they want to take.
        Dim ActionSuccess As Boolean = False
        Do
            '-- Get the AIs decision (the action they chose and where they chose to make it)
            Dim AIDecision As Integer = CurrentPlayer.ChooseNextAction()

            If AIDecision = AIPass Then
                ActionSuccess = False
            Else
                SelectedCard = AIDecision
                ClickCity = CurrentPlayer.BestMove
                ActionSuccess = Build()
            End If

            If ActionSuccess Then
                AIActionCount += 1
                If AIDecision >= 0 And AIDecision < CardCount Then
                    Dim newBuilding As Building = ClickCity.Buildings(ClickCity.Buildings.Count - 1) '-- Get latest building
                    Diary.AIBuildEvents.AddEvent(CurrentPlayer.GetPlayerName() + " bought a " + newBuilding.GetNameAndAddress())
                ElseIf AIDecision = RoadCard Then
                    Diary.AIRoadEvents.AddEvent(CurrentPlayer.GetPlayerName() + " upgraded the road at " + ClickCity.GetName())
                ElseIf AIDecision = LandCard Then
                    Diary.AILandEvents.AddEvent(CurrentPlayer.GetPlayerName() + " founded " + ClickCity.GetName() + " at " + ClickCity.GetLocationText())
                End If
            ElseIf AIActionCount = 0 Then
                Diary.AILandEvents.AddEvent(CurrentPlayer.GetPlayerName() + " passed on their turn")
            End If

        Loop While ActionSuccess


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

    Sub EventsHappen()
        Dim TurnEvents As New Turn(CurrentPlayer, theYear)
        TurnEvents.UpdatePeople()
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
            Dim newBuilding As Building = BuildingGenerator.CreateBuilding(-1)
            Cards.Add(newBuilding)
        End While

        '--Reduce Cost of Available Buildings
        Dim i As Integer
        For i = 0 To CardCount - 1

            Dim CardBuilding As Building = Cards(i)
            If CardBuilding.Cost = 0 Then
                If CardBuilding.RejectionCount >= Players.Count Then
                    '-- If the rejection level of a free building hit the player count, replace it
                    Cards.RemoveAt(i)
                    Dim newBuilding As Building = BuildingGenerator.CreateBuilding(-1)
                    Cards.Add(newBuilding)
                Else
                    '-- No one bought this building even though it was free. Escallate its rejection level
                    CardBuilding.RejectionCount += 1
                End If
            End If

            '-- Reduce cost of available buildings by 5
            CardBuilding.Cost = Math.Max(CardBuilding.Cost - DropCostBase, 0)
        Next

        '-- Reduce cost for this player to wipe the buildings cards by 5 (no lower limit)
        CurrentPlayer.WipeCost -= DropCostBase

        '--Update building card text
        For i = 0 To CardCount - 1

            Dim CardBuilding As Building = Cards(i)

            Dim cardText As String = CardBuilding.GetName() + ControlChars.NewLine
            cardText += "$" + CardBuilding.Cost.ToString() + " - "
            cardText += CardBuilding.Jobs.ToString() + " jobs"

            Select Case i
                Case 0
                    ubcard1.Text = cardText
                Case 1
                    ubcard2.Text = cardText
                Case 2
                    ubcard3.Text = cardText
                Case 3
                    ubcard4.Text = cardText
            End Select
        Next

        '--Update wipe card text
        Dim WipeCost As Integer = CurrentPlayer.GetPlayerWipeCost()

        ubWipe.Text = "$" + WipeCost.ToString() + " - Redraw"
        '--Update land card text
        Dim RoadCost As Integer = RoadCostBase
        ubroad.Text = "$" + RoadCost.ToString() + " - Road"

        '--Update land card text
        Dim LandCost As Integer = CurrentPlayer.GetPlayerLandCost()
        ubland.Text = "$" + LandCost.ToString() + " - Land"

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

        '-- Update the person tab
        Dim personText As String = ""
        Dim currentPop As Integer = ClickCity.getPopulation()
        If currentPop > 0 Then
            SelectedPerson = 0
            personText = ClickCity.People(0).toString()
            lblPerson.Text = "Displaying 1 of " + currentPop.ToString()
        Else
            personText = ""
            lblPerson.Text = "Displaying 0 of 0"
        End If
        UpdateTextBox(txt_person, personText)

        '-- Update the building tab
        Dim buildingText As String = ""
        Dim currentDev As Integer = ClickCity.getDevelopment()
        If currentDev > 0 Then
            SelectedBuilding = 0
            buildingText = ClickCity.Buildings(0).toString()
            lblBuilding.Text = "Displaying 1 of " + currentDev.ToString()
        Else
            buildingText = ""
            lblBuilding.Text = "Displaying 0 of 0"
        End If
        UpdateTextBox(txt_building, buildingText)
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
        Dim GameTypeText As String = ""
        Dim WinningString As String = ""
        Dim maxValue As Integer = 0
        Dim currentValue As Integer = 0
        Dim winningPlayer As Integer = -1
        For i As Integer = 0 To Players.Count - 1
            Dim currentPlayer As Player = Players(i)

            Select Case GameType
                Case ScoreGame
                    GameTypeText = "Score"
                    currentValue = currentPlayer.GetPlayerScore()
                Case TerritoryGame
                    GameTypeText = "Territory"
                    currentValue = currentPlayer.GetPlayerTerritoryCount()
                Case PopulationGame
                    GameTypeText = "Population"
                    currentValue = currentPlayer.GetPlayerPopulationCount()
                Case DevelopmentGame
                    GameTypeText = "Development"
                    currentValue = currentPlayer.GetPlayerDevelopment()
                Case YearGame
                    GameTypeText = "Score"
                    currentValue = currentPlayer.GetPlayerScore()
            End Select

            WinningString += "Player " + (i + 1).ToString + " " + GameTypeText + ": " + currentValue.ToString + ControlChars.NewLine
            If currentValue > maxValue Then
                maxValue = currentValue
                winningPlayer = i + 1
            End If
        Next
        WinningString += ControlChars.NewLine + "The winner is: Player " + winningPlayer.ToString + ControlChars.NewLine


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
            ClickCity = Nothing
        End If

        SelectedCard = NoCard
        SelectedPerson = -1
        SelectedBuilding = -1
        Diary.ClearEvents()
        UpdateTextBox(txt_event, "")
        UpdateTextBox(txt_card, "")
        UpdateTextBox(txt_city, "")
        UpdateTextBox(txt_person, "")
        lblPerson.Text = "Displaying 0 of 0"
        CurrentView = PopView

        '-- Display new hint
        DisplayHint()
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

    Private Sub ubroadmax_Click(sender As Object, e As EventArgs) Handles ubroadmax.Click
        CardClick(RoadMaxCard)
    End Sub

    Private Sub ubland_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubland.Click
        CardClick(LandCard)
    End Sub

    Private Sub ubWipe_Click(sender As Object, e As EventArgs) Handles ubWipe.Click
        CardClick(WipeCard)
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
            cardText = Cards(SelectedCard).toString()
        ElseIf SelectedCard = RoadCard Then
            cardText = "Roads help increase the mobility of you population and allows them to reach nearby squares within your kingdom. Roads always cost " + RoadCostBase.ToString()
        ElseIf SelectedCard = LandCard Then
            cardText = "Land can only be bought adjacent to land you already own. The cost increases by 20 after every time you buy."
        ElseIf SelectedCard = WipeCard Then
            cardText = "Redraw discards the currently available buildings and draws new ones, for the base price of $100. Click anywhere on the map to confirm." + ControlChars.NewLine + ControlChars.NewLine
            cardText += "Like with buildings, the cost drops $5 after every action you take." + ControlChars.NewLine + ControlChars.NewLine
            cardText += "Unlike buildings, the cost is unique to each player and can go below $0."
        ElseIf SelectedCard = RoadMaxCard Then
            cardText = "Increase road on a square to the maximum level you can afford."
        End If
        UpdateTextBox(txt_card, cardText)

        Infotab.SelectedTab = Infotab.TabPages(CardTab)
    End Sub

    Public Sub UpdateCardSelection()

        Dim newBold As New Font(ubEnd.Font.FontFamily, 10, FontStyle.Bold)
        Dim newRegular As New Font(ubEnd.Font.FontFamily, 10, FontStyle.Regular)

        ubcard1.Font = newRegular
        ubcard2.Font = newRegular
        ubcard3.Font = newRegular
        ubcard4.Font = newRegular
        ubroad.Font = newRegular
        ubland.Font = newRegular
        ubWipe.Font = newRegular
        ubroadmax.Font = newRegular

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
            Case WipeCard
                ubWipe.Font = newBold
            Case RoadMaxCard
                ubroadmax.Font = newBold
        End Select

    End Sub

    Private Sub ubEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubEnd.Click
        SelectedCard = NoCard
        UpdateCardSelection()
        NextPlayer()
    End Sub

    '-- Person viewing
    Private Sub ubPBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubPBack.Click
        Dim selectedPop As Integer = ClickCity.getPopulation()
        If selectedPop > 0 And SelectedPerson > 0 Then
            SelectedPerson -= 1
            lblPerson.Text = "Displaying " + (SelectedPerson + 1).ToString() + " of " + selectedPop.ToString()
            If SelectedPerson < selectedPop Then
                UpdateTextBox(txt_person, ClickCity.People(SelectedPerson).toString())
            End If
        End If
    End Sub

    Private Sub ubPForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubPForward.Click
        Dim selectedPop As Integer = ClickCity.getPopulation()
        If selectedPop > 0 And SelectedPerson < selectedPop - 1 Then
            SelectedPerson += 1
            lblPerson.Text = "Displaying " + (SelectedPerson + 1).ToString() + " of " + selectedPop.ToString()
            UpdateTextBox(txt_person, ClickCity.People(SelectedPerson).toString())
        End If
    End Sub

    '-- Building viewing
    Private Sub ubBBack_Click(sender As Object, e As EventArgs) Handles ubBBack.Click
        Dim selectedDev As Integer = ClickCity.getDevelopment()
        If selectedDev > 0 And SelectedBuilding > 0 Then
            SelectedBuilding -= 1
            lblBuilding.Text = "Displaying " + (SelectedBuilding + 1).ToString() + " of " + selectedDev.ToString()
            If SelectedBuilding < selectedDev Then
                UpdateTextBox(txt_building, ClickCity.Buildings(SelectedBuilding).toString())
            End If
        End If
    End Sub

    Private Sub ubBForward_Click(sender As Object, e As EventArgs) Handles ubBForward.Click
        Dim selectedDev As Integer = ClickCity.getDevelopment()
        If selectedDev > 0 And SelectedBuilding < selectedDev - 1 Then
            SelectedBuilding += 1
            lblBuilding.Text = "Displaying " + (SelectedBuilding + 1).ToString() + " of " + selectedDev.ToString()
            UpdateTextBox(txt_building, ClickCity.Buildings(SelectedBuilding).toString())
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
        Dim CName As New RenameCity
        CName.ShowDialog()
        ClickCity.CityName = LastCityName
        UpdateTabs()
    End Sub

    Private Sub ubHint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubHint.Click
        DisplayHint()
    End Sub

    Private Sub p1_details_Click(sender As Object, e As EventArgs) Handles p1_details.Click
        DisplayPlayerInfo(0)
    End Sub

    Private Sub p2_details_Click(sender As Object, e As EventArgs) Handles p2_details.Click
        DisplayPlayerInfo(1)
    End Sub

    Private Sub p3_details_Click(sender As Object, e As EventArgs) Handles p3_details.Click
        DisplayPlayerInfo(2)
    End Sub

    Private Sub p4_details_Click(sender As Object, e As EventArgs) Handles p4_details.Click
        DisplayPlayerInfo(3)
    End Sub

    Public Sub DisplayPlayerInfo(ByVal playerIndex As Integer)

        Dim thisPlayer As Player = Players(playerIndex)

        Dim playerInfoText As String = ""
        playerInfoText += thisPlayer.toString() + ControlChars.NewLine
        If thisPlayer.PlayerType = PlayerAI Then
            playerInfoText += thisPlayer.Personality.toString()
        End If

        MsgBox(playerInfoText, MsgBoxStyle.Information, "Player Info")
    End Sub

#End Region

#Region " Debug Stuff "

    Public Sub SetDebugMode(ByVal debugBool As Boolean)
        DebugMode = debugBool
        BuildingDropdown.Visible = DebugMode
        btnCheat.Visible = DebugMode
    End Sub

    Public Sub FillBuildingDropdown()
        For i As Integer = 0 To BuildingGen.BuildingEnum.BuildingCount - 1
            BuildingDropdown.Items.Add(BuildingGenerator.GetName(i))
        Next
    End Sub

    Private Sub BuildingDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BuildingDropdown.SelectedIndexChanged
        '-- Add the building of the type selected to the dropdown
        Dim newBuildingType As Integer = BuildingDropdown.SelectedIndex

        Cards.RemoveAt(0)
        Dim newBuilding As Building = BuildingGenerator.CreateBuilding(newBuildingType)
        Cards.Add(newBuilding)
        UpdateCards()
    End Sub

    Private Sub btnCheat_Click(sender As Object, e As EventArgs) Handles btnCheat.Click
        CurrentPlayer.TotalMoney += 1000000
        UpdatePlayers()
    End Sub


#End Region

End Class

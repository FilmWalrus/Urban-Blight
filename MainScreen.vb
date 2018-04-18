Imports System.Drawing

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Variables "

    Public ButtonList As New List(Of System.Windows.Forms.Button)

    Public DisableDropdownChange As Boolean = True

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
    Friend WithEvents TabPageBuilding As TabPage
    Friend WithEvents lblBuilding As Label
    Friend WithEvents ubBForward As Button
    Friend WithEvents ubBBack As Button
    Friend WithEvents txt_building As TextBox
    Friend WithEvents btnCheat As Button
    Friend WithEvents MarketPanel As Panel
    Friend WithEvents ubcard1 As Button
    Friend WithEvents BuildingDropdown As ComboBox
    Friend WithEvents ubEnd As Button
    Friend WithEvents gbP1 As Panel
    Friend WithEvents gbP2 As Panel
    Friend WithEvents gbP3 As Panel
    Friend WithEvents gbP4 As Panel
    Friend WithEvents MarketLabel As Label
    Friend WithEvents ubcard2 As Button
    Friend WithEvents ubland As Button
    Friend WithEvents ubroadmax As Button
    Friend WithEvents ubroad As Button
    Friend WithEvents ubWipe As Button
    Friend WithEvents ubcard4 As Button
    Friend WithEvents ubcard3 As Button
    Friend WithEvents ubcardChoice As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ViewDropdown As ComboBox
    Friend WithEvents btnSkip As Button
    Friend WithEvents ubVForward As Button
    Friend WithEvents ubVBack As Button
    Friend WithEvents ubCloseBuilding As Button
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
    Friend WithEvents UltraTabSharedControlsPage1 As TabPage
    Friend WithEvents Infotab As TabControl
    Friend WithEvents TabPageEvents As TabPage
    Friend WithEvents TabPageCity As TabPage
    Friend WithEvents TabPagePerson As TabPage
    Friend WithEvents txt_event As System.Windows.Forms.TextBox
    Friend WithEvents txt_person As System.Windows.Forms.TextBox
    Friend WithEvents txt_city As System.Windows.Forms.TextBox
    Friend WithEvents ubPBack As System.Windows.Forms.Button
    Friend WithEvents ubPForward As System.Windows.Forms.Button
    Friend WithEvents lblPerson As Label
    Friend WithEvents txtP1 As System.Windows.Forms.TextBox
    Friend WithEvents txtP2 As System.Windows.Forms.TextBox
    Friend WithEvents txtP3 As System.Windows.Forms.TextBox
    Friend WithEvents txtP4 As System.Windows.Forms.TextBox
    Friend WithEvents ubRename As System.Windows.Forms.Button
    Friend WithEvents TabPageGame As TabPage
    Friend WithEvents ubNew As System.Windows.Forms.Button
    Friend WithEvents ubQuit As System.Windows.Forms.Button
    Friend WithEvents ubHint As System.Windows.Forms.Button
    Friend WithEvents txtHint As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.UltraTab1 = New System.Windows.Forms.TabControl()
        Me.TabPageEvents = New System.Windows.Forms.TabPage()
        Me.txt_event = New System.Windows.Forms.TextBox()
        Me.UltraTab2 = New System.Windows.Forms.TabControl()
        Me.UltraTab3 = New System.Windows.Forms.TabControl()
        Me.TabPageCity = New System.Windows.Forms.TabPage()
        Me.ubRename = New System.Windows.Forms.Button()
        Me.txt_city = New System.Windows.Forms.TextBox()
        Me.UltraTab4 = New System.Windows.Forms.TabControl()
        Me.TabPagePerson = New System.Windows.Forms.TabPage()
        Me.lblPerson = New System.Windows.Forms.Label()
        Me.ubPForward = New System.Windows.Forms.Button()
        Me.ubPBack = New System.Windows.Forms.Button()
        Me.txt_person = New System.Windows.Forms.TextBox()
        Me.UltraTab5 = New System.Windows.Forms.TabControl()
        Me.UltraTab6 = New System.Windows.Forms.TabControl()
        Me.TabPageGame = New System.Windows.Forms.TabPage()
        Me.btnSkip = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ubVForward = New System.Windows.Forms.Button()
        Me.ViewDropdown = New System.Windows.Forms.ComboBox()
        Me.ubVBack = New System.Windows.Forms.Button()
        Me.txtHint = New System.Windows.Forms.TextBox()
        Me.ubHint = New System.Windows.Forms.Button()
        Me.ubQuit = New System.Windows.Forms.Button()
        Me.ubNew = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.p1_details = New System.Windows.Forms.Button()
        Me.txtP1 = New System.Windows.Forms.TextBox()
        Me.p2_details = New System.Windows.Forms.Button()
        Me.txtP2 = New System.Windows.Forms.TextBox()
        Me.p4_details = New System.Windows.Forms.Button()
        Me.txtP4 = New System.Windows.Forms.TextBox()
        Me.p3_details = New System.Windows.Forms.Button()
        Me.txtP3 = New System.Windows.Forms.TextBox()
        Me.Infotab = New System.Windows.Forms.TabControl()
        Me.TabPageBuilding = New System.Windows.Forms.TabPage()
        Me.lblBuilding = New System.Windows.Forms.Label()
        Me.ubBForward = New System.Windows.Forms.Button()
        Me.ubBBack = New System.Windows.Forms.Button()
        Me.txt_building = New System.Windows.Forms.TextBox()
        Me.btnCheat = New System.Windows.Forms.Button()
        Me.MarketPanel = New System.Windows.Forms.Panel()
        Me.BuildingDropdown = New System.Windows.Forms.ComboBox()
        Me.ubcardChoice = New System.Windows.Forms.Button()
        Me.ubland = New System.Windows.Forms.Button()
        Me.ubroadmax = New System.Windows.Forms.Button()
        Me.ubroad = New System.Windows.Forms.Button()
        Me.ubWipe = New System.Windows.Forms.Button()
        Me.MarketLabel = New System.Windows.Forms.Label()
        Me.ubcard4 = New System.Windows.Forms.Button()
        Me.ubcard3 = New System.Windows.Forms.Button()
        Me.ubcard2 = New System.Windows.Forms.Button()
        Me.ubcard1 = New System.Windows.Forms.Button()
        Me.ubEnd = New System.Windows.Forms.Button()
        Me.gbP1 = New System.Windows.Forms.Panel()
        Me.gbP2 = New System.Windows.Forms.Panel()
        Me.gbP3 = New System.Windows.Forms.Panel()
        Me.gbP4 = New System.Windows.Forms.Panel()
        Me.ubCloseBuilding = New System.Windows.Forms.Button()
        Me.TabPageEvents.SuspendLayout()
        Me.TabPageCity.SuspendLayout()
        Me.TabPagePerson.SuspendLayout()
        Me.TabPageGame.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Infotab.SuspendLayout()
        Me.TabPageBuilding.SuspendLayout()
        Me.MarketPanel.SuspendLayout()
        Me.gbP1.SuspendLayout()
        Me.gbP2.SuspendLayout()
        Me.gbP3.SuspendLayout()
        Me.gbP4.SuspendLayout()
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
        Me.TabPageEvents.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageEvents.Controls.Add(Me.txt_event)
        Me.TabPageEvents.Location = New System.Drawing.Point(4, 24)
        Me.TabPageEvents.Name = "TabPageEvents"
        Me.TabPageEvents.Size = New System.Drawing.Size(290, 547)
        Me.TabPageEvents.TabIndex = 0
        Me.TabPageEvents.Text = "Events"
        '
        'txt_event
        '
        Me.txt_event.AcceptsReturn = True
        Me.txt_event.AcceptsTab = True
        Me.txt_event.Location = New System.Drawing.Point(3, 3)
        Me.txt_event.Multiline = True
        Me.txt_event.Name = "txt_event"
        Me.txt_event.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_event.Size = New System.Drawing.Size(284, 541)
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
        Me.TabPageCity.Controls.Add(Me.ubRename)
        Me.TabPageCity.Controls.Add(Me.txt_city)
        Me.TabPageCity.Location = New System.Drawing.Point(4, 24)
        Me.TabPageCity.Name = "TabPageCity"
        Me.TabPageCity.Size = New System.Drawing.Size(290, 547)
        Me.TabPageCity.TabIndex = 0
        Me.TabPageCity.Text = "City"
        '
        'ubRename
        '
        Me.ubRename.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubRename.Location = New System.Drawing.Point(192, 13)
        Me.ubRename.Name = "ubRename"
        Me.ubRename.Size = New System.Drawing.Size(71, 24)
        Me.ubRename.TabIndex = 21
        Me.ubRename.Text = "Rename"
        '
        'txt_city
        '
        Me.txt_city.AcceptsReturn = True
        Me.txt_city.AcceptsTab = True
        Me.txt_city.Location = New System.Drawing.Point(3, 3)
        Me.txt_city.Multiline = True
        Me.txt_city.Name = "txt_city"
        Me.txt_city.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_city.Size = New System.Drawing.Size(287, 541)
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
        Me.TabPagePerson.Location = New System.Drawing.Point(4, 24)
        Me.TabPagePerson.Name = "TabPagePerson"
        Me.TabPagePerson.Size = New System.Drawing.Size(290, 547)
        Me.TabPagePerson.TabIndex = 0
        Me.TabPagePerson.Text = "Person"
        '
        'lblPerson
        '
        Me.lblPerson.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPerson.Location = New System.Drawing.Point(3, 519)
        Me.lblPerson.Name = "lblPerson"
        Me.lblPerson.Size = New System.Drawing.Size(143, 23)
        Me.lblPerson.TabIndex = 4
        Me.lblPerson.Text = "Displaying 0 of 0"
        Me.lblPerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ubPForward
        '
        Me.ubPForward.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubPForward.Location = New System.Drawing.Point(239, 519)
        Me.ubPForward.Name = "ubPForward"
        Me.ubPForward.Size = New System.Drawing.Size(48, 23)
        Me.ubPForward.TabIndex = 3
        Me.ubPForward.Text = ">>>"
        '
        'ubPBack
        '
        Me.ubPBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubPBack.Location = New System.Drawing.Point(183, 519)
        Me.ubPBack.Name = "ubPBack"
        Me.ubPBack.Size = New System.Drawing.Size(48, 23)
        Me.ubPBack.TabIndex = 2
        Me.ubPBack.Text = "<<<"
        '
        'txt_person
        '
        Me.txt_person.AcceptsReturn = True
        Me.txt_person.AcceptsTab = True
        Me.txt_person.Location = New System.Drawing.Point(3, 3)
        Me.txt_person.Multiline = True
        Me.txt_person.Name = "txt_person"
        Me.txt_person.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_person.Size = New System.Drawing.Size(284, 512)
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
        Me.TabPageGame.Controls.Add(Me.btnSkip)
        Me.TabPageGame.Controls.Add(Me.GroupBox1)
        Me.TabPageGame.Controls.Add(Me.txtHint)
        Me.TabPageGame.Controls.Add(Me.ubHint)
        Me.TabPageGame.Controls.Add(Me.ubQuit)
        Me.TabPageGame.Controls.Add(Me.ubNew)
        Me.TabPageGame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPageGame.Location = New System.Drawing.Point(4, 24)
        Me.TabPageGame.Name = "TabPageGame"
        Me.TabPageGame.Size = New System.Drawing.Size(290, 547)
        Me.TabPageGame.TabIndex = 0
        Me.TabPageGame.Text = "Game"
        '
        'btnSkip
        '
        Me.btnSkip.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSkip.Location = New System.Drawing.Point(13, 142)
        Me.btnSkip.Name = "btnSkip"
        Me.btnSkip.Size = New System.Drawing.Size(110, 48)
        Me.btnSkip.TabIndex = 21
        Me.btnSkip.Text = "Fast Forward"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ubVForward)
        Me.GroupBox1.Controls.Add(Me.ViewDropdown)
        Me.GroupBox1.Controls.Add(Me.ubVBack)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 89)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Views"
        '
        'ubVForward
        '
        Me.ubVForward.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubVForward.Location = New System.Drawing.Point(158, 57)
        Me.ubVForward.Name = "ubVForward"
        Me.ubVForward.Size = New System.Drawing.Size(102, 23)
        Me.ubVForward.TabIndex = 23
        Me.ubVForward.Text = ">>>"
        '
        'ViewDropdown
        '
        Me.ViewDropdown.FormattingEnabled = True
        Me.ViewDropdown.Location = New System.Drawing.Point(6, 25)
        Me.ViewDropdown.Name = "ViewDropdown"
        Me.ViewDropdown.Size = New System.Drawing.Size(254, 23)
        Me.ViewDropdown.TabIndex = 0
        '
        'ubVBack
        '
        Me.ubVBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubVBack.Location = New System.Drawing.Point(6, 57)
        Me.ubVBack.Name = "ubVBack"
        Me.ubVBack.Size = New System.Drawing.Size(104, 23)
        Me.ubVBack.TabIndex = 22
        Me.ubVBack.Text = "<<<"
        '
        'txtHint
        '
        Me.txtHint.AcceptsReturn = True
        Me.txtHint.AcceptsTab = True
        Me.txtHint.Location = New System.Drawing.Point(13, 220)
        Me.txtHint.Multiline = True
        Me.txtHint.Name = "txtHint"
        Me.txtHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHint.Size = New System.Drawing.Size(266, 136)
        Me.txtHint.TabIndex = 19
        '
        'ubHint
        '
        Me.ubHint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubHint.Location = New System.Drawing.Point(13, 375)
        Me.ubHint.Name = "ubHint"
        Me.ubHint.Size = New System.Drawing.Size(266, 48)
        Me.ubHint.TabIndex = 18
        Me.ubHint.Text = "Hint"
        '
        'ubQuit
        '
        Me.ubQuit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubQuit.Location = New System.Drawing.Point(171, 480)
        Me.ubQuit.Name = "ubQuit"
        Me.ubQuit.Size = New System.Drawing.Size(108, 48)
        Me.ubQuit.TabIndex = 17
        Me.ubQuit.Text = "Quit"
        '
        'ubNew
        '
        Me.ubNew.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubNew.Location = New System.Drawing.Point(13, 480)
        Me.ubNew.Name = "ubNew"
        Me.ubNew.Size = New System.Drawing.Size(110, 48)
        Me.ubNew.TabIndex = 16
        Me.ubNew.Text = "New Game"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(720, 720)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Board"
        Me.Label1.Visible = False
        '
        'p1_details
        '
        Me.p1_details.Location = New System.Drawing.Point(84, 101)
        Me.p1_details.Name = "p1_details"
        Me.p1_details.Size = New System.Drawing.Size(19, 22)
        Me.p1_details.TabIndex = 3
        Me.p1_details.Text = "?"
        Me.p1_details.UseVisualStyleBackColor = True
        '
        'txtP1
        '
        Me.txtP1.Location = New System.Drawing.Point(8, 8)
        Me.txtP1.Multiline = True
        Me.txtP1.Name = "txtP1"
        Me.txtP1.Size = New System.Drawing.Size(96, 114)
        Me.txtP1.TabIndex = 2
        '
        'p2_details
        '
        Me.p2_details.Location = New System.Drawing.Point(85, 100)
        Me.p2_details.Name = "p2_details"
        Me.p2_details.Size = New System.Drawing.Size(19, 22)
        Me.p2_details.TabIndex = 4
        Me.p2_details.Text = "?"
        Me.p2_details.UseVisualStyleBackColor = True
        '
        'txtP2
        '
        Me.txtP2.Location = New System.Drawing.Point(8, 8)
        Me.txtP2.Multiline = True
        Me.txtP2.Name = "txtP2"
        Me.txtP2.Size = New System.Drawing.Size(96, 114)
        Me.txtP2.TabIndex = 3
        '
        'p4_details
        '
        Me.p4_details.Location = New System.Drawing.Point(85, 100)
        Me.p4_details.Name = "p4_details"
        Me.p4_details.Size = New System.Drawing.Size(19, 22)
        Me.p4_details.TabIndex = 6
        Me.p4_details.Text = "?"
        Me.p4_details.UseVisualStyleBackColor = True
        '
        'txtP4
        '
        Me.txtP4.Location = New System.Drawing.Point(8, 8)
        Me.txtP4.Multiline = True
        Me.txtP4.Name = "txtP4"
        Me.txtP4.Size = New System.Drawing.Size(96, 114)
        Me.txtP4.TabIndex = 3
        '
        'p3_details
        '
        Me.p3_details.Location = New System.Drawing.Point(85, 100)
        Me.p3_details.Name = "p3_details"
        Me.p3_details.Size = New System.Drawing.Size(19, 22)
        Me.p3_details.TabIndex = 5
        Me.p3_details.Text = "?"
        Me.p3_details.UseVisualStyleBackColor = True
        '
        'txtP3
        '
        Me.txtP3.Location = New System.Drawing.Point(8, 8)
        Me.txtP3.Multiline = True
        Me.txtP3.Name = "txtP3"
        Me.txtP3.Size = New System.Drawing.Size(96, 114)
        Me.txtP3.TabIndex = 3
        '
        'Infotab
        '
        Me.Infotab.Controls.Add(Me.TabPageEvents)
        Me.Infotab.Controls.Add(Me.TabPageCity)
        Me.Infotab.Controls.Add(Me.TabPageBuilding)
        Me.Infotab.Controls.Add(Me.TabPagePerson)
        Me.Infotab.Controls.Add(Me.TabPageGame)
        Me.Infotab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Infotab.Location = New System.Drawing.Point(935, 161)
        Me.Infotab.Name = "Infotab"
        Me.Infotab.SelectedIndex = 0
        Me.Infotab.Size = New System.Drawing.Size(298, 575)
        Me.Infotab.TabIndex = 15
        '
        'TabPageBuilding
        '
        Me.TabPageBuilding.Controls.Add(Me.ubCloseBuilding)
        Me.TabPageBuilding.Controls.Add(Me.lblBuilding)
        Me.TabPageBuilding.Controls.Add(Me.ubBForward)
        Me.TabPageBuilding.Controls.Add(Me.ubBBack)
        Me.TabPageBuilding.Controls.Add(Me.txt_building)
        Me.TabPageBuilding.Location = New System.Drawing.Point(4, 24)
        Me.TabPageBuilding.Name = "TabPageBuilding"
        Me.TabPageBuilding.Size = New System.Drawing.Size(290, 547)
        Me.TabPageBuilding.TabIndex = 1
        Me.TabPageBuilding.Text = "Building"
        '
        'lblBuilding
        '
        Me.lblBuilding.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBuilding.Location = New System.Drawing.Point(3, 519)
        Me.lblBuilding.Name = "lblBuilding"
        Me.lblBuilding.Size = New System.Drawing.Size(143, 23)
        Me.lblBuilding.TabIndex = 8
        Me.lblBuilding.Text = "Displaying 0 of 0"
        Me.lblBuilding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ubBForward
        '
        Me.ubBForward.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubBForward.Location = New System.Drawing.Point(239, 519)
        Me.ubBForward.Name = "ubBForward"
        Me.ubBForward.Size = New System.Drawing.Size(48, 23)
        Me.ubBForward.TabIndex = 7
        Me.ubBForward.Text = ">>>"
        '
        'ubBBack
        '
        Me.ubBBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubBBack.Location = New System.Drawing.Point(183, 519)
        Me.ubBBack.Name = "ubBBack"
        Me.ubBBack.Size = New System.Drawing.Size(48, 23)
        Me.ubBBack.TabIndex = 6
        Me.ubBBack.Text = "<<<"
        '
        'txt_building
        '
        Me.txt_building.AcceptsReturn = True
        Me.txt_building.AcceptsTab = True
        Me.txt_building.Location = New System.Drawing.Point(3, 3)
        Me.txt_building.Multiline = True
        Me.txt_building.Name = "txt_building"
        Me.txt_building.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_building.Size = New System.Drawing.Size(284, 512)
        Me.txt_building.TabIndex = 5
        '
        'btnCheat
        '
        Me.btnCheat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCheat.Location = New System.Drawing.Point(121, 541)
        Me.btnCheat.Name = "btnCheat"
        Me.btnCheat.Size = New System.Drawing.Size(45, 23)
        Me.btnCheat.TabIndex = 23
        Me.btnCheat.Text = "Cheat"
        Me.btnCheat.UseVisualStyleBackColor = True
        '
        'MarketPanel
        '
        Me.MarketPanel.BackColor = System.Drawing.Color.DimGray
        Me.MarketPanel.Controls.Add(Me.BuildingDropdown)
        Me.MarketPanel.Controls.Add(Me.ubcardChoice)
        Me.MarketPanel.Controls.Add(Me.ubland)
        Me.MarketPanel.Controls.Add(Me.ubroadmax)
        Me.MarketPanel.Controls.Add(Me.ubroad)
        Me.MarketPanel.Controls.Add(Me.ubWipe)
        Me.MarketPanel.Controls.Add(Me.MarketLabel)
        Me.MarketPanel.Controls.Add(Me.ubcard4)
        Me.MarketPanel.Controls.Add(Me.ubcard3)
        Me.MarketPanel.Controls.Add(Me.ubcard2)
        Me.MarketPanel.Controls.Add(Me.ubcard1)
        Me.MarketPanel.Controls.Add(Me.btnCheat)
        Me.MarketPanel.Controls.Add(Me.ubEnd)
        Me.MarketPanel.Location = New System.Drawing.Point(745, 161)
        Me.MarketPanel.Name = "MarketPanel"
        Me.MarketPanel.Size = New System.Drawing.Size(182, 575)
        Me.MarketPanel.TabIndex = 26
        '
        'BuildingDropdown
        '
        Me.BuildingDropdown.DropDownHeight = 190
        Me.BuildingDropdown.FormattingEnabled = True
        Me.BuildingDropdown.IntegralHeight = False
        Me.BuildingDropdown.Location = New System.Drawing.Point(16, 372)
        Me.BuildingDropdown.Name = "BuildingDropdown"
        Me.BuildingDropdown.Size = New System.Drawing.Size(150, 21)
        Me.BuildingDropdown.TabIndex = 22
        '
        'ubcardChoice
        '
        Me.ubcardChoice.BackColor = System.Drawing.SystemColors.Control
        Me.ubcardChoice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubcardChoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcardChoice.Location = New System.Drawing.Point(16, 308)
        Me.ubcardChoice.Name = "ubcardChoice"
        Me.ubcardChoice.Size = New System.Drawing.Size(150, 58)
        Me.ubcardChoice.TabIndex = 30
        Me.ubcardChoice.Text = "Card5"
        Me.ubcardChoice.UseVisualStyleBackColor = False
        '
        'ubland
        '
        Me.ubland.BackColor = System.Drawing.SystemColors.Control
        Me.ubland.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubland.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubland.Location = New System.Drawing.Point(16, 453)
        Me.ubland.Name = "ubland"
        Me.ubland.Size = New System.Drawing.Size(150, 32)
        Me.ubland.TabIndex = 29
        Me.ubland.Text = "Land"
        Me.ubland.UseVisualStyleBackColor = False
        '
        'ubroadmax
        '
        Me.ubroadmax.BackColor = System.Drawing.SystemColors.Control
        Me.ubroadmax.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubroadmax.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubroadmax.Location = New System.Drawing.Point(121, 415)
        Me.ubroadmax.Name = "ubroadmax"
        Me.ubroadmax.Size = New System.Drawing.Size(45, 32)
        Me.ubroadmax.TabIndex = 28
        Me.ubroadmax.Text = "Max"
        Me.ubroadmax.UseVisualStyleBackColor = False
        '
        'ubroad
        '
        Me.ubroad.BackColor = System.Drawing.SystemColors.Control
        Me.ubroad.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubroad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubroad.Location = New System.Drawing.Point(16, 415)
        Me.ubroad.Name = "ubroad"
        Me.ubroad.Size = New System.Drawing.Size(103, 32)
        Me.ubroad.TabIndex = 27
        Me.ubroad.Text = "Road"
        Me.ubroad.UseVisualStyleBackColor = False
        '
        'ubWipe
        '
        Me.ubWipe.BackColor = System.Drawing.SystemColors.Control
        Me.ubWipe.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubWipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubWipe.Location = New System.Drawing.Point(16, 270)
        Me.ubWipe.Name = "ubWipe"
        Me.ubWipe.Size = New System.Drawing.Size(150, 32)
        Me.ubWipe.TabIndex = 26
        Me.ubWipe.Text = "Clear Above"
        Me.ubWipe.UseVisualStyleBackColor = False
        '
        'MarketLabel
        '
        Me.MarketLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MarketLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarketLabel.Location = New System.Drawing.Point(16, 0)
        Me.MarketLabel.Name = "MarketLabel"
        Me.MarketLabel.Size = New System.Drawing.Size(150, 27)
        Me.MarketLabel.TabIndex = 25
        Me.MarketLabel.Text = "Market"
        Me.MarketLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MarketLabel.Visible = False
        '
        'ubcard4
        '
        Me.ubcard4.BackColor = System.Drawing.SystemColors.Control
        Me.ubcard4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubcard4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard4.Location = New System.Drawing.Point(16, 206)
        Me.ubcard4.Name = "ubcard4"
        Me.ubcard4.Size = New System.Drawing.Size(150, 58)
        Me.ubcard4.TabIndex = 4
        Me.ubcard4.Text = "Card4"
        Me.ubcard4.UseVisualStyleBackColor = False
        '
        'ubcard3
        '
        Me.ubcard3.BackColor = System.Drawing.SystemColors.Control
        Me.ubcard3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubcard3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard3.Location = New System.Drawing.Point(16, 141)
        Me.ubcard3.Name = "ubcard3"
        Me.ubcard3.Size = New System.Drawing.Size(150, 58)
        Me.ubcard3.TabIndex = 3
        Me.ubcard3.Text = "Card3"
        Me.ubcard3.UseVisualStyleBackColor = False
        '
        'ubcard2
        '
        Me.ubcard2.BackColor = System.Drawing.SystemColors.Control
        Me.ubcard2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubcard2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard2.Location = New System.Drawing.Point(16, 78)
        Me.ubcard2.Name = "ubcard2"
        Me.ubcard2.Size = New System.Drawing.Size(150, 58)
        Me.ubcard2.TabIndex = 2
        Me.ubcard2.Text = "Card2"
        Me.ubcard2.UseVisualStyleBackColor = False
        '
        'ubcard1
        '
        Me.ubcard1.BackColor = System.Drawing.SystemColors.Control
        Me.ubcard1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ubcard1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubcard1.Location = New System.Drawing.Point(16, 14)
        Me.ubcard1.Name = "ubcard1"
        Me.ubcard1.Size = New System.Drawing.Size(150, 58)
        Me.ubcard1.TabIndex = 1
        Me.ubcard1.Text = "Card1"
        Me.ubcard1.UseVisualStyleBackColor = False
        '
        'ubEnd
        '
        Me.ubEnd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ubEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ubEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubEnd.Location = New System.Drawing.Point(16, 505)
        Me.ubEnd.Name = "ubEnd"
        Me.ubEnd.Size = New System.Drawing.Size(150, 59)
        Me.ubEnd.TabIndex = 17
        Me.ubEnd.Text = "END TURN"
        Me.ubEnd.UseVisualStyleBackColor = False
        '
        'gbP1
        '
        Me.gbP1.BackColor = System.Drawing.Color.DimGray
        Me.gbP1.Controls.Add(Me.p1_details)
        Me.gbP1.Controls.Add(Me.txtP1)
        Me.gbP1.Location = New System.Drawing.Point(745, 16)
        Me.gbP1.Name = "gbP1"
        Me.gbP1.Size = New System.Drawing.Size(110, 130)
        Me.gbP1.TabIndex = 27
        '
        'gbP2
        '
        Me.gbP2.BackColor = System.Drawing.Color.DimGray
        Me.gbP2.Controls.Add(Me.p2_details)
        Me.gbP2.Controls.Add(Me.txtP2)
        Me.gbP2.Location = New System.Drawing.Point(871, 16)
        Me.gbP2.Name = "gbP2"
        Me.gbP2.Size = New System.Drawing.Size(110, 130)
        Me.gbP2.TabIndex = 28
        '
        'gbP3
        '
        Me.gbP3.BackColor = System.Drawing.Color.DimGray
        Me.gbP3.Controls.Add(Me.p3_details)
        Me.gbP3.Controls.Add(Me.txtP3)
        Me.gbP3.Location = New System.Drawing.Point(997, 16)
        Me.gbP3.Name = "gbP3"
        Me.gbP3.Size = New System.Drawing.Size(110, 130)
        Me.gbP3.TabIndex = 29
        '
        'gbP4
        '
        Me.gbP4.BackColor = System.Drawing.Color.DimGray
        Me.gbP4.Controls.Add(Me.p4_details)
        Me.gbP4.Controls.Add(Me.txtP4)
        Me.gbP4.Location = New System.Drawing.Point(1123, 16)
        Me.gbP4.Name = "gbP4"
        Me.gbP4.Size = New System.Drawing.Size(110, 130)
        Me.gbP4.TabIndex = 30
        '
        'ubCloseBuilding
        '
        Me.ubCloseBuilding.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ubCloseBuilding.Location = New System.Drawing.Point(192, 13)
        Me.ubCloseBuilding.Name = "ubCloseBuilding"
        Me.ubCloseBuilding.Size = New System.Drawing.Size(71, 24)
        Me.ubCloseBuilding.TabIndex = 22
        Me.ubCloseBuilding.Text = "Close"
        '
        'MainForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1249, 750)
        Me.Controls.Add(Me.gbP4)
        Me.Controls.Add(Me.gbP3)
        Me.Controls.Add(Me.gbP2)
        Me.Controls.Add(Me.gbP1)
        Me.Controls.Add(Me.MarketPanel)
        Me.Controls.Add(Me.Infotab)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Urban Blight"
        Me.TabPageEvents.ResumeLayout(False)
        Me.TabPageEvents.PerformLayout()
        Me.TabPageCity.ResumeLayout(False)
        Me.TabPageCity.PerformLayout()
        Me.TabPagePerson.ResumeLayout(False)
        Me.TabPagePerson.PerformLayout()
        Me.TabPageGame.ResumeLayout(False)
        Me.TabPageGame.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Infotab.ResumeLayout(False)
        Me.TabPageBuilding.ResumeLayout(False)
        Me.TabPageBuilding.PerformLayout()
        Me.MarketPanel.ResumeLayout(False)
        Me.gbP1.ResumeLayout(False)
        Me.gbP1.PerformLayout()
        Me.gbP2.ResumeLayout(False)
        Me.gbP2.PerformLayout()
        Me.gbP3.ResumeLayout(False)
        Me.gbP3.PerformLayout()
        Me.gbP4.ResumeLayout(False)
        Me.gbP4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Player Actions "

    Private Sub MapMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim TheBox As Label = CType(sender, Label)
        Dim X, Y As Integer
        GetCoords(X, Y, TheBox.Tag)

        Dim ClickCity As CitySquare = UrbanBlight.GetSelectedCity()

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
        If Not DoubleClick Then
            UrbanBlight.SetSelectedCity(ClickCity)
            UrbanBlight.SetSelectedBuilding(0)
            UrbanBlight.SetSelectedPerson(0)
        End If

        '-- Select the newly clicked on grid box
        ClickCity.GridSquare.BorderStyle = BorderStyle.Fixed3D

        '-- Don't let players rename each other's cities!
        If ClickCity.IsOwned(CurrentPlayer.ID) Then
            ubRename.Visible = True
        Else
            ubRename.Visible = False
        End If

        If e.Button = MouseButtons.Left Then
            Dim BuildSuccess As Boolean = UrbanBlight.Build()

            If BuildSuccess Then
                '-- If the user just built a building, switch to the city tab of the construction location
                Infotab.SelectedTab = Infotab.TabPages(TabsEnum.City)
            ElseIf DoubleClick Then
                '-- If the user double-clicks a location, cycle through city, building and person tabs
                If Infotab.SelectedIndex = TabsEnum.City And ClickCity.IsOwned() Then
                    Infotab.SelectedTab = Infotab.TabPages(TabsEnum.Building)
                ElseIf Infotab.SelectedIndex = TabsEnum.Building And ClickCity.IsOwned() Then
                    Infotab.SelectedTab = Infotab.TabPages(TabsEnum.Person)
                Else
                    Infotab.SelectedTab = Infotab.TabPages(TabsEnum.City)
                End If
            ElseIf ClickCity.IsOwned() Then
                '- Show the information for this city
                If Infotab.SelectedIndex <> TabsEnum.Building And Infotab.SelectedIndex <> TabsEnum.Person Then
                    '-- If the user wasn't looking at the person or building tab when they clicked a location, switch them to the city tab
                    Infotab.SelectedTab = Infotab.TabPages(TabsEnum.City)
                End If
            Else
                '-- Show information for the terrain
                Infotab.SelectedTab = Infotab.TabPages(TabsEnum.City)
            End If

        ElseIf e.Button = MouseButtons.Right Then
            '-- Loop through the buildings or persons at a location using right-click
            If DoubleClick Then
                If Infotab.SelectedIndex = TabsEnum.Building Then
                    UrbanBlight.CycleThroughBuildings(True, True)
                ElseIf Infotab.SelectedIndex = TabsEnum.Person Then
                    UrbanBlight.CycleThroughPersons(True, True)
                ElseIf Infotab.SelectedIndex = TabsEnum.Game Then
                    UrbanBlight.CycleThroughViews(True, True)
                End If
            End If
        End If

    End Sub

#End Region

    Sub DisplayPlayerText()

        For i As Integer = 0 To Players.Count - 1
            '-- Updates player stats
            Dim thisPlayer As Player = Players(i)
            thisPlayer.GetPlayerScore()

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
            If GameType = GameEnum.Score And thisPlayer.TotalScore >= GoalNumber Then
                UrbanBlight.SetWinFlag(True)
            End If
            If GameType = GameEnum.Territory And thisPlayer.TotalTerritory >= GoalNumber Then
                UrbanBlight.SetWinFlag(True)
            End If
            If GameType = GameEnum.Population And thisPlayer.TotalPopulation >= GoalNumber Then
                UrbanBlight.SetWinFlag(True)
            End If
            If GameType = GameEnum.Development And thisPlayer.TotalDevelopment >= GoalNumber Then
                UrbanBlight.SetWinFlag(True)
            End If
        Next
    End Sub

    Public Sub SetTab(ByVal TabId As Integer)
        Infotab.SelectedTab = Infotab.TabPages(TabId)
    End Sub

    Sub UpdateTitle()
        Dim PlaceHolderTab As String = "        "
        Dim TitleText As String = "URBAN BLIGHT" + PlaceHolderTab
        TitleText += "Year: " + UrbanBlight.theYear.ToString + PlaceHolderTab

        Dim GoalText As String = ""
        Select Case (GameType)
            Case GameEnum.Score
                GoalText = "Score " + GoalNumber.ToString
            Case GameEnum.Territory
                GoalText = "Territory " + GoalNumber.ToString
            Case GameEnum.Population
                GoalText = "Population " + GoalNumber.ToString
            Case GameEnum.Development
                GoalText = "Development " + GoalNumber.ToString
            Case GameEnum.Year
                GoalText = "Year " + GoalNumber.ToString
            Case GameEnum.Infinite
                GoalText = "None"
        End Select
        TitleText += "Goal: " + GoalText.ToString + PlaceHolderTab

        TitleText += "Current View: " + GetViewName(UrbanBlight.GetSelectedView()).ToString

        Me.Text = TitleText

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



#Region " Texts, Hints and Rules "

    Public Sub ClearTexts()
        For i As Integer = 0 To TabsEnum.EnumEnd - 1
            UpdateTextBox(i, "")
        Next
        DisplayHint()
    End Sub

    Public Function GetTextBoxByTab(ByVal TabId As Integer) As TextBox
        Select Case TabId
            Case TabsEnum.Events
                Return txt_event
            Case TabsEnum.City
                Return txt_city
            Case TabsEnum.Building
                Return txt_building
            Case TabsEnum.Person
                Return txt_person
            Case TabsEnum.Game
                Return txtHint
            Case Else
                Return Nothing
        End Select
    End Function

    Public Sub UpdateTextBox(ByVal TabId As Integer, ByVal displayString As String)
        '-- Update the textbox to display text and then deselect it.
        Dim ThisTextBox As TextBox = GetTextBoxByTab(TabId)
        ThisTextBox.Text = displayString.Trim()
        ThisTextBox.Select(ThisTextBox.Text.Length, 0)
    End Sub

    Public Sub DisplayInstructions()

    End Sub

    Public Sub DisplayHint()
        txtHint.Text = Hinter.GenerateHint()
    End Sub
#End Region

#Region " Buttons "
    Public Sub FillButtonList()
        ButtonList.Add(ubcard1)
        ButtonList.Add(ubcard2)
        ButtonList.Add(ubcard3)
        ButtonList.Add(ubcard4)
        ButtonList.Add(ubcardChoice)
        ButtonList.Add(ubroad)
        ButtonList.Add(ubland)
        ButtonList.Add(ubWipe)
        ButtonList.Add(ubroadmax)
    End Sub

    Private Sub ubcard1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard1.Click
        CardClick(CardEnum.Building1)
    End Sub
    Private Sub ubcard2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard2.Click
        CardClick(CardEnum.Building2)
    End Sub
    Private Sub ubcard3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard3.Click
        CardClick(CardEnum.Building3)
    End Sub
    Private Sub ubcard4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubcard4.Click
        CardClick(CardEnum.Building4)
    End Sub
    Private Sub ubcardChoice_Click(sender As Object, e As EventArgs) Handles ubcardChoice.Click
        CardClick(CardEnum.BuildingSpecialOrder)
    End Sub
    Private Sub ubroad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubroad.Click
        CardClick(CardEnum.Road)
    End Sub
    Private Sub ubroadmax_Click(sender As Object, e As EventArgs) Handles ubroadmax.Click
        CardClick(CardEnum.RoadMax)
    End Sub
    Private Sub ubland_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubland.Click
        CardClick(CardEnum.Land)
    End Sub
    Private Sub ubWipe_Click(sender As Object, e As EventArgs) Handles ubWipe.Click
        CardClick(CardEnum.WipeBuildings)
    End Sub

    Public Sub CardClick(ByVal CardNumber As Integer)

        '-- Select the clicked card. 
        If UrbanBlight.GetSelectedCard() = CardNumber Then
            '-- If they click on it a second time, deselect it.
            UrbanBlight.SetSelectedCard(CardEnum.NoCard)
        Else
            UrbanBlight.SetSelectedCard(CardNumber)
        End If

        UpdateButtonSelection()

        '-- Display the card text
        UpdateTextBox(TabsEnum.Building, UrbanBlight.GetSelectedCardText())
        SetTab(TabsEnum.Building)
    End Sub

    Sub UpdateButtonEnables()
        '-- Toggle the buttons so humans can't play for the computer
        Dim toggleButtons As Boolean = True
        If CurrentPlayer.PlayerType = PlayerTypeEnum.AI Then
            toggleButtons = False
        End If

        For Each Control As Control In MarketPanel.Controls
            If Not Control.Equals(ubEnd) Then
                Control.Enabled = toggleButtons
            End If
        Next

        'For i As Integer = 0 To ButtonList.Count - 1
        '    ButtonList(i).Enabled = toggleButtons
        'Next

        '-- Disable access to cards banned for this player
        If CurrentPlayer.PlayerType = PlayerTypeEnum.Human Then
            For i As Integer = 0 To Cards.Length - 1
                Dim CardBuilding As Building = Cards(i)
                If CardBuilding IsNot Nothing Then
                    If CurrentPlayer.BannedBuildings.Contains(CardBuilding.Type) Then
                        ButtonList(i).Enabled = False
                    End If
                End If
            Next
        Else

        End If
    End Sub

    Public Sub UpdateButtonSelection()

        Dim newBold As New Font(ubEnd.Font.FontFamily, 10, FontStyle.Bold)
        Dim newRegular As New Font(ubEnd.Font.FontFamily, 10, FontStyle.Regular)

        '-- Bold the text on the selected card
        For i As Integer = 0 To ButtonList.Count - 1
            If i = UrbanBlight.GetSelectedCard() Then
                ButtonList(i).Font = newBold
            Else
                ButtonList(i).Font = newRegular
            End If
        Next
    End Sub

    Public Sub UpdateButtonText(ByVal ButtonId As Integer, ByVal ButtonText As String)
        ButtonList(ButtonId).Text = ButtonText
    End Sub

    Private Sub ubEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubEnd.Click
        UrbanBlight.EndTurn()
    End Sub

    '-- Person viewing
    Private Sub ubPBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubPBack.Click
        UrbanBlight.CycleThroughPersons(False, False)
    End Sub

    Private Sub ubPForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubPForward.Click
        UrbanBlight.CycleThroughPersons(True, False)
    End Sub

    Sub DisplaySelectedPerson(ByVal PersonId As Integer)
        '-- Set the selected building ID
        UpdateTextBox(TabsEnum.Person, "")

        '-- Make sure this building ID is valid
        Dim ClickCity As CitySquare = UrbanBlight.GetSelectedCity()
        If ClickCity IsNot Nothing Then
            Dim PersonCount As Integer = ClickCity.getPopulation()
            If PersonCount = 0 Then
                lblPerson.Text = "Displaying 0 of 0"
            Else
                If PersonId >= 0 And PersonId < PersonCount Then
                    '-- Update the building tab textbox
                    Dim thePerson As Citizen = ClickCity.People(PersonId)
                    UpdateTextBox(TabsEnum.Person, thePerson.toString())

                    lblPerson.Text = "Displaying " + (PersonId + 1).ToString() + " of " + PersonCount.ToString()

                    '-- Players can only take actions on citizens of their nationality
                    Return
                End If
            End If
        End If

    End Sub


    '-- Building viewing
    Private Sub ubBBack_Click(sender As Object, e As EventArgs) Handles ubBBack.Click
        UrbanBlight.CycleThroughBuildings(False, False)
    End Sub

    Private Sub ubBForward_Click(sender As Object, e As EventArgs) Handles ubBForward.Click
        UrbanBlight.CycleThroughBuildings(True, False)
    End Sub

    Sub DisplaySelectedBuilding(ByVal BuildingId As Integer)
        '-- Set the selected building ID
        ubCloseBuilding.Visible = False
        UpdateTextBox(TabsEnum.Building, "")

        '-- Make sure this building ID is valid
        Dim ClickCity As CitySquare = UrbanBlight.GetSelectedCity()
        If ClickCity IsNot Nothing Then
            Dim BuildingCount As Integer = ClickCity.getDevelopment()
            If BuildingCount = 0 Then
                lblBuilding.Text = "Displaying 0 of 0"
            Else
                If BuildingId >= 0 And BuildingId < BuildingCount Then
                    '-- Update the building tab textbox
                    Dim theBuilding As Building = ClickCity.Buildings(BuildingId)
                    UpdateTextBox(TabsEnum.Building, theBuilding.toString())

                    lblBuilding.Text = "Displaying " + (BuildingId + 1).ToString() + " of " + BuildingCount.ToString()

                    '-- Players can only close buildings they own
                    If theBuilding.OwnerID = CurrentPlayer.ID Then
                        ubCloseBuilding.Visible = True
                    End If
                    Return
                End If
            End If
        End If

    End Sub

#Region " Views "

    Private Sub ViewDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ViewDropdown.SelectedIndexChanged
        Dim NewSelectedIndex As Integer = ViewDropdown.SelectedIndex
        If NewSelectedIndex <> UrbanBlight.GetSelectedView Then
            UrbanBlight.SetSelectedView(NewSelectedIndex)
        End If
    End Sub

    Private Sub ubVForward_Click(sender As Object, e As EventArgs) Handles ubVForward.Click
        UrbanBlight.CycleThroughViews(True, True)
    End Sub

    Private Sub ubVBack_Click(sender As Object, e As EventArgs) Handles ubVBack.Click
        UrbanBlight.CycleThroughViews(False, True)
    End Sub

#End Region

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



    Private Sub Infotab_SelectedTabChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Infotab.TabIndexChanged
        If init Then
            UrbanBlight.ResetView()
        End If
    End Sub

    Private Sub ubRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubRename.Click

    End Sub

    Private Sub ubCloseBuilding_Click(sender As Object, e As EventArgs) Handles ubCloseBuilding.Click
        UrbanBlight.CloseCurrentBuilding()
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
        If thisPlayer.PlayerType = PlayerTypeEnum.AI Then
            playerInfoText += thisPlayer.Personality.toString()
        End If

        MsgBox(playerInfoText, MsgBoxStyle.Information, "Player Info")
    End Sub

    Sub HighlightCurrentPlayer()
        txtP1.BackColor = ColorPlayerUnselected
        txtP2.BackColor = ColorPlayerUnselected
        txtP3.BackColor = ColorPlayerUnselected
        txtP4.BackColor = ColorPlayerUnselected

        If CurrentPlayer.ID = 0 Then
            txtP1.BackColor = ColorPlayerSelected
        ElseIf CurrentPlayer.ID = 1 Then
            txtP2.BackColor = ColorPlayerSelected
        ElseIf CurrentPlayer.ID = 2 Then
            txtP3.BackColor = ColorPlayerSelected
        ElseIf CurrentPlayer.ID = 3 Then
            txtP4.BackColor = ColorPlayerSelected
        End If
    End Sub

#End Region

#Region " Special Orders "
    Public Sub FillBuildingDropdown()

        DisableDropdownChange = True

        BuildingDropdown.Items.Clear()
        For i As Integer = 0 To BuildingGen.BuildingEnum.BuildingCount - 1
            Dim BaseCost As Integer = BuildingGenerator.GetBaseCost(i) + CurrentPlayer.SpecialOrderOffsets(i)
            BuildingDropdown.Items.Add("$" + BaseCost.ToString + " - " + BuildingGenerator.GetName(i))
        Next

        DisableDropdownChange = False
    End Sub

    Private Sub BuildingDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BuildingDropdown.SelectedIndexChanged

        If DisableDropdownChange Then
            Return
        End If

        If BuildingDropdown.Items.Count > 0 Then
            '-- Add the building of the type selected to the Choice Card slot
            'Dim key As String = DirectCast(BuildingDropdown.SelectedItem, KeyValuePair(Of String, String)).Key
            'Dim value As String = DirectCast(BuildingDropdown.SelectedItem, KeyValuePair(Of String, String)).Value
            'Dim newBuildingType As Integer = key

            Dim newBuildingType As Integer = BuildingDropdown.SelectedIndex
            Dim newBuilding As Building = BuildingGenerator.CreateBuilding(newBuildingType)
            Dim SpecialOrderPrice As Integer = newBuilding.BaseCost + CurrentPlayer.SpecialOrderOffsets(newBuildingType)
            newBuilding.SetMarkdownPrice(SpecialOrderPrice)

            If newBuilding.GetPurchasePrice() <= CurrentPlayer.GetSpecialOrderCap() Then
                Cards(CardEnum.BuildingSpecialOrder) = newBuilding
            Else
                Cards(CardEnum.BuildingSpecialOrder) = Nothing
            End If

            UrbanBlight.UpdateCards(False)
        End If

    End Sub
#End Region



#Region " Debug Stuff "

    Public Sub SetDebugMode(ByVal debugBool As Boolean)
        DebugMode = debugBool
        BuildingDropdown.Visible = DebugMode
        btnCheat.Visible = DebugMode
    End Sub

    Private Sub btnCheat_Click(sender As Object, e As EventArgs) Handles btnCheat.Click
        CurrentPlayer.TotalMoney += 100000
        CurrentPlayer.SpecialOrderCap += 500
        DisplayPlayerText()
        UrbanBlight.UpdateCards(True)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles MarketLabel.Click
        ColorFlip = Not ColorFlip
        For Each Location As CitySquare In GridArray
            Location.UpdateTerrain()
        Next
        UrbanBlight.UpdateGrid()
    End Sub

    Private Sub btnSkip_Click(sender As Object, e As EventArgs) Handles btnSkip.Click
        '-- Let the user decide how many turns to skip
        GameType = GameEnum.Infinite
        Dim ReturnString As String = InputBox("Skip how many turns?", "Fast Forward")
        If ReturnString.Length = 0 Then
            Return
        End If
        Dim SkipTurns As Integer = ReturnString
        For i As Integer = 0 To SkipTurns - 1
            UrbanBlight.EndTurn()
        Next
    End Sub

#End Region

End Class


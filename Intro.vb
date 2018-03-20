Public Class Intro
    Inherits System.Windows.Forms.Form

#Region " Variables "
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
    Friend WithEvents gbPlayers As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ubBegin As System.Windows.Forms.Button
    Friend WithEvents rbTerritory As System.Windows.Forms.RadioButton
    Friend WithEvents rbPopulation As System.Windows.Forms.RadioButton
    Friend WithEvents rbScore As System.Windows.Forms.RadioButton
    Friend WithEvents rbYear As System.Windows.Forms.RadioButton
    Friend WithEvents numTerritory As System.Windows.Forms.NumericUpDown
    Friend WithEvents numPopulation As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScore As System.Windows.Forms.NumericUpDown
    Friend WithEvents numYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbBuildings As System.Windows.Forms.RadioButton
    Friend WithEvents AI_label1 As Label
    Friend WithEvents p1_rb_none As RadioButton
    Friend WithEvents p1_rb_robot As RadioButton
    Friend WithEvents p1_rb_human As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents AI_label2 As Label
    Friend WithEvents p2_rb_none As RadioButton
    Friend WithEvents p2_rb_robot As RadioButton
    Friend WithEvents p2_rb_human As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents AI_label3 As Label
    Friend WithEvents p3_rb_none As RadioButton
    Friend WithEvents p3_rb_robot As RadioButton
    Friend WithEvents p3_rb_human As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents AI_label4 As Label
    Friend WithEvents p4_rb_none As RadioButton
    Friend WithEvents p4_rb_robot As RadioButton
    Friend WithEvents p4_rb_human As RadioButton
    Friend WithEvents numBuildings As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Intro))
        Me.gbPlayers = New System.Windows.Forms.GroupBox()
        Me.AI_label1 = New System.Windows.Forms.Label()
        Me.p1_rb_none = New System.Windows.Forms.RadioButton()
        Me.p1_rb_robot = New System.Windows.Forms.RadioButton()
        Me.p1_rb_human = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numYear = New System.Windows.Forms.NumericUpDown()
        Me.rbBuildings = New System.Windows.Forms.RadioButton()
        Me.numBuildings = New System.Windows.Forms.NumericUpDown()
        Me.numScore = New System.Windows.Forms.NumericUpDown()
        Me.numPopulation = New System.Windows.Forms.NumericUpDown()
        Me.numTerritory = New System.Windows.Forms.NumericUpDown()
        Me.rbYear = New System.Windows.Forms.RadioButton()
        Me.rbScore = New System.Windows.Forms.RadioButton()
        Me.rbPopulation = New System.Windows.Forms.RadioButton()
        Me.rbTerritory = New System.Windows.Forms.RadioButton()
        Me.ubBegin = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AI_label2 = New System.Windows.Forms.Label()
        Me.p2_rb_none = New System.Windows.Forms.RadioButton()
        Me.p2_rb_robot = New System.Windows.Forms.RadioButton()
        Me.p2_rb_human = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.AI_label3 = New System.Windows.Forms.Label()
        Me.p3_rb_none = New System.Windows.Forms.RadioButton()
        Me.p3_rb_robot = New System.Windows.Forms.RadioButton()
        Me.p3_rb_human = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.AI_label4 = New System.Windows.Forms.Label()
        Me.p4_rb_none = New System.Windows.Forms.RadioButton()
        Me.p4_rb_robot = New System.Windows.Forms.RadioButton()
        Me.p4_rb_human = New System.Windows.Forms.RadioButton()
        Me.gbPlayers.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBuildings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPopulation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTerritory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPlayers
        '
        Me.gbPlayers.BackColor = System.Drawing.SystemColors.ControlDark
        Me.gbPlayers.Controls.Add(Me.AI_label1)
        Me.gbPlayers.Controls.Add(Me.p1_rb_none)
        Me.gbPlayers.Controls.Add(Me.p1_rb_robot)
        Me.gbPlayers.Controls.Add(Me.p1_rb_human)
        Me.gbPlayers.Location = New System.Drawing.Point(12, 12)
        Me.gbPlayers.Name = "gbPlayers"
        Me.gbPlayers.Size = New System.Drawing.Size(250, 61)
        Me.gbPlayers.TabIndex = 0
        Me.gbPlayers.TabStop = False
        Me.gbPlayers.Text = "Player 1"
        '
        'AI_label1
        '
        Me.AI_label1.Location = New System.Drawing.Point(9, 34)
        Me.AI_label1.Name = "AI_label1"
        Me.AI_label1.Size = New System.Drawing.Size(235, 24)
        Me.AI_label1.TabIndex = 5
        Me.AI_label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p1_rb_none
        '
        Me.p1_rb_none.AutoSize = True
        Me.p1_rb_none.Location = New System.Drawing.Point(183, 16)
        Me.p1_rb_none.Name = "p1_rb_none"
        Me.p1_rb_none.Size = New System.Drawing.Size(51, 17)
        Me.p1_rb_none.TabIndex = 2
        Me.p1_rb_none.TabStop = True
        Me.p1_rb_none.Text = "None"
        Me.p1_rb_none.UseVisualStyleBackColor = True
        '
        'p1_rb_robot
        '
        Me.p1_rb_robot.AutoSize = True
        Me.p1_rb_robot.Location = New System.Drawing.Point(100, 16)
        Me.p1_rb_robot.Name = "p1_rb_robot"
        Me.p1_rb_robot.Size = New System.Drawing.Size(35, 17)
        Me.p1_rb_robot.TabIndex = 1
        Me.p1_rb_robot.TabStop = True
        Me.p1_rb_robot.Text = "AI"
        Me.p1_rb_robot.UseVisualStyleBackColor = True
        '
        'p1_rb_human
        '
        Me.p1_rb_human.AutoSize = True
        Me.p1_rb_human.Location = New System.Drawing.Point(12, 17)
        Me.p1_rb_human.Name = "p1_rb_human"
        Me.p1_rb_human.Size = New System.Drawing.Size(59, 17)
        Me.p1_rb_human.TabIndex = 0
        Me.p1_rb_human.TabStop = True
        Me.p1_rb_human.Text = "Human"
        Me.p1_rb_human.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox1.Controls.Add(Me.numYear)
        Me.GroupBox1.Controls.Add(Me.rbBuildings)
        Me.GroupBox1.Controls.Add(Me.numBuildings)
        Me.GroupBox1.Controls.Add(Me.numScore)
        Me.GroupBox1.Controls.Add(Me.numPopulation)
        Me.GroupBox1.Controls.Add(Me.numTerritory)
        Me.GroupBox1.Controls.Add(Me.rbYear)
        Me.GroupBox1.Controls.Add(Me.rbScore)
        Me.GroupBox1.Controls.Add(Me.rbPopulation)
        Me.GroupBox1.Controls.Add(Me.rbTerritory)
        Me.GroupBox1.Location = New System.Drawing.Point(280, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 218)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game Goal"
        '
        'numYear
        '
        Me.numYear.Increment = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numYear.Location = New System.Drawing.Point(96, 181)
        Me.numYear.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numYear.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numYear.Name = "numYear"
        Me.numYear.Size = New System.Drawing.Size(72, 20)
        Me.numYear.TabIndex = 9
        Me.numYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numYear.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'rbBuildings
        '
        Me.rbBuildings.Location = New System.Drawing.Point(16, 141)
        Me.rbBuildings.Name = "rbBuildings"
        Me.rbBuildings.Size = New System.Drawing.Size(72, 24)
        Me.rbBuildings.TabIndex = 8
        Me.rbBuildings.Text = "Buildings"
        '
        'numBuildings
        '
        Me.numBuildings.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numBuildings.Location = New System.Drawing.Point(96, 141)
        Me.numBuildings.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numBuildings.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numBuildings.Name = "numBuildings"
        Me.numBuildings.Size = New System.Drawing.Size(72, 20)
        Me.numBuildings.TabIndex = 7
        Me.numBuildings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numBuildings.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numScore
        '
        Me.numScore.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numScore.Location = New System.Drawing.Point(96, 21)
        Me.numScore.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numScore.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numScore.Name = "numScore"
        Me.numScore.Size = New System.Drawing.Size(72, 20)
        Me.numScore.TabIndex = 6
        Me.numScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScore.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'numPopulation
        '
        Me.numPopulation.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numPopulation.Location = New System.Drawing.Point(96, 101)
        Me.numPopulation.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numPopulation.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numPopulation.Name = "numPopulation"
        Me.numPopulation.Size = New System.Drawing.Size(72, 20)
        Me.numPopulation.TabIndex = 5
        Me.numPopulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPopulation.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'numTerritory
        '
        Me.numTerritory.Location = New System.Drawing.Point(96, 61)
        Me.numTerritory.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numTerritory.Name = "numTerritory"
        Me.numTerritory.Size = New System.Drawing.Size(72, 20)
        Me.numTerritory.TabIndex = 4
        Me.numTerritory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numTerritory.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'rbYear
        '
        Me.rbYear.Location = New System.Drawing.Point(16, 181)
        Me.rbYear.Name = "rbYear"
        Me.rbYear.Size = New System.Drawing.Size(64, 24)
        Me.rbYear.TabIndex = 3
        Me.rbYear.Text = "Year"
        '
        'rbScore
        '
        Me.rbScore.Location = New System.Drawing.Point(16, 21)
        Me.rbScore.Name = "rbScore"
        Me.rbScore.Size = New System.Drawing.Size(64, 24)
        Me.rbScore.TabIndex = 2
        Me.rbScore.Text = "Score"
        '
        'rbPopulation
        '
        Me.rbPopulation.Location = New System.Drawing.Point(16, 101)
        Me.rbPopulation.Name = "rbPopulation"
        Me.rbPopulation.Size = New System.Drawing.Size(80, 24)
        Me.rbPopulation.TabIndex = 1
        Me.rbPopulation.Text = "Population"
        '
        'rbTerritory
        '
        Me.rbTerritory.Location = New System.Drawing.Point(16, 61)
        Me.rbTerritory.Name = "rbTerritory"
        Me.rbTerritory.Size = New System.Drawing.Size(64, 24)
        Me.rbTerritory.TabIndex = 0
        Me.rbTerritory.Text = "Territory"
        '
        'ubBegin
        '
        Me.ubBegin.Location = New System.Drawing.Point(280, 239)
        Me.ubBegin.Name = "ubBegin"
        Me.ubBegin.Size = New System.Drawing.Size(184, 45)
        Me.ubBegin.TabIndex = 4
        Me.ubBegin.Text = "Begin"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox2.Controls.Add(Me.AI_label2)
        Me.GroupBox2.Controls.Add(Me.p2_rb_none)
        Me.GroupBox2.Controls.Add(Me.p2_rb_robot)
        Me.GroupBox2.Controls.Add(Me.p2_rb_human)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 82)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(250, 61)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Player 2"
        '
        'AI_label2
        '
        Me.AI_label2.Location = New System.Drawing.Point(9, 34)
        Me.AI_label2.Name = "AI_label2"
        Me.AI_label2.Size = New System.Drawing.Size(235, 24)
        Me.AI_label2.TabIndex = 5
        Me.AI_label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p2_rb_none
        '
        Me.p2_rb_none.AutoSize = True
        Me.p2_rb_none.Location = New System.Drawing.Point(183, 16)
        Me.p2_rb_none.Name = "p2_rb_none"
        Me.p2_rb_none.Size = New System.Drawing.Size(51, 17)
        Me.p2_rb_none.TabIndex = 2
        Me.p2_rb_none.TabStop = True
        Me.p2_rb_none.Text = "None"
        Me.p2_rb_none.UseVisualStyleBackColor = True
        '
        'p2_rb_robot
        '
        Me.p2_rb_robot.AutoSize = True
        Me.p2_rb_robot.Location = New System.Drawing.Point(100, 16)
        Me.p2_rb_robot.Name = "p2_rb_robot"
        Me.p2_rb_robot.Size = New System.Drawing.Size(35, 17)
        Me.p2_rb_robot.TabIndex = 1
        Me.p2_rb_robot.TabStop = True
        Me.p2_rb_robot.Text = "AI"
        Me.p2_rb_robot.UseVisualStyleBackColor = True
        '
        'p2_rb_human
        '
        Me.p2_rb_human.AutoSize = True
        Me.p2_rb_human.Location = New System.Drawing.Point(12, 17)
        Me.p2_rb_human.Name = "p2_rb_human"
        Me.p2_rb_human.Size = New System.Drawing.Size(59, 17)
        Me.p2_rb_human.TabIndex = 0
        Me.p2_rb_human.TabStop = True
        Me.p2_rb_human.Text = "Human"
        Me.p2_rb_human.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox3.Controls.Add(Me.AI_label3)
        Me.GroupBox3.Controls.Add(Me.p3_rb_none)
        Me.GroupBox3.Controls.Add(Me.p3_rb_robot)
        Me.GroupBox3.Controls.Add(Me.p3_rb_human)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(250, 61)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Player 3"
        '
        'AI_label3
        '
        Me.AI_label3.Location = New System.Drawing.Point(9, 34)
        Me.AI_label3.Name = "AI_label3"
        Me.AI_label3.Size = New System.Drawing.Size(235, 24)
        Me.AI_label3.TabIndex = 5
        Me.AI_label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p3_rb_none
        '
        Me.p3_rb_none.AutoSize = True
        Me.p3_rb_none.Location = New System.Drawing.Point(183, 16)
        Me.p3_rb_none.Name = "p3_rb_none"
        Me.p3_rb_none.Size = New System.Drawing.Size(51, 17)
        Me.p3_rb_none.TabIndex = 2
        Me.p3_rb_none.TabStop = True
        Me.p3_rb_none.Text = "None"
        Me.p3_rb_none.UseVisualStyleBackColor = True
        '
        'p3_rb_robot
        '
        Me.p3_rb_robot.AutoSize = True
        Me.p3_rb_robot.Location = New System.Drawing.Point(100, 16)
        Me.p3_rb_robot.Name = "p3_rb_robot"
        Me.p3_rb_robot.Size = New System.Drawing.Size(35, 17)
        Me.p3_rb_robot.TabIndex = 1
        Me.p3_rb_robot.TabStop = True
        Me.p3_rb_robot.Text = "AI"
        Me.p3_rb_robot.UseVisualStyleBackColor = True
        '
        'p3_rb_human
        '
        Me.p3_rb_human.AutoSize = True
        Me.p3_rb_human.Location = New System.Drawing.Point(12, 17)
        Me.p3_rb_human.Name = "p3_rb_human"
        Me.p3_rb_human.Size = New System.Drawing.Size(59, 17)
        Me.p3_rb_human.TabIndex = 0
        Me.p3_rb_human.TabStop = True
        Me.p3_rb_human.Text = "Human"
        Me.p3_rb_human.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ControlDark
        Me.GroupBox4.Controls.Add(Me.AI_label4)
        Me.GroupBox4.Controls.Add(Me.p4_rb_none)
        Me.GroupBox4.Controls.Add(Me.p4_rb_robot)
        Me.GroupBox4.Controls.Add(Me.p4_rb_human)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(250, 61)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Player 4"
        '
        'AI_label4
        '
        Me.AI_label4.Location = New System.Drawing.Point(9, 34)
        Me.AI_label4.Name = "AI_label4"
        Me.AI_label4.Size = New System.Drawing.Size(235, 24)
        Me.AI_label4.TabIndex = 5
        Me.AI_label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'p4_rb_none
        '
        Me.p4_rb_none.AutoSize = True
        Me.p4_rb_none.Location = New System.Drawing.Point(183, 16)
        Me.p4_rb_none.Name = "p4_rb_none"
        Me.p4_rb_none.Size = New System.Drawing.Size(51, 17)
        Me.p4_rb_none.TabIndex = 2
        Me.p4_rb_none.TabStop = True
        Me.p4_rb_none.Text = "None"
        Me.p4_rb_none.UseVisualStyleBackColor = True
        '
        'p4_rb_robot
        '
        Me.p4_rb_robot.AutoSize = True
        Me.p4_rb_robot.Location = New System.Drawing.Point(100, 16)
        Me.p4_rb_robot.Name = "p4_rb_robot"
        Me.p4_rb_robot.Size = New System.Drawing.Size(35, 17)
        Me.p4_rb_robot.TabIndex = 1
        Me.p4_rb_robot.TabStop = True
        Me.p4_rb_robot.Text = "AI"
        Me.p4_rb_robot.UseVisualStyleBackColor = True
        '
        'p4_rb_human
        '
        Me.p4_rb_human.AutoSize = True
        Me.p4_rb_human.Location = New System.Drawing.Point(12, 17)
        Me.p4_rb_human.Name = "p4_rb_human"
        Me.p4_rb_human.Size = New System.Drawing.Size(59, 17)
        Me.p4_rb_human.TabIndex = 0
        Me.p4_rb_human.TabStop = True
        Me.p4_rb_human.Text = "Human"
        Me.p4_rb_human.UseVisualStyleBackColor = True
        '
        'Intro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(475, 296)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ubBegin)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbPlayers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Intro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Intro"
        Me.gbPlayers.ResumeLayout(False)
        Me.gbPlayers.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBuildings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPopulation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTerritory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Game Mode "

    Private Sub Intro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '-- Create default player types
        Players.Clear()
        For i As Integer = 0 To MaxPlayers - 1
            Dim newPlayer As New Player(i)
            Players.Add(newPlayer)
        Next

        p1_rb_human.Checked = True
        p2_rb_robot.Checked = True
        p3_rb_none.Checked = True
        p4_rb_none.Checked = True

        rbScore.Checked = True

    End Sub

    Private Sub ubBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubBegin.Click
        Select Case (GameType)
            Case ScoreGame
                GoalNumber = numScore.Value
            Case TerritoryGame
                GoalNumber = numTerritory.Value
            Case PopulationGame
                GoalNumber = numPopulation.Value
            Case DevelopmentGame
                GoalNumber = numBuildings.Value
            Case YearGame
                GoalNumber = numYear.Value
        End Select
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub rbScore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbScore.CheckedChanged
        GameType = ScoreGame
        GoalNumber = numScore.Value
    End Sub

    Private Sub rbTerritory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTerritory.CheckedChanged
        GameType = TerritoryGame
        GoalNumber = numTerritory.Value
    End Sub

    Private Sub rbPopulation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPopulation.CheckedChanged
        GameType = PopulationGame
        GoalNumber = numPopulation.Value
    End Sub

    Private Sub rbBuildings_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBuildings.CheckedChanged
        GameType = DevelopmentGame
        GoalNumber = numYear.Value
    End Sub

    Private Sub rbYear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbYear.CheckedChanged
        GameType = YearGame
        GoalNumber = numYear.Value
    End Sub

    Private Sub numScore_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScore.ValueChanged
        If GameType = ScoreGame Then
            GoalNumber = numScore.Value
        End If
    End Sub

    Private Sub numTerritory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numTerritory.ValueChanged
        If GameType = TerritoryGame Then
            GoalNumber = numTerritory.Value
        End If
    End Sub

    Private Sub numPopulation_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPopulation.ValueChanged
        If GameType = PopulationGame Then
            GoalNumber = numPopulation.Value
        End If
    End Sub

    Private Sub numBuildings_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numBuildings.ValueChanged
        If GameType = DevelopmentGame Then
            GoalNumber = numBuildings.Value
        End If
    End Sub

    Private Sub numYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numYear.ValueChanged
        If GameType = YearGame Then
            GoalNumber = numYear.Value
        End If
    End Sub

#End Region

#Region " Player Types "

    Private Sub p1_rb_human_CheckedChanged(sender As Object, e As EventArgs) Handles p1_rb_human.CheckedChanged
        UpdatePlayerType(0, PlayerHuman)
    End Sub

    Private Sub p1_rb_robot_CheckedChanged(sender As Object, e As EventArgs) Handles p1_rb_robot.CheckedChanged
        UpdatePlayerType(0, PlayerAI)
    End Sub

    Private Sub p1_rb_none_CheckedChanged(sender As Object, e As EventArgs) Handles p1_rb_none.CheckedChanged
        UpdatePlayerType(0, PlayerNone)
    End Sub

    Private Sub p2_rb_human_CheckedChanged(sender As Object, e As EventArgs) Handles p2_rb_human.CheckedChanged
        UpdatePlayerType(1, PlayerHuman)
    End Sub

    Private Sub p2_rb_robot_CheckedChanged(sender As Object, e As EventArgs) Handles p2_rb_robot.CheckedChanged
        UpdatePlayerType(1, PlayerAI)
    End Sub

    Private Sub p2_rb_none_CheckedChanged(sender As Object, e As EventArgs) Handles p2_rb_none.CheckedChanged
        UpdatePlayerType(1, PlayerNone)
    End Sub

    Private Sub p3_rb_human_CheckedChanged(sender As Object, e As EventArgs) Handles p3_rb_human.CheckedChanged
        UpdatePlayerType(2, PlayerHuman)
    End Sub

    Private Sub p3_rb_robot_CheckedChanged(sender As Object, e As EventArgs) Handles p3_rb_robot.CheckedChanged
        UpdatePlayerType(2, PlayerAI)
    End Sub

    Private Sub p3_rb_none_CheckedChanged(sender As Object, e As EventArgs) Handles p3_rb_none.CheckedChanged
        UpdatePlayerType(2, PlayerNone)
    End Sub

    Private Sub p4_rb_human_CheckedChanged(sender As Object, e As EventArgs) Handles p4_rb_human.CheckedChanged
        UpdatePlayerType(3, PlayerHuman)
    End Sub

    Private Sub p4_rb_robot_CheckedChanged(sender As Object, e As EventArgs) Handles p4_rb_robot.CheckedChanged
        UpdatePlayerType(3, PlayerAI)
    End Sub

    Private Sub p4_rb_none_CheckedChanged(sender As Object, e As EventArgs) Handles p4_rb_none.CheckedChanged
        UpdatePlayerType(3, PlayerNone)
    End Sub

    Private Sub AI_label1_Click(sender As Object, e As EventArgs) Handles AI_label1.Click
        UpdatePlayerAI(0)
    End Sub

    Private Sub AI_label2_Click(sender As Object, e As EventArgs) Handles AI_label2.Click
        UpdatePlayerAI(1)
    End Sub

    Private Sub AI_label3_Click(sender As Object, e As EventArgs) Handles AI_label3.Click
        UpdatePlayerAI(2)
    End Sub

    Private Sub AI_label4_Click(sender As Object, e As EventArgs) Handles AI_label4.Click
        UpdatePlayerAI(3)
    End Sub

    Private Sub UpdatePlayerType(ByVal playerIndex As Integer, ByVal playerType As Integer)

        Dim currentPlayer As Player = Players(playerIndex)
        currentPlayer.PlayerType = playerType

        If currentPlayer.PlayerType = PlayerAI Then
            '-- Generate a new player personality and display
            UpdatePlayerAI(currentPlayer)
        End If

        '-- Must have at least 1 player to begin
        Dim playerCount As Integer = 0
        For i As Integer = 0 To MaxPlayers - 1
            If Players(i).PlayerType <> PlayerNone Then
                playerCount += 1
            End If
        Next
        If playerCount > 0 Then
            ubBegin.Enabled = True
        Else
            ubBegin.Enabled = False
        End If
    End Sub

    Private Sub UpdatePlayerAI(ByVal playerIndex As Integer)
        Dim currentPlayer As Player = Players(playerIndex)
        UpdatePlayerAI(currentPlayer)
    End Sub

    Private Sub UpdatePlayerAI(ByRef thisPlayer As Player)

        Dim AIText As String = ""
        If thisPlayer.PlayerType = PlayerAI Then
            '-- Generate a new player personality and display
            thisPlayer.SetPersonality()
            AIText = thisPlayer.Personality.toString()
        End If

        Select Case thisPlayer.ID
            Case 0
                AI_label1.Text = AIText
            Case 1
                AI_label2.Text = AIText
            Case 2
                AI_label3.Text = AIText
            Case 3
                AI_label4.Text = AIText
        End Select

    End Sub



#End Region

End Class

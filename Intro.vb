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
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb4 As System.Windows.Forms.RadioButton
    Friend WithEvents numYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbBuildings As System.Windows.Forms.RadioButton
    Friend WithEvents numBuildings As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Intro))
        Me.gbPlayers = New System.Windows.Forms.GroupBox
        Me.rb4 = New System.Windows.Forms.RadioButton
        Me.rb3 = New System.Windows.Forms.RadioButton
        Me.rb2 = New System.Windows.Forms.RadioButton
        Me.rb1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.numYear = New System.Windows.Forms.NumericUpDown
        Me.rbBuildings = New System.Windows.Forms.RadioButton
        Me.numBuildings = New System.Windows.Forms.NumericUpDown
        Me.numScore = New System.Windows.Forms.NumericUpDown
        Me.numPopulation = New System.Windows.Forms.NumericUpDown
        Me.numTerritory = New System.Windows.Forms.NumericUpDown
        Me.rbYear = New System.Windows.Forms.RadioButton
        Me.rbScore = New System.Windows.Forms.RadioButton
        Me.rbPopulation = New System.Windows.Forms.RadioButton
        Me.rbTerritory = New System.Windows.Forms.RadioButton
        Me.ubBegin = New System.Windows.Forms.Button
        Me.gbPlayers.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBuildings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPopulation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTerritory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbPlayers
        '
        Me.gbPlayers.BackColor = System.Drawing.SystemColors.ControlDark
        Me.gbPlayers.Controls.Add(Me.rb4)
        Me.gbPlayers.Controls.Add(Me.rb3)
        Me.gbPlayers.Controls.Add(Me.rb2)
        Me.gbPlayers.Controls.Add(Me.rb1)
        Me.gbPlayers.Location = New System.Drawing.Point(216, 16)
        Me.gbPlayers.Name = "gbPlayers"
        Me.gbPlayers.Size = New System.Drawing.Size(120, 176)
        Me.gbPlayers.TabIndex = 0
        Me.gbPlayers.TabStop = False
        Me.gbPlayers.Text = "Number of Players?"
        '
        'rb4
        '
        Me.rb4.Location = New System.Drawing.Point(32, 144)
        Me.rb4.Name = "rb4"
        Me.rb4.Size = New System.Drawing.Size(64, 16)
        Me.rb4.TabIndex = 11
        Me.rb4.Text = "   4"
        '
        'rb3
        '
        Me.rb3.Location = New System.Drawing.Point(32, 104)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(64, 16)
        Me.rb3.TabIndex = 10
        Me.rb3.Text = "   3"
        '
        'rb2
        '
        Me.rb2.Location = New System.Drawing.Point(32, 64)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(64, 16)
        Me.rb2.TabIndex = 9
        Me.rb2.Text = "   2"
        '
        'rb1
        '
        Me.rb1.Location = New System.Drawing.Point(32, 24)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(64, 16)
        Me.rb1.TabIndex = 8
        Me.rb1.Text = "   1"
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 224)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "End Game Method?"
        '
        'numYear
        '
        Me.numYear.Increment = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numYear.Location = New System.Drawing.Point(96, 184)
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
        Me.rbBuildings.Location = New System.Drawing.Point(16, 144)
        Me.rbBuildings.Name = "rbBuildings"
        Me.rbBuildings.Size = New System.Drawing.Size(72, 24)
        Me.rbBuildings.TabIndex = 8
        Me.rbBuildings.Text = "Buildings"
        '
        'numBuildings
        '
        Me.numBuildings.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numBuildings.Location = New System.Drawing.Point(96, 144)
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
        Me.numScore.Location = New System.Drawing.Point(96, 24)
        Me.numScore.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numScore.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numScore.Name = "numScore"
        Me.numScore.Size = New System.Drawing.Size(72, 20)
        Me.numScore.TabIndex = 6
        Me.numScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScore.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'numPopulation
        '
        Me.numPopulation.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numPopulation.Location = New System.Drawing.Point(96, 104)
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
        Me.numTerritory.Location = New System.Drawing.Point(96, 64)
        Me.numTerritory.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numTerritory.Name = "numTerritory"
        Me.numTerritory.Size = New System.Drawing.Size(72, 20)
        Me.numTerritory.TabIndex = 4
        Me.numTerritory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numTerritory.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'rbYear
        '
        Me.rbYear.Location = New System.Drawing.Point(16, 184)
        Me.rbYear.Name = "rbYear"
        Me.rbYear.Size = New System.Drawing.Size(64, 24)
        Me.rbYear.TabIndex = 3
        Me.rbYear.Text = "Year"
        '
        'rbScore
        '
        Me.rbScore.Location = New System.Drawing.Point(16, 24)
        Me.rbScore.Name = "rbScore"
        Me.rbScore.Size = New System.Drawing.Size(64, 24)
        Me.rbScore.TabIndex = 2
        Me.rbScore.Text = "Score"
        '
        'rbPopulation
        '
        Me.rbPopulation.Location = New System.Drawing.Point(16, 104)
        Me.rbPopulation.Name = "rbPopulation"
        Me.rbPopulation.Size = New System.Drawing.Size(80, 24)
        Me.rbPopulation.TabIndex = 1
        Me.rbPopulation.Text = "Population"
        '
        'rbTerritory
        '
        Me.rbTerritory.Location = New System.Drawing.Point(16, 64)
        Me.rbTerritory.Name = "rbTerritory"
        Me.rbTerritory.Size = New System.Drawing.Size(64, 24)
        Me.rbTerritory.TabIndex = 0
        Me.rbTerritory.Text = "Territory"
        '
        'ubBegin
        '
        Me.ubBegin.Location = New System.Drawing.Point(216, 208)
        Me.ubBegin.Name = "ubBegin"
        Me.ubBegin.Size = New System.Drawing.Size(120, 32)
        Me.ubBegin.TabIndex = 4
        Me.ubBegin.Text = "Begin"
        '
        'Intro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(352, 254)
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
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.numYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBuildings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPopulation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTerritory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Intro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rb1.Checked = True
        rbScore.Checked = True
        'Dim test As String
        'Dim i As Integer
        'For i = 0 To 20
        '    test += GetRandom(0, 1).ToString + " "
        'Next
        'For i = 0 To 20
        '    test += GetRandom(5, 5).ToString + " "
        'Next
        'For i = 0 To 20
        '    test += GetRandom(-3, -1).ToString + " "
        'Next
        'MsgBox(test, MsgBoxStyle.OKOnly, "Test")
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

    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        PlayerCount = 1
    End Sub

    Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
        PlayerCount = 2
    End Sub

    Private Sub rb3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb3.CheckedChanged
        PlayerCount = 3
    End Sub

    Private Sub rb4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb4.CheckedChanged
        PlayerCount = 4
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
End Class

Public Class GameOver
    Inherits System.Windows.Forms.Form

#Region " Variables "
    Dim FinalMessage As String
#End Region

#Region " Windows Form Designer generated code "



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
    Friend WithEvents txt_ending As System.Windows.Forms.TextBox
    Friend WithEvents ubexit As System.Windows.Forms.Button
    Friend WithEvents ubContinue As System.Windows.Forms.Button
    Friend WithEvents ubPlayAgain As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GameOver))
        Me.txt_ending = New System.Windows.Forms.TextBox
        Me.ubexit = New System.Windows.Forms.Button
        Me.ubContinue = New System.Windows.Forms.Button
        Me.ubPlayAgain = New System.Windows.Forms.Button
        CType(Me.txt_ending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_ending
        '
        Me.txt_ending.AcceptsReturn = True
        Me.txt_ending.AcceptsTab = True
        Me.txt_ending.Location = New System.Drawing.Point(16, 16)
        Me.txt_ending.Multiline = True
        Me.txt_ending.Name = "txt_ending"
        Me.txt_ending.Scrollbars = System.Windows.Forms.ScrollBars.Vertical
        'Me.txt_ending.ShowOverflowIndicator = True
        Me.txt_ending.Size = New System.Drawing.Size(248, 224)
        Me.txt_ending.TabIndex = 2
        '
        'ubexit
        '
        Me.ubexit.Location = New System.Drawing.Point(200, 256)
        Me.ubexit.Name = "ubexit"
        Me.ubexit.Size = New System.Drawing.Size(64, 25)
        Me.ubexit.TabIndex = 17
        Me.ubexit.Text = "Exit"
        '
        'ubContinue
        '
        Me.ubContinue.Location = New System.Drawing.Point(16, 256)
        Me.ubContinue.Name = "ubContinue"
        Me.ubContinue.Size = New System.Drawing.Size(96, 25)
        Me.ubContinue.TabIndex = 18
        Me.ubContinue.Text = "Continue Game"
        '
        'ubPlayAgain
        '
        Me.ubPlayAgain.Location = New System.Drawing.Point(120, 256)
        Me.ubPlayAgain.Name = "ubPlayAgain"
        Me.ubPlayAgain.Size = New System.Drawing.Size(72, 25)
        Me.ubPlayAgain.TabIndex = 19
        Me.ubPlayAgain.Text = "Play Again"
        '
        'GameOver
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 294)
        Me.Controls.Add(Me.ubPlayAgain)
        Me.Controls.Add(Me.ubContinue)
        Me.Controls.Add(Me.ubexit)
        Me.Controls.Add(Me.txt_ending)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GameOver"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GameOver"
        CType(Me.txt_ending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal message As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FinalMessage = message
        txt_ending.Text = FinalMessage
    End Sub

    Private Sub ubContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubContinue.Click
        Me.DialogResult = DialogResult.Ignore
        Me.Close()
    End Sub

    Private Sub ubPlayAgain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubPlayAgain.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub ubexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubexit.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class

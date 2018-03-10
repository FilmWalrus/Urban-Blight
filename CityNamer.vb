Public Class CityNamer
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents txtCityName As System.Windows.Forms.TextBox
    Friend WithEvents ubOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CityNamer))
        Me.txtCityName = New System.Windows.Forms.TextBox
        Me.ubOK = New System.Windows.Forms.Button
        'CType(Me.txtCityName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCityName
        '
        Me.txtCityName.Location = New System.Drawing.Point(8, 8)
        Me.txtCityName.Name = "txtCityName"
        Me.txtCityName.Size = New System.Drawing.Size(176, 21)
        Me.txtCityName.TabIndex = 0
        '
        'ubOK
        '
        Me.ubOK.Location = New System.Drawing.Point(200, 8)
        Me.ubOK.Name = "ubOK"
        Me.ubOK.Size = New System.Drawing.Size(48, 23)
        Me.ubOK.TabIndex = 1
        Me.ubOK.Text = "OK"
        '
        'CityNamer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(258, 48)
        Me.ControlBox = False
        Me.Controls.Add(Me.ubOK)
        Me.Controls.Add(Me.txtCityName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CityNamer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Name of City?"
        'CType(Me.txtCityName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ubOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubOK.Click
        LastCityName = txtCityName.Text.ToString.Trim
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class

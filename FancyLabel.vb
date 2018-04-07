
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FancyLabel
    Inherits Label

    ' The first color
    Private _BackColor1 As Color
    Public Property BackColor1() As Color
        Get
            Return _BackColor1
        End Get
        Set(ByVal value As Color)
            _BackColor1 = value
        End Set
    End Property

    ' The second color
    Private _BackColor2 As Color
    Public Property BackColor2() As Color
        Get
            Return _BackColor2
        End Get
        Set(ByVal value As Color)
            _BackColor2 = value
        End Set
    End Property

    ' This hides the original BackColor property from the list, because we dont use it
    <Browsable(False)>
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(pevent)

        Using b As New LinearGradientBrush(Me.ClientRectangle, Me.BackColor1, Me.BackColor2, LinearGradientMode.Horizontal)
            pevent.Graphics.FillRectangle(b, Me.ClientRectangle)
        End Using
    End Sub

End Class


Public Class LabelWithTextBorder
    Inherits Label

    Sub New()
        SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        Dim size As SizeF = e.Graphics.MeasureString(Text, DemoFont)
        'Using pen As New Pen(Color.White)
        '    e.Graphics.DrawRectangle(pen, (ClientSize.Width - size.Width) / 2, (ClientSize.Height - size.Height) / 2, size.Width, size.Height)
        'End Using


        '-- Draw the image
        If MyBase.Image IsNot Nothing Then
            e.Graphics.DrawImage(MyBase.Image, New Point(0, 0))
        End If

        '-- Draw a spherical backdrop around the text
        Dim BackColorAlpha As New Color()
        BackColorAlpha = Color.FromArgb(120, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
        Using brush As New SolidBrush(BackColorAlpha) 'Me.BackColor
            'e.Graphics.FillRectangle(brush, (ClientSize.Width - size.Width) / 2, (ClientSize.Height - size.Height) / 2, size.Width, size.Height)
            e.Graphics.FillEllipse(brush, (ClientSize.Width - size.Width) / 2, (ClientSize.Height - size.Height) / 2, size.Width, size.Height)
        End Using

        '-- Draw the text
        ' Dim TextColor As Color = SystemColors.ControlText
        Dim TextColor As Color = System.Drawing.Color.White
        If ColorFlip Then
            TextColor = System.Drawing.Color.Black
        End If
        Using brush As New SolidBrush(TextColor)
            e.Graphics.DrawString(Text, DemoFont, brush, (ClientSize.Width - size.Width) / 2, (ClientSize.Height - size.Height) / 2)
        End Using

        'MyBase.OnPaint(e)
    End Sub

End Class


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

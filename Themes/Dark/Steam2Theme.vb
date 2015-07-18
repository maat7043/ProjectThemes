﻿Imports System.Drawing.Drawing2D

Class SteamTheme
    Inherits ThemeContainer153

    Sub New()
        ForeColor = Color.FromArgb(195, 193, 191)
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(56, 54, 53))
        DrawGradient(Color.Black, Color.FromArgb(76, 108, 139), ClientRectangle, 65S)
        G.FillRectangle(New SolidBrush(Color.FromArgb(56, 54, 53)), New Rectangle(1, 1, Width - 2, Height - 2))
        DrawGradient(Color.FromArgb(71, 68, 66), Color.FromArgb(57, 55, 54), New Rectangle(1, 1, Width - 2, 35), 90S)
        DrawText(New SolidBrush(Color.FromArgb(195, 193, 191)), HorizontalAlignment.Left, 4, 0)
    End Sub
End Class
Class SteamThemeAlt
    Inherits ThemeContainer153

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(44, 42, 40))

        Dim T As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(20, 19, 19), Color.FromArgb(46, 44, 42))
        G.FillRectangle(T, ClientRectangle)
        DrawGradient(Color.Transparent, Color.FromArgb(29, 28, 27), New Rectangle(0, 0 - Height / 3 - Height / 9, Width, Height))
        G.FillRectangle(New SolidBrush(Color.FromArgb(29, 28, 28)), New Rectangle(0, Height / 3 + Height / 3 - Height / 9, Width, Height))


        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(0, 0, 0))))
        DrawText(New SolidBrush(Color.FromArgb(195, 193, 191)), HorizontalAlignment.Left, 4, 0)
    End Sub
End Class

Class SteamButton
    Inherits ThemeControl153

    Sub New()
        Font = New Font("Verdana", 7.25)
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(56, 54, 53))
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(77, 75, 72))))
        DrawCorners(Color.FromArgb(56, 54, 53))
        Select Case State
            Case 0
                DrawGradient(Color.FromArgb(92, 89, 86), Color.FromArgb(74, 72, 70), ClientRectangle, 90S)
                DrawBorders(New Pen(New SolidBrush(Color.FromArgb(112, 109, 105))))
                DrawCorners(Color.FromArgb(82, 79, 77))
            Case 1
                DrawGradient(Color.FromArgb(112, 109, 106), Color.FromArgb(94, 92, 90), ClientRectangle, 90S)
                DrawBorders(New Pen(New SolidBrush(Color.FromArgb(141, 148, 130))))
                DrawCorners(Color.FromArgb(82, 79, 77))
            Case 2
                DrawGradient(Color.FromArgb(56, 54, 53), Color.FromArgb(73, 71, 69), ClientRectangle, 90S)
                DrawBorders(New Pen(New SolidBrush(Color.FromArgb(112, 109, 105))))
                DrawCorners(Color.FromArgb(82, 79, 77))
        End Select
        DrawText(New SolidBrush(Color.FromArgb(195, 193, 191)), Text.ToUpper, HorizontalAlignment.Left, 4, 0)
    End Sub
End Class

Class SteamSeparator
    Inherits ThemeControl153

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.FillRectangle(New SolidBrush(Color.FromArgb(56, 54, 53)), ClientRectangle)
        DrawGradient(Color.FromArgb(107, 104, 101), Color.FromArgb(74, 72, 70), New Rectangle(0, Height / 2, Width, 1), 45S)
    End Sub
End Class

Class SteamProgressBar
    Inherits ThemeControl153

    Private _Maximum As Integer
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is < _Value
                    _Value = v
            End Select
            _Maximum = v
            Invalidate()
        End Set
    End Property
    Private _Value As Integer
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 1
                Case Else
                    Return _Value
            End Select
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is > _Maximum
                    v = _Maximum
            End Select
            _Value = v
            Invalidate()
        End Set
    End Property

    Sub New()
        Transparent = True
        BackColor = Color.Transparent
        LockHeight = 18
        Value = 0
        Maximum = 100
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        'Fill
        Select Case _Value
            Case Is > 2
                G.FillRectangle(New SolidBrush(Color.FromArgb(166, 164, 161)), New Rectangle(4, 4, CInt(_Value / _Maximum * Width) - 8, Height - 8))
            Case Is > 0
                G.FillRectangle(New SolidBrush(Color.FromArgb(166, 164, 161)), New Rectangle(4, 4, CInt(_Value / _Maximum * Width) - 2, Height - 8))

        End Select

        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(128, 124, 120))))
        DrawCorners(BackColor)
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub
End Class

Class SteamTextBox
    Inherits ThemeControl153
    Dim WithEvents txtbox As New TextBox

    Private _PassMask As Boolean
    Public Property UsePasswordMask() As Boolean
        Get
            Return _PassMask
        End Get
        Set(ByVal v As Boolean)
            _PassMask = v
            Invalidate()
        End Set
    End Property
    Private _maxchars As Integer
    Public Property MaxCharacters() As Integer
        Get
            Return _maxchars
        End Get
        Set(ByVal v As Integer)
            _maxchars = v
        End Set
    End Property

    Sub New()
        txtbox.TextAlign = HorizontalAlignment.Center
        txtbox.BorderStyle = BorderStyle.None
        txtbox.Location = New Point(5, 6)
        txtbox.Font = New Font("Verdana", 7.25)
        Controls.Add(txtbox)
        Text = ""
        txtbox.Text = ""
        Me.Size = New Size(135, 35)
        Transparent = True
        BackColor = Color.Transparent
    End Sub

    Dim P1 As Pen

    Protected Overrides Sub ColorHook()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(56, 54, 53))
        Select Case UsePasswordMask
            Case True
                txtbox.UseSystemPasswordChar = True
            Case False
                txtbox.UseSystemPasswordChar = False
        End Select
        Size = New Size(Width, 25)
        txtbox.BackColor = Color.FromArgb(56, 54, 53)
        txtbox.ForeColor = Color.FromArgb(195, 193, 191)
        txtbox.Font = Font
        txtbox.Size = New Size(Width - 10, txtbox.Height - 10)
        txtbox.MaxLength = MaxCharacters
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(112, 109, 105))))
        DrawCorners(BackColor)
    End Sub
    Sub TextChngTxtBox() Handles txtbox.TextChanged
        Text = txtbox.Text
    End Sub
    Sub TextChng() Handles MyBase.TextChanged
        txtbox.Text = Text
    End Sub
End Class
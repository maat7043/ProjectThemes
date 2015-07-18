Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
'------------------
'Creator: Himler
'Created: 16/11/2012
'Version: 1.0.0
'------------------
Class clsNeoBuxTheme
    Inherits ThemeContainer154

    Sub New()
        TransparencyKey = Color.Fuchsia
        BackColor = Color.FromArgb(239, 239, 242)
        Font = New Font("Segoe UI", 9)
        SetColor("Text", Color.Black)

    End Sub

    Dim TextBrush As Brush


    Protected Overrides Sub ColorHook()
        TextBrush = GetBrush("Text")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.Gray)

        'MenuTop
        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(1, 1, Width - 2, Height - 2))

        'Border
        G.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(1, 35, Width - 2, Height - 38))

        'MainForm
        G.FillRectangle(New SolidBrush(Color.WhiteSmoke), New Rectangle(1, 36, Width - 2, Height - 39))


        'ColorLine
        Dim LGB As New LinearGradientBrush(New Rectangle(1, 36, Width - 2, Height - 255), Color.FromArgb(0, 177, 253), Color.FromArgb(46, 202, 56), 180.0F)
        G.DrawRectangle(New Pen(Color.LightGray), 1, 35, Width - 3, 4)
        G.FillRectangle(LGB, New Rectangle(1, 35, Width - 2, 4))

        'MenuItems
        G.DrawString(FindForm.Text, Font, TextBrush, New Point(35, 10))
        G.DrawIcon(FindForm.Icon, New Rectangle(10, 10, 16, 16))
        DrawCorners(Color.Fuchsia)

    End Sub
End Class

Class clsControlMenu
    Inherits ThemeControl154
    Private X As Integer
    Dim BG, Edge As Color
    Dim BEdge As Pen
    Protected Overrides Sub ColorHook()
        BG = GetColor("Background")
        Edge = GetColor("Edge color")
        BEdge = New Pen(GetColor("Button edge color"))
    End Sub

    Sub New()
        SetColor("Background", Color.FromArgb(239, 239, 242))
        SetColor("Edge color", Color.Transparent)
        SetColor("Button edge color", Color.Transparent)
        Me.Size = New Size(71, 19)
        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As System.EventArgs)
        MyBase.OnClick(e)
        If X <= 22 Then
            FindForm.WindowState = FormWindowState.Minimized
        ElseIf X > 22 And X <= 44 Then
            If FindForm.WindowState <> FormWindowState.Maximized Then FindForm.WindowState = FormWindowState.Maximized Else FindForm.WindowState = FormWindowState.Normal
        ElseIf X > 44 Then
            FindForm.Close()
        End If
    End Sub

    Protected Overrides Sub PaintHook()
        'Draw outer edge
        G.Clear(Color.FromArgb(239, 239, 242))

        'Fill buttons
        'Dim SB As New LinearGradientBrush(New Rectangle(New Point(1, 1), New Size(Width - 2, Height - 2)), BG, Color.FromArgb(30, 30, 30), 90.0F)
        G.FillRectangle(New SolidBrush(Color.FromArgb(239, 239, 242)), New Rectangle(New Point(1, 1), New Size(Width - 2, Height - 2)))

        'Draw icons
        G.DrawString("0", New Font("Marlett", 8.25), Brushes.Black, New Point(5, 5))
        If FindForm.WindowState <> FormWindowState.Maximized Then G.DrawString("1", New Font("Marlett", 8.25), Brushes.Black, New Point(27, 4)) Else G.DrawString("2", New Font("Marlett", 8.25), Brushes.Black, New Point(27, 4))
        G.DrawString("r", New Font("Marlett", 10), Brushes.Black, New Point(49, 3))

        'Glassy effect
        'Dim CBlend As New ColorBlend(2)
        'CBlend.Colors = {Color.FromArgb(100, Color.Black), Color.Transparent}
        'CBlend.Positions = {0, 1}
        'DrawGradient(CBlend, New Rectangle(New Point(1, 8), New Size(68, 8)), 90.0F)

        'Draw button outlines
        G.DrawRectangle(BEdge, New Rectangle(New Point(1, 1), New Size(20, 16)))
        G.DrawRectangle(BEdge, New Rectangle(New Point(23, 1), New Size(20, 16)))
        G.DrawRectangle(BEdge, New Rectangle(New Point(45, 1), New Size(24, 16)))

        'Mouse states
        Select Case State
            Case MouseState.Over
                If X <= 22 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), New Rectangle(New Point(1, 1), New Size(21, Height - 2)))
                ElseIf X > 22 And X <= 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), New Rectangle(New Point(23, 1), New Size(21, Height - 2)))
                ElseIf X > 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), New Rectangle(New Point(45, 1), New Size(25, Height - 2)))
                End If
            Case MouseState.Down
                If X <= 22 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), New Rectangle(New Point(1, 1), New Size(21, Height - 2)))
                ElseIf X > 22 And X <= 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), New Rectangle(New Point(23, 1), New Size(21, Height - 2)))
                ElseIf X > 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), New Rectangle(New Point(45, 1), New Size(25, Height - 2)))
                End If
        End Select
    End Sub
End Class

Class clsButtonGreen
    Inherits ThemeControl154

    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Text", Color.WhiteSmoke)
        SetColor("Border", Color.DarkGray)
    End Sub

    Protected Overrides Sub ColorHook()
        TextColor = GetBrush("Text")
        Border = GetPen("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        DrawCorners(Color.Fuchsia)
        G.Clear(BackColor)
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(23, 178, 23), Color.FromArgb(1, 156, 1), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGB1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(0, 124, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)


            Case MouseState.Over
                Dim LGBO1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(49, 188, 49), Color.FromArgb(26, 180, 26), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBO1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(0, 124, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)

            Case MouseState.Down
                Dim LGBD1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(49, 188, 49), Color.FromArgb(26, 180, 26), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBD1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(0, 124, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 1)
        End Select
    End Sub
End Class

Class clsButtonBlue
    Inherits ThemeControl154

    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Text", Color.WhiteSmoke)
        SetColor("Border", Color.DarkGray)
    End Sub

    Protected Overrides Sub ColorHook()
        TextColor = GetBrush("Text")
        Border = GetPen("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        DrawCorners(Color.Fuchsia)
        G.Clear(BackColor)
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(23, 167, 237), Color.FromArgb(1, 145, 215), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGB1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(0, 116, 172)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)


            Case MouseState.Over
                Dim LGBO1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(49, 178, 241), Color.FromArgb(26, 169, 239), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBO1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(0, 116, 172)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)

            Case MouseState.Down
                Dim LGBD1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(49, 178, 241), Color.FromArgb(26, 169, 239), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBD1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(0, 116, 172)), CreateRound(0, 0, Width - 1, Height - 1, 5))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 1)
        End Select
    End Sub
End Class

Class clsButtonOrange
    Inherits ThemeControl154

    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Text", Color.WhiteSmoke)
        SetColor("Border", Color.DarkGray)
    End Sub

    Protected Overrides Sub ColorHook()
        TextColor = GetBrush("Text")
        Border = GetPen("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        DrawCorners(Color.Fuchsia)
        G.Clear(BackColor)
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(253, 163, 23), Color.FromArgb(231, 141, 1), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGB1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(184, 112, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)


            Case MouseState.Over
                Dim LGBO1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(255, 175, 49), Color.FromArgb(255, 166, 26), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBO1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(184, 112, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)

            Case MouseState.Down
                Dim LGBD1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(255, 175, 49), Color.FromArgb(255, 166, 26), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBD1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(184, 112, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5))


                DrawText(TextColor, HorizontalAlignment.Center, 0, 1)
        End Select
    End Sub
End Class

Class clsButtonPurple
    Inherits ThemeControl154

    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Text", Color.WhiteSmoke)
        SetColor("Border", Color.DarkGray)
    End Sub

    Protected Overrides Sub ColorHook()
        TextColor = GetBrush("Text")
        Border = GetPen("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        DrawCorners(Color.Fuchsia)
        G.Clear(BackColor)
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(229, 43, 245), Color.FromArgb(207, 21, 223), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGB1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(165, 16, 178)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)


            Case MouseState.Over
                Dim LGBO1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(234, 67, 248), Color.FromArgb(231, 46, 247), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBO1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(165, 16, 178)), CreateRound(0, 0, Width - 1, Height - 1, 5))


                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)

            Case MouseState.Down
                Dim LGBD1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(234, 67, 248), Color.FromArgb(231, 46, 247), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBD1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(165, 16, 178)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 1)
        End Select
    End Sub
End Class

Class clsButtonGrey
    Inherits ThemeControl154

    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Text", Color.WhiteSmoke)
        SetColor("Border", Color.DarkGray)
    End Sub

    Protected Overrides Sub ColorHook()
        TextColor = GetBrush("Text")
        Border = GetPen("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        DrawCorners(Color.Fuchsia)
        G.Clear(BackColor)
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(161, 161, 161), Color.FromArgb(139, 139, 139), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGB1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(111, 111, 111)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)


            Case MouseState.Over
                Dim LGBO1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(172, 172, 172), Color.FromArgb(163, 163, 163), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBO1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(111, 111, 111)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)

            Case MouseState.Down
                Dim LGBD1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(172, 172, 172), Color.FromArgb(163, 163, 163), 90.0F)

                G.SmoothingMode = SmoothingMode.HighQuality
                G.FillPath(LGBD1, CreateRound(0, 1, Width - 1, Height - 2, 3))
                G.DrawPath(New Pen(Color.FromArgb(111, 111, 111)), CreateRound(0, 0, Width - 1, Height - 1, 5))

                DrawText(TextColor, HorizontalAlignment.Center, 0, 1)
        End Select
    End Sub
End Class
Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
'------------------
'Creator: The Erwan
'Site: lentcardenas.com
'------------------

Class OriginTheme
    Inherits ThemeContainer154

    Sub New()
        TransparencyKey = Color.Fuchsia
        BackColor = Color.FromArgb(245, 245, 245)
        Font = New Font("Segoe UI", 9)
        SetColor("border", Color.FromArgb(39, 38, 38))
        SetColor("Text", Color.White)
    End Sub

    Dim Border As Color
    Dim TextBrush As Brush
    Protected Overrides Sub ColorHook()
        Border = GetColor("border")
        TextBrush = GetBrush("Text")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Border)
        ' Dim HB As New HatchBrush(HatchStyle.Percent80, Color.FromArgb(45, Color.FromArgb(39, 38, 38)), Color.Transparent)
        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(3, 26, Width - 6, Height - 29))
        '.FillRectangle(HB, New Rectangle(6, 26, Width - 12, Height - 33))
        G.DrawString(FindForm.Text, Font, TextBrush, New Point(27, 3))
        G.DrawIcon(FindForm.Icon, New Rectangle(10, 3, 16, 16))
        DrawCorners(Color.Transparent)
    End Sub

End Class

Class OriginButton
    Inherits ThemeControl154

    Dim ButtonColor As Color
    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Button", Color.Orange)
        SetColor("Text", Color.White)
        SetColor("BorderColor", Color.White)
    End Sub

    Protected Overrides Sub ColorHook()
        ButtonColor = GetColor("Button")
        TextColor = GetBrush("Text")
        Border = GetPen("BorderColor")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(ButtonColor)
        Select Case State
            Case MouseState.None
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)
                DrawCorners(Color.White)
            Case MouseState.Over
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)
                DrawCorners(Color.White)
            Case MouseState.Down
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Silver)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)
                DrawCorners(Color.White)
        End Select
    End Sub
End Class

Class OriginGroupBox
    Inherits ThemeContainer154

    Sub New()
        ControlMode = True
        SetColor("Border", Color.Silver)
        SetColor("Header", Color.Gray)
        SetColor("TextColor", Color.White)
    End Sub

    Dim Border As Pen
    Dim HeaderColor, TextColor As Brush

    Protected Overrides Sub ColorHook()
        Border = GetPen("Border")
        HeaderColor = GetBrush("Header")
        TextColor = GetBrush("TextColor")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Dim HB As New HatchBrush(HatchStyle.Percent80, Color.FromArgb(45, Color.FromArgb(39, 38, 38)), Color.Transparent)
        G.FillRectangle(HeaderColor, New Rectangle(0, 0, Width - 2, 25))
        G.FillRectangle(HB, New Rectangle(0, 0, Width - 2, Height - 1))

        G.DrawRectangle(Border, New Rectangle(0, 0, Width - 2, 25))
        G.DrawRectangle(Border, New Rectangle(0, 0, Width - 2, Height - 1))
        G.DrawString(Text, Font, TextColor, New Point(5, 5))
    End Sub
End Class

Class SecondOriginButton
    Inherits ThemeControl154

    Dim ButtonColorTop, ButtonColorBottom As Color
    Dim TextColor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Button Top", Color.Silver)
        SetColor("Button Bottom", Color.Gray)
        SetColor("Text", Color.White)
        SetColor("BorderColor", Color.White)
    End Sub

    Protected Overrides Sub ColorHook()
        ButtonColorTop = GetColor("Button Top")
        ButtonColorBottom = GetColor("Button Bottom")
        TextColor = GetBrush("Text")
        Border = GetPen("BorderColor")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(ButtonColorTop)
        Select Case State
            Case MouseState.None
                Dim LGB As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90.0F)
                G.FillRectangle(LGB, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Black)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)
                DrawCorners(Color.White)
            Case MouseState.Over
                Dim LGB As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90.0F)
                G.FillRectangle(LGB, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)
                DrawCorners(Color.White)
            Case MouseState.Down
                'Dim LGB As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90.0F)
                'G.FillRectangle(LGB, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(TextColor, HorizontalAlignment.Center, 0, 0)
                DrawCorners(Color.White)
        End Select
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class OriginRadioButton
    Inherits ThemeControl154

    Sub New()
        LockHeight = 17
        SetColor("Text", Color.Black)
        SetColor("Gradient 1", 245, 245, 245)
        SetColor("Gradient 2", 225, 225, 225)
        SetColor("Glow", 245, 245, 245)
        SetColor("Edges", 170, 170, 170)
        SetColor("Backcolor", Color.FromArgb(245, 245, 245))
        SetColor("Bullet", Color.Orange)
        Width = 180
    End Sub

    Private X As Integer
    Private TextColor, G1, G2, Glow, Edge, BG As Color

    Protected Overrides Sub ColorHook()
        TextColor = GetColor("Text")
        G1 = GetColor("Gradient 1")
        G2 = GetColor("Gradient 2")
        Glow = GetColor("Glow")
        Edge = GetColor("Edges")
        BG = GetColor("Backcolor")
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.Location.X
        Invalidate()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)
        G.SmoothingMode = SmoothingMode.HighQuality
        If _Checked Then
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 14)), G1, G2, 90.0F)
            G.FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))
            G.FillEllipse(New SolidBrush(Glow), New Rectangle(New Point(0, 0), New Size(14, 7)))
        Else
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 16)), G1, G2, 90.0F)
            G.FillEllipse(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))
            G.FillEllipse(New SolidBrush(Glow), New Rectangle(New Point(0, 0), New Size(14, 7)))
        End If

        If State = MouseState.Over And X < 15 Then
            Dim SB As New SolidBrush(Color.FromArgb(70, Color.White))
            G.FillEllipse(SB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        ElseIf State = MouseState.Down And X < 15 Then
            Dim SB As New SolidBrush(Color.FromArgb(10, Color.Black))
            G.FillEllipse(SB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        End If

        'Dim HB As New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(7, Color.Black), Color.Transparent)
        'G.FillEllipse(HB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        G.DrawEllipse(New Pen(Edge), New Rectangle(New Point(0, 0), New Size(14, 14)))

        If _Checked Then G.FillEllipse(GetBrush("Bullet"), New Rectangle(New Point(4, 4), New Size(6, 6)))
        DrawText(New SolidBrush(TextColor), HorizontalAlignment.Left, 19, -1)
    End Sub

    Private _Field As Integer = 16
    Property Field() As Integer
        Get
            Return _Field
        End Get
        Set(ByVal value As Integer)
            If value < 4 Then Return
            _Field = value
            LockHeight = value
            Invalidate()
        End Set
    End Property

    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnMouseDown(e)
    End Sub

    Event CheckedChanged(ByVal sender As Object)

    Protected Overrides Sub OnCreation()
        InvalidateControls()
    End Sub

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is OriginRadioButton Then
                DirectCast(C, OriginRadioButton).Checked = False
            End If
        Next
    End Sub

End Class

<DefaultEvent("CheckedChanged")> _
Class OriginCheckBox
    Inherits ThemeControl154

    Sub New()
        LockHeight = 17
        SetColor("Text", Color.Black)
        SetColor("Gradient 1", 230, 230, 230)
        SetColor("Gradient 2", 210, 210, 210)
        SetColor("Glow", 230, 230, 230)
        SetColor("Edges", 170, 170, 170)
        SetColor("Backcolor", 245, 245, 245)
        SetColor("BK", Color.FromArgb(245, 245, 245))
        Width = 160
    End Sub

    Private X As Integer
    Private TextColor, G1, G2, Glow, Edge, BG As Color
    Dim BK As Brush

    Protected Overrides Sub ColorHook()
        TextColor = GetColor("Text")
        G1 = GetColor("Gradient 1")
        G2 = GetColor("Gradient 2")
        Glow = GetColor("Glow")
        Edge = GetColor("Edges")
        BG = GetColor("Backcolor")
        BK = GetBrush("BK")
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.Location.X
        Invalidate()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)
        If _Checked Then
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 14)), G1, G2, 90.0F)
            G.FillRectangle(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))
            G.FillRectangle(New SolidBrush(Glow), New Rectangle(New Point(0, 0), New Size(14, 7)))
        Else
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(14, 16)), G1, G2, 90.0F)
            G.FillRectangle(LGB, New Rectangle(New Point(0, 0), New Size(14, 14)))
            G.FillRectangle(New SolidBrush(Glow), New Rectangle(New Point(0, 0), New Size(14, 7)))
        End If

        If State = MouseState.Over And X < 15 Then
            Dim SB As New SolidBrush(Color.FromArgb(70, Color.White))
            G.FillRectangle(SB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        ElseIf State = MouseState.Down And X < 15 Then
            Dim SB As New SolidBrush(Color.FromArgb(10, Color.Black))
            G.FillRectangle(SB, New Rectangle(New Point(0, 0), New Size(14, 14)))
        End If


        G.FillRectangle(BK, New Rectangle(New Point(0, 0), New Size(14, 14)))
        G.DrawRectangle(New Pen(Edge), New Rectangle(New Point(0, 0), New Size(14, 14)))

        If _Checked Then G.DrawString("a", New Font("Marlett", 12), Brushes.Orange, New Point(-3, -1))
        DrawText(New SolidBrush(TextColor), HorizontalAlignment.Left, 19, -1)
    End Sub

    Private _Checked As Boolean
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnMouseDown(e)
    End Sub

    Event CheckedChanged(ByVal sender As Object)

End Class
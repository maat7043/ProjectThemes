﻿Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
'------------------------
'Credits:
'Example - Theme Creator
'Mavamaarten~ - Hatchbrush in Progressbar and TabControl
'
'Created on - 9/17/12
'Released on - 9/22/12
'
'Example Profile Link - http://www.hackforums.net/member.php?action=profile&uid=672917
'Mavamaarten~ Profile Link - http://www.hackforums.net/member.php?action=profile&uid=244760
'------------------------

Class VitalityTheme
    Inherits ThemeContainer154
    Dim G1, G2, BG As Color

    Sub New()
        TransparencyKey = Color.Fuchsia
        SetColor("G1", Color.White)
        SetColor("G2", Color.LightGray)
        SetColor("BG", Color.FromArgb(240, 240, 240))
    End Sub

    Protected Overrides Sub ColorHook()
        G1 = GetColor("G1")
        G2 = GetColor("G2")
        BG = GetColor("BG")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)

        Dim LGB As New LinearGradientBrush(New Rectangle(New Point(1, 1), New Size(Me.Width - 2, 23)), G1, G2, 90.0F)
        G.FillRectangle(LGB, New Rectangle(New Point(1, 1), New Size(Me.Width - 2, 23)))

        G.DrawLine(Pens.LightGray, 1, 25, Me.Width - 2, 25)
        G.DrawLine(Pens.White, 1, 26, Me.Width - 2, 26)

        DrawCorners(TransparencyKey)
        DrawBorders(Pens.LightGray, 1)

        Dim IconRec As Rectangle = New Rectangle(3, 3, 20, 20)
        G.DrawIcon(ParentForm.Icon, IconRec)

        G.DrawString(ParentForm.Text, New Font("Segoe UI", 9), Brushes.Gray, New Point(25, 5))
    End Sub
End Class

Class VitalityButton
    Inherits ThemeControl154
    Dim G1, G2, BG As Color

    Sub New()
        Me.Size = New Size(120, 26)
        SetColor("G1", Color.White)
        SetColor("G2", Color.LightGray)
        SetColor("BG", Color.FromArgb(240, 240, 240))
    End Sub

    Protected Overrides Sub ColorHook()
        G1 = GetColor("G1")
        G2 = GetColor("G2")
        BG = GetColor("BG")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)

        If State = MouseState.Over Then
            G.FillRectangle(Brushes.White, New Rectangle(New Point(0, 0), New Size(Width, Height)))
        ElseIf State = MouseState.Down Then
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(Width, Height)), Color.FromArgb(240, 240, 240), Color.White, 90.0F)
            G.FillRectangle(LGB, New Rectangle(New Point(0, 0), New Size(Width, Height)))
        ElseIf State = MouseState.None Then
            Dim LGB As New LinearGradientBrush(New Rectangle(New Point(0, 0), New Size(Width, Height)), Color.White, Color.FromArgb(240, 240, 240), 90.0F)
            G.FillRectangle(LGB, New Rectangle(New Point(0, 0), New Size(Width, Height)))
        End If

        DrawBorders(Pens.LightGray)
        DrawCorners(Color.Transparent)

        Dim SF As New StringFormat
        SF.Alignment = StringAlignment.Center
        SF.LineAlignment = StringAlignment.Center
        G.DrawString(Me.Text, New Font("Segoe UI", 9), Brushes.Gray, New RectangleF(2, 2, Me.Width - 5, Me.Height - 4), SF)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class VitalityCheckbox
    Inherits ThemeControl154
    Dim BG As Color
    Private _Checked As Boolean

    Event CheckedChanged(ByVal sender As Object)

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal V As Boolean)
            _Checked = V
            Invalidate()
            RaiseEvent CheckedChanged(Me)
        End Set
    End Property

    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If _Checked = True Then _Checked = False Else _Checked = True
    End Sub

    Sub New()
        LockHeight = 22
        SetColor("G1", Color.White)
        SetColor("G2", Color.LightGray)
        SetColor("BG", Color.FromArgb(240, 240, 240))
    End Sub

    Protected Overrides Sub ColorHook()
        BG = GetColor("BG")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)

        If _Checked Then G.DrawString("a", New Font("Marlett", 14), Brushes.Gray, New Point(0, 1))

        If State = MouseState.Over Then
            G.FillRectangle(Brushes.White, New Rectangle(New Point(3, 3), New Size(15, 15)))
            If _Checked Then G.DrawString("a", New Font("Marlett", 14), Brushes.Gray, New Point(0, 1))
        End If

        G.DrawRectangle(Pens.White, 2, 2, 17, 17)
        G.DrawRectangle(Pens.LightGray, 3, 3, 15, 15)
        G.DrawRectangle(Pens.LightGray, 1, 1, 19, 19)

        G.DrawString(Text, New Font("Segoe UI", 9), Brushes.Gray, 22, 3)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class VitalityRadiobutton
    Inherits ThemeControl154
    Dim BG As Color

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

    Event CheckedChanged(ByVal sender As Object)

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is VitalityRadiobutton Then
                DirectCast(C, VitalityRadiobutton).Checked = False
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnMouseDown(e)
    End Sub

    Sub New()
        LockHeight = 22
        Width = 140
        SetColor("BG", Color.FromArgb(240, 240, 240))
    End Sub

    Protected Overrides Sub ColorHook()
        BG = GetColor("BG")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)

        G.SmoothingMode = SmoothingMode.HighQuality

        If _Checked Then G.FillEllipse(Brushes.Gray, New Rectangle(New Point(7, 7), New Size(8, 8)))

        If State = MouseState.Over Then
            G.FillEllipse(Brushes.White, New Rectangle(New Point(4, 4), New Size(14, 14)))
            If _Checked Then G.FillEllipse(Brushes.Gray, New Rectangle(New Point(7, 7), New Size(8, 8)))
        End If

        G.DrawEllipse(Pens.White, New Rectangle(New Point(3, 3), New Size(16, 16)))
        G.DrawEllipse(Pens.LightGray, New Rectangle(New Point(2, 2), New Size(18, 18)))
        G.DrawEllipse(Pens.LightGray, New Rectangle(New Point(4, 4), New Size(14, 14)))

        G.DrawString(Text, New Font("Segoe UI", 9), Brushes.Gray, 23, 3)
    End Sub
End Class

Class VitalityProgressbar
    Inherits ThemeControl154
    Dim BG As Color
    Dim HBPos As Integer

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            Invalidate()
        End Set
    End Property

    Private Sub Increment(ByVal amount As Integer)
        Value += amount
    End Sub

    Property Animated() As Boolean
        Get
            Return IsAnimated
        End Get
        Set(ByVal value As Boolean)
            IsAnimated = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnAnimation()
        If HBPos = 0 Then
            HBPos = 7
        Else
            HBPos += 1
        End If
    End Sub

    Sub New()
        Animated = True
        SetColor("BG", Color.FromArgb(240, 240, 240))
    End Sub

    Protected Overrides Sub ColorHook()
        BG = GetColor("BG")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BG)

        DrawBorders(Pens.LightGray, 1)
        DrawCorners(Color.Transparent)

        Dim LGB As New LinearGradientBrush(New Rectangle(New Point(2, 2), New Size(Width - 2, Height - 5)), Color.White, Color.FromArgb(240, 240, 240), 90.0F)
        G.FillRectangle(LGB, New Rectangle(New Point(2, 2), New Size((Width / Maximum) * Value - 5, Height - 5)))

        G.RenderingOrigin = New Point(HBPos, 0)
        Dim HB As New HatchBrush(HatchStyle.BackwardDiagonal, Color.LightGray, Color.Transparent)
        G.FillRectangle(HB, New Rectangle(New Point(1, 2), New Size((Width / Maximum) * Value - 3, Height - 3)))
        G.DrawLine(Pens.LightGray, New Point((Width / Maximum) * Value - 2, 1), New Point((Width / Maximum) * Value - 2, Height - 3))
    End Sub
End Class

Class VitalityTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Try : SelectedTab.BackColor = Color.FromArgb(240, 240, 240) : Catch : End Try
        G.Clear(Parent.BackColor)
        For i = 0 To TabCount - 1
            If Not i = SelectedIndex Then
                Dim x2 As Rectangle = New Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 2, GetTabRect(i).Height)
                Dim G1 As New LinearGradientBrush(New Point(x2.X, x2.Y), New Point(x2.X, x2.Y + x2.Height), Color.White, Color.LightGray)
                G.FillRectangle(G1, x2) : G1.Dispose()
                G.DrawRectangle(Pens.LightGray, x2)
                G.DrawRectangle(Pens.LightGray, New Rectangle(x2.X + 1, x2.Y + 1, x2.Width - 2, x2.Height))
                G.DrawString(TabPages(i).Text, Font, Brushes.Gray, x2, New StringFormat With {.LineAlignment = StringAlignment.Near, .Alignment = StringAlignment.Center})
            End If
        Next

        G.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), 0, ItemSize.Height, Width, Height)
        G.DrawRectangle(Pens.LightGray, 0, ItemSize.Height, Width - 1, Height - ItemSize.Height - 1)
        G.DrawRectangle(Pens.LightGray, 1, ItemSize.Height + 1, Width - 3, Height - ItemSize.Height - 3)
        If Not SelectedIndex = -1 Then
            Dim x1 As Rectangle = New Rectangle(GetTabRect(SelectedIndex).X - 2, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width + 3, GetTabRect(SelectedIndex).Height)
            Dim GradientBrush As New LinearGradientBrush(New Rectangle(x1.X + 2, x1.Y + 2, x1.Width - 2, x1.Height), Color.White, Color.LightGray, 90.0F)
            G.FillRectangle(New SolidBrush(Color.FromArgb(240, 240, 240)), New Rectangle(x1.X + 2, x1.Y + 2, x1.Width - 2, x1.Height))
            G.DrawLine(Pens.LightGray, New Point(x1.X, x1.Y + x1.Height - 2), New Point(x1.X, x1.Y))
            G.DrawLine(Pens.LightGray, New Point(x1.X, x1.Y), New Point(x1.X + x1.Width, x1.Y))
            G.DrawLine(Pens.LightGray, New Point(x1.X + x1.Width, x1.Y), New Point(x1.X + x1.Width, x1.Y + x1.Height - 2))

            G.DrawLine(Pens.LightGray, New Point(x1.X + 1, x1.Y + x1.Height - 1), New Point(x1.X + 1, x1.Y + 1))
            G.DrawLine(Pens.LightGray, New Point(x1.X + 1, x1.Y + 1), New Point(x1.X + x1.Width - 1, x1.Y + 1))
            G.DrawLine(Pens.LightGray, New Point(x1.X + x1.Width - 1, x1.Y + 1), New Point(x1.X + x1.Width - 1, x1.Y + x1.Height - 1))

            G.DrawString(TabPages(SelectedIndex).Text, Font, Brushes.Gray, x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
        End If

        G.DrawLine(New Pen(Color.FromArgb(240, 240, 240)), New Point(0, 1), New Point(0, 2))

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class

Class VitalityTextBox
    Inherits TextBox

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case 15
                Invalidate()
                MyBase.WndProc(m)
                Me.CustomPaint()
                Exit Select
            Case Else
                MyBase.WndProc(m)
                Exit Select
        End Select
    End Sub

    Sub New()
        Font = New Font("Microsoft Sans Serif", 8)
        ForeColor = Color.Gray
        BackColor = Color.FromArgb(235, 235, 235)
        BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub CustomPaint()
        Dim p As Pen = Pens.LightGray
        CreateGraphics.DrawLine(p, 0, 0, Width, 0)
        CreateGraphics.DrawLine(p, 0, Height - 1, Width, Height - 1)
        CreateGraphics.DrawLine(p, 0, 0, 0, Height - 1)
        CreateGraphics.DrawLine(p, Width - 1, 0, Width - 1, Height - 1)
    End Sub
End Class

Class VitalityLabel
    Inherits Label

    Sub New()
        ForeColor = Color.Gray
        BackColor = Color.Transparent
    End Sub
End Class
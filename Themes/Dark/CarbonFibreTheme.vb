'[INFO]
'ThemeBase Creator: Aeonhack
'Site: *********
'[DATE]
'Created: 08/02/2011
'Changed: 12/06/2011
'[VERSION]
'ThemeBase Version: 1.5.4
'
'[INFO]
'Theme Creator: Novi
'Theme Name: CarbonOrainsTheme
'[DATE]
'Created: 7/14/2013
'Changed: 7/26/2013
'Released: 7/27/2013
'[VERSION]
'Version: 1.1
'[CREDITS]
'Thanks to Mavamaarten for the tut =))
'Thanks to Aeonhack for the important ThemeBase154
'--------[/CREDITS]------------
#Region "Imports"
Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Windows.Forms.TabControl
Imports System.ComponentModel.Design
#End Region

Class CarbonFiberTheme
    Inherits ThemeContainer154
#Region "Properties"
    Private _Icon As Icon
    Public Property Icon() As Icon
        Set(ByVal value As Icon)
            _Icon = value
        End Set
        Get
            Return _Icon
        End Get
    End Property
    Private _ShowIcon As Boolean
    Public Property ShowIcon As Boolean
        Get
            Return _ShowIcon
        End Get
        Set(ByVal value As Boolean)
            _ShowIcon = value
            Invalidate()
        End Set
    End Property

    Sub New()
        BackColor = Color.FromArgb(22, 22, 22)
        TransparencyKey = Color.Fuchsia
        Font = New Font("Verdana", 8)
        Header = 30
    End Sub

    Protected Overrides Sub ColorHook()
        ' Color hook is just a waste of time haha !!
        '
        '
    End Sub
#End Region
#Region "Color of Control"
    Protected Overrides Sub PaintHook()
        'This G.Clear does not need ^^
        G.Clear(Color.FromArgb(31, 31, 31))

        '''''''''' Gradient the Body '''''''
        Dim GradientBG As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(22, 22, 22), -270S)
        G.FillRectangle(GradientBG, New Rectangle(0, 0, Width - 1, Height - 1))

        '''''''''' Draw Body '''''''
        Dim BodyHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
        G.FillRectangle(BodyHatch, New Rectangle(0, 0, Width - 1, Height - 1))
        ' G.FillRectangle(New SolidBrush(Color.FromArgb(32, 32, 32)), New Rectangle(10, 10, Width - 21, Height - 21))
        G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(10, 32, Width - 21, Height - 43))
        G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(9, 31, Width - 19, Height - 41))


        '''''''''' Draw Header '''''''
        Dim Header As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, 30), Color.FromArgb(25, 25, 25), Color.FromArgb(40, 40, 40), 270S)
        G.FillRectangle(Header, New Rectangle(0, 0, Width - 1, 30))
        Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
        G.FillRectangle(HeaderHatch, New Rectangle(0, 0, Width - 1, 30))
        G.FillRectangle(New SolidBrush(Color.FromArgb(15, Color.White)), 0, 0, Width - 1, 15)

        '''''''''' Draw Header Seperator ''''''
        'G.DrawLine(New Pen(Color.FromArgb(18, 18, 18)), 0, 15, Width + 9000, 15) ' Please dont use 9000 above ^^
        G.DrawLine(New Pen(Color.FromArgb(42, 42, 42)), 0, 15, Width - 1, 15) ' Cuz it has a bug dont worry i will fix it =)

        '''''''''' Draw Header Border '''''''
        'DrawGradient(BlendColor, New Rectangle(0, 0, Width - 1, 32), 0.0F)
        G.FillRectangle(New SolidBrush(Color.FromArgb(22, 22, 22)), New Rectangle(11, 33, Width - 23, Height - 45))
        G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawRectangle(New Pen(Color.FromArgb(49, 49, 49)), New Rectangle(1, 1, Width - 3, Height - 3))

        '''''''''' Reduce Corners '''''''


        '''''''''' Draw Icon and Text '''''''
        If _ShowIcon = False Then
            G.DrawString(Text, Font, New SolidBrush(Color.Black), New Point(8, 7)) ' Text Shadow
            G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(8, 8))
        Else
            G.DrawIcon(FindForm.Icon, New Rectangle(New Point(9, 7), New Size(16, 16)))
            G.DrawString(Text, Font, New SolidBrush(Color.Black), New Point(28, 7)) ' Text Shadow
            G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(28, 8))
        End If

    End Sub
#End Region
End Class
Class CarbonFiberLabel
    Inherits ThemeControl154
#Region "Properties"
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Dim textSize, textSize1 As Integer
        textSize = Me.CreateGraphics.MeasureString(Text, Font).Width
        textSize1 = Me.CreateGraphics.MeasureString(Text, Font).Height

        Me.Width = 5 + textSize
        Me.Height = textSize1
    End Sub
    Sub New()
        Transparent = True
        BackColor = Color.Transparent
        Me.Size = New Point(50, 16)
        'MinimumSize = New Size(50, 16)
        'MaximumSize = New Size(600, 16)
    End Sub
    Protected Overrides Sub ColorHook()
        ' bleh bleh bleh waste of time !!
    End Sub
#End Region
#Region "Color Of Control"
    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)

        G.DrawString(Text, Font, New SolidBrush(Color.Black), New Point(1, 0)) ' Text Shadow
        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(1, 1))
    End Sub
#End Region
End Class
Class CarbonFiberButton
    Inherits ThemeControl154
#Region "Properties"
    Sub New()
        Me.Size = New Point(142, 29)
    End Sub
    Protected Overrides Sub ColorHook()
        ' blah blah blah waste of time !!
    End Sub
#End Region
#Region "Color Of Control"
    Protected Overrides Sub PaintHook()

        G.Clear(Color.FromArgb(22, 22, 22))

        Dim Header As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(42, 42, 42), 270S)
        G.FillRectangle(Header, New Rectangle(0, 0, Width - 1, Height - 1))


        Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
        G.FillRectangle(HeaderHatch, New Rectangle(0, 0, Width - 1, Height - 1))

        Select Case State
            Case MouseState.Over
                Dim Header1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270S)
                G.FillRectangle(Header1, New Rectangle(0, 0, Width - 1, Height - 1))


                Dim HeaderHatch1 As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
                G.FillRectangle(HeaderHatch1, New Rectangle(0, 0, Width - 1, Height - 1))

            Case MouseState.Down
                Dim Header1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(35, 35, 35), 270S)
                G.FillRectangle(Header1, New Rectangle(0, 0, Width - 1, Height - 1))


                Dim HeaderHatch1 As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
                G.FillRectangle(HeaderHatch1, New Rectangle(0, 0, Width - 1, Height - 1))
        End Select

        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(6, 6, 6)), New Rectangle(-1, -1, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Rectangle(0, 0, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

        DrawBorders(Pens.Black)
        DrawBorders(New Pen(Color.FromArgb(32, 32, 32)), 1)

        DrawCorners(Color.FromArgb(22, 22, 22), 1)
        DrawCorners(Color.FromArgb(22, 22, 22))
    End Sub
#End Region
End Class
Class CarbonFiberListBox : Inherits ListBox
#Region "Properties"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        DoubleBuffered = True
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(22, 22, 22)
        BorderStyle = Windows.Forms.BorderStyle.None
        ItemHeight = 15
    End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If m.Msg = 15 Then CustomPaint()
    End Sub
    Sub CustomPaint() ' if you dont call this border will not show ^^
        CreateGraphics.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(1, 1, Width - 3, Height - 3))
        CreateGraphics.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(0, 0, Width - 1, Height - 1))
    End Sub
#End Region
#Region "Color of Control"
    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
        Dim G As Graphics = e.Graphics
        G.SmoothingMode = SmoothingMode.HighQuality
        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height + 3))

        If e.State.ToString().Contains("Selected,") Then
            Dim MainBody As New LinearGradientBrush(New Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270S)
            G.FillRectangle(MainBody, New Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height))
            G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height))
            Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
            G.FillRectangle(HeaderHatch, New Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height))
            'G.FillRectangle(New SolidBrush(Color.FromArgb(5, Color.White)), New Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 8))
        Else
            G.FillRectangle(New SolidBrush(BackColor), e.Bounds)
        End If

        Try
            ' put a space cuz the text will stick into the left
            G.DrawString(" " & Items(e.Index).ToString(), Font, New SolidBrush(Color.FromArgb(100, Color.Black)), e.Bounds.X, e.Bounds.Y)
            G.DrawString(" " & Items(e.Index).ToString(), Font, New SolidBrush(Color.FromArgb(255, 150, 0)), e.Bounds.X, e.Bounds.Y + 1)
        Catch : End Try
        G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(1, 1, Width - 3, Height - 3))
        G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(0, 0, Width - 1, Height - 1))
        MyBase.OnDrawItem(e)
    End Sub
#End Region
End Class
Class CarbonFiberGroupBox
    Inherits ThemeContainer154
#Region "Properties"
    Sub New()
        ControlMode = True
        TransparencyKey = Color.Fuchsia
        Font = New Font("Verdana", 8)
        Me.Size = New Point(172, 105)
    End Sub

    Protected Overrides Sub ColorHook()
        ' another waste of time HAHA !!
    End Sub
#End Region
#Region "Color of Control"
    Protected Overrides Sub PaintHook()

        G.Clear(Color.FromArgb(22, 22, 22))

        '''''''''' Draw Header '''''''

        G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(1, 1, Width - 3, Height - 3))

        Dim Header As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, 26), Color.FromArgb(25, 25, 25), Color.FromArgb(40, 40, 40), 270S)
        G.FillRectangle(Header, New Rectangle(0, 0, Width - 1, 26))

        Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
        G.FillRectangle(HeaderHatch, New Rectangle(0, 0, Width - 1, 26))
        G.FillRectangle(New SolidBrush(Color.FromArgb(13, Color.White)), 0, 0, Width - 1, 13)

        G.DrawLine(New Pen(Color.FromArgb(42, 42, 42)), 0, 13, Width - 1, 13) ' Cuz it has a bug dont worry i will fix it =)

        G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(0, 0, Width - 1, Height - 1))
        ' Draw Border
        'G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(0, 0, Width - 1, 27))
        'G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(0, 0, Width - 1, Height - 1))


        G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(1, 1, Width - 3, 25))
        G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(1, 1, Width - 3, 24))

        '''''''''' Draw Text and Shadw '''''''
        'G.DrawString(Text, Font, New SolidBrush(Color.Black), New Point(9, 7)) ' Text Shadow
        'G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(8, 6))

        DrawText(New SolidBrush(Color.Black), HorizontalAlignment.Center, 1, 1)
        DrawText(New SolidBrush(Color.FromArgb(255, 150, 0)), HorizontalAlignment.Center, 2, 2)

        'DrawCorners(Color.FromArgb(22, 22, 22), 1)
        'DrawCorners(Color.FromArgb(22, 22, 22))
    End Sub
#End Region

End Class
<DefaultEvent("CheckedChanged")> _
Class CarbonFiberCheckbox
#Region "Properties"
    Inherits ThemeControl154
    Private _Checked As Boolean
    Private X As Integer

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

    Protected Overrides Sub ColorHook()
        ' again another waste of time >.<
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Dim textSize As Integer
        textSize = Me.CreateGraphics.MeasureString(Text, Font).Width
        Me.Width = 20 + textSize
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If _Checked = True Then _Checked = False Else _Checked = True
    End Sub
#End Region
#Region "Color of Control"
    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.HighQuality
        G.DrawRectangle(New Pen(Color.FromArgb(29, 29, 29)), 1, 1, 14, 13)

        If State = MouseState.Over Then
            G.DrawString("a", New Font("Marlett", 12), New SolidBrush(Color.FromArgb(13, Color.White)), New Point(-2, 0))
        End If

        If _Checked Then
            Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.Black), Color.Transparent)
            G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), 2, 2, 12, 6) 'Gloss
            G.FillRectangle(HeaderHatch, New Rectangle(2, 2, 12, 12))
            G.DrawString("a", New Font("Marlett", 12), New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(-2, 0))
        Else
            ' Do Nothing ^^
        End If

        G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), 0, 0, 16, 15)
        G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), 2, 2, 12, 11)
        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(0, 0, 0)), 17, 0)
        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), 18, 1)
    End Sub

    Public Sub New()
        Me.Size = New Point(50, 16)
        MinimumSize = New Size(50, 16)
        MaximumSize = New Size(600, 16)
        BackColor = Color.Transparent
    End Sub
#End Region
End Class
Class CarbonFiberCustomBox
    Inherits ThemeContainer154
#Region "Properties"
    Sub New()
        ControlMode = True
        Size = New Size(150, 100)
        BackColor = Color.FromArgb(22, 22, 22)
    End Sub


    Protected Overrides Sub ColorHook()

    End Sub
#End Region
#Region "Color of Control"
    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.FillRectangle(New SolidBrush(Color.FromArgb(22, 22, 22)), ClientRectangle)
        DrawBorders(New Pen(Color.FromArgb(6, 6, 6)), 1)
        DrawBorders(New Pen(Color.FromArgb(32, 32, 32)))
    End Sub
#End Region

End Class
Class CarbonFiberTabControl
    Inherits TabControl
#Region "Properties"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or _
        ControlStyles.UserPaint Or _
        ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True

    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub
    Dim C1 As Color = Color.FromArgb(22, 22, 22) ' BackColor
    Dim C2 As Color = Color.FromArgb(6, 6, 6) ' ' OUter Black
    Dim C3 As Color = Color.FromArgb(32, 32, 32) ' ' Inner Border
#End Region
#Region "Color Of Control"
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Try : SelectedTab.BackColor = C1 : Catch : End Try
        G.Clear(Parent.BackColor)
        For i = 0 To TabCount - 1
            If Not i = SelectedIndex Then
                Dim x2 As Rectangle = New Rectangle(GetTabRect(i).X - 1, GetTabRect(i).Y + 1, GetTabRect(i).Width + 2, GetTabRect(i).Height)
                Dim G1 As New LinearGradientBrush(New Point(x2.X, x2.Y), New Point(x2.X, x2.Y + x2.Height), Color.FromArgb(22, 22, 22), Color.FromArgb(22, 22, 22))
                G.FillRectangle(G1, x2) : G1.Dispose()
                G.DrawRectangle(New Pen(C3), x2)
                G.DrawRectangle(New Pen(C2), New Rectangle(x2.X + 1, x2.Y + 1, x2.Width - 2, x2.Height))
                G.DrawString(TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(250, 150, 0)), x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center}) '
            End If
        Next

        G.FillRectangle(New SolidBrush(C1), 0, ItemSize.Height, Width, Height)
        G.DrawRectangle(New Pen(C2), 0, ItemSize.Height, Width - 1, Height - ItemSize.Height - 1)
        G.DrawRectangle(New Pen(C3), 1, ItemSize.Height + 1, Width - 3, Height - ItemSize.Height - 3)
        If Not SelectedIndex = -1 Then
            Dim x1 As Rectangle = New Rectangle(GetTabRect(SelectedIndex).X - 2, GetTabRect(SelectedIndex).Y, GetTabRect(SelectedIndex).Width + 3, GetTabRect(SelectedIndex).Height)
            G.FillRectangle(New SolidBrush(C1), New Rectangle(x1.X + 2, x1.Y + 2, x1.Width - 2, x1.Height))
            G.DrawLine(New Pen(C2), New Point(x1.X, x1.Y + x1.Height - 2), New Point(x1.X, x1.Y))
            G.DrawLine(New Pen(C2), New Point(x1.X, x1.Y), New Point(x1.X + x1.Width, x1.Y))
            G.DrawLine(New Pen(C2), New Point(x1.X + x1.Width, x1.Y), New Point(x1.X + x1.Width, x1.Y + x1.Height - 2))

            G.DrawLine(New Pen(C3), New Point(x1.X + 1, x1.Y + x1.Height - 1), New Point(x1.X + 1, x1.Y + 1))
            G.DrawLine(New Pen(C3), New Point(x1.X + 1, x1.Y + 1), New Point(x1.X + x1.Width - 1, x1.Y + 1))
            G.DrawLine(New Pen(C3), New Point(x1.X + x1.Width - 1, x1.Y + 1), New Point(x1.X + x1.Width - 1, x1.Y + x1.Height - 1))

            G.DrawString(TabPages(SelectedIndex).Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), x1, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
        End If

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()

    End Sub
#End Region
End Class
<DefaultEvent("CheckedChanged")> _
Class CarbonFiberRadioButton
#Region "Properties"
    Inherits ThemeControl154
    Private X As Integer
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

    Protected Overrides Sub OnCreation()
        InvalidateControls()
    End Sub

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return

        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is CarbonFiberRadioButton Then
                DirectCast(C, CarbonFiberRadioButton).Checked = False
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        Invalidate()
    End Sub


    Protected Overrides Sub ColorHook()
        ' again and again another waste of time >.<
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Dim textSize As Integer
        textSize = Me.CreateGraphics.MeasureString(Text, Font).Width
        Me.Width = 20 + textSize
    End Sub
#End Region
#Region "Color Of Control"
    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(22, 22, 22))
        G.SmoothingMode = SmoothingMode.HighQuality

        If State = MouseState.Over Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(29, 29, 29)), New Rectangle(3, 3, 10, 10))
            G.DrawEllipse(New Pen(Color.FromArgb(22, 22, 22)), 5, 5, 6, 6)
        End If

        If _Checked Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(255, 150, 0)), 5, 5, 6, 6)
        Else
        End If

        G.DrawEllipse(New Pen(Color.FromArgb(6, 6, 6)), 0, 0, 16, 16)
        G.DrawEllipse(New Pen(Color.FromArgb(29, 29, 29)), 1, 1, 14, 14)
        G.DrawEllipse(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(2, 2, 12, 12))

        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(0, 0, 0)), 17, 0)
        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), 18, 1)
    End Sub

    Public Sub New()
        Me.Size = New Point(50, 17)
        MinimumSize = New Size(50, 17)
        MaximumSize = New Size(600, 17)
    End Sub
#End Region
End Class
Class CarbonFiberControlButton
    Inherits ThemeControl154
#Region "Properties"
    Sub New()
        Me.Size = New Point(26, 20)
        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub
    Private _StateMinimize As Boolean = False
    Public Property StateMinimize() As Boolean
        Get
            Return _StateMinimize
        End Get
        Set(ByVal v As Boolean)
            _StateMinimize = v
            Invalidate()
        End Set
    End Property

    Private _StateClose As Boolean = False
    Public Property StateClose() As Boolean
        Get
            Return _StateClose
        End Get
        Set(ByVal v As Boolean)
            _StateClose = v
            Invalidate()
        End Set
    End Property

    Private _StateMaximize As Boolean = False
    Public Property StateMaximize() As Boolean
        Get
            Return _StateMaximize
        End Get
        Set(ByVal v As Boolean)
            _StateMaximize = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Me.Size = New Point(26, 20)
    End Sub
    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseClick(e)
        If _StateMinimize = True Then
            FindForm.WindowState = FormWindowState.Minimized ' true
            ' Else
            _StateClose = False ' false
            _StateMaximize = False
        End If
        If _StateClose = True Then
            FindForm.Close()
            'Else
            _StateMinimize = False
            _StateMaximize = False
        End If
        If _StateMaximize = True Then
            If FindForm.WindowState <> FormWindowState.Maximized Then FindForm.WindowState = FormWindowState.Maximized Else FindForm.WindowState = FormWindowState.Normal

            _StateClose = False ' false
            _StateMinimize = False
        End If
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub
#End Region
#Region "Color Of Control"
    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(22, 22, 22))
        G.SmoothingMode = SmoothingMode.HighQuality

        Dim Header As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(22, 22, 22), Color.FromArgb(35, 35, 35), 270S)
        G.FillRectangle(Header, New Rectangle(0, 0, Width - 1, Height - 1))

        Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
        G.FillRectangle(HeaderHatch, New Rectangle(0, 0, Width - 1, Height - 1))

        G.FillRectangle(New SolidBrush(Color.FromArgb(8, Color.White)), 0, 0, Width - 1, 10)
        G.DrawLine(New Pen(Color.FromArgb(33, 33, 33)), 0, 9, Width - 1, 10) ' Cuz it has a bug dont worry i will fix it =)

        Select Case State
            Case MouseState.Over
                Dim Header1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(40, 40, 40), 270S)
                G.FillRectangle(Header1, New Rectangle(0, 0, Width - 1, Height - 1))
                Dim HeaderHatch1 As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
                G.FillRectangle(HeaderHatch1, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(New SolidBrush(Color.FromArgb(10, Color.White)), 0, 0, Width - 1, 10)
                G.DrawLine(New Pen(Color.FromArgb(38, 38, 38)), 0, 9, Width - 1, 10) ' Cuz it has a bug dont worry i will fix it =)
            Case MouseState.Down
                Dim Header1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(35, 35, 35), 270S)
                G.FillRectangle(Header1, New Rectangle(0, 0, Width - 1, Height - 1))
                Dim HeaderHatch1 As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
                G.FillRectangle(HeaderHatch1, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(New SolidBrush(Color.FromArgb(8, Color.White)), 0, 0, Width - 1, 10)
                G.DrawLine(New Pen(Color.FromArgb(35, 35, 35)), 0, 9, Width - 1, 10) ' Cuz it has a bug dont worry i will fix it =)

        End Select
        'Draw Text


        If _StateMinimize = True Then
            G.DrawString("0", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(6, 4))
            _StateClose = False ' false
            _StateMaximize = False
        End If
        If _StateClose = True Then
            G.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(6, 4))
            _StateMinimize = False
            _StateMaximize = False
        End If

        If _StateMaximize = True Then
            If FindForm.WindowState <> FormWindowState.Maximized Then G.DrawString("1", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(6, 4)) Else G.DrawString("2", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(6, 4))
            _StateClose = False ' false
            _StateMinimize = False
        End If


        'Draw Gloss
        'Draw Border
        DrawBorders(Pens.Black)
        ' DrawBorders(New Pen(Color.FromArgb(32, 32, 32)))
    End Sub
#End Region
End Class
Class CarbonFiberSeparatorVertical
    Inherits ThemeControl154
#Region "Properties"
    Sub New()
        LockWidth = 10
    End Sub
    Protected Overrides Sub ColorHook()


    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(22, 22, 22))

        G.FillRectangle(New SolidBrush(Color.FromArgb(6, 6, 6)), New Rectangle(4, 0, 1, Height - 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(32, 32, 32)), New Rectangle(5, 0, 1, Height - 1))
    End Sub
#End Region
End Class
Class CarbonFiberSeparatorHorizontal
    Inherits ThemeControl154
#Region "Properties"
    Sub New()
        LockHeight = 10
    End Sub
    Protected Overrides Sub ColorHook()


    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(22, 22, 22))
        G.DrawLine(New Pen(Color.FromArgb(6, 6, 6)), 0, 4, Width - 1, 4)
        G.DrawLine(New Pen(Color.FromArgb(32, 32, 32)), 0, 5, Width - 1, 5)
    End Sub
#End Region
End Class
'------------------
'ProgressBar Component By: Aeonhack
'TextBox Component By: Mavamaarten
'------------------
'Credits by Aeonhack and Mavamaarten
<DefaultEvent("TextChanged")> _
Class CarbonFiberTextBox
    Inherits ThemeControl154
#Region "Properties"
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If Base IsNot Nothing Then
                Base.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If Base IsNot Nothing Then
                Base.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If Base IsNot Nothing Then
                Base.ReadOnly = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If Base IsNot Nothing Then
                Base.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If Base IsNot Nothing Then
                Base.Multiline = value

                If value Then
                    LockHeight = 0
                    Base.Height = Height - 11
                Else
                    LockHeight = Base.Height + 11
                End If
            End If
        End Set
    End Property
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If Base IsNot Nothing Then
                Base.Text = value
            End If
        End Set
    End Property
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If Base IsNot Nothing Then
                Base.Font = value
                Base.Location = New Point(3, 5)
                Base.Width = Width - 6

                If Not _Multiline Then
                    LockHeight = Base.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreation()
        If Not Controls.Contains(Base) Then
            Controls.Add(Base)
        End If
    End Sub

    Private Base As TextBox
    Sub New()
        Base = New TextBox

        Base.Font = Font
        Base.Text = Text
        Base.MaxLength = _MaxLength
        Base.Multiline = _Multiline
        Base.ReadOnly = _ReadOnly
        Base.UseSystemPasswordChar = _UseSystemPasswordChar

        Base.BorderStyle = BorderStyle.None

        Base.Location = New Point(5, 5)
        Base.Width = Width - 10

        Base.BackColor = Color.FromArgb(22, 22, 22)
        Base.ForeColor = Color.FromArgb(255, 150, 0)
        If _Multiline Then
            Base.Height = Height - 11
        Else
            LockHeight = Base.Height + 11
        End If

        AddHandler Base.TextChanged, AddressOf OnBaseTextChanged
        AddHandler Base.KeyDown, AddressOf OnBaseKeyDown
    End Sub

#End Region
#Region "Color of Control"
    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(22, 22, 22))

        DrawBorders(New Pen(Color.FromArgb(6, 6, 6)))
        DrawBorders(New Pen(Color.FromArgb(32, 32, 32)), 1)

    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = Base.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            Base.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Base.Location = New Point(5, 5)
        Base.Width = Width - 10

        If _Multiline Then
            Base.Height = Height - 11
        End If


        MyBase.OnResize(e)
    End Sub
#End Region
End Class
Class CarbonFiberProgressBar
    Inherits Control
#Region " Properties "
    Sub New()
        Size = New Point(419, 27)
    End Sub
    Private _Maximum As Double
    Public Property Maximum() As Double
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Double)
            _Maximum = v
            Progress = _Current / v * 100
            Invalidate()
        End Set
    End Property


    Private _Current As Double
    Public Property Current() As Double
        Get
            Return _Current
        End Get
        Set(ByVal v As Double)
            _Current = v
            Progress = v / _Maximum * 100
            Invalidate()
        End Set
    End Property
    Private _Progress As Double
    Public Property Progress() As Double
        Get
            Return _Progress
        End Get
        Set(ByVal v As Double)
            If v < 0 Then v = 0 Else If v > 100 Then v = 100
            _Progress = v
            _Current = v * 0.01 * _Maximum
            Invalidate()
        End Set
    End Property

    Private _ShowPercentage As Boolean = True
    Public Property ShowPercentage() As Boolean
        Get
            Return _ShowPercentage
        End Get
        Set(ByVal v As Boolean)
            _ShowPercentage = v
            Invalidate()
        End Set
    End Property
#End Region
#Region "Color Of Control"
    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Using B As New Bitmap(Width, Height)


            Using G = Graphics.FromImage(B)
                G.Clear(Color.FromArgb(22, 22, 22))
                Dim Glow As New LinearGradientBrush(New Rectangle(3, 3, Width - 7, Height - 7), Color.FromArgb(22, 22, 22), Color.FromArgb(27, 27, 27), -270S)
                G.FillRectangle(Glow, New Rectangle(3, 3, Width - 7, Height - 7))
                G.DrawRectangle(Pens.Black, New Rectangle(3, 3, Width - 7, Height - 7))



                Dim W = CInt(_Progress * 0.01 * Width)

                Dim R As New Rectangle(3, 3, W - 6, Height - 6)

                Dim Header As New LinearGradientBrush(R, Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270S)
                G.FillRectangle(Header, R)
                Dim HeaderHatch As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent)
                G.FillRectangle(HeaderHatch, R)

                If _ShowPercentage Then
                    G.DrawString(Convert.ToString(String.Concat(Progress, "%")), Font, New SolidBrush(Color.FromArgb(6, 6, 6)), New Rectangle(1, 2, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                    G.DrawString(Convert.ToString(String.Concat(Progress, "%")), Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Rectangle(0, 1, Width - 1, Height - 1), New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If

                G.FillRectangle(New SolidBrush(Color.FromArgb(3, Color.White)), R.X, R.Y, R.Width, CInt(R.Height * 0.45))
                G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(4, 4, Width - 9, Height - 9))
                G.DrawRectangle(New Pen(Color.FromArgb(10, 10, 10)), R.X, R.X, R.Width - 1, R.Height - 1)

            End Using
            e.Graphics.DrawImage(B, 0, 0)
        End Using
        MyBase.OnPaint(e)
    End Sub
#End Region
End Class
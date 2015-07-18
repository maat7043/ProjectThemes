' ####### Sugar Theme #######

'Theme name: Sugar Theme
'Creator   : greenviruz
'SKYPE     : greenviruz
'Site:     : www.aeonsofts.com
'Created   : 26/07/2012
'Version   : 1.0
'Thanks to : aeonhack ,Mavamaarten
'If you want a custom theme to be designed contact me at my skype..
'IF YOU ARE USING THIS THEME GIVE CREDITS TO ME
'THIS THEME IS A FREE THEME

'####### Sugar Theme #######

Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Class SugarTheme
    Inherits ThemeContainer154


    Sub New()
        TransparencyKey = Color.Fuchsia
        BackColor = Color.FromArgb(247, 249, 254)
        Font = New Font("Century Gothic", 11)
        SetColor("Border", Color.FromArgb(190, 210, 217))
        SetColor("text", Color.FromArgb(49, 51, 48))

    End Sub
    Dim Border As Color
    Dim TextBrush As Brush



    Protected Overrides Sub ColorHook()
        Border = GetColor("Border")
        TextBrush = GetBrush("text")

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Border)
        Dim HB As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)

        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(6, 36, Width - 13, Height - 43))
        G.FillRectangle(HB, New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawString(FindForm.Text, Font, TextBrush, New Point(35, 10))
        G.DrawIcon(FindForm.Icon, New Rectangle(10, 10, 16, 16))
        DrawCorners(Color.Fuchsia)
    End Sub
End Class

Class SugarButton
    Inherits ThemeControl154
    Dim Buttoncolor As Color
    Dim Textcolor As Brush
    Dim Border As Pen

    Sub New()
        SetColor("Button", Color.FromArgb(220, 232, 235))
        SetColor("Text", Color.FromArgb(49, 51, 48))
        SetColor("Border", Color.White)

    End Sub

    Protected Overrides Sub ColorHook()
        Buttoncolor = GetColor("Button")
        Textcolor = GetBrush("Text")
        Border = GetPen("Border")

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Buttoncolor)


        DrawCorners(BackColor)
        Select Case State
            Case MouseState.None

                Dim HB As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(HB, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(Textcolor, HorizontalAlignment.Center, 0, 0)

            Case MouseState.Over

                Dim HB As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)
                G.FillRectangle(New SolidBrush(Color.FromArgb(236, 241, 242)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(HB, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(Textcolor, HorizontalAlignment.Center, 0, 0)
            Case MouseState.Down

                Dim HB As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)
                G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Black)), New Rectangle(0, 0, Width - 1, Height - 1))
                G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                G.FillRectangle(HB, New Rectangle(0, 0, Width - 1, Height - 1))
                DrawText(Textcolor, HorizontalAlignment.Center, 0, 0)
        End Select
    End Sub
End Class

Class SugarProgressbar
    Inherits ThemeControl154
    Private _Maximum As Integer = 100
    Private _Value As Integer
    Private HOffset As Integer = 0
    Private Progress As Integer
    Protected Overrides Sub ColorHook()

    End Sub

    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal V As Integer)
            If V < 1 Then V = 1
            If V < _Value Then _Value = V
            _Maximum = V
            Invalidate()
        End Set
    End Property
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(ByVal V As Integer)
            If V > _Maximum Then V = Maximum
            _Value = V
            Invalidate()
        End Set
    End Property
    Public Property Animated As Boolean
        Get
            Return IsAnimated
        End Get
        Set(ByVal V As Boolean)
            IsAnimated = V
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnAnimation()
        HOffset -= 1
        If HOffset = 7 Then HOffset = 0
    End Sub

    Protected Overrides Sub PaintHook()
        Dim hatch As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(60, Color.Green))
        G.Clear(Color.FromArgb(0, 236, 241, 242))
        Dim cblend As New ColorBlend(2)
        cblend.Colors(0) = Color.FromArgb(236, 241, 242)
        cblend.Colors(1) = Color.FromArgb(236, 241, 242)
        cblend.Positions(0) = 0
        cblend.Positions(1) = 1
        DrawGradient(cblend, New Rectangle(0, 0, CInt(((Width / _Maximum) * _Value) - 2), Height - 2))
        cblend.Colors(1) = Color.FromArgb(236, 241, 242)
        DrawGradient(cblend, New Rectangle(0, 0, CInt(((Width / _Maximum) * _Value) - 2), Height / 5 * 2))
        G.RenderingOrigin = New Point(HOffset, 0)
        hatch = New HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(40, Color.Green), Color.FromArgb(0, Color.Green))
        G.FillRectangle(hatch, 0, 0, CInt(((Width / _Maximum) * _Value) - 2), Height - 2)
        DrawBorders(Pens.Black)
        DrawBorders(New Pen(Color.FromArgb(236, 241, 242)), 1)
        DrawCorners(Color.Black)
        G.DrawLine(New Pen(Color.FromArgb(200, 236, 241, 242)), CInt(((Width / _Maximum) * _Value) - 2), 1, CInt(((Width / _Maximum) * _Value) - 2), Height - 2)
        G.DrawLine(Pens.Green, CInt(((Width / _Maximum) * _Value) - 2) + 1, 2, CInt(((Width / _Maximum) * _Value) - 2) + 1, Height - 3)
        Progress = CInt(((Width / _Maximum) * _Value))
        Dim cblend2 As New ColorBlend(3)
        cblend2.Colors(0) = Color.FromArgb(0, Color.Gray)
        cblend2.Colors(1) = Color.FromArgb(80, Color.DimGray)
        cblend2.Colors(2) = Color.FromArgb(0, Color.Gray)
        cblend2.Positions = {0, 0.5, 1}
        Dim HB As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)
        G.FillRectangle(New SolidBrush(Color.FromArgb(190, 210, 217)), CInt(((Width / _Maximum) * _Value)) - 1, 2, Width - CInt(((Width / _Maximum) * _Value)) - 1, Height - 4)
        G.FillRectangle(HB, New Rectangle(0, 0, Width - 1, Height - 1))
        If Value > 0 Then G.FillRectangle(New SolidBrush(Color.FromArgb(190, 210, 217)), CInt(((Width / _Maximum) * _Value)) - 1, 2, Width - CInt(((Width / _Maximum) * _Value)) - 1, Height - 4)
    End Sub

    Public Sub New()
        _Maximum = 100
        IsAnimated = True
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class SugarRadiobutton
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
            If C IsNot Me AndAlso TypeOf C Is SugarRadiobutton Then
                DirectCast(C, SugarRadiobutton).Checked = False
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

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Dim textSize As Integer
        textSize = Me.CreateGraphics.MeasureString(Text, Font).Width
        Me.Width = 20 + textSize
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(247, 249, 254))
        Dim asdf As HatchBrush
        asdf = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray))
        G.FillRectangle(New SolidBrush(Color.FromArgb(247, 249, 254)), New Rectangle(0, 0, Width, Height))
        asdf = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray)
        G.FillRectangle(asdf, 0, 0, Width, Height)
        G.FillRectangle(New SolidBrush(Color.FromArgb(247, 249, 254)), 0, 0, Width, Height)

        G.SmoothingMode = SmoothingMode.AntiAlias
        G.FillEllipse(New SolidBrush(Color.FromArgb(220, 232, 235)), 2, 2, 11, 11)
        G.DrawEllipse(Pens.Black, 0, 0, 13, 13)
        G.DrawEllipse(New Pen(Color.FromArgb(220, 232, 235)), 1, 1, 11, 11)

        If _Checked = False Then
            Dim hatch As HatchBrush
            hatch = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(20, Color.White), Color.FromArgb(0, Color.Gray))
            G.FillEllipse(hatch, 2, 2, 10, 10)
        Else
            G.FillEllipse(New SolidBrush(Color.FromArgb(80, 80, 80)), 3, 3, 7, 7)
            Dim hatch As HatchBrush
            hatch = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(60, Color.Black), Color.FromArgb(0, Color.Gray))
            G.FillRectangle(hatch, 3, 3, 7, 7)
        End If

        If State = MouseState.Over And X < 13 Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(20, Color.White)), 2, 2, 11, 11)
        End If

        G.DrawString(Text, Font, Brushes.Black, 16, 0)
    End Sub

    Public Sub New()
        Me.Size = New Point(50, 14)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class SugarCheckbox
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

    Protected Overrides Sub PaintHook()
        G.Clear(Color.FromArgb(239, 254, 213))
        Dim asdf As HatchBrush
        asdf = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray))
        G.FillRectangle(New SolidBrush(Color.FromArgb(247, 249, 254)), New Rectangle(0, 0, Width, Height))
        asdf = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray)
        G.FillRectangle(asdf, 0, 0, Width, Height)
        G.FillRectangle(New SolidBrush(Color.FromArgb(247, 249, 254)), 0, 0, Width, Height)

        G.FillRectangle(New SolidBrush(Color.FromArgb(247, 249, 254)), 3, 3, 10, 10)
        If _Checked Then
            Dim cblend As New ColorBlend(2)
            cblend.Colors(0) = Color.FromArgb(190, 210, 217)
            cblend.Colors(1) = Color.FromArgb(190, 210, 217)
            cblend.Positions(0) = 0
            cblend.Positions(1) = 1
            DrawGradient(cblend, New Rectangle(3, 3, 10, 10))
            cblend.Colors(0) = Color.FromArgb(190, 210, 217)
            cblend.Colors(1) = Color.FromArgb(190, 210, 217)
            DrawGradient(cblend, New Rectangle(3, 3, 10, 4))
            Dim hatch As HatchBrush
            hatch = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(60, Color.Black), Color.FromArgb(0, Color.Gray))
            G.FillRectangle(hatch, 3, 3, 10, 10)
        Else
            Dim hatch As HatchBrush
            hatch = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(20, Color.White), Color.FromArgb(0, Color.Gray))
            G.FillRectangle(hatch, 3, 3, 10, 10)
        End If

        If State = MouseState.Over And X < 15 Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Gray)), New Rectangle(3, 3, 10, 10))
        ElseIf State = MouseState.Down Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), New Rectangle(3, 3, 10, 10))
        End If

        G.DrawRectangle(Pens.Black, 0, 0, 15, 15)
        G.DrawRectangle(New Pen(Color.FromArgb(90, 90, 90)), 1, 1, 13, 13)
        G.DrawString(Text, Font, Brushes.Black, 17, 1)
    End Sub

    Public Sub New()
        Me.Size = New Point(16, 50)
    End Sub
End Class

Class SugarTabControl
    Inherits TabControl
    Private Xstart(9999) As Integer 'Stupid VB.Net bug. Please don't use more than 9999 tabs :3
    Private Xstop(9999) As Integer  'Stupid VB.Net bug. Please don't use more than 9999 tabs :3

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True
        For Each p As TabPage In TabPages
            p.BackColor = Color.FromArgb(247, 249, 254)
            Application.DoEvents()
            p.BackColor = Color.FromArgb(247, 249, 254)
        Next
    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseClick(e)
        Dim index As Integer = 0
        Dim height As Integer = Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8
        For Each a As Integer In Xstart
            If e.X > a And e.X < Xstop(index) And e.Y < height And e.Button = Windows.Forms.MouseButtons.Left Then
                SelectedIndex = index
                Invalidate()
            Else
            End If
            index += 1
        Next
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.Clear(Color.Red)
        Dim asdf As HatchBrush
        asdf = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Red), Color.Pink)
        G.FillRectangle(New SolidBrush(Color.Red), New Rectangle(0, 0, Width, Height))
        asdf = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray)
        G.FillRectangle(asdf, 0, 0, Width, Height)
        G.FillRectangle(New SolidBrush(Color.FromArgb(190, 210, 217)), 0, 0, Width, Height)

        G.FillRectangle(Brushes.PowderBlue, 0, 0, Width, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8)
        G.FillRectangle(New SolidBrush(Color.FromArgb(190, 210, 217)), 2, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 7, Width - 2, Height - 2)

        Dim totallength As Integer = 0
        Dim index As Integer = 0
        For Each tab As TabPage In TabPages
            If SelectedIndex = index Then
                G.FillRectangle(New SolidBrush(Color.Red), totallength, 1, Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 10)
                asdf = New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Red), Color.FromArgb(0, Color.Blue))
                G.FillRectangle(New SolidBrush(Color.FromArgb(199, 211, 229)), totallength, 1, Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 10)
                asdf = New HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Blue)
                G.FillRectangle(asdf, totallength, 1, Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 10)
                G.FillRectangle(New SolidBrush(Color.FromArgb(190, 210, 217)), totallength, 1, Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 10)

                Dim gradient As New LinearGradientBrush(New Point(totallength, 1), New Point(totallength, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8), Color.FromArgb(15, Color.Black), Color.Transparent)
                G.FillRectangle(gradient, totallength, 1, Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 5)

                G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), totallength, 2, totallength, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8)

                G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), totallength + Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8, Width - 1, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8)
                G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), 1, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8, totallength, Me.CreateGraphics.MeasureString("Sasi is awesome", Font).Height + 8)

            End If
            Xstart(index) = totallength
            Xstop(index) = totallength + Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15
            G.DrawString(tab.Text, Font, Brushes.Black, totallength + 8, 5)
            totallength += Me.CreateGraphics.MeasureString(tab.Text, Font).Width + 15
            index += 1
        Next

        G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), 1, 1, Width - 2, 1) 'boven
        G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), 1, Height - 2, Width - 2, Height - 2) 'onder
        G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), 1, 1, 1, Height - 2) 'links
        G.DrawLine(New Pen(Color.FromArgb(190, 210, 217)), Width - 2, 1, Width - 2, Height - 2) 'rechts

        G.DrawLine(Pens.Transparent, 0, 0, Width - 1, 0) 'boven
        G.DrawLine(Pens.Transparent, 0, Height - 1, Width, Height - 1) 'onder
        G.DrawLine(Pens.Transparent, 0, 0, 0, Height - 1) 'links
        G.DrawLine(Pens.Transparent, Width - 1, 0, Width - 1, Height - 1) 'rechts

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
        MyBase.OnSelectedIndexChanged(e)
        Invalidate()
    End Sub
End Class

<DefaultEvent("TextChanged")> _
Class SugarTextBox
    Inherits ThemeControl154

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

        If _Multiline Then
            Base.Height = Height - 11
        Else
            LockHeight = Base.Height + 11
        End If

        AddHandler Base.TextChanged, AddressOf OnBaseTextChanged
        AddHandler Base.KeyDown, AddressOf OnBaseKeyDown


        SetColor("Text", Color.Black)
        SetColor("Back", Color.FromArgb(220, 232, 235))
        SetColor("Border1", Color.White)
        SetColor("Border2", Color.White)
    End Sub

    Private C1 As Color
    Private P1, P2 As Pen

    Protected Overrides Sub ColorHook()
        C1 = GetColor("Back")

        P1 = GetPen("Border1")
        P2 = GetPen("Border2")

        Base.ForeColor = GetColor("Text")
        Base.BackColor = C1
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(C1)

        DrawBorders(P1, 1)
        DrawBorders(P2)
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

End Class
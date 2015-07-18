Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

#Region "Positron Theme"

'-------------------------------------
'------PLEASE LEAVE CREDITS HERE------
'-------------------------------------
'Creator: PatPositron HFUID=1448959
'Site: patpositron.com
'Created: 4/28/13
'Changed: 6/12/13
'Version: 1.8
'-------------------------------------
'------PLEASE LEAVE CREDITS HERE------
'-------------------------------------

Class PositronTheme
    Inherits ThemeContainer154
    Private BG As Color, GT As Color, GB As Color
    Private TB As Brush, Black As Brush, H As Brush
    Private bb As Pen, IB As Pen, PB As Pen

    Public Sub New()
        TransparencyKey = Color.Fuchsia
        BackColor = Color.FromArgb(225, 225, 225)
        Font = New Font("Verdana", 8)
        SetColor("BG", Color.FromArgb(208, 208, 208))
        SetColor("TB", Color.FromArgb(100, 100, 100))
        SetColor("Black", Color.Black)
        SetColor("Hover", Color.FromArgb(210, 210, 210))
        SetColor("Top", Color.FromArgb(220, 220, 220))
        SetColor("Bot", Color.FromArgb(200, 200, 200))
        SetColor("Border", Color.FromArgb(150, 150, 150))
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub ColorHook()
        BG = GetColor("BG")
        TB = GetBrush("TB")
        Black = GetBrush("Black")
        bb = GetPen("Bot")
        GT = GetColor("Top")
        GB = GetColor("Bot")
        H = GetBrush("Hover")
        PB = GetPen("Border")
        IB = GetPen("Bot")
    End Sub
    Protected Overrides Sub PaintHook()
        Dim HBM As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)
        G.Clear(BG)
        G.FillRectangle(HBM, New Rectangle(0, 0, Width - 1, Height - 1))
        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(8, 27, Width - 16, Height - 35))
        G.DrawString(Text, Font, TB, New Point(29, 7))
        G.DrawIcon(ParentForm.Icon, New Rectangle(7, 4, 19, 20))
        DrawBorders(PB)
        DrawBorders(IB, 1)

    End Sub
End Class

Class PositronButton
    Inherits ThemeControl154
    Private TG As Color, BG As Color
    Private TC As Brush, H As Brush
    Private BB As Pen, IB As Pen
    Public Sub New()
        SetColor("TopG", Color.FromArgb(220, 220, 220))
        SetColor("BottomG", Color.FromArgb(200, 200, 200))
        SetColor("Text", Color.FromArgb(100, 100, 100))
        SetColor("Border", Color.FromArgb(150, 150, 150))
        SetColor("Inside", Color.FromArgb(200, 200, 200))
        SetColor("Hover", Color.FromArgb(210, 210, 210))
        Size = New Size(100, 30)
    End Sub
    Protected Overrides Sub ColorHook()
        TG = GetColor("TopG")
        BG = GetColor("BottomG")
        TC = GetBrush("Text")
        BB = GetPen("Border")
        IB = GetPen("Inside")
        H = GetBrush("Hover")
    End Sub
    Protected Overrides Sub PaintHook()
        G.Clear(TG)
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), TG, BG, 90.0F)
                G.FillRectangle(LGB1, New Rectangle(2, 2, Width - 4, Height - 4))
                Exit Select
            Case MouseState.Over
                G.FillRectangle(H, New Rectangle(2, 2, Width - 4, Height - 4))
                Exit Select
            Case MouseState.Down
                Dim LGB3 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), BG, TG, 90.0F)
                G.FillRectangle(LGB3, New Rectangle(2, 2, Width - 4, Height - 4))
                Exit Select
        End Select
        DrawBorders(IB)
        DrawText(TC, HorizontalAlignment.Center, 0, 0)
        G.DrawRectangle(BB, New Rectangle(1, 1, Width - 3, Height - 3))
    End Sub
End Class

Class PositronGroupBox
    Inherits ThemeContainer154
    Private PB As Pen, IB As Pen
    Private BT As Brush
    Private BG As Color
    Public Sub New()
        ControlMode = True
        SetColor("Border", Color.FromArgb(150, 150, 150))
        SetColor("Text", Color.FromArgb(100, 100, 100))
        SetColor("BG", Color.FromArgb(208, 208, 208))
        SetColor("Inside", Color.FromArgb(200, 200, 200))
        Size = New Size(160, 80)
    End Sub
    Protected Overrides Sub ColorHook()
        PB = GetPen("Border")
        BT = GetBrush("Text")
        BG = GetColor("BG")
        IB = GetPen("Inside")
    End Sub
    Protected Overrides Sub PaintHook()
        Dim HBM As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent)
        G.Clear(BG)
        G.FillRectangle(HBM, New Rectangle(0, 0, Width - 1, Height - 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(220, 220, 220)), New Rectangle(5, 20, Width - 10, Height - 25))
        DrawBorders(IB)
        DrawBorders(PB, 1)
        G.DrawString(Text, Font, BT, New Point(6, 3))
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class PositronRadioButton
    Inherits ThemeControl154
    Private TB As Brush, Inside As Brush
    Private BB As Pen, IB As Pen

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Public Event CheckedChanged As CheckedChangedEventHandler
    Public Delegate Sub CheckedChangedEventHandler(sender As Object)

    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then
            Return
        End If

        For Each C As Control In Parent.Controls
            If Not Object.ReferenceEquals(C, Me) AndAlso TypeOf C Is PositronRadioButton Then
                DirectCast(C, PositronRadioButton).Checked = False
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
        If Not _Checked Then
            Checked = True
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Public Sub New()
        LockHeight = 22
        Width = 140
        Size = New Size(150, 22)
        SetColor("Text", Color.FromArgb(100, 100, 100))
        SetColor("Border", Color.FromArgb(175, 175, 175))
        SetColor("IB", Color.FromArgb(200, 200, 200))
        SetColor("B", Color.FromArgb(150, 150, 150))
    End Sub

    Protected Overrides Sub ColorHook()
        TB = GetBrush("Text")
        BB = GetPen("B")
        IB = GetPen("IB")
        Inside = GetBrush("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias
        If _Checked Then
            G.FillEllipse(TB, New Rectangle(New Point(6, 6), New Size(6, 6)))
        End If
        If State = MouseState.Over Then
            If _Checked Then
            Else
                G.FillEllipse(Inside, New Rectangle(New Point(5, 5), New Size(8, 8)))
            End If
        End If

        G.DrawEllipse(New Pen(Color.FromArgb(125, 125, 125)), New Rectangle(New Point(1, 1), New Size(16, 16)))
        G.DrawEllipse(New Pen(Color.FromArgb(200, 200, 200)), New Rectangle(New Point(0, 0), New Size(18, 18)))

        G.DrawString(Text, Font, TB, 19, 2)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class PositronCheckBox
    Inherits ThemeControl154
    Private BG As Color
    Private TB As Brush, [IN] As Brush
    Private IB As Pen, BB As Pen

    Private _Checked As Boolean
    Public Event CheckedChanged As CheckedChangedEventHandler
    Public Delegate Sub CheckedChangedEventHandler(sender As Object)

    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            Invalidate()
            RaiseEvent CheckedChanged(Me)
        End Set
    End Property

    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If _Checked = True Then
            _Checked = False
        Else
            _Checked = True
        End If
    End Sub

    Public Sub New()
        LockHeight = 22
        SetColor("BG", Color.FromArgb(240, 240, 240))
        SetColor("Texts", Color.FromArgb(100, 100, 100))
        SetColor("Inside", Color.FromArgb(175, 175, 175))
        SetColor("IB", Color.FromArgb(200, 200, 200))
        SetColor("B", Color.FromArgb(150, 150, 150))
        Size = New Size(150, 22)
    End Sub

    Protected Overrides Sub ColorHook()
        BG = GetColor("BG")
        TB = GetBrush("Texts")
        [IN] = GetBrush("Inside")
        IB = GetPen("IB")
        BB = GetPen("B")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        If _Checked Then
            G.DrawString("a", New Font("Marlett", 12), TB, New Point(-1, 1))
        End If

        If State = MouseState.Over Then
            G.FillRectangle([IN], New Rectangle(New Point(4, 4), New Size(10, 10)))
            If _Checked Then
                G.DrawString("a", New Font("Marlett", 12), TB, New Point(-1, 1))
            End If
        End If

        G.DrawRectangle(BB, 2, 2, 14, 14)
        G.DrawRectangle(IB, 1, 1, 16, 16)
        G.DrawString(Text, Font, TB, 19, 3)
    End Sub
End Class

<DefaultEvent("CheckedChanged")> _
Class PositronOnOff
    Inherits ThemeControl154
    Private TB As Brush
    Private bb As Pen

    Private _Checked As Boolean = False
    Public Event CheckedChanged As CheckedChangedEventHandler
    Public Delegate Sub CheckedChangedEventHandler(sender As Object)

    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            Invalidate()
            RaiseEvent CheckedChanged(Me)
        End Set
    End Property
    Protected Sub pDrawBorders(p1 As Pen, G As Graphics)
        pDrawBorders(p1, 0, 0, Width, Height, G)
    End Sub
    Protected Sub pDrawBorders(p1 As Pen, offset As Integer, G As Graphics)
        pDrawBorders(p1, 0, 0, Width, Height, offset, _
            G)
    End Sub
    Protected Sub pDrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, G As Graphics)
        G.DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub
    Protected Sub pDrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, offset As Integer, _
        G As Graphics)
        pDrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G)
    End Sub
    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If _Checked = True Then
            _Checked = False
        Else
            _Checked = True
        End If
    End Sub

    Public Sub New()
        LockHeight = 24
        LockWidth = 62
        SetColor("Texts", Color.FromArgb(100, 100, 100))
        SetColor("border", Color.FromArgb(125, 125, 125))
    End Sub

    Protected Overrides Sub ColorHook()
        TB = GetBrush("Texts")
        bb = GetPen("border")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90)
        Dim HB1 As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent)

        If _Checked Then
            G.FillRectangle(LGB1, New Rectangle(2, 2, (Width / 2) - 2, Height - 4))
            G.FillRectangle(HB1, New Rectangle(2, 2, (Width / 2) - 2, Height - 4))
            G.DrawString("On", Font, TB, New Point(36, 6))
        ElseIf Not _Checked Then
            G.FillRectangle(LGB1, New Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4))
            G.FillRectangle(HB1, New Rectangle((Width / 2) - 1, 2, (Width / 2) - 1, Height - 4))
            G.DrawString("Off", Font, TB, New Point(5, 6))
        End If
        pDrawBorders(New Pen(New SolidBrush(Color.FromArgb(200, 200, 200))), G)
        pDrawBorders(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), 1, G)

    End Sub
End Class

Class PositronLabel
    Inherits Label
    Public Sub New()
        ForeColor = Color.FromArgb(100, 100, 100)
        BackColor = Color.Transparent
        Font = New Font("Verdana", 8)
    End Sub
End Class

Class PositronControlBox
    Inherits ThemeControl154
    Private TG As Color, BG As Color
    Private TC As Brush, H As Brush
    Private BB As Pen, IB As Pen

    Public Sub New()
        SetColor("TopG", Color.FromArgb(220, 220, 220))
        SetColor("BottomG", Color.FromArgb(200, 200, 200))
        SetColor("Text", Color.FromArgb(100, 100, 100))
        SetColor("Border", Color.FromArgb(150, 150, 150))
        SetColor("Inside", Color.FromArgb(200, 200, 200))
        SetColor("Hover", Color.FromArgb(210, 210, 210))
        LockHeight = 22
        LockWidth = 22
    End Sub
    Protected Overrides Sub ColorHook()
        TG = GetColor("TopG")
        BG = GetColor("BottomG")
        TC = GetBrush("Text")
        BB = GetPen("Border")
        IB = GetPen("Inside")
        H = GetBrush("Hover")
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Application.[Exit]()
            Environment.[Exit](0)
        End If
    End Sub

    Protected Overrides Sub OnClientSizeChanged(e As EventArgs)
        MyBase.OnClientSizeChanged(e)
    End Sub

    Protected Overrides Sub PaintHook()
        Select Case State
            Case MouseState.None
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), TG, BG, 90.0F)
                G.FillRectangle(LGB1, New Rectangle(0, 0, 22, 22))
                Exit Select
            Case MouseState.Over
                G.FillRectangle(H, New Rectangle(0, 0, 22, 22))
                Exit Select
            Case MouseState.Down
                Dim LGB3 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), BG, TG, 90.0F)
                G.FillRectangle(LGB3, New Rectangle(0, 0, 22, 22))
                Exit Select
        End Select
        DrawBorders(IB)
        G.DrawString("r", New Font("Marlett", 8), TC, 4, 6)
    End Sub
End Class

<DefaultEvent("TextChanged")> _
Class PositronTextBox
    Inherits ThemeControl154

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Public Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(value As HorizontalAlignment)
            _TextAlign = value
            If Base IsNot Nothing Then
                Base.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    Public Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(value As Integer)
            _MaxLength = value
            If Base IsNot Nothing Then
                Base.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    Public Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(value As Boolean)
            _ReadOnly = value
            If Base IsNot Nothing Then
                Base.[ReadOnly] = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    Public Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(value As Boolean)
            _UseSystemPasswordChar = value
            If Base IsNot Nothing Then
                Base.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    Public Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(value As Boolean)
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
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            If Base IsNot Nothing Then
                Base.Text = value
            End If
        End Set
    End Property
    Public Overrides Property Font() As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            If Base IsNot Nothing Then
                Base.Font = value
                Base.Location = New Point(10, 6)
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
    Public Sub New()
        Base = New TextBox()

        Base.Font = New Font("Verdana", 8)
        Base.Text = Text
        Base.MaxLength = _MaxLength
        Base.Multiline = _Multiline
        Base.[ReadOnly] = _ReadOnly
        Base.UseSystemPasswordChar = _UseSystemPasswordChar
        Base.Size = New Size(100, 25)
        Size = New Size(112, 25)
        Base.BorderStyle = BorderStyle.None

        Base.Location = New Point(10, 6)
        Base.Width = Width - 10

        If _Multiline Then
            Base.Height = Height - 11
        Else
            LockHeight = Base.Height + 11
        End If

        AddHandler Base.TextChanged, AddressOf OnBaseTextChanged
        AddHandler Base.KeyDown, AddressOf OnBaseKeyDown


        SetColor("B", Color.FromArgb(210, 210, 210))
        SetColor("Inside", Color.FromArgb(200, 200, 200))
        SetColor("Border", Color.FromArgb(150, 150, 150))
    End Sub

    Private bs As Color, i As Color, bb As Color

    Protected Overrides Sub ColorHook()
        Base.ForeColor = Color.FromArgb(100, 100, 100)
        Base.BackColor = Color.FromArgb(210, 210, 210)
        bs = GetColor("B")
        i = GetColor("Inside")
        bb = GetColor("Border")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(bs)
        Base.Size = New Size(Width - 10, Height - 10)
        G.FillRectangle(New SolidBrush(bs), New Rectangle(1, 1, Width - 2, Height - 2))
        DrawBorders(New Pen(New SolidBrush(bb)), 1)
        DrawBorders(New Pen(New SolidBrush(i)))
    End Sub
    Private Sub OnBaseTextChanged(s As Object, e As EventArgs)
        Text = Base.Text
    End Sub
    Private Sub OnBaseKeyDown(s As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            Base.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        Base.Location = New Point(5, 5)
        Base.Width = Width - 10

        If _Multiline Then
            Base.Height = Height - 11
        End If
        MyBase.OnResize(e)
    End Sub

End Class

Class PositronProgressBar
    Inherits ThemeControl154
    Private _Value As Integer
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(value As Integer)
            If value >= Minimum And value <= _Max Then
                _Value = value
            End If
            Invalidate()
        End Set
    End Property

    Private _Orientation As Orientation
    Public Property Orientation() As Orientation
        Get
            Return _Orientation
        End Get
        Set(value As Orientation)
            _Orientation = value
            Invalidate()
        End Set
    End Property


    Private _Max As Integer = 100
    Public Property Maximum() As Integer
        Get
            Return _Max
        End Get
        Set(value As Integer)
            If value > _Min Then
                _Max = value
            End If
            Invalidate()
        End Set
    End Property

    Private _Min As Integer = 0
    Public Property Minimum() As Integer
        Get
            Return _Min
        End Get
        Set(value As Integer)
            If value < _Max Then
                _Min = value
            End If
            Invalidate()
        End Set
    End Property

    Private Sub Increment(amount As Integer)
        Value += amount
    End Sub

    Private _ShowValue As Boolean = False
    <Description("Indicates if the value of the progress bar will be shown in the middle of it.")> _
    Public Property ShowValue() As Boolean
        Get
            Return _ShowValue
        End Get
        Set(value As Boolean)
            _ShowValue = value
            Invalidate()
        End Set
    End Property

    Private BT As Brush
    Private IB As Pen, PB As Pen
    Private BG As Color, IC As Color

    Public Sub New()
        Transparent = True
        Value = 50
        ShowValue = True
        SetColor("Text", Color.FromArgb(100, 100, 100))
        SetColor("Inside", Color.FromArgb(200, 200, 200))
        SetColor("Border", Color.FromArgb(150, 150, 150))
        SetColor("BG", Color.FromArgb(210, 210, 210))
        SetColor("IC", Color.FromArgb(215, 215, 215))
        MinimumSize = New Size(40, 14)
        Size = New Size(175, 30)
    End Sub

    Protected Overrides Sub ColorHook()
        BT = GetBrush("Text")
        IB = GetPen("Inside")
        PB = GetPen("Border")
        BG = GetColor("BG")
        IC = GetColor("IC")
    End Sub

    Protected Overrides Sub PaintHook()
        Select Case _Orientation
            Case System.Windows.Forms.Orientation.Horizontal

                Dim area As Integer = Convert.ToInt32((_Value * (Width - 6)) \ _Max)
                G.Clear(BG)
                Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90.0F)

                If _Value = _Max Then
                    G.FillRectangle(LGB1, New Rectangle(3, 3, Width - 4, Height - 4))
                    DrawBorders(PB, 3)
                ElseIf _Value = _Min Then
                Else
                    G.FillRectangle(LGB1, New Rectangle(3, 3, area, Height - 4))
                    G.DrawRectangle(PB, New Rectangle(3, 3, area - 1, Height - 7))
                End If
                If _ShowValue Then
                    Dim val As String = _Value.ToString()
                    DrawText(BT, val, HorizontalAlignment.Center, 0, 0)
                End If

                Exit Select

            Case System.Windows.Forms.Orientation.Vertical

                Dim area2 As Integer = Convert.ToInt32((_Value * (Height - 6)) \ _Max)

                G.Clear(BG)
                Dim LGB2 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90.0F)

                If _Value = _Max Then
                    G.FillRectangle(LGB2, New Rectangle(3, 3, Width - 4, Height - 4))
                    DrawBorders(PB, 3)
                ElseIf _Value = _Min Then
                Else
                    G.FillRectangle(LGB2, New Rectangle(3, 3, Width - 4, area2))
                    G.DrawRectangle(PB, New Rectangle(3, 3, Width - 7, area2))
                End If
                If _ShowValue Then
                    Dim val As String = _Value.ToString()
                    DrawText(BT, val, HorizontalAlignment.Center, 0, 0)
                End If


                Exit Select
        End Select

        DrawBorders(IB)
        DrawBorders(PB, 1)
    End Sub
End Class

Class PositronListBox
    Inherits ListBox
    Private mShowScroll As Boolean
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If Not mShowScroll Then
                cp.Style = cp.Style And Not &H200000
            End If
            Return cp
        End Get
    End Property
    <Description("Indicates whether the vertical scrollbar appears or not.")> _
    Public Property ShowScrollbar() As Boolean
        Get
            Return mShowScroll
        End Get
        Set(value As Boolean)
            If value = mShowScroll Then
                Return
            End If
            mShowScroll = value
            If Handle <> IntPtr.Zero Then
                RecreateHandle()
            End If
        End Set
    End Property

    Public Sub New()
        SetStyle(ControlStyles.DoubleBuffer, True)
        BorderStyle = System.Windows.Forms.BorderStyle.None
        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        ItemHeight = 16
        ForeColor = Color.Black
        BackColor = Color.FromArgb(210, 210, 210)
        IntegralHeight = False
        Font = New Font("Verdana", 8)
        ScrollAlwaysVisible = False
    End Sub
    Protected Sub DrawBorders(p1 As Pen)
        DrawBorders(p1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, offset As Integer)
        DrawBorders(p1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer)
        CreateGraphics().DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, offset As Integer)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub
    Protected Overrides Sub OnDrawItem(e As System.Windows.Forms.DrawItemEventArgs)
        If (e.Index >= 0) Then
            Dim ItemBounds As Rectangle = e.Bounds
            e.Graphics.FillRectangle(New SolidBrush(BackColor), ItemBounds)

            If ((e.State.ToString().IndexOf("Selected,") + 1) > 0) Then
                Dim LGB1 As New LinearGradientBrush(ItemBounds, Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90)
                Dim HB1 As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent)
                e.Graphics.FillRectangle(LGB1, ItemBounds)
                e.Graphics.FillRectangle(HB1, ItemBounds)
                e.Graphics.DrawString(Items(e.Index).ToString(), Font, New SolidBrush(Color.FromArgb(200, 200, 200)), 5, Convert.ToInt32((e.Bounds.Y + ((e.Bounds.Height \ 2) - 7))))
            Else
                Try
                    e.Graphics.DrawString(Items(e.Index).ToString(), Font, New SolidBrush(Color.FromArgb(100, 100, 100)), 5, Convert.ToInt32((e.Bounds.Y + ((e.Bounds.Height \ 2) - 7))))
                Catch
                End Try
            End If
        End If
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(200, 200, 200))))
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), 1)
        MyBase.OnDrawItem(e)
    End Sub
    Public Sub CustomPaint()
        CreateGraphics().DrawRectangle(New Pen(Color.FromArgb(210, 210, 210)), New Rectangle(0, 0, Width - 1, Height - 1))
    End Sub
End Class

Class PositronDivider
    Inherits ThemeControl154

    Private _Orientation As Orientation

    Public Property Orientation() As Orientation
        Get
            Return _Orientation
        End Get
        Set(value As Orientation)
            _Orientation = value
            If value = System.Windows.Forms.Orientation.Vertical Then
                LockHeight = 0
                LockWidth = 14
            Else
                LockHeight = 14
                LockWidth = 0
            End If
            Invalidate()
        End Set
    End Property

    Public Sub New()
        Transparent = True
        BackColor = Color.Transparent
        LockHeight = 14
    End Sub

    Protected Overrides Sub ColorHook()
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Dim BL1 As New ColorBlend()
        Dim BL2 As New ColorBlend()
        BL1.Positions = New Single() {0.0F, 0.15F, 0.85F, 1.0F}
        BL2.Positions = New Single() {0.0F, 0.15F, 0.5F, 0.85F, 1.0F}
        BL1.Colors = New Color() {Color.Transparent, Color.LightGray, Color.LightGray, Color.Transparent}
        BL2.Colors = New Color() {Color.Transparent, Color.FromArgb(144, 144, 144), Color.FromArgb(160, 160, 160), Color.FromArgb(156, 156, 156), Color.Transparent}
        If _Orientation = System.Windows.Forms.Orientation.Vertical Then
            DrawGradient(BL1, 6, 0, 1, Height)
            DrawGradient(BL2, 7, 0, 1, Height)
        Else
            DrawGradient(BL1, 0, 6, Width, 1, 0.0F)
            DrawGradient(BL2, 0, 7, Width, 1, 0.0F)
        End If
    End Sub
End Class

Class PositronComboBox
    Inherits ComboBox
    Private X As Integer
    Private _StartIndex As Integer = 0
    Public Property StartIndex() As Integer
        Get
            Return _StartIndex
        End Get
        Set(value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Protected Sub DrawBorders(p1 As Pen, G As Graphics)
        DrawBorders(p1, 0, 0, Width, Height, G)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, offset As Integer, G As Graphics)
        DrawBorders(p1, 0, 0, Width, Height, offset, _
            G)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, G As Graphics)
        G.DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, offset As Integer, _
        G As Graphics)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G)
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        X = e.X
        MyBase.OnMouseMove(e)
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        X = 0
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            X = 0
        End If
        MyBase.OnMouseClick(e)
    End Sub

    Private B1 As SolidBrush, B2 As SolidBrush, B3 As SolidBrush

    Public Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed

        BackColor = Color.FromArgb(225, 225, 225)
        DropDownStyle = ComboBoxStyle.DropDownList

        Font = New Font("Verdana", 8)

        B1 = New SolidBrush(Color.FromArgb(230, 230, 230))
        B2 = New SolidBrush(Color.FromArgb(210, 210, 210))
        B3 = New SolidBrush(Color.FromArgb(100, 100, 100))
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        Dim points As Point() = New Point() {New Point(Width - 15, 9), New Point(Width - 6, 9), New Point(Width - 11, 14)}
        G.Clear(BackColor)
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim LGB1 As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90.0F)

        G.FillRectangle(LGB1, New Rectangle(0, 0, Width, Height))

        G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), New Point(Width - 21, 2), New Point(Width - 21, Height))

        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(200, 200, 200))), G)
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), 1, G)

        Try
            G.DrawString(DirectCast(Items(SelectedIndex).ToString(), String), Font, New SolidBrush(Color.FromArgb(100, 100, 100)), New Point(3, 4))
        Catch
            G.DrawString(" . . . ", Font, New SolidBrush(Color.FromArgb(100, 100, 100)), New Point(3, 4))
        End Try

        If X >= 1 Then
            Dim LGB3 As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(200, 200, 200), Color.FromArgb(220, 220, 220), 90.0F)
            G.FillRectangle(LGB3, New Rectangle(Width - 20, 2, 18, 17))
            G.FillPolygon(B3, points)
        Else
            G.FillPolygon(B3, points)
        End If
    End Sub
    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim LGB1 As New LinearGradientBrush(e.Bounds, Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90)
        Dim HB1 As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent)

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(LGB1, New Rectangle(1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
            e.Graphics.FillRectangle(HB1, e.Bounds)
            e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, New SolidBrush(Color.FromArgb(200, 200, 200)), e.Bounds)
        Else
            e.Graphics.FillRectangle(B2, e.Bounds)
            Try
                e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, New SolidBrush(Color.FromArgb(100, 100, 100)), e.Bounds)
            Catch
            End Try
        End If

    End Sub
End Class

Class PositronTabControl
    Inherits TabControl
    Private TB As Brush
    Private i As Integer = 0

    Protected Sub DrawBorders(p1 As Pen, G As Graphics)
        DrawBorders(p1, 0, 0, Width, Height, G)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, offset As Integer, G As Graphics)
        DrawBorders(p1, 0, 0, Width, Height, offset, _
            G)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, G As Graphics)
        G.DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, offset As Integer, _
        G As Graphics)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G)
    End Sub

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        SizeMode = TabSizeMode.Fixed
        DoubleBuffered = True
        ItemSize = New Size(30, 120)
        Size = New Size(250, 150)
        TB = New SolidBrush(Color.FromArgb(100, 100, 100))
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim HBS As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(6, Color.Black), Color.Transparent)
        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(FindForm().BackColor)
        G.FillRectangle(HBS, New Rectangle(0, 0, Width, Height))

        Try
            SelectedTab.BackColor = Color.FromArgb(210, 210, 210)
        Catch
        End Try
        Dim i As Integer
        For i = 0 To TabCount - 1
            Dim TabRect As Rectangle = GetTabRect(i)
            Try
                Dim LGB1 As New LinearGradientBrush(TabRect, Color.FromArgb(190, 190, 190), Color.FromArgb(220, 220, 220), 90.0F)
                Dim LGB2 As New LinearGradientBrush(TabRect, Color.FromArgb(220, 220, 220), Color.FromArgb(190, 190, 190), 90.0F)

                If i = SelectedIndex Then
                    G.FillRectangle(LGB1, TabRect)
                    G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), TB, TabRect, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                Else
                    G.FillRectangle(LGB2, TabRect)
                    G.DrawString(TabPages(i).Text, Font, TB, TabRect, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                End If
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), New Point(TabRect.X, TabRect.Y), New Point(ItemSize.Height + 1, TabRect.Y))
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), New Point(), New Point())
            Catch
            End Try
        Next
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(200, 200, 200))), 1, G)
        DrawBorders(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), 2, G)
        G.DrawLine(New Pen(Color.FromArgb(150, 150, 150)), New Point(ItemSize.Height + 2, Height - (Height - 3)), New Point(ItemSize.Height + 2, Height - 3))

        e.Graphics.DrawImage(B, 0, 0)
        G.Dispose()
        B.Dispose()
        MyBase.OnPaint(e)
    End Sub
End Class

#End Region
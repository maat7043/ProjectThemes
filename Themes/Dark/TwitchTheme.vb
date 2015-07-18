'------------------
'Creator: Tidas
'Created: 06/22/2013
'Changed: 06/22/2013
'Version: 1.0.0
'Credits: 
' • Aeonhack ~ Themebase
' • Mavamaarten ~ Textbox + Tutorials
' • xZ3ROxPROJ3CTx ~ General Help, Control Box, Progress Bar.
'------------------
Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Drawing.Text

#Region " Draw Methods - xZ3ROxPROJ3CTx"
Module twDraw
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    Private Function ImageFromCode(ByRef str$) As Image
        Dim imageBytes As Byte() = Convert.FromBase64String(str)
        Dim ms As New IO.MemoryStream(imageBytes, 0, imageBytes.Length) : ms.Write(imageBytes, 0, imageBytes.Length)
        Dim i As Image = Image.FromStream(ms, True) : Return i
    End Function
    Public Function TiledTextureFromCode(ByVal str As String) As TextureBrush
        Return New TextureBrush(twDraw.ImageFromCode(str), WrapMode.Tile)
    End Function
End Module
#End Region

Class TwitchTheme
    Inherits ThemeContainer154
    Public Property Fill As Boolean

    Sub New()
        TransparencyKey = Color.Fuchsia
        BackColor = Color.Red
        Font = New Font("Segoe UI", 9)
        SetColor("Border", BackColor)
        Fill = True
    End Sub

    Dim Border As Color
    Protected Overrides Sub ColorHook()
        Border = GetColor("Border")
        BackColor = Color.White
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(Border)
        G.FillRectangle(Brushes.White, New Rectangle(0, 0, Width, Height))
        G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 0, Width, 30))
        'G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 30, 10, Height - 30))
        'G.DrawLine(Pens.Black, Width - 11, 30, Width - 10, Height - 30)
        G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(Width - 10, 30, 10, Height - 30))
        'G.DrawLine(Pens.Black, 10, Height - 11, Width - 10, Height - 11)
        G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, Height - 10, Width, 10))
        DrawCorners(Color.Fuchsia)
        G.DrawString(FindForm.Text, Font, Brushes.White, 5, 6)
        If Fill = True Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 0, Width, Height))
            DrawCorners(Color.Fuchsia)
            G.DrawString(FindForm.Text, Font, Brushes.White, 5, 6)
        End If
    End Sub
End Class

Class TwitchCollapseBox
    Inherits ThemeContainer154
    Public Property twIsCollapsable As Boolean
    Dim hgt As Integer
    Sub New()
        ControlMode = True
        SetColor("Border", Color.Red)
        SetColor("Header", Color.Red)
        SetColor("Text", Color.Red)
        Cursor = Cursors.Hand
        AddHandler TwitchCollapseBox.Click, AddressOf BoxClicked
        Size = New Size(245, 188)
        twIsCollapsable = True
    End Sub

    Private Sub BoxClicked(ByVal sender As Object, ByVal e As EventArgs)
        If twIsCollapsable = True Then
            If sender.Height > 25 Then
                hgt = sender.Height
                For Each ctrl As Control In sender.Controls
                    ctrl.Visible = False
                Next
                sender.Height = 25
            Else
                sender.Height = hgt
                For Each ctrl As Control In sender.Controls
                    ctrl.Visible = True
                Next
            End If
        End If
    End Sub

    Dim border As Pen
    Dim headercolor, textcolor As Brush

    Protected Overrides Sub ColorHook()
        border = GetPen("Border")
        headercolor = GetBrush("Header")
        textcolor = GetBrush("Text")
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.DrawRectangle(border, New Rectangle(0, 0, Width - 1, Height - 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 0, Width - 1, Height - 1))
        G.FillRectangle(New SolidBrush(Color.FromArgb(40, 40, 40)), New Rectangle(0, 0, Width, Height))
        G.DrawLine(Pens.Black, 0, 0, Width, 0)
        DrawText(New SolidBrush(Color.FromArgb(87, 87, 87)), HorizontalAlignment.Left, 4, 0)
        G.DrawLine(Pens.Black, 0, Height, Width, Height)
        G.DrawLine(Pens.Black, 0, 24, Width, 24)
        If twIsCollapsable = True Then
            For Each ctrl As Control In Controls
                If ctrl.Visible = False Then
                    G.DrawString("v", Font, New SolidBrush(Color.FromArgb(87, 87, 87)), Width - 20, 6)
                Else
                    G.DrawString("^", Font, New SolidBrush(Color.FromArgb(87, 87, 87)), Width - 20, 8)
                End If
            Next
        End If
    End Sub
End Class

Class TwitchTextBox
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
        Dim sw As New System.Drawing.Size(245, 4)
        Size = sw
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


        SetColor("Text", Color.White)
        SetColor("Back", 0, 0, 0)
        SetColor("Border1", Color.FromArgb(30, 30, 30))
        SetColor("Border2", Color.FromArgb(30, 30, 30))
    End Sub

    Private C1 As Color
    Private P1, P2 As Pen

    Protected Overrides Sub ColorHook()
        C1 = Color.FromArgb(50, 50, 50)

        P1 = GetPen("Border1")
        P2 = GetPen("Border2")

        Base.ForeColor = Color.White
        Base.BackColor = C1
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(C1)
        SetColor("Text", Color.White)
        DrawBorders(P1, 1)
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

Class TwitchButton
    Inherits ThemeControl154
    Public Property twNoRounding As Boolean
    Sub New()
        Cursor = Cursors.Hand
        Size = New Size(105, 31)
        Tag = "purple"
        Transparent = True
        BackColor = Color.Transparent
        Font = New Font("Verdana", 8.0!, FontStyle.Regular)
        twNoRounding = False
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(BackColor)
        Select Case Tag
            Case "purple"
                Select Case State
                    Case MouseState.Down
                        If twNoRounding = True Then
                            DrawGradient(Color.FromArgb(80, 56, 129), Color.FromArgb(58, 37, 103), New Rectangle(0, 0, Width, Height), 90.0F)
                            G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
                            DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
                        Else
                            Dim BackGrad As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(80, 56, 129), Color.FromArgb(58, 37, 103), 90S)
                            G.FillPath(BackGrad, twDraw.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 4))
                            G.DrawPath(Pens.Black, twDraw.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 4))
                            'Really easy to use. Instead of DrawRectangle, use DrawPath. Then instead of a rectangle, use my Draw function.
                            'The curve should be somewhere along the lines of 3-7
                        End If
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
                    Case Else
                        If twNoRounding = True Then
                            DrawGradient(Color.FromArgb(124, 96, 176), Color.FromArgb(87, 59, 139), New Rectangle(0, 0, Width, Height), 90.0F)
                            G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
                            DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
                        Else
                            Dim BackGrad As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(124, 96, 176), Color.FromArgb(87, 59, 139), 90S)
                            G.FillPath(BackGrad, twDraw.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 4))
                            G.DrawPath(Pens.Black, twDraw.RoundRect(New Rectangle(0, 0, Width - 1, Height - 1), 4))
                            DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
                        End If
                End Select
            Case "white"
                Select Case State
                    Case MouseState.None
                        DrawGradient(Color.FromArgb(242, 242, 242), Color.FromArgb(225, 225, 225), New Rectangle(0, 0, Width, Height), 90.0F)
                        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(158, 158, 158))), New Rectangle(0, 0, Width - 1, Height - 1))
                        DrawText(New SolidBrush(Color.FromArgb(124, 124, 124)), HorizontalAlignment.Center, 0, 0)
                    Case MouseState.Down
                        DrawGradient(Color.FromArgb(213, 213, 213), Color.FromArgb(188, 188, 188), New Rectangle(0, 0, Width, Height), 90.0F)
                        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(121, 121, 121))), New Rectangle(0, 0, Width - 1, Height - 1))
                        DrawText(New SolidBrush(Color.FromArgb(124, 124, 124)), HorizontalAlignment.Center, 0, 0)
                    Case MouseState.Over
                        DrawGradient(Color.FromArgb(242, 242, 242), Color.FromArgb(223, 223, 223), New Rectangle(0, 0, Width, Height), 90.0F)
                        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(158, 158, 158))), New Rectangle(0, 0, Width - 1, Height - 1))
                        DrawText(New SolidBrush(Color.FromArgb(124, 124, 124)), HorizontalAlignment.Center, 0, 0)
                End Select
            Case Else
                Select Case State
                    Case MouseState.Down
                        DrawGradient(Color.FromArgb(80, 56, 129), Color.FromArgb(58, 37, 103), New Rectangle(0, 0, Width, Height), 90.0F)
                        G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
                    Case Else
                        DrawGradient(Color.FromArgb(124, 96, 176), Color.FromArgb(87, 59, 139), New Rectangle(0, 0, Width, Height), 90.0F)
                        G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
                End Select
        End Select
    End Sub
End Class

Class TwitchBigButton
    Inherits ThemeControl154
    Public Property twTabPageNumber As Integer
    Public Property twTabPage As TwitchTabControl
    Public Property twDoesTurnPurple As Boolean
    Public Property twStarred As Boolean
#Region "StarBase64"
    Dim StarBase64 As String = "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"
#End Region

    Sub New()
        Cursor = Cursors.Hand
        Dim sw As New System.Drawing.Size(245, 30)
        Size = sw
        AddHandler TwitchBigButton.Click, AddressOf Clicked
        Transparent = True
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        twDoesTurnPurple = False
        twStarred = False
        twTabPageNumber = 1
        Tag = "black"
    End Sub

    Private Sub Clicked(ByVal sender As Object, ByVal e As EventArgs)
        If twDoesTurnPurple = True Then
            For Each C As Control In Parent.Controls
                If C IsNot Me AndAlso TypeOf C Is TwitchBigButton Then
                    Select Case C.Tag
                        Case "purple"
                            DirectCast(C, TwitchBigButton).Tag = "black"
                        Case "purplebottom"
                            DirectCast(C, TwitchBigButton).Tag = "blackbottom"
                    End Select
                    C.Invalidate()
                End If
            Next
            Select Case Tag
                Case "black"
                    Tag = "purple"
                Case "blackbottom"
                    Tag = "purplebottom"
            End Select
        End If
        If Not twTabPageNumber = Nothing Then
            Try
                Methods.SelectTab(twTabPageNumber, twTabPage)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Select Case Tag
            Case "black"
                Select Case State
                    Case MouseState.None
                        G.FillRectangle(New SolidBrush(Color.FromArgb(30, 30, 30)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        G.DrawLine(New Pen(Color.FromArgb(38, 38, 38)), New Point(1, 1), New Point(Width - 2, 1))
                        DrawText(New SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Left, 30, 0)
                    Case MouseState.Over
                        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        G.DrawLine(New Pen(Color.FromArgb(38, 38, 38)), New Point(1, 1), New Point(Width - 2, 1))
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
                    Case MouseState.Down
                        G.FillRectangle(New SolidBrush(Color.FromArgb(25, 25, 25)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
                End Select
                If twStarred = True Then
                    Dim imageBytes As Byte() = Convert.FromBase64String(StarBase64)
                    Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
                    Dim star As Image = Image.FromStream(ms, True)
                    G.DrawImage(star, Width - 20, 0, star.Width, star.Height)
                End If
            Case "purple"
                G.Clear(BackColor)
                G.FillRectangle(New SolidBrush(Color.FromArgb(100, 65, 165)), New Rectangle(0, 0, Width, Height))
                G.DrawLine(Pens.Black, 0, 0, Width, 0)
                DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
            Case "blackbottom"
                Select Case State
                    Case MouseState.None
                        G.FillRectangle(New SolidBrush(Color.FromArgb(30, 30, 30)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1)
                        G.DrawLine(New Pen(Color.FromArgb(38, 38, 38)), New Point(1, 1), New Point(Width - 2, 1))
                        DrawText(New SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Left, 30, 0)
                    Case MouseState.Over
                        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1)
                        G.DrawLine(New Pen(Color.FromArgb(38, 38, 38)), New Point(1, 1), New Point(Width - 2, 1))
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
                    Case MouseState.Down
                        G.FillRectangle(New SolidBrush(Color.FromArgb(25, 25, 25)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1)
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
                End Select
                If twStarred = True Then
                    Dim imageBytes As Byte() = Convert.FromBase64String(StarBase64)
                    Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
                    Dim star As Image = Image.FromStream(ms, True)
                    G.DrawImage(star, Width - 20, 0, star.Width, star.Height)
                End If
            Case "purplebottom"
                G.FillRectangle(New SolidBrush(Color.FromArgb(100, 65, 165)), New Rectangle(0, 0, Width, Height))
                G.DrawLine(Pens.Black, 0, 0, Width, 0)
                G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1)
                DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
            Case Else
                Select Case State
                    Case MouseState.None
                        G.FillRectangle(New SolidBrush(Color.FromArgb(30, 30, 30)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        DrawText(New SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Left, 30, 0)
                    Case MouseState.Over
                        G.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
                    Case MouseState.Down
                        G.FillRectangle(New SolidBrush(Color.FromArgb(25, 25, 25)), New Rectangle(0, 0, Width, Height))
                        G.DrawLine(Pens.Black, 0, 0, Width, 0)
                        DrawText(New SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0)
                End Select
                If twStarred = True Then
                    Dim imageBytes As Byte() = Convert.FromBase64String(StarBase64)
                    Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)
                    Dim star As Image = Image.FromStream(ms, True)
                    G.DrawImage(star, Width - 20, 0, star.Width, star.Height)
                End If
        End Select

        If Not Image Is Nothing Then G.DrawImage(Image, 10, 7, 16, 16)
    End Sub
End Class

Class TwitchGroupBox
    Inherits ThemeContainer154

    Sub New()
        ControlMode = True
        Cursor = Cursors.Default
        Dim sw As New Size(129, 23)
        Size = sw
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.FillRectangle(New SolidBrush(Color.FromArgb(44, 44, 44)), New Rectangle(0, 0, Width, Height))
        G.FillRectangle(New SolidBrush(Color.FromArgb(25, 25, 25)), New Rectangle(0, 0, Width, 26))
        G.DrawLine(Pens.Black, 0, 26, Width, 26)
        G.DrawRectangle(Pens.Black, New Rectangle(0, 0, Width - 1, Height - 1))
        DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0)
    End Sub
End Class

Class TwitchWhiteTextBox
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

    Public Property GhostText As String

    Private Base As TextBox
    Sub New()
        Base = New TextBox
        Dim sw As New System.Drawing.Size(245, 4)
        Size = sw
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


        SetColor("Text", Color.FromArgb(73, 73, 73))
        SetColor("Back", 0, 0, 0)
        SetColor("Border1", Color.FromArgb(100, 65, 165))
        SetColor("Border2", Color.FromArgb(100, 65, 165))
    End Sub

    Private C1 As Color
    Private P1, P2 As Pen

    Protected Overrides Sub ColorHook()
        C1 = Color.White

        P1 = GetPen("Border1")
        P2 = GetPen("Border2")

        Base.ForeColor = Color.FromArgb(73, 73, 73)
        Base.BackColor = C1
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(C1)
        SetColor("Text", Color.FromArgb(73, 73, 73))
        DrawBorders(P1, 1)
        G.DrawString(GhostText, Font, Brushes.Gray, 10, 5)
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

Class TwitchColorSpace
    Inherits ThemeContainer154

    Sub New()
        ControlMode = True
        BackColor = Drawing.Color.White
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.FillRectangle(New SolidBrush(BackColor), New Rectangle(0, 0, Width, Height))
    End Sub
End Class

Class TwitchTrackBar
    Inherits ThemeControl154

    Sub New()
        Width = 100
        Height = 10
        Transparent = True
        BackColor = Color.Transparent
        Cursor = Cursors.Hand
        Size = New Size(125, 30)
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        Select Case State
            Case MouseState.Over
                DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), New Rectangle(0, 10, Width, 10))
                G.DrawRectangle(Pens.Black, New Rectangle(0, 10, Width, 10))
                DrawGradient(Color.FromArgb(245, 245, 245), Color.FromArgb(206, 206, 206), New Rectangle(Width - 7, 6, 7, 17))
                G.DrawRectangle(Pens.Black, New Rectangle(Width - 7, 6, 7, 17))
            Case MouseState.None
                DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), New Rectangle(0, 10, Width, 10))
                G.DrawRectangle(Pens.Black, New Rectangle(0, 10, Width, 10))
                DrawGradient(Color.FromArgb(207, 207, 207), Color.FromArgb(150, 150, 150), New Rectangle(Width - 7, 6, 7, 17))
                G.DrawRectangle(Pens.Black, New Rectangle(Width - 7, 6, 7, 17))
            Case MouseState.Down
                DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), New Rectangle(0, 10, Width, 10))
                G.DrawRectangle(Pens.Black, New Rectangle(0, 10, Width, 10))
                DrawGradient(Color.FromArgb(144, 144, 144), Color.FromArgb(100, 100, 100), New Rectangle(Width - 7, 6, 7, 17))
                G.DrawRectangle(Pens.Black, New Rectangle(Width - 7, 6, 7, 17))
            Case Else
                DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), New Rectangle(0, 10, Width, 10))
                G.DrawRectangle(Pens.Black, New Rectangle(0, 10, Width, 10))
                DrawGradient(Color.FromArgb(207, 207, 207), Color.FromArgb(150, 150, 150), New Rectangle(Width - 7, 6, 7, 17))
                G.DrawRectangle(Pens.Black, New Rectangle(Width - 7, 6, 7, 17))
        End Select

    End Sub
End Class

Class TwitchLabel
    Inherits Label

    Sub New()
        BackColor = Color.Transparent
        ForeColor = Color.FromArgb(153, 153, 153)
    End Sub
End Class

Class TwitchTabControl
    Inherits TabControl
    Public Property Color As Color = Color.FromArgb(40, 40, 40)

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(5, 5)
        For Each Page As TabPage In TabPages
            Page.BackColor = Drawing.Color.FromArgb(40, 40, 40)
        Next
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.Clear(Color)
        If DesignMode = True Then
            For i = 0 To TabCount - 1
                Dim TabRectangle As Rectangle = GetTabRect(i)
                If i = SelectedIndex Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(100, 65, 165)), TabRectangle)
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(30, 30, 30)), TabRectangle)
                End If
            Next
        End If


        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
        MyBase.OnPaint(e)
    End Sub
End Class

Public Class TwitchProgressBar : Inherits Control
    Private _Value As Integer = 0
    Public Property Value() As Integer
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
    Private _Minimum As Integer = 0
    Public Property Minimum() As Integer
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
    Public Property Maximum() As Integer
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
    Public Sub Increment(ByVal amount As Integer)
        Value += amount
    End Sub
    Sub New()
        Size = New Size(309, 10)
        BackColor = Color.FromArgb(51, 51, 51)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.SmoothingMode = SmoothingMode.HighQuality
        Dim Progress As Integer = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width))
        'Progress is going to be your width of a rectangle/path. For example...
        MyBase.OnPaint(e)

        'Now just design to your heart's content.
        G.Clear(BackColor)
        G.FillRectangle(New SolidBrush(Color.FromArgb(185, 155, 235)), New Rectangle(0, 0, Progress - 1, Height - 1))
        e.Graphics.DrawImage(B, New Point(0, 0))
        G.Dispose() : B.Dispose()
    End Sub
End Class

Class TwitchRadiobutton
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
            If C IsNot Me AndAlso TypeOf C Is TwitchRadiobutton Then
                DirectCast(C, TwitchRadiobutton).Checked = False
            End If
        Next
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        Invalidate()
    End Sub

    Dim textcolor As Brush
    Dim circlecolor As Pen

    Protected Overrides Sub ColorHook()
        textcolor = GetBrush("Text")
        circlecolor = GetPen("Circle")
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
    End Sub

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.HighQuality
        If _Checked Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(195, 195, 195)), New Rectangle(0, 0, Width, Height))
            G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), New Rectangle(0, 0, Width - 1, Height - 1))
            DrawText(New SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0)
        Else
            DrawGradient(Color.FromArgb(242, 242, 242), Color.FromArgb(223, 223, 223), New Rectangle(0, 0, Width, Height), 90.0F)
            G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(150, 150, 150))), New Rectangle(0, 0, Width - 1, Height - 1))
            DrawText(New SolidBrush(Color.FromArgb(30, 30, 30)), HorizontalAlignment.Center, 0, 0)
        End If
    End Sub

    Public Sub New()
        SetColor("Text", Color.Black)
        SetColor("Circle", Color.FromArgb(0, 239, 255))
        Me.Size = New Point(147, 29)
        Cursor = Cursors.Hand
    End Sub
End Class

'XZ3ROXPROJ3CTX
Public Class TwitchControlBox : Inherits Control

    Sub New()
        MyBase.New()
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        ForeColor = Color.White
        BackColor = Color.Transparent
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(60, 25)
    End Sub
    Enum ButtonHover
        Minimize
        Maximize
        Close
        None
    End Enum
    Dim ButtonState As ButtonHover = ButtonHover.None
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim X As Integer = e.Location.X
        Dim Y As Integer = e.Location.Y
        If Y > 0 AndAlso Y < (Height - 2) Then
            If X > 0 AndAlso X < 30 Then
                ButtonState = ButtonHover.Minimize
            ElseIf X > 31 AndAlso X < Width Then
                ButtonState = ButtonHover.Close
            Else
                ButtonState = ButtonHover.None
            End If
        Else
            ButtonState = ButtonHover.None
        End If
        Invalidate()
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        MyBase.OnPaint(e)

        G.Clear(BackColor)
        Dim ButtonFont As New Font("Marlett", 10.0F)
        G.DrawString("r", ButtonFont, New SolidBrush(Color.FromArgb(200, 200, 200)), New Point(Width - 16, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        G.DrawString("0", ButtonFont, New SolidBrush(Color.FromArgb(200, 200, 200)), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})

        Select Case ButtonState
            Case ButtonHover.Minimize
                G.DrawString("0", ButtonFont, New SolidBrush(Color.White), New Point(20, 7), New StringFormat With {.Alignment = StringAlignment.Center})
            Case ButtonHover.Close
                G.DrawString("r", ButtonFont, New SolidBrush(Color.White), New Point(Width - 16, 7), New StringFormat With {.Alignment = StringAlignment.Center})
        End Select



        e.Graphics.DrawImage(B, New Point(0, 0))
        G.Dispose() : B.Dispose()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Select Case ButtonState
            Case ButtonHover.Close
                Parent.FindForm().Close()
            Case ButtonHover.Minimize
                Parent.FindForm().WindowState = FormWindowState.Minimized
            Case ButtonHover.Maximize
                Parent.FindForm().WindowState = FormWindowState.Maximized
        End Select
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        ButtonState = ButtonHover.None : Invalidate()
    End Sub
End Class

Class Methods
    Public Shared Sub SelectTab(ByVal Num As Integer, ByVal Control As TwitchTabControl)
        Control.SelectedIndex = Num - 1
    End Sub
End Class
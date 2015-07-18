'IMPORTANT:
'Please leave these comments in place as they help protect intellectual rights and allow
'developers to determine the version of the theme they are using. 
'Name: SLC Theme
'Created: Not defined yet
'Version: 1.0.0.0 beta
'Site: http://sliceproducts.pw/

'Copyright © 2013 Slice Software
'Special Thanks to : Aeonhack http://nimoru.com/

Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

#Region "SLCTheme"
Class SLCTheme
    Inherits ThemeContainer154

    Private P1, P2 As Pen
    Private topc, botc, topc2, botc2 As Color
    Private B1 As SolidBrush




    Sub New()

        TransparencyKey = Color.Fuchsia
        Header = 30
        SetColor("top", Color.FromArgb(21, 18, 37))
        SetColor("bottom", Color.FromArgb(32, 35, 54))
        '(21, 18, 37)
        SetColor("top2", Color.FromArgb(32, 35, 54))
        SetColor("bottom2", Color.FromArgb(21, 18, 37))
        BackColor = Color.FromArgb(0, 57, 72)
        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(60, 60, 60))
        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))

    End Sub

    Protected Overrides Sub ColorHook()
        topc = GetColor("top")
        botc = GetColor("bottom")
        topc2 = GetColor("top2")
        botc2 = GetColor("bottom2")
    End Sub

    Private Function PrepareBorder() As GraphicsPath
        Dim P As New GraphicsPath()

        Dim PS As New List(Of Point)
        PS.Add(New Point(0, 2))
        PS.Add(New Point(2, 0))
        PS.Add(New Point(100, 0))
        PS.Add(New Point(115, 15))
        PS.Add(New Point(Width - 1 - 115, 15))
        PS.Add(New Point(Width - 1 - 100, 0))
        PS.Add(New Point(Width - 2, 0))
        PS.Add(New Point(Width - 1, 3))


        'PS.Add(New Point(Width - 1, Height - 1))

        'bottom
        PS.Add(New Point(Width - 1, Height - 3))
        PS.Add(New Point(Width - 3, Height - 1))
        PS.Add(New Point(Width - 100, Height - 1))
        PS.Add(New Point(Width - 115, Height - 15 - 1))
        PS.Add(New Point(116, Height - 15 - 1))
        PS.Add(New Point(101, Height - 1))
        PS.Add(New Point(2, Height - 1))
        PS.Add(New Point(0, Height - 2))

        P.AddPolygon(PS.ToArray())
        Return P
    End Function

    'Private Function FormInsideSQ()
    '    Dim P As New GraphicsPath()
    '    Dim PS As New List(Of Point)

    '    PS.Add(New Point(6, Height - 310))
    '    PS.Add(New Point(Width - 6, 64))
    '    PS.Add(New Point(Width - 6, Height - 6))
    '    PS.Add(New Point(Width - 100, Height - 6))
    '    PS.Add(New Point(Width - 116, Height - 22))
    '    PS.Add(New Point(Width - 522, Height - 22))
    '    PS.Add(New Point(Width - 538, Height - 6))
    '    PS.Add(New Point(6, Height - 6))
    '    P.AddPolygon(PS.ToArray())
    '    Return p
    'End Function



    Protected Overrides Sub PaintHook()
        TransparencyKey = Color.Fuchsia

        G.Clear(Color.Fuchsia)




        Dim HB As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.FromArgb(38, 138, 201)), Color.FromArgb(80, Color.FromArgb(12, 40, 57)))
        Dim linear As New LinearGradientBrush(New Rectangle(0, 0, Width, Height), Color.FromArgb(108, 137, 184), Color.FromArgb(13, 20, 25), 20.0F)

        G.FillRectangle(linear, New Rectangle(3, 3, Width - 5, Height - 3))

        G.FillRectangle(HB, New Rectangle(3, 3, Width - 5, Height - 3))


        G.DrawLine(Pens.Fuchsia, 1, 0, Width - 1, 0)
        G.DrawLine(Pens.Fuchsia, 1, 1, Width - 1, 1)
        G.DrawLine(New Pen(Color.FromArgb(26, 47, 59)), 1, 2, Width - 1, 2)

        G.DrawLine(Pens.Fuchsia, 1, Height - 1, Width - 1, Height - 1)
        G.DrawLine(Pens.Fuchsia, 1, Height - 2, Width - 1, Height - 2)
        G.DrawLine(New Pen(Color.FromArgb(26, 47, 59)), 1, Height - 2, Width - 4, Height - 2)




        Dim GPF As GraphicsPath = PrepareBorder()


        Dim PB2 As PathGradientBrush
        PB2 = New PathGradientBrush(GPF)
        PB2.CenterColor = Color.FromArgb(250, 250, 250)
        PB2.SurroundColors = {Color.FromArgb(237, 237, 237)}
        PB2.FocusScales = New PointF(0.9F, 0.5F)

        G.SetClip(GPF)

        G.FillPath(PB2, GPF)
        G.DrawPath(New Pen(Color.White, 3), GPF)
        G.ResetClip()

        Dim tmpG As GraphicsPath = PrepareBorder()

        G.DrawPath(Pens.Gray, tmpG)



        Dim linear2 As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(13, 59, 85), Color.FromArgb(22, 35, 43), 180.0F)



        Dim barGP As New GraphicsPath

        Dim PB3 As PathGradientBrush
        PB3 = New PathGradientBrush(GPF)
        PB3.CenterColor = Color.FromArgb(39, 60, 73)
        PB3.SurroundColors = {Color.FromArgb(31, 105, 152)}
        PB3.FocusScales = New PointF(0.5F, 0.5F)
        PB3.CenterPoint = New Point(Width / 2, 10)

        barGP.AddRectangle(New Rectangle(0, 39, Width - 1, 20))

        G.FillPath(PB3, barGP)
        G.FillPath(New HatchBrush(HatchStyle.NarrowHorizontal, Color.FromArgb(20, 34, 45), Color.Transparent), barGP)

        '// get rid of some pixels
        G.DrawRectangle(Pens.Fuchsia, New Rectangle(Width - 4, 40, 3, 17))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(Width - 4, 40, 3, 17))

        G.DrawRectangle(Pens.Fuchsia, New Rectangle(0, 40, 3, 17))
        G.FillRectangle(Brushes.Fuchsia, New Rectangle(0, 40, 3, 17))


        '// inside square

        'Dim SQpth As GraphicsPath = FormInsideSQ()
        ' G.DrawPath(Pens.Red, SQpth)



        DrawText(New SolidBrush(Color.FromArgb(30, Color.Black)), HorizontalAlignment.Left, 12, 6)
        DrawText(New SolidBrush(Color.FromArgb(20, Color.Black)), HorizontalAlignment.Left, 11, 5)
        DrawText(Brushes.Black, HorizontalAlignment.Left, 10, 4)





    End Sub
End Class
#End Region
#Region "SLCbtn"
Class SLCbtn
    Inherits ThemeControl154


    Protected Overrides Sub ColorHook()

    End Sub

    Protected Overrides Sub PaintHook()
        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Color.White)

        Select Case State
            Case MouseState.None

                '// bnt form

                Dim linear As New LinearGradientBrush(New Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90.0F)
                Dim gp As New GraphicsPath
                gp = CreateRound(0, 0, Width - 1, Height - 1, 7)
                G.FillPath(linear, gp)
                G.DrawPath(New Pen(Color.FromArgb(105, 112, 115)), gp)
                G.SetClip(gp)
                Dim btninsideborder As GraphicsPath = CreateRound(1, 1, Width - 3, Height - 3, 7)
                G.DrawPath(New Pen(Color.White, 1), btninsideborder)
                G.ResetClip()

                '// circle



                'Dim GPF As New GraphicsPath
                'GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                'Dim PB2 As PathGradientBrush
                'PB2 = New PathGradientBrush(GPF)
                'PB2.CenterColor = Color.FromArgb(69, 128, 156)
                'PB2.SurroundColors = {Color.FromArgb(8, 25, 33)}
                'PB2.FocusScales = New PointF(0.9F, 0.9F)


                'G.FillPath(PB2, GPF)

                'G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)

                'G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                DrawText(New SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1)
            Case MouseState.Down
                '// bnt form

                Dim linear As New LinearGradientBrush(New Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90.0F)
                Dim gp As New GraphicsPath
                gp = CreateRound(0, 0, Width - 1, Height - 1, 7)
                G.FillPath(linear, gp)
                G.DrawPath(New Pen(Color.FromArgb(105, 112, 115)), gp)
                G.SetClip(gp)
                Dim btninsideborder As GraphicsPath = CreateRound(1, 1, Width - 3, Height - 3, 7)
                G.DrawPath(New Pen(Color.White, 1), btninsideborder)
                G.ResetClip()

                '// circle



                'Dim GPF As New GraphicsPath
                'GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                'Dim PB2 As PathGradientBrush
                'PB2 = New PathGradientBrush(GPF)
                'PB2.CenterColor = Color.FromArgb(86, 161, 196)
                'PB2.SurroundColors = {Color.FromArgb(94, 176, 215)}
                'PB2.FocusScales = New PointF(0.9F, 0.9F)


                'G.FillPath(PB2, GPF)

                'G.DrawPath(New Pen(Color.FromArgb(105, 194, 236)), GPF)

                'G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))

                DrawText(New SolidBrush(Color.FromArgb(86, 161, 196)), HorizontalAlignment.Left, 5, 1)

            Case MouseState.Over
                '// bnt form

                Dim linear As New LinearGradientBrush(New Rectangle(0, 0, Width, Height / 2), Color.FromArgb(100, Color.FromArgb(207, 207, 207)), Color.FromArgb(250, 250, 250), 90.0F)
                Dim gp As New GraphicsPath
                gp = CreateRound(0, 0, Width - 1, Height - 1, 7)
                G.FillPath(linear, gp)
                G.DrawPath(New Pen(Color.FromArgb(105, 112, 115)), gp)
                G.SetClip(gp)
                Dim btninsideborder As GraphicsPath = CreateRound(1, 1, Width - 3, Height - 3, 7)
                G.DrawPath(New Pen(Color.FromArgb(50, Color.Gray), 1), btninsideborder)
                G.ResetClip()

                '// circle


                'Dim GPF As New GraphicsPath
                'GPF.AddEllipse(New Rectangle(4, Height / 2 - 2.5, 6, 6))
                'Dim PB2 As PathGradientBrush
                'PB2 = New PathGradientBrush(GPF)
                'PB2.CenterColor = Color.FromArgb(69, 128, 156)
                'PB2.SurroundColors = {Color.FromArgb(8, 25, 33)}
                'PB2.FocusScales = New PointF(0.9F, 0.9F)


                'G.FillPath(PB2, GPF)

                'G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
                'G.DrawEllipse(New Pen(Color.LightGray), New Rectangle(3, Height / 2 - 3.1, 8, 8))
                DrawText(New SolidBrush(Color.FromArgb(1, 75, 124)), HorizontalAlignment.Left, 5, 1)
        End Select

    End Sub
End Class
#End Region
#Region "SLCTabControl"
Class SLCTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(30, 120)

    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Public Function Borderpts() As GraphicsPath
        Dim P As New GraphicsPath()
        Dim PS As New List(Of Point)

        PS.Add(New Point(0, 0))
        PS.Add(New Point(Width - 1, 0))
        PS.Add(New Point(Width - 1, Height - 1))
        PS.Add(New Point(0, Height - 1))



        P.AddPolygon(PS.ToArray())
        Return P
    End Function

    Public Function BorderptsInside() As GraphicsPath
        Dim P As New GraphicsPath()
        Dim PS As New List(Of Point)

        PS.Add(New Point(1, 1))
        PS.Add(New Point(122, 1))
        PS.Add(New Point(122, Height - 2))
        PS.Add(New Point(1, Height - 2))



        P.AddPolygon(PS.ToArray())
        Return P
    End Function

    Public Function BigBorder() As GraphicsPath
        Dim P As New GraphicsPath()
        Dim PS As New List(Of Point)

        PS.Add(New Point(50, 1))
        PS.Add(New Point(349, 50))
        PS.Add(New Point(349, 50))
        PS.Add(New Point(50, 349))

        P.AddPolygon(PS.ToArray())
        Return P
    End Function

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)



        Dim b As New Bitmap(Width, Height)
        Dim g As Graphics = Graphics.FromImage(b)
        g.Clear(Color.White)




        '//Big square shadow







        Dim GP1 As GraphicsPath = Borderpts()
        g.DrawPath(Pens.LightGray, GP1)


        '// small border
        Dim tmp1 As GraphicsPath = BorderptsInside()

        Dim PB2 As PathGradientBrush
        PB2 = New PathGradientBrush(tmp1)
        PB2.CenterColor = Color.FromArgb(250, 250, 250)
        PB2.SurroundColors = {Color.FromArgb(237, 237, 237)}
        PB2.FocusScales = New PointF(0.9F, 0.9F)

        g.FillPath(PB2, tmp1)
        g.DrawPath(Pens.Gray, tmp1)




        '// items






        For i = 0 To TabCount - 1

            Dim rec As Rectangle = GetTabRect(i)
            Dim rec2 As Rectangle = rec


            '//inside small 
            rec2.Width -= 3
            rec2.Height -= 3
            rec2.Y += 1
            rec2.X += 1




            If i = SelectedIndex Then



                Dim linear As New LinearGradientBrush(New Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180.0F)
                Dim linear3 As New LinearGradientBrush(New Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180.0F)


                g.FillRectangle(New SolidBrush(Color.FromArgb(242, 242, 242)), rec2)
                g.DrawRectangle(Pens.White, rec2)
                g.DrawRectangle(New Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec)
                g.FillRectangle(linear, New Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1))
                g.FillRectangle(linear3, New Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1))
                '// circle


                g.SmoothingMode = SmoothingMode.HighQuality
                '    g.DrawEllipse(New Pen(Color.FromArgb(200, 200, 200), 3), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))
                ' g.DrawEllipse(New Pen(Color.FromArgb(150, 150, 150), 1), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))


                Dim GPF As New GraphicsPath
                GPF.AddEllipse(New Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12))
                Dim PB3 As PathGradientBrush
                PB3 = New PathGradientBrush(GPF)
                PB3.CenterPoint = New Point(rec2.X - 10, rec2.Y - 10)
                PB3.CenterColor = Color.FromArgb(56, 142, 196)
                PB3.SurroundColors = {Color.FromArgb(64, 106, 140)}
                PB3.FocusScales = New PointF(0.9F, 0.9F)


                g.FillPath(PB3, GPF)

                g.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
                g.SetClip(GPF)
                g.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(rec2.X + 10.5, rec2.Y + 11, 6, 6))
                g.ResetClip()



                g.SmoothingMode = SmoothingMode.None

            Else

                g.SmoothingMode = SmoothingMode.HighQuality
                Dim linear As New LinearGradientBrush(New Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180.0F)
                Dim linear3 As New LinearGradientBrush(New Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180.0F)


                g.FillRectangle(New SolidBrush(Color.FromArgb(242, 242, 242)), rec2)
                g.DrawRectangle(Pens.White, rec2)
                g.DrawRectangle(New Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec)
                g.FillRectangle(linear, New Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1))
                g.FillRectangle(linear3, New Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1))


                g.FillEllipse(Brushes.LightGray, New Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12))
                g.DrawEllipse(New Pen(Color.FromArgb(100, 100, 100), 1), New Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12))
                g.SmoothingMode = SmoothingMode.None

            End If

            g.DrawString(TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(56, 106, 137)), rec, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Next




        e.Graphics.DrawImage(b.Clone, 0, 0)
        g.Dispose()
        b.Dispose()
        MyBase.OnPaint(e)
    End Sub
End Class
#End Region
#Region "SLCTextbox"
<DefaultEvent("TextChanged")> Class SLCTextBox : Inherits Control

#Region " Variables"
    Private TB As Windows.Forms.TextBox
    Private State As MouseState = MouseState.None
#End Region

#Region " Properties"
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
        MyBase.OnEnter(e) : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        MyBase.OnLeave(e) : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e) : Invalidate()
    End Sub

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
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
            If TB IsNot Nothing Then
                TB.MaxLength = value
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
            If TB IsNot Nothing Then
                TB.ReadOnly = value
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
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
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
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
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
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub
#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
              ControlStyles.UserPaint Or _
              ControlStyles.OptimizedDoubleBuffer Or _
              ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.Selectable, True)

        DoubleBuffered = True

        TB = New Windows.Forms.TextBox
        TB.Font = New Font("Tahoma", 8)
        TB.BackColor = Color.White
        TB.ForeColor = Color.FromArgb(1, 75, 124)
        TB.MaxLength = _MaxLength
        TB.Multiline = _Multiline
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        TB.Cursor = Cursors.IBeam

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub
    Public Function Borderpts() As Rectangle
        Dim P As New Rectangle


        P = New Rectangle(2, 2, Width - 5, Height - 5)
        Return P
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)


        Dim PB1 As PathGradientBrush
        Dim GP1 As GraphicsPath = RoundRec(Borderpts, 2)





        With G
            .SmoothingMode = 2
            .TextRenderingHint = 1
            .Clear(Color.White)

            PB1 = New PathGradientBrush(GP1)
            PB1.CenterColor = Color.White
            PB1.SurroundColors = {Color.FromArgb(234, 234, 234)}
            PB1.FocusScales = New PointF(0.9F, 0.5F)



            .FillPath(PB1, GP1)
            .DrawPath(New Pen(Color.FromArgb(125, 125, 125)), GP1)


            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End With
    End Sub

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
End Class
#End Region
#Region "SLCRadioButton"
<DefaultEvent("CheckedChanged")> _
Class SLCRadionButton
    Inherits Control

    Event CheckedChanged(ByVal sender As Object)

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        BackColor = Color.White

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Brushes.Red)
    End Sub

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value

            If _Checked Then
                InvalidateParent()
            End If

            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Private Sub InvalidateParent()
        If Parent Is Nothing Then Return

        For Each C As Control In Parent.Controls
            If Not (C Is Me) AndAlso (TypeOf C Is SLCRadionButton) Then
                DirectCast(C, SLCRadionButton).Checked = False
            End If
        Next
    End Sub

    Private GP1 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P1, P2 As Pen

    Private PB1 As PathGradientBrush

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics
        G = e.Graphics


        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = New GraphicsPath
        GP1.AddEllipse(0, 2, Height - 5, Height - 5)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)

        ' G.FillPath(PB1, GP1)

        G.DrawEllipse(P1, 4, 4, Height - 11, Height - 11)
        ' G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7)

        If _Checked Then
            Dim GPF As New GraphicsPath
            GPF.AddEllipse(New Rectangle(Height - 18.5, Height - 19, 12, 12))
            Dim PB3 As PathGradientBrush
            PB3 = New PathGradientBrush(GPF)
            PB3.CenterPoint = New Point(Height - 18.5, Height - 20)
            PB3.CenterColor = Color.FromArgb(56, 142, 196)
            PB3.SurroundColors = {Color.FromArgb(64, 106, 140)}
            PB3.FocusScales = New PointF(0.9F, 0.9F)


            G.FillPath(PB3, GPF)

            G.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
            G.SetClip(GPF)
            G.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(Height - 16, Height - 18, 6, 6))
            G.ResetClip()
        End If

        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(Height - 3, Height \ 2 - SZ1.Height / 2)


        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), PT1)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Checked = True
        MyBase.OnMouseDown(e)
    End Sub

End Class
#End Region
#Region "SLCComboBox"
Class SLCComboBox
    Inherits ComboBox

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        DropDownStyle = ComboBoxStyle.DropDownList


        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed


    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G.Clear(Color.White)





        'inside borders



        Dim GP As GraphicsPath = RoundRec(New Rectangle(0, 0, Width - 1, Height - 1), 5)
        Dim GP2 As GraphicsPath = RoundRec(New Rectangle(1, 1, Width - 3, Height - 3), 5)
        Dim GP3 As GraphicsPath = RoundRec(New Rectangle(2, 2, Width - 5, Height - 5), 5)


        G.SmoothingMode = SmoothingMode.HighQuality

        G.FillPath(New SolidBrush(Color.FromArgb(250, 250, 250)), GP3)
        G.DrawPath(New Pen(Color.FromArgb(60, Color.LightGray), 4), GP2)
        G.DrawPath(New Pen(Color.FromArgb(100, Color.FromArgb(15, 15, 15))), GP)
        ' G.DrawPath(New Pen(Color.FromArgb(60, Color.LightGray), 4), GP3)
        G.SmoothingMode = SmoothingMode.None

        Dim rect1 As New Rectangle(Width - 26, 0, 1, Height)
        Dim rect2 As New Rectangle(Width - 27, 0, 2, Height)
        G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.FromArgb(1, 75, 124))), rect1)
        G.DrawRectangle(New Pen(Color.FromArgb(60, Color.FromArgb(61, 113, 153))), rect1)



        'little arrow shit

        G.SmoothingMode = SmoothingMode.HighQuality


        G.DrawArc(New Pen(Color.FromArgb(97, 152, 195)), New Rectangle(Width - 18, Height - 19, 8, 8), 20, 140)

        G.DrawArc(New Pen(Color.LightGray), New Rectangle(Width - 18, Height - 18, 8, 8), 10, 160)
        G.DrawArc(New Pen(Color.FromArgb(78, 121, 154), 1.5), New Rectangle(Width - 18, Height - 20, 8, 8), 20, 140)



        G.DrawArc(New Pen(Color.FromArgb(97, 152, 195)), New Rectangle(Width - 19, Height - 16, 10, 10), 20, 140)

        G.DrawArc(New Pen(Color.LightGray), New Rectangle(Width - 19, Height - 15, 10, 10), 10, 160)
        G.DrawArc(New Pen(Color.FromArgb(78, 121, 154), 1.5), New Rectangle(Width - 19, Height - 17, 10, 10), 20, 140)
        G.SmoothingMode = SmoothingMode.None


        Dim PT1 As New PointF(3, Height - 18)

        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), PT1)
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds)
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(250, 250, 250)), e.Bounds)
        End If

        If Not e.Index = -1 Then
            e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, New SolidBrush(Color.FromArgb(1, 75, 124)), e.Bounds)
        End If
    End Sub

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
End Class
#End Region
#Region "SLCProgrssBar"
Class SLCProgrssBar
    Inherits Control

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

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)


        P2 = New Pen(Color.FromArgb(55, 55, 55))
        B1 = New SolidBrush(Color.FromArgb(0, 214, 37))
    End Sub

    Private GP1, GP2, GP3 As GraphicsPath

    Private R1, R2 As Rectangle

    Private P2 As Pen
    Private B1 As SolidBrush
    Private GB1, GB2 As LinearGradientBrush

    Private I1 As Integer

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        Dim R3 As New Rectangle
        Dim HB As HatchBrush

        G.Clear(Color.White)
        G.SmoothingMode = SmoothingMode.HighQuality

        GP1 = RoundRec(New Rectangle(0, 0, Width - 1, Height - 1), 4)
        GP2 = RoundRec(New Rectangle(1, 1, Width - 3, Height - 3), 4)

        R1 = New Rectangle(0, 2, Width - 1, Height - 1)
        GB1 = New LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90.0F)





        G.SetClip(GP1)
        'gloss
        Dim PB As New PathGradientBrush(GP1)
        PB.CenterColor = Color.FromArgb(230, 230, 230)
        PB.SurroundColors = {Color.FromArgb(255, 255, 255)}
        PB.CenterPoint = New Point(0, Height)
        PB.FocusScales = New PointF(1, 0)

        G.FillRectangle(PB, R1)

        G.FillPath(New SolidBrush(Color.FromArgb(250, 250, 250)), RoundRec(New Rectangle(1, 1, Width - 3, Height / 2 - 2), 4))

        I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3))

        If I1 > 1 Then





            GP3 = RoundRec(New Rectangle(1, 1, I1, Height - 3), 4)

            'grad
            HB = New HatchBrush(HatchStyle.Trellis, Color.FromArgb(50, Color.Black), Color.Transparent)



            'bar
            R2 = New Rectangle(1, 1, I1, Height - 3)
            GB2 = New LinearGradientBrush(R2, Color.FromArgb(20, 34, 45), Color.FromArgb(27, 84, 121), 90.0F)

            G.FillPath(GB2, GP3)
            G.DrawPath(New Pen(Color.FromArgb(120, 134, 145)), GP3)

            G.SetClip(GP3)
            G.SmoothingMode = SmoothingMode.None



            G.FillRectangle(New SolidBrush(Color.FromArgb(32, 100, 144)), R2.X, R2.Y + 1, R2.Width, R2.Height \ 2)

            R3 = New Rectangle(1, 1, I1, Height - 1)

            G.FillRectangle(HB, R3)

            G.SmoothingMode = SmoothingMode.AntiAlias
            G.ResetClip()
        End If



        G.DrawPath(New Pen(Color.FromArgb(125, 125, 125)), GP2)
        G.DrawPath(New Pen(Color.FromArgb(80, Color.LightGray)), GP1)
    End Sub
    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

End Class
#End Region
#Region "SLCCheckbox"
<DefaultEvent("CheckedChanged")> _
Class SLCCheckbox
    Inherits Control

    Event CheckedChanged(ByVal sender As Object)

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P11 = New Pen(Color.LightGray)
        P22 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.Black, 2.0F)
        P4 = New Pen(Color.White, 2.0F)
    End Sub

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)

            Invalidate()
        End Set
    End Property

    Private GP1, GP2 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P11, P22, P3, P4 As Pen

    Private PB1 As PathGradientBrush

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics


        g.Clear(Color.White)
        g.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = RoundRec(New Rectangle(0, 2, Height - 5, Height - 5), 1)
        GP2 = RoundRec(New Rectangle(1, 3, Height - 7, Height - 7), 1)

        Dim GPF As New GraphicsPath
        GPF.AddPath(RoundRec(New Rectangle(Height - 18.5, Height - 20, 14, 14), 2), True)
        Dim PB3 As PathGradientBrush
        PB3 = New PathGradientBrush(GPF)
        '  PB3.CenterPoint = New Point(Height - 18.5, Height - 21)
        PB3.CenterColor = Color.FromArgb(240, 240, 240)
        PB3.SurroundColors = {Color.FromArgb(90, 90, 90)}
        PB3.FocusScales = New PointF(0.4F, 0.4F)

        Dim hb As New HatchBrush(HatchStyle.Trellis, Color.FromArgb(70, Color.FromArgb(15, 54, 80)), Color.Transparent)

        g.FillPath(PB3, GPF)
        g.FillPath(hb, GPF)


        g.DrawPath(New Pen(Color.FromArgb(49, 63, 86)), GPF)
        g.SetClip(GPF)
        g.FillEllipse(New SolidBrush(Color.FromArgb(70, Color.DarkGray)), New Rectangle(Height - 16, Height - 18, 6, 6))
        g.DrawPath(Pens.White, RoundRec(New Rectangle(5, 4, Height - 11, Height - 11), 2))
        g.ResetClip()



        If _Checked Then

            'g.DrawLine(Pens.Red, New PointF(7, Height - 10), New PointF(Height - 10, 5))
            g.DrawLine(New Pen(New SolidBrush(Color.FromArgb(1, 75, 124)), 2), New Point(8, Height - 9), New Point(Height - 8, 6))


            g.DrawLine(New Pen(New SolidBrush(Color.FromArgb(1, 75, 124)), 2), 7, Height - 13, 8, Height - 10)


        End If

        SZ1 = g.MeasureString(Text, Font)
        PT1 = New PointF(Height - 3, Height \ 2 - SZ1.Height / 2)


        g.DrawString(Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), PT1)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Checked = Not Checked
    End Sub

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

End Class

#End Region
#Region "SLCListview"
Class SLCListView
    Inherits Control

    Class NSListViewItem
        Property Text As String
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Property SubItems As New List(Of NSListViewSubItem)

        Protected UniqueId As Guid

        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is NSListViewItem Then
                Return (DirectCast(obj, NSListViewItem).UniqueId = UniqueId)
            End If

            Return False
        End Function


    End Class

    Class NSListViewSubItem
        Property Text As String

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Class NSListViewColumnHeader
        Property Text As String
        Property Width As Integer = 60

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Private _Items As New List(Of NSListViewItem)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Items() As NSListViewItem()
        Get
            Return _Items.ToArray()
        End Get
        Set(ByVal value As NSListViewItem())
            _Items = New List(Of NSListViewItem)(value)
            InvalidateScroll()
        End Set
    End Property

    Private _SelectedItems As New List(Of NSListViewItem)
    Public ReadOnly Property SelectedItems() As NSListViewItem()
        Get
            Return _SelectedItems.ToArray()
        End Get
    End Property

    Private _Columns As New List(Of NSListViewColumnHeader)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Columns() As NSListViewColumnHeader()
        Get
            Return _Columns.ToArray()
        End Get
        Set(ByVal value As NSListViewColumnHeader())
            _Columns = New List(Of NSListViewColumnHeader)(value)
            InvalidateColumns()
        End Set
    End Property

    Private _MultiSelect As Boolean = True
    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value

            If _SelectedItems.Count > 1 Then
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1)
            End If

            Invalidate()
        End Set
    End Property

    Private ItemHeight As Integer = 24
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            ItemHeight = CInt(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6

            If VS IsNot Nothing Then
                VS.SmallChange = ItemHeight
                VS.LargeChange = ItemHeight
            End If

            MyBase.Font = value
            InvalidateLayout()
        End Set
    End Property

#Region " Item Helper Methods "

    'Ok, you've seen everything of importance at this point; I am begging you to spare yourself. You must not read any further!

    Public Sub AddItem(ByVal text As String, ByVal ParamArray subItems As String())
        Dim Items As New List(Of NSListViewSubItem)
        For Each I As String In subItems
            Dim SubItem As New NSListViewSubItem()
            SubItem.Text = I
            Items.Add(SubItem)
        Next

        Dim Item As New NSListViewItem()
        Item.Text = text
        Item.SubItems = Items

        _Items.Add(Item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItemAt(ByVal index As Integer)
        _Items.RemoveAt(index)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItem(ByVal item As NSListViewItem)
        _Items.Remove(item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItems(ByVal items As NSListViewItem())
        For Each I As NSListViewItem In items
            _Items.Remove(I)
        Next

        InvalidateScroll()
    End Sub

#End Region

    Private VS As SLCScrollBar

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))

        B1 = New SolidBrush(Color.FromArgb(62, 62, 62))
        B2 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B3 = New SolidBrush(Color.FromArgb(47, 47, 47))
        B4 = New SolidBrush(Color.FromArgb(50, 50, 50))

        VS = New SLCScrollBar
        VS.SmallChange = ItemHeight
        VS.LargeChange = ItemHeight

        AddHandler VS.Scroll, AddressOf HandleScroll
        AddHandler VS.MouseDown, AddressOf VS_MouseDown
        Controls.Add(VS)

        InvalidateLayout()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub HandleScroll(ByVal sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        VS.Maximum = (_Items.Count * ItemHeight)
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VS.Location = New Point(Width - VS.Width - 1, 1)
        VS.Size = New Size(18, Height - 2)

        Invalidate()
    End Sub

    Private ColumnOffsets As Integer()
    Private Sub InvalidateColumns()
        Dim Width As Integer = 3
        ColumnOffsets = New Integer(_Columns.Count - 1) {}

        For I As Integer = 0 To _Columns.Count - 1
            ColumnOffsets(I) = Width
            Width += Columns(I).Width
        Next

        Invalidate()
    End Sub

    Private Sub VS_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Focus()

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))
            Dim Index As Integer = ((e.Y + Offset - ItemHeight) \ ItemHeight)

            If Index > _Items.Count - 1 Then Index = -1

            If Not Index = -1 Then
                'TODO: Handle Shift key

                If ModifierKeys = Keys.Control AndAlso _MultiSelect Then
                    If _SelectedItems.Contains(_Items(Index)) Then
                        _SelectedItems.Remove(_Items(Index))
                    Else
                        _SelectedItems.Add(_Items(Index))
                    End If
                Else
                    _SelectedItems.Clear()
                    _SelectedItems.Add(_Items(Index))
                End If
            End If

            Invalidate()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4 As SolidBrush
    Private GB1 As LinearGradientBrush

    'I am so sorry you have to witness this. I tried warning you. ;.;

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G = e.Graphics

        G.Clear(Color.White)

        Dim X, Y As Integer
        Dim H As Single

        G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(50, Color.LightGray))), 1, 1, Width - 3, Height - 3)

        Dim R1 As Rectangle
        Dim CI As NSListViewItem

        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))

        Dim StartIndex As Integer
        If Offset = 0 Then StartIndex = 0 Else StartIndex = (Offset \ ItemHeight)

        Dim EndIndex As Integer = Math.Min(StartIndex + (Height \ ItemHeight), _Items.Count - 1)

        For I As Integer = StartIndex To EndIndex
            CI = Items(I)

            R1 = New Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1)

            H = G.MeasureString(CI.Text, Font).Height
            Y = R1.Y + CInt((ItemHeight / 2) - (H / 2))

            If _SelectedItems.Contains(CI) Then
                If I Mod 2 = 0 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.LightGray)), R1)
                Else
                    G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.LightGray)), R1)
                End If
            Else
                If I Mod 2 = 0 Then
                    G.FillRectangle(Brushes.White, R1)
                Else
                    G.FillRectangle(Brushes.White, R1)
                End If
            End If

            G.DrawLine(Pens.LightGray, 0, R1.Bottom, Width, R1.Bottom)

            If Columns.Length > 0 Then
                R1.Width = Columns(0).Width
                G.SetClip(R1)
            End If

            'TODO: Ellipse text that overhangs seperators.
            G.DrawString(CI.Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), 10, Y + 1)


            If CI.SubItems IsNot Nothing Then
                For I2 As Integer = 0 To Math.Min(CI.SubItems.Count, _Columns.Count) - 1
                    X = ColumnOffsets(I2 + 1) + 4

                    R1.X = X
                    R1.Width = Columns(I2).Width
                    G.SetClip(R1)

                    G.DrawString(CI.SubItems(I2).Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), X + 1, Y + 1)

                Next
            End If

            G.ResetClip()
        Next

        R1 = New Rectangle(0, 0, Width, ItemHeight)

        GB1 = New LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90.0F)
        G.FillRectangle(GB1, R1)
        G.SetClip(R1)
        G.FillRectangle(Brushes.White, New Rectangle(0, 0, R1.Width - 1, R1.Height / 2 - 1))
        G.ResetClip()
        G.DrawRectangle(Pens.White, 1, 1, Width - 22, ItemHeight - 2)

        Dim LH As Integer = Math.Min(VS.Maximum + ItemHeight - Offset, Height)

        Dim CC As NSListViewColumnHeader
        For I As Integer = 0 To _Columns.Count - 1
            CC = Columns(I)

            H = G.MeasureString(CC.Text, Font).Height
            Y = CInt((ItemHeight / 2) - (H / 2))
            X = ColumnOffsets(I)

            G.DrawString(CC.Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), X + 1, Y + 1)


            G.DrawLine(Pens.LightGray, X - 3, 0, X - 3, LH)
            G.DrawLine(Pens.White, X - 2, 0, X - 2, ItemHeight)
        Next

        G.DrawRectangle(Pens.LightGray, 0, 0, Width - 1, Height - 1)

        G.DrawLine(New Pen(New SolidBrush(Color.LightGray)), 0, ItemHeight, Width, ItemHeight)
        G.DrawLine(New Pen(Brushes.LightGray), VS.Location.X - 1, 0, VS.Location.X - 1, Height)

        G.FillRectangle(Brushes.White, Width - 19, 0, Width, Height)
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (ItemHeight \ 2))

        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value

        MyBase.OnMouseWheel(e)
    End Sub

End Class

#End Region
#Region "SLCScrollBar"
<DefaultEvent("Scroll")> _
Class SLCScrollBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

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

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Property _Percent As Double
    Public ReadOnly Property Percent As Double
        Get
            If Not ShowThumb Then Return 0
            Return GetProgress()
        End Get
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Width = 18


    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath



    Dim I1 As Integer

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G = e.Graphics
        G.Clear(Color.FromArgb(255, 255, 255))

        GP1 = DrawArrow(4, 6, False)
        GP2 = DrawArrow(5, 7, False)

        G.FillPath(New SolidBrush(Color.LightGray), GP2)
        G.FillPath(New SolidBrush(Color.FromArgb(83, 123, 168)), GP1)

        GP3 = DrawArrow(4, Height - 11, True)
        GP4 = DrawArrow(5, Height - 10, True)

        G.FillPath(New SolidBrush(Color.LightGray), GP4)
        G.FillPath(New SolidBrush(Color.FromArgb(83, 123, 168)), GP3)

        If ShowThumb Then
            G.FillRectangle(New SolidBrush(Color.FromArgb(250, 250, 250)), Thumb)
            G.DrawRectangle(Pens.LightGray, Thumb)
            G.DrawRectangle(Pens.White, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim Y As Integer
            Dim LY As Integer = Thumb.Y + (Thumb.Height \ 2) - 3

            For I As Integer = 0 To 2
                Y = LY + (I * 3)

                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(68, 95, 127))), Thumb.X + 5, Y, Thumb.Right - 5, Y)
                G.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.FromArgb(68, 95, 127)))), Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1)
            Next
        End If
        G.SmoothingMode = SmoothingMode.HighQuality
        'G.DrawRectangle(New Pen(New SolidBrush(Color.Red)), 0, 0, Width - 1, Height - 1)
        G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(59, 122, 165))), RoundRec(New Rectangle(1, 1, Width - 3, Height - 3), 4))
        G.SmoothingMode = SmoothingMode.None
    End Sub

    Private Function DrawArrow(ByVal x As Integer, ByVal y As Integer, ByVal flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 9
        Dim H As Integer = 5

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        TSA = New Rectangle(0, 0, Width, ButtonSize)
        BSA = New Rectangle(0, Height - ButtonSize, Width, ButtonSize)
        Shaft = New Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(1, 0, Width - 3, ThumbSize)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.Y = CInt(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    MyBase.OnMouseDown(e)
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y - TSA.Height - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
        MyBase.OnMouseUp(e)
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
End Class
#End Region
#Region "SLCOnOffBox"
<DefaultEvent("CheckedChanged")> _
Class SLCOnOffBox
    Inherits Control

    Event CheckedChanged(ByVal sender As Object)

    Protected State As MouseState


    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))

        B1 = New SolidBrush(Color.FromArgb(35, 35, 35))
        B2 = New SolidBrush(Color.FromArgb(85, 85, 85))
        B3 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B4 = New SolidBrush(Color.FromArgb(205, 150, 0))
        B5 = New SolidBrush(Color.FromArgb(40, 40, 40))

        SF1 = New StringFormat()
        SF1.LineAlignment = StringAlignment.Center
        SF1.Alignment = StringAlignment.Near

        SF2 = New StringFormat()
        SF2.LineAlignment = StringAlignment.Center
        SF2.Alignment = StringAlignment.Far

        Size = New Size(56, 24)
        MinimumSize = Size
        MaximumSize = Size
    End Sub

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)

            Invalidate()
        End Set
    End Property

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4, B5 As SolidBrush

    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush

    Private R1, R2, R3 As Rectangle
    Private SF1, SF2 As StringFormat

    Private Offset As Integer

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim G As Graphics = e.Graphics

        G.Clear(Color.White)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = RoundRec(New Rectangle(0, 0, Width - 1, Height - 1), 7)
        GP2 = RoundRec(New Rectangle(1, 1, Width - 3, Height - 3), 7)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(250, 250, 250)
        PB1.SurroundColors = {Color.FromArgb(245, 245, 245)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)

        G.FillPath(PB1, GP1)
        G.DrawPath(Pens.LightGray, GP1)
        G.DrawPath(Pens.White, GP2)

        R1 = New Rectangle(5, 0, Width - 10, Height + 2)
        R2 = New Rectangle(6, 1, Width - 10, Height + 2)

        R3 = New Rectangle(1, 1, (Width \ 2) - 1, Height - 3)



        If _Checked Then
            ' G.DrawString("On", Font, Brushes.Black, R2, SF1)
            G.DrawString("On", Font, New SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF1)

            R3.X += (Width \ 2) - 1
        Else
            'G.DrawString("Off", Font, B1, R2, SF2)
            G.DrawString("Off", Font, New SolidBrush(Color.FromArgb(1, 75, 124)), R1, SF2)
        End If

        GP3 = RoundRec(R3, 7)
        GP4 = RoundRec(New Rectangle(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2), 7)

        GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(245, 245, 245), 90.0F)

        G.FillPath(GB1, GP3)
        G.DrawPath(Pens.LightGray, GP3)
        G.DrawPath(Pens.White, GP4)


        Offset = R3.X + (R3.Width \ 2) - 3

        For I As Integer = 0 To 1
            If _Checked Then
                'G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
            Else
                ' G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
            End If

            G.SmoothingMode = SmoothingMode.None

            If _Checked Then

                G.SmoothingMode = SmoothingMode.HighQuality

                Dim GPF As New GraphicsPath
                GPF.AddEllipse(New Rectangle(Width - 20, Height - 17, 10, 10))
                Dim PB3 As PathGradientBrush
                PB3 = New PathGradientBrush(GPF)
                PB3.CenterPoint = New Point(Height - 18.5, Height - 20)
                PB3.CenterColor = Color.FromArgb(53, 152, 74)
                PB3.SurroundColors = {Color.FromArgb(86, 216, 114)}
                PB3.FocusScales = New PointF(0.9F, 0.9F)


                G.FillPath(PB3, GPF)

                G.DrawPath(New Pen(Color.FromArgb(85, 200, 109)), GPF)
                G.SetClip(GPF)
                G.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(Width - 20, Height - 18, 6, 6))
                G.ResetClip()


                '  G.FillRectangle(New SolidBrush(Color.FromArgb(85, 158, 203)), Offset + (I * 5), 7, 2, Height - 14)
            Else
                G.SmoothingMode = SmoothingMode.HighQuality

                Dim GPF As New GraphicsPath
                GPF.AddEllipse(New Rectangle(Height - 15, Height - 17, 10, 10))
                Dim PB3 As PathGradientBrush
                PB3 = New PathGradientBrush(GPF)
                PB3.CenterPoint = New Point(Height - 18.5, Height - 20)
                PB3.CenterColor = Color.FromArgb(185, 65, 65)
                PB3.SurroundColors = {Color.Red}
                PB3.FocusScales = New PointF(0.9F, 0.9F)


                G.FillPath(PB3, GPF)

                G.DrawPath(New Pen(Color.FromArgb(152, 53, 53)), GPF)
                G.SetClip(GPF)
                G.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(Height - 16, Height - 18, 6, 6))
                G.ResetClip()



                '  G.FillRectangle(Brushes.LightGray, Offset + (I * 5), 7, 2, Height - 14)
            End If

            G.SmoothingMode = SmoothingMode.AntiAlias
        Next
    End Sub

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Checked = Not Checked
        MyBase.OnMouseDown(e)
    End Sub

End Class
#End Region
#Region "SLCGroupBox"
Class SLCGroupBox
    Inherits ContainerControl

    Private _DrawSeperator As Boolean
    Public Property DrawSeperator() As Boolean
        Get
            Return _DrawSeperator
        End Get
        Set(ByVal value As Boolean)
            _DrawSeperator = value
            Invalidate()
        End Set
    End Property

    Private _Title As String = "GroupBox"
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
            Invalidate()
        End Set
    End Property

    Private _SubTitle As String = "Details"
    Public Property SubTitle() As String
        Get
            Return _SubTitle
        End Get
        Set(ByVal value As String)
            _SubTitle = value
            Invalidate()
        End Set
    End Property

    Private _TitleFont As Font
    Private _SubTitleFont As Font

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        _TitleFont = New Font("Verdana", 10.0F)
        _SubTitleFont = New Font("Verdana", 6.5F)


    End Sub

    Private GP1, GP2 As GraphicsPath

    Private PT1 As PointF
    Private SZ1, SZ2 As SizeF




    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G = e.Graphics


        G.Clear(Color.White)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = RoundRec(New Rectangle(0, 0, Width - 1, Height - 1), 7)
        GP2 = RoundRec(New Rectangle(1, 1, Width - 3, Height - 3), 7)


        G.FillPath(New SolidBrush(Color.FromArgb(250, 250, 250)), GP2)
        G.SetClip(GP2)
        Dim PB As New PathGradientBrush(GP2)
        PB.CenterColor = Color.FromArgb(255, 255, 255)
        PB.SurroundColors = {Color.FromArgb(250, 250, 250)}
        PB.FocusScales = New PointF(0.95, 0.95)
        G.FillPath(PB, GP2)
        G.ResetClip()

        G.DrawPath(New Pen(New SolidBrush(Color.FromArgb(70, Color.LightGray))), GP1)
        G.DrawPath(Pens.Gray, GP2)

        SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic)
        SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic)


        G.DrawString(_Title, _TitleFont, New SolidBrush(Color.FromArgb(1, 75, 124)), 5, 5)

        PT1 = New PointF(6.0F, SZ1.Height + 4.0F)


        G.DrawString(_SubTitle, _SubTitleFont, New SolidBrush(Color.Black), PT1.X, PT1.Y)


    End Sub

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

End Class
#End Region
#Region "SLCContextMenu"
Class SLCContextMenu
    Inherits ContextMenuStrip

    Sub New()
        Renderer = New ToolStripProfessionalRenderer(New SLCColorTable())
        ForeColor = Color.FromArgb(1, 75, 124)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(Color.White)
        MyBase.OnPaint(e)
    End Sub

End Class

#End Region
#Region "SCLCT"

Class SLCColorTable
    Inherits ProfessionalColorTable

    Private BackColor As Color = Color.White

    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return Color.FromArgb(1, 75, 124)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return Color.FromArgb(50, Color.LightGray)
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return Color.FromArgb(35, 35, 35)
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

End Class
#End Region
#Region "SLCLABEL"
Class SLCLabel
    Inherits Control
    Dim lb As New Windows.Forms.Label
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Font = New Font("Verdana", 8.0F, FontStyle.Regular)
        Size = New Size(39, 13)


    End Sub

    Private _text As String = "SLCLabel"
    Public Overrides Property Text As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
            Invalidate()
        End Set
    End Property


    Private PT1 As PointF
    Private SZ1 As SizeF

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G = e.Graphics

        G.Clear(Color.White)


        PT1 = New PointF(0, 0)

        G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(1, 75, 124)), PT1)

    End Sub

End Class
#End Region
#Region "SLCClose"
Class SLCClose
    Inherits ThemeControl154
    Dim LB As New Label
    Protected Overrides Sub ColorHook()

    End Sub

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Size = New Size(20, 20)


    End Sub

    Protected Overrides Sub PaintHook()
        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Color.White)
        G.FillRectangle(New SolidBrush(Color.FromArgb(239, 239, 239)), New Rectangle(-1, -1, Width + 1, Height + 1))



        Select Case State
            Case MouseState.None


                '// circle

                G.SmoothingMode = SmoothingMode.HighQuality

                Dim GPF As New GraphicsPath
                GPF.AddEllipse(New Rectangle(Width - 20, Height - 19, 15, 15))
                Dim PB3 As PathGradientBrush
                PB3 = New PathGradientBrush(GPF)
                PB3.CenterPoint = New Point(Height - 18.5, Height - 20)
                PB3.CenterColor = Color.FromArgb(193, 26, 26)
                PB3.SurroundColors = {Color.FromArgb(229, 110, 110)}
                PB3.FocusScales = New PointF(0.6F, 0.6F)


                G.FillPath(PB3, GPF)

                G.DrawPath(New Pen(Color.FromArgb(159, 41, 41)), GPF)
                G.SetClip(GPF)
                G.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(Width - 20, Height - 18, 6, 6))
                G.ResetClip()
            Case MouseState.Down
                '// circle

                G.SmoothingMode = SmoothingMode.HighQuality

                Dim GPF As New GraphicsPath
                GPF.AddEllipse(New Rectangle(Width - 20, Height - 19, 15, 15))
                Dim PB3 As PathGradientBrush
                PB3 = New PathGradientBrush(GPF)
                PB3.CenterPoint = New Point(Height - 18.5, Height - 20)
                PB3.CenterColor = Color.FromArgb(221, 32, 32)
                PB3.SurroundColors = {Color.FromArgb(229, 110, 110)}
                PB3.FocusScales = New PointF(0.6F, 0.6F)


                G.FillPath(PB3, GPF)

                G.DrawPath(New Pen(Color.White), GPF)
                G.SetClip(GPF)
                G.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(Width - 20, Height - 18, 6, 6))
                G.ResetClip()
            Case MouseState.Over
                '// circle

                G.SmoothingMode = SmoothingMode.HighQuality

                Dim GPF As New GraphicsPath
                GPF.AddEllipse(New Rectangle(Width - 20, Height - 19, 15, 15))
                Dim PB3 As PathGradientBrush
                PB3 = New PathGradientBrush(GPF)
                PB3.CenterPoint = New Point(Height - 18.5, Height - 20)
                PB3.CenterColor = Color.FromArgb(221, 32, 32)
                PB3.SurroundColors = {Color.FromArgb(229, 110, 110)}
                PB3.FocusScales = New PointF(0.6F, 0.6F)


                G.FillPath(PB3, GPF)

                G.DrawPath(New Pen(Color.FromArgb(159, 41, 41)), GPF)
                G.SetClip(GPF)
                G.FillEllipse(New SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), New Rectangle(Width - 20, Height - 18, 6, 6))
                G.ResetClip()
        End Select

    End Sub
End Class
#End Region
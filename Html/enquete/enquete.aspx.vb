Partial Class enquete
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Public x, y, w, h As Integer


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        w = Request.QueryString.Item("w")
        h = Request.QueryString.Item("h")
        If Request.QueryString.Item("a") = "b" Then createGraphBar(Request.QueryString.Item("c"), System.Convert.ToSingle(Request.QueryString.Item("p")))
        If Request.QueryString.Item("a") = "l" Then createGraphIndex(Request.QueryString.Item("c"))
        If Request.QueryString.Item("a") = "" Then
            Dim ds As New DataSet
            Dim a As New SqlClient.SqlDataAdapter("select top 6 q.nome as questao, r.nome as resposta, r.hits as votos from questao q inner join resposta r on q.id_questao = r.id_questao order by [data] desc", g.cn)

            a.Fill(ds, "enquete")

            lblQuestao.Text = ds.Tables("enquete").DefaultView(0)("questao")
            leg1.Text = ds.Tables("enquete").DefaultView(0)("resposta")
            leg2.Text = ds.Tables("enquete").DefaultView(1)("resposta")
            leg3.Text = ds.Tables("enquete").DefaultView(2)("resposta")

            Dim votos As Integer

            votos = ds.Tables("enquete").DefaultView(0)("votos") + ds.Tables("enquete").DefaultView(1)("votos") + ds.Tables("enquete").DefaultView(2)("votos")

            pct1.Text = Math.Round(ds.Tables("enquete").DefaultView(0)("votos") / votos * 100) & "%"
            pct2.Text = Math.Round(ds.Tables("enquete").DefaultView(1)("votos") / votos * 100) & "%"
            pct3.Text = Math.Round(ds.Tables("enquete").DefaultView(2)("votos") / votos * 100) & "%"

            imgPct1.ImageUrl = "enquete.aspx?a=b&w=20&h=200&c=verde&p=" & ds.Tables("enquete").DefaultView(0)("votos") / votos * 100

            imgPct2.ImageUrl = "enquete.aspx?a=b&w=20&h=200&c=vinho&p=" & ds.Tables("enquete").DefaultView(1)("votos") / votos * 100

            imgPct3.ImageUrl = "enquete.aspx?a=b&w=20&h=200&c=laranja&p=" & ds.Tables("enquete").DefaultView(2)("votos") / votos * 100
        End If

    End Sub

    Public Sub createGraphBar(ByVal cor1 As String, ByVal pct As Single)

        x = 0
        y = 0
        Dim stream As New IO.MemoryStream
        Dim b As New System.Drawing.Bitmap(w * 2, h, Drawing.Imaging.PixelFormat.Format16bppRgb555)
        Dim graph As Drawing.Graphics = Graphics.FromImage(b)
        Dim color(2) As Drawing.Brush

        b.SetResolution(300, 300)

        Dim brush As Drawing.Brush


        Select Case cor1
            Case "verde"
                color(1) = System.Drawing.Brushes.Green
                color(2) = System.Drawing.Brushes.DarkSeaGreen
            Case "laranja"
                color(1) = Drawing.Brushes.DarkOrange
                color(2) = System.Drawing.Brushes.Orange
            Case "vinho"
                color(1) = Drawing.Brushes.Firebrick
                color(2) = System.Drawing.Brushes.Red
            Case "amarelo"
                color(1) = Drawing.Brushes.Orange
                color(2) = System.Drawing.Brushes.Yellow
            Case Else
                color(1) = System.Drawing.Brushes.Black
                color(2) = System.Drawing.Brushes.DarkGray
        End Select

        brush = color(1)



        graph.FillRegion(Drawing.Brushes.White, New System.Drawing.Region(New Drawing.RectangleF(0, 0, w * 2, h)))

        Dim rect2 As New Drawing.Rectangle(w - x, h - Math.Ceiling(h * (pct / 100)) + 10, w / 3, Math.Ceiling(h * (pct / 100)))
        Dim rect As New Drawing.Rectangle(x, h - Math.Ceiling(h * (pct / 100)), w, Math.Ceiling(h * (pct / 100)))

        Dim points(2) As Drawing.Point
        points(0) = New Point(w, h - Math.Ceiling(h * (pct / 100)))
        points(1) = New Point(w, h - Math.Ceiling(h * (pct / 100)) + 10)
        points(2) = New Point(w + (w / 3), h - Math.Ceiling(h * (pct / 100)) + 10)



        graph.DrawRectangle(New Drawing.Pen(color(1)), rect)
        graph.FillRectangle(brush, rect)

        brush = color(2)

        graph.DrawRectangle(New Drawing.Pen(color(2)), rect2)
        graph.FillRectangle(brush, rect2)

        graph.DrawPolygon(New Drawing.Pen(color(2)), points)
        graph.FillPolygon(color(2), points)



        Response.ContentType = "image/png"


        b.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Jpeg)
        Response.End()







    End Sub

    Public Sub createGraphIndex(ByVal cor1 As String)

        x = 0
        y = 0
        Dim stream As New IO.MemoryStream
        Dim b As New System.Drawing.Bitmap(w, h, Drawing.Imaging.PixelFormat.Format16bppRgb555)
        Dim graph As Drawing.Graphics = Graphics.FromImage(b)
        Dim color(2) As Drawing.Brush

        b.SetResolution(300, 300)

        Dim brush As Drawing.Brush


        Select Case cor1
            Case "verde"
                color(1) = System.Drawing.Brushes.Green
                color(2) = System.Drawing.Brushes.GreenYellow
            Case "laranja"
                color(1) = Drawing.Brushes.DarkOrange
                color(2) = System.Drawing.Brushes.Orange
            Case "vinho"
                color(1) = Drawing.Brushes.Firebrick
                color(2) = System.Drawing.Brushes.Red
            Case "amarelo"
                color(1) = Drawing.Brushes.Orange
                color(2) = System.Drawing.Brushes.Yellow
            Case Else
                color(1) = System.Drawing.Brushes.Black
                color(2) = System.Drawing.Brushes.DarkGray
        End Select

        brush = color(1)



        graph.FillRegion(brush, New System.Drawing.Region(New Drawing.RectangleF(0, 0, w, h)))


        Response.ContentType = "image/png"


        b.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Jpeg)
        Response.End()







    End Sub

End Class

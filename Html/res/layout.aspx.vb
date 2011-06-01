Partial Class layout
    Inherits System.Web.UI.Page
    Public a As String

    Public count As Integer
    Public dsXml As New DataSet
    Public ds As New DataSet
    Public i, j As Integer
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here




        Dim a As New SqlClient.SqlDataAdapter("select top 10 * from texto t inner join area a on t.id_area = a.id_area inner join imagem_texto i on t.id_texto = i.id_texto where a.nomept = @area order by data desc", g.cn)

        a.SelectCommand.Parameters.Add("@area", "Notícias")

        If ds.Tables.Contains("noticia") Then ds.Tables.Remove("noticia")
        a.Fill(ds, "noticia")

        count = ds.Tables("noticia").DefaultView.Count


        a.SelectCommand.CommandText = "select top 1 t.id_texto, id_imagem, cast(titulo as char(60)) as titulo, texto, data from texto t inner join area a on t.id_area = a.id_area inner join imagem_texto i on t.id_texto = i.id_texto where a.nomept = @area order by data desc"
        a.SelectCommand.Parameters("@area").Value = "Dicas de Saúde"

        If ds.Tables.Contains("saude") Then ds.Tables.Remove("saude")
        a.Fill(ds, "saude")
        If ds.Tables("saude").DefaultView.Count > 0 Then
            lblTitSaude.Text = ds.Tables("saude").DefaultView(0).Item("titulo") & "..."
            lnkMaisSaude.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("saude").DefaultView(0).Item("id_texto"))
            imgSaude.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=72&id=" & System.Convert.ToString(ds.Tables("saude").DefaultView(0).Item("id_imagem"))
            If System.Convert.ToString(ds.Tables("saude").DefaultView(0).Item("id_imagem")) = "" Then imgSaude.Visible = False
        End If

        a.SelectCommand.Parameters("@area").Value = "Viagens"

        If ds.Tables.Contains("viagem") Then ds.Tables.Remove("viagem")
        a.Fill(ds, "viagem")
        If ds.Tables("viagem").DefaultView.Count > 0 Then
            lblTitViagens.Text = ds.Tables("viagem").DefaultView(0).Item("titulo") & "..."
            lnkMaisViagens.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("viagem").DefaultView(0).Item("id_texto"))
            imgViagens.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=72&id=" & System.Convert.ToString(ds.Tables("viagem").DefaultView(0).Item("id_imagem"))
            If System.Convert.ToString(ds.Tables("viagem").DefaultView(0).Item("id_imagem")) = "" Then imgViagens.Visible = False
        End If

        Dim b As New SqlClient.SqlDataAdapter("select day(dtnasc) as [data], nome, showaniver from guest.usuario where showaniver = @aniver and month(dtnasc) = @mes order by [data] asc", g.cn)

        b.SelectCommand.Parameters.Add("@aniver", True)
        b.SelectCommand.Parameters.Add("@mes", Date.Now.Month)

        If ds.Tables.Contains("aniver") Then ds.Tables.Remove("aniver")
        b.Fill(ds, "aniver")

        lstAniver.DataSource = ds
        lstAniver.DataMember = "aniver"

        lstAniver.DataBind()

        lblMes.Text = UCase(afabre.g.getMes(Date.Now).Chars(0)) & Right(afabre.g.getMes(Date.Now), afabre.g.getMes(Date.Now).Length - 1)

		default1.GetRecipes(lstReceitas)

		Using stream As New System.IO.FileStream(Server.MapPath("../xml/menu.xml"), IO.FileMode.Open, IO.FileAccess.Read)

			Dim rdXml As New System.Xml.XmlTextReader(stream)

			dsXml.ReadXml(rdXml)

			lstMenu.DataBind()

		End Using
	End Sub




End Class

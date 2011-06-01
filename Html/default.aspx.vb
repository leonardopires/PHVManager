Imports System.Data.SqlClient

Partial Class default1
	Inherits System.Web.UI.Page

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

		If ds.Tables("noticia").DefaultView.Count >= 1 Then
			lblDateHeadline.Text = System.Convert.ToDateTime(ds.Tables("noticia").DefaultView(0).Item("data")).ToShortDateString
			lblTitleHeadline.Text = ds.Tables("noticia").DefaultView(0).Item("titulo")
			lblIntroHeadline.Text = Left(System.Convert.ToString(ds.Tables("noticia").DefaultView(0).Item("texto")), 255)
			imgHeadline.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=104&id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(0).Item("id_imagem"))
			'lnkLeiaMaisHeadline.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & "noticias/noticias.aspx?id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(0).Item("id_texto"))
			lnkLeiaMaisHeadline.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(0).Item("id_texto"))
			If System.Convert.ToString(ds.Tables("noticia").DefaultView(0).Item("id_imagem")) = "" Then imgHeadline.Visible = False
		End If

		If count = 2 Or count = 4 Then lblTitle1.Font.Size = Web.UI.WebControls.FontUnit.Parse("13pt")


		If ds.Tables("noticia").DefaultView.Count >= 2 Then
			lblDate1.Text = System.Convert.ToDateTime(ds.Tables("noticia").DefaultView(1).Item("data")).ToShortDateString
			lblTitle1.Text = ds.Tables("noticia").DefaultView(1).Item("titulo")
			lblTexto1.Text = Left(System.Convert.ToString(ds.Tables("noticia").DefaultView(1).Item("texto")), 96)
			img1.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=72&id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(1).Item("id_imagem"))
			lnkNoticia1.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(1).Item("id_texto"))
			If System.Convert.ToString(ds.Tables("noticia").DefaultView(1).Item("id_imagem")) = "" Then img1.Visible = False
		End If

		If ds.Tables("noticia").DefaultView.Count >= 3 Then
			lblDate2.Text = System.Convert.ToDateTime(ds.Tables("noticia").DefaultView(2).Item("data")).ToShortDateString
			lblTitle2.Text = ds.Tables("noticia").DefaultView(2).Item("titulo")
			lblTexto2.Text = Left(System.Convert.ToString(ds.Tables("noticia").DefaultView(2).Item("texto")), 96)
			img2.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=72&id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(2).Item("id_imagem"))
			lnkNoticia2.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(2).Item("id_texto"))
			If System.Convert.ToString(ds.Tables("noticia").DefaultView(2).Item("id_imagem")) = "" Then img2.Visible = False
		End If

		If ds.Tables("noticia").DefaultView.Count >= 4 Then
			lblDate3.Text = System.Convert.ToDateTime(ds.Tables("noticia").DefaultView(3).Item("data")).ToShortDateString
			lblTitle3.Text = ds.Tables("noticia").DefaultView(3).Item("titulo")
			img3.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=72&id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(3).Item("id_imagem"))
			lblTexto3.Text = Left(System.Convert.ToString(ds.Tables("noticia").DefaultView(3).Item("texto")), 96)
			lnkNoticia3.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(3).Item("id_texto"))
			If System.Convert.ToString(ds.Tables("noticia").DefaultView(3).Item("id_imagem")) = "" Then img3.Visible = False
		End If

		If ds.Tables("noticia").DefaultView.Count >= 5 Then
			lblDate4.Text = System.Convert.ToDateTime(ds.Tables("noticia").DefaultView(4).Item("data")).ToShortDateString
			img4.ImageUrl = g.getRoot(Me.Page) & "/remote/res/getimage.aspx?a=get&w=72&id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(4).Item("id_imagem"))
			lblTitle4.Text = ds.Tables("noticia").DefaultView(4).Item("titulo")
			lblTexto4.Text = Left(System.Convert.ToString(ds.Tables("noticia").DefaultView(4).Item("texto")), 96)
			lnkNoticia4.NavigateUrl = g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/res/gettexto.aspx?id=" & System.Convert.ToString(ds.Tables("noticia").DefaultView(4).Item("id_texto"))
			If System.Convert.ToString(ds.Tables("noticia").DefaultView(4).Item("id_imagem")) = "" Then img4.Visible = False
		End If





		If ds.Tables("noticia").DefaultView.Count > 5 Then

			For i = 0 To 4
				ds.Tables("noticia").DefaultView.Delete(0)
			Next

			lstNoticias.DataSource = ds
			lstNoticias.DataMember = "noticia"
			lstNoticias.DataKeyField = "id_texto"
			lstNoticias.DataBind()

		End If


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

		Dim r As New SqlClient.SqlDataAdapter("select top 1 id_questao from questao order by [data] desc", g.cn)

		If ds.Tables.Contains("questao") Then ds.Tables.Remove("questao")
		r.Fill(ds, "questao")

		If ds.Tables("questao").DefaultView.Count > 0 Then

			Dim q As New SqlClient.SqlDataAdapter("select q.nome as pergunta, r.nome as nome, r.id_resposta, q.id_questao from resposta r inner join questao q on r.id_questao = q.id_questao and q.id_questao = @questao order by nome asc", g.cn)
			q.SelectCommand.Parameters.Add("@questao", ds.Tables("questao").DefaultView(0).Item("id_questao"))

			If ds.Tables.Contains("enquete") Then ds.Tables.Remove("enquete")
			q.Fill(ds, "enquete")

			If ds.Tables("enquete").DefaultView.Count > 0 Then
				lblQuestao.Text = ds.Tables("enquete").DefaultView(0).Item("pergunta")
				rblResposta.DataValueField = "id_resposta"
				rblResposta.DataBind()

			End If
		End If

		GetRecipes(lstReceitas)

		Using stream As New System.IO.FileStream(Server.MapPath(g.getRoot(Me.Page)) & "\xml\menu.xml", IO.FileMode.Open, IO.FileAccess.Read)

			Dim rdXml As New System.Xml.XmlTextReader(stream)

			dsXml.ReadXml(rdXml)

			lstMenu.DataBind()
		End Using
	End Sub


	Public Shared Sub GetRecipes(ByVal list As DataList)

		Using connection As SqlConnection = AfabreLib.AfabreHelper.CreateConnection()

			Using command As New SqlClient.SqlCommand("select top 15 * from texto t inner join area a on t.id_area = a.id_area inner join imagem_texto i on t.id_texto = i.id_texto where a.nomept = @area order by data desc", connection)

				command.Parameters.AddWithValue("@area", "Receitas")

				connection.Open()

				Using reader As SqlDataReader = command.ExecuteReader()
					list.DataSource = reader
					list.DataBind()
				End Using

			End Using
		End Using

	End Sub

	Private Sub btnVotar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVotar.Click

		'If rblResposta.SelectedValue <> "" Then
		Dim a As New SqlClient.SqlDataAdapter("select * from questao", g.cn)

		a.UpdateCommand = New SqlClient.SqlCommand("update resposta set hits = hits + 1 where id_resposta = @resposta", g.cn)

		a.UpdateCommand.Parameters.Add("@resposta", SqlTypes.SqlGuid.Parse(Request.Form.Item("rblResposta").ToString))

		g.cn.Close()
		g.cn.Open()
		a.UpdateCommand.ExecuteNonQuery()
		g.cn.Close()

		Response.Write("<script language=""javascript"">window.location.href=""javascript:window.open('enquete/enquete.aspx', 'enquete', 'menubar=no, links=no, toolbar=no, width=446, height=390');history.back();""</script>")
		'End If
	End Sub


	Private Sub btnBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusca.Click
		Response.Redirect(g.getRoot(Me.Page) & "/res/layout.aspx?url=" & g.getRoot(Me.Page) & "/busca/busca.aspx?q=" & Server.UrlEncode(txtBusca.Text))
	End Sub
End Class

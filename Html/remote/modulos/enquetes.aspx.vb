Imports System.Data.SqlClient
Imports AfabreLib

Partial Class enquetes
	Inherits System.Web.UI.Page


	Public cleantext As New cleanText.cleanEngine
	Public i, j As Integer
	Public ds, dsxml, dsxml2, dstmp As New DataSet

	Public dtable As New Data.DataTable



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
		If Not g.logged Then g.unlogged(Me.Page)
		If Not IsPostBack Then
			If Request.QueryString("del") = "true" Then delquestao()


			'testa se o usuário tem acesso ao modulo "Produtos"
			Using cn As SqlConnection = AfabreHelper.CreateConnection()

				Dim a As New SqlClient.SqlDataAdapter("select nome, id_questao from questao order by [data] desc", cn)

				If g.ds.Tables.Contains("questao") Then g.ds.Tables("questao").Clear()
				a.Fill(g.ds, "questao")

				lstTextos.DataSource = g.ds
				lstTextos.DataMember = "questao"
				lstTextos.DataTextField = "nome"

				lstTextos.DataValueField = "id_questao"

				lstTextos.DataBind()



				dsxml.ReadXml(Server.MapPath(g.getRoot(Me.Page) & "/xml/modulos.xml"))

				For i = 0 To dsxml.Tables("modulo").DefaultView.Count - 1
					If i <= dsxml.Tables("modulo").DefaultView.Count - 1 Then
						If Not System.Convert.ToBoolean(dsxml.Tables("modulo").DefaultView(i).Item("ativado")) Then
							dsxml.Tables("modulo").DefaultView(i).Delete()
							dsxml.Tables("modulo").AcceptChanges()
						End If
					End If
				Next

				dsxml.Tables("modulo").DefaultView.Sort = "nome ASC"

				dsxml2.Tables.Add("modulo")

				dsxml2.Tables("modulo").Columns.Add("nome")
				dsxml2.Tables("modulo").Columns.Add("url")


				dsxml2.Tables("modulo").DefaultView.AddNew()
				dsxml2.Tables("modulo").DefaultView(0).Item("nome") = "Home"
				dsxml2.Tables("modulo").DefaultView(0).Item("url") = "../default"


				For i = 0 To dsxml.Tables("modulo").DefaultView.Count - 1
					dsxml2.Tables("modulo").DefaultView.AddNew()
					dsxml2.Tables("modulo").DefaultView(dsxml2.Tables("modulo").DefaultView.Count - 1).Item("nome") = dsxml.Tables("modulo").DefaultView(i).Item("nome")
					dsxml2.Tables("modulo").DefaultView(dsxml2.Tables("modulo").DefaultView.Count - 1).Item("url") = dsxml.Tables("modulo").DefaultView(i).Item("url")

				Next


				lstAlterna.DataSource = dsxml2.Tables("modulo")
				lstAlterna.DataBind()

				lstAlterna.Items.FindByValue("enquetes").Selected = True

			End Using

		End If

	End Sub

	Public Sub delquestao()

		Using cn As SqlConnection = AfabreHelper.CreateConnection()
			Dim d As New SqlClient.SqlCommand("delete from resposta where id_questao = @pId", cn)

			d.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Request.QueryString.Item("uid"))))

			cn.Open()
			d.ExecuteNonQuery()

			d.CommandText = "delete from questao where id_questao = @pId"

			d.ExecuteNonQuery()
			cn.Close()

			Response.Redirect(Request.FilePath)
		End Using
	End Sub
	Public Sub insertQuestao()

		Using cn As SqlConnection = AfabreHelper.CreateConnection()


			Dim dt As DateTime
			Dim s As New SqlClient.SqlCommand("insert into questao (nome, [data]) values (@nome, @data)", cn)

			dt = Date.Now

			s.Parameters.Add("@data", dt)
			s.Parameters.Add("@nome", txtQuestao.Text)

			cn.Open()
			s.ExecuteNonQuery()

			Session.Add("dt", dt)

			updateRespostas()


			Erro("A questão " & txtQuestao.Text & " foi adicionada com sucesso", remote.erro.SUCESSO)

		End Using

	End Sub

	Public Sub updateQuestao()

		Using cn As SqlConnection = AfabreHelper.CreateConnection()
			Dim u As New SqlClient.SqlCommand("update questao set nome = @nome where id_questao = @pID", cn)

			If txtQuestao.Text = String.Empty Or txtResposta1.Text = String.Empty Or txtResposta2.Text = String.Empty Or txtResposta3.Text = String.Empty Then Erro("Você precisa digitar um nome e três respostas para a questao")

			u.Parameters.Add("@nome", txtQuestao.Text)
			u.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("lstTextos.id"))))

			cn.Open()
			u.ExecuteNonQuery()

			updateRespostas()

			Session.Remove("lstTextos.id")

			Erro("O questao " & txtQuestao.Text & " foi atualizado com sucesso", remote.erro.SUCESSO)

		End Using

	End Sub
#Region "Funções Comuns"
	Public Function getDataExt(ByVal data As DateTime) As String
		Return g.getDataExt(data)
	End Function
	Public Sub Erro(ByVal msg As String, Optional ByVal n As Integer = 0, Optional ByVal a As String = "")
		Session.Add("activepage", Request.FilePath)
		Response.Redirect("../res/erro.aspx?e=" & n & "&msg=" & msg & "&a=" & a)
	End Sub
#End Region

	Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

		If System.Convert.ToString(Request.Form.Item("lstTextos")) = "" Then Erro("Você precisa selecionar a questão a ser removida na caixa de listagem.")
		Erro("Você tem certeza que deseja excluir a questão" & System.Convert.ToString(lstTextos.SelectedItem.Text).TrimEnd & " ?", remote.erro.CONFIRM, Request.Path & "?del=true" & "&uid=" & System.Convert.ToString(Request.Form.Item("lstTextos")))


	End Sub

	Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		lstTextos.Enabled = False
		btnAdd.Enabled = False
		btnDel.Enabled = False
		btnEdit.Enabled = False
		txtQuestao.Enabled = True
		txtResposta1.Enabled = True
		txtResposta3.Enabled = True
		txtResposta2.Enabled = True


		btnOk.Enabled = True
		btnCancel.Enabled = True
	End Sub

	Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

		If Request.Form.Item("lstTextos") = String.Empty Then Erro("Você precisa selecionar um item da lista para ser editado")

		lstTextos.Enabled = False
		btnAdd.Enabled = False
		btnDel.Enabled = False
		btnEdit.Enabled = False
		txtQuestao.Enabled = True
		txtResposta1.Enabled = True
		txtResposta2.Enabled = True
		txtResposta3.Enabled = True
		btnOk.Enabled = True
		btnCancel.Enabled = True

		Using cn As SqlConnection = AfabreHelper.CreateConnection()
			Dim a As New SqlClient.SqlDataAdapter("select q.nome, q.id_questao as id_institucional, r.nome as resp from questao q inner join resposta r on q.id_questao = r.id_questao where q.id_questao= @pId", cn)

			a.SelectCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Request.Form("lstTextos"))))


			If g.ds.Tables.Contains("questao") Then g.ds.Tables.Remove("questao")

			a.Fill(g.ds, "questao")

			txtQuestao.Text = System.Convert.ToString(g.ds.Tables("questao").DefaultView(0).Item("nome")).TrimEnd
			txtResposta1.Text = System.Convert.ToString(g.ds.Tables("questao").DefaultView(0).Item("resp")).TrimEnd
			txtResposta2.Text = System.Convert.ToString(g.ds.Tables("questao").DefaultView(1).Item("resp")).TrimEnd
			txtResposta3.Text = System.Convert.ToString(g.ds.Tables("questao").DefaultView(2).Item("resp")).TrimEnd

			Session.Add("lstTextos.id", System.Convert.ToString(Request.Form.Item("lstTextos")))
		End Using

	End Sub

	Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

		If txtQuestao.Text = String.Empty Or txtResposta1.Text = String.Empty Or txtResposta2.Text = String.Empty Or txtResposta3.Text = String.Empty Then Erro("Você precisa digitar um nome e três respostas para a questao")


		If Session.Item("lstTextos.id") = "" Then
			insertQuestao()
		Else
			updateQuestao()
		End If

	End Sub

	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		lstTextos.Enabled = True
		btnAdd.Enabled = True
		btnDel.Enabled = True
		btnEdit.Enabled = True
		txtQuestao.Enabled = False
		txtResposta1.Enabled = False
		txtResposta2.Enabled = False
		txtResposta3.Enabled = False
		btnOk.Enabled = False
		btnCancel.Enabled = False



		txtQuestao.Text = ""
		txtResposta1.Text = ""
		txtResposta2.Text = ""
		txtResposta3.Text = ""


		If Session.Item("lstTextos.id") <> "" Then Session.Remove("lstTextos.id")
	End Sub
	Private Sub btnIr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		Response.Redirect(g.getRoot(Me.Page) & "/modulos/" & Request.Form.Item("lstAlterna") & ".aspx")

	End Sub

	Public Sub updateRespostas()
		Using cn As SqlConnection = AfabreHelper.CreateConnection()
			Dim a As New SqlClient.SqlDataAdapter("select * from questao where [data] = @date", cn)

			a.DeleteCommand = New SqlClient.SqlCommand("delete from resposta where id_questao = @questao", cn)

			If Session.Item("lstTextos.id") = "" Then
				a.SelectCommand.Parameters.Add("@date", Session.Item("dt"))

				If ds.Tables.Contains("resposta1") Then ds.Tables.Remove("resposta1")
				a.Fill(ds, "resposta1")
				a.DeleteCommand.Parameters.Add("@questao", ds.Tables("resposta1").DefaultView(0).Item("id_questao"))
			Else
				a.DeleteCommand.Parameters.Add("@questao", Session.Item("lstTextos.id"))
			End If

			cn.Open()
			a.DeleteCommand.ExecuteNonQuery()

			a.InsertCommand = New SqlClient.SqlCommand("insert into resposta (id_questao, nome, hits) values (@questao, @nome, @hits)", cn)

			a.InsertCommand.Parameters.Add("@questao", a.DeleteCommand.Parameters("@questao").Value)

			a.InsertCommand.Parameters.Add("@hits", 0)

			a.InsertCommand.Parameters.Add("@nome", "")

			Dim arrnome(3) As String
			arrnome(1) = txtResposta1.Text
			arrnome(2) = txtResposta2.Text
			arrnome(3) = txtResposta3.Text

			For i = 1 To 3
				a.InsertCommand.Parameters("@nome").Value = arrnome(i)

				a.InsertCommand.ExecuteNonQuery()
			Next
		End Using

	End Sub

End Class

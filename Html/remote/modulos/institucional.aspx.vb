Partial Class institucional1
    Inherits System.Web.UI.Page

    Public cleantext As New cleanText.cleanEngine
    Public i, j As Integer

    Public ds, dsxml, dsxml2 As New DataSet


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
            If Request.QueryString("del") = "true" Then delTexto()

            'testa se o usuário tem acesso ao modulo "Produtos"

            Dim a As New SqlClient.SqlDataAdapter("select cast(t.titulo as char(1024)) as nome, t.id_texto as id_institucional from texto t inner join area a on t.id_area = a.id_area where a.nomept=@area order by nome asc", g.cn)
            a.SelectCommand.Parameters.Add("@area", "Institucional")

            If g.ds.Tables.Contains("texto") Then g.ds.Tables("texto").Clear()
            a.Fill(g.ds, "texto")

            lstTextos.DataSource = g.ds
            lstTextos.DataMember = "texto"
            lstTextos.DataTextField = "nome"
            lstTextos.DataValueField = "id_institucional"

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

            lstAlterna.Items.FindByValue("institucional").Selected = True




        End If

    End Sub

    Public Sub delTexto()

        Dim d As New SqlClient.SqlCommand("delete from texto where id_texto = @pId", g.cn)

        d.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Request.QueryString.Item("uid"))))

        g.cn.Close()
        g.cn.Open()
        d.ExecuteNonQuery()
        g.cn.Close()

        Response.Redirect(Request.FilePath)

    End Sub
    Public Sub insertProblema()

        Dim a As New SqlClient.SqlDataAdapter("select * from area where nomept = @area", g.cn)
        a.SelectCommand.Parameters.Add("@area", "Institucional")

        Dim ds As New DataSet
        a.Fill(ds, "area")

        Dim s As New SqlClient.SqlCommand("insert into texto (titulo, texto, id_area) values (@pNome, @pTexto, @area)", g.cn)

        s.Parameters.Add("@pNome", txtNome.Text)
        s.Parameters.Add("@pTexto", txtTexto.Text)
        s.Parameters.Add("@area", ds.Tables("area").DefaultView(0).Item("id_area"))

        g.cn.Close()
        g.cn.Open()
        s.ExecuteNonQuery()
        g.cn.Close()


        Erro("O texto " & txtNome.Text & " foi adicionado com sucesso", remote.erro.SUCESSO)


    End Sub

    Public Sub updateProblema()


        Dim u As New SqlClient.SqlCommand("update texto set titulo = @pNome,  texto = @pTexto where id_texto = @pID", g.cn)

        If txtNome.Text = String.Empty Or txtTexto.Text = String.Empty Then Erro("Você precisa digitar um nome e um texto descritivo para a aplicação")

        u.Parameters.Add("@pNome", txtNome.Text)
        u.Parameters.Add("@pTexto", txtTexto.Text)
        u.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("lstTextos.id"))))

        g.cn.Close()
        g.cn.Open()
        u.ExecuteNonQuery()
        g.cn.Close()

        Session.Remove("lstTextos.id")

        Erro("O texto " & txtNome.Text & " foi atualizado com sucesso", remote.erro.SUCESSO)


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

        If System.Convert.ToString(Request.Form.Item("lstTextos")) = "" Then Erro("Você precisa selecionar a aplicação a ser removida na caixa de listagem.")
        Erro("Você tem certeza que deseja excluir o texto" & System.Convert.ToString(lstTextos.SelectedItem.Text).TrimEnd & " ?", remote.erro.CONFIRM, Request.Path & "?del=true" & "&uid=" & System.Convert.ToString(Request.Form.Item("lstTextos")))


    End Sub

    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lstTextos.Enabled = False
        btnAdd.Enabled = False
        btnDel.Enabled = False
        btnEdit.Enabled = False
        txtNome.Enabled = True
        txtTexto.Enabled = True
        btnOk.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If Request.Form.Item("lstTextos") = String.Empty Then Erro("Você precisa selecionar um item da lista para ser editado")

        lstTextos.Enabled = False
        btnAdd.Enabled = False
        btnDel.Enabled = False
        btnEdit.Enabled = False
        txtNome.Enabled = True
        txtTexto.Enabled = True
        btnOk.Enabled = True
        btnCancel.Enabled = True


        Dim a As New SqlClient.SqlDataAdapter("select cast(t.titulo as char(1024)) as nome, t.texto, t.id_texto as id_institucional from texto t inner join area a on t.id_area = a.id_area where id_texto= @pId and a.nomept=@area", g.cn)

        a.SelectCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Request.Form("lstTextos"))))
        a.SelectCommand.Parameters.Add("@area", "Institucional")

        If g.ds.Tables.Contains("texto") Then g.ds.Tables.Remove("texto")

        a.Fill(g.ds, "texto")

        txtNome.Text = System.Convert.ToString(g.ds.Tables("texto").DefaultView(0).Item("nome")).TrimEnd
        txtTexto.Text = System.Convert.ToString(g.ds.Tables("texto").DefaultView(0).Item("texto")).TrimEnd

        Session.Add("lstTextos.id", System.Convert.ToString(Request.Form.Item("lstTextos")))

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If txtNome.Text = String.Empty Or txtTexto.Text = String.Empty Then Erro("Você precisa digitar um nome e um texto descritivo para a aplicação")

        cleantext.Clean(txtTexto)

        If Session.Item("lstTextos.id") = "" Then
            insertProblema()
        Else
            updateProblema()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lstTextos.Enabled = True
        btnAdd.Enabled = True
        btnDel.Enabled = True
        btnEdit.Enabled = True
        txtNome.Enabled = False
        txtTexto.Enabled = False
        btnOk.Enabled = False
        btnCancel.Enabled = False



        txtNome.Text = ""
        txtTexto.Text = ""


        If Session.Item("lstTextos.id") <> "" Then Session.Remove("lstTextos.id")
    End Sub
    Private Sub btnIr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect(g.getRoot(Me.Page) & "/modulos/" & Request.Form.Item("lstAlterna") & ".aspx")

    End Sub

End Class

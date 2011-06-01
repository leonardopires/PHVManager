Partial Class saude1

    Inherits System.Web.UI.Page

    Public frmImg As String

    Public i As Integer

    Public ds, dsxml, dsxml2 As New DataSet

    Public cleanText As New cleanText.cleanEngine

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



        If g.logged Then

            'Dim a As New SqlClient.SqlDataAdapter("select t.titulo as  chamada, t.id_texto as id_noticia, t.texto, t.[data], id_imagem='a' from texto t inner join area a on t.id_area = a.id_area where a.nomept=@area", g.cn)
            'Dim a As New SqlClient.SqlDataAdapter("select t.titulo as chamada, t.id_texto as id_noticia, t.texto, i.id_imagem from texto t inner join area a on t.id_area = a.id_area inner join imagem_texto i on t.id_texto = i.id_texto where month(t.[data]) = month(@date) and year(t.[data]) = year(@date) and a.nomept = @area order by [data] desc", g.cn)

            Dim a As New SqlClient.SqlDataAdapter("select n.titulo as chamada, n.id_texto as id_noticia, n.data, n.texto as texto, i.id_texto, i.id_imagem from texto n inner join area a on n.id_area = a.id_area inner join imagem_texto i on n.id_texto = i.id_texto where month(n.[data]) = month(@date) and year(n.[data]) = year(@date) and a.nomept = @area order by n.[data] desc", g.cn)
            a.SelectCommand.Parameters.Add("@date", Date.Now)
            a.SelectCommand.Parameters.Add("@area", "Dicas de Saúde")

            g.ds.Clear()

            'testa se o usuário tem acesso ao modulo "Dicas de Saúde"

            If Not IsPostBack Then

                Session.Remove("fotoID")

                If Request.QueryString("del") = "true" Then
                    delNoticia(SqlTypes.SqlGuid.Parse(Request.QueryString("uid")))

                    Response.Redirect(Request.FilePath)
                End If

                g.ds.Clear()
                a.Fill(g.ds, "noticia")


                Session.Add("frmImg", "../res/getImage.aspx?a=select")

                lstNoticias.DataSource = g.ds
                lstNoticias.DataMember = "noticia"
                lstNoticias.DataKeyField = "id_noticia"
                lstNoticias.DataBind()

            End If



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

            lstAlterna.Items.FindByValue("saude").Selected = True


            a.SelectCommand.CommandText = "select n.titulo as chamada, n.id_texto as id_noticia, n.data, n.texto as texto, i.id_texto, i.id_imagem from texto n inner join area a on n.id_area = a.id_area inner join imagem_texto i on n.id_texto = i.id_texto where a.nomept = @area order by n.[data] desc"
            '            a.SelectCommand.Parameters.Add("@area", "Dicas de Saúde")

            If g.ds.Tables.Contains("dataNoticia") Then g.ds.Tables("dataNoticia").Clear()
            a.Fill(g.ds, "dataNoticia")

            For i = 0 To g.ds.Tables("dataNoticia").DefaultView.Count - 1

                calNews.SelectedDates.Add(g.ds.Tables("dataNoticia").DefaultView(i).Item("data"))

            Next
        Else
            g.unlogged(Me.Page)

        End If



    End Sub

#Region "Subrotinas de Interface + DB"
    Private Sub btnIr_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnIr.Click


        Dim a As New SqlClient.SqlDataAdapter("select * from noticia n inner join imagem_noticia i on n.id_noticia = i.id_noticia where chamada like @pChamada or texto like @pTexto  order by data desc", g.cn)
        a.SelectCommand.Parameters.Add("@pChamada", "%" & txtBusca.Text & "%")
        a.SelectCommand.Parameters.Add("@pTexto", "%" & txtBusca.Text & "%")

        If g.ds.Tables.Contains("buscanoticia") Then g.ds.Tables("buscanoticia").Clear()
        a.Fill(g.ds, "buscanoticia")



        lstNoticias.DataSource = g.ds
        lstNoticias.DataMember = "buscanoticia"
        lstNoticias.DataKeyField = "id_noticia"
        lstNoticias.DataBind()




        For i = 0 To g.ds.Tables("buscanoticia").DefaultView.Count - 1

            calNews.SelectedDates.Add(g.ds.Tables("buscanoticia").DefaultView(i).Item("data"))

        Next

    End Sub

    Private Sub btnPublish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPublish.Click

        If txtMateria.Text.Length > 1 And txtChamada.Text.Length > 1 Then

            cleanText.Clean(txtMateria)

            If Session.Item("noticiaAction") = "update" Then


                Dim d As New SqlClient.SqlCommand("update texto set titulo = @pChamada, texto = @pTexto where id_texto = @pId", g.cn)

                d.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("noticiaID"))))

                d.Parameters.Add("@pTexto", txtMateria.Text)
                d.Parameters.Add("@pChamada", txtChamada.Text)

                g.cn.Close()
                g.cn.Open()
                d.ExecuteNonQuery()
                g.cn.Close()

                If Not System.Convert.ToString(Session.Item("fotoID")) = "" Then
                    d.CommandText = "update imagem_texto set id_imagem = @pFotoID where id_texto = @pId"
                    d.Parameters.Add("@pFotoID", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("fotoID"))))

                    g.cn.Close()
                    g.cn.Open()
                    d.ExecuteNonQuery()
                    g.cn.Close()
                End If

                Session.Add("frmImg", "../res/getImage.aspx?a=select")
                Session.Remove("noticiaAction")
                Session.Remove("fotoID")
                Response.Redirect(Request.FilePath)

            Else
                insertNoticia()
            End If
        Else
            Erro("Você precisa digitar um título e um texto para adicionar ou editar uma notícia.")
        End If



    End Sub

    Private Sub calNews_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calNews.SelectionChanged

        Dim a As New SqlClient.SqlDataAdapter("select n.texto as chamada, n.id_texto as id_noticia, n.data, n.texto, i.id_texto, i.id_imagem from texto n inner join area a on n.id_area = a.id_area inner join imagem_texto i on n.id_texto = i.id_texto where a.nomept = @area and month(data) = month(@pData) and day(data) = day(@pData) and year(data) = year(@pData) order by data desc", g.cn)

        a.SelectCommand.Parameters.Add("@pData", calNews.SelectedDate.Date)
        a.SelectCommand.Parameters.Add("@area", "Dicas de Saúde")

        If g.ds.Tables.Contains("buscanoticia") Then g.ds.Tables("buscanoticia").Clear()
        a.Fill(g.ds, "buscanoticia")


        lstNoticias.DataSource = g.ds
        lstNoticias.DataMember = "buscanoticia"
        lstNoticias.DataKeyField = "id_noticia"
        lstNoticias.DataBind()




        a.SelectCommand.CommandText = "select n.texto as chamada, n.id_texto as id_noticia, n.data, n.texto, s.id_texto, s.id_imagem from texto n inner join area a on n.id_area = a.id_area inner join imagem_texto s on n.id_texto = s.id_texto where a.nomept = @area order by n.[data] desc"
        If g.ds.Tables.Contains("dataNoticia") Then g.ds.Tables("dataNoticia").Clear()
        a.Fill(g.ds, "dataNoticia")

        For i = 0 To g.ds.Tables("dataNoticia").DefaultView.Count - 1

            calNews.SelectedDates.Add(g.ds.Tables("dataNoticia").DefaultView(i).Item("data"))

        Next

    End Sub

    Private Sub calNews_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles calNews.VisibleMonthChanged
        Dim a As New SqlClient.SqlDataAdapter("select n.texto as chamada, n.id_texto as id_noticia, n.data, n.texto, i.id_texto, i.id_imagem from texto n inner join area a on a.id_area = n.id_area inner join imagem_texto i on n.id_texto = i.id_texto where a.nomept = @area and month(data) = @pData order by data desc", g.cn)

        a.SelectCommand.Parameters.Add("@pData", e.NewDate.Month)
        a.SelectCommand.Parameters.Add("@area", "Dicas de Saúde")


        If g.ds.Tables.Contains("buscanoticia") Then g.ds.Tables("buscanoticia").Clear()
        a.Fill(g.ds, "buscanoticia")


        lstNoticias.DataSource = g.ds
        lstNoticias.DataMember = "buscanoticia"
        lstNoticias.DataKeyField = "id_noticia"
        lstNoticias.DataBind()




        frmImg = "../res/getImage.aspx?a=select"

        For i = 0 To g.ds.Tables("buscanoticia").DefaultView.Count - 1

            calNews.SelectedDates.Add(g.ds.Tables("buscanoticia").DefaultView(i).Item("data"))

        Next


    End Sub

    Private Sub lstNoticias_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles lstNoticias.DeleteCommand
        ' Code to delete the item from the data source.

        Dim a As New SqlClient.SqlDataAdapter("select id_texto as id_noticia from imagem_texto where id_texto = @pId", g.cn)
        a.SelectCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(lstNoticias.DataKeys(e.Item.ItemIndex))))
        If g.ds.Tables.Contains("delNoticia") Then g.ds.Tables("delNoticia").Clear()
        a.Fill(g.ds, "delNoticia")

        Erro("Você tem certeza que deseja excluir a notícia?", remote.erro.CONFIRMCHECK, Request.Path & "?del=true&chk=" & Server.UrlEncode("Excluir também a imagem do Banco de Imagens") & "&uid=" & System.Convert.ToString(lstNoticias.DataKeys(e.Item.ItemIndex)))

    End Sub

    Private Sub lstNoticias_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles lstNoticias.EditCommand
        editNoticia(SqlTypes.SqlGuid.Parse(System.Convert.ToString(lstNoticias.DataKeys(e.Item.ItemIndex))))
    End Sub
#End Region
#Region "Subrotinas de DB"
    Public Sub editNoticia(ByVal id As SqlTypes.SqlGuid)

        Dim a As New SqlClient.SqlDataAdapter("select n.titulo as chamada, n.texto, n.data, n.id_texto as id_noticia, i.id_imagem from texto n inner join area a on a.id_area = n.id_area inner join imagem_texto i on n.id_texto = i.id_texto where n.id_texto = @pId and a.nomept = @area", g.cn)
        a.SelectCommand.Parameters.Add("@pId", id)
        a.SelectCommand.Parameters.Add("@area", "Dicas de Saúde")

        If g.ds.Tables.Contains("editNoticia") Then g.ds.Tables("editNoticia").Clear()
        a.Fill(g.ds, "editNoticia")

        txtChamada.Text = g.ds.Tables("editNoticia").DefaultView(0).Item("chamada")
        txtMateria.Text = g.ds.Tables("editNoticia").DefaultView(0).Item("texto")
        calNews.SelectedDate = g.ds.Tables("editNoticia").DefaultView(0).Item("data")

        Session.Add("frmImg", "../res/getImage.aspx?a=select&id=" & System.Convert.ToString(g.ds.Tables("editNoticia").DefaultView(0).Item("id_imagem")))

        Session.Add("noticiaID", g.ds.Tables("editNoticia").DefaultView(0).Item("id_noticia"))

        Session.Add("noticiaAction", "update")



    End Sub

    Public Sub delNoticia(ByVal id As SqlTypes.SqlGuid)
        Dim a As New SqlClient.SqlDataAdapter("select * from imagem_texto where id_texto = @pId", g.cn)
        a.SelectCommand.Parameters.Add("@pId", id)
        If g.ds.Tables.Contains("delNoticia") Then g.ds.Tables("delNoticia").Clear()
        a.Fill(g.ds, "delNoticia")


        Dim d As New SqlClient.SqlCommand("delete from imagem_texto where id_texto = @pId", g.cn)
        d.Parameters.Add("@pId", id)
        g.cn.Close()
        g.cn.Open()
        d.ExecuteNonQuery()
        g.cn.Close()

        If Request.QueryString("chk") = "True" Then
            d.CommandText = "delete from guest.imagem where id_imagem = @pIdImagem"
            d.Parameters.Add("@pIdImagem", g.ds.Tables("delNoticia").DefaultView(0).Item("id_imagem"))
            g.cn.Close()
            g.cn.Open()
            d.ExecuteNonQuery()
            g.cn.Close()
        End If

        d.CommandText = "delete from texto where id_texto = @pIdNoticia"
        d.Parameters.Add("@pIdNoticia", id)
        g.cn.Close()
        g.cn.Open()
        d.ExecuteNonQuery()
        g.cn.Close()
    End Sub

    Public Sub insertNoticia()
        Dim a As New SqlClient.SqlDataAdapter("select * from noticia", g.cn)
        Dim data As New DateTime

        data = Date.Now

        Dim b As New SqlClient.SqlDataAdapter("select * from area where nomept=@area", g.cn)
        b.SelectCommand.Parameters.Add("@area", "Dicas de Saúde")

        If ds.Tables.Contains("area") Then ds.Tables.Remove("area")

        b.Fill(ds, "area")




        a.InsertCommand = New SqlClient.SqlCommand("insert into texto (titulo, texto, data, id_area) values (@pChamada, @pTexto, @pData, @area)", g.cn)

        a.InsertCommand.Parameters.Add("@pChamada", txtChamada.Text)
        a.InsertCommand.Parameters.Add("@pTexto", txtMateria.Text)
        a.InsertCommand.Parameters.Add("@pData", data)
        a.InsertCommand.Parameters.Add("@area", ds.Tables("area").DefaultView(0).Item("id_area"))

        g.cn.Close()
        g.cn.Open()
        a.InsertCommand.ExecuteNonQuery()
        g.cn.Close()

        a.SelectCommand.CommandText = "select t.titulo as chamada, t.data, t.id_texto as id_noticia from texto t where (data = @pData and titulo like @pChamada)"
        a.SelectCommand.Parameters.Add("@pData", data)
        a.SelectCommand.Parameters.Add("@pChamada", txtChamada.Text)


        g.ds.Clear()
        a.Fill(g.ds, "noticia")

        If System.Convert.ToString(Session.Item("fotoID")) <> "" Then
            a.InsertCommand.CommandText = "insert into imagem_texto (id_imagem, id_texto) values (@pImg, @pNot)"

            a.InsertCommand.Parameters.Add("@pNot", g.ds.Tables("noticia").DefaultView(0).Item("id_noticia"))
            a.InsertCommand.Parameters.Add("@pImg", Session.Item("fotoID"))

        Else
            a.InsertCommand.CommandText = "insert into imagem_texto (id_texto) values (@pNot)"

            a.InsertCommand.Parameters.Add("@pNot", g.ds.Tables("noticia").DefaultView(0).Item("id_noticia"))
        End If

        g.cn.Open()
        a.InsertCommand.ExecuteNonQuery()
        g.cn.Close()

        Session.Remove("fotoID")
        Response.Redirect(Request.FilePath)
    End Sub
#End Region
#Region "Funções Comuns"
    Public Function getDataExt(ByVal data As DateTime) As String
        Return g.getDataExt(data)
    End Function
    Public Sub Erro(ByVal msg As String, Optional ByVal n As Integer = 0, Optional ByVal a As String = "")
        Session.Add("activepage", Request.FilePath)
        Response.Redirect("../res/erro.aspx?e=" & n & "&msg=" & msg & "&a=" & a)
    End Sub
#End Region


    Private Sub lstNoticias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstNoticias.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect(g.getRoot(Me.Page) & "/modulos/" & Request.Form.Item("lstAlterna") & ".aspx")

    End Sub
End Class



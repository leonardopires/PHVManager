Imports afabre
Partial Class login2
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Session.Item("logged") Then
            pnlLogin.Visible = False
            pnlMenu.Visible = True
            imgMensagens.Visible = False
            lblNome.Text = Session.Item("nome")

        End If

        imgUsuarios.Attributes.Add("onmouseover", "txtMenu.value='Gerenciador de Usuários';")
        imgafabre.Attributes.Add("onmouseover", "txtMenu.value='afabre';")
        imgNoticias.Attributes.Add("onmouseover", "txtMenu.value='Gerenciador de Notícias';")
        imgMensagens.Attributes.Add("onmouseover", "txtMenu.value='Gerenciador de Mensagens';")
        imgArquivos.Attributes.Add("onmouseover", "txtMenu.value='Gerenciador de Arquivos';")
        imgLogoff.Attributes.Add("onmouseover", "txtMenu.value='Efetuar Logoff';")

        imgUsuarios.Attributes.Add("onmouseout", "txtMenu.value='';")
        imgafabre.Attributes.Add("onmouseout", "txtMenu.value='';")
        imgNoticias.Attributes.Add("onmouseout", "txtMenu.value='';")
        imgMensagens.Attributes.Add("onmouseout", "txtMenu.value='';")
        imgArquivos.Attributes.Add("onmouseout", "txtMenu.value='';")
        imgLogoff.Attributes.Add("onmouseout", "txtMenu.value='';")

    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdLogin.Click

        Dim a As New SqlClient.SqlDataAdapter("select distinct id_usuario, username, password,nome from usuario where username = @pUser", g.cn)

        a.SelectCommand.Parameters.Add("@pUser", txtUser.Text)
        g.ds.Clear()

        a.Fill(g.ds, "auth")

        If g.ds.Tables("auth").DefaultView.Count > 0 Then
            If txtUser.Text = System.Convert.ToString(g.ds.Tables("auth").DefaultView.Item(0).Item("username")).TrimEnd And txtPassword.Text.GetHashCode.ToString = System.Convert.ToString(g.ds.Tables("auth").DefaultView.Item(0).Item("password")).TrimEnd Then
                Session.Add("logged", True)
                Session.Add("username", g.ds.Tables("auth").DefaultView.Item(0).Item("username"))
                Session.Add("nome", g.ds.Tables("auth").DefaultView.Item(0).Item("nome"))
                Session.Add("userid", g.ds.Tables("auth").DefaultView.Item(0).Item("id_usuario"))

                pnlLogin.Visible = False
                pnlMenu.Visible = True
                imgMensagens.Visible = False
                lblNome.Text = Session.Item("nome")

            Else

                'Response.Write("senha incorreta<br>" + System.Convert.ToString(g.ds.Tables("auth").DefaultView.Item(0).Item("password")).TrimEnd)
            End If
        End If



    End Sub

    Private Sub imgUsuarios_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgUsuarios.Click, imgMensagens.Click, imgNoticias.Click, imgArquivos.Click, imgafabre.Click
        go(sender)

    End Sub
    Public Sub go(ByVal sender As System.Web.UI.WebControls.ImageButton)

        Redirect.RedirectTo(LCase(Right(sender.ID.ToString, Len(sender.ID.ToString) - 3)).TrimEnd, Me.Page)

    End Sub


    Private Sub imgLogoff_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLogoff.Click
        Session.Abandon()
        Redirect.goHome(Me.Page)
    End Sub

    Private Sub imgProdutos_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgafabre.Click

    End Sub
End Class

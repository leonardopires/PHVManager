Partial Class usuarios
    Inherits System.Web.UI.Page

    Public dsXML As New DataSet
    Public ds As New DataSet
    Public dsXML2, dsXML3 As New DataSet
    Dim i, j As Integer

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
        'testa se o usuário está logado no sistema
        Session.Remove("activepage")

        If g.logged Then


            If Not IsPostBack Then

                If LCase(Request.QueryString("del")) = "true" Then DeleteUser(SqlTypes.SqlGuid.Parse("{" & Request.QueryString("uid") & "}"))

                'cria o adaptador de dados, os parametros e preenche o dataset
                Dim a As New SqlClient.SqlDataAdapter("select distinct username from guest.usuario where username=@pUsername", g.cn)

                a.SelectCommand.Parameters.Add("@pUsername", Session.Item("username"))

                g.ds.Clear()
                a.Fill(g.ds, "usuario")

                'testa se o usuário tem acesso ao modulo "usuários"
                'If g.dsXML.Tables("usuario").DefaultView(0).Item("ativado") Then
                'exibe o módulo usuarios em modo completo
                a.SelectCommand.CommandText = "select username, id_usuario, dtnasc from guest.usuario order by username asc"

                g.ds.Clear()
                a.Fill(g.ds, "usuario")

                lstUsers.DataSource = g.ds
                lstUsers.DataMember = "usuario"
                lstUsers.DataTextField = "username"
                lstUsers.DataValueField = "id_usuario"
                lstUsers.DataBind()

                dsXML.ReadXml(Server.MapPath(g.getRoot(Me.Page) & "/xml/modulos.xml"))

                For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                    If i <= dsXML.Tables("modulo").DefaultView.Count - 1 Then
                        If Not System.Convert.ToBoolean(dsXML.Tables("modulo").DefaultView(i).Item("ativado")) Then
                            dsXML.Tables("modulo").DefaultView(i).Delete()
                            dsXML.Tables("modulo").AcceptChanges()
                        End If
                    End If
                Next

                dsXML.Tables("modulo").DefaultView.Sort = "nome ASC"

                chlModulos.DataValueField = "url"
                chlModulos.DataBind()

                dsXML2.Tables.Add("modulo")

                dsXML2.Tables("modulo").Columns.Add("nome")
                dsXML2.Tables("modulo").Columns.Add("url")


                dsXML2.Tables("modulo").DefaultView.AddNew()
                dsXML2.Tables("modulo").DefaultView(0).Item("nome") = "Home"
                dsXML2.Tables("modulo").DefaultView(0).Item("url") = "../default"


                For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                    dsXML2.Tables("modulo").DefaultView.AddNew()
                    dsXML2.Tables("modulo").DefaultView(dsXML2.Tables("modulo").DefaultView.Count - 1).Item("nome") = dsXML.Tables("modulo").DefaultView(i).Item("nome")
                    dsXML2.Tables("modulo").DefaultView(dsXML2.Tables("modulo").DefaultView.Count - 1).Item("url") = dsXML.Tables("modulo").DefaultView(i).Item("url")

                Next


                lstAlterna.DataSource = dsXML2.Tables("modulo")
                lstAlterna.DataBind()


                lstAlterna.Items.FindByValue("usuarios").Selected = True

                For i = 1 To 12
                    lstDataMes.Items.Add(g.getMes(System.DateTime.Parse("01/" & i & "/2004 00:00:00")))
                    lstDataMes.Items(i - 1).Value = i
                Next

                'Else
                'exibe o módulo usuarios em modo reduzido
                '(só permite a auteração da própria senha e dados cadastrais)

                'lblDicaText.Text = "Utilize o gerenciador de usuários para modificar sua senha e seus dados cadastrais."

                'a.SelectCommand.CommandText = "select distinct * from guest.usuario where id_usuario = @pUserID"

                'a.SelectCommand.Parameters.Clear()
                'a.SelectCommand.Parameters.Add("@pUserID", System.Convert.ToString(Session.Item("userid")))
                'g.ds.Clear()
                'a.Fill(g.ds, "usuario")


                'txtUsername.Text = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("username")).TrimEnd

                'txtNome.Text = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("nome")).TrimEnd
                'txtEmail.Text = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("email")).TrimEnd


                'lstUsers.Visible = False
                'btnAdd.Visible = False
                'btnDel.Visible = False
                'btnEdit.Visible = False

                'txtUsername.Enabled = False
                'txtPassword1.Enabled = True
                'txtPassword2.Enabled = True
                'txtNome.Enabled = True
                'txtEmail.Enabled = True
                'btnOk.Enabled = True
                'chkUsuarios.Enabled = False
                'chkProdutos.Enabled = False
                'chkNoticias.Enabled = False
                'chkMensagens.Enabled = False
                'chkEnviarArquivos.Enabled = False
                'chkReceberArquivos.Enabled = False



                'chkUsuarios.Checked = g.ds.Tables("usuario").DefaultView(0).Item("allowusuarios")
                'chkProdutos.Checked = g.ds.Tables("usuario").DefaultView(0).Item("allowprodutos")
                'chkNoticias.Checked = g.ds.Tables("usuario").DefaultView(0).Item("allownoticias")
                'chkMensagens.Checked = g.ds.Tables("usuario").DefaultView(0).Item("allowmensagens")
                'chkEnviarArquivos.Checked = g.ds.Tables("usuario").DefaultView(0).Item("allowenvarq")
                'chkReceberArquivos.Checked = g.ds.Tables("usuario").DefaultView(0).Item("allowrecarq")

                'Session.Add("lstUsers.id", System.Convert.ToString(Session.Item("userid")))

                'End If
            End If
        Else
            'exibe erro 403
            g.unlogged(Me.Page)

        End If


    End Sub
#Region "Definição e Funcionamento de Interface"
    ' define a subrotina de criação da interface de edição de usuário
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim a As New SqlClient.SqlDataAdapter("select * from guest.usuario where id_usuario = @pId", g.cn)

        a.SelectCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse("{" & Request.Form.Item("lstUsers") & "}"))
        g.ds.Clear()
        a.Fill(g.ds, "usuario")

        txtUsername.Text = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("username")).TrimEnd

        txtNome.Text = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("nome")).TrimEnd
        txtEmail.Text = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("email")).TrimEnd




        dsXML3.ReadXml("http://www.afabre.com.br/remote/res/getXML.aspx?t=guest.usuario&f=modulos&id=" & System.Convert.ToString(Request.Form.Item("lstUsers")) & "")

        dsXML.ReadXml(Server.MapPath(g.getRoot(Me.Page) & "/xml/modulos.xml"))

        For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
            If i <= dsXML.Tables("modulo").DefaultView.Count - 1 Then
                If Not System.Convert.ToBoolean(dsXML.Tables("modulo").DefaultView(i).Item("ativado")) Then
                    dsXML.Tables("modulo").DefaultView(i).Delete()
                    dsXML.Tables("modulo").AcceptChanges()
                End If
            End If
        Next

        dsXML.Tables("modulo").DefaultView.Sort = "nome ASC"

        chlModulos.DataBind()

        chlModulos.ClearSelection()

        If dsXML3.Tables.Contains("modulo") Then
            For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                For j = 0 To dsXML3.Tables("modulo").DefaultView.Count - 1
                    If System.Convert.ToString(dsXML.Tables("modulo").DefaultView(i).Item("url")) = (System.Convert.ToString(dsXML3.Tables("modulo").DefaultView(j).Item("url"))) Then
                        chlModulos.Items(i).Selected = True
                    End If
                Next
            Next
        End If

        chkShowAniver.Checked = System.Convert.ToBoolean(g.ds.Tables("usuario").DefaultView(0).Item("showaniver"))
        chkAssociado.Checked = System.Convert.ToBoolean(g.ds.Tables("usuario").DefaultView(0).Item("associado"))
        txtDataDia.Text = System.Convert.ToDateTime(g.ds.Tables("usuario").DefaultView(0).Item("dtnasc")).Day

        Dim provider As System.IFormatProvider

        lstDataMes.ClearSelection()

        lstDataMes.Items(System.Convert.ToDateTime(g.ds.Tables("usuario").DefaultView(0).Item("dtnasc")).Month - 1).Selected = True


        'testa se o usuário é built-in (se ele é protegido como conta de sistema)
        If g.ds.Tables("usuario").DefaultView(0).Item("builtin") = False Or Session.Item("username") = System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("username")).TrimEnd Then
            'ativa a edição de dados da conta built-in SE O USUARIO LOGADO FOR BUILT-IN
            txtUsername.Enabled = True
            txtPassword1.Enabled = True
            txtPassword2.Enabled = True
            txtNome.Enabled = True
            txtEmail.Enabled = True
            btnOk.Enabled = True
            chlModulos.Enabled = True
            lstUsers.Enabled = False
            btnCancel.Enabled = True
            btnEdit.Enabled = False
            btnAdd.Enabled = False
            btnDel.Enabled = False
            txtDataDia.Enabled = True
            lstDataMes.Enabled = True
            chkAssociado.Enabled = True
            chkShowAniver.Enabled = True

        End If





        ' adiciona à sessão o usuário selecionado em lstUsers
        Session.Add("lstUsers.id", Request.Form.Item("lstUsers"))


    End Sub
    'subrotinas de criação da interface de adição de novo usuário
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        txtUsername.Enabled = True


        txtPassword1.Enabled = True
        txtPassword2.Enabled = True


        txtNome.Enabled = True
        txtEmail.Enabled = True
        btnOk.Enabled = True


        txtUsername.Text = ""
        txtPassword1.Text = ""
        txtPassword2.Text = ""
        txtNome.Text = ""
        txtEmail.Text = ""
        chlModulos.Enabled = True

        chkAssociado.Checked = True
        chkShowAniver.Checked = True
        txtDataDia.Enabled = True
        lstDataMes.Enabled = True
        chkAssociado.Enabled = True
        chkShowAniver.Enabled = True


    End Sub
#End Region
#Region "Subrotinas de EXECUÇÃO de tarefas de DB"

    ' executa as ações de ADIÇÃO ou ALTERAÇÃO de usuário
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click


        If g.logged Then
            Dim a As SqlClient.SqlDataAdapter
            'testa se há usuario selecionado em lstUsers salvo na sessão
            '(se é edição ou adição)
            If Session.Item("lstUsers.id") <> "" Then
                a = New SqlClient.SqlDataAdapter("select * from guest.usuario where id_usuario = @pId", g.cn)
                a.SelectCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("lstUsers.id"))))

                If g.ds.Tables.Contains("usuario") Then g.ds.Tables("usuario").Clear()
                a.Fill(g.ds, "usuario")

                Dim b As New SqlClient.SqlDataAdapter("select * from guest.usuario where id_usuario = @pId", g.cn)
                b.SelectCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("userid"))))

                If g.ds.Tables.Contains("meuusuario") Then g.ds.Tables("meuusuario").Clear()

                b.Fill(g.ds, "meuusuario")


                If g.ds.Tables("meuusuario").DefaultView.Count > 0 Then

                    'testa se usuario tem acesso total ao modulo
                    ' If g.ds.Tables("meuusuario").DefaultView(0).Item("allowusuarios") Then

                    fullUpdateUser(b)

                    'Else

                    'limitedUpdateUser(a)

                    'End If

                End If
                lstUsers.Enabled = True
                btnCancel.Enabled = False
                btnOk.Enabled = False
                txtUsername.Enabled = False
                txtPassword1.Enabled = False
                txtPassword2.Enabled = False
                txtEmail.Enabled = False
                btnEdit.Enabled = True
                btnAdd.Enabled = True
                btnDel.Enabled = True
                chkAssociado.Checked = False
                chkShowAniver.Checked = False
                txtDataDia.Enabled = False
                lstDataMes.Enabled = False
                chkAssociado.Enabled = False
                chkShowAniver.Enabled = False

            Else
                insertUser()
            End If
            lstUsers.Enabled = True
            btnCancel.Enabled = False
            btnOk.Enabled = False
            txtUsername.Enabled = False
            txtPassword1.Enabled = False
            txtPassword2.Enabled = False
            txtEmail.Enabled = False
            btnEdit.Enabled = True
            btnAdd.Enabled = True
            btnDel.Enabled = True
            chkAssociado.Checked = False
            chkShowAniver.Checked = False
            txtDataDia.Enabled = False
            lstDataMes.Enabled = False
            chkAssociado.Enabled = False
            chkShowAniver.Enabled = False
            Response.Redirect(Request.Path)
        Else
            g.unlogged(Me.Page)
        End If
    End Sub
    'define subrotinas de EXCLUSÃO de usuário
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        Dim a As New SqlClient.SqlDataAdapter("select * from guest.usuario where id_usuario = @pId", g.cn)
        a.SelectCommand.Parameters.Add("@pId", Request.Form.Item("lstUsers"))
        g.ds.Clear()
        a.Fill(g.ds, "usuario")

        'testa se o usuário NÃO é Built-In
        'Erro(Request.Form.Item("lstUsers"))
        'Erro(System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("builtin")))
        If Not System.Convert.ToBoolean(g.ds.Tables("usuario").DefaultView(0).Item("builtin")) Then
            Erro("O usuário " & g.ds.Tables("usuario").DefaultView(0).Item("username") & " será removido. Deseja continuar?", 3, Request.FilePath & "?del=true&uid=" & System.Convert.ToString(g.ds.Tables("usuario").DefaultView(0).Item("id_usuario")))
        Else
            Erro("O usuário " & g.ds.Tables("usuario").DefaultView(0).Item("username") & " é uma conta do sistema. Contas do sistema não podem ser excluídas")
        End If


    End Sub
    ' Exclui o usuário
    Public Sub DeleteUser(ByVal uid As SqlTypes.SqlGuid)
        Dim a As New SqlClient.SqlDataAdapter("select * from guest.usuario where id_usuario = @pId", g.cn)

        a.SelectCommand.Parameters.Add("@pId", uid)
        g.ds.Clear()
        a.Fill(g.ds, "usuario")

        'exclui usuário do DB
        a.DeleteCommand = New SqlClient.SqlCommand("delete from guest.usuario where id_usuario = @pId", g.cn)
        a.DeleteCommand.Parameters.Add("@pId", a.SelectCommand.Parameters("@pId").Value)

        g.cn.Close()
        g.cn.Open()
        a.DeleteCommand.ExecuteNonQuery()
        g.cn.Close()

        'recarrega a página
        Response.Redirect(Request.FilePath)
    End Sub

    Public Sub insertUser()

        Dim a As New SqlClient.SqlDataAdapter("select * from guest.usuario where username = @pUsername", g.cn)
        a.SelectCommand.Parameters.Add("@pUsername", txtUsername.Text)
        g.ds.Clear()
        a.Fill(g.ds, "usuario")

        If Not g.ds.Tables("usuario").DefaultView.Count > 0 Then
            'testa se a confirmação de senha está certa
            If txtPassword1.Text = txtPassword2.Text Then
                'insere novo usuário no banco de dados
                a.InsertCommand = New SqlClient.SqlCommand("insert into guest.usuario ([username], [password], [nome], [email], builtin, modulos, dtnasc, associado, showaniver) values(@pUsername, @pPassword, @pNome, @pEmail, @pBuiltIn, @modulo, @data, @associado, @showaniver)", g.cn)

                'valida o nome de usuário
                If txtUsername.Text.Length > 0 Then
                    a.InsertCommand.Parameters.Add("@pUsername", txtUsername.Text)
                Else
                    Erro("Você precisa cadastrar um nome de usuário")
                End If

                'valida a senha
                If txtPassword1.Text.Length > 0 Then
                    a.InsertCommand.Parameters.Add("@pPassword", g.GetHash(txtPassword1.Text))
                Else
                    Erro("Você precisa cadastrar uma senha")
                End If


                a.InsertCommand.Parameters.Add("@pNome", txtNome.Text)


                'valida o endereço de e-mail
                If txtEmail.Text.Length > 0 Then
                    If txtEmail.Text.IndexOf("@") >= 0 And txtEmail.Text.IndexOf(".") >= 0 Then
                        a.InsertCommand.Parameters.Add("@pEmail", txtEmail.Text)
                    Else
                        Erro("Um endereço de email deve estar no formato usuario@dominio.com")
                    End If
                Else
                    Erro("Você precisa cadastrar um endereço de email")
                End If

                Dim xmloutput As String

                dsXML.Clear()
                dsXML.ReadXml(Server.MapPath(g.getRoot(Me.Page) & "/xml/modulos.xml"))
                dsXML.Tables("modulo").DefaultView.Sort = "nome ASC"

                For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                    If i <= dsXML.Tables("modulo").DefaultView.Count - 1 Then
                        If Not System.Convert.ToBoolean(dsXML.Tables("modulo").DefaultView(i).Item("ativado")) Then
                            dsXML.Tables("modulo").DefaultView(i).Delete()
                            dsXML.Tables("modulo").AcceptChanges()
                        End If
                    End If
                Next

                For j = 0 To chlModulos.Items.Count - 1
                    For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                        If i <= dsXML.Tables("modulo").DefaultView.Count - 1 Then
                            If System.Convert.ToString(dsXML.Tables("modulo").DefaultView(i).Item("url")) = System.Convert.ToString(chlModulos.Items(j).Value) And Not chlModulos.Items(j).Selected Then
                                dsXML.Tables("modulo").DefaultView(i).Delete()
                                dsXML.Tables("modulo").AcceptChanges()
                            End If
                        End If
                    Next
                Next

                xmloutput = dsXML.GetXml


                a.InsertCommand.Parameters.Add("@modulo", xmloutput)

                a.InsertCommand.Parameters.Add("@pBuiltIn", False)

                a.InsertCommand.Parameters.Add("@data", System.DateTime.Parse(txtDataDia.Text & "/" & lstDataMes.SelectedItem.Value & "/1900 00:00:00"))
                a.InsertCommand.Parameters.Add("@showaniver", chkShowAniver.Checked)
                a.InsertCommand.Parameters.Add("@associado", chkAssociado.Checked)

                g.cn.Close()
                g.cn.Open()
                a.InsertCommand.ExecuteNonQuery()
                g.cn.Close()

                'remove da sessão a identificação do usuário
                Session.Remove("lstUsers.id")


                'exibe mensagem de confirmação"
                Erro("Usuário " & txtUsername.Text & " adicionado com sucesso", 2)


            Else
                Erro("As senhas digitadas não são idênticas. Digite sua senha novamente.")

            End If
        Else
            Erro("O usuário " & txtUsername.Text & " já existe")
        End If



    End Sub

    Public Sub fullUpdateUser(ByVal a As SqlClient.SqlDataAdapter)
        If txtPassword1.Text = txtPassword2.Text Then

            'testa se o usuário digitou senha
            If Not String.IsNullOrEmpty(txtPassword1.Text) Then
                'estabelece nova senha
                a.UpdateCommand = New SqlClient.SqlCommand("update guest.usuario set username = @pUsername, password = @pPassword, nome = @pNome, email = @pEmail, builtin= @pBuiltIn, modulos = @modulos, associado = @associado, dtnasc = @data, showaniver = @showaniver from guest.usuario where id_usuario = @pId", g.cn)

                Dim pwd As String = g.GetHash(txtPassword1.Text)

                a.UpdateCommand.Parameters.Add("@pPassword", pwd)

            Else
                'mantém senha anterior
                a.UpdateCommand = New SqlClient.SqlCommand("update guest.usuario set username = @pUsername, nome = @pNome, email = @pEmail, builtin = @pBuiltIn, modulos = @modulos, associado = @associado, dtnasc = @data, showaniver = @showaniver from guest.usuario where id_usuario = @pId", g.cn)

            End If
            'executa ações comuns de edição de usuário
            a.UpdateCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse("{" & System.Convert.ToString(Session.Item("lstUsers.id")) & "}"))

            'valida o nome de usuário
            If txtUsername.Text.Length > 0 Then
                a.UpdateCommand.Parameters.Add("@pUsername", txtUsername.Text)
            Else
                Erro("Você precisa digitar um nome de usuário")
            End If


            a.UpdateCommand.Parameters.Add("@pNome", txtNome.Text)

            ' valida o endereço de e-mail
            If txtEmail.Text.Length > 0 Then
                If txtEmail.Text.IndexOf("@") > 0 And txtEmail.Text.IndexOf(".") > 0 Then
                    a.UpdateCommand.Parameters.Add("@pEmail", txtEmail.Text)
                Else
                    Erro("Um endereço de email deve estar no formato usuario@dominio.com" & txtEmail.Text.IndexOf("@") & " " & txtEmail.Text.IndexOf("."))
                End If
            Else
                Erro("Você precisa cadastrar um endereço de email")
            End If

            a.UpdateCommand.Parameters.Add("@pBuiltIn", False)

            Dim xmloutput As String

            dsXML.Clear()
            dsXML.ReadXml(Server.MapPath(g.getRoot(Me.Page) & "/xml/modulos.xml"))
            dsXML.Tables("modulo").DefaultView.Sort = "nome ASC"

            For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                If i <= dsXML.Tables("modulo").DefaultView.Count - 1 Then
                    If Not System.Convert.ToBoolean(dsXML.Tables("modulo").DefaultView(i).Item("ativado")) Then
                        dsXML.Tables("modulo").DefaultView(i).Delete()
                        dsXML.Tables("modulo").AcceptChanges()
                    End If
                End If
            Next

            For j = 0 To chlModulos.Items.Count - 1
                For i = 0 To dsXML.Tables("modulo").DefaultView.Count - 1
                    If i <= dsXML.Tables("modulo").DefaultView.Count - 1 Then
                        If System.Convert.ToString(dsXML.Tables("modulo").DefaultView(i).Item("url")) = System.Convert.ToString(chlModulos.Items(j).Value) And Not chlModulos.Items(j).Selected Then
                            dsXML.Tables("modulo").DefaultView(i).Delete()
                            dsXML.Tables("modulo").AcceptChanges()
                        End If
                    End If
                Next
            Next

            xmloutput = dsXML.GetXml


            a.UpdateCommand.Parameters.Add("@modulos", xmloutput)
            a.UpdateCommand.Parameters.Add("@data", System.DateTime.Parse(txtDataDia.Text & "/" & lstDataMes.SelectedItem.Value & "/1900 00:00:00"))
            a.UpdateCommand.Parameters.Add("@showaniver", chkShowAniver.Checked)
            a.UpdateCommand.Parameters.Add("@associado", chkAssociado.Checked)


            'executa comando de edição
            g.cn.Close()
            g.cn.Open()
            a.UpdateCommand.ExecuteNonQuery()
            g.cn.Close()

            Session.Remove("lstUsers.id")
            lstUsers.Enabled = True

            btnCancel.Enabled = False
            btnOk.Enabled = False
            txtUsername.Enabled = False
            txtPassword1.Enabled = False
            txtPassword2.Enabled = False
            txtEmail.Enabled = False
            btnEdit.Enabled = True
            btnAdd.Enabled = True
            btnDel.Enabled = True
            chkAssociado.Checked = False
            chkShowAniver.Checked = False
            txtDataDia.Enabled = False
            lstDataMes.Enabled = False
            chkAssociado.Enabled = False
            chkShowAniver.Enabled = False

            Erro("Usuário " & txtUsername.Text & " alterado com sucesso", 2)

        Else
            Erro("As senhas digitadas não são idênticas. Digite sua senha novamente.")
        End If
    End Sub

    Public Sub limitedUpdateUser(ByVal a As SqlClient.SqlDataAdapter)
        'modo reduzido

        Dim chpwd As Boolean
        'testa se a confirmação de senha está certa
        If txtPassword1.Text = txtPassword2.Text Then

            'testa se o usuário digitou senha
            If txtPassword1.Text <> "" Then
                'estabelece nova senha
                a.UpdateCommand = New SqlClient.SqlCommand("update guest.usuario set password = @pPassword, nome = @pNome, email = @pEmail from guest.usuario where id_usuario = @pId", g.cn)

                a.UpdateCommand.Parameters.Add("@pPassword", g.GetHash(txtPassword1.Text))

                chpwd = True

            Else
                'mantém senha anterior
                a.UpdateCommand = New SqlClient.SqlCommand("update guest.usuario set nome = @pNome, email = @pEmail from guest.usuario where id_usuario = @pId", g.cn)

            End If
            'executa ações comuns de edição de usuário
            a.UpdateCommand.Parameters.Add("@pId", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("userid"))))

            a.UpdateCommand.Parameters.Add("@pNome", Request.Form("txtNome"))

            ' valida o endereço de e-mail
            If txtEmail.Text.Length > 0 Then
                If txtEmail.Text.IndexOf("@") > 0 And txtEmail.Text.IndexOf(".") > 0 Then
                    a.UpdateCommand.Parameters.Add("@pEmail", Request.Form("txtEmail"))
                Else
                    Erro("Um endereço de email deve estar no formato usuario@dominio.com")
                End If
            Else
                Erro("Você precisa cadastrar um endereço de email")
                Erro(a.UpdateCommand.CommandText)
            End If

            'executa comando de edição
            g.cn.Close()
            g.cn.Open()
            'Response.Redirect(a.UpdateCommand.Parameters.Item("@pEmail").Value)
            a.UpdateCommand.ExecuteNonQuery()
            g.cn.Close()


            If chpwd Then
                chpwd = False
                Session.Clear()
                Session.Abandon()
                Erro("Senha alterada com sucesso. Faça login novamente.", remote.erro.SUCESSO, "home")
            End If
            'exibe mensagem de confirmação"
            Erro("Usuário " & txtUsername.Text & " alterado com sucesso.", 2)
        Else
            Erro("As senhas digitadas não são idênticas. Digite sua senha novamente.")
        End If
    End Sub

#End Region

#Region "Subrotinas de Validação e Relatório de Erros"

    Public Sub Erro(ByVal msg As String, Optional ByVal n As Integer = 0, Optional ByVal a As String = "")
        Session.Add("activepage", Request.FilePath)
        Response.Redirect("../res/erro.aspx?e=" & n & "&msg=" & Server.UrlEncode(msg) & "&a=" & a)
    End Sub

#End Region


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click


        txtUsername.Text = ""
        txtPassword1.Text = ""
        txtPassword2.Text = ""
        txtNome.Text = ""
        txtEmail.Text = ""


        lstUsers.Enabled = True
        btnCancel.Enabled = False
        btnOk.Enabled = False
        txtUsername.Enabled = False
        txtPassword1.Enabled = False
        txtPassword2.Enabled = False
        txtNome.Enabled = False
        txtEmail.Enabled = False
        btnEdit.Enabled = True
        btnAdd.Enabled = True
        btnDel.Enabled = True
        chlModulos.Enabled = False
        chlModulos.ClearSelection()

        chkAssociado.Checked = False
        chkShowAniver.Checked = False
        txtDataDia.Enabled = False
        lstDataMes.Enabled = False
        chkAssociado.Enabled = False
        chkShowAniver.Enabled = False


        Session.Remove("lstUsers.id")

    End Sub

    Private Sub btnIr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIr.Click
        Response.Redirect(g.getRoot(Me.Page) & "/modulos/" & Request.Form.Item("lstAlterna") & ".aspx")

    End Sub



End Class

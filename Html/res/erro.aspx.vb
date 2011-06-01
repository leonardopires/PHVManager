Partial Class erro
    Inherits System.Web.UI.Page

    Public Const ERRO = 0
    Public Const ATENCAO = 1
    Public Const SUCESSO = 2
    Public Const CONFIRM = 3
    Public Const RESTRITA = 4
    Public Const CONFIRMCHECK = 5



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
        sErro(Request.QueryString("msg"), Int(Request.QueryString("e")), Request.QueryString("a"))
    End Sub

    Public Sub sErro(ByVal msg As String, Optional ByVal n As Integer = 0, Optional ByVal a As String = "")


        Select Case n
            Case ERRO
                lblErroTitulo.Text = "&nbsp;&nbsp;&nbsp;&nbsp; ERRO"
                btnCancel.Visible = True
                btnCancel.Text = "OK"
            Case ATENCAO
                lblErroTitulo.Text = "&nbsp;&nbsp;&nbsp;&nbsp; ATENÇÃO"
                btnCancel.Visible = True
                btnCancel.Text = "OK"
            Case SUCESSO
                lblErroTitulo.Text = "&nbsp;&nbsp;&nbsp;&nbsp; OPERAÇÃO REALIZADA COM SUCESSO"
                btnCancel.Visible = True
                btnCancel.Text = "OK"
            Case CONFIRM
                lblErroTitulo.Text = "&nbsp;&nbsp;&nbsp;&nbsp; CONFIRMAÇÃO"
                btnOk.Visible = True
                btnCancel.Visible = True
                btnOk.Text = "Sim"
                btnCancel.Text = "Não"
            Case RESTRITA
                lblErroTitulo.Text = "&nbsp;&nbsp;&nbsp;&nbsp; ÁREA RESTRITA"
                btnCancel.Visible = True
                btnCancel.Text = "OK"
            Case CONFIRMCHECK
                lblErroTitulo.Text = "&nbsp;&nbsp;&nbsp;&nbsp; CONFIRMAÇÃO"
                chkMsgBox.Visible = True
                chkMsgBox.Text = Request.QueryString("chk")
                btnOk.Visible = True
                btnCancel.Visible = True
                btnOk.Text = "Sim"
                btnCancel.Text = "Não"
                n = CONFIRM

        End Select

        lblMsg.Text = msg
        imgMsg.ImageUrl = "../images/erro-" & n & ".gif"

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Response.Redirect(Request.QueryString("a") & "&uid=" & Request.QueryString("uid") & "&chk=" & chkMsgBox.Checked.ToString)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Select Case Request.QueryString("e")
            Case ERRO
                If Request.QueryString("a") = "home" Then
                    goHome()
                Else
                    goBack()
                End If
            Case ATENCAO
                If Request.QueryString("a") = "home" Then
                    goHome()
                Else
                    goBack()
                End If
            Case SUCESSO
                If Request.QueryString("a") = "home" Then
                    goHome()
                Else
                    goBack()
                End If
            Case CONFIRM
                If Request.QueryString("a") = "home" Then
                    goHome()
                Else
                    goBack()
                End If
            Case CONFIRMCHECK
                If Request.QueryString("a") = "home" Then
                    goHome()
                Else
                    goBack()
                End If
            Case RESTRITA
                    goHome()


        End Select

    End Sub

    Public Sub goBack()
        Response.Write("<html>")
        Response.Write("<head>")
        Response.Write("<meta http-equiv=""refresh"" content=""0;url=" & Session.Item("activepage") & """>")
        Response.Write("</head>")
        Response.Write("</html>")
        Response.End()
    End Sub

    Public Sub goHome()
        Redirect.goHome(Me.Page)
    End Sub
End Class

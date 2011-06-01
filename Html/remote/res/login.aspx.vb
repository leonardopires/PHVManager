Partial Class login
    Inherits System.Web.UI.Page
    Public er As Integer
    Public ds As New DataSet

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
        If Not IsPostBack Then
            If Request.QueryString("e") <> "" Then
                er = Int(Request.QueryString("e"))

                Select Case er
                    Case 1
                        lblResponse.Text = "Usuário não logado ou sessão expirada."
                    Case 2
                        lblResponse.Text = "Nome de usuário ou senha incorretos."
                    Case 3
                        lblResponse.Text = "Preencha todos os campos."
                    Case 4
                        lblResponse.Text = "Digite corretamente o código do campo abaixo."

                End Select
            End If
        End If
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click

        doLogin()

    End Sub
    Public Sub erro(ByVal erro As Integer)
        Response.Redirect(g.getRoot(Me.Page) & "/res/login.aspx?e=" & erro)
    End Sub
    Public Sub doLogin()

        If String.IsNullOrEmpty(txtUsername.Text) Or String.IsNullOrEmpty(txtPassword.Text) Then erro(3)

		Dim a As New SqlClient.SqlDataAdapter("select username, password, id_usuario, builtin from guest.usuario where username = @username and password = @password", g.cn)
        a.SelectCommand.Parameters.Add("@username", txtUsername.Text)
        a.SelectCommand.Parameters.Add("@password", g.GetHash(txtPassword.Text))

        If ds.Tables.Contains("login") Then ds.Tables.Remove("login")
        a.Fill(ds, "login")

        If ds.Tables("login").DefaultView.Count > 0 Then
            Session.Add("logged", True)
            Session.Add("username", txtUsername.Text)
            Session.Add("password", g.GetHash(txtPassword.Text))
            Session.Add("userid", ds.Tables("login").DefaultView(0).Item("id_usuario"))
            Session.Add("builtin", ds.Tables("login").DefaultView(0).Item("id_usuario"))

            Response.Redirect(g.getRoot(Me.Page) & "/default.aspx")
        Else
            erro(2)
        End If

    End Sub
End Class

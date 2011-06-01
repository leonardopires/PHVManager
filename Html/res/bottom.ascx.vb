Partial Class bottom
    Inherits System.Web.UI.UserControl
    Public Root As String
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
        Root = g.getRoot(Me.Page)
    End Sub

    Public Shared Property teste()
        Get

        End Get
        Set(ByVal Value)

        End Set
    End Property

    Private Sub cmdBusca_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdBusca.Click

        If txtBusca.Text.Length < 1 Then Erro("Você precisa digitar um texto para fazer uma busca.")

        Session.Add("q", txtBusca.Text)
        Response.Redirect(g.getRoot(Me.Page) & "/res/layout.aspx?a=busca")


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
End Class

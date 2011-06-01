Partial Class Redirect
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
    End Sub

    Public Shared Sub RedirectTo(ByVal navName As String, ByVal sender As Page)
        'sender.Response.Write("redirect.aspx?url=" + sender.g.getRoot(Me.Page) + "/res/layout.aspx?a=" + navName + "&r=1" + "")
        sender.Response.Redirect("redirect.aspx?url=" + g.getRoot(sender) + "/res/layout.aspx?a=" + navName + "&r=1" + "")

    End Sub

    Public Shared Sub goHome(ByVal sender As Page)
        'sender.Response.Write("redirect.aspx?url=" + sender.g.getRoot(Me.Page) + "/res/layout.aspx?a=" + navName + "&r=1" + "")
        sender.Response.Redirect("redirect.aspx?url=" + g.getRoot(sender) + "/home.aspx")

    End Sub

End Class

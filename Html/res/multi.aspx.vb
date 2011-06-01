Partial Class multi
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
        Select Case Request.QueryString.Item("action")
            Case "blank"
                Response.Write("<html><LINK href='../css/home.css' type='text/css' rel='stylesheet'><body>&nbsp;</body></html>")
                'Response.Write("<html><LINK href='/css/home.css' type='text/css' rel='stylesheet'><body>&nbsp;</body></html>")
                Response.End()
        End Select
    End Sub

End Class

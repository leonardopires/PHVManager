Partial Class getXML
    Inherits System.Web.UI.Page
    Public ds, dsxml As New DataSet

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

        Dim table As String
        table = Request.QueryString("t")

        If table = "guest.usuario" Then table = "usuario"

		Dim a As New SqlClient.SqlDataAdapter("select " & Request.QueryString("f") & " from " & Request.QueryString("t") & IIf(Request.QueryString("id") <> "", " where id_" & table & " = @id", ""), g.cn)
        If Request.QueryString("id") <> "" Then a.SelectCommand.Parameters.Add("@id", System.Convert.ToString(Request.QueryString("id")))

        a.Fill(ds, Request.QueryString("t"))

        Response.Write(ds.Tables(Request.QueryString("t")).DefaultView(0).Item(Request.QueryString("f")))
        Response.End()

    End Sub

End Class

Partial Class noticias
    Inherits System.Web.UI.Page

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
        'Put user code to initialize the page here
        Dim a As New SqlClient.SqlDataAdapter("select t.data, cast(t.titulo as char(1024)) as titulo, t.id_texto from texto t inner join area a on t.id_area = a.id_area where a.nomept = @area order by data desc", g.cn)
        a.SelectCommand.Parameters.Add("@area", "Notícias")

        If ds.Tables.Contains("texto") Then ds.Tables.Remove("texto")
        a.Fill(ds, "texto")


        lstNoticias.DataSource = ds.Tables("texto")
        lstNoticias.DataBind()


    End Sub
End Class

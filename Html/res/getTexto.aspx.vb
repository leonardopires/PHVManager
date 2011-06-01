Partial Class getTexto
    Inherits System.Web.UI.Page

    Public ds, dsxml As New DataSet
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink

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
        Dim a As New SqlClient.SqlDataAdapter("select top 1 t.texto, t.id_texto, i.id_imagem, t.titulo, a.nomept, a.nomeurl from texto t inner join area a on t.id_area = a.id_area inner join imagem_texto i on t.id_texto = i.id_texto where t.id_texto = @id", g.cn)
        a.SelectCommand.Parameters.Add("@id", SqlTypes.SqlGuid.Parse(Request.QueryString("id")))

        If ds.Tables.Contains("texto") Then ds.Tables.Remove("texto")
        a.Fill(ds, "texto")

        If ds.Tables("texto").DefaultView.Count = 0 Then

            a.SelectCommand.CommandText = "select top 1 t.texto, t.id_texto, a.nomept, t.titulo, a.nomeurl from texto t inner join area a on t.id_area = a.id_area where id_texto = @id"

            If ds.Tables.Contains("texto") Then ds.Tables.Remove("texto")
            a.Fill(ds, "texto")

            Image1.Visible = False

        Else


            If System.Convert.ToString(ds.Tables("texto").DefaultView(0).Item("id_imagem")) = "" Then
                Image1.Visible = False

            Else

                Image1.ImageUrl = "/remote/res/getimage.aspx?a=get&w=150&id=" + System.Convert.ToString(ds.Tables("texto").DefaultView(0).Item("id_imagem"))
            End If
        End If

        lblTitulo.Text = ds.Tables("texto").DefaultView(0).Item("titulo")
        lblTexto.Text = ds.Tables("texto").DefaultView(0).Item("texto")



    End Sub

End Class

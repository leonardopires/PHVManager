Partial Class ifrEnquete
    Inherits System.Web.UI.Page

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

        Dim r As New SqlClient.SqlDataAdapter("select top 1 id_questao from questao order by [data] desc", g.cn)

        If ds.Tables.Contains("questao") Then ds.Tables.Remove("questao")
        r.Fill(ds, "questao")

        If ds.Tables("questao").DefaultView.Count > 0 Then

            Dim q As New SqlClient.SqlDataAdapter("select q.nome as pergunta, r.nome as nome, r.id_resposta, q.id_questao from resposta r inner join questao q on r.id_questao = q.id_questao and q.id_questao = @questao order by nome asc", g.cn)
            q.SelectCommand.Parameters.Add("@questao", ds.Tables("questao").DefaultView(0).Item("id_questao"))

            If ds.Tables.Contains("enquete") Then ds.Tables.Remove("enquete")
            q.Fill(ds, "enquete")

            If ds.Tables("enquete").DefaultView.Count > 0 Then
                lblQuestao.Text = ds.Tables("enquete").DefaultView(0).Item("pergunta")
                rblResposta.DataValueField = "id_resposta"
                rblResposta.DataBind()

            End If
        End If

    End Sub

    Private Sub btnVotar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVotar.Click

        If Request.Form.Item("rblResposta").ToString <> "" Then
            Dim a As New SqlClient.SqlDataAdapter("select * from questao", g.cn)

            a.UpdateCommand = New SqlClient.SqlCommand("update resposta set hits = hits + 1 where id_resposta = @resposta", g.cn)

            a.UpdateCommand.Parameters.Add("@resposta", SqlTypes.SqlGuid.Parse(Request.Form.Item("rblResposta").ToString))

            g.cn.Close()
            g.cn.Open()
            a.UpdateCommand.ExecuteNonQuery()
            g.cn.Close()

            Response.Write("<script language=""javascript"">window.location.href=""javascript:window.open('../enquete/enquete.aspx', 'enquete', 'menubar=no, links=no, toolbar=no, width=446, height=390');history.back();""</script>")
        End If
    End Sub

End Class

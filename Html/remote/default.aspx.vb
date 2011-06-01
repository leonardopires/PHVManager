Partial Class WebForm1
    Inherits System.Web.UI.Page

    Public ds As New DataSet
    Public dsXml As New DataSet
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
        'Put user code to initialize the page here
        If Not g.logged Then g.unlogged(Me.Page)


        Dim xml As New System.Xml.XmlTextReader(Server.MapPath(g.getRoot(Me.Page) & "\xml\modulos.xml"))


        dsXml.ReadXml(xml)

        For i = 0 To dsXml.Tables("modulo").DefaultView.Count - 1
            If i <= dsXml.Tables("modulo").DefaultView.Count - 1 Then
                If Not System.Convert.ToBoolean(dsXml.Tables("modulo").DefaultView(i).Item("ativado")) Then
                    dsXml.Tables("modulo").DefaultView(i).Delete()
                    dsXml.Tables("modulo").AcceptChanges()
                End If
            End If
        Next

        dsXml.Tables("modulo").DefaultView.Sort = "nome ASC"





        lstModulos.DataSource = dsXml.Tables("modulo").DefaultView
        lstModulos.DataBind()

        xml.Close()




    End Sub


    Private Sub lnkLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Session.RemoveAll()
        Response.Redirect(g.getRoot(Me.Page) & "/default.aspx")
    End Sub
End Class

Partial Class contato
    Inherits System.Web.UI.Page

    Public Const destino = "afabre@afabre.com.br"

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
        If Request.Form("txtMsg") <> "" Then
            Dim mailer As Mail.SmtpMail
            Dim msg As New Mail.MailMessage

            msg.BodyFormat = Mail.MailFormat.Text
            msg.From = Request.Form("txtEmail")
            msg.To = destino
            msg.Subject = "Contato pelo Site"
            msg.Body = "Remetente: " & Request.Form("txtNome") & vbCrLf & "IP: " & Request.UserHostAddress & vbCrLf & vbCrLf & "Mensagem:" & vbCrLf & Request.Form("txtMsg")

            mailer.SmtpServer = "127.0.0.1"

            mailer.Send(msg)

            Erro("Mensagem enviada com sucesso. Seu ip é " & Request.UserHostAddress & ".", afabre.erro.SUCESSO)

        End If

    End Sub

#Region "Funções Comuns"
    Public Function getDataExt(ByVal data As DateTime) As String
        Return g.getDataExt(data)
    End Function
    Public Sub Erro(ByVal msg As String, Optional ByVal n As Integer = 0, Optional ByVal a As String = "")
        Session.Add("activepage", Request.FilePath)
        Response.Redirect("../remote/res/erro.aspx?e=" & n & "&msg=" & msg & "&a=" & a)
    End Sub
#End Region

End Class

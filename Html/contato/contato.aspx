<%@ Page Language="vb" AutoEventWireup="false" Codebehind="contato.aspx.vb" Inherits="afabre.contato" EnableSessionState="False" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Afabre - Associação dos Funcionários Aposentados do BRDE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<%="<style>"%>
		<%response.writefile("../css/afabre.css")%>
		<%="</style>"%>
		<script language="Javascript1.2"><!-- // load htmlarea
_editor_url = "../js/";                     // URL to htmlarea files
var win_ie_ver = parseFloat(navigator.appVersion.split("MSIE")[1]);
if (navigator.userAgent.indexOf('Mac')        >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Windows CE') >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Opera')      >= 0) { win_ie_ver = 0; }
if (win_ie_ver >= 5.5) {
 document.write('<scr' + 'ipt src="' +_editor_url+ 'editor.js"');
 document.write(' language="Javascript1.2"></scr' + 'ipt>');  
} else { document.write('<scr'+'ipt>function editor_generate() { return false; }</scr'+'ipt>'); }
// -->
var config = new Object(); // create new config object

config.width = "465px";
config.height = "120px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

// Add additional editor config settings here...



config.toolbar = [
    //['fontname'],
    ['fontsize'],
    //['fontstyle'],
    //['linebreak'],
    ['bold','italic','underline','separator'],
//  ['strikethrough','subscript','superscript','separator'],
    ['justifyleft','justifycenter','justifyright','separator'],
    ['OrderedList','UnOrderedList','Outdent','Indent','separator'],
    ['forecolor','backcolor','separator'],
    ['HorizontalRule','Createlink','InsertTable','separator'],
//  ['custom1','custom2','custom3','separator'],
    //['popupeditor','about']
    ];

		</script>
	</HEAD>
	<body bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post">
			<H1>Contato&nbsp; 
				<!-- ImageReady Slices (cabecalho.psd) --></H1>
			<TABLE cellSpacing="0" cellPadding="0" border="0" id="Table1">
				<tr>
					<td>
						<P>Preencha os campos abaixo e pressione <STRONG><EM>Enviar </EM></STRONG>para 
							enviar um e-mail para a <STRONG>Afabre:</STRONG></P>
						<table>
							<tr>
								<td style="HEIGHT: 21px">
									<asp:Label id="Label1" runat="server" Font-Bold="True" Font-Size="8pt">Nome:</asp:Label></td>
								<td style="HEIGHT: 21px"><INPUT style="WIDTH: 384px; HEIGHT: 22px" type="text" size="58" name="txtNome"></td>
							</tr>
							<tr>
								<td>
									<asp:Label id="Label2" runat="server" Font-Bold="True" Font-Size="8pt">Email:</asp:Label></td>
								<td><INPUT style="WIDTH: 382px; HEIGHT: 22px" type="text" size="58" name="txtEmail"></td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="8pt">Mensagem:</asp:Label><BR>
									<TEXTAREA style="WIDTH: 424px; HEIGHT: 160px" rows="10" cols="50" name="txtMsg">
									</TEXTAREA></td>
							</tr>
							<tr>
								<td>
								&nbsp;
								<td align="right"><INPUT style="BORDER-RIGHT: yellowgreen thin solid; BORDER-TOP: yellowgreen thin solid; FONT-WEIGHT: bold; FONT-SIZE: 8pt; BORDER-LEFT: yellowgreen thin solid; COLOR: white; BORDER-BOTTOM: yellowgreen thin solid; BACKGROUND-COLOR: green"
										type="submit" value="Enviar">&nbsp;&nbsp;&nbsp;&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>

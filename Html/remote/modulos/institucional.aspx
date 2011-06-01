<%@ Page Language="vb" validateRequest="false" AutoEventWireup="false" Codebehind="institucional.aspx.vb" Inherits="remote.institucional1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>institucional</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<%="<style type=text/css>"%>
		<% Response.WriteFile(Server.MapPath("../css/remote.css")) %>
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

config.width = "345px";
config.height = "120px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

// Add additional editor config settings here...



config.toolbar = [
  ['bold','italic','underline','separator'],
  ['OrderedList','UnOrderedList','Outdent','Indent'],
  //['custom1','custom2','custom3','separator'],
  ]; 

		</script>
	</HEAD>
	<body bottomMargin="0" topMargin="0" bgColor="gainsboro" leftMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 768px; HEIGHT: 341px" cellSpacing="0" cellPadding="0" width="768"
				align="left" border="0">
				<tr>
					<td bgColor="#336666"><IMG src="../images/remote-top.gif"><BR>
						<asp:panel id="pnlMenu" runat="server" HorizontalAlign="Right">
<asp:Label id="lblAlterna" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True">Alternar para: </asp:Label>
<asp:DropDownList id="lstAlterna" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True"
								DataValueField="url" DataTextField="nome" BackColor="#336666"></asp:DropDownList>
<asp:Button id="Button1" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True" BackColor="#336666"
								BorderStyle="Solid" BorderWidth="2px" BorderColor="YellowGreen"
								Text="Ir" Width="30px"></asp:Button>&nbsp;&nbsp; 
      </asp:panel></td>
				</tr>
				<TR>
					<td bgColor="whitesmoke">&nbsp;<table border="0" cellspacing="0" cellpadding="0" align="center" width="100%">
							<tr>
								<TD vAlign="top" align="center" bgColor="gainsboro" width="200">
									<P><asp:label id="Label9" runat="server" CssClass="titleBar" Width="100%" BackColor="DarkGray"
											ForeColor="White" Font-Size="8pt" Font-Bold="True">Seleção de Texto</asp:label></P>
									<P><asp:listbox id="lstTextos" runat="server" CssClass="listBox" Width="129px" Rows="12" Height="200px"></asp:listbox><BR>
										<asp:button id="btnAdd" runat="server" Width="24px" Text="+"></asp:button><asp:button id="btnDel" runat="server" Width="24px" Text="-"></asp:button><asp:button id="btnEdit" runat="server" Width="77px" Text="Editar"></asp:button></P>
								</TD>
								<TD style="PADDING-BOTTOM: 20px; PADDING-TOP: 0px" vAlign="top" align="right" bgColor="whitesmoke"><asp:label id="Label1" runat="server" CssClass="titleBar" Width="100%" BackColor="DarkGray"
										ForeColor="White" Font-Size="8pt" Font-Bold="True">Dados do Texto</asp:label>
									<center><asp:panel id="pnlDica" style="Z-INDEX: 106; PADDING-TOP: 5px" runat="server" CssClass="pnlDica"
											Width="356px" BackColor="#FFFFC0" Height="88px" Visible="False" HorizontalAlign="Left" BorderWidth="1px"
											BorderColor="InfoText">
											<P>
												<asp:Label id="Label11" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True" BackColor="DarkGray"
													Width="100%" CssClass="titleDica">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dica</asp:Label><BR>
												<asp:Image id="Image1" runat="server" ImageUrl="../images/erro-2.gif" align="left" ImageAlign="Left"></asp:Image>&nbsp;
												<asp:label id="lblDicaText" style="TEXT-ALIGN: left" runat="server" ForeColor="InfoText" Font-Size="8pt"
													Width="256px" CssClass="pnlDicaTxt" Height="16px">Se você estiver usando bloqueio anti-popups, clique no botão <b>
														"Ir"</b> mantendo a tecla <b> Ctrl</b>  pressionada.</asp:label><BR>
											</P>
										</asp:panel></center>
									<TABLE id="Table1" style="MARGIN-TOP: 10px" cellSpacing="1" cellPadding="1" width="100%"
										border="0">
										<TR>
											<TD style="PADDING-LEFT: 10px; WIDTH: 30px" align="left"><asp:label id="Label3" runat="server" Font-Size="8pt" Font-Bold="True">Nome:</asp:label></TD>
											<TD style="PADDING-RIGHT: 10px" align="left"><asp:textbox id="txtNome" runat="server" Width="300px" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
												align="left" colSpan="2">
												<asp:label id="Label5" style="PADDING-BOTTOM: 5px" runat="server" Font-Bold="True" Font-Size="8pt"
													Width="336px">Texto:</asp:label>
												<asp:textbox id="txtTexto" runat="server" Width="98%" Height="160px" Rows="8" Enabled="False"
													Columns="15" TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
									<asp:Button id="btnCancel" runat="server" Text="Cancelar" Enabled="False"></asp:Button>
									<asp:button id="btnOk" runat="server" Width="71px" Text="OK" Enabled="False"></asp:button>&nbsp;&nbsp;&nbsp;
								</TD>
							</tr>
						</table>
						<P><BR>
							&nbsp;</P>
					</td>
				</TR>
				<tr>
					<td colSpan="3" align="center"><asp:label id="Label6" runat="server" Font-Bold="True" Width="100%" Height="21px" CssClass="lblCopy"
							BackColor="Silver">&copy; 2004 - Phosforo Verde - Todos os Direitos Reservados</asp:label></td>
				</tr>
			</TABLE>
		</form>
		<%if txttexto.enabled then%>
		<script language="JavaScript1.2" defer>
editor_generate('txtTexto', config);
		</script>
		<%end if%>
	</body>
</HTML>

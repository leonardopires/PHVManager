<%@ Page Language="vb" AutoEventWireup="false" Codebehind="enquetes.aspx.vb" Inherits="remote.enquetes"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Enquetes</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<%="<style type=text/css>"%>
		<%response.writefile("../css/remote.css")%>
		<%="</style>"%>
	</HEAD>
	<body bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE style="WIDTH: 768px; HEIGHT: 341px" cellSpacing="0" cellPadding="0" width="768"
				align="left" border="0">
				<tr>
					<td bgColor="#336666"><IMG src="../images/remote-top.gif"><BR>
						<asp:panel id="pnlMenu" runat="server" HorizontalAlign="Right">
<asp:Label id="lblAlterna" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White">Alternar para: </asp:Label>
<asp:DropDownList id="lstAlterna" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White"
								BackColor="#336666" DataTextField="nome" DataValueField="url"></asp:DropDownList>
<asp:Button id="Button1" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="#336666"
								Width="30px" Text="Ir" BorderColor="YellowGreen" BorderWidth="2px"
								BorderStyle="Solid"></asp:Button>&nbsp;&nbsp; 
      </asp:panel></td>
				</tr>
				<TR>
					<td bgColor="whitesmoke">&nbsp;
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<TD vAlign="top" align="center" width="200" bgColor="gainsboro">
									<P><asp:label id="Label9" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="DarkGray"
											Width="100%" CssClass="titleBar">Seleção de Enquete</asp:label></P>
									<P><asp:listbox id="lstTextos" runat="server" Width="129px" CssClass="listBox" Height="200px" Rows="12"></asp:listbox><BR>
										<asp:button id="btnAdd" runat="server" Width="24px" Text="+"></asp:button><asp:button id="btnDel" runat="server" Width="24px" Text="-"></asp:button><asp:button id="btnEdit" runat="server" Width="77px" Text="Editar"></asp:button></P>
								</TD>
								<TD style="PADDING-BOTTOM: 20px; PADDING-TOP: 0px" vAlign="top" align="right" bgColor="whitesmoke"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="DarkGray"
										Width="100%" CssClass="titleBar">Dados da Enquete</asp:label>
									<center><asp:panel id="pnlDica" style="Z-INDEX: 106; PADDING-TOP: 5px" runat="server" HorizontalAlign="Left"
											BackColor="#FFFFC0" Width="356px" BorderColor="InfoText" BorderWidth="1px" CssClass="pnlDica"
											Height="88px" Visible="False">
											<P>
												<asp:Label id="Label11" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="DarkGray"
													Width="100%" CssClass="titleDica">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dica</asp:Label><BR>
												<asp:Image id="Image1" runat="server" ImageAlign="Left" align="left" ImageUrl="../images/erro-2.gif"></asp:Image>&nbsp;
												<asp:label id="lblDicaText" style="TEXT-ALIGN: left" runat="server" Font-Size="8pt" ForeColor="InfoText"
													Width="256px" CssClass="pnlDicaTxt" Height="16px">Se você estiver usando bloqueio anti-popups, clique no botão <b>
														"Ir"</b> mantendo a tecla <b> Ctrl</b>  pressionada.</asp:label><BR>
											</P>
										</asp:panel></center>
									<TABLE id="Table1" style="MARGIN-TOP: 10px" cellSpacing="1" cellPadding="1" width="100%"
										border="0">
										<TR>
											<TD style="PADDING-LEFT: 10px; WIDTH: 53px" align="left"><asp:label id="Label3" runat="server" Font-Bold="True" Font-Size="8pt">Questão:</asp:label></TD>
											<TD style="PADDING-RIGHT: 10px; WIDTH: 450px" align="left"><asp:textbox id="txtQuestao" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="PADDING-LEFT: 10px; WIDTH: 53px" vAlign="top" align="left"><asp:label id="Label2" runat="server" Font-Bold="True" Font-Size="8pt" Width="84px" Height="25px">Resposta 1:</asp:label><BR>
												<asp:label id="Label4" runat="server" Font-Bold="True" Font-Size="8pt" Width="84px" Height="25px">Resposta 2:</asp:label><BR>
												<asp:label id="Label5" runat="server" Font-Bold="True" Font-Size="8pt" Width="84px" Height="25px">Resposta 3:</asp:label></TD>
											<TD style="PADDING-RIGHT: 10px" align="left"><asp:textbox id="txtResposta1" runat="server" Width="438px" Height="20px"></asp:textbox><BR>
												<asp:textbox id="txtResposta2" runat="server" Width="438px"></asp:textbox><BR>
												<asp:textbox id="txtResposta3" runat="server" Width="438px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px"
												align="left" colSpan="2">
												<P>&nbsp;</P>
											</TD>
										</TR>
									</TABLE>
									<asp:button id="btnCancel" runat="server" Text="Cancelar" Enabled="False"></asp:button><asp:button id="btnOk" runat="server" Width="71px" Text="OK" Enabled="False"></asp:button>&nbsp;&nbsp;&nbsp;
								</TD>
							</tr>
						</table>
						<P><BR>
							&nbsp;</P>
					</td>
				</TR>
				<tr>
					<td align="center" colSpan="3"><asp:label id="Label6" runat="server" Font-Bold="True" BackColor="Silver" Width="100%" CssClass="lblCopy"
							Height="21px">&copy; 2004 - Phosforo Verde - Todos os Direitos Reservados</asp:label></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>

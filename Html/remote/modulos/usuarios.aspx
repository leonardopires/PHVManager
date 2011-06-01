<%@ Page Language="vb" AutoEventWireup="false" Codebehind="usuarios.aspx.vb" Inherits="remote.usuarios" culture="pt-BR" uiCulture="pt-BR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>usuarios</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<%="<style type=text/css>"%>
		<% Response.WriteFile(Server.MapPath("../css/remote.css")) %>
		<%="</style>"%>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="usuariosLayout" id="Table1" style="WIDTH: 768px; HEIGHT: 320px; EIGHT: 315px"
				cellSpacing="0" cellPadding="0" width="768" bgColor="#f5f5f5" border="0">
				<tr>
					<td bgColor="#336666" colSpan="3"><IMG src="../images/remote-top.gif"><BR>
						<asp:panel id="pnlMenu" runat="server" HorizontalAlign="Right">
<asp:Label id="lblAlterna" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True">Alternar para: </asp:Label>
<asp:DropDownList id="lstAlterna" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True"
								DataValueField="url" DataTextField="nome" BackColor="#336666"></asp:DropDownList>
<asp:Button id="btnIr" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True" BackColor="#336666"
								BorderStyle="Solid" BorderColor="YellowGreen" BorderWidth="2px"
								Text="Ir" Width="30px"></asp:Button>&nbsp;&nbsp; 
      </asp:panel></td>
				</tr>
				<TR>
					<TD style="WIDTH: 189px" vAlign="top" align="center" bgColor="gainsboro" rowSpan="2">
						<P><asp:label id="Label9" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="DarkGray"
								Width="100%" CssClass="titleBar">Seleção de Usuário</asp:label></P>
						<P>&nbsp;
							<asp:listbox id="lstUsers" runat="server" Width="136" CssClass="listBox" Height="248px" Rows="15"></asp:listbox><BR>
							<asp:button id="btnAdd" runat="server" Width="24px" Text="+"></asp:button><asp:button id="btnDel" runat="server" Width="24px" Text="-"></asp:button><asp:button id="btnEdit" runat="server" Width="83px" Text="Editar"></asp:button></P>
					</TD>
					<TD style="WIDTH: 377px; PADDING-TOP: 0px; HEIGHT: 54px" vAlign="top" align="center"
						bgColor="white">&nbsp;
						<asp:panel id="Panel1" style="PADDING-TOP: 5px" runat="server" HorizontalAlign="Left" BackColor="#FFFFC0"
							Width="313px" BorderWidth="1px" BorderColor="InfoText" CssClass="pnlDica" Height="80px">
							<P>
								<asp:Label id="Label11" runat="server" ForeColor="White" Font-Size="8pt" Font-Bold="True" BackColor="DarkGray"
									Width="100%" CssClass="titleDica">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dica</asp:Label><BR>
								<asp:Image id="Image1" runat="server" align="left" ImageUrl="../images/icones/ic-info.gif"></asp:Image>&nbsp;
								<asp:label id="lblDicaText" style="TEXT-ALIGN: left" runat="server" ForeColor="InfoText" Font-Size="8pt"
									Width="241px" CssClass="pnlDicaTxt" Height="24px">Utilize a lista ao lado e os botões "+", "-" e "Editar" para gerenciar os usuários do sistema.</asp:label></P>
						</asp:panel></TD>
					<TD style="HEIGHT: 83px" vAlign="top" width="220" bgColor="gainsboro" rowSpan="2">
						<P><asp:label id="Label10" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="DarkGray"
								Width="100%" CssClass="titleBar">Seleção de Módulos</asp:label></P>
						<P style="PADDING-LEFT: 10px"><asp:label id="Label7" runat="server" Font-Size="8pt" Width="192px" Height="24px">Selecione os módulos aos quais esse usuário possuirá acesso:</asp:label></P>
						<P style="PADDING-LEFT: 10px"><asp:checkboxlist id=chlModulos runat="server" DataTextField="nome" DataValueField="url" Enabled="False" DataSource='<%# dsXML.tables("modulo").defaultview %>'>
							</asp:checkboxlist></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 377px" align="right"><asp:label id="Label8" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="White" BackColor="DarkGray"
							Width="100%" CssClass="titleBar">Dados do Usuário</asp:label>
						<TABLE id="Table2" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; WIDTH: 310px; BORDER-BOTTOM: 0px; HEIGHT: 157px"
							cellSpacing="0" cellPadding="0" width="310" border="0">
							<TR>
								<TD><asp:label id="Label1" runat="server" Font-Size="8pt">Nome de usuário:</asp:label></TD>
								<TD><asp:textbox id="txtUsername" runat="server" Enabled="False" MaxLength="16"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label2" runat="server" Font-Size="8pt">Senha:</asp:label></TD>
								<TD><asp:textbox id="txtPassword1" runat="server" Width="155px" Enabled="False" TextMode="Password"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label3" runat="server" Font-Size="8pt">Confirmar Senha:</asp:label></TD>
								<TD><asp:textbox id="txtPassword2" runat="server" Width="155px" Enabled="False" TextMode="Password"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label4" runat="server" Font-Size="8pt">Nome:</asp:label></TD>
								<TD><asp:textbox id="txtNome" runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label5" runat="server" Font-Size="8pt">Email:</asp:label></TD>
								<TD><asp:textbox id="txtEmail" runat="server" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 16px"><asp:label id="Label12" runat="server" Font-Size="8pt">Data de Nascimento:</asp:label></TD>
								<TD style="HEIGHT: 16px"><asp:textbox id="txtDataDia" runat="server" Width="32px" Enabled="False"></asp:textbox><asp:label id="Label13" runat="server" Font-Size="8pt">de</asp:label><asp:dropdownlist id="lstDataMes" runat="server" Width="112px" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<tr>
								<td colSpan="2"><asp:checkbox id="chkShowAniver" runat="server" Font-Size="8pt" Text="Exibir usuário na lista de aniversariantes do mês"
										Enabled="False"></asp:checkbox><BR>
									<asp:CheckBox id="chkAssociado" runat="server" Font-Size="8pt" Text="Usuário é associado à Afabre"
										Enabled="False"></asp:CheckBox><BR>
									&nbsp;</td>
							</tr>
						</TABLE>
						<asp:button id="btnCancel" runat="server" Text="Cancelar" Enabled="False"></asp:button>
						<asp:button id="btnOk" runat="server" Width="58px" Text="OK" Enabled="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<tr>
					<td colSpan="3"><asp:label id="Label6" runat="server" Font-Bold="True" BackColor="Silver" Width="100%" CssClass="lblCopy"
							Height="21px">&copy; 2004 - Phosforo Verde - Todos os Direitos Reservados</asp:label></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>

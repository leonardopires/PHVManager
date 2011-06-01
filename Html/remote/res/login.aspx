<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="remote.login"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Phosforo Verde - Sistema de Gerenciamento de Conteúdo </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/remote.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" rightMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" rules="all" bgColor="whitesmoke" border="0" style="border: 0px;">
				<tr>
					<td><IMG src="../images/remote-top.gif"></td>
				</tr>
				<tr>
					<td vAlign="middle" align="center">&nbsp;
						<table style="WIDTH: 322px; HEIGHT: 91px" cellSpacing="3" cellPadding="0" rules="all" width="322"
							border="0">
							<tr>
								<td align="right">
									<asp:Label id="Label1" runat="server" Font-Bold="True" Font-Size="8pt"> Usuário:</asp:Label></td>
								<td style="WIDTH: 150px">
									<asp:TextBox id="txtUsername" runat="server" MaxLength="32" Width="150px" tabIndex="1"></asp:TextBox>
								</td>
								<td>
									<asp:Button id="cmdLogin" runat="server" Text="Entrar" tabIndex="4"></asp:Button>
								</td>
							</tr>
							<tr>
								<td style="HEIGHT: 2px" align="right">
									<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="8pt">Senha:</asp:Label></td>
								<td style="WIDTH: 150px; HEIGHT: 2px">
									<asp:TextBox id="txtPassword" runat="server" TextMode="Password" MaxLength="32" Width="150px"
										tabIndex="2"></asp:TextBox>
								</td>
								<td style="HEIGHT: 2px">
								</td>
							</tr>
							<tr>
								<td align="center" colspan="3">
									<asp:Label id="lblResponse" runat="server" Width="252px" ForeColor="Red" CssClass="lblResponse"
										Font-Bold="True" Font-Size="8pt"></asp:Label>&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server" Width="100%" Height="21px" CssClass="lblCopy" BackColor="Silver"
							Font-Bold="True">&copy; 2004 - Phosforo Verde - Todos os Direitos Reservados</asp:Label>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

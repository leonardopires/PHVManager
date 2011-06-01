<%@ Page Language="vb" AutoEventWireup="false" Codebehind="login.aspx.vb" Inherits="afabre.login2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>login</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/afabre.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" bgColor="#dfdbdc" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="form1" action="login.aspx" runat="server" autocomplete="on">
			<asp:panel id="pnlLogin" style="Z-INDEX: 101; PADDING-TOP: 12px" runat="server" cssclass="form"
				Width="264px" Height="8px" HorizontalAlign="Justify">
				<SPAN style="MARGIN-LEFT: 10px">
					<asp:image id="Image6" runat="server" ImageUrl="../images/area-restrita.gif"></asp:image></SPAN>
				<TABLE id="Table1" style="MARGIN-TOP: 0px; MARGIN-LEFT: 20px; WIDTH: 216px; POSITION: relative; TOP: -5px; HEIGHT: 67px"
					border="0">
					<TR>
						<TD style="WIDTH: 54px">Usuário:&nbsp;<BR>
							<BR>
							Senha:&nbsp;&nbsp;&nbsp;
						</TD>
						<TD>
							<asp:textbox id="txtUser" runat="server" CssClass="txtBox"></asp:textbox><BR>
							<asp:textbox id="txtPassword" runat="server" CssClass="txtBox" TextMode="Password"></asp:textbox>
							<asp:imagebutton id="cmdLogin" runat="server" Height="17px" Width="17px" ImageUrl="../images/ir.gif"
								CssClass="cmdIr"></asp:imagebutton></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlMenu" style="PADDING-TOP: 12px" runat="server" Width="264px" Height="96px"
				CssClass="form" Visible="False" HorizontalAlign="Center">
				<P>
					<DIV style="PADDING-BOTTOM: 5px">
						<asp:Label id="lblWelcome" runat="server" ForeColor="Gray" Font-Size="8pt">Bem-vindo:</asp:Label>&nbsp;
						<asp:Label id="lblNome" runat="server" ForeColor="Gray" Font-Size="8pt" Font-Bold="True">Fulano</asp:Label></DIV>
					<asp:ImageButton id="imgUsuarios" runat="server" Height="37px" Width="38px" ImageUrl="../images/ic-usuarios-at.gif"></asp:ImageButton>
					<asp:ImageButton id="imgafabre" runat="server" Height="37px" Width="38px" ImageUrl="../images/ic-produtos-at.gif"></asp:ImageButton>
					<asp:ImageButton id="imgNoticias" runat="server" Height="37px" Width="38px" ImageUrl="../images/ic-noticias-at.gif"></asp:ImageButton>
					<asp:ImageButton id="imgMensagens" runat="server" Height="37px" Width="38px" ImageUrl="../images/ic-mensagens-at.gif"></asp:ImageButton>
					<asp:ImageButton id="imgArquivos" runat="server" Height="37px" Width="38px" ImageUrl="../images/ic-arquivos-at.gif"></asp:ImageButton>
					<asp:ImageButton id="imgLogoff" runat="server" Height="37px" Width="38px" ImageUrl="../images/logoff.gif"></asp:ImageButton>
					<asp:TextBox id="txtMenu" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BACKGROUND: #dfdbdc; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; TEXT-ALIGN: center"
						runat="server" Width="201px" ForeColor="Gray" Font-Size="8pt" Font-Bold="True" Columns="30"
						Font-Names="Tahoma"></asp:TextBox>
			</asp:panel></form>
	</body>
</HTML>

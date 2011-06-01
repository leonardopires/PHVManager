<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ifrEnquete.aspx.vb" Inherits="afabre.ifrEnquete" culture="pt-BR"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ifrEnquete</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/afabre.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" bgColor="#99bb28">
		<form id="Form1" method="post" runat="server">
			<P>
				&nbsp;
				<asp:label id="lblQuestao" runat="server" Font-Size="8pt" Font-Bold="True"></asp:label><BR>
				<asp:radiobuttonlist id=rblResposta runat="server" Font-Size="8pt" DataSource="<%# ds %>" DataMember="enquete" DataValueField="id_resposta" DataTextField="nome" Width="140px">
				</asp:radiobuttonlist></P>
			<P align="right">
				<asp:button id="btnVotar" runat="server" Font-Size="8pt" Font-Bold="True" Text="Votar" BorderStyle="Solid"
					BorderColor="OliveDrab" BackColor="DarkGreen" ForeColor="White" Width="41px"></asp:button></P>
		</form>
	</body>
</HTML>

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="getImage.aspx.vb" Inherits="afabre.getImage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>getImage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="whitesmoke">
		<form id="Form1" method="post" runat="server">
			<INPUT id="File1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 0px; POSITION: absolute; TOP: 8px; HEIGHT: 22px"
				type="file" size="1" name="fileImage" runat="server">
			<asp:ImageButton id="ImageButton1" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 8px"
				runat="server" ImageUrl="../images/ir.gif"></asp:ImageButton>
			<asp:Image id="img" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server"
				Height="88px" Width="120px"></asp:Image></form>
	</body>
</HTML>

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="imagePopup.aspx.vb" Inherits="afabre.imagePopup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>afabre</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
			<script language="javascript">
function resize() {
			window.resizeTo(window.document.images.item("Image1").width	, window.document.images.item("Image1").height + 35);
			window.moveTo((screen.width - window.document.images.item("Image1").width)/2, (screen.height - window.document.images.item("Image1").height + 35)/2)
			window.focus();
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="resize()">
		<form id="Form1" method="post" runat="server">
			<asp:Image id="Image1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server" ImageUrl="">
			</asp:Image>
		</form>

	</body>
</HTML>

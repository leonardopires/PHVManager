<%@ Page Language="vb" AutoEventWireup="false" Codebehind="erro.aspx.vb" Inherits="afabre.erro" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>erro</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/afabre.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlErro" style="Z-INDEX: 101;LEFT: 8px;VERTICAL-ALIGN: middle;POSITION: absolute;TOP: 8px"
				runat="server" HorizontalAlign="Center" Height="90%" Width="100%" CssClass="pnlErro">
				<asp:Panel id="pnlMsgBox" style="POSITION: relative" runat="server" CssClass="pnlMsgBox" Width="359"
					Height="144px" BackColor="Gainsboro" ms_positioning="GridLayout">
					<asp:Image id="imgMsg" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px" runat="server"></asp:Image>
					<asp:CheckBox id="chkMsgBox" style="Z-INDEX: 106; LEFT: 80px; POSITION: absolute; TOP: 72px; TEXT-ALIGN: left"
						runat="server" Font-Size="8pt" Visible="False"></asp:CheckBox>
					<asp:Label id="lblErroTitulo" style="Z-INDEX: 102; LEFT: 0px; PADDING-TOP: 5px; POSITION: absolute; TOP: 0px; TEXT-ALIGN: left"
						runat="server" Width="358px" Height="24px" BackColor="DarkBlue" ForeColor="White" Font-Bold="True"
						Font-Size="10pt">ERRO</asp:Label>
					<asp:Label id="lblMsg" style="Z-INDEX: 103; LEFT: 72px; POSITION: absolute; TOP: 40px; TEXT-ALIGN: left"
						runat="server" CssClass="lblMsg" Width="264px" Height="40px" ForeColor="Black" Font-Bold="True"
						Font-Size="8pt"></asp:Label>
					<asp:Button id="btnOk" style="Z-INDEX: 105; LEFT: 176px; POSITION: absolute; TOP: 112px" runat="server"
						Width="80px" Visible="False" Text="Ok"></asp:Button>
					<asp:Button id="btnCancel" style="Z-INDEX: 104; LEFT: 264px; POSITION: absolute; TOP: 112px"
						runat="server" Width="80px" Visible="False" Text="Cancelar"></asp:Button>
				</asp:Panel>
			</asp:panel></form>
	</body>
</HTML>

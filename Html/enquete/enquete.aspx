<%@ Page Language="vb" AutoEventWireup="false" Codebehind="enquete.aspx.vb" Inherits="afabre.enquete"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Afabre - Enquete</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/afabre.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" bgColor="whitesmoke" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="corpo" style="BORDER-RIGHT: #00cc00 3px ridge; BORDER-TOP: #00cc00 3px ridge; BORDER-LEFT: #00cc00 3px ridge; WIDTH: 416px; BORDER-BOTTOM: #00cc00 3px ridge; HEIGHT: 345px"
				cellSpacing="0" cellPadding="0" width="416" bgColor="gainsboro" border="0">
				<tr>
					<td style="WIDTH: 435px; HEIGHT: 54px" colSpan="4"><asp:image id="Image1" runat="server" ImageUrl="../images/topo-enquete.gif"></asp:image></td>
				</tr>
				<tr>
					<td style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 5px; WIDTH: 435px; COLOR: white; PADDING-TOP: 5px; HEIGHT: 2px"
						bgColor="#99cc00" colSpan="4"><asp:label id="lblQuestao" runat="server" Font-Bold="True" Font-Size="10pt" Width="408px" Height="50px"></asp:label></td>
				</tr>
				<tr>
					<td colSpan="4">&nbsp;
					</td>
				</tr>
				<TR>
					<TD class="tdl" style="BORDER-TOP: thin inset; BORDER-LEFT: thin inset; BORDER-BOTTOM: thin inset"
						align="center" width="70" bgColor="white"><asp:image id="imgPct1" runat="server" ImageUrl="enquete.aspx?a=b&amp;w=20&amp;h=200&amp;c=verde&amp;p=100"></asp:image><BR>
						<asp:label id="pct1" runat="server" Font-Bold="True" Font-Size="8pt"></asp:label>&nbsp;
					</TD>
					<TD class="tdc" style="BORDER-TOP: thin inset; BORDER-BOTTOM: thin inset" align="center"
						width="70" bgColor="white"><asp:image id="imgPct2" runat="server" ImageUrl="enquete.aspx?a=b&amp;w=20&amp;h=200&amp;c=vinho&amp;p=100"></asp:image><BR>
						<asp:label id="pct2" runat="server" Font-Bold="True" Font-Size="8pt"></asp:label></TD>
					<TD class="tdr" style="BORDER-RIGHT: thin inset; BORDER-TOP: thin inset; WIDTH: 69px; BORDER-BOTTOM: thin inset"
						align="center" width="69" bgColor="white"><asp:image id="imgPct3" runat="server" ImageUrl="enquete.aspx?a=b&amp;w=20&amp;h=200&amp;c=laranja&amp;p=100"></asp:image><BR>
						<asp:label id="pct3" runat="server" Font-Bold="True" Font-Size="8pt"></asp:label></TD>
					<TD style="WIDTH: 191px" align="right" width="191"><asp:panel id="Panel1" runat="server" Width="150px" BorderWidth="1px" BorderColor="Black" BorderStyle="Solid"
							HorizontalAlign="Left" CssClass="grfLegenda">
							<P><STRONG><FONT size="2">Legenda:<BR>
										&nbsp;<BR>
									</FONT></STRONG>
								<asp:Image id="imgLeg1" runat="server" ImageUrl="enquete.aspx?a=l&amp;w=10&amp;h=10&amp;c=verde"></asp:Image>
								<asp:Label id="leg1" runat="server" Font-Size="8pt">Label</asp:Label><BR>
								<asp:Image id="imgLeg2" runat="server" ImageUrl="enquete.aspx?a=l&amp;w=10&amp;h=10&amp;c=vinho"></asp:Image>
								<asp:Label id="leg2" runat="server" Font-Size="8pt">Label</asp:Label><BR>
								<asp:Image id="imgLeg3" runat="server" ImageUrl="enquete.aspx?a=l&amp;w=10&amp;h=10&amp;c=laranja"></asp:Image>
								<asp:Label id="leg3" runat="server" Font-Size="8pt">Label</asp:Label></P>
						</asp:panel></TD>
				</TR>
				<tr>
					<td colSpan="4">&nbsp;</td>
				</tr>
			</table>
		</form>

	</body>
</HTML>

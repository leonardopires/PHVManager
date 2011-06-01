<%@ Register TagPrefix="uc1" TagName="login" Src="login.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="bottom.ascx.vb" Inherits="afabre.bottom" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" enableViewState="False" %>
<TABLE class="tblBottom" id="tblBottom" height="100%" cellSpacing="0" cellPadding="0" width="100%"
	border="0">
	<TBODY>
		<TR>
			<TD style="BACKGROUND-POSITION: center center; BACKGROUND-IMAGE: url(<%=root%>/images/logo-back.gif); WIDTH: 269px; BACKGROUND-REPEAT: no-repeat"
							vAlign="middle" align="center"><asp:image id="Image1" runat="server" ImageAlign="Middle" ImageUrl="../images/logo.gif"></asp:image></TD>
			<TD style="WIDTH: 246px" vAlign="middle">
				<div class="form" id="Busca" style="Z-INDEX: 101">
					<P>&nbsp;
						<asp:image id="Image5" runat="server" ImageUrl="../images/busca.gif"></asp:image><BR>
						<BR>
						Palavra-chave:
						<asp:textbox id="txtBusca" runat="server" CssClass="txtBox" Width="96px"></asp:textbox><asp:imagebutton id="cmdBusca" runat="server" ImageUrl="../images/ir.gif" CssClass="cmdIr" Width="17px"
							Height="17px"></asp:imagebutton><BR>
						&nbsp;
						<asp:Panel id="pnlJs" runat="server" Width="1px" Height="1px"></asp:Panel></P>
				</div>
			</TD>
			<TD vAlign="middle">
				<uc1:login id="lgnLogin" runat="server" EnableViewState="False"></uc1:login>
			</TD>
		</TR>
		</TR></TBODY>
</TABLE>

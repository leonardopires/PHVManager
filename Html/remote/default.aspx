<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="remote.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Phosforo Verde - Sistema de Gerenciamento de Conteúdo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/remote.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" rules="all" bgColor="whitesmoke" border="0">
				<tr>
					<td bgColor="#336666">
						<IMG src="images/remote-top.gif"><BR>
						<asp:panel id="pnlMenu" runat="server" HorizontalAlign="Right" Height="20px">
<asp:LinkButton id="lnkLogout" runat="server" Font-Bold="True" ForeColor="White"><span style="padding-top: 5px; height: 20px; cursor:hand" unselectable=on>Logout</span></asp:LinkButton>&nbsp; 
      
&nbsp;&nbsp; 
      </asp:panel>
					</td>
				</tr>
				<tr>
					<td vAlign="middle" align="center">
						&nbsp;
						<asp:Panel id="Panel1" runat="server" Width="637px" HorizontalAlign="Left" BackColor="#FFFFC0"
							Height="72px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="pnlToolTip">
							<P><STRONG><IMG src="images/icones/ic-info.gif" align="left" border="0"></STRONG></P>
							<asp:Panel id="Panel2" runat="server" Width="580px" HorizontalAlign="Justify">
      <DIV style="PADDING-BOTTOM: 5px"><STRONG>Bem-vindo ao Sistema de Gerenciamento de Conteúdo da Phosforo Verde.</DIV></STRONG></STRONG>Este 
      sistema foi desenvolvido para facilitar a atualização e o gerenciamento do 
      conteúdo de seu site. Com ele você poderá adicionar, alterar ou remover 
      textos, notícias, imagens e usuários de seu site, bem como definir as 
      configurações locais do seu país de origem, definindo o seu fuso-horário 
      predileto. Para tanto, basta selecionar um dos itens do menu 
      abaixo.</asp:Panel>
						</asp:Panel><BR>
						<div style="WIDTH:637px; HEIGHT:13px; TEXT-ALIGN:left; align:left">Selecione um 
							item no menu abaixo para navegar para o respectivo gerenciador.</div>
						<BR>
						<table style="BORDER-RIGHT: 2px inset; BORDER-TOP: 2px inset; BORDER-LEFT: 2px inset; WIDTH: 639px; BORDER-BOTTOM: 2px inset; HEIGHT: 72px"
							cellSpacing="0" cellPadding="0" bgColor="white" border="0">
							<tr>
								<td vAlign="middle" align="center" colSpan="1"><asp:datalist id="lstModulos" runat="server" Width="560px" RepeatColumns="3" RepeatDirection="Horizontal">
										<ItemStyle HorizontalAlign="Center" Width="180px" VerticalAlign="Middle"></ItemStyle>
										<ItemTemplate>
											<A class=lnkLabel id=lnkLabel href='<%# remote.g.getroot(me.page) + "/modulos/" + databinder.eval(container.dataitem, "url") + ".aspx" %>' runat="server">
												<asp:image id=lnkIcone runat="server" ImageUrl='<%# remote.g.getroot(me.page) + "/images/icones/ic-" + databinder.eval(container.dataitem, "url") + ".gif" %>' imagealign="left">
												</asp:image><BR>
												<%# DataBinder.Eval(Container, "DataItem.Nome") %>
												<BR>
											</A>
										</ItemTemplate>
									</asp:datalist></td>
							</tr>
						</table>
						<BR>
						&nbsp;
					</td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server" Font-Bold="True" Width="100%" CssClass="lblCopy" BackColor="Silver"
							Height="21px">&copy; 2004 - Phosforo Verde - Todos os Direitos Reservados</asp:label></td>
				</tr>
			</table>
		</form>


	</body>
</HTML>

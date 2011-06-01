<%@ Page Language="vb" AutoEventWireup="false" Codebehind="viagens.aspx.vb" Inherits="afabre.viagens" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Afabre - Associação dos Funcionários Aposentados do BRDE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<%="<style>"%>
		<%response.writefile("../css/afabre.css")%>
		<%="</style>"%>
	</HEAD>
	<body bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<H1>
				<!-- ImageReady Slices (cabecalho.psd) --> Viagens
			</H1>
			<TABLE cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td>
						<P>Selecione um texto na listagem abaixo para exibir a versão completa:</P>
						<P>
							<asp:datalist id="lstNoticias" runat="server" Width="420px">
								<AlternatingItemStyle ForeColor="White" CssClass="lstNoticiasAlt" BackColor="#AEC900"></AlternatingItemStyle>
								<ItemTemplate>
									<asp:HyperLink id=lnkData runat="server" NavigateUrl='<%# afabre.g.getroot(me.page) & "/res/layout.aspx?url=" & afabre.g.getroot(me.page) + "/res/gettexto.aspx?id=" + system.convert.tostring(DataBinder.Eval(Container.DataItem, "id_texto")) %>'>
									
									<asp:Image id="Image13" runat="server" ImageUrl="../images/seta-esq-cl.gif"></asp:Image>&nbsp;
									<%# system.convert.todatetime(DataBinder.Eval(Container.DataItem, "data")).toshortdatestring %>
									</asp:HyperLink>&nbsp;-
									<asp:HyperLink id=lnkNoticiasNrm runat="server" NavigateUrl='<%# afabre.g.getroot(me.page) & "/res/layout.aspx?url=" & afabre.g.getroot(me.page) + "/res/gettexto.aspx?id=" + system.convert.tostring(DataBinder.Eval(Container.DataItem, "id_texto")) %>'>
										<%# DataBinder.Eval(Container.DataItem, "titulo") %>
									</asp:HyperLink>
								</ItemTemplate>
								<AlternatingItemTemplate>
									<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl='<%# afabre.g.getroot(me.page) & "/res/layout.aspx?url=" & afabre.g.getroot(me.page) + "/res/gettexto.aspx?id=" + system.convert.tostring(DataBinder.Eval(Container.DataItem, "id_texto")) %>'>
														
														<asp:Image id="Image21" runat="server" ImageUrl="../images/seta-dir-bc.gif"></asp:Image>&nbsp;
									<%# system.convert.todatetime(DataBinder.Eval(Container.DataItem, "data")).toshortdatestring %>
									</asp:HyperLink>&nbsp;-
									<asp:HyperLink id=lnkNoticiasAlt runat="server" NavigateUrl='<%# afabre.g.getroot(me.page) & "/res/layout.aspx?url=" & afabre.g.getroot(me.page) + "/res/gettexto.aspx?id=" + system.convert.tostring(DataBinder.Eval(Container.DataItem, "id_texto")) %>' Text="" CssClass="lstNoticiasAlt">
										<%# DataBinder.Eval(Container.DataItem, "titulo") %>
									</asp:HyperLink>
								</AlternatingItemTemplate>
							</asp:datalist></P>
						<P><BR>
							&nbsp;</P>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>

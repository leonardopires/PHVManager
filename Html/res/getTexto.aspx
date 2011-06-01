<%@ Page Language="vb" AutoEventWireup="false" Codebehind="getTexto.aspx.vb" Inherits="afabre.getTexto"%>
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
			<P>&nbsp;
				<asp:Label id="lblTitulo" runat="server" ForeColor="DarkGreen" Font-Bold="True" Font-Size="16pt"></asp:Label></P>
			<P>
				<asp:Image id="Image1" runat="server" ImageUrl="" ImageAlign="Left" style="MARGIN-RIGHT: 15px"></asp:Image><BR>
				<asp:Label id="lblTexto" runat="server" CssClass="lblTexto"></asp:Label></P>
			<P>
				
				<a href=<%="/res/layout.aspx?url=/" + ds.tables("texto").defaultview(0).item("nomeurl") + "/" + ds.tables("texto").defaultview(0).item("nomeurl") + ".aspx" %>>
				<%= "Ler mais&nbsp;" + ds.tables("texto").defaultview(0).item("nomept")%>
				</a>&nbsp;|
				
				
				<asp:HyperLink id="HyperLink2" runat="server" NavigateUrl="/">Voltar para Home</asp:HyperLink><BR>
				&nbsp;</P>
		</form>
	</body>
</HTML>

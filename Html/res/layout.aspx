<%@ Page Language="vb" AutoEventWireup="false" Codebehind="layout.aspx.vb" Inherits="afabre.layout" %>
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
	<body bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" rightMargin="0"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblLayout" cellSpacing="0" cellPadding="0" width="768" bgColor="white" border="0">
				<tr>
					<td colSpan="3">
						<!-- ImageReady Slices (cabecalho.psd) -->
						<TABLE cellSpacing="0" cellPadding="0" width="768" border="0">
							<TR>
								<TD colSpan="2"><IMG height="11" alt="" src="../images/cabecalho_01.gif" width="55"></TD>
								<TD colSpan="2"><IMG height="11" alt="" src="../images/cabecalho_02.jpg" width="139"></TD>
								<TD rowSpan="5"><IMG height="108" alt="" src="../images/cabecalho_03.jpg" width="93"></TD>
								<TD rowSpan="3"><IMG height="61" alt="" src="../images/cabecalho_04.jpg" width="299"></TD>
								<TD rowSpan="5"><IMG height="108" alt="" src="../images/cabecalho_05.jpg" width="146"></TD>
								<TD rowSpan="2"><IMG height="31" alt="" src="../images/cabecalho_06.gif" width="36"></TD>
								<TD><IMG height="11" alt="" src="../images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD rowSpan="3"><IMG height="82" alt="" src="../images/cabecalho_07.gif" width="28"></TD>
								<TD colSpan="2" rowSpan="3"><IMG height="82" alt="" src="../images/cabecalho_08.gif" width="116"></TD>
								<TD rowSpan="3"><IMG height="82" alt="" src="../images/cabecalho_09.gif" width="50"></TD>
								<TD><IMG height="20" alt="" src="../images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD rowSpan="3"><IMG height="77" alt="" src="../images/cabecalho_10.jpg" width="36"></TD>
								<TD><IMG height="30" alt="" src="../images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD rowSpan="2"><IMG height="47" alt="" src="../images/cabecalho_11.jpg" width="299"></TD>
								<TD><IMG height="32" alt="" src="../images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD colSpan="3" rowSpan="2"><IMG height="39" alt="" src="../images/cabecalho_12.gif" width="144"></TD>
								<TD rowSpan="2"><IMG height="39" alt="" src="../images/cabecalho_13.gif" width="50"></TD>
								<TD><IMG height="15" alt="" src="../images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD><IMG height="24" alt="" src="../images/cabecalho_14.jpg" width="93"></TD>
								<TD align="right" background="../images/cabecalho_15.jpg" bgColor="#99bb28" colSpan="3"
									unselectable="on"><asp:datalist id=lstMenu runat="server" unselectable="on" DataSource="<%# dsXml %>" RepeatDirection="Horizontal" RepeatLayout="Flow">
										<ItemTemplate>
											<asp:HyperLink id=lnkItem runat="server" CssClass="lnkItem" Text='<%# databinder.eval(container.dataitem, "nomept") %>' NavigateUrl='<%# afabre.g.getRoot(Me.Page) & "/res/layout.aspx?url=" + afabre.g.getroot(me.page) + "/"  + databinder.eval(container.dataitem, "nomeurl") + "/" + databinder.eval(container.dataitem, "nomeurl") + ".aspx" %>' unselectable=on>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:datalist></TD>
								<TD><IMG height="24" alt="" src="../images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="28"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="27"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="89"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="50"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="93"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="299"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="146"></TD>
								<TD><IMG height="1" alt="" src="../images/spacer.gif" width="36"></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<!-- End ImageReady Slices --></td>
				</tr>
				<tr>
					<td>
						<table style="MARGIN-TOP: 5px" cellSpacing="0" cellPadding="0" rules="all" width="768"
							border="0">
							<tr>
								<td vAlign="top" bgColor="#227725">
									<table cellSpacing="0" cellPadding="0" width="158" bgColor="#ffffff" border="0">
										<tr>
											<td width="158" height="23"><asp:image id="imgEsqTop" runat="server" ImageUrl="../images/esq-top.gif"></asp:image></td>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px; HEIGHT: 71px"
												width="158" bgColor="#aec900" height="0">
												<div class="dica-saude"><asp:image id="Image5" runat="server" ImageUrl="../images/dica-saude.gif"></asp:image></div>
												<asp:image id="imgSaude" runat="server" ImageAlign="Left" Width="60px"></asp:image><asp:label id="lblTitSaude" runat="server" CssClass="titDica"></asp:label><BR>
												<asp:hyperlink id="lnkMaisSaude" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#227725"><img src="../images/seta-esq-es.gif" border="0"> leia mais</asp:hyperlink></td>
										</tr>
										<tr>
											<td width="158" height="35"><asp:image id="imgEsqMid" runat="server" ImageUrl="../images/esq-mid.gif"></asp:image></td>
										</tr>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px" width="158"
												bgColor="#99bb28" height="0">
												<div class="dica-viagem"><asp:image id="Image6" runat="server" ImageUrl="../images/dica-viagem.gif"></asp:image></div>
												<asp:image id="imgViagens" runat="server" ImageAlign="Left" Width="60px"></asp:image><asp:label id="lblTitViagens" runat="server" CssClass="titDica"></asp:label><BR>
												<asp:hyperlink id="lnkMaisViagens" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#227725"><img src="../images/seta-esq-es.gif" border="0"> leia mais</asp:hyperlink></td>
										</tr>
										<tr>
											<td width="158" height="36"><asp:image id="imgEsqBtm" runat="server" ImageUrl="../images/esq-btm.gif"></asp:image></td>
										</tr>
									</table>
									<div class="aniver"><asp:image id="Image7" runat="server" ImageUrl="../images/aniver.gif"></asp:image></div>
									&nbsp;
									<asp:label id="lblMes" runat="server" Font-Size="10pt" Font-Bold="True" ForeColor="YellowGreen"></asp:label><asp:datalist id="lstAniver" runat="server">
										<ItemTemplate>
											&nbsp;
											<asp:Label id=lblData runat="server" Font-Size="7pt" Font-Bold="True" ForeColor="White" Text='<%# databinder.eval(container.dataitem, "data") %>'>
											</asp:Label><FONT color="#ffffff" size="1">&nbsp;- </FONT>
											<asp:Label id=lblNome runat="server" Font-Size="7pt" Font-Bold="True" ForeColor="White" Text='<%# databinder.eval(container.dataitem, "nome") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:datalist><BR>
								</td>
								<td vAlign="top" align="center" width="452" height="*">
									<table class="tblCorpo" cellSpacing="0" cellPadding="0" rules="all" width="442" border="0">
										<tr>
											<td class="cllBannerTop" align="center" colSpan="2"><asp:image id="imgBannerTop" runat="server" ImageUrl="../images/banners/01.gif" DESIGNTIMEDRAGDROP="4621"
													Visible="False"></asp:image></td>
										</tr>
										<tr>
											<td colspan="2"><%server.execute(request.querystring("url"))%></td>
										</tr>
										<TR>
										</TR>
										<TR>
											<TD class="td" align="center" colSpan="2"></TD>
										</TR>
										<TR>
											<td class="cllBanner" align="center" colSpan="2"><asp:image id="Image4" runat="server" ImageUrl="../images/banners/01.gif" Visible="False"></asp:image></td>
										</TR>
									</table>
								</td>
								<TD vAlign="top" bgColor="#227725">
									<table cellSpacing="0" cellPadding="0" width="120" bgColor="#ffffff" border="0">
										<tr>
											<td width="169" height="23" style="WIDTH: 169px"><asp:image id="Image1" runat="server" ImageUrl="../images/dir-top.gif"></asp:image></td>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-BOTTOM: 10px; WIDTH: 169px; HEIGHT: 105px" width="169"
												bgColor="#aec900" height="0" valign="top">
												<div class="busca"><asp:image id="Image8" runat="server" ImageUrl="../images/busca.gif"></asp:image></div>
												<center>
													<IFRAME style="WIDTH: 147px; HEIGHT: 52px" src="..\busca\ifrbusca.aspx" frameBorder="0"
														width="150" scrolling="no" height="300"></IFRAME>
												</center>
											</td>
										</tr>
										<tr>
											<td width="169" height="35" style="WIDTH: 169px"><asp:image id="Image2" runat="server" ImageUrl="../images/dir-mid.gif"></asp:image></td>
										</tr>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-BOTTOM: 10px; WIDTH: 169px; HEIGHT: 196px" width="169"
												bgColor="#99bb28" height="0">
												<div class="enquete"><asp:image id="Image9" runat="server" ImageUrl="../images/enquete.gif"></asp:image></div>
												<iframe src="..\enquete\ifrEnquete.aspx" width="150" height="300" frameBorder="0" scrolling="no"
													style="WIDTH: 150px; HEIGHT: 186px"></iframe>
											</td>
										</tr>
										<tr>
											<td width="169" height="36" style="WIDTH: 169px"><asp:image id="Image3" runat="server" ImageUrl="../images/dir-btm.gif"></asp:image></td>
										</tr>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px" align="left"
												bgColor="#227725">
												<div class="enquete">
													<asp:image id="Image13" runat="server" ImageUrl="../images/receitas.gif"></asp:image><BR>
													<asp:datalist id="lstReceitas" runat="server" Width="130px" HorizontalAlign="Right">
														<ItemTemplate>
															<FONT color="#ffffff" size="1">
																<asp:HyperLink id=lnkReceitaTitulo runat="server" ForeColor="White" Font-Bold="True" Font-Size="8pt" NavigateUrl='<%# afabre.g.getRoot(Me.Page) &amp; "/res/layout.aspx?url=" &amp; afabre.g.getRoot(Me.Page) &amp; "/res/gettexto.aspx?id=" &amp; System.Convert.ToString(databinder.eval(container.dataitem, "id_texto")) %>' Text='<%# databinder.eval(container.dataitem, "titulo") %>'>
																</asp:HyperLink></FONT>
														</ItemTemplate>
													</asp:datalist></div>
											</td>
										</tr>
									</table>
									&nbsp;
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<IMG style="Z-INDEX: 101; LEFT: 680px; POSITION: relative; TOP: -15px" src="../images/logo-phv.gif">
			<asp:Panel id="Panel1" style="Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 0px" runat="server"
				Width="232px" Height="140px">
				<A 
style="WIDTH: 100%; COLOR: white; HEIGHT: 100%" 
href="<%=afabre.g.getroot(me.page)%>/">&nbsp;</A></asp:Panel>
		</form>
	</body>
</HTML>

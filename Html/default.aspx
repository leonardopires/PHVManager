<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="afabre.default1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Afabre - Associação dos Funcionários Aposentados do BRDE</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<%="<style>"%>
		<%response.writefile("css/afabre.css")%>
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
								<TD colSpan="2"><IMG height="11" alt="" src="images/cabecalho_01.gif" width="55"></TD>
								<TD colSpan="2"><IMG height="11" alt="" src="images/cabecalho_02.jpg" width="139"></TD>
								<TD rowSpan="5"><IMG height="108" alt="" src="images/cabecalho_03.jpg" width="93"></TD>
								<TD rowSpan="3"><IMG height="61" alt="" src="images/cabecalho_04.jpg" width="299"></TD>
								<TD rowSpan="5"><IMG height="108" alt="" src="images/cabecalho_05.jpg" width="146"></TD>
								<TD rowSpan="2"><IMG height="31" alt="" src="images/cabecalho_06.gif" width="36"></TD>
								<TD><IMG height="11" alt="" src="images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD rowSpan="3"><IMG height="82" alt="" src="images/cabecalho_07.gif" width="28"></TD>
								<TD colSpan="2" rowSpan="3"><IMG height="82" alt="" src="images/cabecalho_08.gif" width="116"></TD>
								<TD rowSpan="3"><IMG height="82" alt="" src="images/cabecalho_09.gif" width="50"></TD>
								<TD><IMG height="20" alt="" src="images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD rowSpan="3"><IMG height="77" alt="" src="images/cabecalho_10.jpg" width="36"></TD>
								<TD><IMG height="30" alt="" src="images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD rowSpan="2"><IMG height="47" alt="" src="images/cabecalho_11.jpg" width="299"></TD>
								<TD><IMG height="32" alt="" src="images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD colSpan="3" rowSpan="2"><IMG height="39" alt="" src="images/cabecalho_12.gif" width="144"></TD>
								<TD rowSpan="2"><IMG height="39" alt="" src="images/cabecalho_13.gif" width="50"></TD>
								<TD><IMG height="15" alt="" src="images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD><IMG height="24" alt="" src="images/cabecalho_14.jpg" width="93"></TD>
								<TD align="right" background="images/cabecalho_15.jpg" bgColor="#99bb28" colSpan="3"
									unselectable="on"><asp:datalist id=lstMenu runat="server" unselectable="on" DataSource="<%# dsXml %>" RepeatDirection="Horizontal" RepeatLayout="Flow">
										<ItemTemplate>
											<asp:HyperLink id=lnkItem runat="server" CssClass="lnkItem" Text='<%# databinder.eval(container.dataitem, "nomept") %>' NavigateUrl='<%# afabre.g.getRoot(Me.Page) & "/res/layout.aspx?url=" + afabre.g.getroot(me.page) + "/"  + databinder.eval(container.dataitem, "nomeurl") + "/" + databinder.eval(container.dataitem, "nomeurl") + ".aspx" %>' unselectable=on>
											</asp:HyperLink>
										</ItemTemplate>
									</asp:datalist></TD>
								<TD><IMG height="24" alt="" src="images/spacer.gif" width="1"></TD>
							</TR>
							<TR>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="28"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="27"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="89"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="50"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="93"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="299"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="146"></TD>
								<TD><IMG height="1" alt="" src="images/spacer.gif" width="36"></TD>
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
											<td width="158" height="23"><asp:image id="imgEsqTop" runat="server" ImageUrl="images/esq-top.gif"></asp:image></td>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px; HEIGHT: 71px"
												width="158" bgColor="#aec900" height="0">
												<div class="dica-saude"><asp:image id="Image5" runat="server" ImageUrl="images/dica-saude.gif"></asp:image></div>
												<asp:image id="imgSaude" runat="server" ImageAlign="Left" Width="60px"></asp:image><asp:label id="lblTitSaude" runat="server" CssClass="titDica"></asp:label><BR>
												<asp:hyperlink id="lnkMaisSaude" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#227725"><img src="images/seta-esq-es.gif" border="0"> leia mais</asp:hyperlink></td>
										</tr>
										<tr>
											<td width="158" height="35"><asp:image id="imgEsqMid" runat="server" ImageUrl="images/esq-mid.gif"></asp:image></td>
										</tr>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px" width="158"
												bgColor="#99bb28" height="0">
												<div class="dica-viagem"><asp:image id="Image6" runat="server" ImageUrl="images/dica-viagem.gif"></asp:image></div>
												<asp:image id="imgViagens" runat="server" ImageAlign="Left" Width="60px"></asp:image><asp:label id="lblTitViagens" runat="server" CssClass="titDica"></asp:label><BR>
												<asp:hyperlink id="lnkMaisViagens" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#227725"><img src="images/seta-esq-es.gif" border="0"> leia mais</asp:hyperlink></td>
										</tr>
										<tr>
											<td width="158" height="36"><asp:image id="imgEsqBtm" runat="server" ImageUrl="images/esq-btm.gif"></asp:image></td>
										</tr>
									</table>
									<div class="aniver"><asp:image id="Image7" runat="server" ImageUrl="images/aniver.gif"></asp:image></div>
									&nbsp;
									<asp:label id="lblMes" runat="server" Font-Size="10pt" Font-Bold="True" ForeColor="YellowGreen"></asp:label><asp:datalist id="lstAniver" runat="server">
										<ItemTemplate>
											&nbsp;
											<asp:Label id=lblData runat="server" Font-Size="7pt" Font-Bold="True" ForeColor="White" Text='<%# databinder.eval(container.dataitem, "data") %>'>
											</asp:Label><FONT color="#ffffff" size="1">&nbsp;- </FONT>
											<asp:Label id=lblNome runat="server" Font-Size="7pt" Font-Bold="True" ForeColor="White" Text='<%# databinder.eval(container.dataitem, "nome") %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:datalist></td>
								<td vAlign="top" align="center" width="452" height="*">
									<table class="tblCorpo" cellSpacing="0" cellPadding="0" rules="all" width="442" border="0">
										<tr>
											<td class="cllBannerTop" align="center" colSpan="2"><asp:image id="imgBannerTop" runat="server" ImageUrl="images/banners/01.gif" DESIGNTIMEDRAGDROP="4621"
													Visible="False"></asp:image></td>
										</tr>
										<tr>
											<%if count >= 1 then%>
											<td class="td" style="HEIGHT: 19px" colSpan="2">
												<P><asp:image id="Image10" runat="server" ImageUrl="images/seta-esq-cl.gif"></asp:image>&nbsp;<asp:label id="lblDateHeadline" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#99BB28">00/00/0000</asp:label><BR>
													<asp:panel id="Panel1" runat="server" HorizontalAlign="Center">
														<asp:Label id="lblTitleHeadline" runat="server" ForeColor="#227725" Font-Bold="True" Font-Size="13pt">Espaço reservado à chamada da matéria principal sobre a afabre</asp:Label>
													</asp:panel><asp:image id="imgHeadline" runat="server" ImageUrl="images/foto-dummy-princ.jpg" ImageAlign="Left"
														Width="104px"></asp:image><asp:panel id="pnlHeadline" runat="server" Width="98%" CssClass="pnlHeadline"></P>
												<P align="right"><asp:label id="lblIntroHeadline" runat="server" Width="100%" CssClass="lblIntro" Height="100px"
														Visible="False">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed justo neque, facilisis vel, congue pellentesque, venenatis tempus, libero. Aliquam pharetra aliquam sapien. Nunc in erat. Fusce malesuada, ipsum id tristique cursus, ante purus dictum felis, vel euismod metus libero ac wisi. Nullam volutpat justo congue felis. Nulla arcu. Sed porttitor nibh id erat.</asp:label><BR>
													<asp:hyperlink id="lnkLeiaMaisHeadline" runat="server"><img src="images/seta-esq-cl.gif" border="0"> leia mais</asp:hyperlink>&nbsp;&nbsp;&nbsp;
												</P>
												</asp:panel></td>
											<%end if%>
										</tr>
										<tr>
											<%if count >= 2 then%>
											<td class="td<%if count =3 or count >= 5 then%>e<%end if%>" 
                vAlign=top width="50%" 
                colSpan="<%if count = 2 or count =4 then %>2<%else%>1<%end if%>" 
                >
												<P><asp:image id="Image11" runat="server" ImageUrl="images/seta-esq-cl.gif"></asp:image>&nbsp;<asp:label id="lblDate1" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#99BB28">00/00/0000</asp:label>
													<asp:panel id="Panel3" runat="server" HorizontalAlign="Left">
														<%if count =2 or count = 4 then%>
														<CENTER><%end if%>
															<asp:Label id="lblTitle1" runat="server" ForeColor="#227725" Font-Bold="True" Font-Size="10pt">Espaço reservado à chamada da matéria sobre a afabre</asp:Label><%if count =2 or count = 4 then%></CENTER>
														<%end if%>
													</asp:panel><asp:image id="img1" runat="server" ImageUrl="images/foto-dummy-princ.jpg" ImageAlign="Left"
														Width="72px"></asp:image><asp:panel id="Panel2" runat="server" Width="98%" CssClass="pnlHeadline">
														<P></P>
														<P></P>
														<P align="right">
															<asp:label id="lblTexto1" runat="server" Width="100%" CssClass="lblIntro" Visible="False" Height="70px">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed justo neque, facilisis.</asp:label><BR>
															<asp:hyperlink id="lnkNoticia1" runat="server"><img src="images/seta-esq-cl.gif" border="0"> leia mais</asp:hyperlink>&nbsp;&nbsp;&nbsp;
														</P>
													</asp:panel>
												<P></P>
												<%end if%>
											</td>
											<%if count = 2 or count =4 then %>
										</tr>
										<tr>
											<%end if%>
											<%if count >= 3 then%>
											<td class="td<%if count =4 then%>e<%end if%>" vAlign=top 
                width="50%">
												<P><asp:image id="Image15" runat="server" ImageUrl="images/seta-esq-cl.gif"></asp:image>&nbsp;<asp:label id="lblDate2" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#99BB28">00/00/0000</asp:label><BR>
													<asp:panel id="Panel5" runat="server" HorizontalAlign="Left">
														<asp:Label id="lblTitle2" runat="server" ForeColor="#227725" Font-Bold="True" Font-Size="10pt">Espaço reservado à chamada da matéria sobre a afabre</asp:Label>
													</asp:panel><asp:image id="img2" runat="server" ImageUrl="images/foto-dummy-princ.jpg" ImageAlign="Left"
														Width="72px"></asp:image><asp:panel id="Panel4" runat="server" Width="98%" CssClass="pnlHeadline"></P>
												<P></P>
												<P align="right"><asp:label id="lblTexto2" runat="server" Width="100%" CssClass="lblIntro" Height="70px" Visible="False">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed justo neque, facilisis.</asp:label><BR>
													&nbsp;
													<asp:hyperlink id="lnkNoticia2" runat="server"><img src="images/seta-esq-cl.gif" border="0"> leia mais</asp:hyperlink>&nbsp;&nbsp;
												</P>
												</asp:panel></td>
											<% end if %>
											<%if count = 2 or count =4 then %>
											<%else %>
										</tr>
										<tr>
											<%end if%>
											<%if count >= 4 then%>
											<td class="td<%if count >=5 then%>e<%end if%>" vAlign=top 
                width="50%">
												<P><asp:image id="Image12" runat="server" ImageUrl="images/seta-esq-cl.gif"></asp:image>&nbsp;
													<asp:label id="lblDate3" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#99BB28">00/00/0000</asp:label><BR>
													<asp:panel id="Panel7" runat="server" HorizontalAlign="Left">
														<asp:Label id="lblTitle3" runat="server" ForeColor="#227725" Font-Bold="True" Font-Size="10pt">Espaço reservado à chamada da matéria sobre a afabre</asp:Label>
													</asp:panel><asp:image id="img3" runat="server" ImageUrl="images/foto-dummy-princ.jpg" ImageAlign="Left"
														Width="72px"></asp:image><asp:panel id="Panel6" runat="server" Width="98%" CssClass="pnlHeadline"></P>
												<P></P>
												<P align="right"><asp:label id="lblTexto3" runat="server" Width="100%" CssClass="lblIntro" Height="70px" Visible="False">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed justo neque, facilisis.</asp:label><BR>
													<asp:hyperlink id="lnkNoticia3" runat="server"><img src="images/seta-esq-cl.gif" border="0"> leia mais</asp:hyperlink>&nbsp;&nbsp;&nbsp;
												</P>
												</asp:panel></td>
											<% end if %>
											<%if count >= 5 then%>
											<TD class="td" vAlign="top" width="50%">
												<P><asp:image id="Image14" runat="server" ImageUrl="images/seta-esq-cl.gif"></asp:image>&nbsp;
													<asp:label id="lblDate4" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="#99BB28">00/00/0000</asp:label><asp:panel id="Panel9" runat="server" HorizontalAlign="Left">
														<asp:Label id="lblTitle4" runat="server" ForeColor="#227725" Font-Bold="True" Font-Size="10pt">Espaço reservado à chamada da matéria sobre a afabre</asp:Label>
													</asp:panel><asp:image id="img4" runat="server" ImageUrl="images/foto-dummy-princ.jpg" ImageAlign="Left"
														Width="72px"></asp:image><asp:panel id="Panel8" runat="server" Width="98%" CssClass="pnlHeadline"></P>
												<P></P>
												<P align="right"><asp:label id="lblTexto4" runat="server" Width="100%" CssClass="lblIntro" Height="70px" Visible="False">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Sed justo neque, facilisis.</asp:label><BR>
													<asp:hyperlink id="lnkNoticia4" runat="server"><img src="images/seta-esq-cl.gif" border="0"> leia mais</asp:hyperlink>&nbsp;&nbsp;&nbsp;
												</P>
												</asp:panel></TD>
											<%end if%>
										</tr>
										<TR>
										</TR>
										<TR>
											<TD class="td" align="center" colSpan="2"><asp:datalist id="lstNoticias" runat="server" Width="420px">
													<AlternatingItemStyle ForeColor="White" CssClass="lstNoticiasAlt" BackColor="#AEC900"></AlternatingItemStyle>
													<ItemTemplate>
														<asp:HyperLink id=lnkNoticiasNrm runat="server" NavigateUrl='<%# afabre.g.getroot(me.page) + "/res/default.aspx?url=" + afabre.g.getroot(me.page) + "/noticias/noticias.aspx?id=" + system.convert.tostring(DataBinder.Eval(Container.DataItem, "id_texto")) %>'>
<asp:Image runat="server" ID="Image13" ImageUrl="images/seta-esq-cl.gif"></asp:Image>
&nbsp;
														<asp:Label runat="server" ForeColor="#99BB28" ID="Label3" Font-Size="8pt" Font-Bold="True" Text='<%# system.convert.todatetime(databinder.eval(container.dataitem, &quot;data&quot;)).toshortdatestring %>'>
															</asp:Label>
&nbsp;- <%# DataBinder.Eval(Container.DataItem, "titulo") %></asp:HyperLink>
													</ItemTemplate>
													<AlternatingItemTemplate>
														<asp:HyperLink id=lnkNoticiasAlt runat="server" CssClass="lstNoticiasAlt" Text="" NavigateUrl='<%# afabre.g.getroot(me.page) + "/noticias/noticias.aspx?id=" + system.convert.tostring(DataBinder.Eval(Container.DataItem, "id_texto")) %>'>
														<asp:Image id="Image21" runat="server" ImageUrl="images/seta-dir-bc.gif"></asp:Image>&nbsp;
														<asp:Label id=Label14 runat="server" ForeColor="White" Font-Bold="True" Font-Size="8pt" Text='<%# system.convert.todatetime(databinder.eval(container.dataitem, "data")).toshortdatestring %>'>
															</asp:Label>&nbsp;- <%# DataBinder.Eval(Container.DataItem, "titulo") %>
														</asp:HyperLink>
													</AlternatingItemTemplate>
												</asp:datalist></TD>
										</TR>
										<TR>
											<td class="cllBanner" align="center" colSpan="2"><asp:image id="Image4" runat="server" ImageUrl="images/banners/01.gif" Visible="False"></asp:image></td>
										</TR>
									</table>
								</td>
								<TD vAlign="top" bgColor="#227725">
									<table cellSpacing="0" cellPadding="0" width="0" bgColor="#ffffff" border="0">
										<tr>
											<td width="158" height="23"><asp:image id="Image1" runat="server" ImageUrl="images/dir-top.gif"></asp:image></td>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px" width="158"
												bgColor="#aec900" height="0">
												<div class="busca"><asp:image id="Image8" runat="server" ImageUrl="images/busca.gif"></asp:image></div>
												<center><asp:textbox id="txtBusca" runat="server" Width="96px" Font-Size="8pt" Font-Bold="True" ForeColor="DarkGreen"
														Height="20px" BorderStyle="Solid" BorderColor="DarkOliveGreen" BackColor="#8EC900" BorderWidth="1px"></asp:textbox><asp:button id="btnBusca" runat="server" Width="45px" Font-Size="8pt" Font-Bold="True" ForeColor="White"
														Height="20px" BorderStyle="Solid" BorderColor="OliveDrab" BackColor="DarkGreen" Text="Buscar"></asp:button>
													<DIV></DIV>
												</center>
											</td>
										</tr>
										<tr>
											<td width="158" height="35"><asp:image id="Image2" runat="server" ImageUrl="images/dir-mid.gif"></asp:image></td>
										</tr>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px" width="158"
												bgColor="#99bb28" height="0">
												<div class="enquete"><asp:image id="Image9" runat="server" ImageUrl="images/enquete.gif"></asp:image><BR>
												</div>
												&nbsp;
												<asp:label id="lblQuestao" runat="server" Font-Size="8pt" Font-Bold="True"></asp:label><br>
												<asp:radiobuttonlist id=rblResposta runat="server" DataSource="<%# ds %>" DataTextField="nome" DataValueField="id_resposta" DataMember="enquete">
												</asp:radiobuttonlist>
												<P align="right"><asp:button id="btnVotar" runat="server" Width="41px" Font-Size="8pt" Font-Bold="True" ForeColor="White"
														BorderStyle="Solid" BorderColor="OliveDrab" BackColor="DarkGreen" Text="Votar"></asp:button>&nbsp;
												</P>
											</td>
										</tr>
										<tr>
											<td width="158" height="36"><asp:image id="Image3" runat="server" ImageUrl="images/dir-btm.gif"></asp:image></td>
										</tr>
										<tr>
											<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 10px" align="left"
												bgColor="#227725">
												<div class="enquete">
													<asp:image id="Image13" runat="server" ImageUrl="images/receitas.gif"></asp:image><BR>
													<asp:datalist id="lstReceitas" runat="server" Width="130px" HorizontalAlign="Right">
														<ItemTemplate>
															<FONT color="#ffffff" size="1">
																<asp:HyperLink id=lnkReceitaTitulo runat="server" ForeColor="White" Font-Bold="True" Font-Size="8pt" Text='<%# databinder.eval(container.dataitem, "titulo") %>' NavigateUrl='<%# afabre.g.getRoot(Me.Page) &amp; "/res/layout.aspx?url=" &amp; afabre.g.getRoot(Me.Page) &amp; "/res/gettexto.aspx?id=" &amp; System.Convert.ToString(databinder.eval(container.dataitem, "id_texto")) %>'>
																</asp:HyperLink></FONT>
														</ItemTemplate>
													</asp:datalist></div>
											</td>
										</tr>
									</table>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<IMG style="LEFT: 680px; POSITION: relative; TOP: -15px" src="images/logo-phv.gif">
		</form>


	</body>
</HTML>

<%@ Page Language="vb" validateRequest="false" AutoEventWireup="false" Codebehind="receitas.aspx.vb" Inherits="remote.receitas" smartNavigation="False" aspCompat="True" culture="pt-BR" enableViewStateMac="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML dir="ltr">
	<HEAD>
		<title>noticias</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<%="<style type=text/css>"%>
		<% Response.WriteFile(Server.MapPath("../css/remote.css")) %>
		<%="</style>"%>
		<script language="Javascript1.2"><!-- // load htmlarea
_editor_url = "../js/";                     // URL to htmlarea files
var win_ie_ver = parseFloat(navigator.appVersion.split("MSIE")[1]);
if (navigator.userAgent.indexOf('Mac')        >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Windows CE') >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Opera')      >= 0) { win_ie_ver = 0; }
if (win_ie_ver >= 5.5) {
 document.write('<scr' + 'ipt src="' +_editor_url+ 'editor.js"');
 document.write(' language="Javascript1.2"></scr' + 'ipt>');  
} else { document.write('<scr'+'ipt>function editor_generate() { return false; }</scr'+'ipt>'); }
// --></script>
		<script language="JavaScript1.2" defer>
var config = new Object(); // create new config object

config.width = "90%";
config.height = "110px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

// Add additional editor config settings here...



config.toolbar = [
  ['bold','italic','underline','separator'],
  ['OrderedList','UnOrderedList','Outdent','Indent','separator'],
  //['custom1','custom2','custom3','separator'],
]; 

		</script>
		<script language="javascript">

		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" dir="ltr" method="post" autocomplete="on" runat="server">
			<TABLE id="tblBody" style="WIDTH: 689px" cellSpacing="0" cellPadding="0" width="689" align="left"
				border="0">
				<tr>
					<td bgColor="#336666" colSpan="3"><IMG src="../images/remote-top.gif"><BR>
						<asp:panel id="pnlMenu" runat="server" HorizontalAlign="Right">
<asp:Label id="lblAlterna" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="White">Alternar para: </asp:Label>
<asp:DropDownList id="lstAlterna" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="White"
								DataTextField="nome" DataValueField="url" BackColor="#336666"></asp:DropDownList>
<asp:Button id="Button1" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="White" BackColor="#336666"
								BorderStyle="Solid" BorderWidth="2px" BorderColor="YellowGreen"
								Text="Ir" Width="30px"></asp:Button>&nbsp;&nbsp; 
      </asp:panel></td>
				</tr>
				<TR>
					<TD style="PADDING-RIGHT: 3px; PADDING-LEFT: 20px; PADDING-BOTTOM: 5px; WIDTH: 1041px; PADDING-TOP: 5px; HEIGHT: 16px"
						bgColor="darkgray" colSpan="4"><asp:label id="Label3" runat="server" ForeColor="White" Font-Bold="True" Font-Size="8pt">Gerenciador de Receitas</asp:label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 566px; HEIGHT: 176px" vAlign="top" align="center" bgColor="gainsboro"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="8pt">Título: &nbsp;</asp:label><asp:textbox id="txtChamada" runat="server" Width="283px"></asp:textbox><asp:textbox id="txtMateria" runat="server" Width="329px" Height="144px" TextMode="MultiLine"></asp:textbox></TD>
					<td style="WIDTH: 191px; HEIGHT: 176px" bgColor="gainsboro"><asp:panel id="Panel1" runat="server" Width="164px" Height="160px">
							<asp:Label id="lblImagem" runat="server" Font-Size="8pt" Font-Bold="True">Escolha a foto a ser enviada:</asp:Label>
							<BR>
							<IFRAME 
      id=frmImg style="WIDTH: 160px; HEIGHT: 136px" 
      src='<%=session.item("frmImg")%>' frameBorder=no 
      scrolling=no></IFRAME>
						</asp:panel></td>
					<TD style="WIDTH: 510px; HEIGHT: 176px" vAlign="middle" align="center" bgColor="gainsboro"><asp:calendar id="calNews" runat="server" Font-Size="8pt" Width="164px" Height="128px" DayNameFormat="FirstLetter"
							FirstDayOfWeek="Sunday" CssClass="calNews" BackColor="WhiteSmoke">
							<TodayDayStyle Font-Bold="True" BorderWidth="2px" ForeColor="White" BorderStyle="Inset" BorderColor="Gainsboro"
								BackColor="Red"></TodayDayStyle>
							<SelectorStyle BackColor="Silver"></SelectorStyle>
							<DayHeaderStyle Font-Bold="True" BackColor="WhiteSmoke"></DayHeaderStyle>
							<SelectedDayStyle ForeColor="Red" BackColor="White"></SelectedDayStyle>
							<TitleStyle Font-Bold="True"></TitleStyle>
							<WeekendDayStyle ForeColor="Gray"></WeekendDayStyle>
							<OtherMonthDayStyle BackColor="Gainsboro"></OtherMonthDayStyle>
						</asp:calendar><asp:label id="Label2" runat="server" ForeColor="WindowText" Font-Bold="True" Font-Size="8pt">&nbsp;Busca:&nbsp;</asp:label><asp:textbox id="txtBusca" runat="server" Width="80px"></asp:textbox><asp:imagebutton id="btnIr" runat="server" ImageUrl="../images/ir.gif"></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD align="right" bgColor="gray" colSpan="4"><asp:button id="btnPublish" runat="server" Text="Publicar"></asp:button></TD>
				</TR>
				<TR>
					<TD style="PADDING-RIGHT: 20px; PADDING-LEFT: 20px; PADDING-BOTTOM: 20px; WIDTH: 1041px; PADDING-TOP: 20px"
						vAlign="top" align="right" bgColor="whitesmoke" colSpan="4"><asp:datalist id="lstNoticias" runat="server" Width="694px" Height="0px" CssClass="lstNoticias"
							BorderColor="Silver" BorderWidth="1px" BorderStyle="Dashed" GridLines="Both">
							<ItemTemplate>
								<P>
									<asp:Image id=Image1 runat="server" ImageUrl='<%# "../res/getimage.aspx?a=get&amp;id=" &amp; system.convert.tostring(DataBinder.Eval(Container, "DataItem.id_imagem")) &amp; "&amp;w=106&amp;h=80"%>' align="right">
									</asp:Image>
									<asp:Label id=lblData runat="server" Font-Size="11pt" Font-Bold="True" ForeColor="Silver" Text='<%# getDataExt(DataBinder.Eval(Container, "DataItem.data")) %>'>
									</asp:Label></P>
								<P>
									<asp:Label id=lblTitulo runat="server" Font-Size="10pt" Font-Bold="True" Text='<%# DataBinder.Eval(Container, "DataItem.chamada") %>'>
									</asp:Label></P>
								<P>
									<asp:Label id=lblMateria runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.texto") %>'>
									</asp:Label></P>
								<P align="right">
									<asp:Button id="btnEdit" runat="server" Width="74px" Height="24px" Text="Editar" CommandName="edit"></asp:Button>&nbsp;
									<asp:Button id="btnRemover" runat="server" Width="70px" Text="Remover" CommandName="delete"></asp:Button></P>
							</ItemTemplate>
						</asp:datalist></TD>
				</TR>
				<tr>
					<td colSpan="3"><asp:label id="Label6" runat="server" Font-Bold="True" Width="100%" Height="21px" CssClass="lblCopy"
							BackColor="Silver">&copy; 2004 - Phosforo Verde - Todos os Direitos Reservados</asp:label></td>
				</tr>
			</TABLE>
		</form>
		<script language="JavaScript1.2" defer>
editor_generate('txtMateria', config);
		</script>
	</body>
</HTML>

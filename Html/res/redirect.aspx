<%@ Page Language="vb" AutoEventWireup="false" Codebehind="redirect.aspx.vb" Inherits="afabre.Redirect" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>Redirecionando...</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

		
		<% 
		response.write("<script language=""javascript"">")
		if request.querystring.item("r") = "" then
			response.write("window.parent.location.href=""" + request.querystring.item("url") + """")
		else 
			response.write("window.parent.location.href=""" + request.querystring.item("url") + "&r=" + request.querystring.item("r") + """")
		end if			%>
		</script>

	</head>
</html>

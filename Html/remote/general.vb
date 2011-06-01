Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Globalization
Imports System.Data.SqlClient


Public Class g

	Inherits System.Web.UI.Page

	Public Shared ds As New DataSet
	Public Shared cn As SqlConnection

	Shared Sub New()
		cn = AfabreLib.AfabreHelper.CreateConnection()
	End Sub

	Public Shared Sub dsClr()
		ds.Clear()
	End Sub

	Public Shared Function logged() As Boolean
		Dim x As New remote.WebForm1
		Return x.Session.Item("logged")
		'Return True
	End Function

	Public Shared Sub unlogged(ByVal page As Page)
		page.Response.Redirect(getRoot(page) & "/res/login.aspx?e=1")
	End Sub


	Public Shared Function getDataExt(ByVal data As DateTime) As String

		Return getDiaSem(data) & ", " & data.Day & " de " & getMes(data) & " de " & data.Year


	End Function

	Public Shared Function getDiaSem(ByVal data As DateTime) As String
		Dim iDiaSem As Integer
		Dim sDiaSem(7) As String

		iDiaSem = data.DayOfWeek()

		sDiaSem(1) = "segunda-feira"
		sDiaSem(2) = "terça-feira"
		sDiaSem(3) = "quarta-feira"
		sDiaSem(4) = "quinta-feira"
		sDiaSem(5) = "sexta-feira"
		sDiaSem(6) = "sabado"
		sDiaSem(7) = "domingo"

		Return sDiaSem(iDiaSem)

	End Function

	Public Shared Function getMes(ByVal data As DateTime) As String

		Dim culture As New CultureInfo("pt-BR")
		Dim months As Integer = culture.Calendar.GetMonthsInYear(data.Year)

		Dim iMes As Integer
		Dim sMes(months) As String

		iMes = data.Month

		Return data.ToString("MMMM", culture)

		'sMes(1) = "janeiro"
		'sMes(2) = "fevereiro"
		'sMes(3) = "março"
		'sMes(4) = "abril"
		'sMes(5) = "maio"
		'sMes(6) = "junho"
		'sMes(7) = "julho"
		'sMes(8) = "agosto"
		'sMes(9) = "setembro"
		'sMes(10) = "outubro"
		'sMes(11) = "novembro"
		'sMes(12) = "dezembro"

		'Return sMes(iMes)

	End Function

	Public Shared Function getRoot(ByVal page As Page) As String

		If page.Request.ApplicationPath = "/" Then
			Return ""
		Else
			Return page.Request.ApplicationPath
		End If

	End Function

	Public Shared Function GetHash(ByVal password As String) As String

		If (Not String.IsNullOrEmpty(password)) Then

			Dim engine As MD5 = MD5.Create()
			Dim input, output As Byte()

			input = Encoding.Default.GetBytes(password)
			output = engine.ComputeHash(input)

			Dim builder As New StringBuilder()

			For Each item As Byte In output
				builder.Append(item.ToString("x"))
			Next

			Return builder.ToString()
		Else
			Return String.Empty
		End If

	End Function

End Class

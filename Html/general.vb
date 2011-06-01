Imports System

Public Class g

    Inherits System.Web.UI.Page

    Public Shared cn As SqlClient.SqlConnection
    Public Shared ds As New DataSet
    Shared Sub New()
        cn = AfabreLib.AfabreHelper.CreateConnection()
    End Sub
    Public Shared Sub dsClr()
        ds.Clear()
    End Sub

    Public Shared Function logged() As Boolean
        Dim x As New afabre.default1
        Return x.Session.Item("logged")
        'Return True
    End Function

    Public Shared Sub unlogged(ByVal page As Page)
        page.Response.Redirect(getRoot(page) & "/res/erro.aspx?msg=" & page.Server.UrlEncode("Você precisa fazer login para acessar esta página") & "&e=4")
    End Sub


    Public Shared Function getDataExt(ByVal data As DateTime) As String

        Return getDiaSem(data) & ", " & data.Day & " de " & getMes(data) & " de " & data.Year


    End Function

    Public Shared Function getDiaSem(ByVal data As DateTime) As String
        Dim iDiaSem As Integer
        Dim sDiaSem(7) As String

        iDiaSem = data.DayOfWeek()

        sDiaSem(0) = "domingo"
        sDiaSem(1) = "segunda-feira"
        sDiaSem(2) = "terça-feira"
        sDiaSem(3) = "quarta-feira"
        sDiaSem(4) = "quinta-feira"
        sDiaSem(5) = "sexta-feira"
        sDiaSem(6) = "sabado"


        Return sDiaSem(iDiaSem)

    End Function

    Public Shared Function getMes(ByVal data As DateTime) As String

        Dim iMes As Integer
        Dim sMes(12) As String

        iMes = data.Month

        sMes(1) = "janeiro"
        sMes(2) = "fevereiro"
        sMes(3) = "março"
        sMes(4) = "abril"
        sMes(5) = "maio"
        sMes(6) = "junho"
        sMes(7) = "julho"
        sMes(8) = "agosto"
        sMes(9) = "setembro"
        sMes(10) = "outubro"
        sMes(11) = "novembro"
        sMes(12) = "dezembro"

        Return sMes(iMes)

    End Function

    Public Shared Function getRoot(ByVal page As Page) As String

        If page.Request.ApplicationPath = "/" Then
            Return ""
        Else
            Return page.Request.ApplicationPath
        End If

    End Function

End Class

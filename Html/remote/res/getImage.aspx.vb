Partial Class getImage
    Inherits System.Web.UI.Page

    Public imageContent As SqlClient.SqlDataReader
    Public w As Integer
    Public h As Integer

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Request.QueryString("w") <> "" Then w = Int(Request.QueryString.Item("w"))
        If Request.QueryString("h") <> "" Then h = Int(Request.QueryString.Item("h"))

        Select Case Request.QueryString("a")
            Case "select"
                selectPhoto()
            Case "get"
                If Request.QueryString("id") = "" Then erro()
                getPhoto()
            Case "save"
                savePhoto()
            Case "na"
                erro()
            Case "texto"
                geraTexto(Request.QueryString.Item("txt"))

        End Select
    End Sub


    Public Sub selectPhoto()

        If Request.QueryString.Item("id") <> "" Then

            img.ImageUrl = "../res/getimage.aspx?a=get&id=" & Request.QueryString.Item("id") & "&w=" & img.Width.Value & "&h=" & img.Height.Value
            Session.Add("fotoID", SqlTypes.SqlGuid.Parse(Request.QueryString.Item("id")))
        Else
            img.ImageUrl = "../res/getimage.aspx?a=na&w=" & img.Width.Value & "&h=" & img.Height.Value
        End If

    End Sub

    Public Sub getPhoto()
        Dim ImageID As SqlTypes.SqlGuid
        On Error GoTo er
        ImageID = Data.SqlTypes.SqlGuid.Parse("{" & Request.QueryString.Item("id") & "}")


            imageContent = GetImages(ImageID)

            '// The Read method is used to load the record into memory </summary>
            imageContent.Read()
            If imageContent.FieldCount > 0 Then
                '	/// <summary>
                '	/// The ImageType is retrieved from the database and sent to the browser as the
                '	/// ContentType. This tells the browser how to display the image. </summary>
                'Response.ContentType = imageContent("mimetype").ToString()
                Response.ContentType = imageContent("mimetype")
                '			/// <summary>
                '			/// The OutputStream.Write is used to write a byte array of the image, starting at
                '			/// the first byte and proceeding through the entire file. </summary>




                If Request.QueryString.Item("w") <> "" Or Request.QueryString.Item("h") <> "" Then


                    w = System.Convert.ToInt32(Request.QueryString.Item("w"))
                    h = System.Convert.ToInt32(Request.QueryString.Item("h"))



                getThumbnail(imageContent("imagem"), w, h, System.Convert.ToInt32(imageContent("filesize")))


                Else
                Response.OutputStream.Write(imageContent("imagem"), 0, System.Convert.ToInt32(imageContent("filesize")))
                End If

                '			/// <summary>
                '			/// Call the End method to indicate to the browser that the entire image has been sent. </summary>
            Else
                erro()
        End If

        imageContent.Close()

        Response.End()
        GoTo fim
er:
        erro()
fim:

    End Sub

    Public Sub savePhoto()


        Dim data1 As System.DateTime

        Dim ab As SqlClient.SqlCommand

        ab = New SqlClient.SqlCommand("insert into guest.imagem ([imagem], [filesize], [mimetype], [datetime], [filename]) values (@pFoto, @pFotoTamanho, @pMimeType, @pDataHora, @pArquivo)", g.cn)

        ab.Parameters.Add(New SqlClient.SqlParameter("@pFoto", SqlDbType.Image))
        ab.Parameters.Add(New SqlClient.SqlParameter("@pMimeType", SqlDbType.VarChar))
        ab.Parameters.Add(New SqlClient.SqlParameter("@pFotoTamanho", SqlDbType.BigInt))

        Dim Length As Integer

        Length = System.Convert.ToInt32(File1.PostedFile.InputStream.Length)

        Dim content(Length) As Byte

        File1.PostedFile.InputStream.Read(content, 0, Length)

        data1 = Date.Now

        ab.Parameters("@pFoto").Value = content
        ab.Parameters("@pMimeType").Value = File1.PostedFile.ContentType.ToString
        ab.Parameters("@pFotoTamanho").Value = Length

        ab.Parameters.Add("@pDataHora", data1)
        ab.Parameters.Add("@pArquivo", File1.PostedFile.FileName.ToString)

        ab.Connection.Close()
        ab.Connection.Open()

        ab.ExecuteNonQuery()

        ab.Connection.Close()



        Dim a As New SqlClient.SqlDataAdapter("select id_imagem as id_foto from guest.imagem where (datetime = @pDataHora and filename = @pArquivo)", g.cn)
        a.SelectCommand.Parameters.Add("@pDataHora", data1)
        a.SelectCommand.Parameters.Add("@pArquivo", File1.PostedFile.FileName.ToString)


        Dim ds As New DataSet
        ds.Clear()
        a.Fill(ds, "foto")

        If Not System.Convert.ToString(Session.Item("fotoID")) = "" Then

            a.UpdateCommand = New SqlClient.SqlCommand("update imagem_texto set id_imagem = null where id_imagem = @pID", g.cn)
            a.UpdateCommand.Parameters.Add("@pID", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("fotoID"))))
            g.cn.Close()
            g.cn.Open()
            a.UpdateCommand.ExecuteNonQuery()
            g.cn.Close()


            a.DeleteCommand = New SqlClient.SqlCommand("delete from guest.imagem where id_imagem = @pID", g.cn)
            a.DeleteCommand.Parameters.Add("@pID", SqlTypes.SqlGuid.Parse(System.Convert.ToString(Session.Item("fotoID"))))
            g.cn.Close()
            g.cn.Open()
            a.DeleteCommand.ExecuteNonQuery()
            g.cn.Close()
        End If

        Session.Add("fotoID", ds.Tables("foto").DefaultView(0).Item("id_foto"))

        Response.Redirect("getimage.aspx?a=select&id=" & System.Convert.ToString(ds.Tables("foto").DefaultView(0).Item("id_foto")))


    End Sub




    Private Function GetImages(ByVal imageId As SqlTypes.SqlGuid) As SqlClient.SqlDataReader

        ' <summary>
        ' Open a g.cn to the SQL Server </summary>
        '		/// <summary>
        '		/// The SqlCommand retrieves a single record from the Images table </summary>
        Dim Command As SqlClient.SqlCommand
        Command = New SqlClient.SqlCommand("Select * from guest.imagem Where id_imagem=@ImageId", g.cn)

        '			/// <summary>
        '			/// Create a SqlParameter that will allow you to pass in the ImageId to the query </summary>
        Dim imageIDParameter As SqlClient.SqlParameter

        imageIDParameter = New SqlClient.SqlParameter("@ImageId", SqlDbType.UniqueIdentifier)

        '			/// <summary>
        '			/// Assign the ImageId to the parameter that was created </summary>
        imageIDParameter.Value = imageId
        '			/// <summary>
        '			/// Add the Parameter to the SqlCommand's Parameters collection </summary>
        Command.Parameters.Add(imageIDParameter)
        '			/// <summary>
        '			/// Open the g.cn in order to retrieve the record </summary>
        g.cn.Close()
        g.cn.Open()
        '			/// <summary>
        '			/// Return a SqlDataReader to the calling procedure. Notice that the g.cn will
        '			/// be closed afer the record has been read </summary>
        Return Command.ExecuteReader(CommandBehavior.CloseConnection)


    End Function

    Public Function merda() As Boolean
        Return False
    End Function

    Public Sub getThumbnail(ByVal Imagem As Object, ByVal w As Integer, ByVal h As Integer, ByVal Tamanho As Integer)

        Dim stream As New System.IO.MemoryStream
        Dim img As System.Drawing.Bitmap
        Dim callback As Drawing.Image.GetThumbnailImageAbort

        callback = New Drawing.Image.GetThumbnailImageAbort(AddressOf merda)

        stream.Write(Imagem, 0, System.Convert.ToInt32(Tamanho))

        img = New System.Drawing.Bitmap(stream)

        If w = 0 Then w = (img.Width / img.Height) * h
        If h = 0 Then h = (img.Height / img.Width) * w

        'img.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Png)

        img.GetThumbnailImage(w, h, callback, System.IntPtr.Zero).Save(Response.OutputStream, img.RawFormat)

        stream.Close()
    End Sub

    Public Sub erro()

        w = System.Convert.ToInt32(Request.QueryString.Item("w"))
        h = System.Convert.ToInt32(Request.QueryString.Item("h"))

        If w = 0 Then w = 240
        If h = 0 Then h = 240

        Dim b As New System.drawing.Bitmap(w, h, Drawing.Imaging.PixelFormat.Format16bppRgb555)
        Dim salign As New System.drawing.StringFormat
        Dim g As Drawing.Graphics = Drawing.Graphics.FromImage(b)

        salign.Alignment = Drawing.StringAlignment.Center

        g.DrawString("IMAGEM" & vbCrLf & "NÃO" & vbCrLf & "DISPONÍVEL", New Drawing.Font("Tahoma", 10, Drawing.FontStyle.Bold), Drawing.Brushes.White, w / 2, 25, salign)




        ' Set the content type  
        Response.ContentType = "image/gif"

		' send the image to the viewer  
		Try
			b.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Gif)
		Catch ex As Exception
			Response.End()
		End Try
	End Sub


    Public Sub geraTexto(ByVal texto As String)
        If w = 0 Then w = 150
        If h = 0 Then h = 60

        Dim b As New System.drawing.Bitmap(w, h, Drawing.Imaging.PixelFormat.Format16bppRgb555)
        Dim g As Drawing.Graphics = Drawing.Graphics.FromImage(b)
        Dim color As Drawing.Brush
        b.SetResolution(300, 300)
        Select Case Request.QueryString.Item("cor")
            Case "verde"
                color = System.Drawing.Brushes.Green
            Case "laranja"
                color = Drawing.Brushes.DarkOrange
            Case "vinho"
                color = Drawing.Brushes.Firebrick
            Case "amarelo"
                color = Drawing.Brushes.Orange
            Case Else
                color = System.Drawing.Brushes.Black
        End Select

        If texto = "" Then
            Dim FonteFundo = New Drawing.Font("Garamond", 36, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
            Dim FonteFrente = New Drawing.Font("Garamond", 28, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)

            Session.Remove("rnd")
            Dim rnd As New System.Random
            Dim i As Integer
            For i = 1 To 5
                Dim n As Integer = rnd.Next(48, 122)
                If n < 58 Or n > 63 Then
                    If n < 91 Or n > 96 Then
                        texto = texto & Chr(n)
                    Else
                        i = i - 1
                    End If
                Else
                    i = i - 1
                End If
                'Response.Write(i & " " & Chr(i) & "<br>" & vbCrLf)
            Next
            Session.Add("rnd", texto)

            g.FillRegion(Drawing.Brushes.LightGray, New System.Drawing.Region(New Drawing.RectangleF(0, 0, w, h)))
            g.DrawString(texto, FonteFundo, Drawing.Brushes.White, -10, -10)
            g.DrawString(texto, FonteFrente, Drawing.Brushes.SeaGreen, 0, 0)
            g.DrawString(texto, FonteFundo, Drawing.Brushes.White, 10, 25)


            For i = 1 To 10
                g.DrawLine(Drawing.Pens.Khaki, 0, 0, w, h)
                g.DrawLine(Drawing.Pens.Lavender, System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)))
                g.DrawLine(Drawing.Pens.MediumSeaGreen, System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)))
                g.DrawLine(Drawing.Pens.DarkMagenta, System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)))
                g.DrawLine(Drawing.Pens.PapayaWhip, System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)))

                g.DrawEllipse(Drawing.Pens.LimeGreen, New Drawing.RectangleF(System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 1)), System.Convert.ToInt32(Left(rnd.Next(h * w).ToString, 3))))
            Next

        Else


            Dim FonteFundo = New Drawing.Font("Futura-Condensed-Normal", 48, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            Dim FonteFrente = New Drawing.Font("Futura-Condensed-Normal", 28, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

            g.FillRegion(Drawing.Brushes.LightGray, New System.Drawing.Region(New Drawing.RectangleF(0, 0, w, h)))
            g.DrawString(texto, FonteFundo, Drawing.Brushes.White, -15, -20)
            g.DrawString(texto, FonteFrente, color, 18, 6)

        End If


        Response.ContentType = "image/jpeg"

        ' send the image to the viewer  

        b.Save(Response.OutputStream, Drawing.Imaging.ImageFormat.Jpeg)

        Response.End()
    End Sub

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        savePhoto()
    End Sub
End Class

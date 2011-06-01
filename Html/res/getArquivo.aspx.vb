Partial Class getArquivo

    Inherits System.Web.UI.Page

    Public imageContent As SqlClient.SqlDataReader
    Public w As Integer
    Public h As Integer


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton

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
        Select Case Request.QueryString("a")
            Case "get"
                getFile()
        End Select
    End Sub


    Public Sub getFile()
        Dim ImageID As SqlTypes.SqlGuid
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





            Response.OutputStream.Write(imageContent("arquivo"), 0, System.Convert.ToInt32(imageContent("filesize")))
   
            '			/// <summary>
            '			/// Call the End method to indicate to the browser that the entire image has been sent. </summary>
        Else
        End If

        imageContent.Close()

        Response.End()


    End Sub

    Private Function GetImages(ByVal imageId As SqlTypes.SqlGuid) As SqlClient.SqlDataReader

        ' <summary>
        ' Open a g.cn to the SQL Server </summary>
        '		/// <summary>
        '		/// The SqlCommand retrieves a single record from the Images table </summary>
        Dim Command As SqlClient.SqlCommand
        Command = New SqlClient.SqlCommand("Select * From arquivo Where id_arquivo=@ImageId", g.cn)

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

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

    End Sub
End Class




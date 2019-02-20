Imports System.IO
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Public Class Connectioncls
    Public Shared Function ConnSQL() As SqlConnection
        Dim connectionString As String
        Dim con As SqlConnection
        connectionString = "Data Source=HDDSANDHYADEVIR\SQLEXPRESS;Initial Catalog=Mydb;Integrated Security=True;Connect Timeout=30;User Instance=False"
        'connectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\PC4\My Documents\Visual Studio 2008\Projects\morevariables\morevariables\App_Data\test_db.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        con = New SqlConnection(connectionString)
        Try
            con.Open()
            Return con
        Catch ex As NullReferenceException
            MsgBox("Can not open connection ! ")

        Finally
            con.Close()
        End Try
    End Function
End Class



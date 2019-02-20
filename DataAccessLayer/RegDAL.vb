Imports System.Text.RegularExpressions
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports BObject
Imports BObject.BObject
Imports System.Data.SqlClient.SqlDataReader
Namespace DAL
    Public Class RegDAL

        Public Function AddUserdetails(ob As ClassBO)
            Dim Conn As New SqlConnection
            Conn = Connectioncls.ConnSQL
            Dim da As New SqlDataAdapter
            Dim message As String
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_EmpDetails"
            cmd.Parameters.AddWithValue("@firstname", ob.Firstname)
            cmd.Parameters.AddWithValue("@lastname", ob.Lastname)
            cmd.Parameters.AddWithValue("@username", ob.Username)
            cmd.Parameters.AddWithValue("@password", ob.Password)
            cmd.Parameters.AddWithValue("@email", ob.Email)
            cmd.Parameters.AddWithValue("@location", ob.Location)
            cmd.Parameters.AddWithValue("@phonenumber", ob.Phonenumber)
            cmd.Parameters.AddWithValue("@skills", ob.Technicalskills)
            cmd.Parameters.AddWithValue("@dateofjoin", ob.Dateofjoin)
            cmd.Parameters.AddWithValue("@image", ob.Picture)
            cmd.Parameters.AddWithValue("@gender", ob.Gender)
            cmd.Parameters.Add("@output", SqlDbType.Char, 500)
            cmd.Parameters("@output").Direction = ParameterDirection.Output
            cmd.Connection = Conn
            Try
                Conn.Open()
                cmd.ExecuteNonQuery()
                message = cmd.Parameters("@output").Value.ToString()
                cmd.Dispose()
                MsgBox(message)

            Catch ex As NullReferenceException
                MsgBox("Failed")
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try
        End Function

        Public Function UpdateUserdetails(ob As ClassBO) As Integer

            Dim Conn As New SqlConnection
            Conn = Connectioncls.ConnSQL
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_UpdateEmpdetails"
            cmd.Parameters.AddWithValue("@id", ob.Id)
            cmd.Parameters.AddWithValue("@firstname", ob.Firstname)
            cmd.Parameters.AddWithValue("@lastname", ob.Lastname)
            cmd.Parameters.AddWithValue("@username", ob.Username)
            cmd.Parameters.AddWithValue("@password", ob.Password)
            cmd.Parameters.AddWithValue("@email", ob.Email)
            cmd.Parameters.AddWithValue("@location", ob.Location)
            cmd.Parameters.AddWithValue("@phonenumber", ob.Phonenumber)
            cmd.Parameters.AddWithValue("@skills", ob.Technicalskills)
            cmd.Parameters.AddWithValue("@dateofjoin", ob.Dateofjoin)
            cmd.Parameters.AddWithValue("@image", ob.Picture)
            cmd.Parameters.AddWithValue("@gender", ob.Gender)
            cmd.Connection = Conn
            Try
                Conn.Open()
                Dim result As Integer = cmd.ExecuteNonQuery()
                MsgBox("Record Updated successfully")
                cmd.Dispose()
                Return result

            Catch ex As NullReferenceException
                MsgBox("No Record found")
            Finally
                Conn.Close()
                Conn.Dispose()
            End Try
        End Function

        Public Function Selectrecords() As DataTable
            Dim Conn As New SqlConnection
            Conn = Connectioncls.ConnSQL
            Try

                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT * FROM Employeedata"
                Conn.Open()
                cmd.Connection = Conn
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable("Employeedata")
                da.Fill(dt)
                Return dt
            Catch ex As NullReferenceException
                MsgBox("Error")
            Finally

                Conn.Close()
                Conn.Dispose()
            End Try
        End Function
    End Class
End Namespace
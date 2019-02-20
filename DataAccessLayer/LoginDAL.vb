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

Namespace DAL
    Public Class LoginDAL
        Public Function ValidateLogin(ob As ClassBO) As Integer
            Dim Conn As New SqlConnection
            Conn = Connectioncls.ConnSQL
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            dt.Clear()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Validate_Emp"
            cmd.Parameters.AddWithValue("@username", ob.Username)
            cmd.Parameters.AddWithValue("@password", ob.Password)
            cmd.Connection = Conn
            Try
                da.SelectCommand = cmd
                da.Fill(dt)
                cmd.Dispose()
                Conn.Open()
                If dt.Rows.Count > 0 Then
                    MsgBox("Login Successful")
                    Return 1
                Else
                    MsgBox("Wrong Username/Password")
                    Return 0
                End If
            Catch ex As NullReferenceException
                MsgBox("Error")
            Finally
                dt.Clear()
                dt.Dispose()
                da.Dispose()
                Conn.Close()
                Conn.Dispose()
            End Try

        End Function

        Public Function getempskills(ob As ClassBO) As DataTable
            Dim Conn As New SqlConnection
            Conn = Connectioncls.ConnSQL
            Try
                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_Displayempskills"
                cmd.Parameters.AddWithValue("@username", ob.Username)
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
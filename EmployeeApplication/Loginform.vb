Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System
Imports System.Web
Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports BObject.BObject
Imports BusinessLayer.BL
Imports EmployeeApplication.EmployeeApplication

Public Class Loginform
    Public data As String = ""

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim y As Registrationform = New Registrationform
        y.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim empformobj As Employeeform = New Employeeform

        If Check(sender, e) = 1 Then

            data = TextBox1.Text
            Dim z As Employeeform = New Employeeform
            z.Show()
        Else
        End If
    End Sub
    Public Function Check(sender As Object, e As EventArgs) As Integer
        Dim blob As LoginBL = New LoginBL
        Dim ob As ClassBO = New ClassBO
        ob.Username = TextBox1.Text
        ob.Password = TextBox2.Text
        Try
            Return blob.Validate(ob)
        Catch ex As Exception
        End Try
    End Function
End Class
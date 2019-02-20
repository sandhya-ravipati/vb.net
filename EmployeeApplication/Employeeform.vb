Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Text
Imports BObject
Imports BObject.BObject
Imports DataAccessLayer.DAL
Imports System.ComponentModel
Imports BusinessLayer.BL
Imports EmployeeApplication.EmployeeApplication

Public Class Employeeform
    Dim regformobj As Registrationform = New Registrationform
    Dim loginformobj As Loginform = New Loginform


    Private Sub Employeeform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As New DataTable
        Label4.Text = Loginform.data
        dt = regformobj.Search()
        DataGridView1.DataSource = dt
        dt = getSkills(sender, e)
        RichTextBox1.DataBindings.Add("Text", dt, "Skills")

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        If index = -1 Then
            DataGridView1.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.Automatic
            'DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
        Else
        End If
    End Sub
    'pagination
    Private da As SqlDataAdapter
    Private ds As DataSet
    Private dt As DataTable
    Private PageCount As Integer
    Private maxRec As Integer
    Private pageSize As Integer
    Private currentPage As Integer
    Private recNo As Integer

    Private Sub LoadPage()
        Dim i As Integer
        Dim startRec As Integer
        Dim endRec As Integer
        Dim dtTemp As DataTable
        'Duplicate or clone the source table to create the temporary table.
        dtTemp = dt.Clone

        If currentPage = PageCount Then
            endRec = maxRec
        Else
            endRec = pageSize * currentPage
        End If

        startRec = recNo

        'Copy the rows from the source table to fill the temporary table.
        For i = startRec To endRec - 1
            dtTemp.ImportRow(dt.Rows(i))
            recNo = recNo + 1
        Next
        DataGridView1.DataSource = dtTemp
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click
        currentPage = currentPage + 1
        If currentPage > PageCount Then
            currentPage = PageCount
            'Check if you are already at the last page.
            If recNo = maxRec Then
                MessageBox.Show("You are at the Last Page!")
                Return
            End If
        End If
        LoadPage()
    End Sub
    Public Sub details()
        dt = regformobj.Search()
        maxRec = dt.Rows.Count
        pageSize = TextBox1.Text
        PageCount = maxRec \ pageSize
        If (maxRec Mod pageSize) > 0 Then
            PageCount = PageCount + 1
        End If
        currentPage = 1
        recNo = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If currentPage = PageCount Then
            recNo = pageSize * (currentPage - 2)
        End If
        currentPage = currentPage - 1
        'Check if you are already at the first page.
        If currentPage < 1 Then
            MessageBox.Show("You are at the First Page!")
            currentPage = 1
            Return
        Else
            recNo = pageSize * (currentPage - 1)
        End If
        LoadPage()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If recNo = maxRec Then
            MessageBox.Show("You are at the Last Page!")
            Return
        End If
        currentPage = PageCount
        recNo = pageSize * (currentPage - 1)
        LoadPage()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button4.Click
        details()
        LoadPage()
        If currentPage = 1 Then
            MessageBox.Show("You are at the First Page!")
            Return
        End If
        currentPage = 1
        recNo = 0
    End Sub
    Public Function getSkills(sender As Object, e As EventArgs) As DataTable
        Dim blob As LoginBL = New LoginBL
        Dim ob As ClassBO = New ClassBO
        ob.Username = Label4.Text
        Try
            Return blob.search(ob)
        Catch ex As Exception
        End Try
    End Function
    Public Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub
   
    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub
End Class

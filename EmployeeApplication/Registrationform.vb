Imports System.Text.RegularExpressions
Imports System.Windows.Forms
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
Imports DataAccessLayer.DAL
Imports System.ComponentModel
Imports BusinessLayer.BL

Public Class Registrationform

    Private Sub Registrationform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt = search()
        datagridview1.datasource = dt

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If (TextBox1.Text.Trim = "") Then
            MsgBox("Firstname is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub
        End If
        TextBox1.Focus()
        If (TextBox2.Text.Trim = "") Then
            MsgBox("Lastname is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub
        End If
        TextBox2.Focus()

        If (TextBox3.Text.Trim = "") Then
            MsgBox("Username is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub
        End If
        TextBox3.Focus()

        If (TextBox4.Text.Trim = "") Then
            MsgBox("Password is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub
        End If

        TextBox4.Focus()

        If (TextBox5.Text.Trim = "") Then
            MsgBox("Email is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub
        End If
        TextBox5.Focus()

        If (TextBox6.Text.Trim = "") Then
            MsgBox("Location is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub

        End If
        TextBox6.Focus()
        If (TextBox7.Text.Trim = "") Then
            MsgBox("Phone number is required,Blank not Allowed", MsgBoxStyle.Information, "Verify")
            Exit Sub
        End If

        TextBox7.Focus()
        Dim blobj As RegBL = New RegBL
        AddRecords(sender, e)
        Dim dt As New DataTable
        dt = Search()
        DataGridView1.DataSource = dt
    End Sub
    Protected Sub AddRecords(sender As Object, e As EventArgs)

        Dim blobj As RegBL = New RegBL
        Dim ob As ClassBO = New ClassBO
        ob.Firstname = TextBox1.Text
        ob.Lastname = TextBox2.Text
        ob.Username = TextBox3.Text
        ob.Password = TextBox4.Text
        ob.Email = TextBox5.Text
        ob.Location = TextBox6.Text
        ob.Phonenumber = TextBox7.Text
        ob.Technicalskills = GetCheckboxSelected()
        ob.Dateofjoin = DateTimePicker1.Value
        ob.Picture = TextBox8.Text
        ob.Gender = GetGroupBox1CheckedButton(GroupBox1).Text
        Try
            blobj.Save(ob)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As Loginform = New Loginform
        x.Show()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        UpdateRecords()
        Dim dt As New DataTable
        dt = Search()
        DataGridView1.DataSource = dt
    End Sub
    Protected Sub UpdateRecords()
        Dim blobj As RegBL = New RegBL
        Dim ob As ClassBO = New ClassBO
        Dim rowCurrent As DataGridViewRow = DataGridView1.CurrentRow
        ob.Id = rowCurrent.Cells(0).Value.ToString()
        ob.Firstname = TextBox1.Text
        ob.Lastname = TextBox2.Text
        ob.Username = TextBox3.Text
        ob.Password = TextBox4.Text
        ob.Email = TextBox5.Text
        ob.Location = TextBox6.Text
        ob.Phonenumber = TextBox7.Text
        ob.Technicalskills = GetCheckboxSelected()
        ob.Dateofjoin = DateTimePicker1.Value
        ob.Picture = TextBox8.Text
        ob.Gender = GetGroupBox1CheckedButton(GroupBox1).Text
        Try
            blobj.Update(ob)

        Catch ex As Exception

        End Try
    End Sub
    Public Function Search() As DataTable
        Dim dt As New DataTable
        Dim blob As RegBL = New RegBL
        Dim ob As ClassBO = New ClassBO
        dt = blob.View()
        Return dt
    End Function
    Public Function GetCheckboxSelected() As String
        Dim sb As New System.Text.StringBuilder
        For Each item In CheckedListBox1.CheckedItems
            sb.Append(item)
            sb.Append(",")
        Next
        Return sb.ToString()
    End Function

    Private Function GetGroupBox1CheckedButton(grpb As GroupBox) As RadioButton
        Dim rButton As RadioButton = grpb.Controls.OfType(Of RadioButton).Where(Function(r) r.Checked = True).FirstOrDefault()
        Return rButton
    End Function
    Public Function upload() As String
        Dim saveDirectory As String = "C:\Users\sandhyadevir\Documents\Visual Studio 2013\Projects\Employeeapplication\Employeeapplication\pictures"
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog()
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            If Not Directory.Exists(saveDirectory) Then
                Directory.CreateDirectory(saveDirectory)
            End If

            Dim fileName As String = System.IO.Path.GetFileName(openFileDialog1.FileName)
            Dim fileSavePath As String = System.IO.Path.Combine(saveDirectory, fileName)
            File.Copy(openFileDialog1.FileName, fileSavePath, True)
            Return fileSavePath
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox8.Text = upload()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Char.IsControl(e.KeyChar) = False) Then
            If (Char.IsLetter(e.KeyChar)) Or (Char.IsWhiteSpace(e.KeyChar)) Then
                'do nothing
            Else
                e.Handled = True
                MsgBox("Sorry Only Characters & Spaces Allowed!!", MsgBoxStyle.Information, "Verify")
                TextBox1.Focus()
            End If
        End If
    End Sub
    Private Sub textbox2_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Char.iscontrol(e.keychar) = False) Then
            If (Char.isletter(e.keychar)) Or (Char.iswhitespace(e.keychar)) Then
                'do nothing
            Else
                e.handled = True
                msgbox("sorry only characters & spaces allowed!!", msgboxstyle.information, "verify")
                textbox2.focus()
            End If
        End If
    End Sub
    Private Sub textbox3_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If (Char.iscontrol(e.keychar) = False) Then
            If (Char.isletter(e.keychar)) Or (Char.isdigit(e.keychar)) Then
                'do nothing
            Else
                e.handled = True
                msgbox("sorry only characters & digits allowed!!", msgboxstyle.information, "verify")
                textbox3.focus()
            End If
        End If
    End Sub
    Private Sub textbox4_leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        Dim pattern As String = "^.*(?=.{5,})(?=.*\d)(?=.*[a-z])(?=.*[a-z])(?=.*[@#$%^&+=]).*$"
        If textbox4.text.trim <> "" Then
            If Not regex.ismatch(textbox4.text, pattern) Then
                messagebox.show("password is not valid")
            End If
        End If
    End Sub
    Private Sub textbox5_leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        Dim status As Integer = validateemail(textbox5.text)
        If status = 0 Then
            messagebox.show("e-mail id is invalid,enter valid email id", "error", messageboxbuttons.ok, messageboxicon.[error])
        End If

    End Sub
    Public Function validateemail(ByVal email As String) As Integer
        Dim remail As New system.text.regularexpressions.regex("^[a-za-z][\w\.-]{2,28}[a-za-z0-9]@[a-za-z0-9][\w\.-]*[a-za-z0-9]\.[a-za-z][a-za-z\.]*[a-za-z]$")
        If email.length > 0 Then
            If Not remail.ismatch(email) Then
                Return 0
            Else
                Return 1
            End If
        End If
        Return 2
    End Function

    Private Sub textbox6_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If (Char.iscontrol(e.keychar) = False) Then
            If (Char.isletter(e.keychar)) Or (Char.iswhitespace(e.keychar)) Then
                'do nothing
            Else
                e.handled = True
                msgbox("sorry only characters & spaces allowed!!", msgboxstyle.information, "verify")
                textbox6.focus()
            End If
        End If
    End Sub
    Private Sub textbox7_leave(sender As Object, e As EventArgs) Handles TextBox7.Leave
        Dim pattern As String = "^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"
        If textbox7.text.trim <> "" Then
            If Not regex.ismatch(textbox7.text, pattern) Then
                messagebox.show("phone number is not valid,it should be of(333-223-9876)format")
            End If
        End If
    End Sub
    Private Sub groupbox1_mouseclick(sender As Object, e As MouseEventArgs) Handles GroupBox1.MouseClick
        If Not radiobutton1.checked AndAlso Not radiobutton2.checked Then
            messagebox.show("you did not select any of radio button options.")
        End If
    End Sub
 
    'binding datagridview selected row data to vb.net form controls
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        index = e.RowIndex
        If index = -1 Then
            DataGridView1.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.Automatic
            'DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)
        Else
            Dim selectedRow As DataGridViewRow
            selectedRow = DataGridView1.Rows(index)
            TextBox1.Text = selectedRow.Cells(1).Value.ToString()
            TextBox2.Text = selectedRow.Cells(2).Value.ToString()
            TextBox3.Text = selectedRow.Cells(3).Value.ToString()
            TextBox4.Text = selectedRow.Cells(4).Value.ToString()
            TextBox5.Text = selectedRow.Cells(5).Value.ToString()
            TextBox6.Text = selectedRow.Cells(6).Value.ToString()
            TextBox7.Text = selectedRow.Cells(7).Value.ToString()
            DateTimePicker1.Text = selectedRow.Cells(9).Value.ToString()
            TextBox8.Text = selectedRow.Cells(10).Value.ToString()
            RadioButton1.Text = selectedRow.Cells(11).Value.ToString()
            RadioButton2.Text = selectedRow.Cells(11).Value.ToString()
            If selectedRow.Cells(8).Value.Equals("Male") Then
                RadioButton1.Checked = True
            End If
            If selectedRow.Cells(8).Value.Equals("Female") Then
                RadioButton2.Checked = True
            End If
            Dim areasback As String = selectedRow.Cells(8).Value.ToString()
            Dim areasback1 As String() = areasback.Split(",")
            Dim intCount As Integer = 0
            'for clearing the items in checkedlistbox
            For Each intCount In CheckedListBox1.CheckedIndices
                CheckedListBox1.SetItemCheckState(intCount, CheckState.Unchecked)
            Next

            For Each str As String In areasback1
                For intCount = 0 To CheckedListBox1.Items.Count - 1
                    If CheckedListBox1.Items(intCount).ToString() = str Then
                        CheckedListBox1.SetItemChecked(intCount, True)
                    End If
                Next
            Next
        End If
    End Sub
   
End Class

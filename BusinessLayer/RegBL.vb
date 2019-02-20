
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports BObject
Imports BObject.BObject
Imports DataAccessLayer.DAL


Namespace BL
    Public Class RegBL
        Public Function Save(ob As ClassBO)
            Dim daobj As RegDAL = New RegDAL()
            Try
                Return daobj.AddUserdetails(ob)
            Catch
            End Try
        End Function
        Public Function Update(ob As ClassBO) As Integer
            Dim daobj As RegDAL = New RegDAL()
            Try
                Return daobj.UpdateUserdetails(ob)
            Catch
            End Try
        End Function

        Public Function View() As DataTable
            Dim dt As New DataTable
            Dim daobj As RegDAL = New RegDAL()
            dt = daobj.Selectrecords()
            Return dt
        End Function

    End Class
End Namespace
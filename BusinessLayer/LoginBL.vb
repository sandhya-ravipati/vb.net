Imports System.Linq
Imports System.Text
Imports BObject
Imports BObject.BObject
Imports DataAccessLayer.DAL


Namespace BL
    Public Class LoginBL
        Dim daob As LoginDAL = New LoginDAL
        Public Function Validate(ob As ClassBO)
            Try
                Return daob.ValidateLogin(ob)
            Catch

            End Try
        End Function
        Public Function search(ob As ClassBO)
            Try
                Return daob.getempskills(ob)
            Catch

            End Try
        End Function
    End Class
End Namespace
Imports System.Threading
Imports System.Configuration

Module ModMain
    Public Sub main()
        'AddHandler Application.ThreadException, AddressOf CommonExceptionHandler
        Application.Run(New Loginform)
    End Sub
    'Public Sub CommonExceptionHandler(ByVal sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)
    '    logerror(t.Exception)
    'End Sub
    'Public Sub logerror(ex As Exception)
    '    Dim errormsg As String = ex.Message
    'End Sub
End Module

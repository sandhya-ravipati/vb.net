
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Namespace BObject
    Public Class ClassBO
        Private _Id As Integer
        Private _Firstname As String
        Private _Lastname As String
        Private _Username As String
        Private _Password As String
        Private _Email As String
        Private _Location As String
        Private _Phonenumber As String
        Private _Technicalskills As String
        Private _Dateofjoin As String
        Private _Picture As String
        Private _Gender As String

        Public Property Id() As String
            Get
                Return _Id
            End Get
            Set(ByVal value As String)
                _Id = value
            End Set
        End Property

        Public Property Firstname() As String
            Get
                Return _Firstname
            End Get
            Set(ByVal value As String)
                _Firstname = value
            End Set
        End Property

        Public Property Lastname() As String
            Get
                Return _Lastname
            End Get
            Set(ByVal value As String)
                _Lastname = value
            End Set
        End Property

        Public Property Username() As String
            Get
                Return _Username
            End Get
            Set(ByVal value As String)
                _Username = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return _Location
            End Get
            Set(ByVal value As String)
                _Location = value
            End Set
        End Property

        Public Property Phonenumber() As String
            Get
                Return _Phonenumber
            End Get
            Set(ByVal value As String)
                _Phonenumber = value
            End Set
        End Property

        Public Property Technicalskills() As String
            Get
                Return _Technicalskills
            End Get
            Set(ByVal value As String)
                _Technicalskills = value
            End Set
        End Property

        Public Property Dateofjoin() As String
            Get
                Return _Dateofjoin
            End Get
            Set(ByVal value As String)
                _Dateofjoin = value
            End Set
        End Property

        Public Property Picture() As String
            Get
                Return _Picture
            End Get
            Set(ByVal value As String)
                _Picture = value
            End Set
        End Property

        Public Property Gender() As String
            Get
                Return _Gender
            End Get
            Set(ByVal value As String)
                _Gender = value
            End Set
        End Property

    End Class

End Namespace

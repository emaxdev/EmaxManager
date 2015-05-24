Imports Microsoft.VisualBasic

Public Class scripts
    Private _scriptName As String
    Public Property scriptName() As String
        Get
            Return _scriptName
        End Get
        Set(ByVal value As String)
            _scriptName = value
        End Set
    End Property

    Private _scriptDescription As String
    Public Property scriptDescription() As String
        Get
            Return _scriptDescription
        End Get
        Set(ByVal value As String)
            _scriptDescription = value
        End Set
    End Property

    Private _scriptDetails As String
    Public Property scriptDetails() As String
        Get
            Return _scriptDetails
        End Get
        Set(ByVal value As String)
            _scriptDetails = value
        End Set
    End Property

    Private _scripts As Array
    Public Property scripts() As Array
        Get
            Return _scripts
        End Get
        Set(ByVal value As Array)
            _scripts = value
        End Set
    End Property


End Class

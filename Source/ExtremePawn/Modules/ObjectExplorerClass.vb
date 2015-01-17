Imports System.Text.RegularExpressions

Public Class ObjectExplorerClass
    Inherits Form
    Public explorerList As List(Of ExplorerItem) = New List(Of ExplorerItem)()

    Public Enum ExplorerItemType
        [Class]
        [Property]
    End Enum

    Public Class ExplorerItem
        Public type As ExplorerItemType

        Public title As String

        Public position As Integer
    End Class

    Public Class ExplorerItemComparer
        Implements IComparer(Of ExplorerItem)

        Public Function Compare(ByVal x As ExplorerItem, ByVal y As ExplorerItem) As Integer Implements IComparer(Of ExplorerItem).Compare
            Return x.title.CompareTo(y.title)
        End Function
    End Class
End Class

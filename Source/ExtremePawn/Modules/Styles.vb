Imports FastColoredTextBoxNS

Module Styles 'MainForm is a big mess and very big, So I made a new module to save some space :D
    Public BlueItalicStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Italic)
    Public BlueStyle As Style = New TextStyle(Brushes.Blue, Nothing, FontStyle.Regular)
    Public GreenStyle As Style = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Public BoldStyle As Style = New TextStyle(Brushes.Black, Nothing, FontStyle.Bold + FontStyle.Underline)
    Public TextStyle As Style = New TextStyle(Brushes.Chocolate, Nothing, Nothing)
    Public NumberStyle As Style = New TextStyle(Brushes.Magenta, Nothing, Nothing)
    Public MulinLineGreenStyle As Style = New TextStyle(Brushes.Green, Nothing, FontStyle.Italic)
    Public DefineStyle As Style = New TextStyle(Brushes.Turquoise, Nothing, FontStyle.Regular)
    Public FuncStyle As Style = New TextStyle(Brushes.Firebrick, Nothing, FontStyle.Regular)

End Module

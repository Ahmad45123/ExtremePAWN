Imports ExtremeINI

Module SettingsHandler
    Dim INIRead As New Read
    Dim INIWrite As New Write

    Public Sub WriteSetting(ByVal Title As String, ByVal value As Object)
        Dim INIFile As New INI
        INIFile.Path = Application.StartupPath + "\Settings.ini"
        INIWrite.WriteData(INIFile, Title, value)
        INIWrite.WriteINI(INIFile)
    End Sub

    Public Function GetSetting(ByVal setting As String)
        INIRead.LoadINI(Application.StartupPath + "\Settings.ini")
        Return INIRead.ReadString(setting)
    End Function
End Module

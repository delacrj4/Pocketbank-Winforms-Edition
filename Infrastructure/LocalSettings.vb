Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports System.Security.Cryptography
Imports System.Text
Imports Oracle.ManagedDataAccess.Client

Namespace Infrastructure
    Public Class LocalSettings
        Public Property DataSource As String = "localhost:1521/XEPDB1"
        Public Property UserId As String = "POCKETBANK_APP"
        Public Property Schema As String = "POCKETBANK_OWNER"
        Public Property ProtectedPassword As String = ""

        <JsonIgnore>
        Public Property Password As String
            Get
                If ProtectedPassword = "" Then Return ""
                Return Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(ProtectedPassword), Nothing, DataProtectionScope.CurrentUser))
            End Get
            Set(value As String)
                ProtectedPassword = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(value), Nothing, DataProtectionScope.CurrentUser))
            End Set
        End Property

        Public Sub Save()
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath))
            File.WriteAllText(SettingsPath, JsonSerializer.Serialize(Me, New JsonSerializerOptions With {.WriteIndented = True}))
        End Sub

        Public Shared ReadOnly Property SettingsPath As String
            Get
                Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PocketBank", "connection.json")
            End Get
        End Property

        Public Shared Function Load() As LocalSettings
            If Not File.Exists(SettingsPath) Then Return New LocalSettings()
            Return JsonSerializer.Deserialize(Of LocalSettings)(File.ReadAllText(SettingsPath))
        End Function

        Public Function ConnectionString() As String
            Dim b As New OracleConnectionStringBuilder With {.DataSource = DataSource, .UserID = UserId, .Password = Password, .ConnectionTimeout = 8, .Pooling = True}
            Return b.ConnectionString
        End Function
    End Class
End Namespace

Imports System.Security.Cryptography
Imports System.Text
Imports Org.BouncyCastle.Crypto.Generators

Namespace Services
    Public NotInheritable Class Passwords
        Private Const Iterations As Integer = 210000

        Public Shared Function Hash(password As String) As String
            Dim salt = RandomNumberGenerator.GetBytes(16)
            Dim key = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, 32)
            Return $"pbkdf2:{Iterations}:{Convert.ToHexString(salt)}:{Convert.ToHexString(key)}"
        End Function

        Public Shared Function Verify(password As String, stored As String) As Boolean
            Try
                Dim parts = stored.Split(":"c)
                If parts.Length = 4 AndAlso parts(0) = "pbkdf2" Then
                    Dim rounds = Integer.Parse(parts(1), Globalization.CultureInfo.InvariantCulture)
                    If rounds < 100000 OrElse rounds > 2000000 Then Return False
                    Dim actual = Rfc2898DeriveBytes.Pbkdf2(password, Convert.FromHexString(parts(2)), rounds, HashAlgorithmName.SHA256, 32)
                    Return CryptographicOperations.FixedTimeEquals(actual, Convert.FromHexString(parts(3)))
                End If
                If parts.Length <> 2 OrElse parts(0).Length <> 32 OrElse parts(1).Length <> 128 Then Return False
                ' Node crypto.scrypt receives the salt as UTF-8 hex TEXT, not decoded bytes.
                Dim legacy = SCrypt.Generate(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(parts(0)), 16384, 8, 1, 64)
                Return CryptographicOperations.FixedTimeEquals(legacy, Convert.FromHexString(parts(1)))
            Catch ex As FormatException
                Return False
            End Try
        End Function
    End Class
End Namespace

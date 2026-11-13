Namespace UI
    ' Screen layout and editable styling live in each view's Designer file.
    ' These colors are used only for changing state (selection and feedback).
    Public Module Theme
        Public ReadOnly Background As Color = Color.FromArgb(13, 20, 35)
        Public ReadOnly Surface As Color = Color.FromArgb(24, 36, 57)
        Public ReadOnly Ink As Color = Color.FromArgb(239, 244, 252)
        Public ReadOnly Accent As Color = Color.FromArgb(83, 147, 255)
        Public ReadOnly Good As Color = Color.FromArgb(105, 224, 181)
        Public ReadOnly Bad As Color = Color.FromArgb(255, 158, 158)

        Public Function Money(cents As Long) As String
            Return (cents / 100D).ToString("C2", Globalization.CultureInfo.GetCultureInfo("en-US"))
        End Function
    End Module
End Namespace

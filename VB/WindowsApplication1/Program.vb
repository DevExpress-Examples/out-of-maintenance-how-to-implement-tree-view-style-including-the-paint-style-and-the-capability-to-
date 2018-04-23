Imports Microsoft.VisualBasic
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WindowsApplication1
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
        <STAThread> _
        Public Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            DevExpress.UserSkins.BonusSkins.Register()
            SkinManager.EnableFormSkins()
            Application.Run(New Form1())
        End Sub
    End Class
End Namespace

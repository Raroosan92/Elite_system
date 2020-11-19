Const FONTS = &H14&
Set objShell = CreateObject("cmd.exe")
Set objFolder = objShell.Namespace(FONTS)
objFolder.CopyHere "c:\Windows\Fonts\IDAutomationC128XS.ttf"
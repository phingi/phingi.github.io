# teszt


## Egy minimalista C# fejlesztő környezet beállítása

### Parancssorból:
[roslyn - Microsoft.Net.Compilers.Toolset](=https://dotnet.myget.org/feed/roslyn/package/nuget/Microsoft.Net.Compilers.Toolset)
[download version 3.8.0-1.20330.5](https://dotnet.myget.org/F/roslyn/api/v2/package/Microsoft.Net.Compilers.Toolset/3.8.0-1.20330.5)
A Microsoft.Net.Compilers.Toolset.3.8.0-1.20330.5.nupkg\tasks\net472 könyvtár kicsomagolása, ebben lesz a "csc.exe"
Fordítás pl: csc.exe -r:System.Windows.Forms.dll,System.Drawing.dll -target:winexe -win32icon:icon.ico Fájlnév.cs
Fordítás és futtatás pl: csc.exe -r:System.Windows.Forms.dll,System.Drawing.dll -target:winexe -win32icon:icom.ico Fájlnév.cs && Fájlnév.exe

### Notepad++ -szal
[Notepad++ letöltés](https://notepad-plus-plus.org/downloads)
[v7.8.8 64-bit zip package] (https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v7.8.8/npp.7.8.8.bin.x64.zip)
Notepad++
futtatás
Bővítmények -> Plugin Manager -> Show Plugin Manager
Available -> CS-Script (C# INtelisense)
Bővítmények -> CS-Script -> Run (F5)
...


```
// csc.exe -r:System.Windows.Forms.dll -r:System.Drawing.dll WinFormsHelloWorldProgram.cs && WinFormsHelloWorldProgram.exe

using System;
using System.Windows.Forms;

class WinFormsHelloWorldProgram : Form
{
	public static void Main()
    {
        Application.Run( new WinFormsHelloWorldProgram() );
    }

    WinFormsHelloWorldProgram()
    {
        Text = "Click Me!";
        Click += new EventHandler (Button_Click);
    }

    void Button_Click (object sender, EventArgs e)
    {
        MessageBox.Show ("Button Clicked!");
    }

}
```

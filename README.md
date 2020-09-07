# teszt


## Egy minimalista C# fejlesztő környezet beállítása

### Parancssorból:

A programok fordításához szülséges a csc.exe, melyet legegyszerűbben a 'where /r c:\ csc.exe' paranccsal lehet megtalálni. Az ezt a programot tartalmazó könyvtárat célszerű hozzáadni a PATH környezeti változóhoz: Windows 10 alatt a Gépház-ban a kereső mezőbe elég beírni, hogy "körn" és a listából kiválaszttani, majd a felhasználói változók között a 'Path' értékéhez *(ami alapból valami iylesmi: "C:\Users\...\AppData\Local\Microsoft\WindowsApps")* hozzáfűzni *(azaz ha a cs.exe a 'C:\net572' könyvtárban van, akkor a művelet végén a 'Path' értéke valami ilyesmi lesz: "C:\Users\...\AppData\Local\Microsoft\WindowsApps;C:\net472")*.
Ha több cs.exe is van, akkor javaslom a legrövidebb elérési úttal rendelkezőt választani, mert jelen írás szempontjából a verziónak nincs gyakorlati jelentősége.

Ha a rendszeren nem található meg a csc.exe, akkor letölthetjül a [roslyn - Microsoft.Net.Compilers.Toolset](https://dotnet.myget.org/feed/roslyn/package/nuget/Microsoft.Net.Compilers.Toolset) oldalról a [3.8.0-1.20330.5](https://dotnet.myget.org/F/roslyn/api/v2/package/Microsoft.Net.Compilers.Toolset/3.8.0-1.20330.5).ös verziójú 
A Microsoft.Net.Compilers.Toolset.3.8.0-1.20330.5.nupkg\tasks\net472 könyvtár kicsomagolása, ebben lesz a "csc.exe"
Fordítás pl: csc.exe -r:System.Windows.Forms.dll,System.Drawing.dll -target:winexe -win32icon:icon.ico Fájlnév.cs
Fordítás és futtatás pl: csc.exe -r:System.Windows.Forms.dll,System.Drawing.dll -target:winexe -win32icon:icom.ico Fájlnév.cs && Fájlnév.exe

### Notepad++ -szal
[Notepad++ letöltés](https://notepad-plus-plus.org/downloads)
[v7.8.8 64-bit zip package](https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v7.8.8/npp.7.8.8.bin.x64.zip)
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

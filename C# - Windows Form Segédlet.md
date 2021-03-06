# C# - Windows Form Development "Tutorial"

Jelen írásnak nem célja egy teljes körű C# segédlet, vagy valamiféle kézikönyv elkészítése, sokkal inkább cél annak bemutatása, hogy olyan nehézsúlyú fejlesztői környezetek nélkül, mint például a Microsoft Visual Studio, hogyan lehet az egyszerű parancssoros programoknál felhasználó barátabb programokat készíteni, a lehető legegyszerűbb eszközökkel.

## Egy minimalista C# fejlesztő környezet beállítása

### Parancssor használatával

*(Ennek előnye, hogy még az olyan egyszerű szövegszerkesztő is elegendő, mint például a Windows Notepad-ja, bár nem túl kényelmes...)*

A C#-ban írt programok fordításához szülséges a **csc.exe**, melyet legegyszerűbben a '**where /r c:\ csc.exe**' paranccsal lehet megtalálni.
Az ezt a programot tartalmazó könyvtárat célszerű hozzáadni a **PATH** környezeti változóhoz: Windows 10 alatt a Gépház-ban a kereső mezőbe elég beírni, hogy *"körn"* és a listából kiválaszttani *"A fiók környezeti változóinak szerkesztése"* lehetőséget, majd a felhasználói változók között a '*Path*' értékéhez *(ami alapból valami ilyesmi: "C:\Users\\...\AppData\Local\Microsoft\WindowsApps")* hozzáfűzni. Azaz, ha például a *csc.exe* a '*C:\Programs\net572*' könyvtárban van, akkor a művelet végén a '*Path*' értéke valami ilyesmi lesz: '*C:\Users\\...\AppData\Local\Microsoft\WindowsApps;C:\Programs\net472)*'.
Ha több csc.exe is van, akkor javaslom a legrövidebb elérési úttal rendelkezőt választani. *(Jelen írás szempontjából a verziónak nincs gyakorlati jelentősége, de nyilván a legújabb nyelvi elemeket csak a legújabb verziójú fordítók ismerik.)*

Ha a rendszeren nem található meg a csc.exe, akkor például letölthetjük a [roslyn - Microsoft.Net.Compilers.Toolset](https://dotnet.myget.org/feed/roslyn/package/nuget/Microsoft.Net.Compilers.Toolset) oldalról a [Microsoft.Net.Compilers.Toolset.3.8.0-1.20330.5.nupkg](https://dotnet.myget.org/F/roslyn/api/v2/package/Microsoft.Net.Compilers.Toolset/3.8.0-1.20330.5) csomagot.
Mivel ez a fájl a '*nupkg*' kiterjesztés ellenére valójában egy ZIP fájl, nyugodtan nevezzük át a kiterjesztést 'zip'-re *(a Windows ezt a lépést jellemzően nehezményezi, de ezzel nem kell foglalkozni)*, majd a Fájlkezelő-vel lépjünk bele a fájlba *(a Windows ezt a lépést is általában nehezményezi, mert 'gyanús' neki az Internet-ről letöltött ZIP fájl, de jelen esetben ezzel sem kell foglalkozni)* és másoljuk ki a '**tasks\net472**' könyvtárat egy tetszőleges helyre. *(Én általában a telepítést nem igénylő programokat a C:\Programs könyvtárba teszem.)* Ettől kezdve, vagy a beírjuk a csc.exe elé a teljes elérési útját *(a TAB segítségével ez nem túl bonyolult...)*, vagy ha hozzáadtuk a könyvtárat a '*PATH*'-hoz, akkor a fordító bármely könyvtárban elindul a csc.exe parancs hatására.

Ezt követően a legegyszerűbb program esetén fordítás valahogy így néz ki:
>csc.exe -r:System.Windows.Forms.dll Fájlnév.cs

Több forrásfájl *(\*.cs)* esetén... :
>csc.exe -r:System.Windows.Forms.dll Fájlnév1.cs Fájlnév2.cs \sokcsv\\\*.csv

Használhatunk többféle parancssori kapcsolót *(melyek neve jobbára önmagáért beszél...)*, például így:
>csc.exe -platform:x64 -target:winexe -win32icon:icon.ico -debug+ -r:System.Windows.Forms.dll,System.Drawing.dll /out: AzÉnProgramom.exe Fájlnév.cs 

Ha a sikeres fordítás után rögtön futtatni is szeretnénk a programot:
>csc.exe -r:System.Windows.Forms.dll Fájlnév.cs **&&** Fájlnév.exe

### Notepad++ használatával

A Notepad++ egy "egyszerű" szövegszerkesztő, melyhez számtalan kiegészítő érhető el, többek között egy komplett .NET fordító is. E programot letölthetjük a [saját oldaláról](https://notepad-plus-plus.org/downloads) oldalról, vagy a 'v7.8.8 64-bit zip package' csomagot közvetlenül [erről](https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v7.8.8/npp.7.8.8.bin.x64.zip) a linkről.

A Notepad++ elindítását követően
  1. indítsuk ez a Plugin Manager-t:
  2. Bővítmények -> Plugin Manager -> Show Plugin Manager
  3. Válasszuk ki az 'Available' fülön a 'CS-Script (C# INtelisense)' csomagot és telepítsük fel.
  4. Ha ez sikeres, akkor a programok futtathatóak a
  5. Bővítmények -> CS-Script -> Run (F5) menüpontban.

## Példaprogramok

### A létező legegyszerűbb példa:
```
// csc.exe -r:System.Windows.Forms.dll WinFormsMinimal.cs && WinFormsMinimal.exe

using System.Windows.Forms;

class WinFormsMinimal
{
    public static void Main()
    {
        Application.Run( new Form() );
    }
}
```
*Megjelenít egy alapértelmezett méretű, üres Form-ot (ablakot). Mivel itt Form-ra nem tudunk hivatkozni, így nem sokat lehet vele kezdeni, viszont az látszik, hogy a fordítás megtörtént és a program fut.*

### A létező legegyszerűbb példa, továbbfejlesztve:
```
// csc.exe -r:System.Windows.Forms.dll WinFormsMinimal+.cs && WinFormsMinimal+.exe

using System.Windows.Forms;

class WinFormsMinimal
{
    public static void Main()
    {
        Form f = new Form();
        f.Text = "Hello World!";
        Application.Run( f );
    }
}
```
*A Form-hoz rendeltünk egy nevet, így tudunk rá hivatkozni és további műveleteket végezni, jelen esetben beállítjuk az ablak címfeliratát, illetve a sikeres fordítás után rögtön futtatjuk is.*

### Egy egyszerű, de "értelmesebb" példa:
```
// csc.exe -r:System.Windows.Forms.dll WinFormsHelloWorldProgram.cs && WinFormsHelloWorldProgram.exe

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
        this.Text = "Click Me!";
        this.Click += new EventHandler (Button_Click);
    }

    void Button_Click (object sender, EventArgs e)
    {
        MessageBox.Show ("Button Clicked!");
    }
}
```

*... Itt már több dolgot is el kell magyarázni...*

Az első fontos különbség, hogy a létrehozott osztály leszármazottja lesz a "Form" osztálynak *(örökli annak minden tulajdonságát)*, így ha létrehozunk belőle egy példányt, akkor egy a Form osztállyal egyenértékű példány jön létre. Az öröklés folytán ennek a példánynak lesz például "Text" tulajdonsága, melyre a **this** kulcsszóval hivatkozhatunk, vagy akár el is hagyhatjuk.


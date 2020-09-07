# teszt


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

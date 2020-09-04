/*
  C:\Temp\phingi>csc.exe -r:System.Windows.Forms.dll,System.Drawing.dll gomb.cs && gomb.exe
*/
using System;
using System.Windows.Forms;
using System.Drawing;

public class Program : Form
{

	Button Gombó;
	Label szám;
	int gombnyomásszámláló=0;

	[STAThread]
	public static void Main()
	{
		Application.Run(new Program());
	}

	public Program()
	{
		Text = "A Gombó 1";
		
		Gombó = new Button();
		Controls.Add(Gombó);
		Gombó.Text="nyomj meg :)";
		Gombó.Size = new Size(100, 20);
		Gombó.Location=new Point(10, 10);
		Gombó.Click += new EventHandler(buttonclick);
		
		szám=new Label();
		szám.Text="0";
		szám.Size = new Size(100, 20);
		szám.Location=new Point(10, 50);
		Controls.Add(szám);
	}


	private  void buttonclick (object sender, EventArgs e)
	{
		gombnyomásszámláló+=1;
		szám.Text=gombnyomásszámláló.ToString();
	}
	
}
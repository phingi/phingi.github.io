/*
  C:\Temp\phingi>csc.exe -r:System.Windows.Forms.dll,System.Drawing.dll gomb.cs && gomb.exe
*/
using System;
using System.Windows.Forms;
using System.Drawing;

public class Program : Form
{

	Button Gomb�;
	Label sz�m;
	int gombnyom�ssz�ml�l�=0;

	[STAThread]
	public static void Main()
	{
		Application.Run(new Program());
	}

	public Program()
	{
		Text = "A Gomb� 1";
		
		Gomb� = new Button();
		Controls.Add(Gomb�);
		Gomb�.Text="nyomj meg :)";
		Gomb�.Size = new Size(100, 20);
		Gomb�.Location=new Point(10, 10);
		Gomb�.Click += new EventHandler(buttonclick);
		
		sz�m=new Label();
		sz�m.Text="0";
		sz�m.Size = new Size(100, 20);
		sz�m.Location=new Point(10, 50);
		Controls.Add(sz�m);
	}


	private  void buttonclick (object sender, EventArgs e)
	{
		gombnyom�ssz�ml�l�+=1;
		sz�m.Text=gombnyom�ssz�ml�l�.ToString();
	}
	
}
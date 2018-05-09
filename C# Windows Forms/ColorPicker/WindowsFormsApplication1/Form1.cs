using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gma.System.Windows;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		UserActivityHook actHook;
		static Bitmap BMP;
		static Graphics GPS;
		static int X, Y;
		public Form1()
		{
			InitializeComponent();
			this.Load += new EventHandler(this.MainFormLoad);

		}

		void MainFormLoad(object sender, System.EventArgs e)
		{
			actHook = new UserActivityHook();
			actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
			actHook.KeyDown += new KeyEventHandler(MyKeyDown);
		}

		void MouseMoved(object sender, MouseEventArgs e)
		{
			Y = e.Y;
			X = e.X;	
		}

		void MyKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.C)
			{
				BMP = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				GPS = Graphics.FromImage(BMP);
				GPS.CopyFromScreen(0, 0, 0, 0, BMP.Size);
				Color CPX = BMP.GetPixel(X, Y);
				Clipboard.SetText("#" + CPX.R.ToString("X2") + CPX.G.ToString("X2") + CPX.B.ToString("X2"));
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Control
{
	public partial class Form1 : Form
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
		private const int MOUSEEVENTF_LEFTDOWN = 0x02;
		private const int MOUSEEVENTF_LEFTUP = 0x04;
		private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const int MOUSEEVENTF_RIGHTUP = 0x10;
		public Form1()
		{
			InitializeComponent();
			//this.button1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			//this.BackgroundImage = Image.FromFile("1.jpg");
			//this.button1.Cursor = new Cursor("error.ico");
			//this.button1.Padding = new Padding(30);

			this.button1.Tag = "One";
			this.button2.Tag = "Two";
			this.button3.Tag = "Three";
			this.button4.Tag = "Four";
		}

		private void button1_Click(object sender, EventArgs e)
		{
		//	Cursor.Position = new Point(150, 150);
		//	mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
			if (sender is System.Windows.Forms.Control)
			{
				object obj = ((System.Windows.Forms.Control)sender).Tag;
				if (obj != null)
				{
					switch(obj.ToString())
					{
						case "One":
							MessageBox.Show("нажата первая кнопка");
							break;
						case "Two":
							MessageBox.Show("нажата вторая кнопка");
							break;
						case "Three":
							MessageBox.Show("нажата третья кнопка");
							break;
						case "Four":
							MessageBox.Show("нажата четвертая кнопка");
							break;
					}
				}
			}
		}
	}
}

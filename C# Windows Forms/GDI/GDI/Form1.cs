using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI
{
	public partial class Form1 : Form
	{
		private List<Point> points = new List<Point>();
		public Form1()
		{
			InitializeComponent();
			this.Paint += Form1_Paint;
			this.MouseDown += Form1_MouseDown;
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			Graphics g = this.CreateGraphics();

			//g.FillEllipse(Brushes.Green, e.X - 15, e.Y - 15, 30, 30);
			//this.points.Add(e.Location);
			//g.Dispose();
			this.Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			//Graphics g = e.Graphics;
			//g.DrawEllipse(Pens.Red, 20, 20, 200, 150);
			//g.FillRectangle(Brushes.Yellow, 50, 50, 100, 100);
			//g.DrawString(
			//		"Hello, World!",
			//		new Font("Courier New", 20.0f, FontStyle.Bold),
			//		Brushes.Green,
			//		new PointF(200, 200)
			//	);
			Graphics g = e.Graphics;
			g.Clear(Color.White);
			foreach (Point P in this.points)
			{
				g.FillEllipse(Brushes.Red, P.X - 15, P.Y - 15, 30, 30);
			}
			g.Dispose();
		}


	}
}

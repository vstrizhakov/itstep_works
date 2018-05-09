using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI2
{
	public partial class Form1 : Form
	{
		private bool isDraw = false;
		private Point ptBeg;
		private List<Rectangle> figures = new List<Rectangle>();
		private BufferedGraphicsContext context;
		private BufferedGraphics bgGraph;
		public Form1()
		{
			InitializeComponent();
			this.Paint += Form1_Paint;
			this.MouseDown += Form1_MouseDown;
			this.MouseUp += Form1_MouseUp;
			this.MouseMove += Form1_MouseMove;
			this.SizeChanged += Form1_SizeChanged;

			this.context = BufferedGraphicsManager.Current;
			this.context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
			this.bgGraph = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
			this.DoubleBuffered = true;
		}

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			this.context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
			this.bgGraph = context.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.isDraw == false)
				return;
			Rectangle R = new Rectangle(
					(ptBeg.X < e.X) ? ptBeg.X : e.X,
					(ptBeg.Y < e.Y) ? ptBeg.Y : e.Y,
					Math.Abs(ptBeg.X - e.X),
					Math.Abs(ptBeg.Y - e.Y)
				);
			//Graphics g = this.CreateGraphics();
			//g.Clear(Color.White);
			this.bgGraph.Graphics.Clear(Color.White);
			foreach (Rectangle R2 in this.figures)
			{
				//g.FillEllipse(Brushes.Red, R2);
				this.bgGraph.Graphics.FillEllipse(Brushes.Green, R2);
			}
			this.bgGraph.Graphics.FillEllipse(Brushes.Red, R);
			Graphics g = this.CreateGraphics();
			this.bgGraph.Render(g);

			
			//g.FillEllipse(Brushes.Red, R);
			g.Dispose();
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			this.isDraw = false;
			Rectangle R = new Rectangle(
					(ptBeg.X < e.X) ? ptBeg.X : e.X,
					(ptBeg.Y < e.Y) ? ptBeg.Y : e.Y,
					Math.Abs(ptBeg.X - e.X),
					Math.Abs(ptBeg.Y - e.Y)
				);
			this.figures.Add(R);
			this.Invalidate();
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			this.isDraw = true;
			this.ptBeg = e.Location;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			this.bgGraph.Graphics.Clear(Color.White);
			//g.Clear(Color.White);
			foreach (Rectangle R in this.figures)
			{
				//g.FillEllipse(Brushes.Green, R);
				this.bgGraph.Graphics.FillEllipse(Brushes.Green, R);
			}
			this.bgGraph.Render(g);
		}
	}
}

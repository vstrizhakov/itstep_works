using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CartWithBalls
{
	public partial class Form1 : Form
	{
		static private Brush[] Colors = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Green, Brushes.Orange, Brushes.Pink, Brushes.Blue, Brushes.Violet, Brushes.Aquamarine, Brushes.Gold, Brushes.Olive };
		private Dictionary<Panel, BufferedGraphics> PanelToGraphics = new Dictionary<Panel, BufferedGraphics>();
		private BufferedGraphicsContext BGC = BufferedGraphicsManager.Current;
		private Panel[] panels;
		private int size = 0;
		private int[] Balls = new int[100];
		public Form1()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
			this.SizeChanged += this.FormSizeChanged;

			this.panels = new Panel[] { this.panel1, this.panel2, this.panel3, this.panel4, this.panel5 };

			BGC.MaximumBuffer = new Size(panels[0].Width + 1, panels[1].Height + 1);
			foreach (Panel p in panels)
			{
				p.Paint += this.PanelPaint;
				BufferedGraphics BG = BGC.Allocate(p.CreateGraphics(), new Rectangle(0, 0, p.Width, p.Height));
				this.PanelToGraphics.Add(p, BG);
			}

			while (true)
			{
				int xx = this.panels[0].Width / (this.size + 1);
				int yy = this.panels[0].Height / (this.size + 1);
				if (xx * yy <= 100)
					break;
				this.size++;
			}

			Semaphore S = new Semaphore(5, 5);
			EventWaitHandle AllEWH = new EventWaitHandle(true, EventResetMode.ManualReset);
			EventWaitHandle WritersEWH = new EventWaitHandle(true, EventResetMode.AutoReset);

			for (int i = 0; i < 2; i++)
			{
				BallWriter BW = new BallWriter(S, AllEWH, WritersEWH, this.Balls, this.listBox1);
				Thread T = new Thread(BW.Run);
				T.Name = (i + 1).ToString();
				T.IsBackground = true;
				T.Start();
			}

			for (int i = 0; i < 5; i++)
			{
				BallReader BR = new BallReader(S, AllEWH, this.Balls, panels[i], this.listBox1);
				Thread T = new Thread(BR.Run);
				T.Name = (i + 1).ToString();
				T.IsBackground = true;
				T.Start();
			}
		}

		private void FormSizeChanged(object sender, EventArgs e)
		{
			this.BGC.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
			foreach (Panel p in panels)
			{
				this.PanelToGraphics[p] = BGC.Allocate(p.CreateGraphics(), new Rectangle(0, 0, p.Width, p.Height));
				p.Invalidate();
			}
			this.size = 0;
			while (true)
			{
				int xx = this.panels[0].Width / (this.size + 1);
				int yy = this.panels[0].Height / (this.size + 1);
				if (xx * yy <= 100)
					break;
				this.size++;
			}
		}

		private void PanelPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Panel p = (Panel)sender;
			BufferedGraphics BG = this.PanelToGraphics[p];
			BG.Graphics.Clear(Color.Black);
			int x = 0, y = 0;
			foreach (int i in this.Balls)
			{
				if (i == 0)
					continue;
				BG.Graphics.FillEllipse(Form1.Colors[i - 1], new Rectangle(x, y, this.size, this.size));
				x += this.size;
				if (x >= this.panels[0].Width - this.size)
				{
					y += this.size;
					x = 0;
				}
			}
			BG.Render(g);
		}
	}

	class BallWriter
	{
		private Semaphore S;
		private int[] A;
		private ListBox Console;
		private EventWaitHandle AllEWH;
		private EventWaitHandle WritersEWH;

		public BallWriter(Semaphore S, EventWaitHandle AllEWH, EventWaitHandle WritersEWH, int[] A, ListBox Console)
		{
			this.S = S;
			this.A = A;
			this.Console = Console;
			this.AllEWH = AllEWH;
			this.WritersEWH = WritersEWH;
		}

		public void Run()
		{
			while (true)
			{
				this.WritersEWH.WaitOne();
				this.AllEWH.Reset();
				this.S.WaitOne();
				this.S.WaitOne();
				this.S.WaitOne();
				this.S.WaitOne();
				this.S.WaitOne();
				this.AllEWH.Set();
				this.WritersEWH.Set();

				this.Console.Items.Insert(0, "");
				this.Console.Items.Insert(0, String.Format("Писатель #{0} начал свою работу", Thread.CurrentThread.Name));

				Random R = new Random();
				for (int i = 0; i < 100; i++)
				{
					int color = R.Next(0, 9);
					this.A[i] = color;
					Thread.Sleep(10);
				}

				this.Console.Items.Insert(0, String.Format("Писатель #{0} закончил свою работу", Thread.CurrentThread.Name));
				this.Console.Items.Insert(0, "");

				this.S.Release();
				this.S.Release();
				this.S.Release();
				this.S.Release();
				this.S.Release();
				Thread.Sleep(1000);
			}
		}
	}

	public partial class MyPanel : Panel
	{
		public MyPanel() : base()
		{
			this.DoubleBuffered = true;
		}
	}

	class BallReader
	{
		private Semaphore S;
		private int[] A;
		private Panel P;
		private ListBox Console;
		private EventWaitHandle AllEWH;

		public BallReader(Semaphore S, EventWaitHandle AllEWH, int[] A, Panel P, ListBox Console)
		{
			this.S = S;
			this.A = A;
			this.P = P;
			this.Console = Console;
			this.AllEWH = AllEWH;
		}

		public void Run()
		{
			while (true)
			{
				this.AllEWH.WaitOne();
				this.S.WaitOne();

				this.Console.Items.Insert(0, String.Format("Читатель #{0} начал свою работу", Thread.CurrentThread.Name));

				Thread.Sleep(1000);
				this.P.Invalidate();
				Thread.Sleep(1000);

				this.Console.Items.Insert(0, String.Format("Читатель #{0} закончил свою работу", Thread.CurrentThread.Name));

				this.S.Release();
				Thread.Sleep(1000);
			}
		}
	}

	public partial class MyListBox : ListBox
	{
		public MyListBox() : base()
		{
			this.DoubleBuffered = true;
		}
	}
}

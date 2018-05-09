using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CrocodileServer;
using System.Threading;
using System.Text.RegularExpressions;

namespace Client
{
	public partial class Game : Form
	{
		private bool IsDrawing = false;
		private Point PrevPoint;
		private int PenSize = 2;
		private int PenOpacity = 255;
		private Color PenColor = Color.Black;
		private Room Room;
		private Line Line;
		private BufferedGraphicsContext Context;
		private List<Line> Lines = new List<Line>();
		private BufferedGraphics BgGraph;
		private int lastId = 0;
		private PictureBox PB;
		private int type;

		public Game(Room Room, int type)
		{
			InitializeComponent();
			this.type = type;
			this.Room = Room;
			this.panel1.MouseDown += Panel1_MouseDown;
			this.panel1.MouseMove += Panel1_MouseMove;
			this.panel1.MouseUp += Panel1_MouseUp;
			this.panel1.Paint += Panel1_Paint;
			this.FormClosing += Game_FormClosing;
			this.Context = BufferedGraphicsManager.Current;
			this.Context.MaximumBuffer = new Size(this.panel1.ClientSize.Width + 1, this.panel1.ClientSize.Height + 1);
			this.BgGraph = this.Context.Allocate(this.panel1.CreateGraphics(), new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
			this.Shown += Game_Shown;
		}

		private void Game_Shown(object sender, EventArgs e)
		{
			GameController.OnChatChanged -= GameController_OnChatChanged;
			GameController.OnImageChanged -= GameController_OnImageChanged;
			GameController.OnSecondsLeftChanged -= GameController_OnSecondsLeftChanged;
			GameController.OnPainterChanged -= GameController_OnPainterChanged;

			GameController.OnChatChanged += GameController_OnChatChanged;
			GameController.OnImageChanged += GameController_OnImageChanged;
			GameController.OnSecondsLeftChanged += GameController_OnSecondsLeftChanged;
			GameController.OnPainterChanged += GameController_OnPainterChanged; ;

			if (GameController.Chat != null)
			{
				this.lastId = GameController.Chat.Count;
				for (int i = 0; i < lastId; i++)
					this.chat.Items.Add(GameController.Chat[i]);
			}

			if (this.Room.PainterName == GameController.Username)
			{
				while (true)
				{
					String word = GameController.GetWord();
					if (word == "-1")
					{
						this.DialogResult = DialogResult.Abort;
						this.Close();
						break;
					}
					else if (MessageBox.Show(String.Format("Предлагаемое слово - {0}\r\nДа - показывать\r\nНет - получить другое слово", word), "Выбор слова", MessageBoxButtons.YesNo) == DialogResult.Yes)
						if (GameController.SetWord(word) == true)
						{
							this.DialogResult = DialogResult.Abort;
							this.Close();
						}
						else
						{
							this.word.Text = word;
							break;
						}
				}
			}
			else
			{
				this.PB = new PictureBox();
				this.PB.Size = this.panel1.ClientSize;
				this.PB.Location = new Point(-10, -20);
				this.panel1.Parent = null;
				this.tableLayoutPanel1.Controls.Add(PB, 0, 1);
				this.PB.BorderStyle = BorderStyle.FixedSingle;
				if (GameController.Img != null)
					this.PB.Image = GameController.Img;
			}
			this.painter.Text = "Рисует: " + Room.PainterName;
		}

		private void GameController_OnPainterChanged()
		{
			this.painter.Text = GameController.Painter;
		}

		private void GameController_OnSecondsLeftChanged()
		{
			this.Invoke(new Action(() =>
			{
				if (GameController.SecondsLeft <= 0)
				{
					FinishGame FG = new FinishGame();
					if (FG.ShowDialog() == DialogResult.Yes)
						this.DialogResult = DialogResult.Yes;
					this.Close();
				}
				else

					this.secondsLeft.Text = GameController.SecondsLeft + " сек...";
			}));
		}

		private void GameController_OnImageChanged()
		{
			if (this.Room.PainterName != GameController.Username)
				PB.Image = GameController.Img;
		}

		private void Game_FormClosing(object sender, FormClosingEventArgs e)
		{
			GameController.OnChatChanged -= GameController_OnChatChanged;
			GameController.OnImageChanged -= GameController_OnImageChanged;
			GameController.OnSecondsLeftChanged -= GameController_OnSecondsLeftChanged;
			GameController.OnPainterChanged -= GameController_OnPainterChanged;
			if (GameController.SecondsLeft > 0 && GameController.LeaveRoom() == -1)
				this.DialogResult = DialogResult.Abort;
		}

		private void GameController_OnChatChanged()
		{
			Regex regEx = new Regex(".*зашел.*");
			while (this.lastId < GameController.Chat.Count)
			{
				if (!this.chat.Items.Contains(GameController.Chat[lastId]) || !regEx.IsMatch(GameController.Chat[lastId]))
					this.Invoke(new Action(() =>
					{
						this.chat.Items.Add(GameController.Chat[lastId]);
						this.chat.TopIndex = this.chat.Items.Count - 1;
					}));
				lastId++;
			}
		}

		private void Panel1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			this.BgGraph.Graphics.Clear(Color.White);
			foreach (Line line in this.Lines)
				for (int i = 1; i < line.Points.Count; i++)
					this.BgGraph.Graphics.DrawLine(line.Pen, line.Points[i - 1], line.Points[i]);
			if (this.Line != null)
				for (int i = 1; i < this.Line.Points.Count; i++)
					this.BgGraph.Graphics.DrawLine(this.Line.Pen, this.Line.Points[i - 1], this.Line.Points[i]);
			this.BgGraph.Render(g);
		}

		private void Panel1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;
			this.IsDrawing = true;
			this.PrevPoint = e.Location;

			Pen pen = new Pen(Color.FromArgb(this.PenOpacity, this.PenColor), this.PenSize);
			pen.StartCap = LineCap.Round;
			pen.EndCap = LineCap.Round;
			pen.LineJoin = LineJoin.Round;

			this.Line = new Line(pen);
			this.Line.AddPoint(this.PrevPoint);
		}

		private void Panel1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || this.Line == null)
				return;
			this.IsDrawing = false;
			Point endPoint = new Point(e.Location.X + 1, e.Location.Y + 1);
			this.Line.AddPoint(endPoint);
			this.BgGraph.Graphics.DrawLine(this.Line.Pen, this.PrevPoint, endPoint);
			this.PrevPoint = e.Location;
			this.Lines.Add(this.Line);
			this.Line = null;
			Graphics g = this.panel1.CreateGraphics();
			this.BgGraph.Render(g);
			Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);
			Rectangle R = new Rectangle(0, 0, this.panel1.Width, this.panel1.Height);
			this.panel1.DrawToBitmap(bmp, R);
			GameController.SendImage(bmp);
			bmp.Dispose();
		}

		private void Panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.IsDrawing)
			{
				this.Line.AddPoint(e.Location);
				this.BgGraph.Graphics.DrawLine(this.Line.Pen, this.PrevPoint, e.Location);
				this.PrevPoint = e.Location;
				Graphics g = this.panel1.CreateGraphics();
				this.BgGraph.Render(g);
				Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);
				Rectangle R = new Rectangle(0, 0, this.panel1.Width, this.panel1.Height);
				this.panel1.DrawToBitmap(bmp, R);
				GameController.SendImage(bmp);
				bmp.Dispose();
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			this.PenSize = this.trackBar1.Value;
		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			this.PenOpacity = this.trackBar2.Value;
		}

		private void panel2_Click(object sender, EventArgs e)
		{
			Panel P = (Panel)sender;
			this.PenColor = P.BackColor;
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.button1_Click(null, null);
				e.Handled = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (GameController.SendMessage(this.textBox1.Text) == "-1")
			{
				this.DialogResult = DialogResult.Abort;
				this.Close();
				return;
			}
			this.textBox1.Text = "";
			this.textBox1.Focus();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Close();
		}
	}

	class Line
	{
		public Pen Pen { get; set; }
		public List<Point> Points { get; } = new List<Point>();

		public void AddPoint(Point p)
		{
			this.Points.Add(p);
		}

		public Line(Pen pen)
		{
			this.Pen = pen;
		}
	}

	public class MyPanel : Panel
	{
		public MyPanel() : base()
		{
			this.DoubleBuffered = true;
		}
	}
}

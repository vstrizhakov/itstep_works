using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pyatnashki
{
	public partial class Form1 : Form
	{
		private int[,] area;
		private List<Button> btnArea = new List<Button>();
		private int step = 0;
		private int size;
		private int seconds = 0;
		private LinkLabel prevLink;

		public Form1()
		{
			InitializeComponent();
			this.size = 3;
			this.linkLabel1.Enabled = false;
			this.prevLink = this.linkLabel1;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.seconds++;
			this.time.Text = String.Format("{0:D2}:{1:D2}", this.seconds / 60, this.seconds % 60);
		}

		private void BtnClick(object sender, EventArgs e)
		{
			if (sender is Button)
			{
				Button tmp = (Button)sender;
				String[] crd = ((String)tmp.Tag).Split(new char[] { ';' });
				int y = Int32.Parse(crd[0]), x = Int32.Parse(crd[1]), x1 = 0, y1 = 0;
				bool flag = false;
				if (y + 1 < this.size && this.area[y + 1, x] == 0)
				{
					flag = true;
					y1 = y + 1;
					x1 = x;
				}
				else if (y - 1 >= 0 && this.area[y - 1, x] == 0)
				{
					flag = true;
					y1 = y - 1;
					x1 = x;
				}
				else if (x + 1 < this.size && this.area[y, x + 1] == 0)
				{
					flag = true;
					y1 = y;
					x1 = x + 1;
				}
				else if (x - 1 >= 0 && this.area[y, x - 1] == 0)
				{
					flag = true;
					y1 = y;
					x1 = x - 1;
				}
				if (flag)
				{
					tmp.Tag = (object)String.Format("{0};{1}", y1, x1);
					this.area[y1, x1] = Int32.Parse(tmp.Text);
					this.area[y, x] = 0;
					this.step++;
					this.Draw(tmp, x1, y1);
					if (this.CheckWin())
					{
						this.Stop(sender, e);
						MessageBox.Show(String.Format("Поздравляем, вы сложили пятнашки в правильной последовательности!\nКол-во ходов: {0} Время игры: {1:D2}:{2:D2} Сложность: {3}x{3}", this.step, this.seconds / 60, this.seconds % 60, this.size));
					}
				}
			}
		}

		private void Start(object sender, EventArgs e)
		{
			this.timer1.Enabled = false;
			this.panel.Controls.Clear();
			this.step = 0;
			this.seconds = 0;
			this.time.Text = String.Format("{0:D2}:{1:D2}", this.seconds / 60, this.seconds % 60);
			this.steps.Text = this.step.ToString();
			this.area = new int[this.size, this.size];
			Random R = new Random();
			int x = 0, y = 0, i = 0;
			while (i < this.size * this.size - 1)
			{
				x = R.Next(0, this.size);
				y = R.Next(0, this.size);
				if (this.area[x, y] == 0)
					this.area[x, y] = i++ + 1;
			}
			int wh = this.panel.Width / this.size;
			for (i = 0; i < this.size; i++)
			{
				for (int j = 0; j < this.size; j++)
				{
					if (this.area[i, j] == 0)
						continue;
					Button tmp = new Button();
					tmp.Size = new Size(wh, wh);
					tmp.Location = new Point(wh * j, wh * i);
					tmp.Text = this.area[i, j].ToString();
					tmp.Tag = (object)String.Format("{0};{1}", i, j);
					tmp.Click += this.BtnClick;
					this.panel.Controls.Add(tmp);
					this.btnArea.Add(tmp);
				}
			}
			this.timer1.Enabled = true;
		}

		private void Draw(Button b1, int x, int y)
		{
			this.time.Text = String.Format("{0:D2}:{1:D2}", this.seconds / 60, this.seconds % 60);
			this.steps.Text = this.step.ToString();
			int wh = this.panel.Width / this.size;

			this.panel.Controls.Remove(b1);
			this.btnArea.Remove(b1);
			Button tmp = new Button();
			tmp.Size = new Size(wh, wh);
			tmp.Location = new Point(wh * x, wh * y);
			tmp.Text = this.area[y, x].ToString();
			tmp.Tag = (object)String.Format("{0};{1}", y, x);
			tmp.Click += this.BtnClick;
			this.panel.Controls.Add(tmp);
			this.btnArea.Add(tmp);
		}

		private void Stop(object sender, EventArgs e)
		{
			this.timer1.Enabled = false;
			foreach (Button btn in this.btnArea)
				btn.Enabled = false;
		}

		private bool CheckWin()
		{
			int num = 0;
			for (int j = 0; j < this.size; j++)
			{
				for (int i = 0; i < this.size && j * this.size + i < this.size * this.size - 1; i++)
				{
					if (this.area[j, i] > num)
						num = this.area[j, i];
					else
						return false;
				}
			}
			return true;
		}

		private void ChangeSize(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (sender is LinkLabel)
			{
				prevLink.Enabled = true;
				LinkLabel tmp = (LinkLabel)sender;
				tmp.Enabled = false;
				this.size = Int32.Parse((String)tmp.Tag);
				prevLink = tmp;

				this.Start(sender, e);
			}
		}
	}
}

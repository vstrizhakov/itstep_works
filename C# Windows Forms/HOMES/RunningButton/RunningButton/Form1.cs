using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningButton
{
	public partial class Form1 : Form
	{
		private int X;
		private int Y;
		private int btnBottom;
		private int btnRight;
		private int btnX;
		private int btnY;
		public Form1()
		{
			InitializeComponent();
			this.MouseMove += Form1_MouseMove;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			int d = 10;
			btnX = this.btn.Location.X;
			btnY = this.btn.Location.Y;
			X = e.X;
			Y = e.Y;
			btnBottom = btnY + this.btn.Height;
			btnRight = btnX + this.btn.Width;
			if (X > btnX - d && X < btnX && Y > btnY && Y < btnBottom)
				this.btn.Location = new Point(btnX + 5, btnY);
			else if (X < btnRight + d && X > btnRight && Y > btnY && Y < btnBottom)
				this.btn.Location = new Point(btnX - 5, btnY);
			else if (Y > btnY - d && Y < btnY && X > btnX && X < btnRight)
				this.btn.Location = new Point(btnX, btnY + 5);
			else if (Y < btnBottom + d && Y > btnBottom && X > btnX && X < btnRight)
				this.btn.Location = new Point(btnX, btnY - 5);
			else if (X > btnX - d && X < btnX && Y > btnY - d && Y < btnY)
				this.btn.Location = new Point(btnX + 5, btnY + 5);
			else if (X < btnRight + d && X > btnRight && Y > btnY - d && Y < btnY)
				this.btn.Location = new Point(btnX - 5, btnY + 5);
			else if (X < btnRight + d && X > btnRight && Y > btnBottom && Y < btnBottom + d)
				this.btn.Location = new Point(btnX - 5, btnY - 5);
			else if (X > btnX - d && X < btnX && Y > btnBottom && Y < btnBottom + d)
				this.btn.Location = new Point(btnX + 5, btnY - 5);

			if (this.btn.Location.X < 15)
				this.btn.Location = new Point(this.Width - 85, this.btn.Location.Y);
			if (this.btn.Location.Y < 15)
				this.btn.Location = new Point(this.btn.Location.X, this.Height - 100);
			if (this.btn.Location.Y + 70 > this.Height - 30)
				this.btn.Location = new Point(this.btn.Location.X, 15);
			if (this.btn.Location.X + 70 > this.Width - 15)
				this.btn.Location = new Point(15, this.btn.Location.Y);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void ButtonMouseMove(object sender, MouseEventArgs e)
		{
			int x = this.Location.X + e.X, y = this.Location.Y + e.Y;
			Button tmp = (Button)sender;
			Random R = new Random();
			int direction = R.Next(0, 8);
			switch (direction)
			{
				case 0:
					tmp.Location = new Point(x + 70, y);
					break;
				case 1:
					tmp.Location = new Point(x - 70, y);
					break;
				case 2:
					tmp.Location = new Point(x, y - 70);
					break;
				case 3:
					tmp.Location = new Point(x, y + 70);
					break;
				case 4:
					tmp.Location = new Point(x + 70, y + 70);
					break;
				case 5:
					tmp.Location = new Point(x + 70, y - 70);
					break;
				case 6:
					tmp.Location = new Point(x - 70, y + 70);
					break;
				case 7:
					tmp.Location = new Point(x - 70, y - 70);
					break;
			}
		}

		private void btn_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Вы кликнули на кнопку!");
		}
	}
}

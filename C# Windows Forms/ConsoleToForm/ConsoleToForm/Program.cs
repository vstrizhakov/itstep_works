using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleToForm
{
	class Program
	{
		static void Main(string[] args)
		{
			Form F = new Form();
			F.Text = "Первое Windows Forms приложение";
			F.Size = new Size(400, 300);

			Button B1 = new Button();
			B1.Click += B1_Click;
			B1.Text = "Первая кнопка";
			B1.Size = new Size(150, 30);
			B1.Top = 20;
			B1.Left = 20;
			F.Controls.Add(B1);

			Button B2 = new Button();
			B2.Text = "Вторая кнопка";
			B2.Size = new Size(150, 30);
			B2.Top = 20;
			B2.Left = 190;
			F.Controls.Add(B2);
			B2.Click += B2_Click;
			F.ShowDialog();
		}

		private static void B2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("1");
			Button B = (Button)sender;
			B.Text = "1";
		}

		private static void B1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("2");
			Button B = (Button)sender;
			B.Text = "2";
		}
	}
}
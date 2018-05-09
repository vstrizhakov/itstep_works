using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox_
{
	public partial class Form1 : Form
	{
		private int EditIndex;
		public Form1()
		{
			InitializeComponent();

			for (int i = 0; i < 100; i++)
			{
				this.listBox1.Items.Add(new Product("Snickers " + i, 12.5 + i, 45 + i % 10));
			}
			this.listBox1.SelectedIndex = 0;
		}

		class Product
		{
			public String Name { get; set; }
			public double Price { get; set; }
			public int Weight { get; set; }

			public Product(String name, double price, int weight)
			{
				this.Name = name;
				this.Price = price;
				this.Weight = weight;
			}

			public override string ToString()
			{
				return String.Format("{0}, {1}$, {2}g", this.Name, this.Price, this.Weight);
			}
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.tableLayoutPanel3.Visible = true;
			this.EditIndex = -1;
			this.button4.Visible = true;
			this.name.Text = "";
			this.price.Text = "";
			this.weight.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.tableLayoutPanel3.Visible = true;
			this.button4.Visible = true;
			this.EditIndex = this.listBox1.SelectedIndex;

			this.name.Text = ((Product)this.listBox1.Items[this.EditIndex]).Name;
			this.price.Text = ((Product)this.listBox1.Items[this.EditIndex]).Price.ToString();
			this.weight.Text = ((Product)this.listBox1.Items[this.EditIndex]).Weight.ToString();

		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.tableLayoutPanel3.Visible = false;
			this.button4.Visible = false;
			if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Вы уверены?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);

		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (this.name.Text.Trim(new char[] { ' ' }) != "" && this.price.Text.Trim(new char[] { ' ' }) != "" && this.weight.Text.Trim(new char[] { ' ' }) != "")
			{
				double Tprice = 0;
				int Tweight = 0;
				try
				{
					this.price.Text = this.price.Text.Replace('.', ',');
					Tprice = Double.Parse(this.price.Text);
					Tweight = Int32.Parse(this.weight.Text);
				}
				catch (Exception a)
				{
					MessageBox.Show(String.Format("Ошибка: {0}", a.Message));
					return;
				}
				if (this.EditIndex == -1)
					this.listBox1.Items.Add(new Product(name.Text, Tprice, Tweight));
				else
				{
					this.listBox1.Items.RemoveAt(this.EditIndex);
					this.listBox1.Items.Insert(this.EditIndex, new Product(name.Text, Tprice, Tweight));
				}
				this.tableLayoutPanel3.Visible = false;
				this.button4.Visible = false;				
				if (this.EditIndex == -1)
					this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
				else
					this.listBox1.SelectedIndex = this.EditIndex;

			}
			else
				MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK);
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedIndex == -1)
			{
				this.button2.Enabled = false;
				this.button3.Enabled = false;
			}
			else
			{
				this.button2.Enabled = true;
				this.button3.Enabled = true;
			}
		}
	}
}

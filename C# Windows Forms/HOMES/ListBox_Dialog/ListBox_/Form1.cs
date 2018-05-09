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
			this.EditIndex = -1;
			ProductForm PF = new ProductForm();
			if (PF.ShowDialog() == DialogResult.OK)
			{
				PF.price.Text = PF.price.Text.Replace(".", ",");
				this.listBox1.Items.Add(new Product(PF.name.Text, Double.Parse(PF.price.Text), Int32.Parse(PF.weight.Text)));
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.EditIndex = this.listBox1.SelectedIndex;
			ProductForm PF = new ProductForm();
			PF.name.Text = ((Product)this.listBox1.Items[EditIndex]).Name;
			PF.price.Text = ((Product)this.listBox1.Items[EditIndex]).Price.ToString();
			PF.weight.Text = ((Product)this.listBox1.Items[EditIndex]).Weight.ToString();
			if (PF.ShowDialog() == DialogResult.OK)
			{
				PF.price.Text = PF.price.Text.Replace(".", ",");
				this.listBox1.Items[EditIndex] = new Product(PF.name.Text, Double.Parse(PF.price.Text), Int32.Parse(PF.weight.Text));
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Вы уверены?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
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

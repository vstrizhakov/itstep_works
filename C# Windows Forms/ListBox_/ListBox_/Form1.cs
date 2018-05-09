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
		public Form1()
		{
			InitializeComponent();
			TableLayoutPanel TLP = new TableLayoutPanel();
			TLP.ColumnCount = 1;
			TLP.RowCount = 3;
			TLP.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
			TLP.Size = this.ClientSize;
			TLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

			RowStyle RS1 = new RowStyle(SizeType.Absolute, 30);
			TLP.RowStyles.Add(RS1);
			RowStyle RS2 = new RowStyle(SizeType.Percent, 100);
			TLP.RowStyles.Add(RS2);
			RowStyle RS3 = new RowStyle(SizeType.Absolute, 40);
			TLP.RowStyles.Add(RS3);

			this.Controls.Add(TLP);

			Label L = new Label();
			L.Text = "Список";
			L.Anchor = AnchorStyles.Top | AnchorStyles.Left;
			TLP.Controls.Add(L);

			ListBox LB = new ListBox();
			LB.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			LB.ColumnWidth = 150;
			LB.MultiColumn = true;
			LB.SelectionMode = SelectionMode.MultiExtended;
			TLP.Controls.Add(LB);

			for (int i = 0; i < 100; i++)
			{
				LB.Items.Add(new Product("Snickers " + i, 12.5 + i, 45 + i % 10));
			}

			FlowLayoutPanel FLP = new FlowLayoutPanel();
			FLP.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TLP.Controls.Add(FLP);

			Button btnDel = new Button();
			btnDel.Text = "Delete";
			FLP.Controls.Add(btnDel);

			Button btnAdd = new Button();
			btnAdd.Text = "Add";
			FLP.Controls.Add(btnAdd);

			Button btnEdit = new Button();
			btnEdit.Text = "Edit";
			FLP.Controls.Add(btnEdit);
		}

		class Product
		{
			public String Name { get; set; }
			public double Price { get; set; }
			public int Weight { get; set; }

			public Product (String name, double price, int weight)
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
	}
}

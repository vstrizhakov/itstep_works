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
using System.Collections;

namespace Films
{
	public partial class Form1 : Form
	{
		static public bool Order { set; get; }
		private List<Film> Films = new List<Film>();

		public Form1()
		{
			Films.Add(new Film("Побег из Шоушенка", "драма", 1994, 173));
			Films.Add(new Film("Властелин колец 3: Возвращение Короля", "комедия", 2003, 137));
			Films.Add(new Film("Форрест Гамп", "военный", 2002, 178));
			Films.Add(new Film("Терминатор 2: Судный день", "приключения", 2002, 194));
			Films.Add(new Film("Властелин колец 2: Две крепости", "фантастика", 1991, 162));
			Films.Add(new Film("Властелин колец: Братство кольца", "мелодрама", 1993, 88));
			Films.Add(new Film("Список Шиндлера", "биографический", 1953, 133));
			Films.Add(new Film("Римские каникулы", "криминал", 1997, 152));

			InitializeComponent();

			this.listView1.SmallImageList = this.imageList1;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.GridLines = true;
			this.listView1.FullRowSelect = true;
			this.ViewType.Text = this.ViewType.Items[0].ToString();
			this.listView1.View = (View)this.ViewType.SelectedIndex;
			Random R = new Random();
			for (int i = 0; i < 8; i++)
			{
				ListViewItem LVI = new ListViewItem(Films[i].Name, Films[i].Ico);
				LVI.SubItems.Add(Films[i].Genre);
				LVI.SubItems.Add(Films[i].Duration.ToString());
				LVI.SubItems.Add(Films[i].Premier.ToString());
				this.listView1.Items.Add(LVI);
			}
			ColumnHeader CH = new ColumnHeader();
			CH.Text = "Название";
			CH.Width = 300;
			CH.TextAlign = HorizontalAlignment.Center;
			this.listView1.Columns.Add(CH);
			CH = new ColumnHeader();
			CH.Text = "Жанр";
			CH.Width = 100;
			CH.TextAlign = HorizontalAlignment.Center;
			this.listView1.Columns.Add(CH);
			CH = new ColumnHeader();
			CH.Text = "Премьера";
			CH.Width = 100;
			CH.TextAlign = HorizontalAlignment.Center;
			this.listView1.Columns.Add(CH);
			CH = new ColumnHeader();
			CH.Text = "Длительность";
			CH.Width = 100;
			CH.TextAlign = HorizontalAlignment.Center;
			this.listView1.Columns.Add(CH);
			this.listView1.ColumnClick += ListView1_ColumnClick;

		}

		private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			this.listView1.ListViewItemSorter = new FilmCompare(e.Column);
			Form1.Order = !Form1.Order;

		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void ViewType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.listView1.View = (View)this.ViewType.SelectedIndex;
		}
	}

	class Film
	{
		public String Name { set; get; }
		public String Genre { set; get; }
		public int Duration { set; get; }
		public int Premier { set; get; }
		public int Ico { set; get; }
		public Film(String name, String genre, int duration, int premier)
		{
			this.Name = name;
			this.Genre = genre;
			this.Duration = duration;
			this.Premier = premier;
			switch(this.Genre)
			{
				case "драма":
					this.Ico = 5;
					break;
				case "комедия":
					this.Ico = 5;
					break;
				case "военный":
					this.Ico = 1;
					break;
				case "биографический":
					this.Ico = 3;
					break;
				case "приключения":
					this.Ico = 4;
					break;
				case "фантастика":
					this.Ico = 0;
					break;
				case "мелодрама":
					this.Ico = 5;
					break;
			}
		}
	}

	class FilmCompare : IComparer
	{
		private int column = 0;
		public FilmCompare(int column)
		{
			this.column = column;
		}

		public int Compare(object x, object y)
		{
			if (column < 2)
			{
				if (Form1.Order)
					return String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
				else
					return String.Compare(((ListViewItem)y).SubItems[column].Text, ((ListViewItem)x).SubItems[column].Text);
			}
			else
			{
				if (Form1.Order)
					return Int32.Parse(((ListViewItem)x).SubItems[column].Text) - Int32.Parse(((ListViewItem)y).SubItems[column].Text);
				else
					return Int32.Parse(((ListViewItem)y).SubItems[column].Text) - Int32.Parse(((ListViewItem)x).SubItems[column].Text);
			}
		}	
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Explorere
{
	public partial class Form1 : Form
	{
		private int viewId = 0;
		public Form1()
		{
			InitializeComponent();
			this.catalog.View = View.Details;
			ColumnHeader CH = new ColumnHeader();
			CH.Text = "Имя";
			CH.Width = 150;
			this.catalog.Columns.Add(CH);
			CH = new ColumnHeader();
			CH.Text = "Дата создания";
			CH.Width = 150;
			this.catalog.Columns.Add(CH);
		}

		private void GoSearch(object sender, EventArgs e)
		{
			String[] folders = new String[0];
			String[] files = new String[0];
			try
			{
				folders = Directory.GetDirectories(this.path.Text);
				files = Directory.GetFiles(this.path.Text);
			}
			catch
			{
				MessageBox.Show("Невозможно отобразить данные из указанного каталога. Скорее всего Вы ввели неправильный путь.");
			}
			List<FileInfo> all = new List<FileInfo>();
			foreach (String f in folders)
				all.Add(new FileInfo(f));
			foreach (String f in files)
				all.Add(new FileInfo(f));
			this.catalog.Items.Clear();
			Image fold = this.imageList1.Images[0];
			this.imageList1.Images.Clear();
			this.imageList1.Images.Add(fold);
			int i = 1;
			Dictionary<String, int> types = new Dictionary<String, int>();
			foreach (FileInfo file in all)
			{
				ListViewItem LVI = new ListViewItem(file.Name);
				try
				{
					String[] type = file.Name.Split(new char[] { '.' }, StringSplitOptions.None);
					if (types.ContainsKey(type[type.Length - 1]) == false)
					{
						this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
						types.Add(type[type.Length - 1], i++);

					}
					if (type[type.Length - 1] == "exe")
					{
						this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
						LVI.ImageIndex = i++;
					}
					else
						LVI.ImageIndex = types[type[type.Length - 1]];

				}
				catch
				{
					LVI.ImageIndex = 0;
				}
				LVI.SubItems.Add(file.CreationTime.ToString());
				this.catalog.Items.Add(LVI);
			}
			this.catalog.SmallImageList = this.imageList1;
			this.catalog.LargeImageList = this.imageList1;
		}

		private void panel1_Click(object sender, EventArgs e)
		{
			viewId++;
			if (viewId > 4)
				viewId = 0;
			if (viewId == 0)
				this.catalog.View = View.Details;
			if (viewId == 1)
				this.catalog.View = View.LargeIcon;
			if (viewId == 2)
				this.catalog.View = View.SmallIcon;
			if (viewId == 3)
				this.catalog.View = View.List;
			if (viewId == 4)
				this.catalog.View = View.Tile;
		}
	}
}

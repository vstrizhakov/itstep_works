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
using System.Diagnostics;
using System.Threading;
using System.Resources;
using System.Collections;
using System.Security.AccessControl;

namespace Explorere
{
	public partial class Main : Form
	{
		static public bool Order { set; get; }
		private List<String> prevs = new List<String>();
		private List<String> next = new List<String>();
		private int viewId = 0;
		private String prevPath;
		private object buf;
		private bool readHidden = false;
		/// <summary>
		/// true - вырезать, false - скопировать
		/// </summary>
		private Dictionary<String, bool> toPasteBuf = new Dictionary<string, bool>();
		public Dictionary<String, bool> ToPasteBuf
		{
			get
			{
				return this.toPasteBuf;
			}
		}
		public object Buf
		{
			get
			{
				return this.buf;
			}
		}
		private String validatedPath;
		public String ValidatedPath
		{
			get
			{
				return this.validatedPath;
			}
		}
		public Main()
		{
			InitializeComponent();
			this.Font = new Font("Adobe Arabic", 8, FontStyle.Regular);
			// Дерево
			this.tree.ImageList = this.imageList1;
			this.tree.ContextMenuStrip = this.contextMenuStrip1;
			this.tree.BeforeExpand += Tree_BeforeExpand;
			this.tree.DoubleClick += Tree_DoubleClick;
			// Создание столбцов
			ColumnHeader CH = new ColumnHeader();
			CH.Text = "Имя";
			CH.Width = 150;
			this.catalog.Columns.Add(CH);
			CH = new ColumnHeader();
			CH.Text = "Дата создания";
			CH.Width = 120;
			this.catalog.Columns.Add(CH);
			CH = new ColumnHeader();
			CH.Text = "Тип файла";
			CH.Width = 70;
			CH.TextAlign = HorizontalAlignment.Center;
			this.catalog.Columns.Add(CH);
			//CH = new ColumnHeader();
			//CH.Text = "Размер";
			//CH.Width = 70;
			//CH.TextAlign = HorizontalAlignment.Center;
			//this.catalog.Columns.Add(CH);
			// Лист
			this.catalog.View = View.Details;
			this.catalog.FullRowSelect = true;
			this.catalog.ContextMenuStrip = this.contextMenuStrip1;
			this.catalog.DoubleClick += Catalog_DoubleClick;
			// Появление контекстного меню
			this.contextMenuStrip1.Opened += ContextPopup;
			// Инициализация дерева
			String[] drives = Directory.GetLogicalDrives();
			foreach (String drive in drives)
			{
				TreeNode tmp = new TreeNode(drive, 0, 1);
				this.tree.Nodes.Add(tmp);
				this.fillTree(tmp, drive);
			}
			// Инициализация листа
			this.Open(drives[0]);
			this.catalog.ColumnClick += Catalog_ColumnClick;

			this.prevPath = drives[0];
			this.validatedPath = prevPath;
		}

		private void Catalog_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			this.catalog.ListViewItemSorter = new FileCompare(e.Column);
			Main.Order = !Main.Order;
		}

		private void ContextPopup(object sender, EventArgs e)
		{
			switch (((ContextMenuStrip)sender).SourceControl.Name)
			{
				case "catalog":
					{
						if (this.catalog.SelectedItems.Count != 0)
						{
							this.copy.Visible = true;
							this.cut.Visible = true;
							this.rename.Visible = true;
							this.delete.Visible = true;
							this.buf = (object)this.catalog.SelectedItems;
						}
						else
						{
							this.copy.Visible = false;
							this.cut.Visible = false;
							this.rename.Visible = false;
							this.delete.Visible = false;
							this.buf = validatedPath;
						}
						this.createFolder.Visible = (this.catalog.SelectedItems.Count == 0 || (this.catalog.SelectedItems.Count == 1 && this.catalog.SelectedItems[0].SubItems[2].Text == "")) ? true : false;
						this.paste.Visible = (this.toPasteBuf.Count != 0 && ((this.catalog.SelectedItems.Count == 1 && this.catalog.SelectedItems[0].SubItems[2].Text == "") || this.catalog.SelectedItems.Count == 0)) ? true : false;
					}
					break;
				case "tree":
					{
						Point NodePoint = this.tree.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
						TreeNode TN = tree.GetNodeAt(NodePoint.X, NodePoint.Y);
						if (TN != null && TN.Parent != null)
						{
							this.copy.Visible = true;
							this.cut.Visible = true;
							this.rename.Visible = true;
							this.delete.Visible = true;
							this.buf = TN.FullPath;
						}
						else
						{
							this.copy.Visible = false;
							this.cut.Visible = false;
							this.rename.Visible = false;
							this.delete.Visible = false;
							this.buf = (TN != null && TN.Parent == null) ? TN.FullPath : validatedPath;
						}
						if (TN != null)
							this.createFolder.Visible = true;
						else
							this.createFolder.Visible = false;
						this.paste.Visible = (this.toPasteBuf.Count == 0) ? false : true;
					}
					break;
			}
		}

		private void Tree_DoubleClick(object sender, EventArgs e)
		{
			if (this.tree.SelectedNode == null)
				return;
			String path = this.tree.SelectedNode.FullPath;
			if (Directory.Exists(path))
			{
				try
				{
					this.Open(path);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message, "Ошибка");
					return;
				}
				if ((this.prevs.Count == 0 || this.prevs.Last() != this.prevPath) && this.prevPath != this.validatedPath)
				{
					this.up.Enabled = true;
					this.up.BackgroundImage = Resource1.back;
					this.down.Enabled = false;
					this.down.BackgroundImage = Resource1.back___копия2;
					this.prevs.Add(this.prevPath);
					this.next.Clear();
				}
				this.prevPath = path;
			}
		}

		private void Tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			node.Nodes.Clear();
			this.fillTree(node, node.FullPath);
		}

		public void fillTree(TreeNode node, String path)
		{
			try
			{
				String[] dirs = Directory.GetDirectories(path);
				foreach (String dir in dirs)
				{
					if (this.readHidden == false && ((new DirectoryInfo(dir)).Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
						continue;
					TreeNode TN = new TreeNode(Path.GetFileName(dir), 0, 1);
					node.Nodes.Add(TN);
					try
					{
						String[] subDirs = Directory.GetDirectories(dir);
						if (subDirs.Length > 0)
						{
							TreeNode tn = new TreeNode("?", 0, 1);
							TN.Nodes.Add(tn);
						}
					}
					catch { }
				}
			}
			catch { }
		}

		private void Catalog_DoubleClick(object sender, EventArgs e)
		{
			String path = Path.Combine(validatedPath, this.catalog.SelectedItems[0].Text);
			if (!Directory.Exists(path) && File.Exists(path))
			{
				try
				{
					Process.Start(path);
				}
				catch (Win32Exception a)
				{
					MessageBox.Show(a.Message, "Ошибка");
					return;
				}
			}
			else
			{
				try
				{
					this.Open(path);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message, "Ошибка");
					return;
				}
				if ((this.prevs.Count == 0 || this.prevs.Last() != this.prevPath) && this.prevPath != this.validatedPath)
				{
					this.up.Enabled = true;
					this.up.BackgroundImage = Resource1.back;
					this.down.Enabled = false;
					this.down.BackgroundImage = Resource1.back___копия2;
					this.prevs.Add(this.prevPath);
					this.next.Clear();
				}
				this.prevPath = path;
			}
		}

		private void ChangeView(object sender, EventArgs e)
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

		public void Open(String path)
		{
			if (!path.Contains("\\") && !path.Contains("/"))
				path += "\\";
			String[] folders = new String[0];
			String[] files = new String[0];
			try
			{
				folders = Directory.GetDirectories(path);
				files = Directory.GetFiles(path);
			}
			catch (Exception e)
			{
				this.path.Text = validatedPath;
				throw new Exception(e.Message);
			}
			List<FileInfo> all = new List<FileInfo>();
			foreach (String f in folders)
				all.Add(new FileInfo(f));
			foreach (String f in files)
				all.Add(new FileInfo(f));
			this.catalog.Items.Clear();
			Image fold = this.imageList1.Images[0];
			Image foldOpened = this.imageList1.Images[1];
			this.imageList1.Images.Clear();
			this.imageList1.Images.Add(fold);
			this.imageList1.Images.Add(foldOpened);
			int i = 2;
			Dictionary<String, int> types = new Dictionary<String, int>();
			foreach (FileInfo file in all)
			{
				if (this.readHidden == false && (file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
					continue;
				ListViewItem LVI = new ListViewItem(file.Name);
				String type = file.Extension;
				try
				{
					if (types.ContainsKey(type) == false)
					{
						this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
						types.Add(type, i++);

					}
					if (type == ".exe")
					{
						this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(file.FullName));
						LVI.ImageIndex = i++;
					}
					else
						LVI.ImageIndex = types[type];

				}
				catch
				{
					LVI.ImageIndex = 0;
				}
				LVI.SubItems.Add(file.CreationTime.ToString());
				if (File.Exists(file.FullName))
				{
					LVI.SubItems.Add(type.Replace(".", "").ToUpper());
					//LVI.SubItems.Add(file.Length.ToString() + "");
				}
				else
				{
					LVI.SubItems.Add("");
					//LVI.SubItems.Add("");
				}
				this.catalog.Items.Add(LVI);
			}
			this.catalog.SmallImageList = this.imageList1;
			this.catalog.LargeImageList = this.imageList1;
			this.path.Text = path.Replace(@"\\", @"\").Replace(@"//", @"\").Replace("/", "\\");
			this.validatedPath = this.path.Text;
		}

		private void path_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;
				try
				{
					this.Open(this.path.Text);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message, "Ошибка");
					return;
				}
			}
		}

		private void UpOrDown(object sender, EventArgs e)
		{
			if (sender is Panel)
			{
				String tmp = ((Panel)sender).Tag.ToString();
				if (tmp == "up" && this.prevs.Count > 0)
				{
					String path = this.prevs[this.prevs.Count - 1];
					try
					{
						this.Open(path);
					}
					catch (Exception a)
					{
						this.prevs.RemoveAt(this.prevs.Count - 1);
						if (this.prevs.Count == 0)
						{
							this.up.Enabled = false;
							this.up.BackgroundImage = Resource1.back2;
						}
						MessageBox.Show(a.Message, "Ошибка");
						return;
					}
					if (this.next.Count == 0 || this.next.Last() != this.prevPath)
						this.next.Add(this.prevPath);
					this.prevPath = path;
					this.prevs.RemoveAt(this.prevs.Count - 1);
					if (this.prevs.Count == 0)
					{
						this.up.Enabled = false;
						this.up.BackgroundImage = Resource1.back2;
					}
					this.down.Enabled = true;
					this.down.BackgroundImage = Resource1.back___копия;
				}
				if (tmp == "down" && this.next.Count > 0)
				{
					String path = this.next[this.next.Count - 1];
					try
					{
						this.Open(path);
					}
					catch (Exception a)
					{
						this.next.RemoveAt(this.next.Count - 1);
						if (this.next.Count == 0)
						{
							this.down.Enabled = false;
							this.down.BackgroundImage = Resource1.back___копия2;
						}
						MessageBox.Show(a.Message, "Ошибка");
						return;
					}
					if (this.prevs.Count == 0 || this.prevs.Last() != this.prevPath)
					{
						this.prevs.Add(this.prevPath);
						this.up.Enabled = true;
						this.up.BackgroundImage = Resource1.back;
					}
					this.prevPath = path;
					this.next.RemoveAt(this.next.Count - 1);
					if (this.next.Count == 0)
					{
						this.down.Enabled = false;
						this.down.BackgroundImage = Resource1.back___копия2;
					}
				}
			}
		}

		private void createFolder_Click(object sender, EventArgs e)
		{
			AskNameForm ANF = new AskNameForm();
			ANF.StartPosition = FormStartPosition.CenterParent;
			if (ANF.ShowDialog() == DialogResult.OK)
			{
				String name = ANF.InputName;
				String pth = (this.buf is ListView.SelectedListViewItemCollection) ? Path.Combine(this.validatedPath, ((ListView.SelectedListViewItemCollection)this.buf)[0].Text) : ((String)this.buf);
				if (File.Exists(pth))
					pth = Path.GetDirectoryName(pth);
				if (!Directory.Exists(Path.Combine(pth, name)) && !File.Exists(Path.Combine(pth, name)))
					Directory.CreateDirectory(Path.Combine(pth, name));
				else
				{
					MessageBox.Show("Такая папка уже существует", "Ошибка");
					return;
				}
				try
				{
					this.Open(pth);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message, "Ошибка");
					return;
				}
				TreeNode TN = this.FindNode(pth, this.tree.Nodes);
				List<String> ExpandedNodes = new List<String>();
				if (TN != null)
				{
					if (TN.IsExpanded)
						ExpandedNodes = this.CheckExpandedNodes(TN);
					TN.Nodes.Clear();
				}
				this.fillTree(TN, pth);
				this.ExpandNodes(ExpandedNodes);
			}
		}

		public void ExpandNodes(List<String> ExpandedNodes)
		{
			foreach (String NodePath in ExpandedNodes)
			{
				TreeNode tmp = this.FindNode(NodePath.Replace(@"\\", @"\"), this.tree.Nodes);
				if (tmp != null)
					tmp.Expand();
			}
		}

		private void delete_Click(object sender, EventArgs e)
		{
			String[] pths = new String[1];
			if (this.buf is ListView.SelectedListViewItemCollection)
			{
				int i = 0;
				pths = new String[((ListView.SelectedListViewItemCollection)this.buf).Count];
				foreach (ListViewItem lvi in ((ListView.SelectedListViewItemCollection)this.buf))
					pths[i++] = Path.Combine(validatedPath, lvi.Text);
			}
			else
				pths[0] = ((String)this.buf);
			int amount = 0;
			foreach (String p in pths)
				if (Directory.Exists(p))
					amount += this.GetAmountOfPaths(p);
				else
					amount++;
			if (amount == 0)
				return;
			Proccessing PB = new Proccessing(this, amount, "delete", this.validatedPath, this.buf, pths);
			PB.Show();
		}

		public List<String> CheckExpandedNodes(TreeNode TN)
		{
			List<String> pths = new List<String>();
			foreach (TreeNode tmp in TN.Nodes)
			{
				if (tmp.IsExpanded)
				{
					pths.Add(tmp.FullPath);
					pths.AddRange(CheckExpandedNodes(tmp));
				}
			}
			return pths;
		}

		public TreeNode FindNode(String fullPath, TreeNodeCollection nodes)
		{
			foreach (TreeNode tmp in nodes)
			{
				if (tmp.FullPath.Replace(@"\\", @"\") == fullPath)
					return tmp;
				TreeNode TN = this.FindNode(fullPath, tmp.Nodes);
				if (TN != null)
					return TN;
			}
			return null;
		}

		public TreeView Tree
		{
			get
			{
				return this.tree;
			}
		}

		private void rename_Click(object sender, EventArgs e)
		{
			String pth = (this.buf is ListView.SelectedListViewItemCollection) ? Path.Combine(validatedPath, ((ListView.SelectedListViewItemCollection)this.buf)[0].Text) : ((String)this.buf);
			AskNameForm ANF = new AskNameForm(pth);
			ANF.StartPosition = FormStartPosition.CenterParent;
			if (ANF.ShowDialog() == DialogResult.OK)
			{
				String name = ANF.InputName;
				String dir = Path.GetDirectoryName(pth);
				if (!Directory.Exists(Path.Combine(dir, name)))
				{
					try
					{
						Directory.Move(pth, Path.Combine(dir, name));
					}
					catch (Exception a)
					{
						MessageBox.Show(a.Message);
						return;
					}
				}
				else
				{
					MessageBox.Show("Такая папка уже существует", "Ошибка");
					return;
				}
				try
				{
					this.Open(dir);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
					return;
				}
				TreeNode TN = this.FindNode(dir, this.tree.Nodes);
				List<String> ExpandedNodes = new List<String>();
				if (TN != null)
				{
					if (TN.IsExpanded)
						ExpandedNodes = this.CheckExpandedNodes(TN);
					TN.Nodes.Clear();
				}
				this.fillTree(TN, dir);
				this.ExpandNodes(ExpandedNodes);
			}
		}

		private void cut_Click(object sender, EventArgs e)
		{
			this.toPasteBuf.Clear();
			String[] pths = new String[1];
			if (this.buf is ListView.SelectedListViewItemCollection)
			{
				int i = 0;
				pths = new String[((ListView.SelectedListViewItemCollection)this.buf).Count];
				foreach (ListViewItem lvi in ((ListView.SelectedListViewItemCollection)this.buf))
					pths[i++] = Path.Combine(validatedPath, lvi.Text);
			}
			else
				pths[0] = ((String)this.buf);
			foreach (String p in pths)
				this.toPasteBuf.Add(p, true);
		}

		private void copy_Click(object sender, EventArgs e)
		{
			this.toPasteBuf.Clear();
			String[] pths = new String[1];
			if (this.buf is ListView.SelectedListViewItemCollection)
			{
				int i = 0;
				pths = new String[((ListView.SelectedListViewItemCollection)this.buf).Count];
				foreach (ListViewItem lvi in ((ListView.SelectedListViewItemCollection)this.buf))
					pths[i++] = Path.Combine(validatedPath, lvi.Text);
			}
			else
				pths[0] = ((String)this.buf);
			foreach (String p in pths)
				this.toPasteBuf.Add(p, false);
		}

		private void paste_Click(object sender, EventArgs e)
		{
			int amount = 0;
			ICollection<String> pths = this.ToPasteBuf.Keys;
			foreach (String p in pths)
				if (Directory.Exists(p))
					amount += this.GetAmountOfPaths(p);
				else
					amount++;
			Proccessing PB = new Proccessing(this, amount, "paste", this.validatedPath, this.buf);
			PB.Show();
		}

		private void toolStripStatusLabel2_Click(object sender, EventArgs e)
		{
			this.readHidden = !this.readHidden;
			if (this.readHidden)
				this.toolStripStatusLabel2.Text = "Не показывать скрытые";
			else
				this.toolStripStatusLabel2.Text = "Показывать скрытые";
			try
			{
				this.Open(this.validatedPath);
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message);
				return;
			}
			foreach (TreeNode TN in this.tree.Nodes)
			{
				if (TN.IsExpanded)
				{
					TN.Nodes.Clear();
					this.fillTree(TN, TN.FullPath);
				}
			}
		}

		public int GetAmountOfPaths(String dir)
		{
			int amount = 1;
			String[] dirs = new String[0], files = new String[0];
			try
			{
				dirs = Directory.GetDirectories(dir);
				files = Directory.GetFiles(dir);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
				return 0;
			}
			foreach (String d in dirs)
			{
				int i = this.GetAmountOfPaths(d);
				if (i == 0)
					return 0;
				amount += i;
			}
			amount += files.Length;
			return amount;
		}

		private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				this.tree.SelectedNode = this.tree.GetNodeAt(e.Location);
		}

		private void catalog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.A && e.Control)
			{
				foreach (ListViewItem LVI in this.catalog.Items)
					LVI.Selected = true;
			}
		}

		private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				this.Open(this.validatedPath);
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message, "Ошибка");
				return;
			}
			TreeNode TN = this.FindNode(this.validatedPath, this.Tree.Nodes);
			List<String> ExpandedNodes = new List<String>();
			if (TN != null)
			{
				if (TN.IsExpanded)
					ExpandedNodes = this.CheckExpandedNodes(TN);
				TN.Nodes.Clear();
			}
			this.fillTree(TN, this.validatedPath);
			this.ExpandNodes(ExpandedNodes);
		}
	}

	class FileCompare : IComparer
	{
		private int column = 0;
		public FileCompare(int column)
		{
			this.column = column;
		}

		public int Compare(object x, object y)
		{
			if (this.column == 0 || this.column == 2)
			{
				if (Main.Order)
					return String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
				else
					return String.Compare(((ListViewItem)y).SubItems[column].Text, ((ListViewItem)x).SubItems[column].Text);
			}
			else if (this.column == 1)
			{
				if (Main.Order)
					return DateTime.Compare(DateTime.Parse(((ListViewItem)x).SubItems[column].Text), DateTime.Parse(((ListViewItem)y).SubItems[column].Text));
				else
					return DateTime.Compare(DateTime.Parse(((ListViewItem)y).SubItems[column].Text), DateTime.Parse(((ListViewItem)x).SubItems[column].Text));
			}
			else if (this.column == 3)
			{
				int x1 = Int32.Parse(((ListViewItem)x).SubItems[column].Text);
				int y1 = Int32.Parse(((ListViewItem)x).SubItems[column].Text);
				if (Main.Order)
					return x1 - y1;
				else
					return y1 - x1;
			}
			else
				return 0;
		}
	}
}
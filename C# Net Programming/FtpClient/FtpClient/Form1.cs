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
using System.Threading;
using System.Diagnostics;

namespace FtpClient
{
	public partial class Form1 : Form
	{
		private Dictionary<String, TabPage> HostToPage = new Dictionary<String, TabPage>();
		private Dictionary<TabPage, FtpController> PageToFtp = new Dictionary<TabPage, FtpController>();
		private Dictionary<String, FtpController> HostToFtp = new Dictionary<String, FtpController>();
		private Dictionary<String, int> types = new Dictionary<String, int>();
		private bool ComboBoxChangedByUser = true;
		private String CurrentPath;
		public Form1()
		{
			InitializeComponent();
			ColumnHeader CH = new ColumnHeader();
			CH.Text = "Название";
			CH.Width = (int)(this.localList.ClientSize.Width * 0.4);
			this.localList.Columns.Add(CH);
			this.remoteList.Columns.Add((ColumnHeader)CH.Clone());
			CH = new ColumnHeader();
			CH.Text = "Дата последнего изменения";
			CH.Width = (int)(this.localList.ClientSize.Width * 0.3);
			this.localList.Columns.Add(CH);
			this.remoteList.Columns.Add((ColumnHeader)CH.Clone());
			CH = new ColumnHeader();
			CH.Text = "Размер";
			CH.Width = (int)(this.localList.ClientSize.Width * 0.2);
			this.localList.Columns.Add(CH);
			this.remoteList.Columns.Add((ColumnHeader)CH.Clone());

			this.TabController.SelectedIndexChanged += TabController_SelectedIndexChanged;
			this.splitContainer2.SplitterMoved += SplitContainer2_SplitterMoved;
			this.remoteList.MouseDoubleClick += RemoteList_DoubleClick;
			this.remoteList.SelectedIndexChanged += RemoteList_SelectedIndexChanged;
			this.tableLayoutPanel9.Enabled = false;
			this.remoteList.SmallImageList = this.imageList1;
			this.localTree.ImageList = this.imageList2;
			this.localList.SmallImageList = this.imageList1;
			this.remoteList.ContextMenuStrip = this.remoteContextMenu;

			String[] drives = Directory.GetLogicalDrives();
			foreach (String drive in drives)
			{
				TreeNode tmp = new TreeNode(drive);
				tmp.ImageIndex = 0;
				this.localTree.Nodes.Add(tmp);
				try
				{
					if (Directory.GetDirectories(drive).Length > 0)
						tmp.Nodes.Add("");
				}
				catch { }
			}

			this.OpenDirectory("C:/");
		}

		private void RemoteList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.remoteList.SelectedItems.Count > 0)
			{
				this.скачатьССервераToolStripMenuItem.Enabled = true;
				this.удалитьToolStripMenuItem.Enabled = true;
				this.переименоватьToolStripMenuItem.Enabled = true;
			}
			else
			{
				this.скачатьССервераToolStripMenuItem.Enabled = false;
				this.удалитьToolStripMenuItem.Enabled = false;
				this.переименоватьToolStripMenuItem.Enabled = false;
			}
		}

		private void RemoteList_DoubleClick(object sender, MouseEventArgs e)
		{
			if (!(sender is ToolStripMenuItem) && e.Button != MouseButtons.Left)
				return;
			if (this.remoteList.SelectedItems.Count > 0)
			{
				if (this.remoteList.SelectedItems.Count > 1 || sender is ToolStripMenuItem)
				{
					foreach (ListViewItem LVI in this.remoteList.SelectedItems)
					{
						if (LVI.Text != "..")
						{
							try
							{
								this.Download(LVI);
							}
							catch (Exception a)
							{
								this.Log(a.Message, true);
							}
						}
						else
							LVI.Selected = false;
					}
				}
				else if (this.remoteList.SelectedItems.Count == 1)
				{
					ListViewItem LVI = this.remoteList.SelectedItems[0];
					if ((bool)LVI.Tag == true)
					{
						try
						{
							this.LoadRemoteDirectory(LVI.Text.Trim());
						}
						catch (Exception a)
						{
							this.Log(a.Message, true);
						}
					}
					else
					{
						try
						{
							this.Download(LVI);
						}
						catch (Exception a)
						{
							this.Log(a.Message, true);
						}
					}
				}
			}
		}

		private void Download(ListViewItem LVI)
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			if ((bool)LVI.Tag == false)
				FC.DownloadFile(LVI.Text, this.CurrentPath);
			else
				FC.DownloadDirectory(LVI.Text + "/", this.CurrentPath);
			this.OpenDirectory("*" + this.CurrentPath);
		}

		private void TabController_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.TabController.SelectedIndex >= 0)
			{
				TabPage TP = this.TabController.SelectedTab;
				this.TabTable.Size = TP.ClientSize;
				this.TabTable.Location = new Point(0, 0);
				this.TabTable.Parent = TP;
				if (this.ComboBoxChangedByUser == true)
					this.LoadRemoteDirectory();
			}
		}

		private void LoadRemoteDirectory(String itemPath = "/")
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			List<DirectoryItem> items = FC.GetListing(itemPath);
			if (!this.remoteComboBox.Items.Contains(FC.CurrentPath))
				this.remoteComboBox.Items.Add(FC.CurrentPath);
			this.ComboBoxChangedByUser = false;
			this.remoteComboBox.Text = FC.CurrentPath;
			this.ComboBoxChangedByUser = true;
			this.remoteList.Items.Clear();
			if (FC.CurrentPath != "/")
			{
				ListViewItem LVI = new ListViewItem("..");
				LVI.ImageIndex = 1;
				LVI.Tag = true;
				this.remoteList.Items.Add(LVI);
			}
			foreach (DirectoryItem item in items)
			{
				ListViewItem LVI = new ListViewItem(item.Name);
				if (item.IsDirectory == true)
					LVI.ImageIndex = 0;
				else
				{
					try
					{
						String[] type = item.Name.Split(new char[] { '.' }, StringSplitOptions.None);
						if (this.types.ContainsKey(type[type.Length - 1]) == false)
						{
							FileStream FS = new FileStream(Application.StartupPath + "/" + item.Name, FileMode.Create, FileAccess.Write);
							FS.Close();
							this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(item.Name));
							File.Delete(item.Name);
							this.types.Add(type[type.Length - 1], this.imageList1.Images.Count - 1);
						}
						if (type[type.Length - 1] == "exe")
						{
							this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(item.Name));
							LVI.ImageIndex = this.imageList1.Images.Count - 1;
						}
						else
							LVI.ImageIndex = this.types[type[type.Length - 1]];

					}
					catch { }
				}
				LVI.SubItems.Add(item.DateTime);
				LVI.SubItems.Add(item.Size.ToString());
				LVI.Tag = item.IsDirectory;
				if (item.IsDirectory == true)
					this.remoteList.Items.Insert((FC.CurrentPath == "/") ? 0 : 1, LVI);
				else
					this.remoteList.Items.Add(LVI);
			}
		}

		private void connect(object sender, EventArgs e)
		{
			FtpController FC;
			String host = this.host.Text + ":" + ((this.port.Text == "") ? "21" : this.port.Text);
			if (!this.HostToFtp.ContainsKey(host))
				FC = new FtpController(this.host.Text, this.port.Text, this.username.Text, this.password.Text, this.logger);
			else
			{
				FC = this.HostToFtp[host];
			}

			if (this.TabWrapper.Controls.Contains(this.TabTable))
			{
				this.TabWrapper.Controls.Remove(this.TabTable);
				this.TabWrapper.Controls.Add(this.TabController);
			}

			TabPage TP;
			if (!this.HostToFtp.ContainsKey(host))
			{
				TP = new TabPage();
				TP.BackColor = Color.White;
				TP.Text = host;
				this.HostToPage.Add(TP.Text, TP);
				this.HostToFtp.Add(TP.Text, FC);
				this.PageToFtp.Add(TP, FC);
				this.TabController.Controls.Add(TP);
				this.TabController.SelectedTab = TP;
			}
			else
				TP = this.HostToPage[host];

			try
			{
				this.LoadRemoteDirectory();
				this.ComboBoxChangedByUser = false;
				this.TabController_SelectedIndexChanged(null, null);
				this.ComboBoxChangedByUser = true;
				this.tableLayoutPanel9.Enabled = true;
				this.toolStripButton2.Enabled = true;
			}
			catch (Exception a)
			{
				this.Log(a.Message, true);
				this.HostToPage.Remove(TP.Text);
				this.HostToFtp.Remove(TP.Text);
				this.PageToFtp.Remove(TP);
				this.TabController.Controls.Remove(TP);
				if (this.TabWrapper.Controls.Contains(this.TabController) && this.TabController.TabPages.Count == 0)
				{
					this.TabWrapper.Controls.Add(this.TabTable);
					this.TabWrapper.Controls.Remove(this.TabController);
				}
				TP.Dispose();
			}
		}

		private void Log(String message, bool isError = false)
		{
			switch (isError)
			{
				case false:
					this.logger.AppendText("Статус: " + message);
					break;
				case true:
					this.logger.SelectionColor = Color.Red;
					this.logger.AppendText("Ошибка: " + message + "\r\n");
					this.logger.SelectionColor = Color.Black;
					break;
			}
			this.logger.ScrollToCaret();
		}

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			this.localList.Columns[0].Width = (int)(this.localList.ClientSize.Width * 0.4);
			this.localList.Columns[1].Width = (int)(this.localList.ClientSize.Width * 0.2);
			this.localList.Columns[2].Width = (int)(this.localList.ClientSize.Width * 0.3);

			this.remoteList.Columns[0].Width = (int)(this.localList.ClientSize.Width * 0.4);
			this.remoteList.Columns[1].Width = (int)(this.localList.ClientSize.Width * 0.2);
			this.remoteList.Columns[2].Width = (int)(this.localList.ClientSize.Width * 0.3);
		}

		private void host_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.connect(null, null);
		}

		private void SplitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
		{
			this.localList.Columns[0].Width = (int)(this.localList.ClientSize.Width * 0.4);
			this.localList.Columns[1].Width = (int)(this.localList.ClientSize.Width * 0.2);
			this.localList.Columns[2].Width = (int)(this.localList.ClientSize.Width * 0.3);

			this.remoteList.Columns[0].Width = (int)(this.localList.ClientSize.Width * 0.4);
			this.remoteList.Columns[1].Width = (int)(this.localList.ClientSize.Width * 0.2);
			this.remoteList.Columns[2].Width = (int)(this.localList.ClientSize.Width * 0.3);
		}

		private void remoteComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ComboBoxChangedByUser == true)
			{
				try
				{
					this.LoadRemoteDirectory("*" + this.remoteComboBox.Text);
				}
				catch (Exception a)
				{
					this.Log(a.Message, true);
				}
			}
		}

		private void remoteComboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				try
				{
					this.LoadRemoteDirectory("*" + this.remoteComboBox.Text);
				}
				catch (Exception a)
				{
					this.Log(a.Message, true);
				}
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			TabPage TP = this.TabController.SelectedTab;
			this.HostToPage.Remove(TP.Text);
			this.HostToFtp.Remove(TP.Text);
			this.PageToFtp.Remove(TP);
			this.TabController.Controls.Remove(TP);
			this.remoteList.Items.Clear();
			if (this.TabWrapper.Controls.Contains(this.TabController) && this.TabController.TabPages.Count == 0)
			{
				this.TabWrapper.Controls.Add(this.TabTable);
				this.TabWrapper.Controls.Remove(this.TabController);
				this.tableLayoutPanel9.Enabled = false;
				this.toolStripButton2.Enabled = false;
			}
			TP.Dispose();
		}

		private void localTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode TN = e.Node;
			String[] dirs = Directory.GetDirectories(TN.FullPath);
			TN.Nodes.Clear();
			foreach (String dir in dirs)
			{
				TreeNode tmp = new TreeNode(Path.GetFileName(dir), 1, 2);
				TN.Nodes.Add(tmp);
				try
				{
					if (Directory.GetDirectories(dir).Length > 0)
						tmp.Nodes.Add("");
				}
				catch { }
			}
		}

		private void localTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeNode TN = e.Node;
			this.OpenDirectory("*" + TN.FullPath);
		}

		private void localList_DoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;
			if (this.localList.SelectedItems.Count > 0)
			{
				int i = 0;
				foreach (ListViewItem LVI in this.localList.SelectedItems)
				{
					if (i++ == 0 && (bool)LVI.Tag == true)
						this.OpenDirectory(LVI.Text);
					else
						Process.Start(this.CurrentPath + LVI.Text);
				}
			}
		}

		private void OpenDirectory(String path)
		{
			String tmp = this.CurrentPath;
			if (path == "..")
			{
				String[] ss = this.CurrentPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
				this.CurrentPath = "";
				for (int j = 0; j < ss.Length - 1; j++)
					this.CurrentPath += ss[j] + "/";
			}
			else if (path[0] == '*')
				this.CurrentPath = path.Remove(0, 1).Replace(@"\", "/").Replace("//", "/");
			else
				this.CurrentPath += (path + "/").Replace(@"\", "/").Replace("//", "/");
			try
			{
				String[] dirs = Directory.GetDirectories(this.CurrentPath);
				String[] files = Directory.GetFiles(this.CurrentPath);
				this.ComboBoxChangedByUser = false;
				this.localComboBox.Text = this.CurrentPath;
				if (!this.localComboBox.Items.Contains(this.CurrentPath))
					this.localComboBox.Items.Add(this.CurrentPath);
				this.ComboBoxChangedByUser = true;
				this.localList.Items.Clear();
				if (this.CurrentPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Length != 1)
				{
					ListViewItem LVI = new ListViewItem("..");
					LVI.ImageIndex = 1;
					LVI.Tag = true;
					this.localList.Items.Add(LVI);
				}
				foreach (String dir in dirs)
				{
					DirectoryInfo DI = new DirectoryInfo(dir);
					ListViewItem LVI = new ListViewItem(DI.Name);
					LVI.SubItems.Add(DI.LastWriteTime.ToShortDateString());
					LVI.SubItems.Add("");
					LVI.Tag = true;
					LVI.ImageIndex = 0;
					this.localList.Items.Add(LVI);
				}
				foreach (String file in files)
				{
					FileInfo FI = new FileInfo(file);
					ListViewItem LVI = new ListViewItem(FI.Name);
					LVI.SubItems.Add(FI.LastWriteTime.ToShortDateString());
					LVI.Tag = false;
					String size;
					try
					{
						Double s = FI.Length;
						size = s.ToString() + " Б";
						if ((s / 1024 / 1024) >= 1024)
							size = String.Format("{0:0.00} ГБ", s / 1024 / 1024 / 1024);
						else if ((s / 1024) >= 1024)
							size = String.Format("{0:0.00} МБ", s / 1024 / 1024);
						else if (s >= 1024)
							size = String.Format("{0:0.00} КБ", s / 1024);
					}
					catch
					{
						size = FI.Length.ToString();
					}
					try
					{
						String[] type = file.Split(new char[] { '.' }, StringSplitOptions.None);
						if (this.types.ContainsKey(type[type.Length - 1]) == false)
						{
							this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(file));
							this.types.Add(type[type.Length - 1], this.imageList1.Images.Count - 1);
						}
						if (type[type.Length - 1] == "exe")
						{
							this.imageList1.Images.Add(Icon.ExtractAssociatedIcon(file));
							LVI.ImageIndex = this.imageList1.Images.Count - 1;
						}
						else
							LVI.ImageIndex = this.types[type[type.Length - 1]];

					}
					catch { }
					LVI.SubItems.Add(size);
					this.localList.Items.Add(LVI);
				}
			}
			catch (Exception e)
			{
				this.CurrentPath = tmp;
				MessageBox.Show(e.Message);
			}
		}

		private void localComboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				this.OpenDirectory(this.localComboBox.Text);
		}

		private void localComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ComboBoxChangedByUser == true)
			{
				this.OpenDirectory("*" + this.localComboBox.Text);
			}
		}

		private void скачатьССервераToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.RemoteList_DoubleClick(sender, null);
		}

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem LVI in this.remoteList.SelectedItems)
			{
				try
				{
					this.Delete(LVI);
				}
				catch (Exception a)
				{
					this.Log(a.Message, true);
				}
			}
		}

		private void Delete(ListViewItem LVI)
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			if ((bool)LVI.Tag == false)
				FC.DeleteFile(LVI.Text);
			else
				FC.DeleteDirectory(LVI.Text);
			this.LoadRemoteDirectory();
		}

		private void Rename(ListViewItem LVI, String newName)
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			FC.Rename(LVI.Text, newName);
			this.LoadRemoteDirectory();
		}

		private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.remoteList.SelectedItems.Count > 0)
			{
				ListViewItem LVI = this.remoteList.SelectedItems[0];
				RenameForm RF = new RenameForm();
				RF.textBox1.Text = Path.GetFileNameWithoutExtension(LVI.Text);
				if (RF.ShowDialog() == DialogResult.OK)
				{
					String newName = RF.textBox1.Text;
					if ((bool)LVI.Tag == false)
						newName += Path.GetExtension(LVI.Text);
					if (LVI.Text == newName)
					{
						this.LoadRemoteDirectory();
						return;
					}
					try
					{
						this.Rename(LVI, newName);
					}
					catch (Exception a)
					{
						this.Log(a.Message, true);
					}
				}
			}
		}

		private void создатьКаталогToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			RenameForm RF = new RenameForm();
			if (RF.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (this.remoteList.SelectedItems.Count > 0 && (bool)this.remoteList.SelectedItems[0].Tag == true)
					{
						FC.CreateDirectory(this.remoteList.SelectedItems[0].Text + "/" + RF.textBox1.Text);
						this.LoadRemoteDirectory(this.remoteList.SelectedItems[0].Text);
					}
					else
					{
						FC.CreateDirectory(RF.textBox1.Text);
						this.LoadRemoteDirectory();
					}
				}
				catch (Exception a)
				{
					this.Log(a.Message, true);
				}
			}
		}

		private void localList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.TabController.TabPages.Count > 0 && this.localList.SelectedItems.Count > 0)
				this.localList.ContextMenuStrip = this.localContextMenu;
			else
				this.localList.ContextMenuStrip = null;
		}

		private void UploadFile(String filename, String to)
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read);
			FC.UploadFile(FS, to);
			FS.Close();
		}

		private void UploadDirectory(String dirname)
		{
			FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
			String remoteDirname = dirname.Remove(0, this.CurrentPath.Length);
			try
			{
				FC.CreateDirectory(remoteDirname);
			}
			catch { }
			String[] dirs = Directory.GetDirectories(dirname + "/");
			foreach (String dir in dirs)
			{
				FC.CreateDirectory(dir.Remove(0, this.CurrentPath.Length));
				this.UploadDirectory(dir);
			}
			String[] files = Directory.GetFiles(dirname);
			foreach (String file in files)
				this.UploadFile(file, remoteDirname + "/" + Path.GetFileName(file));
		}

		private void цукншщхйфриыбюфыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.TabController.TabPages.Count > 0 && this.PageToFtp.ContainsKey(this.TabController.SelectedTab) && this.localList.SelectedItems.Count > 0)
			{
				foreach (ListViewItem LVI in this.localList.SelectedItems)
				{
					if ((bool)LVI.Tag == true)
					{
						try
						{
							this.UploadDirectory(this.CurrentPath + LVI.Text);
						}
						catch (Exception a)
						{
							this.Log(a.Message, true);
						}
					}
					else
					{
						try
						{
							FtpController FC = this.PageToFtp[this.TabController.SelectedTab];
							this.UploadFile(this.CurrentPath + LVI.Text, FC.CurrentPath + LVI.Text);
						}
						catch (Exception a)
						{
							this.Log(a.Message, true);
						}
					}
				}
				this.LoadRemoteDirectory();
			}
		}
	}

	public partial class DoubleBufferedListView : ListView
	{
		public DoubleBufferedListView() : base()
		{
			this.DoubleBuffered = true;
		}
	}
}

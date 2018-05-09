using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryTree
{
	public partial class Form1 : Form
	{
		private RegistryKey[] RootKeys = new RegistryKey[] { Registry.ClassesRoot, Registry.CurrentUser, Registry.LocalMachine, Registry.Users, Registry.CurrentConfig };
		private Dictionary<String, RegistryKey> Roots = new Dictionary<String, RegistryKey>();
		public Form1()
		{
			InitializeComponent();
			this.treeView1.BeforeExpand += TreeView1_BeforeExpand;
			this.listView1.Columns.Add("Имя");
			this.listView1.Columns.Add("Тип");
			this.listView1.Columns.Add("Значение");
			this.listView1.ContextMenuStrip = this.contextMenuStrip2;
			this.treeView1.HideSelection = false;
			this.listView1.HideSelection = false;
			this.удалитьToolStripMenuItem1.Enabled = false;
			this.редактироватьToolStripMenuItem1.Enabled = false;
			this.Load += Form1_Load;
			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach (RegistryKey RK in this.RootKeys)
				RK.Close();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.LoadRegistry();
		}

		private RegistryKey GetRegistryKey(String fullPath)
		{
			if (!fullPath.Contains(@"\"))
				return this.Roots[fullPath];
			else
			{
				List<String> s = fullPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
				String root = s[0];
				String name = s[s.Count - 1];
				s.RemoveAt(s.Count - 1);
				s.RemoveAt(0);
				String result = "";
				foreach (String ss in s)
					result += ss + @"\";
				return this.Roots[root].OpenSubKey(result + name, true);
			}
		}

		private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode TN = e.Node;
			RegistryKey RK = this.GetRegistryKey(TN.FullPath);
			if (TN.Nodes.Count == 1 && TN.Nodes[0].Name == "")
				this.LoadSubkeys(RK, TN);
		}

		private void LoadValues(RegistryKey RK)
		{
			this.listView1.Items.Clear();
			String[] values = RK.GetValueNames();
			this.listView1.Tag = RK.Name;
			foreach (String value in values)
			{
				ListViewItem LVI = new ListViewItem();
				LVI.Text = value;
				LVI.SubItems.Add(RK.GetValueKind(value).ToString());
				LVI.SubItems.Add(RK.GetValue(value).ToString());
				this.listView1.Items.Add(LVI);
			}
		}

		private void LoadRegistry()
		{
			foreach (RegistryKey RK in this.RootKeys)
			{
				TreeNode TN = new TreeNode(RK.Name);
				this.Roots.Add(RK.Name, RK);
				this.treeView1.Nodes.Add(TN);
				TN.Nodes.Add("");
			}
		}

		private void LoadSubkeys(RegistryKey RK, TreeNode TN)
		{
			TN.Nodes.Clear();
			String[] RKS;
			try
			{
				RKS = RK.GetSubKeyNames();
			}
			catch { return; }
			foreach (String RN in RKS)
			{
				RegistryKey Key;
				try
				{
					Key = RK.OpenSubKey(RN, true);
				}
				catch { continue; }
				if (Key == null)
					continue;
				TreeNode tn = new TreeNode(RN);
				if (Key.SubKeyCount > 0)
					tn.Nodes.Add("");
				TN.Nodes.Add(tn);
				Key.Close();
			}
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeNode TN = e.Node;
			RegistryKey RK = this.GetRegistryKey(TN.FullPath);
			this.LoadValues(RK);
		}

		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeView1.SelectedNode != null)
			{
				TreeNode TN = this.treeView1.SelectedNode;
				RegistryKey RK = this.GetRegistryKey(TN.FullPath);
				Add AF = new Add();
				if (AF.ShowDialog() == DialogResult.OK)
				{
					try
					{
						RK.CreateSubKey(AF.textBox1.Text);
					}
					catch (Exception a)
					{
						MessageBox.Show(a.Message);
						return;
					}
					if (TN.IsExpanded == false)
						TN.Expand();
					else
						this.LoadSubkeys(RK, TN);
				}
			}
			else
			{
				MessageBox.Show("Выделите раздел, в который хотите добавить подраздел");
				return;
			}
		}

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeView1.SelectedNode != null)
			{
				TreeNode TN = this.treeView1.SelectedNode;
				RegistryKey RK = this.GetRegistryKey(TN.FullPath);
				RegistryKey RKParent = this.GetRegistryKey(TN.Parent.FullPath);
				try
				{
					RKParent.DeleteSubKeyTree(TN.Text);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
					return;
				}
				this.LoadSubkeys(RKParent, TN.Parent);
			}
			else
			{
				MessageBox.Show("Выделите раздел, который хотите удалить");
				return;
			}
		}

		private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.listView1.Tag != null)
			{
				RegistryKey RK =  this.GetRegistryKey(this.listView1.Tag.ToString());
				AddValue AV = new AddValue();
				if (AV.ShowDialog() == DialogResult.OK)
				{
					try
					{
						RK.SetValue(AV.textBox1.Text, AV.textBox2.Text);
					}
					catch (Exception a)
					{
						MessageBox.Show(a.Message);
						return;
					}
					this.LoadValues(RK);
				}
			}
			else
			{
				MessageBox.Show("Выделите раздел, для которого Вы хотите добавить значение");
				return;
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count > 0)
			{
				this.удалитьToolStripMenuItem1.Enabled = true;
				this.редактироватьToolStripMenuItem1.Enabled = true;
			}
			else
			{
				this.удалитьToolStripMenuItem1.Enabled = false;
				this.редактироватьToolStripMenuItem1.Enabled = false;
			}
		}

		private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count > 0)
			{
				RegistryKey RK = this.GetRegistryKey(this.listView1.Tag.ToString());
				try
				{
					RK.DeleteValue(this.listView1.SelectedItems[0].Text);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
					return;
				}
				this.LoadValues(RK);
			}
			else
			{
				MessageBox.Show("Выделите значение, которое хотите удалить");
			}
		}

		private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count > 0)
			{
				RegistryKey RK = this.GetRegistryKey(this.listView1.Tag.ToString());
				AddValue AV = new AddValue(true);
				AV.textBox1.Text = this.listView1.SelectedItems[0].Text;
				AV.textBox2.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
				if (AV.ShowDialog() == DialogResult.OK)
				{
					try
					{
						RK.DeleteValue(this.listView1.SelectedItems[0].Text);
						RK.SetValue(AV.textBox1.Text, AV.textBox2.Text);
					}
					catch (Exception a)
					{
						MessageBox.Show(a.Message);
						return;
					}
					this.LoadValues(RK);
				}
			}
			else
			{
				MessageBox.Show("Выделите значение, которое Вы хотите изменить");
			}
		}
	}
}

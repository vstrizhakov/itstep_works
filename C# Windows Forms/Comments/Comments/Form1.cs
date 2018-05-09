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

namespace Comments
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.treeView1.BeforeExpand += TreeView1_BeforeExpand;

			this.treeView1.ImageList = this.imageList1;
			String[] dirs = Directory.GetLogicalDrives();
			foreach (String D in dirs)
			{
				TreeNode TN = new TreeNode(D, 0, 1);
				this.treeView1.Nodes.Add(TN);
				this.fillTree(TN, D);
			}

		}

		private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			node.Nodes.Clear();
			this.fillTree(node, node.FullPath);
		}

		/// <summary>
		/// Заполняет узел node дочерними узлами, которые содержат
		/// названия подкаталогов каталога path
		/// </summary>
		/// <param name="node"></param>
		/// <param name="path"></param>
		public void fillTree(TreeNode node, String path)
		{
			try
			{
				String[] dirs = Directory.GetDirectories(path);
				foreach (String dir in dirs)
				{
					TreeNode TN = new TreeNode(Path.GetFileName(dir), 0, 1);
					node.Nodes.Add(TN);
					try
					{
						String[] subDirs = Directory.GetDirectories(dir);
						if (subDirs.Length > 0)
						{
							TreeNode tn = new TreeNode("?");
							TN.Nodes.Add(tn);
						}
					}
					catch { }
				}
			}
			catch { }
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}

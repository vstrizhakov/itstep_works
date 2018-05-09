﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// 
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			this.treeView1.ImageList = imageList1;
			for (int i = 0; i<10;i++)
			{
				TreeNode TN = new TreeNode("Корневой узел " + i, 0, 1);
				this.treeView1.Nodes.Add(TN);
				for (int j = 0; j < 10; j++)
				{
					TreeNode tn = new TreeNode("Дочерний узел " + j, 2, 3);
					TN.Nodes.Add(tn);

					for (int k = 0; k < 5; k++)
					{
						TreeNode Tn = new TreeNode("Дочерний дочернего " + k, 4 , 5);
						tn.Nodes.Add(Tn);
					}
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}

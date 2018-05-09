using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableLayoutPanel_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			TableLayoutPanel TLP = new TableLayoutPanel();
			TLP.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
			TLP.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
			TLP.ColumnCount = 2;
			TLP.Size = this.ClientSize;
			TLP.AutoScroll = true;
			this.Controls.Add(TLP);

			for (int i = 0; i < 20; i++)
			{
				if (i%2 ==0)
				{
					Button B = new Button();
					B.Text = "Button " + i;
					B.Size = new Size(70, 30);
					TLP.Controls.Add(B);
				}
				else
				{
					TextBox B = new TextBox();
					B.Text = "TextBox " + i;
					B.Size = new Size(70, 30);
					TLP.Controls.Add(B);
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			FlowLayoutPanel FLP = new FlowLayoutPanel();
			FLP.Size = this.ClientSize;
			FLP.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
			this.Controls.Add(FLP);

			for (int i = 0; i < 10; i++)
			{
				if (i%2 == 0)
				{
					Button B = new Button();
					B.Text = "Button " + i;
					B.Size = new Size(70, 30);
					FLP.Controls.Add(B);
				}
				else
				{
					TextBox B = new TextBox();
					B.Text = "TextBox " + i;
					B.Size = new Size(100, 30);
					FLP.Controls.Add(B);
				}
			}
		}
	}
}

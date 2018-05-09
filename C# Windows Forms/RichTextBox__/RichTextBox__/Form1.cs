using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichTextBox__
{
	public partial class Form1 : Form
	{
		private static String[] keyWords = { " new ", " is "," in ", " as ", " class ", " partial ", " internal ", " static ", " void "," public ", " private ", " protected ", " namespace ", " foreach ", " using ", " this ", " for ", " if ", " else ", " while ", " do ", " switch ", " case ", " break ", " int ", " double ", " float ", " short " };
		private static char[] symbols = { '\n', '\t', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '+', '=', '}', '{', '[', ']', '\'', '"', '?', '.', '/', '\\', ',', '>', '<', ';', ':' };
		public Form1()
		{
			InitializeComponent();
			this.richTextBox1.Font = new Font("Courier New", 10, FontStyle.Regular);
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			this.richTextBox1.Enabled = false;
			String S = " " + this.richTextBox1.Text + " ";
			for (int i = 0; i < symbols.Length; i++)
			{
				S = S.Replace(symbols[i], ' ');
			}

			int pos = this.richTextBox1.SelectionStart;
			this.richTextBox1.Select(0, S.Length - 2);
			this.richTextBox1.SelectionColor = Color.Black;
			int index = -1;

			foreach (String key in keyWords)
			{
				index = 0;
				while (true)
				{
					index = S.IndexOf(key, index);
					if (index == -1)
						break;
					this.richTextBox1.Select(index, key.Length - 2);
					this.richTextBox1.SelectionColor = Color.Blue;
					index += key.Length - 1;
				}
			}
			this.richTextBox1.SelectionStart = pos;
			this.richTextBox1.SelectionLength = 0;
			this.richTextBox1.SelectionColor = Color.Black;
			this.richTextBox1.Enabled = true;
			this.richTextBox1.Focus();
		}
	}
}

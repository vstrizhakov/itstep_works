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
	public partial class AddValue : Form
	{
		public AddValue(bool isEditing = false)
		{
			InitializeComponent();
			if (isEditing == false)
				this.Text = "Добавить значение";
			else
				this.Text = "Изменить значение";
		}
	}
}

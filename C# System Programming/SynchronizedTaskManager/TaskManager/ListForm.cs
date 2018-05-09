using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
	public partial class ListForm : Form
	{
		public ListForm(bool isThreads = false)
		{
			InitializeComponent();
			if (isThreads == false)
			{
				this.listView1.Columns.Add("Адрес модуля");
				this.listView1.Columns.Add("Имя модуля");
				this.listView1.Columns.Add("Имя модуля с путем к нему");
				this.listView1.Columns.Add("Размер памяти, занимаемой модулем");
			}
			else
			{
				this.listView1.Columns.Add("Время запуска потока");
				this.listView1.Columns.Add("Состояние потока");
				this.listView1.Columns.Add("Причина ожидания");
				this.listView1.Columns.Add("Приоритет");
			}
			this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
	}
}

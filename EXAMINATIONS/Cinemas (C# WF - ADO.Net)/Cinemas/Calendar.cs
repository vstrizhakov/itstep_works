using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinemas
{
	public partial class Calendar : Form
	{
		public String DateFrom
		{
			get
			{
				return this.date1.Text;
			}
			set
			{
				this.date1.Text = value;
			}
		}
		public String DateTo
		{
			get
			{
				return this.date2.Text;
			}
			set
			{
				this.date2.Text = value;
			}
		}
		public String Result
		{
			set
			{
				this.result.Text = value;
			}
		}

		public Calendar()
		{
			InitializeComponent();
			DateTime DT = DateTime.Now;
			for (int i = 0; i < 14; i++)
			{
				this.date1.Items.Add(DT.ToShortDateString());
				this.date2.Items.Add(DT.ToShortDateString());
				DT = DT.AddDays(1);
			}
			this.date1.SelectedIndexChanged += date1_SelectedIndexChanged;
			this.date2.SelectedIndexChanged += date1_SelectedIndexChanged;
		}

		private void date1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (DateTime.Parse(this.DateTo) < DateTime.Parse(this.DateFrom))
				{
					String tmp = this.DateTo;
					this.DateTo = this.DateFrom;
					this.DateFrom = tmp;
				}
				this.result.Text = "Результат: " + this.DateFrom + " - " + this.DateTo;
			}
			catch (Exception) { }
		}
	}
}

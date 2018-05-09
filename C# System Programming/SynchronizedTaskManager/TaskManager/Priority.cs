using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskManager
{
	public partial class Priority : Form
	{
		public Dictionary<ProcessPriorityClass, RadioButton> rbs = new Dictionary<ProcessPriorityClass, RadioButton>();
		public Dictionary<RadioButton, ProcessPriorityClass> ppcs = new Dictionary<RadioButton, ProcessPriorityClass>();
		public ProcessPriorityClass ppc;
		public Priority()
		{
			InitializeComponent();
			rbs.Add(ProcessPriorityClass.Idle, this.radioButton1);
			rbs.Add(ProcessPriorityClass.BelowNormal, this.radioButton2);
			rbs.Add(ProcessPriorityClass.Normal, this.radioButton3);
			rbs.Add(ProcessPriorityClass.AboveNormal, this.radioButton4);
			rbs.Add(ProcessPriorityClass.High, this.radioButton5);
			rbs.Add(ProcessPriorityClass.RealTime, this.radioButton6);

			ppcs.Add(this.radioButton1, ProcessPriorityClass.Idle);
			ppcs.Add(this.radioButton2, ProcessPriorityClass.BelowNormal);
			ppcs.Add(this.radioButton3, ProcessPriorityClass.Normal);
			ppcs.Add(this.radioButton4, ProcessPriorityClass.AboveNormal);
			ppcs.Add(this.radioButton5, ProcessPriorityClass.High);
			ppcs.Add(this.radioButton6, ProcessPriorityClass.RealTime);
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			ppc = ppcs[(RadioButton)sender];
			foreach (Form f in Application.OpenForms)
				if (f == this)
					this.Close();
		}
	}
}

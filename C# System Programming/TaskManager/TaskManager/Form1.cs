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
	public partial class Form1 : Form
	{
		public Dictionary<int, ListViewItem> ProcessToLVI = new Dictionary<int, ListViewItem>();
		public Form1()
		{
			InitializeComponent();
			this.listView1.ContextMenuStrip = null;
			this.списокМодулейToolStripMenuItem.Click += СписокМодулейToolStripMenuItem_Click;
			this.списокПотоковToolStripMenuItem.Click += СписокПотоковToolStripMenuItem_Click;
			this.listView1.Columns.Add("Название");
			this.listView1.Columns.Add("Заголовок главного окна процесса");
			this.listView1.Columns.Add("Приоритет");
			this.listView1.Columns.Add("Время запуска");
			this.listView1.Columns.Add("Кол-во потоков");
			this.listView1.Columns.Add("Размер виртуальной памяти, занимаемой процессом");
			this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			this.LoadProcesses();
		}

		private void СписокПотоковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ListForm LF = new ListForm(true);
				ProcessThreadCollection PTC = null;
				PTC = Process.GetProcessById((int)this.listView1.SelectedItems[0].Tag).Threads;
				foreach (ProcessThread PT in PTC)
				{
					ListViewItem LVI = new ListViewItem(PT.StartTime.ToString());
					LVI.SubItems.Add(PT.ThreadState.ToString());
					LVI.SubItems.Add(PT.WaitReason.ToString());
					LVI.SubItems.Add(PT.CurrentPriority.ToString());
					LF.listView1.Items.Add(LVI);
				}
				LF.ShowDialog();
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message);
			}
		}

		private void СписокМодулейToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ListForm LF = new ListForm();
				ProcessModuleCollection PMC = null;

				PMC = Process.GetProcessById((int)this.listView1.SelectedItems[0].Tag).Modules;
				foreach (ProcessModule PM in PMC)
				{
					ListViewItem LVI = new ListViewItem(PM.BaseAddress.ToString());
					LVI.SubItems.Add(PM.ModuleName);
					LVI.SubItems.Add(PM.FileName.ToString());
					LVI.SubItems.Add(PM.ModuleMemorySize.ToString() + " Б");
					LF.listView1.Items.Add(LVI);
				}
				LF.ShowDialog();
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message);
				return;
			}
		}

		private void LoadProcesses()
		{
			Process[] prcs = Process.GetProcesses();
			this.listView1.BeginUpdate();
			foreach (Process prc in prcs)
			{
				String procName = "", title = "", priority = "", starttime = "", threads = "", memSize = "";
				try
				{
					procName = prc.ProcessName;
				}
				catch { }
				try
				{
					title = prc.MainWindowTitle;
				}
				catch { }
				try
				{
					priority = prc.BasePriority.ToString();
				}
				catch { }
				try
				{
					starttime = prc.StartTime.ToString();
				}
				catch { }
				try
				{
					threads = prc.Threads.Count.ToString();
				}
				catch { }
				try
				{
					memSize = prc.VirtualMemorySize64.ToString() + " Б";
				}
				catch { }
				if (this.ProcessToLVI.ContainsKey(prc.Id))
				{
					ListViewItem LVI = this.ProcessToLVI[prc.Id];
					if (procName != LVI.Text
					|| title != LVI.SubItems[1].Text
					|| priority != LVI.SubItems[2].Text
					|| starttime != LVI.SubItems[3].Text
					|| threads != LVI.SubItems[4].Text
					|| memSize != LVI.SubItems[5].Text)
					{
						LVI.Text = procName;
						LVI.SubItems[1].Text = title;
						LVI.SubItems[2].Text = priority;
						LVI.SubItems[3].Text = starttime;
						LVI.SubItems[4].Text = threads;
						LVI.SubItems[5].Text = memSize;
						LVI.BackColor = Color.LightGreen;
					}
					else
						LVI.BackColor = Color.White;
				}
				else
				{
					ListViewItem LVI = new ListViewItem();
					LVI.Text = procName;
					LVI.SubItems.Add(title);
					LVI.SubItems.Add(priority);
					LVI.SubItems.Add(starttime);
					LVI.SubItems.Add(threads);
					LVI.SubItems.Add(memSize);
					LVI.Tag = prc.Id;
					this.listView1.Items.Add(LVI);
					this.ProcessToLVI.Add(prc.Id, LVI);
				}
			}
			foreach (ListViewItem LVI in this.listView1.Items)
			{
				bool exists = false;
				foreach (Process prc in prcs)
					if (prc.Id == (int)LVI.Tag)
					{
						exists = true;
					}
				if (!exists)
				{
					this.ProcessToLVI.Remove((int)LVI.Tag);
					this.listView1.Items.Remove(LVI);
				}
			}
			this.listView1.EndUpdate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.LoadProcesses();
		}

		private void убитьПроцессToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0)
			{
				int id = (int)this.listView1.SelectedItems[0].Tag;
				Process p = Process.GetProcessById(id);
				try
				{
					p.Kill();
					this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
					this.ProcessToLVI.Remove(p.Id);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
				}
			}
		}

		private void изменитьПриоритетToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0)
			{
				int id = (int)this.listView1.SelectedItems[0].Tag;
				Process p = Process.GetProcessById(id);
				Priority PriorityForm = new Priority();
				try
				{
					PriorityForm.rbs[p.PriorityClass].Checked = true;
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
					return;
				}
				if (PriorityForm.ShowDialog() == DialogResult.OK)
				{
					p.PriorityClass = PriorityForm.ppc;
				}
				this.listView1.SelectedItems[0].SubItems[2].Text = p.BasePriority.ToString();
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listView1.SelectedItems.Count != 0)
				this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			else
				this.listView1.ContextMenuStrip = null;
		}
	}
	public partial class MyListView : ListView
	{
		public MyListView()
		{
			this.DoubleBuffered = true;
		}
	}
}

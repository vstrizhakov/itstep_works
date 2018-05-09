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
using System.Threading;

namespace TaskManager
{
	public partial class Form1 : Form
	{
		private UpdatingThread UP;
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
			UP = new UpdatingThread(this);
				
			Thread T = new Thread(UP.LoadProcessesAsync);
			T.IsBackground = true;
			T.Start();
		}

		private void СписокПотоковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ListForm LF = new ListForm(true);
			ProcessThreadCollection PTC = null;
			try
			{
				PTC = Process.GetProcessById((int)this.listView1.SelectedItems[0].Tag).Threads;
			}
			catch (Exception a)
			{
				MessageBox.Show(a.Message);
				return;
			}
			foreach (ProcessThread PT in PTC)
			{
				ListViewItem LVI = new ListViewItem();
				try
				{
					LVI.Text = PT.StartTime.ToString();
				}
				catch { LVI.Text = ""; }
				try
				{
					LVI.SubItems.Add(PT.ThreadState.ToString());
				}
				catch { LVI.SubItems.Add(""); }
				try
				{
					LVI.SubItems.Add(PT.WaitReason.ToString());
				}
				catch { LVI.SubItems.Add(""); }
				try
				{
					LVI.SubItems.Add(PT.CurrentPriority.ToString());
				}
				catch { LVI.SubItems.Add(""); }
				LF.listView1.Items.Add(LVI);
			}
			LF.ShowDialog();
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

		private void button1_Click(object sender, EventArgs e)
		{
			UP.LoadProcesses();
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
					UP.ProcessToLVI.Remove(p.Id);
				}
				catch (Exception a)
				{
					MessageBox.Show(a.Message);
				}
			}
		}

		public MyListView MLV
		{
			get
			{
				return this.listView1;
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
				PriorityForm.ShowDialog();
				p.PriorityClass = PriorityForm.ppc;
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

	class UpdatingThread
	{
		public Dictionary<int, ListViewItem> ProcessToLVI = new Dictionary<int, ListViewItem>();
		private Form1 form;
		private delegate void Add(ListViewItem LVI);
		private delegate void Remove(ListViewItem LVI);
		private delegate void Update(ListViewItem LVI);
		private Add A;
		private Remove R;
		private Update U;
		private bool isFirstlyFilled = false;
		public UpdatingThread(Form1 f)
		{
			this.form = f;
			this.A = new Add(this.AddLVI);
			this.U = new Update(this.UpdateLVI);
			this.R = new Remove(this.RemoveLVI);
		}

		public void LoadProcesses()
		{
			try
			{
				Monitor.Enter(this);
				Process[] prcs = Process.GetProcesses();
				if (this.isFirstlyFilled == false)
					form.MLV.BeginUpdate();
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
						form.Invoke(this.A, LVI);
						this.ProcessToLVI.Add(prc.Id, LVI);
					}
				}
				foreach (ListViewItem LVI in form.MLV.Items)
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
						form.Invoke(this.R, LVI);
					}
				}
			}
			catch {  }
			finally
			{
				if (this.isFirstlyFilled == false)
				{
					form.MLV.EndUpdate();
					this.isFirstlyFilled = true;
				}
				Monitor.Exit(this);
			}
		}
		private void AddLVI(ListViewItem LVI)
		{
			form.MLV.Items.Add(LVI);
		}

		private void RemoveLVI(ListViewItem LVI)
		{
			form.MLV.Items.Remove(LVI);
		}

		private void UpdateLVI(ListViewItem LVI)
		{
			//LVI.Text = LVIFromCopy.Text;
			//LVI.SubItems[1].Text = LVIFromCopy.SubItems[1].Text;
			//LVI.SubItems[2].Text = LVIFromCopy.SubItems[2].Text;
			//LVI.SubItems[3].Text = LVIFromCopy.SubItems[3].Text;
			//LVI.SubItems[4].Text = LVIFromCopy.SubItems[4].Text;
			//LVI.SubItems[5].Text = LVIFromCopy.SubItems[5].Text;
			//LVI.BackColor = LVIFromCopy.BackColor;
		}		

		public void LoadProcessesAsync()
		{
			while (true)
			{
				this.LoadProcesses();
				Thread.Sleep(1100);
			}
		}
	}
}

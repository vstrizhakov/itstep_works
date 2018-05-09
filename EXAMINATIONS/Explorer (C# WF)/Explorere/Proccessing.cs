using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Explorere
{
	public partial class Proccessing : Form
	{
		private Main parent;
		private int amount = 0;
		private String[] paths;
		private String validatedPath;
		private object buf;
		public Proccessing(Main parent, int amount, String action, String valPath, object buf, String[] paths = null)
		{
			this.buf = buf;
			this.validatedPath = valPath;
			this.paths = paths;
			this.amount = amount;
			this.parent = parent;

			InitializeComponent();

			this.FormClosing += Form2_FormClosing;
			this.progress.Maximum = amount;

			if (action == "paste")
				this.backgroundWorker1.DoWork += this.PasteAsync;
			if (action == "delete")
				this.backgroundWorker1.DoWork += this.DeleteAsync;
			this.backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.RunWorkerAsync();
		}

		private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Text = String.Format("Перенесено {0} элементов из {1}", e.ProgressPercentage, this.amount);
			this.progress.Value = e.ProgressPercentage;
			this.current.Text = (String)e.UserState;
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.backgroundWorker1.CancelAsync();
		}

		private void DeleteAsync(object sender, EventArgs e)
		{
			int i = 0;
			foreach (String pth in paths)
			{
				if (this.backgroundWorker1.CancellationPending)
					return;
				this.Delete(pth, ref i);
			}
		}

		private void Delete(String dir, ref int count)
		{
			if (!Directory.Exists(dir) && File.Exists(dir))
			{
				this.backgroundWorker1.ReportProgress(++count, String.Format("Удаление файла {0}...", dir));
				File.SetAttributes(dir, FileAttributes.Normal);
				File.Delete(dir);
				if (this.backgroundWorker1.CancellationPending)
					return;
				return;
			}
			String[] dirs = new String[0], files = new String[0];
			try
			{
				dirs = Directory.GetDirectories(dir);
				files = Directory.GetFiles(dir);
			}
			catch (Exception e) { MessageBox.Show(e.Message); return; }
			foreach (String dirr in dirs)
			{
				if (this.backgroundWorker1.CancellationPending)
					return;
				this.Delete(dirr, ref count);
			}
			foreach (String file in files)
			{
				if (this.backgroundWorker1.CancellationPending)
					return;
				this.backgroundWorker1.ReportProgress(++count, String.Format("Удаление файла {0}...", file));
				try
				{
					File.SetAttributes(file, FileAttributes.Normal);
					File.Delete(file);
				}
				catch (Exception e) { MessageBox.Show(e.Message); }
			}
			if (this.backgroundWorker1.CancellationPending)
				return;
			this.backgroundWorker1.ReportProgress(++count, dir);
			File.SetAttributes(dir, FileAttributes.Normal);
			Directory.Delete(dir);
		}

		private void PasteAsync(object sender, EventArgs e)
		{
			int i = 0;
			String errors = "";
			ICollection<String> pths = parent.ToPasteBuf.Keys;
			String pth = (this.buf is ListView.SelectedListViewItemCollection) ? Path.Combine(this.validatedPath, ((ListView.SelectedListViewItemCollection)this.buf)[0].Text) : ((String)this.buf);
			foreach (String p in pths)
			{
				if (p == pth)
				{
					errors += String.Format("Невозможно скопировать папку \"{0}\", так как она является дочерней самой себе\n", p);
					continue;
				}
				if (this.backgroundWorker1.CancellationPending)
					return;
				this.Paste(p, Path.Combine(pth, Path.GetFileName(p)), parent.ToPasteBuf[p], ref i, ref errors);
			}
			if (errors.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length > 0)
				MessageBox.Show(String.Format("Произошла ошибка при копировании {1} элементов:\n{0}", errors, errors.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).Length), "Ошибка");
			if (parent.ToPasteBuf[pths.First()])
				parent.ToPasteBuf.Clear();
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			String p = (this.buf is ListView.SelectedListViewItemCollection) ? Path.Combine(this.validatedPath, ((ListView.SelectedListViewItemCollection)this.buf)[0].Text) : ((String)this.buf);
			String outputPage = "";
			if (Directory.Exists(p))
				outputPage = p;
			else
				outputPage = Path.GetDirectoryName(p);
			if (parent.ValidatedPath == outputPage)
				parent.Open(outputPage);
			TreeNode TN = parent.FindNode(outputPage, parent.Tree.Nodes);
			List<String> ExpandedNodes = new List<String>();
			if (TN != null)
			{
				if (TN.IsExpanded)
					ExpandedNodes = parent.CheckExpandedNodes(TN);
				TN.Nodes.Clear();
			}
			parent.fillTree(TN, outputPage);
			parent.ExpandNodes(ExpandedNodes);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void Paste(String sourcePath, String destPath, bool delete, ref int count, ref String errors)
		{
			if (Directory.Exists(destPath) || File.Exists(destPath))
			{
				if (this.backgroundWorker1.CancellationPending)
					return;
				if (Directory.Exists(sourcePath))
					this.amount -= parent.GetAmountOfPaths(sourcePath);
				else
					this.amount--;
				this.progress.Maximum = this.amount;
				errors += destPath + " уже существует\n";
				return;
			}
			else if (Directory.Exists(sourcePath) && !File.Exists(sourcePath))
			{
				if (this.backgroundWorker1.CancellationPending)
					return;
				Directory.CreateDirectory(destPath);
				this.backgroundWorker1.ReportProgress(++count, String.Format("Копирование папки {0}...", sourcePath));
				String[] directories;
				String[] files;
				try
				{
					directories = Directory.GetDirectories(sourcePath);
					files = Directory.GetFiles(sourcePath);
				}
				catch
				{
					return;
				}
				foreach (String d in directories)
				{
					if (this.backgroundWorker1.CancellationPending)
						return;
					this.Paste(d, Path.Combine(destPath, Path.GetFileName(d)), delete, ref count, ref errors);
				}
				foreach (String f in files)
				{
					if (this.backgroundWorker1.CancellationPending)
						return;
					this.backgroundWorker1.ReportProgress(++count, String.Format("Копирование файла {0}...", f));
					FileAttributes att = File.GetAttributes(f);
					File.SetAttributes(f, FileAttributes.Normal);
					File.Copy(f, Path.Combine(destPath, Path.GetFileName(f)));
					File.SetAttributes(Path.Combine(destPath, Path.GetFileName(f)), att);
					if (!delete)
						File.SetAttributes(f, att);
					else
						File.Delete(f);
				}
				if (delete)
					Directory.Delete(sourcePath);
			}
			else if (File.Exists(sourcePath))
			{
				if (this.backgroundWorker1.CancellationPending)
					return;
				this.backgroundWorker1.ReportProgress(++count, String.Format("Копирование файла {0}...", sourcePath));
				FileAttributes att;
				try
				{
					att = File.GetAttributes(sourcePath);
					File.SetAttributes(sourcePath, FileAttributes.Normal);
					File.Copy(sourcePath, destPath);
					File.SetAttributes(destPath, att);
				}
				catch (Exception e)
				{
					errors += e.Message + '\n';
					return;
				}
				if (!delete)
					File.SetAttributes(sourcePath, att);
				else
					File.Delete(sourcePath);
			}
		}
	}
}

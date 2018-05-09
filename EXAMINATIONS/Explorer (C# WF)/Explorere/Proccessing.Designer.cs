namespace Explorere
{
	partial class Proccessing
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.progress = new System.Windows.Forms.ProgressBar();
			this.wid = new System.Windows.Forms.Label();
			this.current = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(11, 117);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(355, 19);
			this.progress.TabIndex = 0;
			// 
			// wid
			// 
			this.wid.AutoSize = true;
			this.wid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.wid.Location = new System.Drawing.Point(8, 8);
			this.wid.Name = "wid";
			this.wid.Size = new System.Drawing.Size(300, 15);
			this.wid.TabIndex = 1;
			this.wid.Text = "Подождите, пока все элементы будут перенесены";
			// 
			// current
			// 
			this.current.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.current.Location = new System.Drawing.Point(8, 32);
			this.current.Name = "current";
			this.current.Size = new System.Drawing.Size(359, 73);
			this.current.TabIndex = 2;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// Proccessing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 144);
			this.Controls.Add(this.current);
			this.Controls.Add(this.wid);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Proccessing";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Перенос элементов";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Label wid;
		private System.Windows.Forms.Label current;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}
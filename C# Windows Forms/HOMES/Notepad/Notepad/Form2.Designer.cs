namespace Notepad
{
	partial class Form2
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
			this.label1 = new System.Windows.Forms.Label();
			this.save = new System.Windows.Forms.Button();
			this.no = new System.Windows.Forms.Button();
			this.yes = new System.Windows.Forms.Button();
			this.saveas = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(243, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Вы уверенны, что хотите закрыть программу?";
			// 
			// save
			// 
			this.save.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.save.Location = new System.Drawing.Point(12, 61);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(80, 23);
			this.save.TabIndex = 1;
			this.save.Text = "Сохранить";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.Save);
			// 
			// no
			// 
			this.no.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.no.Location = new System.Drawing.Point(261, 61);
			this.no.Name = "no";
			this.no.Size = new System.Drawing.Size(75, 23);
			this.no.TabIndex = 2;
			this.no.Text = "Отменить";
			this.no.UseVisualStyleBackColor = true;
			// 
			// yes
			// 
			this.yes.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.yes.Location = new System.Drawing.Point(98, 61);
			this.yes.Name = "yes";
			this.yes.Size = new System.Drawing.Size(43, 23);
			this.yes.TabIndex = 3;
			this.yes.Text = "Да";
			this.yes.UseVisualStyleBackColor = true;
			// 
			// saveas
			// 
			this.saveas.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveas.Location = new System.Drawing.Point(147, 61);
			this.saveas.Name = "saveas";
			this.saveas.Size = new System.Drawing.Size(108, 23);
			this.saveas.TabIndex = 4;
			this.saveas.Text = "Сохранить как...";
			this.saveas.UseVisualStyleBackColor = true;
			this.saveas.Click += new System.EventHandler(this.SaveAs);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 97);
			this.Controls.Add(this.saveas);
			this.Controls.Add(this.yes);
			this.Controls.Add(this.no);
			this.Controls.Add(this.save);
			this.Controls.Add(this.label1);
			this.Name = "Form2";
			this.Text = "Блокнот";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button no;
		private System.Windows.Forms.Button yes;
		private System.Windows.Forms.Button saveas;
	}
}
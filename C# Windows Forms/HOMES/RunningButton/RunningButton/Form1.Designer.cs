namespace RunningButton
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn
			// 
			this.btn.Location = new System.Drawing.Point(208, 194);
			this.btn.Name = "btn";
			this.btn.Size = new System.Drawing.Size(50, 50);
			this.btn.TabIndex = 0;
			this.btn.UseVisualStyleBackColor = true;
			this.btn.Click += new System.EventHandler(this.btn_Click);
			this.btn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 462);
			this.Controls.Add(this.btn);
			this.Name = "Form1";
			this.Text = "Running Button";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn;
	}
}


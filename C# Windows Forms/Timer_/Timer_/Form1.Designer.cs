namespace Timer_
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
			this.components = new System.ComponentModel.Container();
			this.stop = new System.Windows.Forms.Button();
			this.start = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// stop
			// 
			this.stop.Location = new System.Drawing.Point(29, 71);
			this.stop.Name = "stop";
			this.stop.Size = new System.Drawing.Size(75, 23);
			this.stop.TabIndex = 0;
			this.stop.Text = "Стоп";
			this.stop.UseVisualStyleBackColor = true;
			this.stop.Click += new System.EventHandler(this.stop_Click);
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(12, 42);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(75, 23);
			this.start.TabIndex = 1;
			this.start.Text = "Старт";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.button2_Click);
			// 
			// timer
			// 
			this.timer.AutoSize = true;
			this.timer.Location = new System.Drawing.Point(37, 9);
			this.timer.Name = "timer";
			this.timer.Size = new System.Drawing.Size(0, 13);
			this.timer.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(116, 106);
			this.Controls.Add(this.timer);
			this.Controls.Add(this.start);
			this.Controls.Add(this.stop);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button stop;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label timer;
	}
}


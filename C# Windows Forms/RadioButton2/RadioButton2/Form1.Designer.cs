﻿namespace RadioButton2
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 164);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton7);
			this.groupBox2.Controls.Add(this.radioButton6);
			this.groupBox2.Controls.Add(this.radioButton5);
			this.groupBox2.Location = new System.Drawing.Point(218, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 164);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(52, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Зима";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.Click += new System.EventHandler(this.Group1Click);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 42);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(56, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Весна";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.Click += new System.EventHandler(this.Group1Click);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 65);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(50, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "Лето";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.Click += new System.EventHandler(this.Group1Click);
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(6, 88);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(57, 17);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "Осень";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.Click += new System.EventHandler(this.Group1Click);
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(6, 19);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(67, 17);
			this.radioButton5.TabIndex = 1;
			this.radioButton5.Text = "Квадрат";
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.Click += new System.EventHandler(this.Group2Click);
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(6, 42);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(52, 17);
			this.radioButton6.TabIndex = 2;
			this.radioButton6.Text = "Ромб";
			this.radioButton6.UseVisualStyleBackColor = true;
			this.radioButton6.Click += new System.EventHandler(this.Group2Click);
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(6, 65);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(90, 17);
			this.radioButton7.TabIndex = 3;
			this.radioButton7.Text = "Треугольник";
			this.radioButton7.UseVisualStyleBackColor = true;
			this.radioButton7.Click += new System.EventHandler(this.Group2Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 353);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton5;
	}
}


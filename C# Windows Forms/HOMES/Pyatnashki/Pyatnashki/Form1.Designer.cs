namespace Pyatnashki
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
			this.play = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.stop = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.steps = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.time = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel4 = new System.Windows.Forms.LinkLabel();
			this.linkLabel5 = new System.Windows.Forms.LinkLabel();
			this.linkLabel6 = new System.Windows.Forms.LinkLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// play
			// 
			this.play.Location = new System.Drawing.Point(40, 29);
			this.play.Name = "play";
			this.play.Size = new System.Drawing.Size(140, 30);
			this.play.TabIndex = 0;
			this.play.Text = "Перемешать и начать";
			this.play.UseVisualStyleBackColor = true;
			this.play.Click += new System.EventHandler(this.Start);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 399);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Другие размеры:";
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel.Location = new System.Drawing.Point(39, 93);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(302, 302);
			this.panel.TabIndex = 2;
			// 
			// stop
			// 
			this.stop.Location = new System.Drawing.Point(200, 29);
			this.stop.Name = "stop";
			this.stop.Size = new System.Drawing.Size(140, 30);
			this.stop.TabIndex = 3;
			this.stop.Text = "Стоп";
			this.stop.UseVisualStyleBackColor = true;
			this.stop.Click += new System.EventHandler(this.Stop);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(37, 66);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(51, 16);
			this.label8.TabIndex = 10;
			this.label8.Text = "Ходов:";
			// 
			// steps
			// 
			this.steps.AutoSize = true;
			this.steps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.steps.Location = new System.Drawing.Point(94, 66);
			this.steps.Name = "steps";
			this.steps.Size = new System.Drawing.Size(15, 16);
			this.steps.TabIndex = 11;
			this.steps.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(200, 66);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 16);
			this.label9.TabIndex = 12;
			this.label9.Text = "Время:";
			// 
			// time
			// 
			this.time.AutoSize = true;
			this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.time.Location = new System.Drawing.Point(258, 66);
			this.time.Name = "time";
			this.time.Size = new System.Drawing.Size(39, 16);
			this.time.TabIndex = 13;
			this.time.Text = "00:00";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(153, 399);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(24, 13);
			this.linkLabel1.TabIndex = 14;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Tag = "3";
			this.linkLabel1.Text = "3x3";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeSize);
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(183, 399);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(24, 13);
			this.linkLabel2.TabIndex = 15;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Tag = "4";
			this.linkLabel2.Text = "4x4";
			this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Blue;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeSize);
			// 
			// linkLabel3
			// 
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Location = new System.Drawing.Point(243, 399);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(24, 13);
			this.linkLabel3.TabIndex = 17;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Tag = "6";
			this.linkLabel3.Text = "6x6";
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeSize);
			// 
			// linkLabel4
			// 
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.Location = new System.Drawing.Point(213, 399);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(24, 13);
			this.linkLabel4.TabIndex = 16;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Tag = "5";
			this.linkLabel4.Text = "5x5";
			this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeSize);
			// 
			// linkLabel5
			// 
			this.linkLabel5.AutoSize = true;
			this.linkLabel5.Location = new System.Drawing.Point(303, 399);
			this.linkLabel5.Name = "linkLabel5";
			this.linkLabel5.Size = new System.Drawing.Size(24, 13);
			this.linkLabel5.TabIndex = 19;
			this.linkLabel5.TabStop = true;
			this.linkLabel5.Tag = "8";
			this.linkLabel5.Text = "8x8";
			this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeSize);
			// 
			// linkLabel6
			// 
			this.linkLabel6.AutoSize = true;
			this.linkLabel6.Location = new System.Drawing.Point(273, 399);
			this.linkLabel6.Name = "linkLabel6";
			this.linkLabel6.Size = new System.Drawing.Size(24, 13);
			this.linkLabel6.TabIndex = 18;
			this.linkLabel6.TabStop = true;
			this.linkLabel6.Tag = "7";
			this.linkLabel6.Text = "7x7";
			this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangeSize);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(384, 421);
			this.Controls.Add(this.linkLabel5);
			this.Controls.Add(this.linkLabel6);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.linkLabel4);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.time);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.steps);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.stop);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.play);
			this.Name = "Form1";
			this.Text = "Пятнашки";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button play;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button stop;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label steps;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label time;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.LinkLabel linkLabel4;
		private System.Windows.Forms.LinkLabel linkLabel5;
		private System.Windows.Forms.LinkLabel linkLabel6;
		private System.Windows.Forms.Timer timer1;
	}
}


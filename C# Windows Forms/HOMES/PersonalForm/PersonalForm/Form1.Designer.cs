namespace PersonalForm
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.firstName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lastName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.year = new System.Windows.Forms.ComboBox();
			this.month = new System.Windows.Forms.ComboBox();
			this.day = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.java = new System.Windows.Forms.CheckBox();
			this.php = new System.Windows.Forms.CheckBox();
			this.cpp = new System.Windows.Forms.CheckBox();
			this.cs = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.male = new System.Windows.Forms.RadioButton();
			this.female = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.05263F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 260);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.12545F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.87455F));
			this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.firstName, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.lastName, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(279, 124);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Дата рождения:";
			// 
			// firstName
			// 
			this.firstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.firstName.Location = new System.Drawing.Point(101, 51);
			this.firstName.Name = "firstName";
			this.firstName.Size = new System.Drawing.Size(175, 20);
			this.firstName.TabIndex = 3;
			this.firstName.TextChanged += new System.EventHandler(this.firstName_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Имя:";
			// 
			// lastName
			// 
			this.lastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lastName.Location = new System.Drawing.Point(101, 10);
			this.lastName.Name = "lastName";
			this.lastName.Size = new System.Drawing.Size(175, 20);
			this.lastName.TabIndex = 1;
			this.lastName.TextChanged += new System.EventHandler(this.lastName_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Фамилия:";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.42623F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.57377F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
			this.tableLayoutPanel4.Controls.Add(this.year, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.month, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.day, 0, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(101, 85);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(175, 36);
			this.tableLayoutPanel4.TabIndex = 5;
			// 
			// year
			// 
			this.year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.year.FormattingEnabled = true;
			this.year.Location = new System.Drawing.Point(119, 7);
			this.year.Name = "year";
			this.year.Size = new System.Drawing.Size(53, 21);
			this.year.TabIndex = 2;
			this.year.SelectedIndexChanged += new System.EventHandler(this.year_SelectedIndexChanged);
			// 
			// month
			// 
			this.month.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.month.FormattingEnabled = true;
			this.month.Location = new System.Drawing.Point(43, 7);
			this.month.Name = "month";
			this.month.Size = new System.Drawing.Size(70, 21);
			this.month.TabIndex = 1;
			this.month.SelectedIndexChanged += new System.EventHandler(this.month_SelectedIndexChanged);
			// 
			// day
			// 
			this.day.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.day.FormattingEnabled = true;
			this.day.Location = new System.Drawing.Point(3, 7);
			this.day.Name = "day";
			this.day.Size = new System.Drawing.Size(34, 21);
			this.day.TabIndex = 0;
			this.day.SelectedIndexChanged += new System.EventHandler(this.day_SelectedIndexChanged);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 133);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(279, 124);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.java);
			this.groupBox1.Controls.Add(this.php);
			this.groupBox1.Controls.Add(this.cpp);
			this.groupBox1.Controls.Add(this.cs);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(133, 118);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Интересы";
			// 
			// java
			// 
			this.java.AutoSize = true;
			this.java.Location = new System.Drawing.Point(3, 92);
			this.java.Name = "java";
			this.java.Size = new System.Drawing.Size(49, 17);
			this.java.TabIndex = 3;
			this.java.Tag = "3";
			this.java.Text = "Java";
			this.java.UseVisualStyleBackColor = true;
			this.java.CheckedChanged += new System.EventHandler(this.InterestChanged);
			// 
			// php
			// 
			this.php.AutoSize = true;
			this.php.Location = new System.Drawing.Point(3, 69);
			this.php.Name = "php";
			this.php.Size = new System.Drawing.Size(48, 17);
			this.php.TabIndex = 2;
			this.php.Tag = "2";
			this.php.Text = "PHP";
			this.php.UseVisualStyleBackColor = true;
			this.php.CheckedChanged += new System.EventHandler(this.InterestChanged);
			// 
			// cpp
			// 
			this.cpp.AutoSize = true;
			this.cpp.Location = new System.Drawing.Point(3, 46);
			this.cpp.Name = "cpp";
			this.cpp.Size = new System.Drawing.Size(45, 17);
			this.cpp.TabIndex = 1;
			this.cpp.Tag = "1";
			this.cpp.Text = "C++";
			this.cpp.UseVisualStyleBackColor = true;
			this.cpp.CheckedChanged += new System.EventHandler(this.InterestChanged);
			// 
			// cs
			// 
			this.cs.AutoSize = true;
			this.cs.Location = new System.Drawing.Point(3, 23);
			this.cs.Name = "cs";
			this.cs.Size = new System.Drawing.Size(40, 17);
			this.cs.TabIndex = 0;
			this.cs.Tag = "0";
			this.cs.Text = "C#";
			this.cs.UseVisualStyleBackColor = true;
			this.cs.CheckedChanged += new System.EventHandler(this.InterestChanged);
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.button1, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.groupBox2, 0, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(142, 3);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.49152F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.50847F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(134, 118);
			this.tableLayoutPanel5.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(3, 85);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "Сохранить и выйти";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.male);
			this.groupBox2.Controls.Add(this.female);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(128, 76);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Пол";
			// 
			// male
			// 
			this.male.AutoSize = true;
			this.male.Location = new System.Drawing.Point(6, 24);
			this.male.Name = "male";
			this.male.Size = new System.Drawing.Size(71, 17);
			this.male.TabIndex = 1;
			this.male.TabStop = true;
			this.male.Tag = "0";
			this.male.Text = "Мужской";
			this.male.UseVisualStyleBackColor = true;
			this.male.CheckedChanged += new System.EventHandler(this.SexChanged);
			// 
			// female
			// 
			this.female.AutoSize = true;
			this.female.Location = new System.Drawing.Point(6, 47);
			this.female.Name = "female";
			this.female.Size = new System.Drawing.Size(72, 17);
			this.female.TabIndex = 0;
			this.female.TabStop = true;
			this.female.Tag = "1";
			this.female.Text = "Женский";
			this.female.UseVisualStyleBackColor = true;
			this.female.CheckedChanged += new System.EventHandler(this.SexChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "Form1";
			this.Text = "Анкета";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox lastName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox firstName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox year;
		private System.Windows.Forms.ComboBox month;
		private System.Windows.Forms.ComboBox day;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox java;
		private System.Windows.Forms.CheckBox php;
		private System.Windows.Forms.CheckBox cpp;
		private System.Windows.Forms.CheckBox cs;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton male;
		private System.Windows.Forms.RadioButton female;
	}
}


namespace Films
{
	partial class Main
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tab1 = new System.Windows.Forms.TabPage();
			this.genres = new System.Windows.Forms.ListView();
			this.tab2 = new System.Windows.Forms.TabPage();
			this.films = new System.Windows.Forms.ListView();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.editBtn = new System.Windows.Forms.Button();
			this.deleteBtn = new System.Windows.Forms.Button();
			this.addBtn = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tab1.SuspendLayout();
			this.tab2.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(628, 332);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tab1);
			this.tabControl1.Controls.Add(this.tab2);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(622, 286);
			this.tabControl1.TabIndex = 1;
			// 
			// tab1
			// 
			this.tab1.Controls.Add(this.genres);
			this.tab1.Location = new System.Drawing.Point(4, 22);
			this.tab1.Name = "tab1";
			this.tab1.Padding = new System.Windows.Forms.Padding(3);
			this.tab1.Size = new System.Drawing.Size(614, 260);
			this.tab1.TabIndex = 0;
			this.tab1.Text = "Жанры";
			this.tab1.UseVisualStyleBackColor = true;
			// 
			// genres
			// 
			this.genres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.genres.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.genres.FullRowSelect = true;
			this.genres.GridLines = true;
			this.genres.Location = new System.Drawing.Point(0, 0);
			this.genres.Name = "genres";
			this.genres.Size = new System.Drawing.Size(615, 260);
			this.genres.TabIndex = 1;
			this.genres.UseCompatibleStateImageBehavior = false;
			this.genres.View = System.Windows.Forms.View.Details;
			// 
			// tab2
			// 
			this.tab2.Controls.Add(this.films);
			this.tab2.Location = new System.Drawing.Point(4, 22);
			this.tab2.Name = "tab2";
			this.tab2.Padding = new System.Windows.Forms.Padding(3);
			this.tab2.Size = new System.Drawing.Size(614, 260);
			this.tab2.TabIndex = 1;
			this.tab2.Text = "Фильмы";
			this.tab2.UseVisualStyleBackColor = true;
			// 
			// films
			// 
			this.films.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.films.FullRowSelect = true;
			this.films.GridLines = true;
			this.films.Location = new System.Drawing.Point(0, 0);
			this.films.Name = "films";
			this.films.Size = new System.Drawing.Size(615, 260);
			this.films.TabIndex = 0;
			this.films.UseCompatibleStateImageBehavior = false;
			this.films.View = System.Windows.Forms.View.Details;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.editBtn, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.deleteBtn, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.addBtn, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 295);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(622, 34);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// editBtn
			// 
			this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.editBtn.Location = new System.Drawing.Point(417, 3);
			this.editBtn.Name = "editBtn";
			this.editBtn.Size = new System.Drawing.Size(202, 28);
			this.editBtn.TabIndex = 2;
			this.editBtn.Text = "Редактировать";
			this.editBtn.UseVisualStyleBackColor = true;
			this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
			// 
			// deleteBtn
			// 
			this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteBtn.Location = new System.Drawing.Point(210, 3);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(201, 28);
			this.deleteBtn.TabIndex = 1;
			this.deleteBtn.Text = "Удалить";
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// addBtn
			// 
			this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.addBtn.Location = new System.Drawing.Point(3, 3);
			this.addBtn.Name = "addBtn";
			this.addBtn.Size = new System.Drawing.Size(201, 28);
			this.addBtn.TabIndex = 0;
			this.addBtn.Text = "Добавить";
			this.addBtn.UseVisualStyleBackColor = true;
			this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(628, 333);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Main";
			this.Text = "Films";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tab1.ResumeLayout(false);
			this.tab2.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tab1;
		private System.Windows.Forms.TabPage tab2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button editBtn;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.Button addBtn;
		private System.Windows.Forms.ListView films;
		private System.Windows.Forms.ListView genres;
	}
}


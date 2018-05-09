namespace TaskManager
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.listView1 = new MyListView();
			this.button1 = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.убитьПроцессToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьПриоритетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокМодулейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокПотоковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 547);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(3, 3);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(992, 511);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(3, 520);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(992, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Обновить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.убитьПроцессToolStripMenuItem,
            this.изменитьПриоритетToolStripMenuItem,
            this.списокМодулейToolStripMenuItem,
            this.списокПотоковToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(190, 92);
			// 
			// убитьПроцессToolStripMenuItem
			// 
			this.убитьПроцессToolStripMenuItem.Name = "убитьПроцессToolStripMenuItem";
			this.убитьПроцессToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.убитьПроцессToolStripMenuItem.Text = "Убить процесс";
			this.убитьПроцессToolStripMenuItem.Click += new System.EventHandler(this.убитьПроцессToolStripMenuItem_Click);
			// 
			// изменитьПриоритетToolStripMenuItem
			// 
			this.изменитьПриоритетToolStripMenuItem.Name = "изменитьПриоритетToolStripMenuItem";
			this.изменитьПриоритетToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.изменитьПриоритетToolStripMenuItem.Text = "Изменить приоритет";
			this.изменитьПриоритетToolStripMenuItem.Click += new System.EventHandler(this.изменитьПриоритетToolStripMenuItem_Click);
			// 
			// списокМодулейToolStripMenuItem
			// 
			this.списокМодулейToolStripMenuItem.Name = "списокМодулейToolStripMenuItem";
			this.списокМодулейToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.списокМодулейToolStripMenuItem.Text = "Список модулей";
			// 
			// списокПотоковToolStripMenuItem
			// 
			this.списокПотоковToolStripMenuItem.Name = "списокПотоковToolStripMenuItem";
			this.списокПотоковToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.списокПотоковToolStripMenuItem.Text = "Список потоков";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(998, 547);
			this.Controls.Add(this.tableLayoutPanel1);
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Диспетчер задач";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private MyListView listView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem убитьПроцессToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьПриоритетToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокМодулейToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокПотоковToolStripMenuItem;
	}
}


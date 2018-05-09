namespace Explorere
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.catalog = new System.Windows.Forms.ListView();
			this.tree = new System.Windows.Forms.TreeView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.path = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.down = new System.Windows.Forms.Panel();
			this.up = new System.Windows.Forms.Panel();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.createFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rename = new System.Windows.Forms.ToolStripMenuItem();
			this.copy = new System.Windows.Forms.ToolStripMenuItem();
			this.paste = new System.Windows.Forms.ToolStripMenuItem();
			this.cut = new System.Windows.Forms.ToolStripMenuItem();
			this.delete = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(813, 559);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.statusStrip1, 0, 1);
			this.tableLayoutPanel3.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 36);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(807, 520);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.catalog, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.tree, 0, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(801, 494);
			this.tableLayoutPanel4.TabIndex = 0;
			// 
			// catalog
			// 
			this.catalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.catalog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.catalog.Location = new System.Drawing.Point(209, 3);
			this.catalog.Name = "catalog";
			this.catalog.Size = new System.Drawing.Size(589, 488);
			this.catalog.TabIndex = 5;
			this.catalog.UseCompatibleStateImageBehavior = false;
			this.catalog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.catalog_KeyDown);
			// 
			// tree
			// 
			this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tree.Location = new System.Drawing.Point(3, 3);
			this.tree.Name = "tree";
			this.tree.Size = new System.Drawing.Size(200, 488);
			this.tree.TabIndex = 6;
			this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 500);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(807, 20);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.IsLink = true;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 15);
			this.toolStripStatusLabel1.Text = "Изменить вид";
			this.toolStripStatusLabel1.Click += new System.EventHandler(this.ChangeView);
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.IsLink = true;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(123, 15);
			this.toolStripStatusLabel2.Text = "Показывать скрытые";
			this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.path, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(807, 27);
			this.tableLayoutPanel2.TabIndex = 4;
			// 
			// path
			// 
			this.path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.path.Location = new System.Drawing.Point(70, 3);
			this.path.Name = "path";
			this.path.Size = new System.Drawing.Size(734, 20);
			this.path.TabIndex = 2;
			this.path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.path_KeyDown);
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.down, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.up, 0, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(61, 21);
			this.tableLayoutPanel5.TabIndex = 3;
			// 
			// down
			// 
			this.down.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.down.BackgroundImage = global::Explorere.Properties.Resources.back___копия2;
			this.down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.down.Cursor = System.Windows.Forms.Cursors.Hand;
			this.down.Enabled = false;
			this.down.Location = new System.Drawing.Point(33, 3);
			this.down.Name = "down";
			this.down.Size = new System.Drawing.Size(24, 15);
			this.down.TabIndex = 7;
			this.down.Tag = "down";
			this.down.Click += new System.EventHandler(this.UpOrDown);
			// 
			// up
			// 
			this.up.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.up.BackgroundImage = global::Explorere.Properties.Resources.back2;
			this.up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.up.Cursor = System.Windows.Forms.Cursors.Hand;
			this.up.Enabled = false;
			this.up.Location = new System.Drawing.Point(3, 3);
			this.up.Name = "up";
			this.up.Size = new System.Drawing.Size(24, 15);
			this.up.TabIndex = 6;
			this.up.Tag = "up";
			this.up.Click += new System.EventHandler(this.UpOrDown);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "CLSDFOLD.ICO");
			this.imageList1.Images.SetKeyName(1, "OPENFOLD.ICO");
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFolder,
            this.обновитьToolStripMenuItem,
            this.rename,
            this.copy,
            this.paste,
            this.cut,
            this.delete});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(196, 180);
			// 
			// createFolder
			// 
			this.createFolder.Name = "createFolder";
			this.createFolder.ShortcutKeyDisplayString = "";
			this.createFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.createFolder.Size = new System.Drawing.Size(195, 22);
			this.createFolder.Text = "Создать папку";
			this.createFolder.Click += new System.EventHandler(this.createFolder_Click);
			// 
			// обновитьToolStripMenuItem
			// 
			this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
			this.обновитьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.обновитьToolStripMenuItem.Text = "Обновить";
			this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
			// 
			// rename
			// 
			this.rename.Name = "rename";
			this.rename.Size = new System.Drawing.Size(195, 22);
			this.rename.Text = "Переименовать";
			this.rename.Click += new System.EventHandler(this.rename_Click);
			// 
			// copy
			// 
			this.copy.Name = "copy";
			this.copy.Size = new System.Drawing.Size(195, 22);
			this.copy.Text = "Копировать";
			this.copy.Click += new System.EventHandler(this.copy_Click);
			// 
			// paste
			// 
			this.paste.Name = "paste";
			this.paste.Size = new System.Drawing.Size(195, 22);
			this.paste.Text = "Вставить";
			this.paste.Click += new System.EventHandler(this.paste_Click);
			// 
			// cut
			// 
			this.cut.Name = "cut";
			this.cut.Size = new System.Drawing.Size(195, 22);
			this.cut.Text = "Вырезать";
			this.cut.Click += new System.EventHandler(this.cut_Click);
			// 
			// delete
			// 
			this.delete.Name = "delete";
			this.delete.Size = new System.Drawing.Size(195, 22);
			this.delete.Text = "Удалить";
			this.delete.Click += new System.EventHandler(this.delete_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 557);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.Text = "Проводник";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ListView catalog;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox path;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Panel down;
		private System.Windows.Forms.Panel up;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem createFolder;
		private System.Windows.Forms.ToolStripMenuItem copy;
		private System.Windows.Forms.ToolStripMenuItem paste;
		private System.Windows.Forms.ToolStripMenuItem cut;
		private System.Windows.Forms.ToolStripMenuItem delete;
		private System.Windows.Forms.ToolStripMenuItem rename;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
	}
}


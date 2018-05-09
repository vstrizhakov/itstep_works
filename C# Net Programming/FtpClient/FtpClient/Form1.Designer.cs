namespace FtpClient
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.TabController = new System.Windows.Forms.TabControl();
			this.TabTable = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
			this.localTree = new System.Windows.Forms.TreeView();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.localList = new FtpClient.DoubleBufferedListView();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.localComboBox = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			this.remoteList = new FtpClient.DoubleBufferedListView();
			this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
			this.remoteComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.TabWrapper = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
			this.logger = new System.Windows.Forms.RichTextBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.password = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.username = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.host = new System.Windows.Forms.TextBox();
			this.connectBtn = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.port = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.localContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.цукншщхйфриыбюфыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.remoteContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.скачатьССервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.создатьКаталогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TabTable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.tableLayoutPanel12.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.tableLayoutPanel10.SuspendLayout();
			this.tableLayoutPanel14.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.TabWrapper.SuspendLayout();
			this.tableLayoutPanel11.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.localContextMenu.SuspendLayout();
			this.remoteContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabController
			// 
			this.TabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabController.Location = new System.Drawing.Point(4, 4);
			this.TabController.Name = "TabController";
			this.TabController.SelectedIndex = 0;
			this.TabController.Size = new System.Drawing.Size(833, 430);
			this.TabController.TabIndex = 0;
			// 
			// TabTable
			// 
			this.TabTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabTable.ColumnCount = 1;
			this.TabTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TabTable.Controls.Add(this.splitContainer2, 0, 0);
			this.TabTable.Location = new System.Drawing.Point(4, 4);
			this.TabTable.Name = "TabTable";
			this.TabTable.RowCount = 1;
			this.TabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TabTable.Size = new System.Drawing.Size(833, 430);
			this.TabTable.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel6);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel9);
			this.splitContainer2.Size = new System.Drawing.Size(827, 424);
			this.splitContainer2.SplitterDistance = 409;
			this.splitContainer2.TabIndex = 6;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel6.ColumnCount = 1;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Controls.Add(this.splitContainer3, 0, 1);
			this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 0, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 2;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(407, 424);
			this.tableLayoutPanel6.TabIndex = 0;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer3.Location = new System.Drawing.Point(4, 39);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel12);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel7);
			this.splitContainer3.Size = new System.Drawing.Size(399, 381);
			this.splitContainer3.SplitterDistance = 170;
			this.splitContainer3.TabIndex = 0;
			// 
			// tableLayoutPanel12
			// 
			this.tableLayoutPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel12.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel12.ColumnCount = 1;
			this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel12.Controls.Add(this.localTree, 0, 0);
			this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel12.Name = "tableLayoutPanel12";
			this.tableLayoutPanel12.RowCount = 1;
			this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel12.Size = new System.Drawing.Size(399, 168);
			this.tableLayoutPanel12.TabIndex = 2;
			// 
			// localTree
			// 
			this.localTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.localTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.localTree.FullRowSelect = true;
			this.localTree.HideSelection = false;
			this.localTree.Location = new System.Drawing.Point(4, 4);
			this.localTree.Name = "localTree";
			this.localTree.PathSeparator = "/";
			this.localTree.Size = new System.Drawing.Size(391, 160);
			this.localTree.TabIndex = 0;
			this.localTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.localTree_BeforeExpand);
			this.localTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.localTree_AfterSelect);
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel7.ColumnCount = 1;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.Controls.Add(this.localList, 0, 0);
			this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(399, 207);
			this.tableLayoutPanel7.TabIndex = 0;
			// 
			// localList
			// 
			this.localList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.localList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.localList.FullRowSelect = true;
			this.localList.HideSelection = false;
			this.localList.Location = new System.Drawing.Point(4, 4);
			this.localList.Name = "localList";
			this.localList.Size = new System.Drawing.Size(391, 199);
			this.localList.TabIndex = 1;
			this.localList.UseCompatibleStateImageBehavior = false;
			this.localList.View = System.Windows.Forms.View.Details;
			this.localList.SelectedIndexChanged += new System.EventHandler(this.localList_SelectedIndexChanged);
			this.localList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.localList_DoubleClick);
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel8.ColumnCount = 2;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel8.Controls.Add(this.localComboBox, 1, 0);
			this.tableLayoutPanel8.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(399, 28);
			this.tableLayoutPanel8.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(129, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Локальный компьютер:";
			// 
			// localComboBox
			// 
			this.localComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.localComboBox.FormattingEnabled = true;
			this.localComboBox.Location = new System.Drawing.Point(138, 3);
			this.localComboBox.Name = "localComboBox";
			this.localComboBox.Size = new System.Drawing.Size(258, 21);
			this.localComboBox.TabIndex = 1;
			this.localComboBox.SelectedIndexChanged += new System.EventHandler(this.localComboBox_SelectedIndexChanged);
			this.localComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.localComboBox_KeyPress);
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel9.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel9.ColumnCount = 1;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.Controls.Add(this.splitContainer4, 0, 1);
			this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel14, 0, 0);
			this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 2;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(412, 424);
			this.tableLayoutPanel9.TabIndex = 0;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer4.Location = new System.Drawing.Point(4, 39);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.tableLayoutPanel13);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.tableLayoutPanel10);
			this.splitContainer4.Size = new System.Drawing.Size(404, 381);
			this.splitContainer4.SplitterDistance = 170;
			this.splitContainer4.TabIndex = 0;
			// 
			// tableLayoutPanel13
			// 
			this.tableLayoutPanel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel13.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel13.ColumnCount = 1;
			this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel13.Name = "tableLayoutPanel13";
			this.tableLayoutPanel13.RowCount = 1;
			this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel13.Size = new System.Drawing.Size(404, 168);
			this.tableLayoutPanel13.TabIndex = 3;
			// 
			// tableLayoutPanel10
			// 
			this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel10.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel10.ColumnCount = 1;
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel10.Controls.Add(this.remoteList, 0, 0);
			this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 1;
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel10.Size = new System.Drawing.Size(404, 207);
			this.tableLayoutPanel10.TabIndex = 1;
			// 
			// remoteList
			// 
			this.remoteList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.remoteList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.remoteList.FullRowSelect = true;
			this.remoteList.HideSelection = false;
			this.remoteList.Location = new System.Drawing.Point(4, 4);
			this.remoteList.Name = "remoteList";
			this.remoteList.Size = new System.Drawing.Size(396, 199);
			this.remoteList.TabIndex = 1;
			this.remoteList.UseCompatibleStateImageBehavior = false;
			this.remoteList.View = System.Windows.Forms.View.Details;
			// 
			// tableLayoutPanel14
			// 
			this.tableLayoutPanel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel14.ColumnCount = 2;
			this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
			this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel14.Controls.Add(this.remoteComboBox, 0, 0);
			this.tableLayoutPanel14.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel14.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanel14.Name = "tableLayoutPanel14";
			this.tableLayoutPanel14.RowCount = 1;
			this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel14.Size = new System.Drawing.Size(404, 28);
			this.tableLayoutPanel14.TabIndex = 1;
			// 
			// remoteComboBox
			// 
			this.remoteComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.remoteComboBox.FormattingEnabled = true;
			this.remoteComboBox.Location = new System.Drawing.Point(138, 3);
			this.remoteComboBox.Name = "remoteComboBox";
			this.remoteComboBox.Size = new System.Drawing.Size(263, 21);
			this.remoteComboBox.TabIndex = 2;
			this.remoteComboBox.SelectedIndexChanged += new System.EventHandler(this.remoteComboBox_SelectedIndexChanged);
			this.remoteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.remoteComboBox_KeyPress);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Удаленный компьютер:";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(1, 561);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(853, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.splitContainer1, 0, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 45);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(847, 512);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.TabWrapper);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel11);
			this.splitContainer1.Size = new System.Drawing.Size(841, 506);
			this.splitContainer1.SplitterDistance = 441;
			this.splitContainer1.TabIndex = 0;
			// 
			// TabWrapper
			// 
			this.TabWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabWrapper.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.TabWrapper.ColumnCount = 1;
			this.TabWrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TabWrapper.Controls.Add(this.TabTable, 0, 0);
			this.TabWrapper.Location = new System.Drawing.Point(0, 0);
			this.TabWrapper.Name = "TabWrapper";
			this.TabWrapper.RowCount = 1;
			this.TabWrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TabWrapper.Size = new System.Drawing.Size(841, 438);
			this.TabWrapper.TabIndex = 0;
			// 
			// tableLayoutPanel11
			// 
			this.tableLayoutPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel11.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel11.ColumnCount = 1;
			this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel11.Controls.Add(this.logger, 0, 0);
			this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel11.Name = "tableLayoutPanel11";
			this.tableLayoutPanel11.RowCount = 1;
			this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel11.Size = new System.Drawing.Size(841, 61);
			this.tableLayoutPanel11.TabIndex = 0;
			// 
			// logger
			// 
			this.logger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logger.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.logger.Location = new System.Drawing.Point(4, 4);
			this.logger.Name = "logger";
			this.logger.Size = new System.Drawing.Size(833, 53);
			this.logger.TabIndex = 0;
			this.logger.Text = "";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 9;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel2.Controls.Add(this.password, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.username, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.host, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.connectBtn, 8, 0);
			this.tableLayoutPanel2.Controls.Add(this.label6, 6, 0);
			this.tableLayoutPanel2.Controls.Add(this.port, 7, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(847, 34);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// password
			// 
			this.password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.password.Location = new System.Drawing.Point(449, 7);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(113, 20);
			this.password.TabIndex = 5;
			this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.host_KeyPress);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(395, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Пароль:";
			// 
			// username
			// 
			this.username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.username.Location = new System.Drawing.Point(276, 7);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(113, 20);
			this.username.TabIndex = 3;
			this.username.Text = "admin";
			this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.host_KeyPress);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(162, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Имя пользователя:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Хост:";
			// 
			// host
			// 
			this.host.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.host.Location = new System.Drawing.Point(43, 7);
			this.host.Name = "host";
			this.host.Size = new System.Drawing.Size(113, 20);
			this.host.TabIndex = 1;
			this.host.Text = "127.0.0.1";
			this.host.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.host_KeyPress);
			// 
			// connectBtn
			// 
			this.connectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.connectBtn.Location = new System.Drawing.Point(730, 3);
			this.connectBtn.Name = "connectBtn";
			this.connectBtn.Size = new System.Drawing.Size(114, 28);
			this.connectBtn.TabIndex = 6;
			this.connectBtn.Text = "Подключиться";
			this.connectBtn.UseVisualStyleBackColor = true;
			this.connectBtn.Click += new System.EventHandler(this.connect);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(568, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Порт:";
			// 
			// port
			// 
			this.port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.port.Location = new System.Drawing.Point(611, 7);
			this.port.Name = "port";
			this.port.Size = new System.Drawing.Size(113, 20);
			this.port.TabIndex = 8;
			this.port.Text = "5055";
			this.port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.host_KeyPress);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 28);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 584);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(857, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Enabled = false;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(125, 22);
			this.toolStripButton1.Text = "Менеджер Серверов";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton2.Enabled = false;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(103, 22);
			this.toolStripButton2.Text = "Закрыть вкладку";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "icons8-папка-32.png");
			this.imageList1.Images.SetKeyName(1, "icons8-открыть-папку-32.png");
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "icons8-болванка-cd-32.png");
			this.imageList2.Images.SetKeyName(1, "icons8-папка-32.png");
			this.imageList2.Images.SetKeyName(2, "icons8-открыть-папку-32.png");
			// 
			// localContextMenu
			// 
			this.localContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цукншщхйфриыбюфыToolStripMenuItem});
			this.localContextMenu.Name = "localContextMenu";
			this.localContextMenu.Size = new System.Drawing.Size(181, 26);
			// 
			// цукншщхйфриыбюфыToolStripMenuItem
			// 
			this.цукншщхйфриыбюфыToolStripMenuItem.Name = "цукншщхйфриыбюфыToolStripMenuItem";
			this.цукншщхйфриыбюфыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.цукншщхйфриыбюфыToolStripMenuItem.Text = "Закачать на сервер";
			this.цукншщхйфриыбюфыToolStripMenuItem.Click += new System.EventHandler(this.цукншщхйфриыбюфыToolStripMenuItem_Click);
			// 
			// remoteContextMenu
			// 
			this.remoteContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьССервераToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.переименоватьToolStripMenuItem,
            this.создатьКаталогToolStripMenuItem});
			this.remoteContextMenu.Name = "remoteContextMenu";
			this.remoteContextMenu.Size = new System.Drawing.Size(175, 92);
			// 
			// скачатьССервераToolStripMenuItem
			// 
			this.скачатьССервераToolStripMenuItem.Name = "скачатьССервераToolStripMenuItem";
			this.скачатьССервераToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.скачатьССервераToolStripMenuItem.Text = "Скачать с сервера";
			this.скачатьССервераToolStripMenuItem.Click += new System.EventHandler(this.скачатьССервераToolStripMenuItem_Click);
			// 
			// удалитьToolStripMenuItem
			// 
			this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
			this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.удалитьToolStripMenuItem.Text = "Удалить";
			this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
			// 
			// переименоватьToolStripMenuItem
			// 
			this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
			this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.переименоватьToolStripMenuItem.Text = "Переименовать";
			this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.переименоватьToolStripMenuItem_Click);
			// 
			// создатьКаталогToolStripMenuItem
			// 
			this.создатьКаталогToolStripMenuItem.Name = "создатьКаталогToolStripMenuItem";
			this.создатьКаталогToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.создатьКаталогToolStripMenuItem.Text = "Создать каталог";
			this.создатьКаталогToolStripMenuItem.Click += new System.EventHandler(this.создатьКаталогToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(857, 613);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FTP Client";
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.TabTable.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.tableLayoutPanel12.ResumeLayout(false);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			this.tableLayoutPanel9.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.tableLayoutPanel10.ResumeLayout(false);
			this.tableLayoutPanel14.ResumeLayout(false);
			this.tableLayoutPanel14.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.TabWrapper.ResumeLayout(false);
			this.tableLayoutPanel11.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.localContextMenu.ResumeLayout(false);
			this.remoteContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}		

		#endregion
		private System.Windows.Forms.TabControl TabController;
		private System.Windows.Forms.TableLayoutPanel TabTable;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private DoubleBufferedListView localList;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.SplitContainer splitContainer4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
		private DoubleBufferedListView remoteList;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TableLayoutPanel TabWrapper;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
		private System.Windows.Forms.RichTextBox logger;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox host;
		private System.Windows.Forms.Button connectBtn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox port;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ComboBox localComboBox;
		private System.Windows.Forms.ComboBox remoteComboBox;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TreeView localTree;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ContextMenuStrip localContextMenu;
		private System.Windows.Forms.ContextMenuStrip remoteContextMenu;
		private System.Windows.Forms.ToolStripMenuItem скачатьССервераToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem цукншщхйфриыбюфыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem создатьКаталогToolStripMenuItem;
	}
}


namespace JSBuild
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExtjsWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnWebSite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.tbNew = new System.Windows.Forms.ToolStripButton();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tbFolder = new System.Windows.Forms.ToolStripButton();
            this.tbRemoveFolder = new System.Windows.Forms.ToolStripButton();
            this.tbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbOptions = new System.Windows.Forms.ToolStripButton();
            this.tbBuild = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.form = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.files = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.projectTab = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCopy = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.targets = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.cbDoc = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtBuild = new System.Windows.Forms.TextBox();
            this.txtDocs = new System.Windows.Forms.TextBox();
            this.cbSource = new System.Windows.Forms.CheckBox();
            this.cbBuild = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.btnAddTarget = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnRemoveTarget = new System.Windows.Forms.Button();
            this.btnModifyTarget = new System.Windows.Forms.Button();
            this.filesCtx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSet = new System.Data.DataSet();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.folders = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnRecentProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.form.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.projectTab.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.filesCtx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(772, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNew,
            this.mnOpen,
            this.toolStripSeparator2,
            this.mnSave,
            this.toolStripSeparator7,
            this.mnRecentProjects,
            this.toolStripSeparator3,
            this.mnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnNew
            // 
            this.mnNew.Image = ((System.Drawing.Image)(resources.GetObject("mnNew.Image")));
            this.mnNew.Name = "mnNew";
            this.mnNew.Size = new System.Drawing.Size(161, 22);
            this.mnNew.Text = "New Project";
            this.mnNew.Click += new System.EventHandler(this.tbNew_Click);
            // 
            // mnOpen
            // 
            this.mnOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnOpen.Image")));
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.Size = new System.Drawing.Size(161, 22);
            this.mnOpen.Text = "Open Project...";
            this.mnOpen.Click += new System.EventHandler(this.tbOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // mnSave
            // 
            this.mnSave.Enabled = false;
            this.mnSave.Image = ((System.Drawing.Image)(resources.GetObject("mnSave.Image")));
            this.mnSave.Name = "mnSave";
            this.mnSave.Size = new System.Drawing.Size(161, 22);
            this.mnSave.Text = "Save Project...";
            this.mnSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(161, 22);
            this.mnExit.Text = "Exit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnBuild,
            this.mnOptions});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // mnBuild
            // 
            this.mnBuild.Enabled = false;
            this.mnBuild.Image = ((System.Drawing.Image)(resources.GetObject("mnBuild.Image")));
            this.mnBuild.Name = "mnBuild";
            this.mnBuild.Size = new System.Drawing.Size(144, 22);
            this.mnBuild.Text = "Build Project";
            this.mnBuild.Click += new System.EventHandler(this.BuildClick);
            // 
            // mnOptions
            // 
            this.mnOptions.Name = "mnOptions";
            this.mnOptions.Size = new System.Drawing.Size(144, 22);
            this.mnOptions.Text = "Options...";
            this.mnOptions.Click += new System.EventHandler(this.tbOptions_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExtjsWebsite,
            this.mnWebSite,
            this.toolStripSeparator5,
            this.mnAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuExtjsWebsite
            // 
            this.mnuExtjsWebsite.Name = "mnuExtjsWebsite";
            this.mnuExtjsWebsite.Size = new System.Drawing.Size(247, 22);
            this.mnuExtjsWebsite.Text = "Visit the Ext JS website";
            this.mnuExtjsWebsite.Click += new System.EventHandler(this.mnuExtjsWebsite_Click);
            // 
            // mnWebSite
            // 
            this.mnWebSite.Image = ((System.Drawing.Image)(resources.GetObject("mnWebSite.Image")));
            this.mnWebSite.Name = "mnWebSite";
            this.mnWebSite.Size = new System.Drawing.Size(247, 22);
            this.mnWebSite.Text = "Visit the JSB Google Code website";
            this.mnWebSite.Click += new System.EventHandler(this.mnWebSite_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(244, 6);
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(247, 22);
            this.mnAbout.Text = "About JS Builder";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNew,
            this.tbOpen,
            this.tbSave,
            this.toolStripSeparator6,
            this.tbFolder,
            this.tbRemoveFolder,
            this.tbRefresh,
            this.toolStripSeparator1,
            this.tbOptions,
            this.tbBuild});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(772, 25);
            this.toolbar.TabIndex = 2;
            this.toolbar.Text = "toolStrip1";
            // 
            // tbNew
            // 
            this.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbNew.Image = ((System.Drawing.Image)(resources.GetObject("tbNew.Image")));
            this.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbNew.Name = "tbNew";
            this.tbNew.Size = new System.Drawing.Size(23, 22);
            this.tbNew.Text = "New Project";
            this.tbNew.Click += new System.EventHandler(this.tbNew_Click);
            // 
            // tbOpen
            // 
            this.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbOpen.Image")));
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(23, 22);
            this.tbOpen.Text = "Open Project";
            this.tbOpen.Click += new System.EventHandler(this.tbOpen_Click);
            // 
            // tbSave
            // 
            this.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSave.Enabled = false;
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(23, 22);
            this.tbSave.Text = "Save Project";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tbFolder
            // 
            this.tbFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbFolder.Enabled = false;
            this.tbFolder.Image = ((System.Drawing.Image)(resources.GetObject("tbFolder.Image")));
            this.tbFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(23, 22);
            this.tbFolder.Text = "Add Folder";
            this.tbFolder.Click += new System.EventHandler(this.tbFolder_Click);
            // 
            // tbRemoveFolder
            // 
            this.tbRemoveFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRemoveFolder.Enabled = false;
            this.tbRemoveFolder.Image = ((System.Drawing.Image)(resources.GetObject("tbRemoveFolder.Image")));
            this.tbRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRemoveFolder.Name = "tbRemoveFolder";
            this.tbRemoveFolder.Size = new System.Drawing.Size(23, 22);
            this.tbRemoveFolder.Text = "Remove Folder";
            this.tbRemoveFolder.Click += new System.EventHandler(this.tbRemoveFolder_Click);
            // 
            // tbRefresh
            // 
            this.tbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRefresh.Enabled = false;
            this.tbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbRefresh.Image")));
            this.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefresh.Name = "tbRefresh";
            this.tbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tbRefresh.Text = "Refresh File List";
            this.tbRefresh.Click += new System.EventHandler(this.tbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbOptions
            // 
            this.tbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tbOptions.Image")));
            this.tbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOptions.Name = "tbOptions";
            this.tbOptions.Size = new System.Drawing.Size(23, 22);
            this.tbOptions.Text = "Options...";
            this.tbOptions.Click += new System.EventHandler(this.tbOptions_Click);
            // 
            // tbBuild
            // 
            this.tbBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBuild.Enabled = false;
            this.tbBuild.Image = ((System.Drawing.Image)(resources.GetObject("tbBuild.Image")));
            this.tbBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBuild.Name = "tbBuild";
            this.tbBuild.Size = new System.Drawing.Size(23, 22);
            this.tbBuild.Text = "Build Project";
            this.tbBuild.Click += new System.EventHandler(this.BuildClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status,
            this.progress});
            this.statusStrip.Location = new System.Drawing.Point(0, 521);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(772, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // progress
            // 
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(100, 16);
            this.progress.Visible = false;
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "jsb";
            this.openDialog.Filter = "JS Builder Projects|*.jsb";
            this.openDialog.InitialDirectory = "c:\\";
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "jsb";
            this.saveDialog.FileName = "project1";
            this.saveDialog.Filter = "JS Builder Projects|*.jsb";
            this.saveDialog.InitialDirectory = "c:\\";
            // 
            // form
            // 
            this.form.Controls.Add(this.splitContainer1);
            this.form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form.Enabled = false;
            this.form.Location = new System.Drawing.Point(0, 49);
            this.form.Name = "form";
            this.form.Padding = new System.Windows.Forms.Padding(4);
            this.form.Size = new System.Drawing.Size(772, 472);
            this.form.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(764, 464);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseDown);
            this.splitContainer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.files);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 464);
            this.panel1.TabIndex = 2;
            // 
            // files
            // 
            this.files.AllowDrop = true;
            this.files.CheckBoxes = true;
            this.files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.files.ImageIndex = 0;
            this.files.ImageList = this.images;
            this.files.Location = new System.Drawing.Point(0, 0);
            this.files.Name = "files";
            this.files.SelectedImageIndex = 0;
            this.files.ShowLines = false;
            this.files.Size = new System.Drawing.Size(251, 464);
            this.files.TabIndex = 6;
            this.files.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.files_AfterCheck);
            this.files.DragDrop += new System.Windows.Forms.DragEventHandler(this.files_DragDrop);
            this.files.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.files_AfterSelect);
            this.files.DragEnter += new System.Windows.Forms.DragEventHandler(this.files_DragEnter);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "event_log.gif");
            this.images.Images.SetKeyName(1, "folder.gif");
            this.images.Images.SetKeyName(2, "folder_open.gif");
            this.images.Images.SetKeyName(3, "newmodule.gif");
            this.images.Images.SetKeyName(4, "props.gif");
            this.images.Images.SetKeyName(5, "treeview.gif");
            this.images.Images.SetKeyName(6, "x.gif");
            this.images.Images.SetKeyName(7, "build.gif");
            this.images.Images.SetKeyName(8, "save.gif");
            this.images.Images.SetKeyName(9, "script.gif");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 464);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.projectTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(509, 464);
            this.tabControl1.TabIndex = 1;
            // 
            // projectTab
            // 
            this.projectTab.Controls.Add(this.panel3);
            this.projectTab.Location = new System.Drawing.Point(4, 22);
            this.projectTab.Name = "projectTab";
            this.projectTab.Padding = new System.Windows.Forms.Padding(3);
            this.projectTab.Size = new System.Drawing.Size(501, 438);
            this.projectTab.TabIndex = 0;
            this.projectTab.Text = "Project Settings";
            this.projectTab.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(495, 432);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtVersion, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtCopy, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtAuthor, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(475, 412);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Author:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.Location = new System.Drawing.Point(74, 55);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(398, 20);
            this.txtVersion.TabIndex = 3;
            this.txtVersion.Text = "1.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Header:";
            // 
            // txtCopy
            // 
            this.txtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopy.Location = new System.Drawing.Point(74, 81);
            this.txtCopy.Multiline = true;
            this.txtCopy.Name = "txtCopy";
            this.txtCopy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCopy.Size = new System.Drawing.Size(398, 328);
            this.txtCopy.TabIndex = 4;
            this.txtCopy.Text = "$projectName\r\nCopyright(c) 2006, $author.\r\n\r\nThis code is licensed under BSD lice" +
                "nse. Use it as you wish, \r\nbut keep this copyright intact.";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.Location = new System.Drawing.Point(74, 29);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(398, 20);
            this.txtAuthor.TabIndex = 2;
            this.txtAuthor.Text = "Your Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(74, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(398, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "New Project 1";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(501, 438);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Build Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtOutput);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.targets);
            this.panel4.Controls.Add(this.cbDoc);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtSource);
            this.panel4.Controls.Add(this.txtBuild);
            this.panel4.Controls.Add(this.txtDocs);
            this.panel4.Controls.Add(this.cbSource);
            this.panel4.Controls.Add(this.cbBuild);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 432);
            this.panel4.TabIndex = 31;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(18, 37);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(372, 20);
            this.txtOutput.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Output Directory:";
            // 
            // targets
            // 
            this.targets.AllowColumnReorder = true;
            this.targets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.targets.FullRowSelect = true;
            this.targets.HideSelection = false;
            this.targets.Location = new System.Drawing.Point(18, 236);
            this.targets.MultiSelect = false;
            this.targets.Name = "targets";
            this.targets.Size = new System.Drawing.Size(372, 180);
            this.targets.SmallImageList = this.images;
            this.targets.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.targets.TabIndex = 8;
            this.targets.UseCompatibleStateImageBehavior = false;
            this.targets.View = System.Windows.Forms.View.Details;
            this.targets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.targets_MouseDoubleClick);
            this.targets.SelectedIndexChanged += new System.EventHandler(this.targets_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "File";
            this.columnHeader4.Width = 172;
            // 
            // cbDoc
            // 
            this.cbDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDoc.AutoSize = true;
            this.cbDoc.Checked = true;
            this.cbDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDoc.Location = new System.Drawing.Point(18, 113);
            this.cbDoc.Name = "cbDoc";
            this.cbDoc.Size = new System.Drawing.Size(373, 17);
            this.cbDoc.TabIndex = 4;
            this.cbDoc.Text = "Run JS Doc on the source files and copy output to the following directory:";
            this.cbDoc.UseVisualStyleBackColor = true;
            this.cbDoc.CheckedChanged += new System.EventHandler(this.cbDoc_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Combine compressed files to create specific output files:";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(18, 87);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(372, 20);
            this.txtSource.TabIndex = 3;
            this.txtSource.Text = "$output\\source";
            // 
            // txtBuild
            // 
            this.txtBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuild.Location = new System.Drawing.Point(18, 185);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Size = new System.Drawing.Size(372, 20);
            this.txtBuild.TabIndex = 7;
            this.txtBuild.Text = "$output\\build";
            // 
            // txtDocs
            // 
            this.txtDocs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocs.Location = new System.Drawing.Point(18, 136);
            this.txtDocs.Name = "txtDocs";
            this.txtDocs.Size = new System.Drawing.Size(372, 20);
            this.txtDocs.TabIndex = 5;
            this.txtDocs.Text = "$output\\docs";
            // 
            // cbSource
            // 
            this.cbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSource.AutoSize = true;
            this.cbSource.Checked = true;
            this.cbSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSource.Location = new System.Drawing.Point(18, 66);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(226, 17);
            this.cbSource.TabIndex = 2;
            this.cbSource.Text = "Copy source files to the following directory:";
            this.cbSource.UseVisualStyleBackColor = true;
            this.cbSource.CheckedChanged += new System.EventHandler(this.cbSource_CheckedChanged);
            // 
            // cbBuild
            // 
            this.cbBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBuild.AutoSize = true;
            this.cbBuild.Checked = true;
            this.cbBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBuild.Location = new System.Drawing.Point(18, 162);
            this.cbBuild.Name = "cbBuild";
            this.cbBuild.Size = new System.Drawing.Size(339, 17);
            this.cbBuild.TabIndex = 6;
            this.cbBuild.Text = "Compress the source files and copy them to the following directory:";
            this.cbBuild.UseVisualStyleBackColor = true;
            this.cbBuild.CheckedChanged += new System.EventHandler(this.cbBuild_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnOutputBrowse);
            this.panel5.Controls.Add(this.btnAddTarget);
            this.panel5.Controls.Add(this.btnCopy);
            this.panel5.Controls.Add(this.btnRemoveTarget);
            this.panel5.Controls.Add(this.btnModifyTarget);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(410, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(88, 432);
            this.panel5.TabIndex = 32;
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(3, 35);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOutputBrowse.TabIndex = 1;
            this.btnOutputBrowse.Text = "Browse";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // btnAddTarget
            // 
            this.btnAddTarget.Location = new System.Drawing.Point(0, 236);
            this.btnAddTarget.Name = "btnAddTarget";
            this.btnAddTarget.Size = new System.Drawing.Size(75, 23);
            this.btnAddTarget.TabIndex = 9;
            this.btnAddTarget.Text = "New...";
            this.btnAddTarget.UseVisualStyleBackColor = true;
            this.btnAddTarget.Click += new System.EventHandler(this.btnAddOutFile_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(0, 292);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 11;
            this.btnCopy.Text = "Copy...";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRemoveTarget
            // 
            this.btnRemoveTarget.Enabled = false;
            this.btnRemoveTarget.Location = new System.Drawing.Point(0, 320);
            this.btnRemoveTarget.Name = "btnRemoveTarget";
            this.btnRemoveTarget.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveTarget.TabIndex = 12;
            this.btnRemoveTarget.Text = "Remove";
            this.btnRemoveTarget.UseVisualStyleBackColor = true;
            this.btnRemoveTarget.Click += new System.EventHandler(this.btnRemoveTarget_Click);
            // 
            // btnModifyTarget
            // 
            this.btnModifyTarget.Enabled = false;
            this.btnModifyTarget.Location = new System.Drawing.Point(0, 264);
            this.btnModifyTarget.Name = "btnModifyTarget";
            this.btnModifyTarget.Size = new System.Drawing.Size(75, 23);
            this.btnModifyTarget.TabIndex = 10;
            this.btnModifyTarget.Text = "Edit...";
            this.btnModifyTarget.UseVisualStyleBackColor = true;
            this.btnModifyTarget.Click += new System.EventHandler(this.btnModifyTarget_Click);
            // 
            // filesCtx
            // 
            this.filesCtx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnRemove,
            this.toolStripSeparator4,
            this.mnAdd});
            this.filesCtx.Name = "filesCtx";
            this.filesCtx.Size = new System.Drawing.Size(158, 54);
            // 
            // mnRemove
            // 
            this.mnRemove.Image = ((System.Drawing.Image)(resources.GetObject("mnRemove.Image")));
            this.mnRemove.Name = "mnRemove";
            this.mnRemove.Size = new System.Drawing.Size(157, 22);
            this.mnRemove.Text = "Remove Folder";
            this.mnRemove.Click += new System.EventHandler(this.tbRemoveFolder_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // mnAdd
            // 
            this.mnAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnAdd.Image")));
            this.mnAdd.Name = "mnAdd";
            this.mnAdd.Size = new System.Drawing.Size(157, 22);
            this.mnAdd.Text = "Add Folder";
            this.mnAdd.Click += new System.EventHandler(this.tbFolder_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.checkBox1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.checkBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBox3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox4, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBox3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBox4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(67, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(394, 158);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 107);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Master File:";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(3, 30);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(63, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "Source:";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "$output\\yui-ext.js";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(103, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 20);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "$output\\build";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(103, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(288, 20);
            this.textBox3.TabIndex = 20;
            this.textBox3.Text = "$output\\source";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(103, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(288, 20);
            this.textBox4.TabIndex = 21;
            this.textBox4.Text = "$output\\docs";
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(3, 82);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(52, 17);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "Build:";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(3, 56);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(61, 17);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.Text = "JSDoc:";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(103, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(288, 20);
            this.textBox5.TabIndex = 18;
            this.textBox5.Text = "$projectDir\\build\\";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Output Directory:";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(158, 6);
            // 
            // mnRecentProjects
            // 
            this.mnRecentProjects.Name = "mnRecentProjects";
            this.mnRecentProjects.Size = new System.Drawing.Size(161, 22);
            this.mnRecentProjects.Text = "Recent Projects";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 543);
            this.Controls.Add(this.form);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 515);
            this.Name = "MainForm";
            this.Text = "JS Builder";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.form.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.projectTab.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.filesCtx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Panel form;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage projectTab;
        private System.Windows.Forms.ToolStripButton tbNew;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton tbBuild;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnWebSite;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.ToolStripMenuItem mnNew;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnBuild;
        private System.Data.DataSet dataSet;
        private System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckBox cbSource;
        private System.Windows.Forms.TextBox txtBuild;
        private System.Windows.Forms.CheckBox cbDoc;
        private System.Windows.Forms.TextBox txtDocs;
        private System.Windows.Forms.CheckBox cbBuild;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripMenuItem mnOptions;
        private System.Windows.Forms.ToolStripButton tbOptions;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView targets;
        private System.Windows.Forms.Button btnRemoveTarget;
        private System.Windows.Forms.Button btnAddTarget;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.FolderBrowserDialog folders;
        private System.Windows.Forms.Button btnModifyTarget;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tbFolder;
        private System.Windows.Forms.ToolStripButton tbRemoveFolder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCopy;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TreeView files;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ContextMenuStrip filesCtx;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem mnRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnAdd;
		private System.Windows.Forms.ToolStripMenuItem mnuExtjsWebsite;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnRecentProjects;

    }
}


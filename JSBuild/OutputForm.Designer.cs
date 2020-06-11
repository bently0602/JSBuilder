namespace JSBuild
{
    partial class OutputForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputForm));
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.incs = new JSBuild.DDListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.files = new JSBuild.DDListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.debug = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.txtList = new System.Windows.Forms.TextBox();
			this.cbWrap = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(84, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(594, 20);
			this.txtName.TabIndex = 1;
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(84, 46);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(594, 20);
			this.txtFile.TabIndex = 2;
			this.txtFile.TextChanged += new System.EventHandler(this.txtFile_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Output File:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Project Files:";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(526, 6);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(607, 6);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(4, 4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(705, 415);
			this.tabControl1.TabIndex = 10;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tableLayoutPanel1);
			this.tabPage1.Controls.Add(this.debug);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtName);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.txtFile);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(697, 389);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Target Properties";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.incs, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.files, 0, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 101);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 269);
			this.tableLayoutPanel1.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.label7, 2);
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.Location = new System.Drawing.Point(3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(652, 39);
			this.label7.TabIndex = 14;
			this.label7.Text = resources.GetString("label7.Text");
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(332, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Included Files:";
			// 
			// incs
			// 
			this.incs.AllowDrop = true;
			this.incs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
			this.incs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.incs.FullRowSelect = true;
			this.incs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.incs.HideSelection = false;
			this.incs.LabelWrap = false;
			this.incs.Location = new System.Drawing.Point(332, 67);
			this.incs.Name = "incs";
			this.incs.ShowGroups = false;
			this.incs.Size = new System.Drawing.Size(323, 199);
			this.incs.SmallImageList = this.images;
			this.incs.TabIndex = 5;
			this.incs.UseCompatibleStateImageBehavior = false;
			this.incs.View = System.Windows.Forms.View.Details;
			this.incs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.incs_MouseDoubleClick);
			this.incs.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView2_DragEnter);
			this.incs.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView2_DragDrop);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "File Name";
			this.columnHeader3.Width = 121;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Full Path";
			this.columnHeader4.Width = 278;
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
			// files
			// 
			this.files.AllowDrop = true;
			this.files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.files.FullRowSelect = true;
			this.files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.files.HideSelection = false;
			this.files.LabelWrap = false;
			this.files.Location = new System.Drawing.Point(3, 67);
			this.files.Name = "files";
			this.files.ShowGroups = false;
			this.files.Size = new System.Drawing.Size(323, 199);
			this.files.SmallImageList = this.images;
			this.files.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.files.TabIndex = 4;
			this.files.UseCompatibleStateImageBehavior = false;
			this.files.View = System.Windows.Forms.View.Details;
			this.files.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.files_MouseDoubleClick);
			this.files.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
			this.files.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File Name";
			this.columnHeader1.Width = 122;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Full Path";
			this.columnHeader2.Width = 278;
			// 
			// debug
			// 
			this.debug.AutoSize = true;
			this.debug.Location = new System.Drawing.Point(84, 73);
			this.debug.Name = "debug";
			this.debug.Size = new System.Drawing.Size(337, 17);
			this.debug.TabIndex = 3;
			this.debug.Text = "Create uncompressed debug file (only applies to javascript targets)";
			this.debug.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(0, 13);
			this.label5.TabIndex = 12;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.txtList);
			this.tabPage2.Controls.Add(this.cbWrap);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(697, 389);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Experimental";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 43);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(175, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Shorthand Definitions (one per line):";
			// 
			// txtList
			// 
			this.txtList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtList.Enabled = false;
			this.txtList.Location = new System.Drawing.Point(20, 59);
			this.txtList.Multiline = true;
			this.txtList.Name = "txtList";
			this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtList.Size = new System.Drawing.Size(658, 312);
			this.txtList.TabIndex = 1;
			// 
			// cbWrap
			// 
			this.cbWrap.AutoSize = true;
			this.cbWrap.Enabled = false;
			this.cbWrap.Location = new System.Drawing.Point(18, 17);
			this.cbWrap.Name = "cbWrap";
			this.cbWrap.Size = new System.Drawing.Size(389, 17);
			this.cbWrap.TabIndex = 0;
			this.cbWrap.Text = "Wrap code in an anonymous function and define private shorthand variables.";
			this.cbWrap.UseVisualStyleBackColor = true;
			this.cbWrap.CheckedChanged += new System.EventHandler(this.cbWrap_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cancelButton);
			this.panel1.Controls.Add(this.okButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(4, 419);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(705, 39);
			this.panel1.TabIndex = 11;
			// 
			// OutputForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(713, 462);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(650, 450);
			this.Name = "OutputForm";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Output Target Properties";
			this.Load += new System.EventHandler(this.OutputForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList images;
        private DDListView incs;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private DDListView files;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cbWrap;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox debug;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label7;
    }
}
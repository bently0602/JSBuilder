using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using McGiv.Win32.Forms;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.Collections;

namespace JSBuild
{
    public partial class MainForm : Form
    {
        private Project project = Project.GetInstance();
        private Regex filter;
        private ProgressForm pform;
        private Boolean bound = false;

        public const string REGISTRY_KEY = @"Software\Slocum\JSBuilder";
        public MainForm(string startupProject)
        {
            InitializeComponent();
            //Positioning.Load(this,
             //                RegistryHive.CurrentUser, REGISTRY_KEY);
			Options.GetInstance().Load(Application.ExecutablePath);
			if (Options.GetInstance().Reopen && startupProject == null)
            {
				startupProject = Options.GetInstance().LastProject;
            }
            if(startupProject != null)
            {
                FileInfo fi = new FileInfo(startupProject);
                if(fi.Exists)
                {
					project.Load(Application.ExecutablePath, startupProject);
                    LoadProject();
                }
            }

            LoadRecentItems();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
			//Util.RegisterExtension(Application.ExecutablePath);

			ProjectBuilder.ProgressUpdate += new ProgressDelegate(ProjectBuilder_ProgressUpdated);
			ProjectBuilder.MessageAvailable += new MessageDelegate(ProjectBuilder_MessageAvailable);
			ProjectBuilder.BuildComplete += new BuildCompleteDelegate(ProjectBuilder_BuildComplete);
        }

        private void BindFields()
        {
            BindHelper.Bind(txtName, "Text", project, "Name");
            BindHelper.Bind(txtAuthor,"Text", project, "Author");
            BindHelper.Bind(txtVersion, "Text", project, "Version");
            BindHelper.Bind(txtOutput, "Text", project, "Output");
            BindHelper.Bind(txtCopy, "Text", project, "Copyright");
            BindHelper.Bind(txtSource, "Text", project, "SourceDir");
            BindHelper.Bind(txtDocs, "Text", project, "DocDir");
            BindHelper.Bind(txtBuild, "Text", project, "MinDir");
            BindHelper.Bind(cbSource, "Checked", project, "Source");
            BindHelper.Bind(cbDoc, "Checked", project, "Doc");
            BindHelper.Bind(cbBuild, "Checked", project, "Minify");
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog(this);
        }

        private void LoadFiles()
        {
			string output = Util.FixPath(Util.ApplyVars(project.Output, "", project));
			string[] userVals = Options.GetInstance().Filter.Split(';', ',', '|');
            string regex = "";
            foreach(string v in userVals)
            {
                if(v.Length > 0)
                    regex += Regex.Escape(Util.ApplyVars(v.Trim(), output, project)) + "|";
            }
            regex += "^w-t-f$"; // match nothing
            filter = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ECMAScript);
            files.BeginUpdate();
            files.Nodes.Clear();
			string outputDir = Util.FixPath(Util.ApplyVars(txtOutput.Text, "", project));
            foreach(DirectoryInfo di in project.SelectedDirectories)
            {
                LoadDir(null, di, true, di);
            }

            files.EndUpdate();
            LoadTargets();
        }

        private bool LoadDir(TreeNode parent, DirectoryInfo dir, bool fullName, DirectoryInfo root)
        {
            if(filter.IsMatch(Util.FixPath(dir.FullName)) || filter.IsMatch(Util.FixPath(dir.Name)))
            {
				return false;
            }

            TreeNode dirNode = new FileNode(fullName ? dir.FullName : dir.Name, 1, dir.FullName, dir, root);
            DirectoryInfo[] childDirs = dir.GetDirectories();
			bool allSubdirsChecked = true;

            foreach(DirectoryInfo d in childDirs)
            {
				allSubdirsChecked &= LoadDir(dirNode, d, false, root);
            }

			TreeDirectoryInfo tdInfo = LoadFiles(dir, root, dirNode);
			if (tdInfo.fileCount > 0)
			{
				dirNode.Checked = (allSubdirsChecked && tdInfo.allFilesSelected);
				if (!tdInfo.allFilesSelected && tdInfo.selectedFileCount > 0)
				{
					// expand the node automatically if some, but not all, files are 
					// checked since the tree node will be unchecked but will still 
					// contain checked files.
					dirNode.Expand();
				}
			}
			else
			{
				dirNode.Checked = allSubdirsChecked;
			}

			foreach (TreeNode node in dirNode.Nodes)
			{
				if (node.IsExpanded)
				{
					// if a child node is expanded, then assume that it already has at least one
					// selected file in the hierarchy.  Even if there are no selected files
					// at this level in the tree, we still want to expand to show nested selections.
					dirNode.Expand();
					break;
				}
			}

			if (tdInfo.fileCount > 0 || dirNode.Nodes.Count > 0)
			{
				if (parent == null)
				{
					files.Nodes.Add(dirNode);
					// always expand the root node
					dirNode.Expand();
				}
				else
				{
					parent.Nodes.Add(dirNode);
				}
			}

			return dirNode.Checked;
        }

		private class TreeDirectoryInfo
		{
			internal int fileCount = 0;
			internal int selectedFileCount = 0;
			internal bool allFilesSelected
			{
				get { return fileCount == selectedFileCount; }
			}
		}

		private TreeDirectoryInfo LoadFiles(DirectoryInfo dir, DirectoryInfo root, TreeNode dirNode)
		{
			TreeDirectoryInfo tdInfo = new TreeDirectoryInfo();
			string[] filter = Options.GetInstance().Files.Split(';', ',', '|');
			FileInfo[] files = { };

			foreach (string pattern in filter)
			{
				if (pattern.Length > 0)
				{
					FileInfo[] matches = GetFiles(dir, pattern);
					if (matches.Length > 0)
					{
						//BPM: changed logic to grab ub first so the insert is at the correct index after resize
						//      to fix crash bug anytime more than one file type was matched separately in the same dir
						int ub = files.GetUpperBound(0);
						Array.Resize(ref files, files.Length + matches.Length);
						matches.CopyTo(files, (files[0] == null ? 0 : ub + 1));
					}
				}
			}

			if (Options.GetInstance().Files != project.FileFilter)
			{
			    //The filter has changed, so we need to remove any items that may still be in the project
			    //that no longer match the new filter criteria.
			    string[] oldFilter = project.FileFilter.Split(';', ',', '|');
				foreach (string oldPattern in oldFilter)
				{
					bool remove = true;
					foreach (string pattern in filter)
					{
						if (pattern == oldPattern)
						{
							remove = false;
							break;
						}
					}
					if (remove)
					{
						//Old pattern is not in the new filter, so remove matching files
						FileInfo[] oldFiles = GetFiles(dir, oldPattern);
						foreach (FileInfo fi in oldFiles)
						{
							project.RemoveFile(project.GetPath(fi.FullName));
						}
					}
				}
			}

			foreach (FileInfo f in files)
			{
				tdInfo.fileCount++;
				TreeNode fileNode = new FileNode(f.Name, 9, f.FullName, f, root);
				fileNode.Checked = project.IsSelected(project.GetPath(f.FullName));
				dirNode.Nodes.Add(fileNode);

				if (fileNode.Checked)
				{
					tdInfo.selectedFileCount++;
				}
			}
			return tdInfo;
		}

		private FileInfo[] GetFiles(DirectoryInfo dir, string filePattern)
		{
			FileInfo[] files = { };
			try
			{
				files = dir.GetFiles(filePattern);
			}
			catch { }

			return files;
		}

		private void LoadTargets()
		{
			List<Target> ts = project.GetTargets(false);
			targets.BeginUpdate();
			targets.Items.Clear();
			foreach (Target t in ts)
			{
				targets.Items.Add(t.Name, t.Name, 9).SubItems.Add(t.File);
			}
			targets.EndUpdate();
			btnRemoveTarget.Enabled = btnCopy.Enabled = btnModifyTarget.Enabled = (targets.SelectedItems.Count > 0);
		}

        private void tbNew_Click(object sender, EventArgs e)
        {
            if(SaveProject() == DialogResult.Cancel)
            {
                return;
            }
            ProjectForm pf = new ProjectForm();
            if(pf.ShowDialog(this) == DialogResult.OK)
            {
                LoadProject();
            }
        }

        private void LoadProject()
        {
            AddToRecentItems();
            LoadFiles();
            form.Enabled = true;
            tbSave.Enabled = true;
            tbFolder.Enabled = true;
            tbRefresh.Enabled = true;
            tbBuild.Enabled = true;
            mnBuild.Enabled = true;
            mnSave.Enabled = true;
            if(!bound)
            {
                BindFields();
                bound = true;
            }
			SetFormCaption();
        }

		private void SetFormCaption()
		{
			this.Text = "JS Builder " + Application.ProductVersion + " - [" + project.FileName + "]";
		}

        private void tbOpen_Click(object sender, EventArgs e)
        {
            if(SaveProject() == DialogResult.Cancel)
            {
                return;
            }
			string lastFile = Options.GetInstance().LastProject;
            if(lastFile != null && File.Exists(lastFile))
            {
                openDialog.FileName = lastFile;
            }
            if(openDialog.ShowDialog(this) == DialogResult.OK)
            {
				Options.GetInstance().LastProject = openDialog.FileName;
				project.Load(Application.ExecutablePath, openDialog.FileName);
                LoadProject();
            }
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            project.Save();
            status.Text = "Project saved to " + project.FileName;
			SetFormCaption();
        }

        private void files_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //e.Node.Checked = e.Node.IsSelected;
            tbRemoveFolder.Enabled = mnRemove.Enabled = (e.Node.Parent == null);
        }

        private void files_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool state = e.Node.Checked;
            FileNode node = (FileNode)e.Node;
            if(state && !node.IsDir)
            {
                project.AddFile(project.GetPath(node.FilePath), Path.RelativePathTo(node.Root.FullName, node.FileInfo.DirectoryName));
            }
            else if(!state && !node.IsDir)
            {
                project.RemoveFile(project.GetPath(node.FilePath));
            }
            files.BeginUpdate();
            foreach(TreeNode c in node.Nodes)
            {
                c.Checked = state;
            }
            if(node.Parent != null && node.Parent.Checked != state)
            {
                bool allMatch = true;
                foreach(TreeNode c in node.Parent.Nodes)
                {
                    if(c.Checked != state)
                    {
                        allMatch = false;
                        break;
                    }
                }
                if(allMatch)
                {
                    node.Parent.Checked = state;
                }
            }
            files.EndUpdate();
        }

        private void propagateCheck(TreeNode node, bool state)
        {
            node.Checked = state;
            foreach(TreeNode c in node.Nodes)
            {
                propagateCheck(c, state);
            }
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnWebSite_Click(object sender, EventArgs e)
        {
			LaunchWebsite("http://code.google.com/p/js-builder/");
        }

		private void mnuExtjsWebsite_Click(object sender, EventArgs e)
		{
			LaunchWebsite("http://www.extjs.com/");
		}

		private void LaunchWebsite(string url)
		{
			try
			{
				//This will attempt to use the system default browser
				System.Diagnostics.Process.Start(url);
			}
			catch
			{
				MessageBox.Show("There was a problem starting your web browser.", "JS Builder", 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

        protected DialogResult SaveProject()
        {
            if(project.FileName != null && project.IsChanged())
            {
				if (Options.GetInstance().AutoSave)
                {
                    project.Save();
                    return DialogResult.OK;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Save Changes to " + project.Name+ "?", "Save Project?", 
						MessageBoxButtons.YesNoCancel);

                    if(res == DialogResult.OK)
                    {
                        project.Save();
                    }
                    return res;
                }
            }
            return DialogResult.OK;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(SaveProject() == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
			Options.GetInstance().Save(Application.ExecutablePath);
            // save position and size
           // Positioning.Save(this, RegistryHive.CurrentUser, REGISTRY_KEY);

        }

        private void tbRefresh_Click(object sender, EventArgs e)
        {
			RefreshTree();
        }

		private void RefreshTree()
		{
			LoadFiles();
			Project.GetInstance().FileFilter = Options.GetInstance().Files;
			tbRemoveFolder.Enabled = false;
		}

		private void Build()
		{
			try
			{
				ProjectBuilder.Build(project);
			}
			catch (Exception ex)
			{
				MessageBox.Show("An unhandled exception occurred while building:\n" + ex.ToString(), 
					"JS Builder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				status.Text = "Build failed";
				this.Invoke(new ProgressForm.CloseDelegate(pform.Close));
			}
		}

		#region ProjectBuilder event handlers

		void ProjectBuilder_ProgressUpdated(ProgressInfo progressInfo)
		{
			ProgressForm.SetValueDelegate d = new ProgressForm.SetValueDelegate(pform.SetValues);
			this.Invoke(d, progressInfo.Percent, progressInfo.Message);
		}

		void ProjectBuilder_MessageAvailable(Message message)
		{
			switch (message.Type)
			{
				case MessageTypes.Info:
					MessageBox.Show(message.Text, "JS Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;

				case MessageTypes.Error:
					MessageBox.Show(message.Text, "JS Builder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					status.Text = "Build failed";
					this.Invoke(new ProgressForm.CloseDelegate(pform.Close));
					break;

				case MessageTypes.Status:
					status.Text = message.Text;
					break;
			}
		}

		void ProjectBuilder_BuildComplete()
		{
			status.Text = "Build completed successfully!";
			this.Invoke(new ProgressForm.CloseDelegate(pform.Close));
		}
		#endregion
		

		private void BuildClick(object sender, EventArgs e)
		{
			if (project.SelectedFiles.Count < 1)
			{
				MessageBox.Show("The project doesn't contain any files to build.", "JS Builder",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			status.Text = "";
			pform = new ProgressForm();
			pform.Text = "Building " + project.Name;
			Thread t = new Thread(new ThreadStart(Build));
			t.Start();
			pform.ShowDialog(this);
		}

		private void tbOptions_Click(object sender, EventArgs e)
        {
			string origFileFilter = Options.GetInstance().Files;
            OptionsForm o = new OptionsForm();

			if (o.ShowDialog(this) == DialogResult.OK)
			{
				if (origFileFilter != Options.GetInstance().Files)
				{
					RefreshTree();
				}
			}
        }

        private void btnAddOutFile_Click(object sender, EventArgs e)
        {
			OutputForm o = new OutputForm(null);
			o.ShowDialog(this);
			LoadTargets();
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(txtOutput.Text);
            if(d.Exists)
            {
                folders.SelectedPath = d.FullName;
            }
            else
            {
                folders.SelectedPath = project.ProjectDir.FullName;
            }
            if(folders.ShowDialog(this) == DialogResult.OK)
            {
                txtOutput.Text = folders.SelectedPath;
            }
        }

        private void tbFolder_Click(object sender, EventArgs e)
        {
            folders.SelectedPath = project.ProjectDir.FullName;
            if(folders.ShowDialog(this) == DialogResult.OK)
            {
                //project.AddDirectory(Path.RelativePathTo(project.ProjectDir.FullName, folders.SelectedPath));
				AddSourceDirectory(folders.SelectedPath);
                LoadFiles();
            }
        }

        private void tbRemoveFolder_Click(object sender, EventArgs e)
        {
            if(files.SelectedNode != null)
            {
                files.SelectedNode.Checked = false;
                project.RemoveDirectory(project.GetPath(((FileNode)files.SelectedNode).FilePath));
                tbRemoveFolder.Enabled = false;
                LoadFiles();
            }
        }

        private void targets_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveTarget.Enabled = btnCopy.Enabled = btnModifyTarget.Enabled = (targets.SelectedItems.Count > 0);
        }

        private void btnModifyTarget_Click(object sender, EventArgs e)
        {
			Target target = GetTarget(targets.SelectedItems[0].Name);
			if (target != null)
			{
				OutputForm o = new OutputForm(target);
				o.ShowDialog(this);
				LoadTargets();
			}
        }

        private void btnRemoveTarget_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to remove this target?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                project.RemoveTarget(targets.SelectedItems[0].Name);
                LoadTargets();
            }
        }

        private void cbSource_CheckedChanged(object sender, EventArgs e)
        {
            txtSource.Enabled = cbSource.Checked;
        }

        private void cbDoc_CheckedChanged(object sender, EventArgs e)
        {
            txtDocs.Enabled = cbDoc.Checked;
        }

        private void cbBuild_CheckedChanged(object sender, EventArgs e)
        {
            txtBuild.Enabled = cbBuild.Checked;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Target target = GetTarget(targets.SelectedItems[0].Name);
			if (target != null)
			{
				target.Name = "Copy of " + target.Name;
				OutputForm o = new OutputForm(target);
				o.ShowDialog(this);
				LoadTargets();
			}
        }

		private Target GetTarget(string name)
		{
			Target t = project.GetTarget(name);

			if (t == null || t.Includes == null)
			{
				MessageBox.Show("The files included in this target are no longer valid.  Either remove and re-add this target or update your file list.",
					"JS Builder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null;
			}
			else
			{
				return t;
			}
		}

        #region Splitter focus stealing code
        private Control focused = null;

        private void splitContainer_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the focused control before the splitter is focused
            focused = getFocused(this.Controls);
        }

        private Control getFocused(Control.ControlCollection controls)
        {
            foreach(Control c in controls)
            {
                if(c.Focused)
                {
                    // Return the focused control
                    return c;
                }
                else if(c.ContainsFocus)
                {
                    // If the focus is contained inside a control's children
                    // return the child
                    return getFocused(c.Controls);
                }
            }
            // No control on the form has focus
            return null;
        }

        private void splitContainer_MouseUp(object sender, MouseEventArgs e)
        {
            // If a previous control had focus
            if(focused != null)
            {
                // Return focus and clear the temp variable for 
                // garbage collection
                focused.Focus();
                focused = null;
            }
        }
        #endregion

        private void targets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickItem = targets.GetItemAt(e.X, e.Y);
			if (clickItem != null)
			{
				Target target = GetTarget(clickItem.Name);
				if (target != null)
				{
					OutputForm o = new OutputForm(target);
					o.ShowDialog(this);
					LoadTargets();
				}
			}
        }

        private void files_DragEnter(object sender, DragEventArgs e)
        {
            if(!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach(string file in files)
            {
                DirectoryInfo d = new DirectoryInfo(file);
                if(d.Exists)
                {
                    e.Effect = DragDropEffects.Link;
                }
            }
        }

        private void files_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach(string file in files)
            {
                DirectoryInfo d = new DirectoryInfo(file);
                if(d.Exists)
                {
					try
					{
						AddSourceDirectory(d.FullName);
					}
					catch (Exception ex)
					{
						//HACK: This should not be necessary if we properly support 
						//adding absolute paths with drive letters
						if (ex.Message.Contains("different path roots"))
						{
							MessageBox.Show("You cannot add files located on a different drive.  For example, " +
								"if your JS Builder project is on C:, you cannot add files from D:.", "JS Builder");
						}
						else
						{
							MessageBox.Show("The folder(s) could not be added because of the following error: " + 
								ex.ToString(), "JS Builder Error");
						}
					}
                }
            }
            LoadFiles();
        }

		private void AddSourceDirectory(string sourcePath)
		{
			try
			{
				project.AddDirectory(Path.RelativePathTo(project.ProjectDir.FullName, sourcePath));
			}
			catch (Exception ex)
			{
				//HACK: This should not be necessary if we properly support 
				//adding absolute paths with drive letters
				if (ex.Message.Contains("different path roots"))
				{
					MessageBox.Show("You cannot currently add files located on a different drive.  For example, " +
						"if your JS Builder project is on C:, you cannot add files from D:.  This will be fixed " +
						" in a future release.", "JS Builder");
				}
				else
				{
					MessageBox.Show("The folder(s) could not be added because of the following error: " +
						ex.ToString(), "JS Builder Error");
				}
			}
		}

        private void AddToRecentItems()
        {
            Options.GetInstance().AddRecentProject(project.FileName);
            Options.GetInstance().Save(Application.ExecutablePath);
            LoadRecentItems();
        }
        private void LoadRecentItems()
        {
            if (Options.GetInstance().RecentProjects != null && Options.GetInstance().RecentProjects.Count > 0)
            {
                this.mnRecentProjects.DropDownItems.Clear();
                foreach (string projectName in Options.GetInstance().RecentProjects)
                {
                    ToolStripMenuItem tsi = new ToolStripMenuItem();
                    tsi.Text = projectName;
                    tsi.Click += new EventHandler(tsi_Click);
                    this.mnRecentProjects.DropDownItems.Add(tsi);
                }
                    
            }
        }

        void tsi_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    string projectName = sender.ToString();
                    Options.GetInstance().LastProject = projectName;
                    project.Load(Application.ExecutablePath, projectName);
                    LoadProject();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Project File Name has incorrect format.", "JS Builder");
            }
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JSBuild
{
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
			string lastFile = Options.GetInstance().LastProject;
            if(lastFile != null)
            {
                string dir = new FileInfo(lastFile).Directory.FullName;
                txtPath.Text = dir + (dir.EndsWith("\\") ? "" : "\\") + "NewProject1.jsb";
            }
            else
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString();
                txtPath.Text = dir + (dir.EndsWith("\\") ? "" : "\\") + "NewProject1.jsb";
            }
            txtName.Text = "New Project 1";
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(txtPath.Text);
            if(file.Exists)
            {
                saveDialog.FileName = file.FullName;
            }
            else
            {
				string lastFile = Options.GetInstance().LastProject;
                if(lastFile != null)
                {
                    saveDialog.InitialDirectory = new FileInfo(lastFile).Directory.FullName;
                }
                else
                {
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString();
                }
            }
            if(saveDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = saveDialog.FileName;
            }
        }

        private void ValidateEntry()
        {
			if (txtPath.Text.Length > 0) // && new FileInfo(txtPath.Text).Directory.Exists)
			{
				if (txtName.Text.Length > 0)
				{
					okButton.Enabled = true;
					return;
				}
			}
			okButton.Enabled = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string filePath = txtPath.Text.Trim();
			DirectoryInfo path = Directory.GetParent(filePath);

			if (path == null)
			{
				MessageBox.Show("The File Name is not valid", "JS Builder Error", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!path.Exists)
			{
				DialogResult dr = MessageBox.Show("Directory '" + path.FullName + 
					"' does not exist.  Create it?", "JS Builder", MessageBoxButtons.OKCancel, 
					MessageBoxIcon.Question);

				if (dr == DialogResult.OK)
				{
					Directory.CreateDirectory(path.FullName);
				}
				else
				{
					return;
				}
			}

			filePath = filePath + (filePath.EndsWith(".jsb") ? "" : ".jsb");
			Options.GetInstance().LastProject = filePath;
			Project.GetInstance().Load(Application.ExecutablePath, Options.GetInstance().LastProject);
            Project.GetInstance().Name = txtName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ValidateEntry();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            ValidateEntry();
        }

   
    }

}
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
    public partial class OptionsForm : Form
    {
		Options options = Options.GetInstance();

        public OptionsForm()
        {
            InitializeComponent();
            txtPath.DataBindings.Add("Text", options, "JsdocPath");
            txtOptions.DataBindings.Add("Text", options, "JsdocArgs");
            txtFiles.DataBindings.Add("Text", options, "Files");
            txtFilter.DataBindings.Add("Text", options, "Filter");
            txtSuffix.DataBindings.Add("Text", options, "OutputSuffix");
            cbAutoSave.DataBindings.Add("Checked", options, "AutoSave");
            cbCalc.DataBindings.Add("Checked", options, "AutoCalc");
            cbReopen.DataBindings.Add("Checked", options, "Reopen");
            cbClearOutputDir.DataBindings.Add("Checked", options, "ClearOutputDir");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(txtPath.Text);
            if(file.Exists)
            {
                open.FileName = file.FullName;
            }
            else
            {
                open.InitialDirectory = "c:\\";
            }
            if(open.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = open.FileName;
				options.JsdocPath = open.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
			bool fileFilterChanged = (txtFiles.Text != options.Files);
			options.Save(Application.ExecutablePath);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
			options.Load(Application.ExecutablePath);
            this.Close();
        }

		private void btnResetDefaults_Click(object sender, EventArgs e)
		{
			options.ResetDefaults();

			txtPath.Text = options.JsdocPath;
			txtOptions.Text = options.JsdocArgs;
			txtFiles.Text = options.Files;
			txtFilter.Text = options.Filter;
			txtSuffix.Text = options.OutputSuffix;
			cbAutoSave.Checked = options.AutoSave;
			cbCalc.Checked = options.AutoCalc;
			cbReopen.Checked = options.Reopen;
            cbClearOutputDir.Checked = options.ClearOutputDir;
		}
    }
}
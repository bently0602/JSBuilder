using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JSBuild
{
    public partial class ProgressForm : Form
    {
        public delegate void SetValueDelegate(int value, string text);
        public delegate void CloseDelegate();

        public ProgressForm()
        {
            InitializeComponent();
        }

        public int Progress
        {
            get { return pbar.Value; }
            set { pbar.Value = value; }
        }

        public string Label
        {
            get { return plabel.Text; }
            set { plabel.Text = value; }
        }

        public void SetValues(int value, string text)
        {
            pbar.Value = value;
            plabel.Text = text;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JSBuild
{
    public class FileNode : TreeNode
    {
        private string path;
        private bool isDir;
        private FileInfo fileInfo;

        public FileInfo FileInfo
        {
            get { return fileInfo; }
            set { fileInfo = value; }
        }
        private DirectoryInfo dirInfo;

        public DirectoryInfo DirInfo
        {
            get { return dirInfo; }
            set { dirInfo = value; }
        }
        private DirectoryInfo root;

        public DirectoryInfo Root
        {
            get { return root; }
            set { root = value; }
        }

        public string FilePath
        {
            get { return path; }
            set { path = value; }
        }

        public bool IsDir
        {
            get { return isDir; }
            set { isDir = value; }
        }

        public FileNode(string text, int imageIndex, string path, FileInfo fileInfo, DirectoryInfo root)
            : base(text, imageIndex, imageIndex)
        {
            this.path = path;
            this.isDir = false;
            this.fileInfo = fileInfo;
            this.root = root;
        }
        public FileNode(string text, int imageIndex, string path, DirectoryInfo dirInfo, DirectoryInfo root)
            : base(text, imageIndex, imageIndex)
        {
            this.path = path;
            this.isDir = true;
            this.dirInfo = dirInfo;
            this.root = root;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conductor
{
    public partial class Form1 : Form,I_Global
    {
        public event EventHandler<EventArgs> Close_Program;
        public event EventHandler<EventArgs> Open_Tree;
        public event EventHandler<EventArgs> Open_Folder_in_Tree;
        public event EventHandler<EventArgs> Edit_List_Viwe;
        public event EventHandler<EventArgs> Up;
        public event EventHandler<EventArgs> End;
        public event EventHandler<EventArgs> Move_;
        public event EventHandler<EventArgs> Start_program;
        public event EventHandler<EventArgs> Renewal;
        #region Pole
        List<string> full_Path_Note_List = new List<string>();
        List<string> name_Notee_List = new List<string>();
        public string Name_Note { set; get; }
        public string Full_Path_Note { set; get; }
        public List<string> Full_Path_Note_List { set { full_Path_Note_List = value; } get { return full_Path_Note_List; } }
        public List<string> Name_Notee_List { set { name_Notee_List = value; } get { return name_Notee_List; } }
        #endregion Pole

        public Form1()
        {
            InitializeComponent();
            Start_program?.Invoke(this, EventArgs.Empty);


            TreeNode node;


            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();
           
          //  foreach (string disk in astrLogicalDrives)
            //    node = treeViewPath1.Nodes.Add(disk);
          
            for (int x = 0; x < 3; ++x)
            {
                // Добавляем корневой узел
                node = treeViewPath1.Nodes.Add(String.Format("Node{0}", x * 4));
                for (int y = 1; y < 4; ++y)
                {
                    // Добавляем дочерние узлы 
                    node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y));
                }
            }

        }
        #region Button
        private void таблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonEnd_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonMove_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonUp_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonRenewal_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
        #endregion Button
        

       

        

        private void treeViewPath1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Name_Note = e.Node.Name;
            Full_Path_Note = e.Node.FullPath;

            Open_Tree?.Invoke(this, EventArgs.Empty);
        }
    }
}

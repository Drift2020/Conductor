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

        // 1 element , 2 name, 3 full path, 4 elements element's, 5 name, 6 full path


        List<int> name_Notee_element_List = new List<int>();
        List<string> full_Path_Note_List = new List<string>();
        List<string> name_Notee_List = new List<string>();


        public string Name_Note { set; get; }
        public string Full_Path_Note { set; get; }

        public List<string> Full_Path_Note_List { set { full_Path_Note_List = value; } get { return full_Path_Note_List; } }
        public List<string> Name_Notee_List { set { name_Notee_List = value; } get { return name_Notee_List; } }
        public List<int> Name_Notee_element_List { set { name_Notee_element_List = value; } get { return name_Notee_element_List; } }

        #endregion Pole
        private void Form1_Load(object sender, EventArgs e)
        {
            Start_program?.Invoke(this, EventArgs.Empty);

            TreeNode node;

            // string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();          
            for (int disk = 0; disk < name_Notee_List.Count; disk++)
            {
                node = treeViewPath1.Nodes.Add(name_Notee_List[disk]);

                if (name_Notee_element_List[disk] > 0)
                    node.Nodes.Add("1");
            }
        }
        public Form1()
        {
            InitializeComponent();
            
            //for (int x = 0; x < 3; ++x)
            //{
            //    // Добавляем корневой узел
            //    node = treeViewPath1.Nodes.Add(String.Format("Node{0}", x * 4));
            //    for (int y = 1; y < 4; ++y)
            //    {
            //        // Добавляем дочерние узлы 
            //        node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y));
            //    }
            //}
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
            

            TreeNode node;
            Name_Note = e.Node.Name;
            Full_Path_Note = e.Node.FullPath;

            Open_Tree?.Invoke(this, EventArgs.Empty);
            e.Node.Nodes.Clear();

            for (int i=0;i< name_Notee_List.Count;i++)
            {
                node=e.Node.Nodes.Add(name_Notee_List[i]);
                node.Name = name_Notee_List[i];

                if (name_Notee_element_List[i] > 0)
                    node.Nodes.Add("1");
            }


        }
        private void treeViewPath1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            bool i = false;
            if (e.Node.Nodes.Count > 0)
                i = !i;
            e.Node.Nodes.Clear();
            if (i)
            {
                e.Node.Nodes.Add("1");
            }
            Name_Notee_List.Clear();
            Full_Path_Note_List.Clear();
            Name_Notee_element_List.Clear();
        }

        private void treeViewPath1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Full_Path_Note = e.Node.FullPath;

            Open_Folder_in_Tree?.Invoke(this, EventArgs.Empty);


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Conductor
{

    public partial class Form1 : Form, I_Global
    {
        public event EventHandler<EventArgs> Close_Program;
        public event EventHandler<EventArgs> Open_Tree;
        public event EventHandler<EventArgs> Close_Tree;
        public event EventHandler<EventArgs> Remove_Die_Path;
        public event EventHandler<EventArgs> Open_Folder_in_Tree;
        public event EventHandler<EventArgs> Edit_List_Viwe;
        public event EventHandler<EventArgs> Up;
        public event EventHandler<EventArgs> End;
        public event EventHandler<EventArgs> Move_;
        public event EventHandler<EventArgs> Start_program;
        public event EventHandler<EventArgs> Renewal;
        #region Pole

        // 1 element , 2 name, 3 full path, 4 elements element's, 5 name, 6 full path
        ImageList list = new ImageList();
        
        bool start = true;
        List<int> name_Notee_element_List = new List<int>();
        List<string> full_Path_Note_List = new List<string>();
        List<string> name_Notee_element_List_Tree = new List<string>();
        List<string> name_Notee_List = new List<string>();

        public string[] str { set; get; }
        public string Name_Note { set; get; }
        public string Full_Path_Note { set; get; }
        

        public List<string> Full_Path_Note_List { set { full_Path_Note_List = value; } get { return full_Path_Note_List; } }
        public List<string> Name_Notee_List { set { name_Notee_List = value; } get { return name_Notee_List; } }
        public List<int> Name_Notee_element_List { set { name_Notee_element_List = value; } get { return name_Notee_element_List; } }
        public List<string> Name_Notee_element_List_Tree { set { name_Notee_element_List_Tree = value; } get { return name_Notee_element_List_Tree; } }
        #endregion Pole
        private void Form1_Load(object sender, EventArgs e)
        {
            Start_program?.Invoke(this, EventArgs.Empty);

            TreeNode node;

            // string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();          
            for (int disk = 0; disk < name_Notee_List.Count; disk++)
            {
                node = treeViewPath1.Nodes.Add(name_Notee_List[disk]);
                node.Name = name_Notee_List[disk];
                if (name_Notee_element_List[disk] > 0)
                    node.Nodes.Add("1");
            }


            Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
            if (str.Length == 0)
            {
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                    Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                System.Drawing.Icon icon = Icon.FromHandle(sh.hIcon);
                list.Images.Add(icon);
                listViewFolder1.Items.Add(sh.szDisplayName, i);
            }
        }
        public Form1()
        {
            InitializeComponent();
            list.ColorDepth = ColorDepth.Depth32Bit;
            list.ImageSize = new Size(32, 32);
            list.TransparentColor = Color.Transparent;

            listViewFolder1.LargeImageList = list;
           
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
            try
            {
                End?.Invoke(this, EventArgs.Empty);

                if (str != null)
                {
                 
                    list.Images.Clear();
                    listViewFolder1.Clear();

                    Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
                    if (str.Length == 0)
                    {
                        return;
                    }

                    for (int i = 0; i < str.Length; i++)
                    {
                        Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                            Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                        Icon icon = Icon.FromHandle(sh.hIcon);
                        list.Images.Add(icon);
                        listViewFolder1.Items.Add(sh.szDisplayName, i);
                    }
                }             
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(ex.Message); }
        }

        private void toolStripButtonMove_Click(object sender, EventArgs e)
        {
            try
            {
                Move_?.Invoke(this, EventArgs.Empty);

                if (str != null)
                {

                    list.Images.Clear();
                    listViewFolder1.Clear();

                    Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
                    if (str.Length == 0)
                    {
                        return;
                    }

                    for (int i = 0; i < str.Length; i++)
                    {
                        Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                            Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                        Icon icon = Icon.FromHandle(sh.hIcon);
                        list.Images.Add(icon);
                        listViewFolder1.Items.Add(sh.szDisplayName, i);
                    }
                }
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty); MessageBox.Show(ex.Message); }
        }

        private void toolStripButtonUp_Click(object sender, EventArgs e)
        {
           
            try
            {
                Up?.Invoke(this, EventArgs.Empty);
                if (str != null)
                {

                    list.Images.Clear();
                    listViewFolder1.Clear();

                    Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
                    if (str.Length == 0)
                    {
                        return;
                    }

                    for (int i = 0; i < str.Length; i++)
                    {
                        Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                            Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                        Icon icon = Icon.FromHandle(sh.hIcon);
                        list.Images.Add(icon);
                        listViewFolder1.Items.Add(sh.szDisplayName, i);
                    }
                }
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty); MessageBox.Show(ex.Message); }
        }

        private void toolStripButtonRenewal_Click(object sender, EventArgs e)
        {
            Name_Notee_List.Clear();
            Full_Path_Note_List.Clear();
            Name_Notee_element_List.Clear();


            Renewal?.Invoke(this, EventArgs.Empty);


            TreeNode node;



            for (int i1 = 0,i=0 ; i1 < Name_Notee_element_List_Tree.Count; i1++)
            {
                //.Find(Name_Notee_element_List_Tree[i1], true);
                TreeNodeCollection findTreeNodes = treeViewPath1.Nodes;
                TreeNode[] node1 = findTreeNodes.Find(Name_Notee_element_List_Tree[i1], false);
                node1[0].Nodes.Clear();
               //TreeNode[] findTreeNodes = treeViewPath1.Nodes.Find(Name_Notee_element_List_Tree[i1], false);

                // findTreeNodes[0].Nodes.Clear();

                for (; i < name_Notee_List.Count; i++)
                {
                    node = node1[0].Nodes.Add(name_Notee_List[i]);
                    node.Name = name_Notee_List[i];

                    if (name_Notee_element_List[i] > 0)
                        node.Nodes.Add("1");
                }
                ///////////////////
                //тут нужено добавление
                //////////
            }

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
            Name_Notee_List.Clear();
            Full_Path_Note_List.Clear();
            Name_Notee_element_List.Clear();

            TreeNode node;
            Name_Note = e.Node.Name;
            Full_Path_Note = e.Node.FullPath;

            Open_Tree?.Invoke(this, EventArgs.Empty);
            e.Node.Nodes.Clear();

            for (int i = 0; i < name_Notee_List.Count; i++)
            {
                node = e.Node.Nodes.Add(name_Notee_List[i]);
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

            Full_Path_Note = e.Node.FullPath;

            Close_Tree?.Invoke(this, EventArgs.Empty);

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
           
            if (start)
            {
                start = !start;
                return;
            }
            try
            {
                Full_Path_Note = e.Node.FullPath;

                Open_Folder_in_Tree?.Invoke(this, EventArgs.Empty);

                list.Images.Clear();
                listViewFolder1.Clear();

                Win32.SHFILEINFO sh = new Win32.SHFILEINFO();
                if (str.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < str.Length; i++)
                {
                    Win32.SHGetFileInfo(str[i], 0, ref sh, (uint)Marshal.SizeOf(sh),
                        Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON | Win32.SHGFI_DISPLAYNAME);
                    Icon icon = Icon.FromHandle(sh.hIcon);
                    list.Images.Add(icon);
                    listViewFolder1.Items.Add(sh.szDisplayName, i);
                }
            }
            catch (Exception ex) {
             
                    MessageBox.Show(ex.Message);
            }
        }

        private void toolStripSplitButtonTabl_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Edit_List_Viwe?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) { Remove_Die_Path?.Invoke(this, EventArgs.Empty); MessageBox.Show(ex.Message); }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductor
{
    class P_Global
    {
        private readonly I_Global _viwe;
        //  private readonly 
        public P_Global(I_Global viwe)
        {
            _viwe = viwe;
            _viwe.Close_Program += new EventHandler<EventArgs>(Close_Program);
            _viwe.Open_Tree += new EventHandler<EventArgs>(Open_Tree);
            _viwe.Open_Folder_in_Tree += new EventHandler<EventArgs>(Open_Folder_in_Tree);
            _viwe.Edit_List_Viwe += new EventHandler<EventArgs>(Edit_List_Viwe);
            _viwe.Up += new EventHandler<EventArgs>(Up);
            _viwe.End += new EventHandler<EventArgs>(End);
            _viwe.Move_ += new EventHandler<EventArgs>(Move_);
            _viwe.Start_program += new EventHandler<EventArgs>(Start_program);
            _viwe.Renewal += new EventHandler<EventArgs>(Renewal);
        }
        public void Close_Program(object sender, EventArgs e)
        {

        }
        public void Open_Tree(object sender, EventArgs e)
        {            
            string[] str = System.IO.Directory.GetDirectories((@"" + _viwe.Full_Path_Note), "*.*");
            FileInfo fi;
            

            for (int i=0;i<str.Length;i++)
            {
                try { 
                fi = new FileInfo(str[i]);
                string[] str2 = System.IO.Directory.GetDirectories((@"" + fi.FullName), "*.*");
                _viwe.Name_Notee_List.Add(fi.Name);
                _viwe.Full_Path_Note_List.Add(fi.FullName);
               

                if (str2.Length > 0)
                {
                    _viwe.Name_Notee_element_List.Add(1);
                }
                else
                    _viwe.Name_Notee_element_List.Add(0);
                }
                catch (Exception ex)
                {
                 
                };
            }
            
        }

        public void Open_Folder_in_Tree(object sender, EventArgs e)
        {
            
             string[] str1 = Directory.GetDirectories(@""+_viwe.Full_Path_Note.Replace("\\\\","\\"), "*.*");
             string[] str2 = Directory.GetFiles(@""+_viwe.Full_Path_Note.Replace("\\\\", "\\"), " *.*");
             int length = str1.Length;
             Array.Resize(ref str1, str1.Length + str2.Length);
             Array.Copy(str2, 0, str1, length, str2.Length);
             _viwe.str = str1;
        }
        public void Edit_List_Viwe(object sender, EventArgs e)
        {

        }
        public void Up(object sender, EventArgs e)
        {

        }
        public void End(object sender, EventArgs e)
        {

        }
        public void Move_(object sender, EventArgs e)
        {

        }
        public void Start_program(object sender, EventArgs e)
        {

            string[] str1 = Directory.GetLogicalDrives();
            //  string[] str1 = Directory.GetDirectories(@"C:\Windows", "*.*");
            // string[] str2 = Directory.GetFiles(@"C:\Windows", "*.*");
            int length = str1.Length;
          //  Array.Resize(ref str1, str1.Length + str2.Length);
           // Array.Copy(str2, 0, str1, length, str2.Length);
            _viwe.str = str1;


            ////////////////////////////////////



            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives(); // System.Environment.GetLogicalDrives();    
                             
            foreach (string disk in astrLogicalDrives)
                _viwe.Name_Notee_List.Add(disk);
            string[] str= null;
            for (int element=0; element < astrLogicalDrives.Length;element++)
            {

                try
                {
                    str = System.IO.Directory.GetDirectories((@"" + astrLogicalDrives[element]), "*.*");
                    if (str.Length > 0)
                    {
                        _viwe.Name_Notee_element_List.Add(1);
                    }
                    else
                        _viwe.Name_Notee_element_List.Add(0);
                }
                catch
                {
                    _viwe.Name_Notee_element_List.Add(0);
                }

               
            }
              
        }

            ////  foreach (string disk in astrLogicalDrives)
            ////    node = treeViewPath1.Nodes.Add(disk);        
        
        public void Renewal(object sender, EventArgs e)
        {

        }
    }
}

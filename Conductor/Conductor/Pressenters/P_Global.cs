using System;
using System.Collections.Generic;
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

        }

        public void Open_Folder_in_Tree(object sender, EventArgs e)
        {

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

        }
        public void Renewal(object sender, EventArgs e)
        {

        }
    }
}

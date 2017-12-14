using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductor
{
    public interface I_Global
    {
        event EventHandler<EventArgs> Close_Program;
        event EventHandler<EventArgs> Open_Tree;
        event EventHandler<EventArgs> Open_Folder_in_Tree;
        event EventHandler<EventArgs> Edit_List_Viwe;
        event EventHandler<EventArgs> Up;
        event EventHandler<EventArgs> End;
        event EventHandler<EventArgs> Move_;
        event EventHandler<EventArgs> Start_program;
        event EventHandler<EventArgs> Renewal;

        string Name_Note { set; get; }
        string Full_Path_Note { set; get; }

        List<string> Full_Path_Note_List { set; get; }
        List<string> Name_Notee_List { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.Model
{
    class Histori
    {
        private List<string> list;
        private int element;
        public Histori()
        {
            element =0;
            list = new List<string>();
        }
        public void Add(string s)
        {
            list.Add(s);
        }
        public string Move()
        {
            ++element;
            return list[element];
        }
        public string Back()
        {
            --element;
            return list[element];
        }
        public string Now()
        {
            return list[element];
        }
        public void Clean()
        {
            list.Clear();
        }
    }
}

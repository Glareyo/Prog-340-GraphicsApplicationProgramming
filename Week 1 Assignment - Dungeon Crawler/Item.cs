using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    internal class Item
    {
        string name;
        string description;

        public Item(string _name, string _description)
        {
            this.name = _name;
            this.description = _description;
        }
    }
}

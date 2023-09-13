using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    public class Item
    {
        //Item class
        string name;
        string description;

        public string Name { get { return name; } }
        public string Description { get { return description; } }

        public Item(string _name, string _description)
        {
            this.name = _name;
            this.description = _description;
        }
    }
}

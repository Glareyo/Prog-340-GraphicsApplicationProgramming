using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    internal class Trap
    {
        //Basic info on traps
        string name;
        int id;
        
        string defDesript; //Default description before disarming
        string disDescript; //Disarmed Description.
        string deathDescript; //Description that appears if player continues without disarming.

        //Item needed to disarm.
        string itemNeeded;

        public Trap(string _name, int _id, string _defDesript, string _disDescript, string _deathDescript, string _itemNeeded)
        {
            this.name = _name;
            this.id = _id;
            this.defDesript = _defDesript;
            this.disDescript = _disDescript;
            this.deathDescript = _deathDescript;
            this.itemNeeded = _itemNeeded;
        }
    }
}

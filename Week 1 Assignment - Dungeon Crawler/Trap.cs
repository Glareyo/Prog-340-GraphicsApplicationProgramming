using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    public class Trap
    {
        //Basic info on traps
        int id;
        string name;

        string defDesript; //Default description before disarming
        string hint; //A hint for the player to determine the correct tool to disarm the trap.
        string disDescript; //Disarmed Description.
        string failedDescript; //Description that appears if player continues without disarming.



        //Item needed to disarm.
        string itemNeeded;
        public bool isDisarmed;


        //Encapsulation so that the data doesn't get altered
        public string GetName { get { return name; } }
        public string GetDefaultDescript { get { return defDesript; } }
        public string GetHint { get { return hint; } }
        public string GetDisarmDescript { get { return disDescript; } }
        public string GetFailedDescript { get { return failedDescript; } }
        public string GetItemNeeded { get { return itemNeeded; } }
        public int GetID { get { return id; } }



        public Trap(int _id, string _name, string _defDesript,string _hint, string _disDescript, string _failedDescript, string _itemNeeded)
        {
            this.id = _id;
            this.name = _name;
            this.defDesript = _defDesript;
            this.hint = _hint;
            this.disDescript = _disDescript;
            this.failedDescript = _failedDescript;
            this.itemNeeded = _itemNeeded;
            isDisarmed = false;
        }
    }
}

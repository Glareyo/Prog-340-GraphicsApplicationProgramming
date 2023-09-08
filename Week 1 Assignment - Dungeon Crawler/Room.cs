using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    internal class Room
    {
        //Basic Information of Room
        int id;
        string name;
        string description;
        
        //Adjacent Rooms
        int nRoom;
        int sRoom;
        int eRoom;
        int wRoom;

        //Adjacent Traps
        int nTrap;
        int sTrap;
        int eTrap;
        int wTrap;

        //Items in room
        List<string> loot = new List<string>();


        public Room(int _id, string _name, string _description, int _nRoom, int _sRoom, int _eRoom, int _wRoom, int _nTrap, int _sTrap, int _eTrap, int _wTrap, List<string> _loot)
        {
            this.id = _id;
            this.name = _name;
            this.description = _description;
            this.nRoom = _nRoom;
            this.sRoom = _sRoom;
            this.eRoom = _eRoom;
            this.wRoom = _wRoom;
            this.nTrap = _nTrap;
            this.sTrap = _sTrap;
            this.eTrap = _eTrap;
            this.wTrap = _wTrap;
            this.loot = _loot;
        }
    }
}

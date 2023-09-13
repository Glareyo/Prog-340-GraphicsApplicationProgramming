﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    internal class Player
    {
        //Basic Info on player
        public string name; //Name
        public int lives = 3; //Num of lives.

        //Location of the player
        public Room location;

        //Inventory
        public List<Item> inventory = new List<Item>();
    }
}

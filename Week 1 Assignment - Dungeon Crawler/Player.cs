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
        string name;
        int lives;

        //Location of the player
        int playerLocation;

        //Inventory
        List<Item> inventory = new List<Item>();
    }
}
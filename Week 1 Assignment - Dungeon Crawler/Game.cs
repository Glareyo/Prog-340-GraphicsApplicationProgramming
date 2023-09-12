using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week_1_Assignment___Dungeon_Crawler.UIUtility;

namespace Week_1_Assignment___Dungeon_Crawler
{
    internal class Game
    {
        Player player;
        static DataHandler dataHandler;

        public void RunGame()
        {
            player = new Player();
            dataHandler = new DataHandler();

            player.location = dataHandler.GetRoom(1);

            Prompt("Hello Player!");
            string t = PromptAndAnswer("Please enter your name: ");

            Continue();

            DisplayUI(player.location);

            while (true)
            {
                GetPlayerInput();
                DisplayUI(player.location);
            }
        }


        public void GetPlayerInput()
        {//Handles the controls of the player
            //Get input
            string input = Console.ReadLine().ToLower();

            Console.Clear();
            Console.WriteLine();

            switch (input)
            {
                case "n": MovePlayer(input);
                    break;
                case "s": MovePlayer(input);
                    break;
                case "e": MovePlayer(input);
                    break;
                case "w": MovePlayer(input);
                    break;
                case "p":
                    bool running = true;
                    Console.Clear();
                    Console.WriteLine();
                    if (player.location.loot.Count <= 0)
                        UnaccessiblePrompt("There are no items here...");
                    else
                    {
                        while (running)
                            if (player.location.loot.Count > 0)
                                running = PickupItem(player.location);
                    }
                    break;
                case "i":
                    Print_Underline("Your Inventory", ConsoleColor.Cyan, true);
                    Console.WriteLine();
                    for (int i = 0; i < player.inventory.Count; i++)
                    {
                        Print($"{i}. ", $"{player.inventory[i].Name}","",ConsoleColor.White,ConsoleColor.Cyan,ConsoleColor.White,true,false);
                    }
                    Continue();
                    break;
                default: InvalidInput();
                    break;
            }
        }

        public void MovePlayer(string direction)
        {
            int targetRoomId = 0;
            int targetDir = 0;
            string[] dir = { "North", "South", "East", "West" };

            direction = direction.ToLower();

            for (int i = 0; i < 4; i++)
                //Checks the first char of the input, and compares to the first char of the dir[] based on the loop.
                if (direction[0].ToString().ToLower() == dir[i][0].ToString().ToLower())
                {//Get the target room ID
                    targetRoomId = player.location.GetAdjRoomIDs[i];
                    targetDir = i; //Set the target direction for printing.
                }

            DisplayAction($"You go {dir[targetDir]}");

            if (targetRoomId == 0)
                UnaccessiblePrompt();
            //Else assign player to new location
            else
                player.location = dataHandler.GetRoom(targetRoomId);
        }
        public bool PickupItem(Room CurrentLocation)
        {
            Print("Select an item to loot...",ConsoleColor.Green,true,false);

            Print("0".ToString(), " - ", $"Cancel", ConsoleColor.Green, ConsoleColor.White, ConsoleColor.Red,true, false);

            for (int i = 0; i < CurrentLocation.loot.Count; i++)
                Print((i+1).ToString(), " - ", $"{CurrentLocation.loot[i].Name}", ConsoleColor.Green, ConsoleColor.White, ConsoleColor.Red,true, false);

            int input;


            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine();
                UnaccessiblePrompt("Invalid Input");
                return true;
            }

            Console.Clear();
            Console.WriteLine();

            if (input == 0) return false;
            else if (input > 0 && input <= CurrentLocation.loot.Count)
            {
                player.inventory.Add(CurrentLocation.loot[input - 1]);
                CurrentLocation.loot.RemoveAt(input - 1);
                if (CurrentLocation.loot.Count == 0) return false;
            }
            else
                UnaccessiblePrompt("Invalid Input");

            
            return true;
        }
        public void DisplayUI(Room CurrentLocation)
        {
            string[] movePrompts = { "N", "S", "E", "W" };
            string[] directions = { "North", "South", "East", "West" };
            int[] roomIDs = CurrentLocation.GetAdjRoomIDs;


            Print_Underline(CurrentLocation.GetName, ConsoleColor.Magenta,true);
            Print(CurrentLocation.GetDescription,ConsoleColor.White,true,false);
            foreach (Item i in CurrentLocation.loot)
                Print("There is a ", i.Name, " here", ConsoleColor.White, ConsoleColor.Cyan, ConsoleColor.White,true, false);
            Console.WriteLine();

            Print_Underline("Inputs:", ConsoleColor.Green,true);
            for (int i = 0; i < 4; i++)
                Print($" {movePrompts[i]}", $" - Go {directions[i]} : ", $"{dataHandler.GetRoom(roomIDs[i]).GetName}",ConsoleColor.Green,ConsoleColor.White,ConsoleColor.Red,true,false);
            
            Print($" P"," - Pickup an ", "Item", ConsoleColor.Green,ConsoleColor.White,ConsoleColor.Cyan,true,false);
            Print($" I"," - Check ", "Inventory", ConsoleColor.Green,ConsoleColor.White,ConsoleColor.Cyan,true,false);
        }
    }
}

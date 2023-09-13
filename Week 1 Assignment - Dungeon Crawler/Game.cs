using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        void Introduction()
        {
            Prompt("Hello Player!");
            player.name = PromptAndAnswer("Please enter your name: ");

            Console.Clear();
            Console.WriteLine();

            Print("Hello, ", $"{player.name}!", "", ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Green, true, false);
            Print("Welcome to...", ConsoleColor.Green, true, false);

            Continue();

            TitleCard();

            Console.WriteLine("\n");
            Continue();
        }
        public void RunGame()
        {
            player = new Player();
            dataHandler = new DataHandler();

            player.location = dataHandler.GetRoom(1);

            Introduction();

            DisplayUI(player.location);

            bool runningGame = true;

            while (runningGame)
            {
                GetPlayerInput(); //Get player input
                DisplayUI(player.location); //Display UI

                //Check for win/lose conditions
                runningGame = CheckConditions();
            }

            //Rerun the game if there is a win/lose scenario
            RunGame();
        }

        bool CheckConditions()
        {
            if (player.lives <= 0) //Player lost all lives
            {
                Console.Clear();
                Console.WriteLine();

                Print("You ran out of lives.", ConsoleColor.Red, true, false);
                Print("Game Over", ConsoleColor.Red, true, false);

                Console.WriteLine();
                Continue();
                return false;
            }
            foreach (Item i in player.inventory)
                if (i.Name == "Ancient Relic") //Player obtained relic
                {
                    Console.Clear();
                    Console.WriteLine();
                    GameWon();

                    return false;
                }

            return true;
        }

        //Player actions
        public void GetPlayerInput()
        {//Handles the controls of the player
            //Get input
            string input = Console.ReadLine().ToLower();

            Console.Clear();
            Console.WriteLine();

            switch (input)
            {
                //Move the player
                case "n": MovePlayer(input);
                    break;
                case "s": MovePlayer(input);
                    break;
                case "e": MovePlayer(input);
                    break;
                case "w": MovePlayer(input);
                    break;
                case "p": //Pickup items
                    bool running = true;
                    Console.Clear();
                    Console.WriteLine();
                    if (player.location.loot.Count <= 0) //No items
                        UnaccessiblePrompt("There are no items here...");
                    else
                        while (running)
                            if (player.location.loot.Count > 0)
                                running = PickupItem(player.location);
                    break;
                case "i": //Check inventory
                    Print_Underline("Your Inventory", ConsoleColor.Cyan, true);
                    Console.WriteLine();
                    for (int i = 0; i < player.inventory.Count; i++)
                        Print($"{i+1}. ", $"{player.inventory[i].Name}","",ConsoleColor.White,ConsoleColor.Cyan,ConsoleColor.White,true,false);
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
            //Target directions
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
            {
                Room targetRoom = dataHandler.GetRoom(targetRoomId);
                if (targetRoom.GetTrap != null && targetRoom.GetTrap.isDisarmed == false)
                    //There's a trap in the room.
                    InteractWithTrap(targetRoom.GetTrap);
                else
                    player.location = targetRoom;
            }

        }
        public void InteractWithTrap(Trap t)
        {
            bool inputValid = false;
            int input = 0;
            Console.Clear();
            Console.WriteLine();

            while (!inputValid)
            {
                //Display trap information
                Print_Underline(t.GetName, ConsoleColor.Red, true);
                Print(t.GetDefaultDescript, ConsoleColor.White, true, false);
                Print(t.GetHint, ConsoleColor.Cyan, true, false);
                Console.WriteLine();

                //Prompt for action from player
                Print_Underline("Select an Item to Use", ConsoleColor.Green, true);

                //Display items and options
                Print("0.", " - ", "Cancel", ConsoleColor.Green, ConsoleColor.White, ConsoleColor.Red, true, false);
                for (int i = 0; i < player.inventory.Count; i++)
                    Print($"{i + 1}.", " - ", player.inventory[i].Name, ConsoleColor.Green, ConsoleColor.White, ConsoleColor.Cyan, true, false);
                //Get player input                
                try
                {
                    input = Convert.ToInt32(Console.ReadLine()); //Convert input to int.
                    input--;

                    Console.Clear();
                    Console.WriteLine();

                    if (input == -1) inputValid = true;
                    else if (input < 0 || input >= player.inventory.Count)
                        UnaccessiblePrompt("Invalid Input");
                    else
                        inputValid = true;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine();

                    UnaccessiblePrompt("Invalid Input");
                }
            }
                

            Console.Clear();
            Console.WriteLine();

            if (input >= 0)
            {
                if (player.inventory[input].Name == t.GetItemNeeded)
                {
                    t.isDisarmed = true;
                    player.inventory.RemoveAt(input);
                    Print(t.GetDisarmDescript, ConsoleColor.Green, true, false);
                }
                else
                {
                    Print(t.GetFailedDescript, ConsoleColor.Red, true, false);
                    player.lives -= 1;
                }
                Console.WriteLine();
                Continue();
            }
        }
        public bool PickupItem(Room CurrentLocation)
        {
            //Prompt player
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

            //Determine if player selected an item, or canceled
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

            //Changes status depending on number of lives.
            ConsoleColor status = ConsoleColor.Black;

            if (player.lives == 3) status = ConsoleColor.Green; //Good
            else if (player.lives == 2) status = ConsoleColor.Yellow; //Ok
            else if (player.lives == 1) status = ConsoleColor.Red; //Bad

            //Print UI
            Print("Adventurer: ", $"{player.name}", "      Lives: ", $"{player.lives}", ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Cyan, status, true, false);
            GenerateBorderLine();
            
            //Show Location
            Print_Underline(CurrentLocation.GetName, ConsoleColor.Magenta,true);
            Print(CurrentLocation.GetDescription,ConsoleColor.White,true,false);
            foreach (Item i in CurrentLocation.loot)
                Print("There is a ", i.Name, " here", ConsoleColor.White, ConsoleColor.Cyan, ConsoleColor.White,true, false);
            Console.WriteLine();

            //Display controls
            Print_Underline("Inputs:", ConsoleColor.Green,true);
            for (int i = 0; i < 4; i++)
            {
                ConsoleColor validDirection = ConsoleColor.Green;
                if (dataHandler.GetRoom(roomIDs[i]).GetID == 0) validDirection = ConsoleColor.Red;
                Print($" {movePrompts[i]}", $" - Go {directions[i]} : ", $"{dataHandler.GetRoom(roomIDs[i]).GetName}", ConsoleColor.Green, ConsoleColor.White, validDirection, true, false);
            }
            Console.WriteLine();
            Print($" P"," - Pickup an ", "Item", ConsoleColor.Green,ConsoleColor.White,ConsoleColor.Cyan,true,false);
            Print($" I"," - Check ", "Inventory", ConsoleColor.Green,ConsoleColor.White,ConsoleColor.Cyan,true,false);
        }
    }
}

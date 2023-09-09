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
        DataHandler dataHandler;

        public void RunGame()
        {
            player = new Player();
            dataHandler = new DataHandler();

            player.location = dataHandler.GetRoom(1);

            Prompt("Hello Player!");
            string t = PromptAndAnswer("Please enter your name: ");

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
            switch(input)
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
       
        public void DisplayUI(Room CurrentLocation)
        {
            string[] movePrompts = { "N", "S", "E", "W" };
            string[] directions = { "North", "South", "East", "West" };
            int[] roomIDs = CurrentLocation.GetAdjRoomIDs;


            Print_Underline(CurrentLocation.GetName, ConsoleColor.Magenta);
            Print(CurrentLocation.GetDescription,ConsoleColor.White,false);
            foreach (Item i in CurrentLocation.loot)
                Print("There is a ", i.Name, " here", ConsoleColor.White, ConsoleColor.Cyan, ConsoleColor.White, false);
            Console.WriteLine();

            Print("Inputs:", ConsoleColor.Green, false);
            for (int i = 0; i < 4; i++)
                Print($"{movePrompts[i]}", $" - Go {directions[i]} : ", $"{dataHandler.GetRoom(roomIDs[i]).GetName}",ConsoleColor.Green,ConsoleColor.White,ConsoleColor.Red,false);

        }
    }
}

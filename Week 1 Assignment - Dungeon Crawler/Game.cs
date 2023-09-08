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
        public void RunGame()
        {
            Prompt("Hello Player!");
            string t = PromptAndAnswer("Please enter your name: ");

            Prompt("Hello " + t);

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    public static class UIUtility
    {
        public static void CenterString(string message, bool newLine)
        {
            //Get the window width and divide be two
            int spaces = Console.WindowWidth/2;

            //Then get the length of the message and divide by two
            //Subtract from spaces.
            spaces -= (message.Length / 2);

            //This will center the string to the screen.
            string s = "";
            for (int i = 0; i < spaces; i++) s += " ";

            if (newLine) Console.WriteLine(s + message);
            else Console.Write(s + message);
        }

        public static void Prompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(message, true);
            Console.ResetColor();
        }

        public static string PromptAndAnswer(string message)
        {
            string answer = "";
            
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(message, false);
            Console.ForegroundColor = ConsoleColor.Magenta;

            answer = Console.ReadLine();

            Console.ResetColor();

            return answer;
        }
    }
}

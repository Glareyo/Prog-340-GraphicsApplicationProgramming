using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1_Assignment___Dungeon_Crawler
{
    /// <summary>
    /// This class is static, so that the game can quickly call upon a variety of print options for specific tasks
    /// or highlight specific moments and information.
    /// </summary>
    
    public static class UIUtility
    {
        //Used to center strings
        static void CreateSpaces(string message)
        {
            //Get the window width and divide be two
            int spaces = Console.WindowWidth / 2;

            //Then get the length of the message and divide by two
            //Subtract from spaces.
            spaces -= (message.Length / 2);

            //This will center the string to the screen.
            string s = "";
            for (int i = 0; i < spaces; i++) s += " ";
            Console.Write(s);
        }

        //These methods are used to Make the strings the print out on the console appear centered.
        public static void CenterString(string message, bool inline)
        {
            CreateSpaces(message);
            if (inline) Console.Write(message);
            else Console.WriteLine(message);
        }
        public static void CenterString(string message, ConsoleColor highlight,bool inline)
        {
            CreateSpaces(message);
            Console.BackgroundColor = highlight;

            if (inline) Console.Write(message);
            else Console.WriteLine(message);
        }
        public static void CenterString_Underline(string message)
        {
            CreateSpaces(message);

            Console.WriteLine(message);
            CreateSpaces(message);
            for(int i = 0; i<message.Length;i++)
                Console.Write("-");
            Console.WriteLine();
        }


        public static void Prompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(message, false);
            Console.ResetColor();
        }
        public static void DisplayAction(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString_Underline(message);
            
            Console.ResetColor();
        }


        //For if the player attempts to go into a wall, or cannot do a certain action.
        public static void UnaccessiblePrompt(string message = "You cannot go that way")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CenterString(message, false);
            Console.ResetColor();
        }
        public static void InvalidInput(string message = " Invalid Input ")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CenterString(message, ConsoleColor.White,false);
            Console.ResetColor();
        }
        
        //Allows user input
        public static string PromptAndAnswer(string message)
        {
            string answer = "";
            
            Console.ForegroundColor = ConsoleColor.Green;
            CenterString(message, true);
            Console.ForegroundColor = ConsoleColor.Magenta;

            answer = Console.ReadLine();

            Console.ResetColor();

            return answer;
        }
        
        
        //Multiple print options, such as being able to have different colors within a single line.
        public static void Print(string message, ConsoleColor color, bool centerString, bool inLine)
        {
            Console.ForegroundColor = color;
            if (centerString) CenterString(message, inLine);
            else if (inLine) Console.Write(message);
            else Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Print_Underline(string message, ConsoleColor color, bool centerString)
        {
            Console.ForegroundColor = color;
            if (centerString)
                CenterString_Underline(message);
            else
            {
                Console.WriteLine(message);
                for (int i = 0; i < message.Length; i++) Console.Write("-");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void Print(string m1, string m2, string m3, ConsoleColor c1, ConsoleColor c2, ConsoleColor c3,bool centerString, bool inLine)
        {
            if (centerString) CreateSpaces(m1+m2+ m3);
            
            Console.ForegroundColor = c1;
            Console.Write(m1);

            Console.ForegroundColor = c2;
            Console.Write(m2);

            Console.ForegroundColor = c3;
            if (inLine) Console.Write(m3);
            else Console.WriteLine(m3);
            
            Console.ResetColor();
        }
        public static void Print(string m1, string m2, string m3,string m4, ConsoleColor c1, ConsoleColor c2, ConsoleColor c3,ConsoleColor c4, bool centerString, bool inLine)
        {
            if (centerString) CreateSpaces(m1 + m2 + m3 + m4);

            Console.ForegroundColor = c1;
            Console.Write(m1);

            Console.ForegroundColor = c2;
            Console.Write(m2);

            Console.ForegroundColor = c3;
            Console.Write(m3);

            Console.ForegroundColor = c4;
            if (inLine) Console.Write(m4);
            else Console.WriteLine(m4);

            Console.ResetColor();
        }
        
        
        //Acts as a buffer for the player to continue forward.
        public static void Continue()
        {
            Console.WriteLine();
            Print("Press ", "Enter ", "to Continue", ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Green, true, false);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
        }

        //Create a full screen border
        public static void GenerateBorderLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("-");
            Console.WriteLine();
        }



        //ASCII Arts
        //ASCII art generated from TextKool ASCII Art Generator
        //https://textkool.com/en/ascii-art-generator?hl=controlled%20smushing&vl=controlled%20smushing&font=Puffy&text=The%20Ancient%20Relic
        public static void GameWon()
        {
            //ASCII art generated from TextKool ASCII Art Generator
            //https://textkool.com/en/ascii-art-generator?hl=controlled%20smushing&vl=controlled%20smushing&font=Puffy&text=The%20Ancient%20Relic

            string title1 = @"
██████╗ ███████╗██╗     ██╗ ██████╗    ███████╗ ██████╗ ██╗   ██╗███╗   ██╗██████╗ 
██╔══██╗██╔════╝██║     ██║██╔════╝    ██╔════╝██╔═══██╗██║   ██║████╗  ██║██╔══██╗
██████╔╝█████╗  ██║     ██║██║         █████╗  ██║   ██║██║   ██║██╔██╗ ██║██║  ██║
██╔══██╗██╔══╝  ██║     ██║██║         ██╔══╝  ██║   ██║██║   ██║██║╚██╗██║██║  ██║
██║  ██║███████╗███████╗██║╚██████╗    ██║     ╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝
╚═╝  ╚═╝╚══════╝╚══════╝╚═╝ ╚═════╝    ╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝ 
                                                                                   ";
            string title2 = @"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗    ██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║    ██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║    ██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║    ╚═╝
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║    ██╗
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝    ╚═╝
                                                             ";

            Print(title1, ConsoleColor.Green, true, false);
            Print(title2, ConsoleColor.Yellow, true, false);
            Continue();
        }
        public static void TitleCard()
        {
            //ASCII art generated from TextKool ASCII Art Generator
            //https://textkool.com/en/ascii-art-generator?hl=controlled%20smushing&vl=controlled%20smushing&font=Puffy&text=The%20Ancient%20Relic

            string title1 = @"
 _____ _                ___                           _           ___           
(_   _| )              (  _`\                        ( )        /'___)          
  | | | |__     __     | (_(_)   __     _ _ _ __  ___| |__     | (__  _    _ __ 
  | | |  _ `\ /'__`\   `\__ \  /'__`\ /'_` | '__)'___)  _ `\   | ,__)'_`\ ( '__)
  | | | | | |(  ___/   ( )_) |(  ___/( (_| | | ( (___| | | |   | | ( (_) )| |   
  (_) (_) (_)`\____)   `\____)`\____)`\__,_|_) `\____|_) (_)   (_) `\___/'(_)   
                                                                                
                                                                                ";
            string title2 = @"
 _____ _                _____                               _       ___          _            
(_   _| )              (  _  )             _               ( )_    |  _`\       (_ ) _        
  | | | |__     __     | (_) | ___     ___(_)   __    ___  | ,_)   | (_) )   __  | |(_)   ___ 
  | | |  _ `\ /'__`\   |  _  /' _ `\ /'___) | /'__`\/' _ `\| |     | ,  /  /'__`\| || | /'___)
  | | | | | |(  ___/   | | | | ( ) |( (___| |(  ___/| ( ) || |_    | |\ \ (  ___/| || |( (___ 
  (_) (_) (_)`\____)   (_) (_|_) (_)`\____|_)`\____)(_) (_)`\__)   (_) (_)`\____|___|_)`\____)
";
                
            Print(title1, ConsoleColor.Red, true, false);
            Print(title2, ConsoleColor.Red, true, false);
        }
    }
}

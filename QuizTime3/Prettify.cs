using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QuizTime3
{
    static class Prettify
    {
        public static void DisplayPillar()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {

                for (int x = 0; x < Console.WindowWidth / 3; x++)
                {
                    Console.Write(" ");
                }

                for (int y = 0; y < Console.WindowWidth / 3; y++)
                {
                    Console.Write("#");
                }

                WaitBefore();
                Console.WriteLine();
            }

        }

        public static void CreateArrowhead()
        {

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < i + 1; j++)
            //    {
            //        Console.Write("#");
            //    }
            //    Console.WriteLine();
            //}


            for (int i = 0; i < Console.WindowWidth / 4; i++)
            {
                for (int m = 0; m < Console.WindowWidth / 4; m++)
                {
                    Console.Write(" ");
                }

                for (int k = i; k < i + i; k += 1)
                {
                    Console.Write(" ");
                }

                for (int j = Console.WindowWidth / 4; j > i; j--)
                {
                    Console.Write("@");
                }

                for (int l = Console.WindowWidth / 4 - 1; l > i; l--)
                {
                    Console.Write("@");
                }


                //for (int j = i; j > 0; j--)
                //{
                //    Console.Write("#");
                //}
                WaitBefore();
                Console.WriteLine();
            }
        }

        public static void DisplayWelcome()
        {   
            List<string> welcome = new List<string>();
            welcome.Add("__            __           _                \n");
            welcome.Add("\\ \\    __    / / _____    | |  ____   ______   __   __   _____    \n");
            welcome.Add(" \\ \\  /  \\  / / |  __  \\  | | |  __| |  __  | |  \\_/  | |  __  \\  \n");
            welcome.Add("  \\ \\/ /\\ \\/ /  | |__| /_ | | | |__  | |__| | |   _   | | |__| /_  \n");
            welcome.Add("   \\__/  \\__/   |_______/ |_| |____| |______| |__| |_ | |_______/ \n");

            foreach (string line in welcome)
            {
                for (int m = 0; m < Console.WindowWidth / 4; m++)
                {
                    Console.Write(" ");
                }
                Console.Write(line);
            }

        }

        public static void TransitionEffect(string prompt)
        {
            for (int m = 0; m < Console.WindowWidth / 4; m++)
            {
                Console.Write(" ");
            }
            GameHelpers.PrintSlow(prompt);
            Console.WriteLine();
            for (int m = 0; m < Console.WindowWidth / 5; m++)
            {
                Console.Write(" ");
            }
            GameHelpers.PrintSlow("If you did not want to begin, sorry, you're stuck unless you close the console :)");
            Console.ReadLine();
            Thread.Sleep(250);

            TransitionEffectHalfConsole();
        }

        public static void TransitionEffectFullConsole()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                WaitBefore();
                Console.WriteLine();
            }
        }

        public static void TransitionEffectHalfConsole()
        {
            for (int i = 0; i < Console.WindowHeight / 2; i++)
            {
                WaitBefore();
                Console.WriteLine();
            }
        }

        public static void DisplayAlternatingSymbols(char symbol)
        {
            for (int i = 0; i < (Console.WindowHeight / 2); i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {

                    if (j % 2 == 0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(symbol);
                    }

                }

                for (int k = 0; k < Console.WindowWidth; k++)
                {
                   
                    if (k % 2 == 0)
                    {
                        Console.Write(symbol);
                    }
                    else
                    {
                        Console.Write(" ");
                    }     
                }
                WaitBefore();
            }
        }

        public static void DisplayOpening()
        {
            DisplaySet1();
            DisplaySet2();
        } 

        public static void DisplaySet1()
        {
            TransitionEffectHalfConsole();
            DisplayWelcome();
            Thread.Sleep(500);
            TransitionEffectHalfConsole();
            DisplayAlternatingSymbols('$');
            TransitionEffectHalfConsole();
            DisplayPillar();
            CreateArrowhead();
            TransitionEffectHalfConsole();
            TransitionEffect("Ready to jump into the rabbit hole? Press ENTER to continue");
        }

        public static void DisplaySet2()
        {
            DisplayAlternatingSymbols('#');
            TransitionEffectHalfConsole();
            DisplayPillar();
            CreateArrowhead();
            TransitionEffectHalfConsole();
            TransitionEffect("Are you ready to begin the game? Press ENTER to continue");
            DisplayPillar();
            CreateArrowhead();
            TransitionEffectFullConsole();
            Console.Clear();
        }

        public static void DisplayEnding()
        {
            DisplayAlternatingSymbols('*');
            TransitionEffectHalfConsole();
            GameHelpers.PrintSlow(". . . . . . . . ", 150);
            GameHelpers.PrintSlow("Good bye!");
            Thread.Sleep(1000);
        }

        private static void WaitBefore()
        {
            Thread.Sleep(25);
        }
    }
}

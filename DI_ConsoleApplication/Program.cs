using System;

namespace DI_ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartInputLoop();
        }

        public static void StartInputLoop()
        {
            Console.WriteLine("Welcome to Walking Simulator 2019! Type 'exit' to exit.");

            var acceptingInput = true;
            while (acceptingInput)
            {
                DisplayActions();
                var inputText = Console.ReadLine();

                if (inputText == "exit")
                {
                    Console.WriteLine("Exit input received. Exiting application.");
                    acceptingInput = false;
                }
                else
                {
                    ProcessAction(inputText);
                }
            }

            Console.ReadLine();
        }

        public static void ProcessAction(string inputText)
        {
            switch (inputText)
            {
                case "u":
                    WalkUp();
                    break;
                case "d":
                    WalkDown();
                    break;
                case "r":
                    WalkRight();
                    break;
                case "l":
                    WalkLeft();
                    break;
            }
        }

        public static void DisplayActions()
        {
            Console.WriteLine("Please select an action:");
            Console.WriteLine("u: up, d: down, l: left, r: right");
        }

        private static void WalkUp() => Console.WriteLine(">> Walked Up");
               
        public static void WalkDown() => Console.WriteLine(">> Walked Down");
               
        public static void WalkRight() => Console.WriteLine(">> Walked Right");
               
        public static void WalkLeft() => Console.WriteLine(">> Walked Left");
    }
}
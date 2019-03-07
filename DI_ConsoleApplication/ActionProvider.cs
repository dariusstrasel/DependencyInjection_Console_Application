using System;

namespace DI_ConsoleApplication
{
    public class ActionProvider : IActionProvider
    {
        public void ProcessAction(string inputText)
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

        public void DisplayActions()
        {
            Console.WriteLine("Please select an action:");    
            Console.WriteLine("u: up, d: down, l: left, r: right");    
        }

        public void WalkUp()
        {
            Console.WriteLine(">> Walked Up");
            Console.WriteLine("");
        }

        public void WalkDown()
        {
            Console.WriteLine(">> Walked Down");
            Console.WriteLine("");
        }

        public void WalkRight()
        {
            Console.WriteLine(">> Walked Right");
            Console.WriteLine("");
        }

        public void WalkLeft()
        {
            Console.WriteLine(">> Walked Left");
            Console.WriteLine("");
        }
    }
}
using System;

namespace DI_ConsoleApplication.demo
{
    public class ActionProviderWithOutInterface
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

        private void WalkUp() => Console.WriteLine(">> Walked Up");

        public void WalkDown() => Console.WriteLine(">> Walked Down");

        public void WalkRight() => Console.WriteLine(">> Walked Right");

        public void WalkLeft() => Console.WriteLine(">> Walked Left");
    }
}
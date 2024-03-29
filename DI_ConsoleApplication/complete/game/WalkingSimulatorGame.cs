using System;

namespace DI_ConsoleApplication.complete.game
{
    public class WalkingSimulatorGame
    {
        private readonly IActionProvider actionProvider;

        public WalkingSimulatorGame(IActionProvider actionProvider)
        {
            this.actionProvider = actionProvider;
        }

        public void StartInputLoop()
        {
            Console.WriteLine("Welcome to Walking Simulator 2019! Type 'exit' to exit.");

            var acceptingInput = true;
            while (acceptingInput)
            {
                actionProvider.DisplayActions();
                var inputText = Console.ReadLine();

                if (inputText == "exit")
                {
                    Console.WriteLine("Exit input received. Exiting application.");
                    acceptingInput = false;
                }
                else
                {
                    actionProvider.ProcessAction(inputText);
                }
            }

            Console.ReadLine();
        }
    }
}
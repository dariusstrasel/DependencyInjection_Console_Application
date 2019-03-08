using System;
using DI_ConsoleApplication.game;
using Microsoft.Extensions.DependencyInjection;

namespace DI_ConsoleApplication
{
    public class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }
        
        static void Main(string[] args)
        {
            RegisterServices();

            var game = new WalkingSimulatorGame(ServiceProvider.GetService<IActionProvider>());
            game.StartInputLoop();
        }

        private static void RegisterServices()
        {
            ServiceProvider = new ServiceCollection()
                .AddScoped<IActionProvider, ActionProvider>()
                .BuildServiceProvider();
        }
    }
}
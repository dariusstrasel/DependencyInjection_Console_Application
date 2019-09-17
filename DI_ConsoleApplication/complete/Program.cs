using System;
using Microsoft.Extensions.DependencyInjection;
using ActionProvider = DI_ConsoleApplication.complete.game.ActionProvider;
using IActionProvider = DI_ConsoleApplication.complete.game.IActionProvider;
using WalkingSimulatorGame = DI_ConsoleApplication.complete.game.WalkingSimulatorGame;

namespace DI_ConsoleApplication.complete
{
    public class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        static void NotMain(string[] args)
        {
            RegisterServices();
            ServiceProvider.GetService<WalkingSimulatorGame>().StartInputLoop();
        }

        private static void RegisterServices()
        {
            ServiceProvider = new ServiceCollection()
                .AddTransient<WalkingSimulatorGame>()
                .AddScoped<IActionProvider, ActionProvider>()
                .BuildServiceProvider();
        }
    }
}
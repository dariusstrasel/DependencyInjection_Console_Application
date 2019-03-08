# Dependency Injection / IoC

### **Why use Dependency Injection?**

**DI** lets you create classes that work even if it's dependencies have been changed. This implements the "D" in SOLID, or **dependency inversion**.

It does this by removing the responsibility of creating dependencies from the application and instead has an external service provide them. (e.g. the dependency injection service, framework, container, etc.) This behavior also makes DI an implementation of the **inversion of control** principle or IOC.

**Here is an example of a class which does not follow dependency inversion/injection, or IoC:**

```C#
    public class WalkingSimulatorGame
    {
        private ActionProvider actionProvider;
        
        public void StartInputLoop()
        {
            actionProvider = new ActionProvider();
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
```
```C#
public class ActionProvider
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
```
There are a few ways to inject a dependency, but the most popular way is via the **constructor of the class** which needs these dependencies. To first do this... we need to create an abstract representation of our dependency.
```C#
public interface IActionProvider
{
    void ProcessAction(string inputText);
    void DisplayActions();
}
```
And ensure our dependency implements this interface:
```C#
public class ActionProvider : IActionProvider
{
    // SNIP
}
```
We can then signify this dependency via the constructor of our consuming class:
```C#
public class WalkingSimulatorGame
{
    private readonly IActionProvider actionProvider;

    // Add a constructor which accepts the abstract interface of your dependency.
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
                        // SNIP
        }

        Console.ReadLine();
    }
}
```
This may look great, but in its current state, this particular code would not compile or execute. This invites us to explore IoC! 

### **What is DI vs IOC?**

IOC is a high-level technique used to create programming interfaces where generic commands are known, but detailed implementations have to be specified by the writer. Inversion of control is sometimes facetiously referred to as the "Hollywood Principle: Don't call us, we'll call you". You will often find IoC implemented using an IoC container, such as ServiceCollection in DotNet Core. Let's implement our class in a console application using this:
```C#
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
```
This allows us to bind our dependencies early in the call stack of our program so that they may be resolved later in its lifetime. e.g. `RegisterServices()`

We can then have our service provider call our consuming class and provide a dependency instance via constructor injection. e.g. 

`var game = new WalkingSimulatorGame(ServiceProvider.GetService<IActionProvider>());`

**Summary:**

Dependency injection lets us invert the responsibility of constructing class dependencies from the consumer to an external provider, such as the .Net Core DI framework, or others such as AutoFac, StructureMap, etc.

### **Resources:**

[Dependency injection - Wikipedia](https://en.wikipedia.org/wiki/Dependency_injection)

[Control flow - Wikipedia](https://en.wikipedia.org/wiki/Control_flow)

[Dependency Injection with .NET Core](https://msdn.microsoft.com/en-us/magazine/mt707534.aspx)

[Inversion of control - Wikipedia](https://en.wikipedia.org/wiki/Inversion_of_control)
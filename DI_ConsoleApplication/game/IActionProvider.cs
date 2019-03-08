namespace DI_ConsoleApplication.game
{
    public interface IActionProvider
    {
        void ProcessAction(string inputText);
        void DisplayActions();
    }
}
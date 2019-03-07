namespace DI_ConsoleApplication
{
    public interface IActionProvider
    {
        void DisplayActions();
        void WalkUp();
        void WalkDown();
        void WalkLeft();
        void WalkRight();
        void ProcessAction(string inputText);
    }
}
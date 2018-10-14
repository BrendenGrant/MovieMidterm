namespace MovieMiderm.Interfaces
{
    public interface IMenuCommands
    {
        void PrintCurrentMenu();
        void PrintNextMenu();
        void ClearScreen();
        bool IsUserInputValid { get; set; }
    }
}
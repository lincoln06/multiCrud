namespace multiCRUD.Interfaces
{
    public interface IMenu
    {
        void AskWhatToDo();
        void ChooseElementType();
        void ShowBookArgRequest(int option);
        void ShowMainMenu();
        void ShowUserArgRequest(int option);
        void ShowWrongValueError();
    }
}
namespace multiCRUD.Interfaces
{
    public interface IMenu
    {
        void AskWhatToDo();
        void ChooseElementType();
        void ShowBookArgRequest(int option);
        void ShowMainMenu();
        void ShowNotFoundError();
        void ShowUserArgRequest(int option);
        void ShowWrongValueError();
    }
}
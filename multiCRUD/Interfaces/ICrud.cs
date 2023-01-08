using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCrud
{
    public interface ICrud
    {
        void AddToDB(IElement element);
        void AddABookToDB(Book book);
        void AddUserToDB(User user);
        User? FindUserInDB(SearchArguments searchArguments);
        Book? FindBookInDB(SearchArguments searchArguments);
        IElement? FindElementInDB(IElement element, SearchArguments searchArguments);
        bool CheckIfOccursInDatabase(IElement _element);
    }
}
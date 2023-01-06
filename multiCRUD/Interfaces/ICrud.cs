using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCrud
{
    public interface ICrud
    {
        void Add(IElement element);
        void AddABook(Book book);
        void AddUser(User user);
        User? FindUser(SearchArguments searchArguments);
        Book? FindBook(SearchArguments searchArguments);
        IElement? Find(IElement element, SearchArguments searchArguments);
    }
}
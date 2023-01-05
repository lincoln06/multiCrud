using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCrud
{
    public interface ICrud
    {
        void Add(IElement element);
        void AddABook(Book book);
        void AddUser(User user);
        IElement FindUser(string email, string password);
        IElement FindBook(string authorLastName, string title);
        IElement Find(IElement element, SearchArguments searchArguments);
    }
}
using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCRUD.Model.Crud
{
    public class SqliteCrud : ICrud
    {
        public void Add(IElement element)
        {
            if (element is Book)
            {
                Book book = element as Book;
                AddABook(book);
            }
            if (element is User)
            {
                User user = element as User;
                AddUser(user);
            }
        }

        public void AddABook(Book book)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IElement? Find(IElement element, SearchArguments searchArguments)
        {
            throw new NotImplementedException();
        }

        public Book? FindBook(SearchArguments searchArguments)
        {
            throw new NotImplementedException();
        }

        public User? FindUser(SearchArguments searchArguments)
        {
            throw new NotImplementedException();
        }
    }
}

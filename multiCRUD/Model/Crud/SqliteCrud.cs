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
            Console.WriteLine("Dodaję książkę do SQlite");
        }

        public void AddUser(User user)
        {
            Console.WriteLine("Dodaję usera do SQlite");
        }

        public IElement Find(IElement element, SearchArguments searchArguments)
        {
            throw new NotImplementedException();
        }

        public IElement FindBook(string authorLastName, string title)
        {
            Console.WriteLine("Znalazłem książkę");
            return null;
        }

        public IElement FindUser(string email, string password)
        {
            Console.WriteLine("Znalazłem usera");
            return null;
        }
    }
}

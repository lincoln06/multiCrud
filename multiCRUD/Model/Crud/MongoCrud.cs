using MongoDB.Driver;
using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCRUD.Model.Crud
{
    public class MongoCrud : CrudBase, ICrud
    {
        
        private readonly static MongoClient _client = new MongoClient();
        private readonly static IMongoDatabase _database = _client.GetDatabase(_databaseName);
        private readonly IMongoCollection<User> _usersCollection = _database.GetCollection<User>(_usersTableName);
        private readonly IMongoCollection<Book> _booksCollection=_database.GetCollection<Book>(_booksTableName);
        public void Add(IElement element)
        {
            if(element is Book)
            {
                Book book= (Book)element;
                AddABook(book);
            }
            if(element is User)
            {
                User user= (User)element;
                AddUser(user);
            }
        }

        public void AddABook(Book book)
        {
            _booksCollection.InsertOne(book);
        }

        public void AddUser(User user)
        {
            _usersCollection.InsertOne(user);
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

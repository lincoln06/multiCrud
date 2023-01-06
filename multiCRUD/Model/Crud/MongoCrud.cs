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
            if (element is Book)
            {
                Book book = FindBook(searchArguments);
                return book;
            }
            else
            {
                if (element is User)
                {
                    User user = FindUser(searchArguments);
                    return user;
                }
                else return null;
            }
            
        }

        public Book? FindBook(SearchArguments searchArguments)
        {
            var filter = Builders<Book>.Filter.And(
                Builders<Book>.Filter.Eq("AuthorLastName", searchArguments._arg1),
                Builders<Book>.Filter.Eq("Title", searchArguments._arg2));
            try
            {
                var record = (Book)_booksCollection.Find(filter).First();

                return record;
            }
            catch
            {
                return null;
            }
        }

        public User? FindUser(SearchArguments searchArguments)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq("Email", searchArguments._arg1),
                Builders<User>.Filter.Eq("Password", searchArguments._arg2));
            try
            {
                var record = (User)_usersCollection.Find(filter).First();

                return record;
            }
            catch
            {
                return null;
            }
        }
    }
}

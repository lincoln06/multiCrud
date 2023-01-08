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
        public void AddToDB(IElement element)
        {
            if(element is Book)
            {
                Book book= (Book)element;
                AddABookToDB(book);
            }
            if(element is User)
            {
                User user= (User)element;
                AddUserToDB(user);
            }
        }

        public void AddABookToDB(Book book)
        {
            _booksCollection.InsertOne(book);
        }

        public void AddUserToDB(User user)
        {
            _usersCollection.InsertOne(user);
        }

        public bool CheckIfOccursInDatabase(IElement _element)
        {
            if (_element is Book) return CheckIfBookOccursInDB(_element);
            if (_element is User) return CheckIfUserOccursInDB(_element);
            return false;
        }

        private bool CheckIfUserOccursInDB(IElement element)
        {
            User user = (User)element;
            var filter = Builders<User>.Filter.Eq("Email", user._email);
            try
            {
                var record = _usersCollection.Find(filter).First();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckIfBookOccursInDB(IElement element)
        {
            Book book = (Book)element;
            var filter = Builders<Book>.Filter.And(
                Builders<Book>.Filter.Eq("AuthorLastName", book._authorLastName),
                Builders<Book>.Filter.Eq("Title", book._title));
            try
            {
                var record = _booksCollection.Find(filter).First();

                return true; ;
            }
            catch
            {
                return false;
            }
        }

        public IElement? FindElementInDB(IElement element, SearchArguments searchArguments)
        {
            if (element is Book)
            {
                element = FindBookInDB(searchArguments);
            }
            if (element is User)
            {
                element = FindUserInDB(searchArguments);
            }
            return element;
            
        }

        public Book? FindBookInDB(SearchArguments searchArguments)
        {
            var filter = Builders<Book>.Filter.And(
                Builders<Book>.Filter.Eq("AuthorLastName", searchArguments._arg1),
                Builders<Book>.Filter.Eq("Title", searchArguments._arg2));
            try
            {
                var record = _booksCollection.Find(filter).First();

                return record;
            }
            catch
            {
                return null;
            }
        }

        public User? FindUserInDB(SearchArguments searchArguments)
        {
            var filter = Builders<User>.Filter.And(
                Builders<User>.Filter.Eq("Email", searchArguments._arg1),
                Builders<User>.Filter.Eq("Password", PasswordEncryptor.Encrypt(searchArguments._arg2, searchArguments._arg1)));
            try
            {
                var record = _usersCollection.Find(filter).First();
                return record;
            }
            catch
            {
                return null;
            }
        }
    }
}

using Microsoft.Data.Sqlite;
using MongoDB.Driver;
using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCRUD.Model.Crud
{
    public class SqliteCrud : ICrud
    {
        private static SqliteConnection _connection = new("Data Source=Data/Service.db");
        SqliteCommand _command=_connection.CreateCommand();
        public void Add(IElement element)
        {
            using (_connection)
            {
                _connection.Open();
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
                _connection.Close();
            }
        }

        public void AddABook(Book book)
        {
            _command.CommandText = @"insert into Books(AuthorFirstName,AuthorLastName,Title,Year,Genre) values('" + book._authorFirstName + "','" + book._authorLastName + "','" + book._title + "','" + book._year + "','"+book._genre+"')";
            _command.ExecuteNonQuery();
        }

        public void AddUser(User user)
        {
            _command.CommandText = @"insert into Users(FirstName,LastName,Email,Password) values('" + user._firstName + "','" + user._lastName + "','" + user._email + "','" + user._password + "')";
            _command.ExecuteNonQuery();
        }

        public bool CheckIfExists(IElement _element)
        {
            using (_connection)
            {
                _connection.Open();
                if (_element is Book) return CheckIfBookExists(_element);
                if (_element is User) return CheckIfUserExists(_element);
                _connection.Close();
            }
            return false;
        }

        private bool CheckIfUserExists(IElement element)
        {
            User user=(User)element;
            _command.CommandText = @"select * from Users where Email='" + user._email + "'";
            var reader = _command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return false;
            return true;

        }

        private bool CheckIfBookExists(IElement element)
        {
            Book book = (Book)element;
            _command.CommandText = @"select * from Books where AuthorLastName='" + book._authorLastName + "' and Title='" + book._title + "'";
            var reader = _command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return false;
            return true;
        }

        public IElement? Find(IElement element, SearchArguments searchArguments)
        {
            _connection.Open();
            if(element is Book)
            {
                element = FindBook(searchArguments);
            }
            if(element is User)
            {
                element = FindUser(searchArguments);
            }
            _connection.Close();
            return element;
        
        }

        public Book? FindBook(SearchArguments searchArguments)
        {
            _command.CommandText = @"select * from Books where AuthorLastName='" + searchArguments._arg1 + "' and Title='" + searchArguments._arg2 + "'";
            _command.ExecuteNonQuery();
            var reader = _command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return null;
            return new Book(reader.GetString(0), reader.GetString(1), reader.GetString(2), ushort.Parse(reader.GetString(3)), reader.GetString(4));
        }

        public User? FindUser(SearchArguments searchArguments)
        {
            _command.CommandText = @"select * from Users where Email='" + searchArguments._arg1 + "' and Password='" + PasswordEncryptor.Encrypt(searchArguments._arg2,searchArguments._arg1) + "'";
            _command.ExecuteNonQuery();
            var reader = _command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return null;
            return new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
        }
    }
}

using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Model
{
    public class ResponseProvider : IResponseProvider
    {
        private readonly IMenu _menu;
        public ResponseProvider(IMenu menu)
        {
            _menu = menu;
        }

        public IElement GetElementFromUser(IElement element)
        {
            if(element is Book)
            {
                element = GetBook();
            }
            if(element is User)
            {
                element = GetUser();
            }
            return element;
        }

        private User GetUser()
        {
            Console.WriteLine("Imię");
            string firstName = Console.ReadLine();
            Console.WriteLine("Nazwisko");
            string lastName = Console.ReadLine();
            Console.WriteLine("E-mail");
            string email= Console.ReadLine();
            Console.WriteLine("Hasło");
            string password=Console.ReadLine();
            return new User
            {
                _firstName = firstName,
                _lastName = lastName,
                _email = email,
                _password = password
            };
        }

        private Book GetBook()
        {
            Console.WriteLine("Imię autora");
            string firstName = Console.ReadLine();
            Console.WriteLine("Nazwisko autora");
            string lastName = Console.ReadLine();
            Console.WriteLine("Tytuł");
            string title = Console.ReadLine();
            Console.WriteLine("Rok");
            ushort year = ushort.Parse(Console.ReadLine());
            Console.WriteLine("Gatunek");
            string genre = Console.ReadLine();
            return new Book
            {
                _authorFirstName = firstName,
                _authorLastName = lastName,
                _title=title,
                _year=year,
                _genre=genre
            };
        }

        public int GetIntFromUser()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }

        public SearchArguments GetSearchArgumentsFromUser(IElement element)
        {
            string arg1, arg2;
            if (element is Book)
            {
                _menu.ShowBookArgRequest(0);
                arg1 = Console.ReadLine();
                _menu.ShowBookArgRequest(1);
                arg2 = Console.ReadLine();
            }
            else {
                _menu.ShowUserArgRequest(0);
                arg1 = Console.ReadLine();
                _menu.ShowUserArgRequest(1);
                arg2 = Console.ReadLine();
            }
            return new SearchArguments(arg1, arg2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCRUD.View
{
    public class Viewer : IViewer
    {
        public bool ShowElement(IElement element)
        {
            if (element is null) return false;
            if (element is Book)
            {
                Book book=element as Book;
                ShowBook(book);
            }
            if (element is User)
            {
                User user= element as User;
                ShowUser(user);
            }
            return true;
        }
        public void ShowBook(Book book)
        {
            Console.WriteLine($"Autor:\t{book._authorFirstName} {book._authorFirstName}");
            Console.WriteLine($"Tytuł:\t{book._title}");
            Console.WriteLine($"Gatunek:\t{book._genre}");
            Console.WriteLine($"Rok wydania:\t{book._year}");

        }
        public void ShowUser(User user)
        {
            Console.WriteLine($"Imię\t{user._firstName}");
            Console.WriteLine($"Nazwisko\t{user._lastName}");
            Console.WriteLine($"E-mail\t{user._email}");
        }
    }
}

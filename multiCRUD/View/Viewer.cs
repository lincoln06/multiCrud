using FluentValidation.Results;
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
            Console.WriteLine($"Autor:\t{book._authorFirstName} {book._authorLastName}");
            Console.WriteLine($"Tytuł:\t{book._title}");
            Console.WriteLine($"Gatunek:\t{book._genre}");
            Console.WriteLine($"Rok wydania:\t{book._year}");
            Console.ReadKey();

        }
        public void ShowUser(User user)
        {
            Console.WriteLine($"Imię\t{user._firstName}");
            Console.WriteLine($"Nazwisko\t{user._lastName}");
            Console.WriteLine($"E-mail\t{user._email}");
            Console.ReadKey();
        }

        public void ShowAllDoneMessage()
        {
            Console.WriteLine("Pomyślnie dodano");
            Console.ReadKey();
        }

        public void ShowErrors(List<ValidationFailure> validationFailures)
        {
            Console.WriteLine("\n");
            Console.WriteLine(new String('-',35));
            Console.WriteLine("WPROWADZONO NIEPRAWIDŁOWE WARTOŚCI!");
            Console.WriteLine(new String('-', 35));
            foreach (ValidationFailure failure in validationFailures)
            {
                Console.WriteLine(failure.ToString());
            }
            Console.ReadKey();
        }

        public void ShowElementOccursError(object value)
        {
            string type = String.Empty;
            switch(value.ToString())
            {
                case "User":
                    type = "Użytkownik";
                    break;
                case "Book":
                    type = "Książka";
                    break;
                default:
                    type = "Obiekt";
                    break;
            }
            Console.WriteLine($"{type} już istnieje w repozytorium");
            Console.ReadKey();
        }

        public void ShowNotFoundError()
        {
            Console.WriteLine("Nie znaleziono");
            Console.ReadKey();
        }
    }
}

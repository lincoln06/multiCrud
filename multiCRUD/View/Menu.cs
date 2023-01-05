using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multiCRUD.Interfaces;

namespace multiCRUD.View
{
    public class Menu : IMenu
    {
        public void AskWhatToDo()
        {
            Console.WriteLine("Wybierz typ");
            Console.WriteLine("1\tDodaj");
            Console.WriteLine("2\tZnajdź");
        }

        public void ChooseElementType()
        {
            Console.WriteLine("Wybierz typ");
            Console.WriteLine("1\tKsiążka");
            Console.WriteLine("2\tUżytkownik");
        }

        public void ShowBookArgRequest(int option)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("Podaj nazwisko autora");
                    break;
                case 1:
                    Console.WriteLine("Podaj tytuł");
                    break;
            }
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("Wybierz CRUD");
            Console.WriteLine("1\tMongoDB");
            Console.WriteLine("2\tSQLite");
        }

        public void ShowNotFoundError()
        {
            Console.WriteLine("Nie znaleziono");
        }

        public void ShowUserArgRequest(int option)
        {
            switch(option)
            {
                case 0:
                    Console.WriteLine("Podaj e-mail");
                    break;
                case 1:
                    Console.WriteLine("Podaj hasło");
                    break;
            }
        }

        public void ShowWrongValueError()
        {
            Console.WriteLine("Nieprawidłowa wartość");
        }
    }
}

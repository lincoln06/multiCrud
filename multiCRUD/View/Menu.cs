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

        public void ShowMainMenu()
        {
            Console.WriteLine("Wybierz CRUD");
            Console.WriteLine("1\tMongoDB");
            Console.WriteLine("2\tSQLite");
        }

        public void ShowWrongValueError()
        {
            Console.WriteLine("Nieprawidłowa wartość");
        }
    }
}

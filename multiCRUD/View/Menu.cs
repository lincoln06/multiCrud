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
        public void ShowMainMenu()
        {
            Console.WriteLine("Wyświetlam menu");
            //TODO Menu
        }

        public void ShowWrongValueError()
        {
            Console.WriteLine("Wyświetlam błąd");
            //TODO Error
        }
    }
}

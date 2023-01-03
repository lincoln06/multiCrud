using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multiCrud;
using multiCRUD.Interfaces;

namespace multiCRUD.Model
{
    public class App : IApp
    {
        private readonly IMenu _menu;
        private readonly ICrud _mongoCrud;
        private readonly ICrud _sqliteCrud;
        private readonly IResponseProvider _responseProvider;
        private ICrud _crud;
        public App(IMenu menu, ICrud mongoCrud, ICrud sqliteCrud, IResponseProvider responseProvider)
        {
            _menu = menu;
            _mongoCrud = mongoCrud;
            _sqliteCrud = sqliteCrud;
            _responseProvider = responseProvider;
        }

        public void Start()
        {
            _menu.ShowMainMenu();
            int choose=_responseProvider.GetIntFromUser();
            switch(choose)
            {
                case 0:
                    _crud = _mongoCrud;
                    break;
                case 1:
                    _crud = _sqliteCrud;
                    break;
                default:
                    _menu.ShowWrongValueError();
                    Start();
                    break;
            }
            
        }
    }
}

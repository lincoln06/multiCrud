using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model.Crud;
using multiCRUD.Model.Elements;

namespace multiCRUD.Model
{
    public class App : IApp
    {
        private readonly IMenu _menu;
        private readonly ICrud _mongoCrud;
        private readonly ICrud _sqliteCrud;
        private readonly IResponseProvider _responseProvider;
        private ICrud _crud;
        private IElement _element;
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
            _crud = _crud as MongoCrud;
            switch(choose)
            {
                case 1:
                    _crud = _mongoCrud;
                    break;
                case 2:
                    _crud = _sqliteCrud;
                    break;
                default:
                    _menu.ShowWrongValueError();
                    Start();
                    break;
            }
            _menu.ChooseElementType();
            choose = _responseProvider.GetIntFromUser();
            switch(choose)
            {
                case 1:
                    _crud.Add = _crud.AddABook;
                    _crud.Find = _crud.FindBook;
                    break;
                case 2:
                    _crud.Add = _crud.AddUser;
                    _crud.Find = _crud.FindUser;
                    break;
                default:
                    _menu.ShowWrongValueError();
                    Start();
                    break;
            }
            _menu.AskWhatToDo();
            choose=_responseProvider.GetIntFromUser();
            //TODO zaprogramować pobieranie wartości od użytkownika

        }
    }
}

using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model.Crud;
using multiCRUD.Model.Elements;

namespace multiCRUD.Model
{
    public class App : IApp
    {
        private readonly IMenu _menu;
        private readonly IResponseProvider _responseProvider;
        private ICrud _crud;
        private IElement _element;
        private SearchArguments _searchArguments;
        private readonly IViewer _viewer;
        private int _response;
        private bool _occursInDatabase;
        public App(IMenu menu, IResponseProvider responseProvider, IViewer viewer)
        {
            _menu = menu;
            _responseProvider = responseProvider;
            _viewer = viewer;
        }

        public void Start()
        {
            _menu.ShowMainMenu();
            _response = _responseProvider.GetIntFromUser();
            switch (_response)
            {
                case 1:
                    _crud = new MongoCrud();
                    break;
                case 2:
                    _crud = new SqliteCrud();
                    break;
                default:
                    _menu.ShowWrongValueError();
                    break;
            }
            _menu.ChooseElementType();
            _response = _responseProvider.GetIntFromUser();
            switch (_response)
            {
                case 1:
                    _element = new Book();
                    break;
                case 2:
                    _element = new User();
                    break;
                default:
                    _menu.ShowWrongValueError();
                    break;
            }
            _menu.AskWhatToDo();
            _response = _responseProvider.GetIntFromUser();
            switch (_response)
            {
                case 1:
                    _element = _responseProvider.GetElementFromUser(_element);
                    _occursInDatabase = _crud.CheckIfOccursInDatabase(_element);
                    if (_occursInDatabase)
                    {
                        _viewer.ShowElementOccursError(_element.GetType().Name);
                    }
                    else
                    {
                        if (_responseProvider.ShowOutputMessage(_element.Validate())) _crud.AddToDB(_element);
                    }
                    break;
                case 2:
                    _searchArguments = _responseProvider.GetSearchArgumentsFromUser(_element);
                    _element = _crud.FindElementInDB(_element, _searchArguments);
                    if (!_viewer.ShowElement(_element)) _viewer.ShowNotFoundError();
                    break;
            }
        }
    }
}
  

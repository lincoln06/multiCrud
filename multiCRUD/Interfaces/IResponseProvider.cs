using multiCRUD.Model.Elements;

namespace multiCRUD.Interfaces
{
    public interface IResponseProvider
    {
        IElement GetElementFromUser(IElement element);
        int GetIntFromUser();
        SearchArguments GetSearchArgumentsFromUser(IElement element);
    }
}
using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCrud
{
    public interface ICrud
    {
        delegate void AddDelegate(IElement element);
        delegate IElement FindDelegate(string arg1, string arg2);
        FindDelegate Find { get; set; }
        AddDelegate Add { get; set; }
        void AddABook(IElement book);
        void AddUser(IElement user);
        IElement FindUser(string email, string password);
        IElement FindBook(string authorLastName, string title);
    }
}
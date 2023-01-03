using multiCrud;
using multiCRUD.Interfaces;
using multiCRUD.Model.Elements;

namespace multiCRUD.Model.Crud
{
    public class SqliteCrud : ICrud
    {
        public ICrud.FindDelegate Find { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICrud.AddDelegate Add { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddABook(IElement book)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IElement user)
        {
            throw new NotImplementedException();
        }

        public IElement FindBook(string authorLastName, string title)
        {
            throw new NotImplementedException();
        }

        public IElement FindUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

using multiCRUD.Interfaces;

namespace multiCrud
{
    public interface ICrud
    {
        void Add();
        IElement Find(string arg1, string arg2);
    }
}
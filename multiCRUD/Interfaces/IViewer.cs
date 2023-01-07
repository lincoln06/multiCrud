using FluentValidation.Results;
using multiCRUD.Model.Elements;

namespace multiCRUD.Interfaces
{
    public interface IViewer
    {
        bool ShowElement(IElement element);
        void ShowUser(User user);
        void ShowBook(Book book);
        void ShowAllDoneMessage();
        void ShowErrors(List<ValidationFailure> validationFailures);
        void ShowElementExistsError(object value);
    }
}
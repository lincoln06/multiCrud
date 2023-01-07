using FluentValidation.Results;

namespace multiCRUD.Interfaces
{
    public interface IElement
    {
        List<ValidationFailure>? Validate();
    }
}

using FluentValidation;
using multiCRUD.Model.Elements;

namespace multiCRUD.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book._authorFirstName).NotEmpty().NotNull().Length(3, 20).Matches("^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]*$").
                WithMessage("Imię musi zaczynać się wielką literą i składać z 3-30 znaków");
            RuleFor(book => book._authorLastName).NotEmpty().NotNull().Length(3, 30).Matches("^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]*(?:[-'][a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ]+)*$").
                WithMessage("Nazwisko musi zaczynać się wielką literą i składać z 3-30 znaków");
            RuleFor(book => book._title).NotEmpty().NotNull().Length(2, 40).
                WithMessage("Tytuł musi zawierać 2-40 znaków");
            RuleFor(book => book._year).LessThanOrEqualTo(ushort.Parse(DateTime.Now.ToString("yyyy"))).
                WithMessage("Rok musi być liczbą czterocyfrową");
            RuleFor(book=>book._genre).NotEmpty().NotNull().Length(3, 30).Matches("^[A-Z][A-Za-z-]*$").
                WithMessage("Gatunek musi zaczynać się wielką literą i zawierać tylko litery i/lub znak '-'");
        }
    }
}

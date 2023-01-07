using FluentValidation;
using multiCRUD.Model.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Validation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator() {
            RuleFor(user => user._firstName).NotEmpty().NotNull().Length(3, 20).Matches("^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]*$").
                WithMessage("Imię musi zaczynać się wielką literą i składać z 3-30 znaków");
            RuleFor(user => user._lastName).NotEmpty().NotNull().Length(3, 30).Matches("^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]*(?:[-'][a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ]+)*$").
                WithMessage("Nazwisko musi zaczynać się wielką literą i składać z 3-30 znaków"); ;
            RuleFor(user => user._email).EmailAddress().
                WithMessage("Nieprawidłowy format adresu e-mail");
            RuleFor(user => user._password).Matches("(?=.*[A-Z])(?=.*[0-9])(?=.*[\\W_])[\\S]{8,}").
                WithMessage("Hasło powinno składać się z minimum 8 znaków oraz zawierać jedną wielką literę, jedną cyfrę oraz jeden znak specjalny");
        }
    }
}

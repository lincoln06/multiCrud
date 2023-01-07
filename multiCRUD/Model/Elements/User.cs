using FluentValidation.Results;
using MongoDB.Bson.Serialization.Attributes;
using multiCRUD.Interfaces;
using multiCRUD.Validation;

namespace multiCRUD.Model.Elements
{
    [BsonIgnoreExtraElements]
    public class User : IElement
    {

        [BsonElement("FirstName")]
        public string _firstName { get; private set; }
        [BsonElement("LastName")]
        public string _lastName { get; private set; }
        [BsonElement("Email")]
        public string _email { get; private set; }
        [BsonElement("Password")]
        public string _password { get; private set; }

        public User(string firstName, string lastName, string email, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
        }
        public User()
        {

        }
        public List<ValidationFailure>? Validate()
        {
            UserValidator validator = new();
            ValidationResult result = validator.Validate(this);
            if (result.IsValid)
            {
                _password = PasswordEncryptor.Encrypt(_password, _email);

                // Pola _email, _lastName, _firstName należy przepisać - z tej racji,
                // że hasło po walidacji jest kodowane, MongoDB zapisuje je na pierwszej na górze,
                // co nie zgadza się z kolejnością pól w konstrukcji klasy.Powoduje to taki błąd,
                // że podczas wyszukiwania obiektu klasy User, funkcja Find() zwraca obiekt z wartościami
                // null wpisanymi wszędzie prócz hasła, co uniemożliwia wyświetlenie pól _firstName, _lastName,
                // _email po odnalezieniu Usera w bazie - wnioskuję, że na samej górze MongoDB zapisuje wartości,
                // które były modyfikowane. Przepisanie pól "na odwrót" pozwala ustawić je w Mongo
                //  w dobrej kolejności. W klasie Book nie jest to konieczne, ponieważ żadne dane nie są szyfrowane.

                _email = _email;
                _lastName = _lastName;
                _firstName = _firstName;
                return null;
            }
            return result.Errors;
        }
    }
}

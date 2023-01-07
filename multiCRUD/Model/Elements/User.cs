using FluentValidation.Results;
using MongoDB.Bson.Serialization.Attributes;
using multiCRUD.Interfaces;
using multiCRUD.Validation;

namespace multiCRUD.Model.Elements
{
    [BsonIgnoreExtraElements]
    public class User:IElement
    {
        [BsonElement("FirstName")]
        public string _firstName { get;}
        [BsonElement("LastName")]
        public string _lastName { get;}
        [BsonElement("Email")]
        public string _email { get; }
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
                this._password = PasswordEncryptor.Encrypt(_password, _email);
                return null;
            }
            return result.Errors;
        }
    }
}

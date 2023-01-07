using FluentValidation.Results;
using MongoDB.Bson.Serialization.Attributes;
using multiCRUD.Interfaces;
using multiCRUD.Validation;

namespace multiCRUD.Model.Elements
{
    [BsonIgnoreExtraElements]
    public class Book:IElement
    {
        [BsonElement("AuthorFirstName")]
        public string _authorFirstName { get;}
        [BsonElement("AuthorLastName")]
        public string _authorLastName { get;}
        [BsonElement("Title")]
        public string _title { get; }
        [BsonElement("Year")]
        public ushort _year { get; }
        [BsonElement("Genre")]
        public string _genre { get; }
        public Book(string authorFirstName, string authorLastName, string title, ushort year, string genre)
        {
            _authorFirstName = authorFirstName;
            _authorLastName = authorLastName;
            _title = title;
            _year = year;
            _genre = genre;
        }
        public Book() { }

        public List<ValidationFailure>? Validate()
        {
            BookValidator validator = new();
            ValidationResult result= validator.Validate(this);
            if (result.IsValid) return null;
            return result.Errors;
        }
    }
}

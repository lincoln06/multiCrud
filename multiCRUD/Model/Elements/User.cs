using MongoDB.Bson.Serialization.Attributes;
using multiCRUD.Interfaces;

namespace multiCRUD.Model.Elements
{
    [BsonIgnoreExtraElements]
    public class User:IElement
    {
        [BsonElement]
        public string _firstName { get; set; }
        [BsonElement]
        public string _lastName { get; set; }
        [BsonElement]
        public string _email { get; set; }
        [BsonElement]
        public string _password { get; set; }
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
    }
}

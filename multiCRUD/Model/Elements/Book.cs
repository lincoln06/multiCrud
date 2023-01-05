using MongoDB.Bson.Serialization.Attributes;
using multiCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Model.Elements
{
    [BsonIgnoreExtraElements]
    public class Book:IElement
    {
        [BsonElement]
        public string _authorFirstName { get; set; }
        [BsonElement]
        public string _authorLastName { get; set; }
        [BsonElement]
        public string _title { get; set; }
        [BsonElement]
        public ushort _year { get; set; }
        [BsonElement]
        public string _genre { get; set; }
        public Book(string authorFirstName, string authorLastName, string title, ushort year, string genre)
        {
            _authorFirstName = authorFirstName;
            _authorLastName = authorLastName;
            _title = title;
            _year = year;
            _genre = genre;
        }
        public Book() { }
    }
}

using multiCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Model.Elements
{
    public class Book:IElement
    {
        public string _authorFirstName { get; }
        public string _authorLastName { get; } 
        public ushort _year { get; }
        public string _genre { get; }
        public Book(string authorFirstName, string authorLastName, ushort year, string genre)
        {
            _authorFirstName = authorFirstName;
            _authorLastName = authorLastName;
            _year = year;
            _genre = genre;
        }
    }
}

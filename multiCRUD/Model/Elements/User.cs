using multiCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Model.Elements
{
    public class User:IElement
    {
        public string _firstName { get; }
        public string _lastName { get; }
        public string _email { get; }
        public string _password { get; }
        public User(string firstName, string lastName, string email, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
        }
    }
}

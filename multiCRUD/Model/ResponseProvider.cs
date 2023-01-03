using multiCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiCRUD.Model
{
    public class ResponseProvider : IResponseProvider
    {
        public int GetIntFromUser()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }
    }
}

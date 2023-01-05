using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using multiCRUD.Interfaces;

namespace multiCRUD.Model.Elements
{
    public class SearchArguments:ISearchArguments
    {
        public string _arg1 { get; }
        public string _arg2 { get; }
        public SearchArguments(string arg1, string arg2)
        {
            _arg1 = arg1;
            _arg2 = arg2;
        }
        public SearchArguments()
        {

        }
    }
}

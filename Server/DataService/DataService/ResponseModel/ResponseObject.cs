using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.ResponseModel
{
    public class ResponseObject<Object>
    {
        public bool IsError { get; set; }
        public String ErrorMessage { get; set; }
        public String WarningMessage { get; set; }
        public Object ObjReturn { get; set; }
    }
}

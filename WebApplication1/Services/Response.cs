using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class Response
    {
        public Object Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get;set;}

        public List<String> ErrorList = new List<string>();
    }
}

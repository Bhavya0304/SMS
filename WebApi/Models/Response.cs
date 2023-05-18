using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Response<T>
    {
        public int Status { get; set; }
        public string Messege { get; set; }
        public T Data { get; set; }
        public string ExceptionMessege { get; set; }
    }
}
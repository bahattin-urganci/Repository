using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Model
{
    public class ActionResponse<T> where T : class
    {
        public Types.Response ResponseType { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }

    }
}

using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPos.Service
{
    public class BaseService
    {
        public T Map<T>(object source) where T : class => Mapper.MapContext<T>.Map(source);
        public ActionResponse<T> CreateResponse<T>(T response = null) where T : class => new ActionResponse<T>() { ResponseType = Types.Response.Ok, Response = response };
    }
}

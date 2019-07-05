using PawPos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Service
{
    public interface IBaseService<T> where T:class
    {
        Task<List<T>> AllAsync();
        Task<ActionResponse<T>> SaveAsync(T data);
        Task RemoveAsync(T data);
        Task<T> FindOneAsync(string id);
    }
}

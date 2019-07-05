using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PawPos.Repository
{
    public interface IRepository<T> where T : class
    {
        bool CollectionExists();
        Task<bool> ExistsAsync(string id);
        bool Exists(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();        
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<string> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<string> UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task<string> SaveAsync(T entity);
    }
}

using PawPos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PawPos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PawPos.EFRepository
{
    public class EfRepository<T> : IDbManager, IRepository<T> where T : BaseEntity
    {
        private PawPosDbContext _dbContext;
        private DbSet<T> _dbSet;
        public EfRepository(PawPosDbContext pawPosDbContext)
        {
            _dbContext = pawPosDbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public Task<string> AddAsync(T entity)
        {
            _dbSet.AddAsync(entity);

            return Task.FromResult("added");
        }

        public Task AddRangeAsync(IEnumerable<T> entities) => _dbSet.AddRangeAsync(entities);

        public bool CollectionExists()
        {
            //ef bunu desteklemez
            throw new NotImplementedException();
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var data = await _dbSet.Where(predicate).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await _dbSet.ToListAsync();
            return data;
        }

        public Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression) => _dbSet.FindAsync(expression);

        public Task RemoveAsync(T entity) => Task.Run(() => _dbSet.Remove(entity));

        public Task RemoveRangeAsync(IEnumerable<T> entities) => Task.Run(() => _dbSet.RemoveRange(entities));

        public async Task<string> SaveAsync(T entity)
        {
            await _dbContext.SaveChangesAsync();
            return "Saved";
        }

        public void SetConnection(IDbSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<T> SingleOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate) => _dbSet.FirstOrDefaultAsync(predicate);

        public Task<string> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity.Id);
        }
    }
}

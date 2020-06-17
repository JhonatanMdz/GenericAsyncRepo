using GenericRepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, IEntityId
    {
        private DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(DbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                IQueryable<T> query = _dbSet;

                query = includeExpressions.Aggregate(query, (iQueryable, expression) => iQueryable.Include(expression));


                return await query.FirstOrDefaultAsync(e => e.Id == Id);
            }

            return await _dbSet.FindAsync(Id);
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                IQueryable<T> query = _dbSet;
                query = includeExpressions.Aggregate(query, (iQueryable, expression) => iQueryable.Include(expression));
                return await query.ToListAsync();
            }
            else
            {
                return await _dbSet.ToListAsync();
            }
        }

        public async Task<List<T>> SearchForAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}

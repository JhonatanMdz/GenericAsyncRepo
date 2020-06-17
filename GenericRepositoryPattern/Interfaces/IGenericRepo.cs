using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Interfaces
{
    //Async generic methods definition....
    interface IGenericRepo<T> : IDisposable where T : class, IEntityId
    {
        Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includeExpressions);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeExpressions);
        Task<List<T>> SearchForAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entities);
        Task SaveAsync();
    }
}

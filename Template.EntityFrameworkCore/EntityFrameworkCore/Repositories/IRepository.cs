using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Core;

namespace Template.EntityFrameworkCore.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity
    {
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TPrimaryKey id);
        IQueryable<TEntity> GetAll();
    }
}

using System.Threading.Tasks;
using System;
using System.Linq;
using System.Linq.Expressions;
using Template.Core;
using Template.Core.Dependency;

namespace Template.Core.Repositories
{
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {

    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository
        where TEntity : class, IEntity<TPrimaryKey>
    {
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(TPrimaryKey id);
        IQueryable<TEntity> GetAll();
    }

    public interface IRepository : ITransientDependency
    {
        
    }
}

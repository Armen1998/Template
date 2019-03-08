using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Core;
using Template.Core.Repositories;
using Template.Shared.Collection.Extensions;

namespace Template.EntityFrameworkCore.Repositories
{
    public class Repository<TEntity> : Repository<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        public Repository(TemplateDbContext context) : base(context)
        {

        }
    }

    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
      where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly TemplateDbContext _context;

        public Repository(
            TemplateDbContext context
            )
        {
            _context = context;
        }

        protected virtual DbSet<TEntity> Entity => _context.Set<TEntity>();

        public void Insert(TEntity entity)
        {
            Entity.Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync(TEntity entity)
        {
            Entity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TPrimaryKey id)
        {
            Entity.Remove(Entity.Find(id));
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            Entity.Remove(Entity.Find(id));
            await _context.SaveChangesAsync();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Entity.RemoveRange(Entity.Where(predicate));
            _context.SaveChanges();
        }
      
        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Entity.RemoveRange(Entity.Where(predicate));
            await _context.SaveChangesAsync();
        }

        public TEntity Get(TPrimaryKey id)
        {
            return Entity.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entity;
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors.IsNullOrEmpty())
            {
                return GetAll();
            }

            var query = GetAll();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
        }       
      
    }
}

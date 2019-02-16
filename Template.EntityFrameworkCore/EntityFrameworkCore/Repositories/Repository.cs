using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Core;
using Template.Core.Repositories;

namespace Template.EntityFrameworkCore.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
      where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly TemplateDbContext _context;
        private DbSet<TEntity> _entity;

        public Repository(
            TemplateDbContext context
            )
        {
            _context = context;
        }

        protected virtual DbSet<TEntity> Entity => _context.Set<TEntity>();

        public void Delete(TPrimaryKey id)
        {
            Entity.Remove(Entity.Find(id));
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Entity.RemoveRange(Entity.Where(predicate));
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            Entity.Remove(Entity.Find(id));
            await _context.SaveChangesAsync();
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
    }
}

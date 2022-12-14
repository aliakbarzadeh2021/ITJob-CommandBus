using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.EntityFramework.Write.Context.Interfaces;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.EntityFramework.Write.Implement.Context.Implements
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {

        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private IQueryable<TEntity> _query;


        public Repository(IContext context)
        {
            _context = (DataContext)context;
            _dbSet = _context.Set<TEntity>();
        }


        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return _dbSet.AddRange(entities);
        }

        public TEntity Remove(TEntity entity)
        {
            return _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            return _dbSet.RemoveRange(entities);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {

        }
    }
}

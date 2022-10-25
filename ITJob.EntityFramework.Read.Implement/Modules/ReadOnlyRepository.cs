using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ITJob.EntityFramework.Read.Implement.Context.Implements;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.EntityFramework.Read.Implement.Modules
{

    internal class ReadOnlyRepository<TEntity, TGuid> : IReadOnlyRepository<TEntity, TGuid> where TEntity : class
    {

        private readonly ReadOnlyDataContext _context;

        private readonly DbSet<TEntity> _dbSet;
        private IQueryable<TEntity> _query;


        public ReadOnlyRepository()
        {
            _context = new ReadOnlyDataContext();
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindAll(string fieldName, object value)
        {
            throw new NotImplementedException();
        }

        public long Count(string fieldName, object value)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindBy(params TGuid[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindBy(TGuid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TClassField> GetOnlyOneSubDocList<TClassField>(Expression<Func<TEntity, bool>> filterField, Expression<Func<TEntity, IEnumerable<TClassField>>> listField)
        {
            throw new NotImplementedException();
        }
    }
}

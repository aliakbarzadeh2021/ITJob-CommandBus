using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.EntityFramework.Write.Context.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        void Update(TEntity entity);
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        TEntity Remove(TEntity entity);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities);
    }
}

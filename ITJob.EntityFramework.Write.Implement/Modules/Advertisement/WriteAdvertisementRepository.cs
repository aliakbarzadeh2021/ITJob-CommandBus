using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.EntityFramework.Write.Implement.Context.Implements;
using Advertis= ITJob.DomainModel.Modules.AdvertisementModule.Aggregates.Advertisement;

namespace ITJob.EntityFramework.Write.Implement.Modules.Advertisement
{
    internal class WriteAdvertisementRepository : Repository<Advertis>, IWriteAdvertisementRepository
    {
        public Advertis CreateAdvertisement(Advertis entity)
        {
            entity.Id = Guid.NewGuid();
            var t = Add(entity);
            SaveChange();
            return t;
        }
        public WriteAdvertisementRepository(IContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories;
using Adverb= ITJob.DomainModel.Modules.AdvertisementModule.Aggregates.Advertisement;

namespace ITJob.EntityFramework.Read.Implement.Modules.Advertisement
{
    internal class ReadAdvertisementRepository : ReadRepository<Adverb, Guid>, IReadAdvertisementRepository
    {
        

        public ReadAdvertisementRepository()
        {
        }

        public IEnumerable<Adverb> GetAdvertisements()
        {
            return AsQuery();
        }
    }
}

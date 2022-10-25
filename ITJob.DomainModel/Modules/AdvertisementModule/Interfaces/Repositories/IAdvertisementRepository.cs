using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.AdvertisementModule.Aggregates;
using ITJob.DomainModel.Modules.ProfileModule.Aggregates;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.EntityFramework.Read.Context.Interfaces;



namespace ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories
{
    public interface IReadAdvertisementRepository :  IReadRepository<Advertisement, Guid>
    {
        IEnumerable<Advertisement> GetAdvertisements();
    }

    public interface IWriteAdvertisementRepository : IRepository<Advertisement>
    {
        Advertisement CreateAdvertisement(Advertisement entity);
    }
}

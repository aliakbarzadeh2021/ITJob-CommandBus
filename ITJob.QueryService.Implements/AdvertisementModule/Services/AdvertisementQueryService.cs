using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories;
using ITJob.QueryModels.Interfaces.AdvertisementModule;
using ITJob.QueryService.Implements.AdvertisementModule.Mappers;
using ITJob.QueryService.Interfaces.AdvertisementModule;

namespace ITJob.QueryService.Implements.AdvertisementModule.Services
{
    public class AdvertisementQueryService : IAdvertisementQueryService
    {
        private readonly IReadAdvertisementRepository _advertisementRepository;

        public AdvertisementQueryService(IReadAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public IAdvertisementDto GetAdvertisementById(Guid id)
        {
            return _advertisementRepository.Find(id).ToDto();
        }

        public IEnumerable<IAdvertisementDto> SearchAdvertisement(Expression<Func<IAdvertisementDto, bool>> query)
        {
            return _advertisementRepository.GetAdvertisements().Where(x => true).ToDto();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.Commands.Modules.AdvertisementModule.Commands;
using ITJob.DomainModel.Modules.AdvertisementModule.Aggregates;
using ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories;
using SAF.SSN.Kernel.CommandBus.Handling;

namespace ITJob.CommandService.AdvertisementModule
{
    public class AdvertisementCommandService : ICommandHandler<CreateAdvertisementCommand>
    {
        private readonly IWriteAdvertisementRepository _advertisementRepository;

        public AdvertisementCommandService(IWriteAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public void Handle(CreateAdvertisementCommand command)
        {
            var entity = new Advertisement();
            entity.JobTitle = command.JobTitle;
            entity.JobCategory = command.JobCategory;
            entity.Food = command.Food;
            _advertisementRepository.CreateAdvertisement(entity);
        }
    }
}

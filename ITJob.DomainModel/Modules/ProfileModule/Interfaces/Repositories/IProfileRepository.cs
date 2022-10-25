using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.ProfileModule.Aggregates;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.DomainModel.Modules.ProfileModule.Interfaces.Repositories
{
    public interface IProfileRepository : IRepository<Profile, Guid>, IReadOnlyRepository<Profile, Guid>
    {
        Profile GetProfile();
    }
}

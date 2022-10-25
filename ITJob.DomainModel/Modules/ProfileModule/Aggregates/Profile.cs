using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.DomainModel.Modules.ProfileModule.Aggregates
{
    public class Profile : EntityBase<Guid>, IAggregateRoot
    {
        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

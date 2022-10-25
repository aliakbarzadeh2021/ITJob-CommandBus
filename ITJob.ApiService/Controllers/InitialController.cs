using System.Collections.Generic;
using ITJob.ApiService.Factories;
using ITJob.ApiService.SeedWorks.Core;
using SAF.SSN.Kernel.Infrastructure.Helpers;

namespace ITJob.ApiService.Controllers
{
    public class InitialController :ApiControllerBase
    {
        public IEnumerable<EnumType> Get()
        {
            var data = InitialDataFactory.CreateInternalEnumOtherAddOn();
            return data;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories;
using ITJob.DomainModel.SeedWorks.Event;
using SAF.SSN.Kernel.Infrastructure.Domain;

namespace ITJob.DomainModel.Installer
{
    public class DomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().IncludeNonPublicTypes().Pick().WithServiceAllInterfaces());
            DomainServiceLocator.SetContainer(container);
        }
    }
}

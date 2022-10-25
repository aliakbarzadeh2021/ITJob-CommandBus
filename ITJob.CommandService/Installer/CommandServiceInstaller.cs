using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.DomainModel.Installer;
using ITJob.Repository.Installer;
using ITJob.Repository.SeedWorks;
using SAF.SSN.Kernel.CommandBus.Installer;
using SAF.SSN.Kernel.Infrastructure.Configuration;

namespace ITJob.CommandService.Installer
{
    public class CommandServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            DataProviderConfigurator.AddMappingFromAssemblyOf<MappingAssembelyFinder>();
            container.Register(Classes.FromThisAssembly().Pick().WithServiceAllInterfaces().LifestyleTransient());
            container.Install(new CommandBusInstaller());
            container.Install(new DomainInstaller());
            container.Install(new RepositoryInstaller());
            //var bus = container.Resolve<ICommandBus>(); //ToDo => Service: ????
        }
    }
}

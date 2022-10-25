using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.DomainModel.Modules.AdvertisementModule.Interfaces.Repositories;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.EntityFramework.Write.Implement.Context.Implements;
using ITJob.EntityFramework.Write.Implement.Modules.Advertisement;

namespace ITJob.EntityFramework.Write.Implement.Installer
{
    public class EntityFrameworkWriteRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IContext>().ImplementedBy<DataContext>());
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)));
            container.Register(Component.For(typeof(IWriteAdvertisementRepository)).ImplementedBy(typeof(WriteAdvertisementRepository)));
            DataContext.ExecuteMigration();
        }
    }
}

using SAF.SSN.Kernel.Infrastructure.Configuration;

namespace ITJob.ApiService.Installer
{
    using System.Web.Http;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using SeedWorks.Core;
    using CommandService.Installer;
    using Infrastructure.Configurations;
    using QueryService.Implements.Installer;
    using SecurityService.Installer;

    public class ApiServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(new AppConfigApplicationSettings());

            container.Install(new QueryServiceInstaller());
            container.Install(new CommandServiceInstaller());
            container.Install(new SecurityServiceInstaller());

            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<ApiControllerBase>().LifestyleTransient());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
        }
    }
}
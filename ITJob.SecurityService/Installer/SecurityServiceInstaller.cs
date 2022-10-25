namespace ITJob.SecurityService.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using SeedWorks.Core;

    public class SecurityServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<SecurityServiceBase>()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());
        }
    }
}
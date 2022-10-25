namespace ITJob.ApiService
{
    using Castle.Windsor;
    using Installer;

    public class Bootstrapper
    {
        static Bootstrapper()
        {
            Container = new WindsorContainer();
        }

        public static IWindsorContainer Container { get; private set; }

        public static void Run()
        {
            Container.Install(new ApiServiceInstaller());
        }

        public static void ShutDown()
        {
            Container?.Dispose();
        }
    }
}
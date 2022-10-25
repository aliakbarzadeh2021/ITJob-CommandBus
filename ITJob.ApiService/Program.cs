using ITJob.ApiService;

namespace ITJob.ApiService
{
    using System;
    using Topshelf;

    /// <summary>
    /// کلاس اصلی برنامه
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// متد اصلی برنامه
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Starting ...");
            var host = HostFactory.New(x =>
            {
                x.Service<ApiStart>(s =>
                {
                    s.ConstructUsing(name => new ApiStart());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.EnableShutdown();
#if (DEBUG)
                x.RunAsLocalService();
#endif
#if (!DEBUG)
                x.RunAsNetworkService();
#endif
                x.StartAutomaticallyDelayed();

                x.SetDescription("HFJ(c) Organizational Network - IT Job API Host");
                x.SetDisplayName("ITJob API Host");
                x.SetServiceName("ITJobApiHost");
            });

            host.Run();
        }
    }
}
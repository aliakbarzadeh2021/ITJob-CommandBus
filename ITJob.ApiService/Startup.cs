using System;
using System.Web.Http;
using System.Web.Http.Cors;
using ITJob.ApiService;
using ITJob.ApiService.SeedWorks.Helpers;
using ITJob.ApiService.SeedWorks.Resolvers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace ITJob.ApiService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                Bootstrapper.Run();

                var config = new HttpConfiguration
                {
                    DependencyResolver = new ApiDependencyResolver(Bootstrapper.Container)
                };

                var cors = new EnableCorsAttribute(HostSettings.Default.Origins, "*", "*");
                config.EnableCors(cors);

                SecurityService.Startup.ConfigureOAuth(app);

                WebApiConfig.Register(config);

                config.UseJsonFormatters();
                config.EnsureInitialized();

                app.UseCors(CorsOptions.AllowAll);
                app.UseWebApi(config);

                SecurityService.Startup.SetDatabaseInitializer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
namespace ITJob.ApiService
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var routeHandler = HttpClientFactory.CreatePipeline(new HttpControllerDispatcher(config),
                new DelegatingHandler[] {});

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional},
                constraints: null,
                handler: routeHandler);
        }
    }
}
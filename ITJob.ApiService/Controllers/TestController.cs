namespace ITJob.ApiService.Controllers
{
    using SeedWorks.Core;

    public class TestController : ApiControllerBase
    {
        public string Get()
        {
            return "Hello From Api";
        }
    }
}
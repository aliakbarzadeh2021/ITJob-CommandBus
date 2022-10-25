using ITJob.Infrastructure.Configurations;
using System.Configuration;

namespace ITJob.Infrastructure.Configurations
{
    public class AppConfigApplicationSettings : IApplicationSettings
    {
        public string MongoConnectionString
            => ConfigurationManager.ConnectionStrings["MongoConnectionString"].ToString();

        public string MongoDatabaseName
            => ConfigurationManager.AppSettings["MongoDatabaseName"];
    }
}
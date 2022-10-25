namespace ITJob.Infrastructure.Configurations
{
    public interface IApplicationSettings
    {
        /// <summary>
        /// عبارت برقراری ارتباط با سرور مانگو
        /// </summary>
        string MongoConnectionString { get; }

        /// <summary>
        /// نام پایگاه داده مانگو
        /// </summary>
        string MongoDatabaseName { get; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFormatter.cs" company="HFJ">
//   copyright HFJ
// </copyright>
// <summary>
//   Defines the JsonFormatter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ITJob.ApiService.SeedWorks.Helpers
{
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// فرمت سفارشی برای داده جیسون
    /// </summary>
    public static class JsonFormatter
    {
        /// <summary>
        /// سازنده کلاس
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void UseJsonFormatters(this HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new JsonDateTimeConverter());
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new KeyValueConverter());         
        }
    }
}
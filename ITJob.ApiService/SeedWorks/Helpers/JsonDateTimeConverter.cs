using SAF.SSN.Kernel.Infrastructure.Helpers;

namespace ITJob.ApiService.SeedWorks.Helpers
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class JsonDateTimeConverter : DateTimeConverterBase
    {
        //...
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || (DateTime) value <= DateTime.MinValue)
            {
                writer.WriteValue((object) null);
            }
            else
            {
                writer.WriteValue(((DateTime) value).FaDate());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return reader.Value?.ToString().ConvertToDate();
        }
    }
}
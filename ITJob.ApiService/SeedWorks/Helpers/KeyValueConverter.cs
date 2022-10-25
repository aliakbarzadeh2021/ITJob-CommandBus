namespace ITJob.ApiService.SeedWorks.Helpers
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class KeyValueConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = value as List<KeyValuePair<string, object>>;
            writer.WriteStartArray();
            if (list != null)
            {
                foreach (var item in list)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName(item.Key);
                    writer.WriteValue(item.Value);
                    writer.WriteEndObject();
                }
            }
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var list = new List<KeyValuePair<string, object>>();
            if (reader.TokenType != JsonToken.StartArray)
                return list;

            var startDepth = reader.Depth;
            while (reader.Read())
            {
                if ((reader.Depth == startDepth) && (reader.TokenType == JsonToken.EndArray)) break;

                if (reader.TokenType == JsonToken.StartObject)
                {
                    var kvp = GetKeyValueFromJsonObject(reader);
                    list.Add(kvp);
                }
                else
                {
                    throw new NotSupportedException(
                        $"Unexpected JSON token '{reader.TokenType}' while reading special Dictionary");
                }
            }
            return list;
        }

        private KeyValuePair<string, object> GetKeyValueFromJsonObject(JsonReader reader)
        {
            string key = null;
            object value = null;
            var startDepth = reader.Depth;
            while (reader.Read())
            {
                if ((reader.TokenType == JsonToken.EndObject) && (reader.Depth == startDepth))
                    break;

                if (reader.TokenType != JsonToken.PropertyName)
                    continue;

                var propName = reader.Value as string;
                if (propName == null)
                    continue;

                key = propName;
                value = reader.ReadAsString();
            }
            return new KeyValuePair<string, object>(key, value);
        }

        public override bool CanConvert(Type objectType)
         {
            return objectType == typeof (List<KeyValuePair<string, object>>);
        }
    }
}
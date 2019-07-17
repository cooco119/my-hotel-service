using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MyHotelService.Common.Utility
{
    public class CustomJsonConverter<TInterface, TImplementation> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TInterface);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(TImplementation));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(TImplementation));
        }
    }
}

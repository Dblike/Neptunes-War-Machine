using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesWarMachine.Utils
{
    public abstract class CustomJsonConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false");
        }

        public abstract override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer);

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
    }
}

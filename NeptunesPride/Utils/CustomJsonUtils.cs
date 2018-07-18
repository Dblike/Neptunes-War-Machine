using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeptunesWarMachine
{ 
    public static class JsonUtils
    {
        public static List<T> DeserializeTokens<T>(JsonReader reader)
        {
            JObject jsonObject = JObject.Load(reader);
            JEnumerable<JToken> tokens = jsonObject.Children();

            return tokens.Select(token => token.First.ToObject<T>()).ToList();
        }
    }
}

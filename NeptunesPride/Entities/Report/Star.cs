using NeptunesWarMachine;
using NeptunesWarMachine.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesPride
{
    public class Star
    {
        [JsonProperty("uid")]
        public int UniqueId { get; set; }
        [JsonProperty("puid")]
        public int PlayerId { get; set; }
        [JsonProperty("n")]
        public string Name { get; set; }
        [JsonProperty("nr")]
        public int NaturalResources { get; set; }
        [JsonProperty("r")]
        public int TerraformedResources { get; set; }        
        [JsonProperty("e")]
        public int Economy { get; set; }        
        [JsonProperty("i")]
        public int Industry { get; set; }
        [JsonProperty("s")]
        public int Science { get; set; }
        [JsonProperty("st")]
        public int ShipsStationed { get; set; }
        [JsonProperty("c")]
        public double PartiallyCompletedShips { get; set; }
        [JsonProperty("ga")]
        public int Gateways { get; set; }
        public float V { get; set; }
        public float Y { get; set; }
        public float X { get; set; }      
    }

    public class StarConverter : CustomJsonConverter<Star>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JsonUtils.DeserializeTokens<Star>(reader);
        }
    }
}
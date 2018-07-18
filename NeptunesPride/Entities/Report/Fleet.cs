using NeptunesWarMachine.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesWarMachine.Entities
{
    public class Fleet
    {
        public int Ouid { get; set; }
        [JsonProperty("uid")]
        public int UniqueId { get; set; }
        [JsonProperty("puid")]
        public int PlayerId { get; set; }
        [JsonProperty("n")]
        public string Name { get; set; }
        [JsonProperty("st")]
        public int ShipsStationed { get; set; }
        [JsonProperty("o")]
        public List<Order> Orders { get; set; }
        public int L { get; set; }
        public int W { get; set; }
        public double Y { get; set; }
        public double X { get; set; }
        public double Lx { get; set; }
        public double Ly { get; set; }
    }

    public class FleetConverter : CustomJsonConverter<Fleet>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JsonUtils.DeserializeTokens<Fleet>(reader);
        }
    }
}

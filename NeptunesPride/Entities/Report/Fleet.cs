using NeptunesWarMachine.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeptunesWarMachine.Entities
{
    public class Fleet
    {
        [JsonProperty("ouid")]
        public int StarId { get; set; }
        [JsonProperty("uid")]
        public int UniqueId { get; set; }
        [JsonProperty("puid")]
        public int PlayerId { get; set; }
        [JsonProperty("n")]
        public string Name { get; set; }
        [JsonProperty("st")]
        public int ShipsStationed { get; set; }
        [JsonProperty("o")]
        [JsonConverter(typeof(OrderConverter))]
        public List<Order> Orders { get; set; }
        [JsonProperty("l")]
        public bool IsLoopingOrders { get; set; }
        public int W { get; set; }
        public double Y { get; set; }
        public double X { get; set; }
        public double Lx { get; set; }
        public double Ly { get; set; }
    }

    public class Order
    {
        public int Delay { get; set; }
        public int StarId { get; set; }
        public int Action { get; set; }
        public int Ships { get; set; }
    }

    public class FleetConverter : CustomJsonConverter<Fleet>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JsonUtils.DeserializeTokens<Fleet>(reader);
        }
    }

    public class OrderConverter : CustomJsonConverter<Order>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray jsonArray = JArray.Load(reader);
            JEnumerable<JToken> tokens = jsonArray.Children();
            return tokens.Select(token =>
            {
                return new Order
                {
                    Delay = token[0].ToObject<int>(),
                    StarId = token[1].ToObject<int>(),
                    Action = token[2].ToObject<int>(),
                    Ships = token[3].ToObject<int>()
                };
            }).ToList();
        }
    }
}

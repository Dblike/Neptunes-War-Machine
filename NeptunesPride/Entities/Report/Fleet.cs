using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesWarMachine.Entities
{
    public class Fleet
    {
        [JsonProperty("uid")]
        public int UniqueId { get; set; }
        public int L { get; set; }
        [JsonProperty("o")]
        public List<Order> Orders { get; set; }
    }
}

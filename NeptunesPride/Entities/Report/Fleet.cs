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
        public int L { get; set; }
        [JsonProperty("o")]
        public List<Order> Orders { get; set; }
        [JsonProperty("n")]
        public string Name { get; set; }
        public int Puid { get; set; }
        public int W { get; set; }
        public double Y { get; set; }
        public double X { get; set; }
        public int St { get; set; }
        public double Lx { get; set; }
        public double Ly { get; set; }
    }
}

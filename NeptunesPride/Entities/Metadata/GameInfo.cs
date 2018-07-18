using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesWarMachine.Entities.Metadata
{
    public class GameInfo
    {
        public string Name { get; set; }
        [JsonProperty("number")]
        public long Id { get; set; }
    }
}

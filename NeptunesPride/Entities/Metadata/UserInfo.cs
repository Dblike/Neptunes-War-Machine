using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeptunesWarMachine.Entities.Metadata
{
    public class UserInfo
    {
        [JsonProperty("open_games")]
        public List<GameInfo> OpenGames { get; set; }
    }
}

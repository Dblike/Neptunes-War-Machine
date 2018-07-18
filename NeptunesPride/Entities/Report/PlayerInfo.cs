using NeptunesWarMachine.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeptunesWarMachine.Entities.Report
{
    public class PlayerInfo
    {
        //Identifying Information
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("uid")]
        public int UniqueId { get; set; }
        [JsonProperty("huid")]
        public int HumanId { get; set; }
        [JsonProperty("avatar")]
        public int Avatar { get; set; }

        //Empire Information
        [JsonProperty("cash")]
        public int Cash { get; set; }
        [JsonProperty("total_stars")]
        public int TotalStars { get; set; }
        [JsonProperty("total_fleets")]
        public int TotalCarriers { get; set; }
        [JsonProperty("total_strength")]
        public int TotalShips { get; set; }
        [JsonProperty("total_economy")]
        public int TotalEconomy { get; set; }
        [JsonProperty("total_industry")]
        public int TotalIndustry { get; set; }
        [JsonProperty("total_science")]
        public int TotalScience { get; set; }
        [JsonConverter(typeof(ResearchConverter))]
        public List<Research> Tech { get; set; }    
        [JsonProperty("stars_abandoned")]
        public int StarsAbandoned { get; set; }
        
        //Meta-information        
        [JsonProperty("ai")]
        public bool IsComputer { get; set; }
        [JsonProperty("conceded")]
        public bool DidConcede { get; set; }
        [JsonProperty("ready")]
        public bool IsReady { get; set; }
        [JsonProperty("missed_turns")]
        public int MissedTurns { get; set; }
        [JsonProperty("regard")]
        public int Regard { get; set; }
        [JsonProperty("karma_to_give")]
        public int KarmaToGive { get; set; }
        [JsonProperty("ready")]
        public bool Ready { get; set; }
    }

    public class Research
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public int Level { get; set; }
        [JsonProperty("research")]
        public double Sv { get; set; }
        public int ResearchProgress { get; set; }
        public double Bv { get; set; }
        public double Brr { get; set; }
    }

    public class PlayerConverter : CustomJsonConverter<PlayerInfo>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JsonUtils.DeserializeTokens<PlayerInfo>(reader);
        }
    }

    public class ResearchConverter : CustomJsonConverter<Research>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            JEnumerable<JToken> tokens = jsonObject.Children();

            return tokens.Select(token =>
            {
                var obj = token.First.ToObject<Research>();
                obj.Name = ((JProperty)token).Name;
                return obj;
            }).ToList();
        }
    }
}
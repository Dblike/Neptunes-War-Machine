using NeptunesWarMachine.Entities;
using NeptunesWarMachine.Entities.Report;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeptunesPride
{
    public class FullUniverseReport
    {
        //Constants
        const int RANGE_MULTIPLIER = 8;

        //Valuable Content
        [JsonConverter(typeof(FleetConverter))]
        public List<Fleet> Fleets { get; set; }
        [JsonConverter(typeof(StarConverter))]
        public List<Star> Stars { get; set; }
        [JsonConverter(typeof(PlayerConverter))]
        public List<PlayerInfo> Players { get; set; }

        //Game Settings
        [JsonProperty("fleet_speed")]
        public double FleedSpeed { get; set; }
        [JsonProperty("paused")]
        public bool IsPaused { get; set; }
        [JsonProperty("tick_fragment")]
        public double TickFragment { get; set; }
        [JsonProperty("now")]
        public long CurrentTime { get; set; }
        [JsonProperty("tick_rate")]
        public int TickRate { get; set; }
        [JsonProperty("production_rate")]
        public int ProductionRate { get; set; }
        [JsonProperty("stars_for_victory")]
        public int StarsForVictory { get; set; }
        [JsonProperty("game_over")]
        public bool GameOver { get; set; }
        [JsonProperty("started")]
        public bool IsGameStarted { get; set; }
        [JsonProperty("start_time")]
        public long StartTime { get; set; }
        [JsonProperty("total_stars")]
        public int TotalStars { get; set; }
        [JsonProperty("production_counter")]
        public int ProductionCounter { get; set; }
        [JsonProperty("trade_cost")]
        public int TradeCost { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("player_uid")]
        public int PlayerUniqueId { get; set; }
        [JsonProperty("admin")] 
        public bool Admin { get; set; }
        [JsonProperty("turn_based")]
        public bool TurnBased { get; set; } 
        [JsonProperty("war")]
        public bool War { get; set; }
        [JsonProperty("turn_based_time_out")]
        public bool TurnBasedTimeOut { get; set; }

        //public List<Star> GetVulnerableStars(int playerId)
        //{
        //    List<Star> playerStars = Stars.Where(star => star.PlayerId == playerId).ToList();
        //    Dictionary<Star, List<Star>> vulnerableStars = new Dictionary<Star, List<Star>>();


        //    Parallel.ForEach(playerStars, (star) =>
        //    {
        //        List<Star> stars = GetReachableStars(star, range);
        //    });
        //}

        //public List<Star> GetReachableStars(Star origin)
        //{
        //    float range = Players[0].Tech.Where(tech => tech.Name == "Hyperspace").First().Value;
        //    return Stars.Where(star => DistanceBetweenStars(origin, star) <= Players.Where(player => player.UniqueId == star.PlayerId).First).ToList();
        //}

        private double DistanceBetweenStars(Star star1, Star star2)
        {
            return Math.Round(Math.Sqrt(Math.Pow(star1.X - star2.X, 2) + Math.Pow(star1.Y - star2.Y, 2)) * RANGE_MULTIPLIER, 1);
        }
    }
}
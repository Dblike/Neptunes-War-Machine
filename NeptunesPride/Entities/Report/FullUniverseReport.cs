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
        const int RANGE_MULTIPLIER = 8;

        [JsonConverter(typeof(StarConverter))]
        public List<Star> Stars { get; set; }
        [JsonConverter(typeof(PlayerConverter))]
        public List<PlayerInfo> Players { get; set; }

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
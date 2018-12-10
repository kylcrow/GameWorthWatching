using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBAGameTeamScoreModel
    {
        public NBAGameTeamScoreModel() { }

        [JsonProperty(PropertyName = "score")]
        public int QuarterScore { get; set; }
    }
}
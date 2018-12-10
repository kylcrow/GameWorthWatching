using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBATeamModel
    {
        public NBATeamModel() { }

        [JsonProperty(PropertyName = "teamId")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "triCode")]
        public string TriCode { get; set; }

        [JsonProperty(PropertyName = "ttsName")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "primaryColor")]
        public string PrimaryColor { get; set; }

        [JsonProperty(PropertyName = "secondaryColor")]
        public string SecondaryColor { get; set; }
    }
}
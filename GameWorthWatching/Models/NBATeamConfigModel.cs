using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBATeamConfigModel
    {
        public NBATeamConfigModel() { }

        [JsonProperty(PropertyName = "config")]
        public List<NBATeamModel> NBATeamModels { get; set; }
    }
}
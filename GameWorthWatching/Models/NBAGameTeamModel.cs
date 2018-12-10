using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBAGameTeamModel
    {
        public NBAGameTeamModel()
        {
            this.LineScores = new List<NBAGameTeamScoreModel>();
        }

        [JsonProperty(PropertyName = "triCode")]
        public string TriCode { get; set; }

        [JsonProperty(PropertyName = "win")]
        public int CurrentWins { get; set; }

        [JsonProperty(PropertyName = "loss")]
        public int CurrentLosses { get; set; }

        [JsonProperty(PropertyName = "score")]
        public int? Score { get; set; }

        [JsonProperty(PropertyName = "linescore")]
        public List<NBAGameTeamScoreModel> LineScores { get; set; }

        public string Record
        {
            get
            {
                return $"{this.CurrentWins} - {this.CurrentLosses}";
            }
        }

        public int? HalfTimeScore
        {
            get
            {
                if (this.LineScores[1] != null)
                {
                    return this.LineScores[0].QuarterScore + this.LineScores[1].QuarterScore;
                }

                return null;
            }
        }

        public int? Q1Score
        {
            get
            {
                if (this.LineScores.Count() > 0)
                {
                    return this.LineScores[0].QuarterScore;
                }

                return null;
            }
        }

        public int? Q2Score
        {
            get
            {
                if (this.LineScores.Count() > 1)
                {
                    return this.LineScores[1].QuarterScore;
                }

                return null;
            }
        }

        public int? Q3Score
        {
            get
            {
                if (this.LineScores.Count() > 2)
                {
                    return this.LineScores[2].QuarterScore;
                }

                return null;
            }
        }

        public int? Q4Score
        {
            get
            {
                if (this.LineScores.Count() > 3)
                {
                    return this.LineScores[3].QuarterScore;
                }

                return null;
            }
        }
    }
}
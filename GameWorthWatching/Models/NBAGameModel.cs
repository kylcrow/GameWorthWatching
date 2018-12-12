using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBAGameModel
    {
        private string _activeMessage = "The game is on now!";

        public NBAGameModel() { }

        [JsonProperty(PropertyName = "gameId")]
        public int GameId { get; set; }

        [JsonProperty(PropertyName = "hTeam")]
        public NBAGameTeamModel HomeTeam { get; set; }

        [JsonProperty(PropertyName = "vTeam")]
        public NBAGameTeamModel AwayTeam { get; set; }

        [JsonProperty(PropertyName = "isBuzzerBeater")]
        public bool IsBuzzerBeater { get; set; }

        [JsonProperty(PropertyName = "startTimeUTC")]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "endTimeUTC")]
        public DateTime? EndTime { get; set; }

        public string StartMessage
        {
            get
            {
                return string.Format(this.StartTime.ToLocalTime().ToShortTimeString());
            }
        }

        public string ActiveMessage
        {
            get
            {
                return this._activeMessage;
            }
        }

        public bool IsGameOver
        {
            get
            {
                return this.EndTime.HasValue;
            }
        }

        public bool IsGameInFuture
        {
            get
            {
                return this.StartTime > DateTime.Now.ToUniversalTime();
            }
        }

        public bool IsGameActive
        {
            get
            {
                return !IsGameInFuture && !this.IsGameOver && !this.IsGameReallyOld;
            }
        }

        public bool IsGameReallyOld
        {
            get
            {
                return (this.StartTime - DateTime.Now).TotalDays < 300;
            }
        }

        public bool IsGameWorthWatching
        {
            get
            {
                if (this.IsGameOver)
                {
                    if (this.IsCloseGame() || this.IsLargeComback() || this.GameWentToOverTime() || this.IsBuzzerBeater)
                    {
                        return true;
                    }

                }

                return false;
            }
        }

        public bool IsCloseGame()
        {
            if (!this.IsGameOver)
            {
                return false;
            }

            if (Math.Abs(this.HomeTeam.Score.Value - this.AwayTeam.Score.Value) < 5)
            {
                return true;
            }

            return false;
        }

        public bool IsLargeComback()
        {
            if (!this.IsGameOver)
            {
                return false;
            }

            bool homeTeamWon = this.HomeTeam.Score > this.AwayTeam.Score;
            bool awayTeamWon = this.AwayTeam.Score > this.HomeTeam.Score;

            // negative number = away team winning
            int differenceAtQ1 = this.HomeTeam.Q1Score.Value - this.AwayTeam.Q1Score.Value;
            int differenceAtQ2 = (this.HomeTeam.Q1Score.Value + this.HomeTeam.Q2Score.Value) - (this.AwayTeam.Q1Score.Value + this.AwayTeam.Q2Score.Value);
            int differenceAtQ3 = (this.HomeTeam.Q1Score.Value + this.HomeTeam.Q2Score.Value + this.HomeTeam.Q3Score.Value) - (this.AwayTeam.Q1Score.Value + this.AwayTeam.Q2Score.Value + this.AwayTeam.Q3Score.Value);

            if ((differenceAtQ1 >= 18 && awayTeamWon) ||
                (differenceAtQ2 >= 18 && awayTeamWon) ||
                (differenceAtQ3 >= 18 && awayTeamWon) ||
                (differenceAtQ1 <= -18 && homeTeamWon) ||
                (differenceAtQ2 <= -18 && homeTeamWon) ||
                (differenceAtQ3 <= -18 && homeTeamWon))
            {
                return true;
            }

            return false;
        }

        public bool GameWentToOverTime()
        {
            return (this.HomeTeam.LineScores.Any() && this.HomeTeam.LineScores.Count() > 4);
        }
    }
}
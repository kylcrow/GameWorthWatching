using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBAScoreboardModel
    {
        public NBAScoreboardModel()
        {
            this.NBAGamesModel = new List<NBAGameModel>();
        }

        public NBAScoreboardModel(string date) : this()
        {
            DateTime dt = new DateTime();
            if (DateTime.TryParse(date, out dt))
            {
                this.LoadGamesFromDate(dt.Date);
            }
        }

        public NBAScoreboardModel(DateTime date) : this()
        {
            this.LoadGamesFromDate(date);
        }

        public NBA_internalModel _internal { get; set; }

        public int numGames { get; set; }

        [JsonProperty(PropertyName = "games")]
        public List<NBAGameModel> NBAGamesModel { get; set; }

        private void LoadGamesFromDate(DateTime date)
        {
            var dateString = date.ToString("yyyyMMdd");
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create($"http://data.nba.net/10s/prod/v1/{dateString}/scoreboard.json");
            WebReq.Method = "GET";

            try
            {
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                var response = JsonConvert.DeserializeObject<NBAScoreboardModel>(jsonString);
                this.NBAGamesModel = response.NBAGamesModel;
                this.numGames = response.numGames;
                this._internal = response._internal;
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
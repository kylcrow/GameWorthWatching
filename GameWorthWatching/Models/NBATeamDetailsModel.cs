using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBATeamDetailsModel
    {
        public NBATeamDetailsModel() { }

        public NBATeamDetailsModel(DateTime dt) : this()
        {
            this.LoadTeamDataByYear(dt);
        }

        [JsonProperty(PropertyName = "teams")]
        public NBATeamConfigModel NBATeamConfigModel { get; set; }

        private void LoadTeamDataByYear(DateTime date)
        {
            var dateString = date.ToString("yyyy");
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create($"http://data.nba.net/prod/{dateString}/teams_config.json");
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

                var response = JsonConvert.DeserializeObject<NBATeamDetailsModel>(jsonString);
                this.NBATeamConfigModel = response.NBATeamConfigModel;
            }
            catch (Exception e)
            {

            }
        }
    }
}
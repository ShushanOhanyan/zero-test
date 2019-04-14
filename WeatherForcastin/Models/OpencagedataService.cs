using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WeatherForcastin.Interfaces;

namespace WeatherForcastin.Models
{
    public class OpencagedataService : IService
    {
        #region Private fields

        private string key = "3ec6107ba5d14cdab5f18398d292d392";
        private string place;
        private static Dictionary<string, Tuple<string, string>> cache = new Dictionary<string, Tuple<string, string>>();

        #endregion

        #region Public fields

        public string URL
        {
            get { return $"https://api.opencagedata.com/geocode/v1/json?q={place}&key={key}"; }
        }

        #endregion

        #region Constructor

        public OpencagedataService(string place)
        {
            this.place = place;
        }

        #endregion

        #region Public Methods
        public Tuple<string, string> GetCoordinates()
        {
            if (cache.ContainsKey(this.place))
            {
                return cache[place];
            }

            var json = GetData();
            return GetCoordinates(json);
        }

       

        public JObject GetData()
        {
            string str;
            JObject json = new JObject();

            using (var webClient = new WebClient())
            {
                webClient.QueryString.Add("format", "json");
                str = webClient.DownloadString(URL);
                json = JObject.Parse(str);                
            }

            return json;
        }

        #endregion

        #region Private fields
        private Tuple<string, string> GetCoordinates(JObject json)
        {
            if (json["results"].Count() > 0)
            {
                json = (JObject)json["results"][0]["geometry"];
                string lat = (string)json["lat"];
                string lng = (string)json["lng"];

                var result = new Tuple<string, string>(lat, lng);
                cache.Add(this.place, result);
                return result;
            }

            return new Tuple<string, string>(string.Empty, string.Empty);
        }

        #endregion
    }
}
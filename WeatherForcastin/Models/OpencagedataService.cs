using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WeatherForcastin.Models
{
    public class OpencagedataService : IService
    {
        private string key = "3ec6107ba5d14cdab5f18398d292d392";
        private string space;

        public OpencagedataService(string space)
        {
            this.space = space;
        }

        public Tuple<string, string> GetCoordinates()
        {
            
            
            using (var webClient = new WebClient())
            {
                return GetData(webClient);
            }
        }

        private string GetURL()
        {
            return $"https://api.opencagedata.com/geocode/v1/json?q={space}&key={key}";
        }

        private Tuple<string, string>  GetData(WebClient webClient)
        {
            string str;
            var uri = GetURL();

            webClient.QueryString.Add("format", "json");
            str = webClient.DownloadString(uri);
            JObject json = JObject.Parse(str);
            return GetCoordinates(json);

            
        }

        private Tuple<string, string> GetCoordinates(JObject json)
        {
            json = (JObject)json["results"][0]["geometry"];
            string lat = (string)json["lat"];
            string ing = (string)json["lng"];

            return new Tuple<string, string>(lat, ing);
        }
    }
}
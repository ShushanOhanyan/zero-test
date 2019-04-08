using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WeatherForcastin.Interfaces;

namespace WeatherForcastin.Models
{
    public class WeatherService : IService
    {
        private const string key = "107f8b7ce62a20bd55b9f1d787292031";
        private string lat;
        private string ing;

        public WeatherService(string lat, string ing)
        {
            this.lat = lat;
            this.ing = ing;
        }

        public WeatherInfo GetWeatherInfo()
        {
            using (var webClient = new WebClient())
            {
                 GetData(webClient);
            }

            return new WeatherInfo();
        }

        private void GetData(WebClient webClient)
        {
            string str;
            var uri = GetURL();

            webClient.QueryString.Add("format", "json");
            str = webClient.DownloadString(uri);
            JObject json = JObject.Parse(str);
            //return GetCoordinates(json);


        }

        private string GetURL()
        {
            return $"https://api.darksky.net/forecast/{key}/{lat},{ing}";
        }

        
    }
}
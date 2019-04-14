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
        #region Private fields

        private const string key = "107f8b7ce62a20bd55b9f1d787292031";
        private string lat;
        private string lng;

        #endregion

        #region Public fields

        public string URL
        {
            get { return $"https://api.darksky.net/forecast/{key}/{lat},{lng}"; }
        }

        #endregion

        #region Constructor

        public WeatherService(string lat, string lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        #endregion

        #region Public methods

        public double GetWeatherInfo()
        {
            double tempreture = 0.0;
            var json = GetData();
            
            if(json != null)
            {
                tempreture = GetTempreture(json);
            }

            return tempreture;
        }

        

        public JObject GetData()
        {
            string str;
            using (var webClient = new WebClient())
            {                webClient.QueryString.Add("format", "json");
                str = webClient.DownloadString(URL);
                JObject json = JObject.Parse(str);
                return json;
            } 
        }

        #endregion

        #region Private methods

        private double GetTempreture(JObject json)
        {
            //parse json for getting the temperature
            //leaving this parse function uncompleted           
            
            return 25.6;
        }

        #endregion

    }
}
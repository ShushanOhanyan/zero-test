using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForcastin.Models
{
    public class WeatherManager
    {
        public WeatherInfo GetTemperature(string place)
        {
            place = place.ToLower();

            OpencagedataService coordService = new OpencagedataService(place);
            double info = 0.0;
            var coordinates = coordService.GetCoordinates();

            string lat = coordinates.Item1;
            string lng = coordinates.Item2;
            if (!string.IsNullOrEmpty(lat) && !string.IsNullOrEmpty(lng))
            {
                var weatherService = new WeatherService(coordinates.Item1.ToString(), coordinates.Item2.ToString());

                info = weatherService.GetWeatherInfo();
            }
            return new WeatherInfo() { Temperature = info };
        }
    }
}
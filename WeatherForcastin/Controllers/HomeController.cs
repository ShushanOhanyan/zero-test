using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherForcastin.Models;

namespace WeatherForcastin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string space)
        {
            space = "Armenia";
             WeatherInfo result = new WeatherInfo() { Tempreture = 17 }; ;
            if (!string.IsNullOrEmpty(space))
            {
                OpencagedataService coordService = new OpencagedataService(space);
                var coordinates = coordService.GetCoordinates();


                var weatherService = new  WeatherService(coordinates.Item1.ToString(), coordinates.Item2.ToString());

               var a = weatherService.GetWeatherInfo();

            }

            return View(result);
        }
    }
}

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
        public ActionResult Index(string place)
        {
            WeatherInfo info = new WeatherInfo();

            if (!string.IsNullOrEmpty(place))
            {
                WeatherManager weatherManager = new WeatherManager();

                 info = weatherManager.GetTemperature(place);
            }

            return View(info);
        }
    }
}

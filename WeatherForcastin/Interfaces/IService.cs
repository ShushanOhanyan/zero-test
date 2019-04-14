using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForcastin.Interfaces
{
    interface IService
    {
        string URL { get;}

        JObject GetData();
    }
}

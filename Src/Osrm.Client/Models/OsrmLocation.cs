using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class Location
    {
        //private List<double> _coordiantes;

        public Location()
        {
            //_coordiantes = new List<double>();
        }

        //public Location(List<double> coordiantes)
        //{
        //    _coordiantes = coordiantes;
        //}

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
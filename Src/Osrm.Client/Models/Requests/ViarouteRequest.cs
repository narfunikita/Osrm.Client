using Osrm.Client.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class ViarouteRequest
    {
        protected const int DefaultZoom = 18;

        public ViarouteRequest()
        {
            Zoom = DefaultZoom;
        }

        /// <summary>
        /// Location of the via point
        /// </summary>
        public Location[] Locations { get; set; }

        /// <summary>
        /// Use locs encoded plyline param instead locs
        /// </summary>
        public bool SendLocsAsEncodedPolyline { get; set; }

        private int _zoom;

        /// <summary>
        /// Zoom level used for compressing the route geometry accordingly 0 ... 18
        /// </summary>
        public int Zoom
        {
            get
            {
                return _zoom;
            }
            set
            {
                if (value < 0 || value > 18)
                {
                    throw new ArgumentException("ViarouteParams zoom should be 0..18");
                }

                _zoom = value;
            }
        }

        /// <summary>
        /// Format of the response (json (default), gpx)
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Return route instructions for each route
        /// </summary>
        public bool Instructions { get; set; }

        public List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>();
                if (SendLocsAsEncodedPolyline)
                {
                    //locs
                }
                else
                {
                    urlParams.AddRange(Locations.Select(x =>
                        new Tuple<string, string>("loc", x.Latitude.ToString("", CultureInfo.InvariantCulture)
                            + "," + x.Longitude.ToString("", CultureInfo.InvariantCulture))));
                }

                if (Instructions)
                {
                    urlParams.Add(new Tuple<string, string>("instructions", "true"));
                }

                if (Zoom != DefaultZoom)
                {
                    urlParams.Add(new Tuple<string, string>("z", Zoom.ToString()));
                }

                return urlParams;
            }
        }
    }
}
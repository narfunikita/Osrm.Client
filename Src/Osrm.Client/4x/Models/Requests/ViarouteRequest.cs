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
            Alternative = true;
            Geometry = true;
            Compression = true;
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
        /// Return route instructions for each route (default false)
        /// </summary>
        public bool Instructions { get; set; }

        /// <summary>
        /// Return an alternative route (default true)
        /// Not supported in trip request
        /// </summary>
        public bool Alternative { get; set; }

        /// <summary>
        /// Return route geometry (default true)
        /// </summary>
        public bool Geometry { get; set; }

        /// <summary>
        /// Compress route geometry as a polyline; geometry is a list of [lat, lng] pairs if false (default: true)
        /// </summary>
        public bool Compression { get; set; }

        /// <summary>
        /// Enable u-turns at all via points (default false)
        /// </summary>
        public bool UTurns { get; set; }

        /// <summary>
        /// Specify after each loc. Enables/disables u-turn at the via (default false)
        /// </summary>
        public bool UTurnAtTheVia { get; set; }

        /// <summary>
        /// Derives the location of coordinate in the street network, one per loc (base64 string)
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Checksum of the hint parameters.
        /// </summary>
        public string Checksum { get; set; }

        public List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>();

                urlParams.AddRange(OsrmRequestBuilder.CreateLocationParams(SendLocsAsEncodedPolyline ? "locs" : "loc", Locations, SendLocsAsEncodedPolyline));

                urlParams
                    .AddBoolParameter("instructions", Instructions, false)
                    .AddStringParameter("z", Zoom.ToString(), () => Zoom != DefaultZoom)
                    .AddBoolParameter("alt", Alternative, true)
                    .AddBoolParameter("geometry", Geometry, true)
                    .AddBoolParameter("compression", Compression, true)
                    .AddBoolParameter("uturns", UTurns, false)
                    .AddBoolParameter("u", UTurnAtTheVia, false)
                    .AddStringParameter("hint", Hint)
                    .AddStringParameter("checksum", Checksum);

                return urlParams;
            }
        }
    }
}
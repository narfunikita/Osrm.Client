using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class MatchRequest
    {
        protected const float DefaultGpsPrecision = 5;
        protected const float DefaultMatchingBeta = 10;

        public MatchRequest()
        {
            Geometry = true;
            Compression = true;
            GpsPrecision = DefaultGpsPrecision;
            MatchingBeta = DefaultMatchingBeta;
        }

        /// <summary>
        /// Location of the via point
        /// </summary>
        public LocationWithTimestamp[] Locations { get; set; }

        /// <summary>
        /// Use locs encoded plyline param instead locs
        /// </summary>
        public bool SendLocsAsEncodedPolyline { get; set; }

        /// <summary>
        /// Return route geometry (default true)
        /// </summary>
        public bool Geometry { get; set; }

        /// <summary>
        /// Compress route geometry as a polyline; geometry is a list of [lat, lng] pairs if false (default: true)
        /// </summary>
        public bool Compression { get; set; }

        /// <summary>
        /// Return a confidence value for this matching (default: false)
        /// </summary>
        public bool Classify { get; set; }

        /// <summary>
        /// Return the instructions of the matched route, which each matched point as via. (default false)
        /// </summary>
        public bool Instructions { get; set; }

        /// <summary>
        /// Specify gps precision as standart deviation in meters.
        /// </summary>
        public float GpsPrecision { get; set; }

        /// <summary>
        /// Specify beta value for matching algorithm
        /// </summary>
        public float MatchingBeta { get; set; }

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
                   .AddBoolParameter("geometry", Geometry, true)
                   .AddBoolParameter("compression", Compression, true)
                   .AddBoolParameter("classify", Classify, false)
                   .AddBoolParameter("instructions", Instructions, false)
                   .AddStringParameter("gps_precision", GpsPrecision.ToString(), () => GpsPrecision != DefaultGpsPrecision)
                   .AddStringParameter("matching_beta", MatchingBeta.ToString(), () => MatchingBeta != DefaultMatchingBeta)
                   .AddStringParameter("hint", Hint)
                   .AddStringParameter("checksum", Checksum);

                return urlParams;
            }
        }
    }
}
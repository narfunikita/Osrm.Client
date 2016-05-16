using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public abstract class BaseRequest
    {
        public BaseRequest()
        {
            Coordinates = new Location[0];
            Bearings = new Bearing[0];
            Radiuses = new int[0];
            Hints = new string[0];
        }

        /// <summary>
        /// Use locs encoded plyline param instead locs
        /// </summary>
        public bool SendCoordinatesAsPolyline { get; set; }

        public Location[] Coordinates { get; set; }

        /// <summary>
        /// Limits the search to segments with given bearing in degrees towards true north in clockwise direction.
        /// integer 0 .. 360,integer 0 .. 180
        /// </summary>
        public Bearing[] Bearings { get; set; }

        /// <summary>
        /// Limits the search to given radius in meters.
        /// double >= 0 or unlimited (default)
        /// </summary>
        public int[] Radiuses { get; set; }

        /// <summary>
        /// Hint to derive position in street network.
        /// Base64 string
        /// </summary>
        public string[] Hints { get; set; }

        public string CoordinatesUrlPart
        {
            get
            {
                return OsrmRequestBuilder.CreateCoordinatesUrl(Coordinates, SendCoordinatesAsPolyline);
            }
        }

        public abstract List<Tuple<string, string>> UrlParams { get; }

        protected List<Tuple<string, string>> BaseUrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>();

                urlParams
                    .AddParams("bearings", Bearings.Select(x => x.Item1 + "," + x.Item2).ToArray())
                    .AddParams("radiuses", Radiuses.Select(x => x.ToString()).ToArray())
                    .AddParams("hints", Hints);
                //    .AddStringParameter("z", Zoom.ToString(), () => Zoom != DefaultZoom)
                //    .AddBoolParameter("alt", Alternative, true)
                //    .AddBoolParameter("geometry", Geometry, true)
                //    .AddBoolParameter("compression", Compression, true)
                //    .AddBoolParameter("uturns", UTurns, false)
                //    .AddBoolParameter("u", UTurnAtTheVia, false)
                //    .AddStringParameter("hint", Hint)
                //    .AddStringParameter("checksum", Checksum);

                return urlParams;
            }
        }
    }
}
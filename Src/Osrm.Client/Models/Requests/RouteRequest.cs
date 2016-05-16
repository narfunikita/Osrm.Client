using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class RouteRequest : BaseRequest
    {
        protected const string DefaultGeometries = "polyline";
        protected const string DefaultOverview = "simplified";
        protected const string DefaultContinueStraight = "default";

        public RouteRequest()
        {
            Geometries = DefaultGeometries;
            Overview = DefaultOverview;
            ContinueStraight = DefaultContinueStraight;
        }

        /// <summary>
        /// Search for alternative routes and return as well.*
        /// true, false (default)
        /// </summary>
        public bool Alternative { get; set; }

        /// <summary>
        /// Return route steps for each route leg
        /// true, false (default)
        /// </summary>
        public bool Steps { get; set; }

        /// <summary>
        /// Returned route geometry format (influences overview and per step)
        /// polyline (default), geojson
        /// </summary>
        public string Geometries { get; set; }

        /// <summary>
        /// Add overview geometry either full, simplified according to highest zoom level it could be display on, or not at all.
        /// simplified (default), full, false
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Forces the route to keep going straight at waypoints and don't do a uturn even if it would be faster. Default value depends on the profile.
        /// default (default), true, false
        /// </summary>
        public string ContinueStraight { get; set; }

        public override List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>(BaseUrlParams);

                urlParams
                    .AddBoolParameter("alternatives", Alternative, false)
                    .AddBoolParameter("steps", Steps, false)
                    .AddStringParameter("geometries", Geometries, () => Geometries != DefaultGeometries)
                    .AddStringParameter("overview", Overview, () => Overview != DefaultOverview)
                    .AddStringParameter("continue_straight", ContinueStraight, () => ContinueStraight != DefaultContinueStraight);

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
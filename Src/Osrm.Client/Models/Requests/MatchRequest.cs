using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    public class MatchRequest : BaseRequest
    {
        protected const string DefaultGeometries = "polyline";
        protected const string DefaultAnnotations = "false";
        protected const string DefaultOverview = "simplified";

        public MatchRequest()
        {
            Geometries = DefaultGeometries;
            Annotations = DefaultAnnotations;
            Overview = DefaultOverview;
            Timestamps = new int[0];
        }

        /// <summary>
        /// Return route steps for each route
        /// true, false (default)
        /// </summary>
        public bool Steps { get; set; }

        /// <summary>
        /// Returned route geometry format (influences overview and per step)
        /// polyline (default), geojson
        /// </summary>
        public string Geometries { get; set; }

        /// <summary>
        /// Returns additional metadata for each coordinate along the route geometry.
        /// true, false (default), nodes, distance, duration, datasources, weight, speed
        /// </summary>
        public string Annotations { get; set; }

        /// <summary>
        /// Add overview geometry either full, simplified according to highest zoom level it could be display on, or not at all.
        /// simplified (default), full, false
        /// </summary>
        public string Overview { get; set; }

        /// <summary>
        /// Timestamp of the input location.
        /// simplified (default), full, false
        /// </summary>
        public int[] Timestamps { get; set; }

        public override List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>(BaseUrlParams);

                urlParams
                    .AddBoolParameter("steps", Steps, false)
                    .AddStringParameter("geometries", Geometries, () => Geometries != DefaultGeometries)
                    .AddStringParameter("annotations", Annotations, () => Annotations != DefaultAnnotations)
                    .AddStringParameter("overview", Overview, () => Overview != DefaultOverview)
                    .AddParams("timestamps", Timestamps.Select(x => x.ToString()).ToArray());

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
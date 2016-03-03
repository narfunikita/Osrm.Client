using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class ViarouteResponce
    {
        /// <summary>
        /// Geometry of the route compressed as polyline, but with 6 decimals.
        /// </summary>
        [DataMember(Name = "route_geometry")]
        public string RouteGeometryStr { get; set; }

        /// <summary>
        /// Geometry of the route
        /// </summary>
        public Location[] RouteGeometry
        {
            get
            {
                return OsrmPolylineConverter.Decode(RouteGeometryStr)
                    .ToArray();
            }
        }

        /// <summary>
        /// Array containing the instructions for each route segment. Each entry is an array of the following form: [{drive instruction code}, {street name}, {length}, {location index}, {time}, {formated length}, {post-turn direction}, {post-turn azimuth}, {mode}, {pre-turn direction}, {pre-turn azimuth}]
        /// </summary>
        [DataMember(Name = "route_instructions")]
        protected string[][] RouteInstructionsArray { get; set; }

        /// <summary>
        /// Array containing the instructions for each route segment
        /// </summary>
        public RouteInstruction[] RouteInstructions
        {
            get
            {
                if (RouteInstructionsArray == null)
                    return new RouteInstruction[0];

                return RouteInstructionsArray.Select(x => new RouteInstruction(x)).ToArray();
            }
        }

        [DataMember(Name = "route_summary")]
        public RouteSummary RouteSummary { get; set; }

        [DataMember(Name = "route_name")]
        public string[] RouteName { get; set; }

        [DataMember(Name = "via_indices")]
        public int[] ViaIndices { get; set; }

        [DataMember(Name = "via_points")]
        protected double[][] ViaPointsArray { get; set; }

        public Location[] ViaPoints
        {
            get
            {
                if (ViaPointsArray == null)
                    return new Location[0];

                return ViaPointsArray.Select(x => new Location(x[0], x[1])).ToArray();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class Matching
    {
        /// <summary>
        ///  coordinates of the points snapped to the road network in [lat, lon]
        /// </summary>
        [DataMember(Name = "matched_points")]
        protected double[][] MatchedPointsArray { get; set; }

        /// <summary>
        /// Coordinates of the points snapped to the road network
        /// </summary>
        public Location[] MatchedPoints
        {
            get
            {
                if (MatchedPointsArray == null)
                    return new Location[0];

                return MatchedPointsArray.Select(x => new Location(x[0], x[1])).ToArray();
            }
        }

        /// <summary>
        /// Array that gives the indices of the matched coordinates in the original trace
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; set; }

        /// <summary>
        /// Geometry of the matched trace in the road network, but with 6 decimals.
        /// </summary>
        [DataMember(Name = "geometry")]
        public string GeometryStr { get; set; }

        /// <summary>
        /// Geometry of the matched trace in the road network
        /// </summary>
        public Location[] Geometry
        {
            get
            {
                return OsrmPolylineConverter.Decode(GeometryStr)
                    .ToArray();
            }
        }

        /// <summary>
        /// Value between 0 and 1, where 1 is very confident
        /// Please note that the correctness of this value depends highly on the assumptions about the sample rate mentioned above.
        /// </summary>
        [DataMember(Name = "confidence")]
        public double? Confidence { get; set; }

        /// <summary>
        /// Array containing the instructions for each route segment. Each entry is an array of the following form:
        /// [{drive instruction code}, {street name}, {length}, {location index}, {time}, {formated length}, {post-turn direction}, {post-turn azimuth}, {mode}, {pre-turn direction}, {pre-turn azimuth}]
        /// </summary>
        [DataMember(Name = "instructions")]
        protected string[][] InstructionsArray { get; set; }

        /// <summary>
        /// Array containing the instructions for each route segment
        /// </summary>
        public RouteInstruction[] Instructions
        {
            get
            {
                if (InstructionsArray == null)
                    return new RouteInstruction[0];

                return InstructionsArray.Select(x => new RouteInstruction(x)).ToArray();
            }
        }

        /// <summary>
        /// Input for the hint and checksum parameter.
        /// This can be used to enable umambigious coordinate snapping when passed to services like viaroute and trip
        /// </summary>
        [DataMember(Name = "hint_data")]
        protected HintData HintData { get; set; }

        [DataMember(Name = "matched_names")]
        public string[] MatchedNames { get; set; }

        [DataMember(Name = "route_summary")]
        protected RouteSummary RouteSummary { get; set; }
    }
}
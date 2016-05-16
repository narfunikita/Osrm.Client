using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class Waypoint
    {
        [DataMember(Name = "distance")]
        public double Distance { get; set; }

        /// <summary>
        /// Unique internal identifier of the segment (ephemeral, not constant over data updates) This can be used on subsequent request to significantly speed up the query and to connect multiple services. E.g. you can use the hint value obtained by the nearest query as hint values for route inputs.
        /// </summary>
        [DataMember(Name = "hint")]
        public string Hint { get; set; }

        [DataMember(Name = "location")]
        protected double[] LocationArr { get; set; }

        public Location Location
        {
            get
            {
                if (LocationArr == null)
                    return null;

                return new Location(LocationArr[0], LocationArr[1]);
            }
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Match. Index to the Route object in matchings the sub-trace was matched to.
        /// </summary>
        [DataMember(Name = "matchings_index")]
        public int? MatchingsIndex { get; set; }

        [DataMember(Name = "trips_index")]
        public int? TripsIndex { get; set; }

        /// <summary>
        /// Match. Index of the waypoint inside the matched route.
        /// </summary>
        [DataMember(Name = "waypoint_index")]
        public int? WaypointIndex { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models.Responses
{
    [DataContract]
    public class TripResponse : BaseResponse
    {
        /// <summary>
        /// Array of Waypoint objects representing all waypoints in input order. Each Waypoint object has the following additional properties:
        /// </summary>
        [DataMember(Name = "waypoints")]
        public Waypoint[] Waypoints { get; set; }

        /// <summary>
        /// An array of Route objects that assemble the trace.
        /// </summary>
        [DataMember(Name = "trips")]
        public Route[] Trips { get; set; }
    }
}
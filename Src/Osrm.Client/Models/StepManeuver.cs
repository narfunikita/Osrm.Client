using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class StepManeuver
    {
        /// <summary>
        /// The clockwise angle from true north to the direction of travel immediately after the maneuver.
        /// </summary>
        [DataMember(Name = "bearing_after")]
        protected int BearingAfter { get; set; }

        /// <summary>
        /// The clockwise angle from true north to the direction of travel immediately before the maneuver.
        /// </summary>
        [DataMember(Name = "bearing_before")]
        protected int BearingBefore { get; set; }

        /// <summary>
        /// An optional integer indicating number of the exit to take. The field exists for the following type field:
        /// </summary>
        [DataMember(Name = "exit")]
        protected int Exit { get; set; }

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

        /// <summary>
        /// A string indicating the type of maneuver. new identifiers might be introduced without API change Types unknown to the client should be handled like the turn type, the existance of correct modifier values is guranteed.
        /// </summary>
        [DataMember(Name = "type")]
        protected string Type { get; set; }

        /// <summary>
        /// An optional string indicating the direction change of the maneuver.
        /// </summary>
        [DataMember(Name = "modifier")]
        protected string Modifier { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class RouteSummary
    {
        /// <summary>
        /// Total length in meters as integer
        /// </summary>
        [DataMember(Name = "total_distance")]
        public int TotalDistance { get; set; }

        /// <summary>
        /// Total trip time in seconds as integer
        /// </summary>
        [DataMember(Name = "total_time")]
        public int TotalTime { get; set; }

        /// <summary>
        /// Name of the first street as string compressed as polyline
        /// </summary>
        [DataMember(Name = "start_point")]
        public string StartPoint { get; set; }

        /// <summary>
        /// Name of the last street as string compressed as polyline
        /// </summary>
        [DataMember(Name = "end_point")]
        public string EndPoint { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class MatchResponse : OsrmBaseResponse
    {
        /// <summary>
        /// Geometry of the route compressed as polyline, but with 6 decimals.
        /// </summary>
        [DataMember(Name = "matchings")]
        public Matching[] Matchings { get; set; }
    }
}
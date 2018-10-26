using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class Route
    {
        [DataMember(Name = "distance")]
        public double Distance { get; set; }

        [DataMember(Name = "duration")]
        public double Duration { get; set; }

        [DataMember(Name = "geometry")]
        public string GeometryStr { get; set; }

        public Location[] Geometry
        {
            get
            {
                if (string.IsNullOrEmpty(GeometryStr))
                {
                    return new Location[0];
                }

                return OsrmPolylineConverter.Decode(GeometryStr, 1E5)
                    .ToArray();
            }
        }

        [DataMember(Name = "weight")]
        public double Weight { get; set; }

        [DataMember(Name = "legs")]
        public RouteLeg[] Legs { get; set; }

        /// <summary>
        /// Match. Confidence of the matching. float value between 0 and 1. 1 is very confident that the matching is correct.
        /// </summary>
        [DataMember(Name = "confidence")]
        public float? Confidence { get; set; }
    }
}
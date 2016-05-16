using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class NearestResponse : OsrmBaseResponse
    {
        /// <summary>
        /// GName of the street the coordinate snapped to
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Array that contains the [lat, lon] pair of the snapped coordinate
        /// </summary>
        [DataMember(Name = "mapped_coordinate")]
        protected double[] MappedCoordinateArray { get; set; }

        /// <summary>
        /// Snapped coordinate
        /// </summary>
        public Location MappedCoordinate
        {
            get
            {
                if (MappedCoordinateArray == null)
                    return null;

                return new Location(MappedCoordinateArray[0], MappedCoordinateArray[1]);
            }
        }
    }
}
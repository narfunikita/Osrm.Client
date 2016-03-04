using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class TableResponse : OsrmBaseResponse
    {
        /// <summary>
        /// Array of arrays that stores the matrix in row-major order.
        /// distance_table[i][j] gives the travel time from the i-th via to the j-th via point.
        /// Values are given in 10th of a second.
        /// </summary>
        [DataMember(Name = "distance_table")]
        public int[][] DistanceTable { get; set; }

        /// <summary>
        /// Array of arrays that stores the matrix in row-major order.
        /// distance_table[i][j] gives the travel time from the i-th via to the j-th via point.
        /// </summary>
        public TimeSpan[][] DistanceTableTimes
        {
            get
            {
                if (DistanceTable == null)
                {
                    return null;
                }
                //TimeSpan.FromSeconds(t / 10))
                return DistanceTable.Select(x => x.Select(t => TimeSpan.FromMilliseconds(t * 100)).ToArray()).ToArray();
            }
        }

        /// <summary>
        /// Array of arrays that contains the [lat, lon] pair of the snapped coordinate
        /// </summary>
        [DataMember(Name = "destination_coordinates")]
        protected double[][] DestinationCoordinatesArray { get; set; }

        /// <summary>
        /// Array of snapped coordinate
        /// </summary>
        public Location[] DestinationCoordinates
        {
            get
            {
                if (DestinationCoordinatesArray == null)
                    return new Location[0];

                return DestinationCoordinatesArray.Select(x => new Location(x[0], x[1])).ToArray();
            }
        }

        /// <summary>
        /// Contains the [lat, lon] pair of the snapped coordinate
        /// </summary>
        [DataMember(Name = "source_coordinates")]
        protected double[][] SourceCoordinatesArray { get; set; }

        /// <summary>
        /// Array of snapped coordinate
        /// </summary>
        public Location[] SourceCoordinates
        {
            get
            {
                if (SourceCoordinatesArray == null)
                    return new Location[0];

                return SourceCoordinatesArray.Select(x => new Location(x[0], x[1])).ToArray();
            }
        }
    }
}
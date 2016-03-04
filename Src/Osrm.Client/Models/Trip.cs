using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class Trip : ViarouteResponse
    {
        /// <summary>
        /// permuation[i] gives the position in the trip of the i-th input coordinate.
        /// </summary>
        [DataMember(Name = "permutation")]
        public int[] Permutation { get; set; }
    }
}
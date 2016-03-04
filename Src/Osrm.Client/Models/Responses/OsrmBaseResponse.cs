using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public abstract class OsrmBaseResponse
    {
        /// <summary>
        /// The status code. 200 means successful, 207 means no route was found.
        /// </summary>
        [DataMember(Name = "status")]
        public int Status { get; set; }

        /// <summary>
        /// (optional) can either be Found route between points or Cannot find route between points
        /// </summary>
        [DataMember(Name = "status_message")]
        public string StatusMessage { get; set; }
    }
}
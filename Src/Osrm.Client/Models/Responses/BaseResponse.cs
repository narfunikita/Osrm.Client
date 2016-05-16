using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public abstract class BaseResponse
    {
        /// <summary>
        /// The status code. 200 means successful, 207 means no route was found.
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// (optional) can either be Found route between points or Cannot find route between points
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
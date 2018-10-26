using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Models
{
    [DataContract]
    public class Annotation
    {
        [DataMember(Name = "distance")]
        public double[] Distance { get; set; }

        [DataMember(Name = "duration")]
        public double[] Duration { get; set; }

        [DataMember(Name = "datasources")]
        public int[] DataSources { get; set; }

        [DataMember(Name = "nodes")]
        public long[] Nodes { get; set; }

        [DataMember(Name = "weight")]
        public double[] Weight { get; set; }

        [DataMember(Name = "speed")]
        public double[] Speed { get; set; }
    }
}

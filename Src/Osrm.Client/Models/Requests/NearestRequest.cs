using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class NearestRequest
    {
        /// <summary>
        /// Location of the node
        /// </summary>
        public Location Location { get; set; }

        public List<Tuple<string, string>> UrlParams
        {
            get
            {
                var urlParams = new List<Tuple<string, string>>();
                urlParams.AddRange(OsrmRequestBuilder.CreateLocationParams("loc", new Location[] { Location }));

                return urlParams;
            }
        }
    }
}
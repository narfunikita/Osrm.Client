using Newtonsoft.Json;
using Osrm.Client.Models;

using Osrm.Client.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class OsrmClient
    {
        public string Url { get; set; }

        public OsrmClient(string url)
        {
            Url = url;
        }

        public ViarouteResponce Route(Location[] locs)
        {
            return Route(new ViarouteRequest()
            {
                Locations = locs
            });
        }

        public ViarouteResponce Route(ViarouteRequest requestParams)
        {
            var json = Send("viaroute", requestParams.UrlParams);
            var r = JsonConvert.DeserializeObject<ViarouteResponce>(json);
            return r;
        }

        private string Send(string service, List<Tuple<string, string>> urlParams)
        {
            var builder = OsrmRequestBuilder.Build(Url, service);

            var fullUrl = builder.GetUrl(urlParams);
            string json = null;
            using (var client = new WebClient())
            {
                json = client.DownloadString(new Uri(fullUrl));
            }

            return json;
        }
    }
}
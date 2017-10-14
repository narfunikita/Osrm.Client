using Newtonsoft.Json;
using Osrm.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.v5
{
    public class Osrm5x
    {
        public string Url { get; set; }

        /// <summary>
        /// Version of the protocol implemented by the service.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Mode of transportation, is determined by the profile that is used to prepare the data
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Timeout for web request. If not specified default value will be used.
        /// </summary>
        public int? Timeout { get; set; }

        protected readonly string RouteServiceName = "route";
        protected readonly string NearestServiceName = "nearest";
        protected readonly string TableServiceName = "table";
        protected readonly string MatchServiceName = "match";
        protected readonly string TripServiceName = "trip";
        protected readonly string TileServiceName = "tile";

        public Osrm5x(string url, string version = "v1", string profile = "driving")
        {
            Url = url;
            Version = version;
            Profile = profile;
        }

        /// <summary>
        /// This service provides shortest path queries with multiple via locations.
        /// It supports the computation of alternative paths as well as giving turn instructions.
        /// </summary>
        /// <param name="locs"></param>
        /// <returns></returns>
        public RouteResponse Route(Location[] locs)
        {
            return Route(new RouteRequest()
            {
                Coordinates = locs
            });
        }

        /// <summary>
        /// This service provides shortest path queries with multiple via locations.
        /// It supports the computation of alternative paths as well as giving turn instructions.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public RouteResponse Route(RouteRequest requestParams)
        {
            return Send<RouteResponse>(RouteServiceName, requestParams);
        }

        public Osrm.Client.Models.Responses.NearestResponse Nearest(params Location[] locs)
        {
            return Nearest(new Osrm.Client.Models.NearestRequest()
            {
                Coordinates = locs
            });
        }

        public Osrm.Client.Models.Responses.NearestResponse Nearest(Osrm.Client.Models.NearestRequest requestParams)
        {
            return Send<Osrm.Client.Models.Responses.NearestResponse>(NearestServiceName, requestParams);
        }

        public Osrm.Client.Models.Responses.TableResponse Table(params Location[] locs)
        {
            return Table(new Osrm.Client.Models.TableRequest()
            {
                Coordinates = locs
            });
        }

        public Osrm.Client.Models.Responses.TableResponse Table(Osrm.Client.Models.TableRequest requestParams)
        {
            return Send<Osrm.Client.Models.Responses.TableResponse>(TableServiceName, requestParams);
        }

        public Osrm.Client.Models.Responses.MatchResponse Match(params Location[] locs)
        {
            return Match(new Osrm.Client.Models.MatchRequest()
            {
                Coordinates = locs
            });
        }

        public Osrm.Client.Models.Responses.MatchResponse Match(Osrm.Client.Models.MatchRequest requestParams)
        {
            return Send<Osrm.Client.Models.Responses.MatchResponse>(MatchServiceName, requestParams);
        }

        public Osrm.Client.Models.Responses.TripResponse Trip(params Location[] locs)
        {
            return Trip(new Osrm.Client.Models.TripRequest()
            {
                Coordinates = locs
            });
        }

        public Osrm.Client.Models.Responses.TripResponse Trip(Osrm.Client.Models.TripRequest requestParams)
        {
            return Send<Osrm.Client.Models.Responses.TripResponse>(TripServiceName, requestParams);
        }

        protected T Send<T>(string service, BaseRequest request) //string coordinatesStr, List<Tuple<string, string>> urlParams)
        {
            var coordinatesStr = request.CoordinatesUrlPart;
            List<Tuple<string, string>> urlParams = request.UrlParams;
            var fullUrl = OsrmRequestBuilder.GetUrl(Url, service, Version, Profile, coordinatesStr, urlParams);
            string json = null;
            using (var client = new OsrmWebClient(Timeout))
            {
                json = client.DownloadString(new Uri(fullUrl));
            }

            return JsonConvert.DeserializeObject<T>(json); ;
        }

        private class OsrmWebClient : WebClient
        {
            private readonly int? _specificTimeout;

            public OsrmWebClient(int? timeout = null)
            {
                _specificTimeout = timeout;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);

                if (request != null && _specificTimeout.HasValue)
                    request.Timeout = _specificTimeout.Value;

                return request;
            }
        }

    }
}
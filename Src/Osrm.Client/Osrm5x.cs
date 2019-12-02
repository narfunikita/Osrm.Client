using Newtonsoft.Json;
using Osrm.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.v5
{
    
    public class Osrm5x
    {
        private static readonly HttpClient client = new HttpClient();
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
        public async Task<RouteResponse> RouteAsync(Location[] locs)
        {
            return await RouteAsync(new RouteRequest()
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
        /// 

        public async Task<RouteResponse> RouteAsync(RouteRequest requestParams)
        {
            return await SendAsync<RouteResponse>(RouteServiceName, requestParams);
        }

        public async Task<Models.Responses.NearestResponse> NearestAsync(params Location[] locs)
        {
            return await NearestAsync(new Osrm.Client.Models.NearestRequest()
            {
                Coordinates = locs
            });
        }

        public async Task<Models.Responses.NearestResponse> NearestAsync(Osrm.Client.Models.NearestRequest requestParams)
        {
            return await SendAsync<Osrm.Client.Models.Responses.NearestResponse>(NearestServiceName, requestParams);
        }

        public async Task<Models.Responses.TableResponse> TableAsync(params Location[] locs)
        {
            return await TableAsync(new Osrm.Client.Models.TableRequest()
            {
                Coordinates = locs
            });
        }

        public async Task<Models.Responses.TableResponse> TableAsync(Osrm.Client.Models.TableRequest requestParams)
        {
            return await SendAsync<Osrm.Client.Models.Responses.TableResponse>(TableServiceName, requestParams);
        }

        public async Task<Models.Responses.MatchResponse> MatchAsync(params Location[] locs)
        {
            return await MatchAsync(new Osrm.Client.Models.MatchRequest()
            {
                Coordinates = locs
            });
        }

        public async Task<Models.Responses.MatchResponse> MatchAsync(Osrm.Client.Models.MatchRequest requestParams)
        {
            return await SendAsync<Osrm.Client.Models.Responses.MatchResponse>(MatchServiceName, requestParams);
        }

        public async Task<Models.Responses.TripResponse> TripAsync(params Location[] locs)
        {
            return await TripAsync(new Osrm.Client.Models.TripRequest()
            {
                Coordinates = locs
            });
        }

        public async Task<Models.Responses.TripResponse> TripAsync(Osrm.Client.Models.TripRequest requestParams)
        {
            return await SendAsync<Osrm.Client.Models.Responses.TripResponse>(TripServiceName, requestParams);
        }
        
        protected async Task<T> SendAsync<T>(string service, BaseRequest request) //string coordinatesStr, List<Tuple<string, string>> urlParams)
        {
            var coordinatesStr = request.CoordinatesUrlPart;
            List<Tuple<string, string>> urlParams = request.UrlParams;
            var fullUrl = OsrmRequestBuilder.GetUrl(Url, service, Version, Profile, coordinatesStr, urlParams);

            var responseString = await client.GetStringAsync(fullUrl);

            return JsonConvert.DeserializeObject<T>(responseString); ;
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
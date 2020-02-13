using Newtonsoft.Json;
using Osrm.Client.Models;

using Osrm.Client.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class OsrmClient
    {
        private static readonly HttpClient client = new HttpClient();
        public string Url { get; set; }

        protected readonly string NearestServiceName = "nearest";
        protected readonly string RouteServiceName = "viaroute";
        protected readonly string TableServiceName = "table";
        protected readonly string MatchServiceName = "match";
        protected readonly string TripServiceName = "trip";

        public OsrmClient(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Returns the nearest street segment for a given coordinate
        /// <param name="locs"></param>
        /// <returns></returns>
        public async Task<NearestResponse> NearestAsync(Location loc)
        {
            return await NearestAsync(new NearestRequest()
            {
                Location = loc
            });
        }

        /// <summary>
        /// Returns the nearest street segment for a given coordinate
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public async Task<NearestResponse> NearestAsync(NearestRequest requestParams)
        {
            return await SendAsync<NearestResponse>(NearestServiceName, requestParams.UrlParams);
        }

        /// <summary>
        /// This service provides shortest path queries with multiple via locations.
        /// It supports the computation of alternative paths as well as giving turn instructions.
        /// </summary>
        /// <param name="locs"></param>
        /// <returns></returns>
        public async Task<ViarouteResponse> RouteAsync(Location[] locs)
        {
            return await RouteAsync(new ViarouteRequest()
            {
                Locations = locs
            });
        }

        /// <summary>
        /// This service provides shortest path queries with multiple via locations.
        /// It supports the computation of alternative paths as well as giving turn instructions.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public async Task<ViarouteResponse> RouteAsync(ViarouteRequest requestParams)
        {
            return await SendAsync<ViarouteResponse>(RouteServiceName, requestParams.UrlParams);
        }

        /// <summary>
        /// This computes distance tables for the given via points.
        /// Please note that the distance in this case is the travel time which is the default metric used by OSRM.
        /// If only loc parameter is used, all pair-wise distances are computed.
        /// If dst and src parameters are used instead, only pairs between scr/dst are computed.
        /// </summary>
        /// <param name="locs"></param>
        /// <returns></returns>
        public async Task<TableResponse> TableAsync(Location[] locs)
        {
            return await TableAsync(new TableRequest()
            {
                Locations = locs
            });
        }

        /// <summary>
        /// This computes distance tables for the given via points.
        /// Please note that the distance in this case is the travel time which is the default metric used by OSRM.
        /// If only loc parameter is used, all pair-wise distances are computed.
        /// If dst and src parameters are used instead, only pairs between scr/dst are computed.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public async Task<TableResponse> TableAsync(TableRequest requestParams)
        {
            return await SendAsync<TableResponse>(TableServiceName, requestParams.UrlParams);
        }

        /// <summary>
        /// Map matching matches given GPS points to the road network in the most plausible way.
        /// Currently the algorithm works best with trace data that has a sample resolution of 5-10 samples/min.
        /// Please note the request might result multiple sub-traces.
        /// Large jumps in the timestamps (>60s) or improbable transitions lead to trace splits if a complete matching could not be found.
        /// The algorithm might not be able to match all points.
        /// Outliers are removed if they can not be matched successfully.
        /// </summary>
        /// <param name="locs"></param>
        /// <returns></returns>
        public async Task<MatchResponse> MatchAsync(LocationWithTimestamp[] locs)
        {
            return await MatchAsync(new MatchRequest()
            {
                Locations = locs
            });
        }

        /// <summary>
        /// Map matching matches given GPS points to the road network in the most plausible way.
        /// Currently the algorithm works best with trace data that has a sample resolution of 5-10 samples/min.
        /// Please note the request might result multiple sub-traces.
        /// Large jumps in the timestamps (>60s) or improbable transitions lead to trace splits if a complete matching could not be found.
        /// The algorithm might not be able to match all points.
        /// Outliers are removed if they can not be matched successfully.
        /// </summary>
        /// <param name="requestParams"></param>
        /// <returns></returns>
        public async Task<MatchResponse> MatchAsync(MatchRequest requestParams)
        {
            return await SendAsync<MatchResponse>(MatchServiceName, requestParams.UrlParams);
        }

        /// <summary>
        /// The trip plugin solves the famous Traveling Salesman Problem using a greedy heuristic (farest-insertion algorithm).
        /// The returned path does not have to be the shortest path, as TSP is NP-hard it is only an approximation.
        /// Note that if the input coordinates can not be joined by a single trip (e.g. the coordinates are on several disconnecte islands)
        /// multiple trips for each connected component are returned.
        /// Trip does not support computing alternatives
        /// </summary>
        /// <param name="locs">Trip does not support computing alternatives</param>
        /// <returns></returns>
        public async Task<TripResponse> TripAsync(Location[] locs)
        {
            return await TripAsync(new ViarouteRequest()
            {
                Locations = locs
            });
        }

        /// <summary>
        /// The trip plugin solves the famous Traveling Salesman Problem using a greedy heuristic (farest-insertion algorithm).
        /// The returned path does not have to be the shortest path, as TSP is NP-hard it is only an approximation.
        /// Note that if the input coordinates can not be joined by a single trip (e.g. the coordinates are on several disconnecte islands)
        /// multiple trips for each connected component are returned.
        /// Trip does not support computing alternatives.
        /// <param name="requestParams">Trip does not support computing alternatives</param>
        /// <returns></returns>
        public async Task<TripResponse> TripAsync(ViarouteRequest requestParams)
        {
            return await SendAsync<TripResponse>(TripServiceName, requestParams.UrlParams);
        }

        protected async Task<T> SendAsync<T>(string service, List<Tuple<string, string>> urlParams)
        {
            
            var fullUrl = OsrmRequestBuilder.GetUrl(Url, service, urlParams);
            var responseString = await client.GetStringAsync(fullUrl);


            return JsonConvert.DeserializeObject<T>(responseString); ;
        }
    }
}
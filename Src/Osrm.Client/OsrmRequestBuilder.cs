using Osrm.Client.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Osrm.Client
{
    internal class OsrmRequestBuilder
    {
        private string _url;
        private string _service;
        private readonly bool _useLocsEndodedPath;
        private readonly List<Location> _locs;
        public bool Instructions = false;

        public OsrmRequestBuilder()
        {
            _locs = new List<Location>();
        }

        public OsrmRequestBuilder(string url, string service)
            : base()
        {
            _url = url;
            _service = service;
        }

        public static OsrmRequestBuilder Build(string baseUrl, string service)
        {
            return new OsrmRequestBuilder(baseUrl, service);
        }

        public string GetUrl(List<Tuple<string, string>> urlParams)
        {
            var uriBuilder = new UriBuilder(_url);
            uriBuilder.Path += _service;
            var url = uriBuilder.Uri.ToString();

            var encodedParams = urlParams
                .Select(x => string.Format("{0}={1}", HttpUtility.UrlEncode(x.Item1), HttpUtility.UrlEncode(x.Item2)))
                .ToList();

            var result = url + "?" + string.Join("&", encodedParams);

            return result;
        }
    }
}
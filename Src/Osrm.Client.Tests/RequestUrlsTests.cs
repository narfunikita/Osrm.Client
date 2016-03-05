using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Tests
{
    [TestClass]
    public class RequestUrlsTests
    {
        private Location[] locations = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.42929),
            };

        private Location[] src = new Location[] {
                new Location(52.55407, 13.160621),
            };

        private Location[] dst = new Location[] {
                new Location(52.431272, 13.720654)
            };

        private LocationWithTimestamp[] matchLocations = new LocationWithTimestamp[] {
                new LocationWithTimestamp(52.542648, 13.393252, 1424684612),
                new LocationWithTimestamp(52.543079, 13.394780, 1424684616),
                new LocationWithTimestamp(52.542107, 13.397389, 142468462)
            };

        private string[] ParamValues(List<Tuple<string, string>> urlParams, string paramKey)
        {
            return urlParams.Where(p => p.Item1 == paramKey).Select(p => p.Item2).ToArray();
        }

        [TestMethod]
        public void RouteRequest_Url()
        {
            var r = new ViarouteRequest();
            r.Locations = locations;
            var locParams = ParamValues(r.UrlParams, "loc");
            Assert.AreEqual<int>(locations.Length, locParams.Length);
            Assert.IsTrue(locParams.Contains("52.503033,13.420526"));
            Assert.IsTrue(locParams.Contains("52.516582,13.42929"));
            r.SendLocsAsEncodedPolyline = true;
            Assert.AreEqual<int>(0, ParamValues(r.UrlParams, "loc").Length);
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "locs").Length);
            r.Zoom = 5;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "z").Length);
            Assert.AreEqual<string>("5", ParamValues(r.UrlParams, "z")[0]);
            r.Instructions = true;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "instructions").Length);
            Assert.AreEqual<string>("true", ParamValues(r.UrlParams, "instructions")[0]);
            r.Alternative = false;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "alt").Length);
            Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "alt")[0]);
            r.Geometry = false;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "geometry").Length);
            Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "geometry")[0]);
            r.Compression = false;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "compression").Length);
            Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "compression")[0]);
            r.UTurns = true;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "uturns").Length);
            Assert.AreEqual<string>("true", ParamValues(r.UrlParams, "uturns")[0]);
            r.UTurnAtTheVia = true;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "u").Length);
            Assert.AreEqual<string>("true", ParamValues(r.UrlParams, "u")[0]);
            r.Hint = "hinttest";
            Assert.AreEqual<string>("hinttest", ParamValues(r.UrlParams, "hint")[0]);
            r.Checksum = "checksumTest";
            Assert.AreEqual<string>("checksumTest", ParamValues(r.UrlParams, "checksum")[0]);
        }

        [TestMethod]
        public void TableRequest_Url()
        {
            var r = new TableRequest();
            r.Locations = locations;
            var locParams = ParamValues(r.UrlParams, "loc");
            Assert.AreEqual<int>(locations.Length, locParams.Length);
            Assert.IsTrue(locParams.Contains("52.503033,13.420526"));
            Assert.IsTrue(locParams.Contains("52.516582,13.42929"));
            r.SourceLocations = src;
            var srcParams = ParamValues(r.UrlParams, "src");
            Assert.AreEqual<int>(src.Length, srcParams.Length);
            Assert.IsTrue(srcParams.Contains("52.55407,13.160621"));
            r.DestinationLocations = dst;
            var dstParams = ParamValues(r.UrlParams, "dst");
            Assert.AreEqual<int>(dst.Length, dstParams.Length);
            Assert.IsTrue(dstParams.Contains("52.431272,13.720654"));
        }

        [TestMethod]
        public void MatchRequest_Url()
        {
            var r = new MatchRequest();
            r.Locations = matchLocations;
            var locParams = ParamValues(r.UrlParams, "loc");
            Assert.AreEqual<int>(matchLocations.Length, locParams.Length);
            Assert.IsTrue(locParams.Contains("52.542648,13.393252"));
            Assert.IsTrue(locParams.Contains("52.543079,13.39478"));
            Assert.IsTrue(locParams.Contains("52.542107,13.397389"));
            var tParams = ParamValues(r.UrlParams, "t");
            Assert.AreEqual<int>(matchLocations.Length, tParams.Length);
            Assert.IsTrue(tParams.Contains("1424684612"));
            Assert.IsTrue(tParams.Contains("1424684616"));
            Assert.IsTrue(tParams.Contains("142468462"));

            r.SendLocsAsEncodedPolyline = true;
            Assert.AreEqual<int>(0, ParamValues(r.UrlParams, "loc").Length);
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "locs").Length);
            r.Geometry = false;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "geometry").Length);
            Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "geometry")[0]);
            r.Compression = false;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "compression").Length);
            Assert.AreEqual<string>("false", ParamValues(r.UrlParams, "compression")[0]);
            r.Classify = true;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "classify").Length);
            Assert.AreEqual<string>("true", ParamValues(r.UrlParams, "classify")[0]);
            r.Instructions = true;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "instructions").Length);
            Assert.AreEqual<string>("true", ParamValues(r.UrlParams, "instructions")[0]);
            r.GpsPrecision = 3;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "gps_precision").Length);
            Assert.AreEqual<string>("3", ParamValues(r.UrlParams, "gps_precision")[0]);
            r.MatchingBeta = 8;
            Assert.AreEqual<int>(1, ParamValues(r.UrlParams, "matching_beta").Length);
            Assert.AreEqual<string>("8", ParamValues(r.UrlParams, "matching_beta")[0]);
            r.Hint = "hinttest";
            Assert.AreEqual<string>("hinttest", ParamValues(r.UrlParams, "hint")[0]);
            r.Checksum = "checksumTest";
            Assert.AreEqual<string>("checksumTest", ParamValues(r.UrlParams, "checksum")[0]);
        }

        [TestMethod]
        public void NearestRequest_Url()
        {
            var r = new NearestRequest();
            r.Location = new Location(52.4224, 13.333086);
            var locParams = ParamValues(r.UrlParams, "loc");
            Assert.AreEqual<int>(1, locParams.Length);
            Assert.IsTrue(locParams.Contains("52.4224,13.333086"));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Osrm.Client.Tests
{
    [TestClass]
    public class RequestModelsTests
    {
        [TestMethod]
        public void RouteRequest_Defaults()
        {
            var r = new ViarouteRequest();
            Assert.AreEqual<int>(18, r.Zoom);
            Assert.AreEqual<bool>(false, r.Instructions);
            Assert.AreEqual<bool>(true, r.Alternative);
            Assert.AreEqual<bool>(true, r.Geometry);
            Assert.AreEqual<bool>(true, r.Compression);
            Assert.AreEqual<bool>(false, r.UTurns);
            Assert.AreEqual<bool>(false, r.UTurnAtTheVia);
            Assert.IsNull(r.Hint);
            Assert.IsNull(r.Checksum);
        }

        [TestMethod]
        public void TableRequest_Defaults()
        {
            var r = new TableRequest();
            Assert.IsNull(r.Locations);
            Assert.IsNull(r.SourceLocations);
            Assert.IsNull(r.DestinationLocations);
        }

        [TestMethod]
        public void MatchRequest_Defaults()
        {
            var r = new MatchRequest();
            Assert.AreEqual<bool>(true, r.Geometry);
            Assert.AreEqual<bool>(true, r.Geometry);
            Assert.AreEqual<bool>(true, r.Compression);
            Assert.AreEqual<bool>(false, r.Classify);
            Assert.AreEqual<bool>(false, r.Instructions);
            Assert.AreEqual<float>(5f, r.GpsPrecision);
            Assert.AreEqual<float>(10f, r.MatchingBeta);
            Assert.IsNull(r.Hint);
            Assert.IsNull(r.Checksum);
        }

        [TestMethod]
        public void NearestRequest_Defaults()
        {
            var r = new NearestRequest();
            Assert.IsNull(r.Location);
        }

        [TestMethod]
        public void Location_Equals()
        {
            var a1 = new LocationWithTimestamp(52.542648, 13.393252, 1424684612);
            var a2 = new LocationWithTimestamp(52.542648, 13.393252, 1424684612);
            var a3 = new LocationWithTimestamp(52.542648, 13.393252);
            Assert.IsTrue(a1 == a2);
            Assert.IsFalse(a1 == a3);
            Assert.IsTrue(a1.Equals(a2));
            Assert.IsFalse(a1.Equals(a3));

            var b1 = new Location(12.542648, 13.393252);
            var b2 = new Location(12.542648, 13.393252);
            var b3 = new Location(12.542648, 99.393252);
            Assert.IsTrue(b1 == b2);
            Assert.IsFalse(b1 == b3);
            Assert.IsTrue(b1.Equals(b2));
            Assert.IsFalse(b1.Equals(b3));
        }
    }
}
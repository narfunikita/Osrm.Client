using Microsoft.VisualStudio.TestTools.UnitTesting;
using Osrm.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Tests
{
    [TestClass]
    public class ResponseTests
    {
        protected OsrmClient osrm = new OsrmClient("http://router.project-osrm.org/");

        private void CheckStatus200(OsrmBaseResponse response)
        {
            Assert.AreEqual(200, response.Status);
        }

        [TestMethod]
        public void Route_Response()
        {
            var locations = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.429290),
            };
            /*
            var result = osrm.RouteAsync(locations);
            var geometryLenDefaultZoom = result.Result.RouteGeometry.Length;
            
            CheckStatus200(result.Result);
            
            Assert.IsTrue(result.Result.RouteName.Length > 0);
            Assert.IsTrue(result.Result.AlternativeGeometries.Length > 0);
            Assert.AreEqual<int>(0, result.Result.RouteInstructions.Length);
            */
            var result2 = osrm.RouteAsync(new ViarouteRequest()
            {
                Locations = locations,
                SendLocsAsEncodedPolyline = true,
                Alternative = false,
            });
            
            //CheckStatus200(result2.Result);
            //Assert.AreEqual(200, result2.Result.StatusMessage);
            //Assert.AreEqual<int>(0, result2.Result.AlternativeGeometries.Length);
            //Assert.AreEqual<int>(0, result2.Result.RouteInstructions.Length);
            
            var result3 = osrm.RouteAsync(new ViarouteRequest()
            {
                Locations = locations,
                Instructions = true,
                Zoom = 5
            });
            /*
            CheckStatus200(result3.Result);
            Assert.IsTrue(result3.Result.AlternativeGeometries.Length > 0);
            Assert.IsTrue(result3.Result.RouteInstructions.Length > 0);
            var geometryLenZoom3 = result3.Result.RouteGeometry.Length;
            Assert.IsTrue(geometryLenZoom3 < geometryLenDefaultZoom);
            */
        }

        [TestMethod]
        public void Table_Response()
        {
            var locations = new Location[] {
                new Location(52.554070, 13.160621),
                new Location(52.431272, 13.720654),
                new Location(52.554070, 13.720654),
                new Location(52.554070, 13.160621),
            };
            /*
            var result = osrm.TableAsync(locations);
            CheckStatus200(result.Result);
            Assert.AreEqual<int>(4, result.Result.DistanceTable.Length);
            Assert.AreEqual<int>(4, result.Result.DistanceTable[0].Length);
            Assert.AreEqual<int>(4, result.Result.DistanceTable[1].Length);
            Assert.AreEqual<int>(4, result.Result.DistanceTable[2].Length);
            Assert.AreEqual<int>(4, result.Result.DistanceTable[3].Length);
            */
            var src = new Location[] {
                new Location(52.554070, 13.160621),
            };

            var dst = new Location[] {
                new Location(52.431272, 13.720654),
                new Location(52.554070, 13.720654),
                new Location(52.554070, 13.160621),
            };

            var result2 = osrm.TableAsync(new TableRequest()
            {
                SourceLocations = src,
                DestinationLocations = dst
            });
            /*
            CheckStatus200(result2.Result);
            Assert.AreEqual<int>(1, result2.Result.DistanceTable.Length);
            Assert.AreEqual<int>(3, result2.Result.DistanceTable[0].Length);
            */
        }

        [TestMethod]
        public void Match_Response()
        {
            var locations = new LocationWithTimestamp[] {
                new LocationWithTimestamp(52.542648, 13.393252, 1424684612),
                new LocationWithTimestamp(52.543079, 13.394780, 1424684616),
                new LocationWithTimestamp(52.542107, 13.397389, 1424684620)
            };

            var request = new MatchRequest()
            {
                Locations = locations,
                Instructions = true,
                Classify = true
            };

            var result = osrm.MatchAsync(request);
            /*
            CheckStatus200(result.Result);
            Assert.IsTrue(result.Result.Matchings.Length > 0);
            Assert.IsTrue(result.Result.Matchings[0].Instructions.Length > 0);
            Assert.IsNotNull(result.Result.Matchings[0].Confidence);
            */
        }

        [TestMethod]
        public void Nearest_Response()
        {
            var result = osrm.NearestAsync(new Location(52.4224, 13.333086));

            /*
            CheckStatus200(result.Result);
            Assert.IsNotNull(result.Result.MappedCoordinate);
            */
        }

        [TestMethod]
        public void Trip_Response()
        {
            var locations = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.429290),
            };

            var result = osrm.TripAsync(locations);
            /*
            CheckStatus200(result.Result);
            
            Assert.AreEqual<int>(1, result.Result.Trips.Length);
            Assert.IsTrue(result.Result.Trips[0].Permutation.Length > 0);
            Assert.IsTrue(result.Result.Trips[0].RouteName.Length > 0);
            Assert.IsTrue(result.Result.Trips[0].RouteGeometry.Length > 0);
            */
        }
    }
}
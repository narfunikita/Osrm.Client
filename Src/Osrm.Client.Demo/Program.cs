using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client.Demo
{
    internal class Program
    {
        public static string OsrmUrl = "http://router.project-osrm.org/";

        private static void Main(string[] args)
        {
            OsrmClient osrm = new OsrmClient(OsrmUrl);
            Route(osrm);
            Table(osrm);
            Match(osrm);
            Nearest(osrm);
            Trip(osrm);
        }

        private static void Route(OsrmClient osrm)
        {
            var locations = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.429290),
            };

            var result = osrm.Route(locations);

            var result2 = osrm.Route(new ViarouteRequest()
            {
                Locations = locations,
                SendLocsAsEncodedPolyline = true,
                Alternative = false,
            });

            var result3 = osrm.Route(new ViarouteRequest()
            {
                Locations = locations,
                Instructions = true,
                Zoom = 5
            });
            var instructions3 = result3.RouteInstructions;
        }

        private static void Table(OsrmClient osrm)
        {
            var locations = new Location[] {
                new Location(52.554070, 13.160621),
                new Location(52.431272, 13.720654),
                new Location(52.554070, 13.720654),
                new Location(52.554070, 13.160621),
            };

            var result = osrm.Table(locations);

            var src = new Location[] {
                new Location(52.554070, 13.160621),
            };

            var dst = new Location[] {
                new Location(52.431272, 13.720654),
                new Location(52.554070, 13.720654),
                new Location(52.554070, 13.160621),
            };

            var result2 = osrm.Table(new TableRequest()
            {
                SourceLocations = src,
                DestinationLocations = dst
            });
        }

        private static void Match(OsrmClient osrm)
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

            var a1 = new LocationWithTimestamp(52.542648, 13.393252, 1424684612);
            var a2 = new LocationWithTimestamp(52.542648, 13.393252, 1424684612);
            var a3 = new LocationWithTimestamp(52.542648, 13.393252);
            var at1 = a1 == a2;
            var at2 = a1 == a3;
            var at3 = a1.Equals(a2);
            var at4 = a1.Equals(a3);

            var b1 = new Location(12.542648, 13.393252);
            var b2 = new Location(12.542648, 13.393252);
            var b3 = new Location(12.542648, 99.393252);
            var bt1 = b1 == b2;
            var bt2 = b1 == b3;
            var bt3 = b1.Equals(b2);
            var bt4 = b1.Equals(b3);

            var result = osrm.Match(request);
        }

        private static void Nearest(OsrmClient osrm)
        {
            var result = osrm.Nearest(new Location(52.4224, 13.333086));
        }

        private static void Trip(OsrmClient osrm)
        {
            var locations = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.429290),
            };

            var result = osrm.Trip(locations);
        }
    }
}
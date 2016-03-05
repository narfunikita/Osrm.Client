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
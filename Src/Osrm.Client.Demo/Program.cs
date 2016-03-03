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
        }

        private static void Route(OsrmClient osrm)
        {
            var positions = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.429290),
            };

            var result = osrm.Route(positions);

            var result2 = osrm.Route(new ViarouteRequest()
            {
                Locations = positions,
                Instructions = true,
                Zoom = 5
            });
            var instructions2 = result2.RouteInstructions;
        }
    }
}
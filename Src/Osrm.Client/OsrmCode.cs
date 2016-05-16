using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public static class OsrmCode
    {
        //      General
        public const string Ok = "Ok";

        public const string InvalidUrl = "InvalidUrl";
        public const string InvalidService = "InvalidService";
        public const string InvalidVersion = "InvalidVersion";
        public const string InvalidOptions = "InvalidOptions";
        public const string NoSegment = "NoSegment";
        public const string TooBig = "TooBig";

        //      Route responces
        public const string NoRoute = "NoRoute";

        //      Table responces
        public const string NoTable = "NoTable";

        //      Match responces
        /// <summary>
        /// No matchings found
        /// </summary>
        public const string NoMatch = "NoMatch";

        /// <summary>
        /// 	No trips found.
        /// </summary>
        public const string NoTrips = "NoTrips";
    }
}
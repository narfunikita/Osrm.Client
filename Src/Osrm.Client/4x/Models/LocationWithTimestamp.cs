using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osrm.Client
{
    public class LocationWithTimestamp : Location
    {
        public double? UnixTimeStamp { get; set; }

        public DateTime? Timestamp
        {
            get
            {
                if (UnixTimeStamp == null)
                {
                    return null;
                }

                return UnixTimeStampToDateTime(UnixTimeStamp.Value);
            }
            set
            {
                if (value == null)
                {
                    UnixTimeStamp = null;
                }
                else
                {
                    UnixTimeStamp = DateTimeToUnixTimestamp(value.Value);
                }
            }
        }

        public LocationWithTimestamp()

            : base()
        {
        }

        public LocationWithTimestamp(double latitude, double longitude, DateTime? timestamp = null)
            : base(latitude, longitude)
        {
            Timestamp = timestamp;
        }

        public LocationWithTimestamp(double latitude, double longitude, double? unixTimestamp)
            : base(latitude, longitude)
        {
            UnixTimeStamp = unixTimestamp;
        }

        public override bool Equals(System.Object obj)
        {
            LocationWithTimestamp p = obj as LocationWithTimestamp;
            if ((object)p == null)
            {
                return false;
            }

            return base.Equals(obj) && UnixTimeStamp == p.UnixTimeStamp;
        }

        public bool Equals(LocationWithTimestamp p)
        {
            return base.Equals((LocationWithTimestamp)p) && UnixTimeStamp == p.UnixTimeStamp;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ UnixTimeStamp.GetHashCode();
        }

        public static bool operator ==(LocationWithTimestamp a, LocationWithTimestamp b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Latitude == b.Latitude && a.Longitude == b.Longitude && a.UnixTimeStamp == b.UnixTimeStamp;
        }

        public static bool operator !=(LocationWithTimestamp a, LocationWithTimestamp b)
        {
            return !(a == b);
        }

        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
using System;

namespace Kinoheld.Api.Client.Helper
{
    public static class DateTimeHelper
    {
        public static DateTime ToDateTime(this long unixTimeStamp)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimeStamp);
            return dt;
        }
    }
}
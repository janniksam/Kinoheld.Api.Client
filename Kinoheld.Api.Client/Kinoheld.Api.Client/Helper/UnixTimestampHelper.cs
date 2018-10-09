using System;

namespace Kinoheld.Api.Client.Helper
{
    public static class UnixTimestampHelper
    {
        public static DateTime ToGermanDateTime(this long unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return TimeZoneInfo.ConvertTime(
                dtDateTime, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));
        }
    }
}
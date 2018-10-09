using System;

namespace Kinoheld.Api.Client.Helper
{
    public static class UnixTimestampHelper
    {
        public static DateTime ToDateTime(this long unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
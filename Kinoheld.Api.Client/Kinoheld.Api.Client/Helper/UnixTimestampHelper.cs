using System;

namespace Kinoheld.Api.Client.Helper
{
    public static class UnixTimestampHelper
    {
        public static DateTime ToGermanDateTime(this long unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).AddHours(2);
            return dtDateTime;
        }
    }
}
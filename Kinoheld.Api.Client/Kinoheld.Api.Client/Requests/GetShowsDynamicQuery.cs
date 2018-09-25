using System;

namespace Kinoheld.Api.Client.Requests
{
    [Flags]
    public enum GetShowsDynamicQuery
    {
        Full = 0,
        Name = 1,
        Beginning = 2,
        Flags = 4,
        DetailUrl = 8,
        MovieInfo = 16
    }
}
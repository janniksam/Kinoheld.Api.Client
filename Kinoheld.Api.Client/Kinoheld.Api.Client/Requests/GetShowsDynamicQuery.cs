using System;

namespace Kinoheld.Api.Client.Requests
{
    [Flags]
    public enum GetShowsDynamicQuery
    {
        Full = 0,
        Id = 1,
        Name = 2,
        Beginning = 5,
        Flags = 8,
        DetailUrl = 16,
        MovieInfo = 32
    }
}
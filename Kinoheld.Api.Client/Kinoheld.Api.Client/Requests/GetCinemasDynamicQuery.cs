using System;

namespace Kinoheld.Api.Client.Requests
{
    [Flags]
    public enum GetCinemasDynamicQuery
    {
        Full = 0,
        Id = 1,
        Name = 2,
        Street = 4,
        City = 8,
        Distance = 16,
        DetailUrl = 32
    }
}
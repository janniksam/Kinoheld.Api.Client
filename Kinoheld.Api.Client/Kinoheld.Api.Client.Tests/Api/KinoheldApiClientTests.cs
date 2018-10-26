using System;
using System.Threading;
using Kinoheld.Api.Client.Api;
using Kinoheld.Api.Client.Requests;
using NUnit.Framework;

namespace Kinoheld.Api.Client.Tests.Api
{
    [TestFixture(Category = "L2")]
    public class KinoheldApiClientTests
    {
        [Test]
        public void GetCinemas_ThrowsWhenCityNotFilled()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCinemas(null, null, 15, 5, GetCinemasDynamicQuery.Full, CancellationToken.None);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCinemas(string.Empty, null, 15, 5, GetCinemasDynamicQuery.Full, CancellationToken.None);
            });
        }

        [Test]
        public void GetCinemas_ThrowsWhenDistanceSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, -1, 5, GetCinemasDynamicQuery.Full, CancellationToken.None);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, 0, 5, GetCinemasDynamicQuery.Full, CancellationToken.None);
            });
        }

        [Test]
        public void GetCinemas_ThrowsWhenLimitSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, 1, 0, GetCinemasDynamicQuery.Full, CancellationToken.None);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, 1, -1, GetCinemasDynamicQuery.Full, CancellationToken.None);
            });
        }

        [Test]
        public void GetCities_ThrowsWhenSearchTermNotFilled()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCities(null, 1, CancellationToken.None);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCities(string.Empty, 1, CancellationToken.None);
            });
        }

        [Test]
        public void GetCities_ThrowsWhenLimitSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCities("aurich", -1, CancellationToken.None);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCities("aurich", 0, CancellationToken.None);
            });
        }

        [Test]
        public void GetCinemas_ThrowsWhenIdSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetShows(0, null, GetShowsDynamicQuery.Full, CancellationToken.None);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetShows(-1, null, GetShowsDynamicQuery.Full, CancellationToken.None);
            });
        }
    }
}
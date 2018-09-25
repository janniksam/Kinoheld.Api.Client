using System;
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
                var o = await client.GetCinemas(null, null, 15, GetCinemasDynamicQuery.Full);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCinemas(string.Empty, null, 15, GetCinemasDynamicQuery.Full);
            });
        }

        [Test]
        public void GetCinemas_ThrowsWhenDistanceSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, -1, GetCinemasDynamicQuery.Full);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, 0, GetCinemasDynamicQuery.Full);
            });
        }

        [Test]
        public void GetCities_ThrowsWhenSearchTermNotFilled()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCities(null, 1);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCities(string.Empty, 1);
            });
        }

        [Test]
        public void GetCities_ThrowsWhenLimitSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCities("aurich", -1);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCities("aurich", 0);
            });
        }
        
        [Test]
        public void GetCinemas_ThrowsWhenIdSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetShows(0, null, GetShowsDynamicQuery.Full);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetShows(-1, null, GetShowsDynamicQuery.Full);
            });
        }
    }
}
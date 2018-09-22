using System;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Api;
using NUnit.Framework;

namespace Kinoheld.Api.Client.Tests.Api
{
    [TestFixture(Category = "L2")]
    public class KinoheldApiClientIntegrationTests
    {
        [Test]
        public async Task GetCinemas_ReturnsSomeCinemas()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cinemas = await client.GetCinemas("aurich", string.Empty, 15);
            Assert.IsNotNull(cinemas);
        }

        [Test]
        public void GetCinemas_ThrowsWhenCityNotFilled()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCinemas(null, null, 15);
            });
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var o = await client.GetCinemas(string.Empty, null, 15);
            });
        }

        [Test]
        public void GetCinemas_ThrowsWhenDistanceSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, -1);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, 0);
            });
        }

        [Test]
        public async Task GetShows_ReturnsSomeShowsWhenDateIsSet()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cinemas = await client.GetShows(2127, DateTime.Today);
            Assert.IsNotNull(cinemas);
        }


        [Test]
        public async Task GetShows_ReturnsSomeShowsWhenDateIsNotSet()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cinemas = await client.GetShows(2127, null);
            Assert.IsNotNull(cinemas);
        }

        [Test]
        public void GetCinemas_ThrowsWhenIdSmallerOrEqual0()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetShows(0, null);
            });
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                var o = await client.GetShows(-1, null);
            });
        }
    }
}
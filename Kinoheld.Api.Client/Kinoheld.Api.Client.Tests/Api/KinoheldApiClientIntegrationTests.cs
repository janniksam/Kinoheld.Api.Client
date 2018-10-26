using System;
using System.Threading;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Api;
using Kinoheld.Api.Client.Requests;
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
            var cinemas = await client.GetCinemas("aurich", string.Empty, 15, 5, GetCinemasDynamicQuery.Full, CancellationToken.None);
            Assert.IsNotNull(cinemas);
        }

        [Test]
        public async Task GetCities_ReturnsSomeCitiesWithPostalCode()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cities = await client.GetCities("266", 10, CancellationToken.None);
            Assert.IsNotNull(cities);
        }

        [Test]
        public async Task GetCities_ReturnsSomeCitiesWithTerm()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cities = await client.GetCities("aur", 10, CancellationToken.None);
            Assert.IsNotNull(cities);
        }

        [Test]
        public async Task GetShows_ReturnsSomeShowsWhenDateIsSet()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var shows = await client.GetShows(2127, DateTime.Today, GetShowsDynamicQuery.Full, CancellationToken.None);
            Assert.IsNotNull(shows);
        }


        [Test]
        public async Task GetShows_ReturnsSomeShowsWhenDateIsNotSet()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cinemas = await client.GetShows(2127, null, GetShowsDynamicQuery.Full, CancellationToken.None);
            Assert.IsNotNull(cinemas);
        }

        [Test]
        public void GetShows_ThrowsOnCancel()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                var o = await client.GetShows(1, null, GetShowsDynamicQuery.Full, cts.Token);
            });
        }

        [Test]
        public void GetCities_ThrowsOnCancel()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                var o = await client.GetCities("aurich", 10, cts.Token);
            });
        }

        [Test]
        public void GetCinemas_ThrowsOnCancel()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            IKinoheldApiClient client = new KinoheldApiClient();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                var o = await client.GetCinemas("aurich", null, 10, 5, GetCinemasDynamicQuery.Full, cts.Token);
            });
        }
    }
}
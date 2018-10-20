using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Requests;
using NUnit.Framework;

namespace Kinoheld.Api.Client.Tests
{
    [TestFixture(Category = "L2")]
    public class KinoheldClientIntegrationTests
    {
        [Test]
        public async Task GetCinemas_ReturnsSomeCinemasInAurich()
        {
            IKinoheldClient client = new KinoheldClient();
            var cinemas = await client.GetCinemas("aurich");
            Assert.AreNotEqual(0, cinemas.Count());
            Assert.True(cinemas.Any(p => p.Name == "Kino Aurich"), "Could not find Kino Aurich in the response list.");
        }

        [Test]
        public async Task GetCinemas_ReturnsSomeCinemasInAurichUsingADynmamicIdNameQuery()
        {
            IKinoheldClient client = new KinoheldClient();
            var dynamicQuery = GetCinemasDynamicQuery.Id | GetCinemasDynamicQuery.Name;
            var cinemas = await client.GetCinemas("aurich", dynamicQuery: dynamicQuery);

            Assert.AreNotEqual(0, cinemas.Count());
            Assert.True(cinemas.Any(p => p.Name == "Kino Aurich"), "Could not find Kino Aurich in the response list.");
            Assert.True(cinemas.All(p => p.City == null && string.IsNullOrEmpty(p.Street)), "The dynamic id / name query gives too much info");
            Assert.True(!cinemas.Any(p => string.IsNullOrEmpty(p.Name) || p.Id <= 0) , "The dynamic id / name query gives too less info");
        }

        [Test]
        public async Task GetCinemas_ReturnsAutokinoAurichWhenSearchtermIsAutokino()
        {
            IKinoheldClient client = new KinoheldClient();
            var cinemas = await client.GetCinemas("aurich", "autokino");
            Assert.AreNotEqual(0, cinemas.Count());
            Assert.True(cinemas.Any(p => p.Name == "Autokino Aurich-Tannenhausen"), "Could not find Autokino Aurich-Tannenhausen in the response list.");
        }

        [Test]
        public async Task GetCinemas_ReturnsNoCinemasWhenNothingHasBeenFound()
        {
            IKinoheldClient client = new KinoheldClient();
            var cinemas = await client.GetCinemas("DummyNotValid");
            Assert.AreEqual(0, cinemas.Count());
        }

        [Test]
        public async Task GetShows_ReturnsSomeShows()
        {
            IKinoheldClient client = new KinoheldClient();
            var shows = await client.GetShows(2127);           
            Assert.AreNotEqual(0, shows.Count());
        }

        [Test]
        public async Task GetShows_ReturnsSomeShowsOtherDateThanToday()
        {
            var tommorow = DateTime.Now.AddDays(1).Date;

            IKinoheldClient client = new KinoheldClient();
            var shows = await client.GetShows(2127, tommorow);
            Assert.AreNotEqual(0, shows.Count());
            Assert.True(shows.All(p => p.Beginning.GetDateTime().Date == tommorow));
        }

        [Test]
        public async Task GetShows_ReturnsSomeShowsUsingADynamicNameQuery()
        {
            IKinoheldClient client = new KinoheldClient();
            var dynamicQuery = GetShowsDynamicQuery.Name;
            var shows = await client.GetShows(2127, dynamicQuery: dynamicQuery);
            Assert.AreNotEqual(0, shows.Count());
            Assert.True(shows.All(p => p.Flags == null && p.Beginning == null && p.DetailUrl == null && p.MovieInfo == null), "The dynamic name query gives too much info");
            Assert.True(!shows.Any(p => string.IsNullOrEmpty(p.Name)), "The dynamic name query gives too less info");
        }

        [Test]
        public async Task GetShows_ReturnsNoShowsWhenNothingHasBeenFound()
        {
            IKinoheldClient client = new KinoheldClient();
            var shows = await client.GetShows(999999);
            Assert.AreEqual(0, shows.Count());
        }

        [Test]
        public async Task GetCities_ReturnsNoCitiesWhenNothingHasBeenFound()
        {
            IKinoheldClient client = new KinoheldClient();
            var cities = await client.GetCities("999999");
            Assert.AreEqual(0, cities.Cities.Count);
            Assert.AreEqual(0, cities.PostalCodes.Count);
        }

        [Test]
        public async Task GetCities_ReturnsAurichWith26603()
        {
            IKinoheldClient client = new KinoheldClient();
            var cities = await client.GetCities("26603");
            Assert.AreEqual(0, cities.Cities.Count);
            Assert.AreEqual(1, cities.PostalCodes.Count);
            Assert.AreEqual("Aurich", cities.PostalCodes[0].City.Name);
            Assert.AreEqual(26603, cities.PostalCodes[0].Code);
        }

        [Test]
        public async Task GetCities_ReturnsAurichWithAuric()
        {
            IKinoheldClient client = new KinoheldClient();
            var cities = await client.GetCities("auric");
            Assert.AreEqual(1, cities.Cities.Count);
            Assert.AreEqual(0, cities.PostalCodes.Count);
            Assert.AreEqual("Aurich", cities.Cities[0].Name);
        }

        [Test]
        public void GetShows_ThrowsOnCancel()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            IKinoheldClient client = new KinoheldClient();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                var o = await client.GetShows(1, cancellationToken: cts.Token);
            });
        }

        [Test]
        public void GetCities_ThrowsOnCancel()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            IKinoheldClient client = new KinoheldClient();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                var o = await client.GetCities("aurich", cancellationToken: cts.Token);
            });
        }

        [Test]
        public void GetCinemas_ThrowsOnCancel()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();

            IKinoheldClient client = new KinoheldClient();
            Assert.ThrowsAsync<TaskCanceledException>(async () =>
            {
                var o = await client.GetCinemas("aurich", cancellationToken: cts.Token);
            });
        }
    }
}
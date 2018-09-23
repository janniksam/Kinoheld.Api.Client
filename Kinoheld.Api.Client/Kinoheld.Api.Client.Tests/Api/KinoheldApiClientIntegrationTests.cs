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
        public async Task GetCinemas_ReturnsSomeCitiesWithPostalCode()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cities = await client.GetCities("266", 10);
            Assert.IsNotNull(cities);
        }

        [Test]
        public async Task GetCinemas_ReturnsSomeCitiesWithTerm()
        {
            IKinoheldApiClient client = new KinoheldApiClient();
            var cities = await client.GetCities("aur", 10);
            Assert.IsNotNull(cities);
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
    }
}
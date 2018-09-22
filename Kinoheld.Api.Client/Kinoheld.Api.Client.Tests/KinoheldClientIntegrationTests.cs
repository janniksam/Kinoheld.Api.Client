using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Kinoheld.Api.Client.Tests
{
    [TestFixture(Category = "L2")]
    public class KinoheldClientIntegrationTests
    {
        [Test]
        public async Task GetCinemas_ReturnsSomeCinemas()
        {
            IKinoheldClient client = new KinoheldClient();
            var cinemas = await client.GetCinemas("aurich");
            Assert.AreNotEqual(0, cinemas.Count());
            Assert.True(cinemas.Any(p => p.Name == "Kino Aurich"), "Could not find Kino Aurich in the response list.");
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
        public async Task GetShows_ReturnsNoShowsWhenNothingHasBeenFound()
        {
            IKinoheldClient client = new KinoheldClient();
            var shows = await client.GetShows(999999);
            Assert.AreEqual(0, shows.Count());
        }
    }
}
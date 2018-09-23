using System;
using System.Linq;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Api;
using Kinoheld.Api.Client.Json;
using Moq;
using NUnit.Framework;

namespace Kinoheld.Api.Client.Tests
{
    [TestFixture(Category = "L0")]
    public class KinoheldClientTests
    {
        private Mock<IKinoheldApiClient> m_kinoheldApiClientMock;
        private Mock<IKinoheldJsonWorker> m_kinoheldJsonWorkerMock;

        [SetUp]
        public void SetUp()
        {
            m_kinoheldApiClientMock = new Mock<IKinoheldApiClient>();
            m_kinoheldJsonWorkerMock = new Mock<IKinoheldJsonWorker>();
        }

        [Test]
        public void KinoheldClient_DoesNotAllowNullApiClient()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    IKinoheldClient client = new KinoheldClient(null, new KinoheldJsonWorker());
                });
        }

        [Test]
        public void KinoheldClient_DoesNotAllowNullJsonWorker()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    IKinoheldClient client = new KinoheldClient(new KinoheldApiClient(), null);
                });
        }

        [Test]
        public async Task GetCinemas_ReturnEmptyListWhenNoCinemasWereFound()
        {
            IKinoheldClient client = new KinoheldClient(m_kinoheldApiClientMock.Object, m_kinoheldJsonWorkerMock.Object);
            var cinemas = await client.GetCinemas("aurich");
            Assert.NotNull(cinemas);
            Assert.AreEqual(0, cinemas.Count());
        }

        [Test]
        public async Task GetCities_ReturnEmptyResultWhenNoCitiesWereFound()
        {
            IKinoheldClient client = new KinoheldClient(m_kinoheldApiClientMock.Object, m_kinoheldJsonWorkerMock.Object);
            var result= await client.GetCities("aurick");
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Cities.Count);
            Assert.AreEqual(0, result.PostalCodes.Count);
        }

        [Test]
        public async Task GetShows_ReturnEmptyListWhenNoShowsWereFound()
        {
            IKinoheldClient client = new KinoheldClient(m_kinoheldApiClientMock.Object, m_kinoheldJsonWorkerMock.Object);
            var shows = await client.GetShows(1);
            Assert.NotNull(shows);
            Assert.AreEqual(0, shows.Count());
        }
    }
}
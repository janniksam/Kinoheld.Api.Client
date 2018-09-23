using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Kinoheld.Api.Client.Model;

[assembly: InternalsVisibleTo("Kinoheld.Api.Client.Tests")]
namespace Kinoheld.Api.Client
{
    public interface IKinoheldClient
    {
        /// <summary>
        /// Get the cinemas matching the given criteria
        /// </summary>
        /// <param name="city">A city in which the cinema is located</param>
        /// <param name="searchTerm">A searchterm (e.g. Autokino)</param>
        /// <param name="distance">Maximum distance in kilometers to search the cinema in</param>
        /// <returns>List of all matching cinemas</returns>
        Task<IEnumerable<Cinema>> GetCinemas(string city, string searchTerm = "", int distance = 15);

        /// <summary>
        /// Get the cinemas matching the given criteria
        /// </summary>
        /// <param name="cinemaId">The Id of the cinema</param>
        /// <param name="date">The date on which the shows should run</param>
        /// <returns>List of all matching cinemas</returns>
        Task<IEnumerable<Show>> GetShows(int cinemaId, DateTime? date = null);

        /// <summary>
        /// Searches for a city
        /// </summary>
        /// <param name="searchTerm">Search Term (e.g. postal code)</param>
        /// <param name="limit">Maximum number of results</param>
        /// <returns></returns>
        Task<CitySearchResult> GetCities(string searchTerm, int limit = 10);
    }
}
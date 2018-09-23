using System;
using System.Collections.Generic;
using Kinoheld.Api.Client.Model;
using Newtonsoft.Json.Linq;

namespace Kinoheld.Api.Client.Json
{
    internal class KinoheldJsonWorker : IKinoheldJsonWorker
    {
        public IEnumerable<Cinema> ConvertToCinemas(JObject jsonResult)
        {
            if (jsonResult == null)
            {
                throw new ArgumentNullException(nameof(jsonResult));
            }

            var selectToken = jsonResult.SelectToken("cinemas");
            if (selectToken == null)
            {
                throw new InvalidCastException($"The given {nameof(jsonResult)} contains a format, that cannot be recognised.");
            }

            var cinemas = selectToken.ToObject<List<Cinema>>();
            return cinemas;
        }

        public IEnumerable<Show> ConvertToShows(JObject jsonResult)
        {
            if (jsonResult == null)
            {
                throw new ArgumentNullException(nameof(jsonResult));
            }

            var selectToken = jsonResult.SelectToken("shows");
            if (selectToken == null)
            {
                throw new InvalidCastException($"The given {nameof(jsonResult)} contains a format, that cannot be recognised.");
            }

            var shows = selectToken.ToObject<List<Show>>();
            return shows;
        }

        public CitySearchResult ConvertToCitySearchResult(JObject jsonResult)
        {
            if (jsonResult == null)
            {
                throw new ArgumentNullException(nameof(jsonResult));
            }
            var cities = jsonResult.SelectToken("cities");
            if (cities == null)
            {
                throw new InvalidCastException($"The given {nameof(jsonResult)} contains a format, that cannot be recognised.");
            }

            var postcodes = jsonResult.SelectToken("postcodes");
            if (postcodes == null)
            {
                throw new InvalidCastException($"The given {nameof(jsonResult)} contains a format, that cannot be recognised.");
            }

            var result = jsonResult.ToObject<CitySearchResult>();
            return result;
        }
    }
}
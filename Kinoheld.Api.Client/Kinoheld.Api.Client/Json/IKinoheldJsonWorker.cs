using System.Collections.Generic;
using Kinoheld.Api.Client.Model;
using Newtonsoft.Json.Linq;

namespace Kinoheld.Api.Client.Json
{
    public interface IKinoheldJsonWorker
    {
        IEnumerable<Cinema> ConvertToCinemas(JObject jsonResult);

        IEnumerable<Show> ConvertToShows(JObject jsonResult);
    }
}
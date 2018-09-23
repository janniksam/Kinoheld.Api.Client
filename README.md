# Kinoheld API Client

[![Build status master](https://ci.appveyor.com/api/projects/status/b982ewnsagvbyd5i?svg=true&passingText=master%20-%20passing&failingText=master%20-%20failing&pendingText=master%20-%20pending)](https://ci.appveyor.com/project/janniksam/kinoheld) 
[![Build status dev](https://ci.appveyor.com/api/projects/status/b982ewnsagvbyd5i/branch/dev?svg=true&passingText=dev%20-%20passing&failingText=dev%20-%20failing&pendingText=dev%20-%20pending)](https://ci.appveyor.com/project/janniksam/kinoheld/branch/dev)

## Description

Kinoheld API Client is a client for the GraphQL-API, which is provided by the kinoheld.de.
It currently supports
- Searching a cinema by giving a city, a search term and a maximum distance between the city and the cinema.
- Retrieving information for movies that are currently played / will be played at the given cinema.
- Searching for city by giving a searchterm (e.g. a postal code)

## Basis usage:
 
### Search for a cinema

    // Get all cinemas that are near the city "Aurich"
    IKinoheldClient client = new KinoheldClient();
    var cinemas = await client.GetCinemas("aurich");
    
    // Search for cinemas near Aurich that contain the term 'autokino'
    IKinoheldClient client = new KinoheldClient();
    var cinemas = await client.GetCinemas("aurich", "autokino");

### Retrieve information about upcoming movies

    // Retrieve all movies, that will be played tommorow
    IKinoheldClient client = new KinoheldClient();
    var upcoming = await client.GetShows(cinema.Id, DateTime.Today.AddDays(1));
    

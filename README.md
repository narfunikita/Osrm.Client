Osrm.Client
==========
A Http client for OSRM for 4x and 5x API

Created by narfunikita https://github.com/narfunikita/<br />
Updated by JadYammine https://github.com/JadYammine/ on the 12 November 2019<br />

## Example for API 5x

#Imports:
using Osrm.Client.v5;<br />
using Osrm.Client.Models;<br />

#### Route
```csharp
var osrm = new Osrm5x("http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.503033, 13.420526),
    new Location(52.516582, 13.429290),
};

var result = osrm.Route(locations);

var result2 = osrm.Route(new RouteRequest()
{
    Coordinates = locations,
    Steps = true
});
var result3 = osrm.Route(new RouteRequest()
{
    Coordinates = locations,
    SendCoordinatesAsPolyline = true
});
```

#### Table
```csharp
var osrm = new Osrm5x("http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.517037, 13.388860),
    new Location(52.529407, 13.397634),
    new Location(52.523219, 13.428555)
};

//Returns a 3x3 matrix:
var result = osrm.Table(locations);

//Returns a 1x3 matrix:
var result2 = osrm.Table(new Osrm.Client.Models.Requests.TableRequest()
{
    Coordinates = locations,
    Sources = new uint[] { 0 }
    //Sources = src,
    //DestinationLocations = dst
});

//Returns a asymmetric 3x2 matrix with from the polyline encoded locations qikdcB}~dpXkkHz:
var result3 = osrm.Table(new Osrm.Client.Models.Requests.TableRequest()
{
    Coordinates = locations,
    SendCoordinatesAsPolyline = true,
    Sources = new uint[] { 0, 1, 3 },
    Destinations = new uint[] { 2, 4 }
    //Sources = src,
    //DestinationLocations = dst
});
```

#### Match
```csharp
var osrm = new Osrm5x("http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.517037, 13.388860),
    new Location(52.529407, 13.397634),
    new Location(52.523219, 13.428555)
};

var request = new Osrm.Client.Models.Requests.MatchRequest()
{
    Coordinates = locations
};

var result = osrm.Match(request);
```

#### Nearest
```csharp
var osrm = new Osrm5x("http://router.project-osrm.org/");
var result = osrm.Nearest(new Location(52.4224, 13.333086));
```

#### Trip
```csharp
var osrm = new Osrm5x("http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.503033, 13.420526),
    new Location(52.516582, 13.429290),
};

var result = osrm.Trip(locations);
```


## Example for API 4x
## Please remove all comments to allow test runs of 4x. (only tests are commented since http://router.project-osrm.org/ no longer supports 4x)
#Imports
using Osrm.Client;
using Osrm.Client.Models;
#### Route
```csharp
var osrm = new OsrmClient("http://router.project-osrm.org/");
var positions = new Location[] {
                new Location(52.503033, 13.420526),
                new Location(52.516582, 13.429290),
            };

var result = osrm.Route(positions);

var result2 = osrm.Route(new ViarouteRequest()
{
    Locations = positions,
    Instructions = true,
    Zoom = 5
});
```

#### Table
```csharp
var osrm = new OsrmClient("http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.554070, 13.160621),
    new Location(52.431272, 13.720654),
    new Location(52.554070, 13.720654),
    new Location(52.554070, 13.160621),
};

var result = osrm.Table(locations);

var src = new Location[] {
    new Location(52.554070, 13.160621),
};

var dst = new Location[] {
    new Location(52.431272, 13.720654),
    new Location(52.554070, 13.720654),
    new Location(52.554070, 13.160621),
};

var result2 = osrm.Table(new TableRequest()
{
    SourceLocations = src,
    DestinationLocations = dst
});
```

#### Match
```csharp
var osrm = new OsrmClient("http://router.project-osrm.org/");
var locations = new LocationWithTimestamp[] {
    new LocationWithTimestamp(52.542648, 13.393252, 1424684612),
    new LocationWithTimestamp(52.543079, 13.394780, 1424684616),
    new LocationWithTimestamp(52.542107, 13.397389, 1424684620)
};

var request = new MatchRequest()
{
    Locations = locations,
    Instructions = true,
    Classify = true
};

var result = osrm.Match(request);
```

#### Nearest
```csharp
var osrm = new OsrmClient("http://router.project-osrm.org/");
var result = osrm.Nearest(new Location(52.4224, 13.333086));
```

#### Trip
```csharp
var osrm = new OsrmClient("http://router.project-osrm.org/");
var locations = new Location[] {
    new Location(52.503033, 13.420526),
    new Location(52.516582, 13.429290),
};

var result = osrm.Trip(locations);
```


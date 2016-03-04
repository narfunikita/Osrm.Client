Osrm.Client
==========
A Http client for OSRM

### Example
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


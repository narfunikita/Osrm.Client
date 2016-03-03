Osrm.Client
==========
A Http client for OSRM

### Example

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

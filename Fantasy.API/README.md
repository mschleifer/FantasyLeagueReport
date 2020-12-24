# Fantasy.API
Azure functions (nodejs) project that wraps the espn-fantasy-football-api package.

We cannot use the api package directly from our Blazor app because accessing a private league requires some headers
to be sent with the api request and those headers cannot be appended in the browser (we also don't want to expose our
private cookie info via Blazor).
Thus the Blazor app calls these azure functions/api endpoints which then append the headers and call the espn api.

The required cookie values are put in local.settings.json (for local dev) and in an Azure app setting for prod.
This prevents any cookie information from being exposed in the git repo or in the distributed Blazor code.
The only thing exposed to the Blazor app is the result ofthe api call.

Unfortunately, we'll need to add a new function for each espn api endpoint we want to hit, but we can implement them
as we need them (instead of all up front).
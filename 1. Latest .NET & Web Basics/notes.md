# 1. .NET 5 & Web Basics
+ What is .NET 5+ ?
  + Rewrite of the .NET framework
  + Open source & community oriented
  + Cross-platform
  + CLI first
  + .NET 5 is .NET Core vNext
  + .NET 5 is NOT the next version of 4.x
  + Unification of all the platforms (Xamarin/Web/Desktop/IoT)
  + Support for native capabilities (lossing cross-platform support)
  + New major version every year, LTS every other year
+ Why choose .NET 5
  + Cross-platform (Windows/Mac/Linux)
  + First class microservices support (Docker/Kubernetes)
  + High-performance and scalability
  + Side-by-side .NET versions per app
  + Supports most platforms (WinForms/WPF/Web/Mobile)
  + New C# versions (not available on 4.x)
  + Because Microsoft says so (no more updates for 4.X)
+ What is ASP .NET Core?
  + Web Framework on top of .NET 5
  + A rewrite of ASP .NET
  + Used to build API/MVC/Razor Pages/Blazor apps
+ Web Basics
  + What is a web app (client - server)
  + Browser limitations
  + Different UX
  + Http Request Methods
    + Show all methods https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
    + Explain GET (No body, browser address bar, query string)
    + Explain POST
  + Http Status Codes
    + Show all codes https://www.restapitutorial.com/httpstatuscodes.html
    + Explain common codes 200/404/500
  + Http Headers [https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers)
    + Authentication
    + Accept-language
    + Content-language
    + Security: https://securityheaders.com/
  + MIME types [https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types](https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types)
  + Json format
  + Apps must be efficient, do not display too many data, etc
+ Hands-on (code)
  + Show dotnet command line
  + Create an ASP .NET Core MVC app
  + Explain what does MVC stand for? (Model - View - Controller)
  + Explain Controllers and Actions
  + Explain MVC Conventions (controller names/folder locations)
  + Explain Views
  + Explain Shared/Layout
  + Explain html
  + Create a TodoItem model
  + Explain APIs (Create an API controller - Weather Forecasts)
  + Explain MVC Attributes (HttpGet/HttpPost/Authorize/Routing)
+ Recap/What's next
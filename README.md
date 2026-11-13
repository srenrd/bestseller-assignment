The solution contains 2 projects Products.Api and Products.Gateway.

Products.Api is a RESTful API that provides endpoints for managing products. It is built using ASP.NET Core and Minimal API.

Products.Gateway is a reverse proxy that routes requests to the Products.Api backend. It is built using ASP.NET Core, Minimal API and YARP. 
It also logs the time taken for each request, providing insights into the performance of the gateway and API.
The solution contains 2 projects Products.Api and Products.Gateway.

Products.Api is a RESTful API that provides endpoints for managing products. It is built using ASP.NET Core and Minimal API.

Products.Gateway is a reverse proxy that routes requests to the Products.Api backend. It is built using ASP.NET Core, Minimal API and YARP. 
It also logs the time taken for each request, providing insights into the performance of the gateway and API.


A lot of improvements can be made to the solution like:
Implementing authentication and authorization. server-server between the gateway and the API, and user authentication for the Gateway.
Adding Swagger/OpenAPI documentation for the API endpoints.
Switch Entity Framework to something like Dapper for better performance. If performance is weighted higher then development time.
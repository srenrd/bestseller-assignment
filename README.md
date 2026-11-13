A .NET solution for a product catalog, made up of two projects:

## Projects

### `Products.Api`
A RESTful API built with ASP.NET Core Minimal APIs. It provides endpoints to list, retrieve, and create products.

### `Products.Gateway`
An ASP.NET Core reverse proxy built with YARP. It routes requests to `Products.Api` and logs the duration of each request.

## Potential Improvements

- Add authentication and authorization, including secure communication between the gateway and API and user authentication at the gateway.
- Add Swagger/OpenAPI documentation for the API endpoints.
- Evaluate Dapper as an alternative to Entity Framework if performance becomes more important than development speed.
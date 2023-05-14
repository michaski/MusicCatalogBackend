# Music Catalog
Quick prototype of a part of a music distribution application. 
## About
The purpose of this application is to store music albums metadata with their track lists. Music albums come from different providers. Each provider has access only to their albums. Newly registered accounts require administrator activation. 

This app was implemented using CQRS pattern with Mediator. It provides an REST API that can be used by clients to interact with the server using HTTP requests.
## Tools and technologies
This app was created using:
- .NET 7
- ASP.NET Core
- EntityFrameworkCore
- MediatR
- PostgreSQL
- AutoMapper
- NLog
- FluentValidation
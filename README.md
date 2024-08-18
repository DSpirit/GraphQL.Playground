# Playground Project

## Overview

The Playground project is a .NET 8.0 application that demonstrates the use of Entity Framework Core with both MongoDB and SQLite databases. It also integrates GraphQL to handle EFCore entities and provides a RESTful API for managing movies and their ratings.

## Features

- **Entity Framework Core**: Uses EF Core to interact with MongoDB and SQLite databases.
- **GraphQL**: Provides a GraphQL server to handle queries and mutations for movies and ratings.
- **RESTful API**: Exposes endpoints to manage movies and their ratings.
- **Swagger**: Integrated Swagger for API documentation and testing.

## Prerequisites

- .NET 8.0 SDK
- MongoDB
- SQLite

## Configuration

Update the appsettings.json file with your MongoDB and SQLite connection strings.

``` json
{
  "ConnectionStrings": {
    "MongoDB": "your_mongodb_connection_string",
    "Sqlite": "Data Source=cinema.db"
  }
}
```

## Project Structure

### CinemaDbContext (SQL)

Database Provider: Uses SQLite.
Configuration: Configured using UseSqlite method.
Entity Configuration: Uses ToTable method to map entities to SQL tables.
Relationships: Configures relationships using HasMany and WithOne methods.
Navigation Properties: Configures navigation properties using UsePropertyAccessMode.

### MovieDbContext (MongoDB)

Database Provider: Uses MongoDB.
Configuration: Configured using UseMongoDB method.
Entity Configuration: Uses ToCollection method to map entities to MongoDB collections.
Relationships: Configures relationships using HasMany and WithOne methods.
Navigation Properties: Configures navigation properties using UsePropertyAccessMode.

### Project

- Controllers: Contains the API controllers for managing movies and ratings.
- Entities: Defines the database entities and DbContext classes.
- Interfaces: Contains the repository interfaces.
- Repositories: Implements the repository interfaces.
- Schemas: Defines the GraphQL schema and queries.
- Models: Contains additional models used in the application.

## Acknowledgements

- [GraphQL](https://graphql.org/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [MongoDB](https://www.mongodb.com/)
- [SQLite](https://www.sqlite.org/)
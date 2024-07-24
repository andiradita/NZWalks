# NZWalks
# Description
NZWalks is a practice project I followed in an online course, aimed at developing API skills using ASP.NET Web API. This project includes managing APIs for regions, difficulties, and walks.

# Features
- REST APIs using ASP.NET Core and C#
- Learn and apply Entity Framework Core to perform CRUD operations on a SQL Server database
- Apply the Repository Pattern in ASP.NET Core Web API
- .NET version 8
- Use Entity Framework Core in a code-first approach
- Use Domain Driven Design (DDD) approach to create domain-first models and project
- Implement JWT Token to authenticate API
- Add validations in ASP.NET Core Web API
- Understand and use interfaces, inheritance, dependency injection
- Test ASP.NET Core Web API using Swagger and Postman
- Use ASP.NET Core Identity in ASP.NET Core Web API to authenticate and add role-based authorization
- Learn filtering, sorting, and pagination in ASP.NET Core Web API

# Technologies
- ASP.NET Core 8
- C#
- Entity Framework Core 8
- SQL Server
- JWT Authentication
- Swagger
- Postman
- ASP.NET Core Identity

# Getting Started
### Prerequisites
- .Net 8 SDK
- SQL Server

### Installation
1. Clone the repository
2. Configure the database
   - Update the appsettings.json file with your SQL Server connection string.
   - Apply migrations to create the database schema
   - Run the application

# Usage
### API Endpoints
- Authentication
  - POST /api/auth/login: login to get bearer token
  - POST /api/auth/register: register user
- Regions
  - GET /api/regions: Get all regions
  - GET /api/regions/{id}: Get region by ID
  - POST /api/regions: Create a new region
  - PUT /api/regions/{id}: Update a region
  - DELETE /api/regions/{id}: Delete a region
- Walks
  - GET /api/walks: Get all walks
  - GET /api/walks/{id}: Get walk by ID
  - POST /api/walks: Create a new walk
  - PUT /api/walks/{id}: Update a walk
  - DELETE /api/walks/{id}: Delete a walk

# Project Structure 
- Models/
  - Domains/ : Contains domain objects
  - DTOs/ : Contains data transfer objects
- Controllers/ : Contains API Controller
- Repositories/ : Contains repository interfaces and implementations
- Data/ : Contains data contexts
- Images/ : Contains local images
- Mappings/ : Contains AutoMapper configurations

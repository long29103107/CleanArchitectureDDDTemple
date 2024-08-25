# Clean Architecture
 
A project using Clean Architecture and Domain-Driven Design

## Setup database configuration

![Sample image](https://github.com/long29103107/CleanArchitectureDDDTemple/blob/master/images/screenshot_1724580857.png)

-  Right click `Package.Shared.Database` set as Startup Project
-  Open `Pakage Manager Console`, select `Package.Shared.Database`
-  Run migration command.
	
## Using libraries
- Entity Framework
- Exception Handler
- MediatR
- AutoMapper
- Serilog
- FluentValidation
- Api Versioning
- Minimal Api (Carter)
- Shared Settings
- Swagger
- Autofac

## Using design pattern
- Repository
- Option
- Unit of work
- Factory

## Migrations

|  Service  |  Method   |      Migration command                                                      |
|-----------|-----------|-----------------------------------------------------------------------------|
|  Product  |  Add      | Add-migration Init -Context ProductDbContext -o Product/Migrations          | 
|  Product  |  Update   | Update-database -Context ProductDbContext                                   | 
|  Product  |  Script   | Script-Migration -Context ProductDbContext                                  | 

## Folder tree
    src
    |
    ├── BuildingBlocks
    |   ├── Contracts  
    |   |   ├── Abstractions   
    |   |   |   ├── Common (IRepositoryBase, IUnitOfWork)
    |   |   |   ├── Message (Command, Query, DomainEvent)
    |   |   |   └── Shared (Result, Error)
    │   |   └── Domain (Implement Contracts\Abstractions)
    |   |      ├── Abstractions (Interface base entity, audit tracking)
    |   |      └── Exceptions
    |   ├── Infrastructures  
    |   |   ├── Common (RepositoryBase, UnitOfWork)
    │   |   └── BaseHandlers (Implement abstract Query, Command, Event handler)
    |   └── Shared  
    |       ├── APIs (Base endpoint)
    |       ├── Dtos
    │       └── Services (shared command, query)
    ├── packages                   
    │   ├── Database            
    │   └── ExceptionHandler    
    ├── services                   
    │   └── Product            
    │       ├── Api 
    |       |   ├── Program.cs
    |       |   └── DependencyInjection 
    │       ├── Application 
    |       |   ├── AutofacModule
    |       |   ├── Behaviors
    |       |   ├── MappingProfiles
    |       |   ├── UserCases
    |       |   └── DependencyInjection 
    │       ├── Domain 
    |       |   ├── Events
    |       |   └── Exceptions
    │       ├── Infrastructure 
    |       |   └── DependencyInjection 
    │       ├── Persistence 
    |       |   ├── Configurations
    |       |   ├── Interceptors
    |       |   ├── Repositories
    |       |   ├── ProductDbContext.cs
    |       |   └── DependencyInjection 
    │       └── Presentation  
    |           ├── APIs
    |           └── DependencyInjection 
    └── shared
        └── Settings  

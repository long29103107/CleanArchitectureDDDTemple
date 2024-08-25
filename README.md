# Clean Architecture


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

## Using pattern
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

## Project tree

     .
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
    |   └── Shared  
    ├── packages                   
    │   ├── Database            
    │   └── ExceptionHandler    
    ├── services                   
    │   └── Product            
    │       ├── Api 
    │       ├── Application 
    │       ├── Domain 
    │       ├── Infrastructure 
    │       ├── Persistence 
    │       └── Presentation  
    └── shared
        └── Settings  
## Setup database configuration

![Sample image](https://github.com/long29103107/CleanArchitectureDDDTemple/blob/master/images/screenshot_1724580857.png)

-  Right click `Package.Shared.Database` set as Startup Project
-  Open `Pakage Manager Console`, select `Package.Shared.Database`
-  Run migration command.

## Migrations

|  Service  |  Method   |      Migration command                                                      |
|-----------|-----------|-----------------------------------------------------------------------------|
|  Product  |  Add      | Add-migration Init -Context ProductDbContext -o Product/Migrations          | 
|  Product  |  Update   | Update-database -Context ProductDbContext                                   | 
|  Product  |  Script   | Script-Migration -Context ProductDbContext                                  | 
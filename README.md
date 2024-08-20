## Migrations

|  Service  |  Method   |      Migration command                                                      |
|-----------|-----------|-----------------------------------------------------------------------------|
|  Product  |  Add      | Add-migration Init -Context ProductDbContext -o Product/Migrations          | 
|  Product  |  Update   | Update-database -Context ProductDbContext                                   | 
|  Product  |  Script   | Script-Migration -Context ProductDbContext                                  | 
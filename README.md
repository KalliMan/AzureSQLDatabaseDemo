# Contains several projects for demonstration purposes including Azure.

## AzureSQLDatabaseDemo
[https://wapp-az-sql-demo-bkdzc0buave8bsan.westeurope-01.azurewebsites.net/](https://az-sql-db-demo-new-hrb5gth7babmbba0.spaincentral-01.azurewebsites.net/)

A simple ASP.NET Web App Application with razor Pages. The main goal is to demonstrate:
* Complete CI process. It includes:
  - Changes on local using local SQL Server.
  - Automated Unit Test.
  - Project&Branch on GitHub  (https://github.com/KalliMan/CloudDemo)..
  - A custom action on GitHub that runs the unit tests as rules check before submition.
  - A custom action on GitHub that deploy the build from the master branch to Azure web app.
* Azure web-app.
* Azure SQL Database
* Entity Framework.
  - Add Migration:
    ```
    dotnet ef migrations add Initial --project AzureSQLDatabaseDemo.DAL --startup-project AzureSQLDatabaseDemo
    ```
  - Update Database:
    ```
    dotnet ef database update --project AzureSQLDatabaseDemo.DAL --startup-project AzureSQLDatabaseDemo
    ```
  - Remove last migration
    ```
    dotnet ef migrations remove --project AzureSQLDatabaseDemo.DAL --startup-project AzureSQLDatabaseDemo
    ```
* Repository and Unit of Work Patterns.
* Automated Unit Tests that to test REST API methods.

#### Note: The CRUD pages are generated using aspnet-codegenerator tool.

    dotnet aspnet-codegenerator razorpage -m AzureSQLDatabaseDemo.DAL.Models.Order -dc AzureSQLDatabaseDemo.DAL.Context.AppDbContext -udl -outDir Pages/Orders --referenceScriptLibraries

# Book Catalog Backend

The backend of the Book Catalog application is built with ASP.NET Core Web API, providing a robust platform for managing book and category data. This document outlines the prerequisites and steps required to get the backend up and running.

## Prerequisites

Before you begin, ensure you have the following installed and configured on your development machine:

- **.NET Core SDK**: Version 3.1 or later. [Download here](https://dotnet.microsoft.com/download)
- **Visual Studio 2019** or **Visual Studio Code**: With the ASP.NET and web development workload. [VS 2019](https://visualstudio.microsoft.com/vs/) | [VS Code](https://code.visualstudio.com/)
- **SQL Server Express**: For local database development. [Download here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Tools and Libraries

- **Entity Framework Core**: For ORM support.

## Development Setup

1. **Clone the repository**: Get the latest version of the backend code from the repository.
2. **Open the solution in Visual Studio** or **VS Code**: Load the `.sln` file to begin.
3. **Restore dependencies**: Use the .NET CLI tool to restore any NuGet packages.
4. **Configure the database connection**: Update the `appsettings.json` file with your SQL Server connection string.
5. **Apply migrations**: Run `dotnet ef database update` to create the database schema.
6. **Run the application**: Use the `dotnet run` command or the Visual Studio play button.

## Testing

- **Postman** or **Swagger**: Recommended tools for testing API endpoints. 

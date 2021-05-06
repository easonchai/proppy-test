# Test Application 📝

_This is a test application/assignment for Proppy_

## About 🤔

This application is used to view Employees data within a company. It is split into two sections: <br>

1. Mobile App
2. .NET Core Web API

<br>

## Getting Started 🏃

### Requirements 🚩

- .NET Core 2.1
- Microsoft SQL Server
- NodeJS

### Setup 🏗️

First, ensure that your SQL server is running & proper credentials have been setup.

<br>

Then, modify the `connection string` in appsettings.json using the format: <br>
`"Server=<server-name>;Database=<db-name>;User Id=<username>;Password=<password>;"`

<br>

Then, run the commands below:

```bash
Windows:
cd backend\Proppy.API # Ensure you're in the correct directory
dotnet ef database update   # This will run migrations
dotnet run # This will run the backend
```

<br>

Once complete, you may test the API by going to `localhost:5000/api/positions`. If you run into issues due to insecure connection, you may alternatively use the HTTPS url at `https://localhost:5001/api/positions`

## Useful Commands

```bash
dotnet run                  # Starts the API
dotnet ef migrations add    # Adds migration
dotnet ef database update   # Runs migrations
dotnet ef database update 0 # Reset all migrations
dotnet watch                # Watches for changes (hot reload)
```

_References: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli_ <br>
*https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli*

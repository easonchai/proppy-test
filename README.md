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

### Backend Setup 🏗️

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

### Frontend Setup 📱

Ensure that your system has the requirements to build & run the android app by following the guide [here](https://ionicframework.com/docs/developing/android).

<br>

Create a .env file using the .env.example as a template. The `VUE_APP_BASE_URL` should point to your backend server.

<br>

With all setup, enter the command below to copy the application to an emulator like android studio

```bash
ionic capacitor run android -l --external
```

<br>

This is important as this opens a port for your Android app to connect to via it's internal proxy. Ensure that your .env uses the same IP displayed in the console.

<br>
Example: `VUE_APP_BASE_URL='http://192.168.0.122:5000'`

<br>

If you still do not see any data from your backend: <br>
Sstart the AVD and use a manual proxy configuration of 10.0.2.2 at port 8100.

## Useful Commands

```bash
dotnet run                  # Starts the API
dotnet ef migrations add    # Adds migration
dotnet ef database update   # Runs migrations
dotnet ef database update 0 # Reset all migrations
dotnet watch run            # Watches for changes (hot reload)
ionic cap copy android      # Builds & copies the file for Android
```

_References: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli_ <br>
*https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli*

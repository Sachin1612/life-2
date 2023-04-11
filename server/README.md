### ImpLink
[React documentation](https://dotnet.microsoft.com/learn/aspnet/hello-world-tutorial/create)

### Create new web api project in dotnet core
CMD
`dotnet new webapi -n api`
`cd api`
`dotnet run`

### Create a class library project
CMD - `dotnet new classlib -o data.models`

### Add monogo packages -
Run Command  `dotnet add package MongoDB.Driver`
## Add connection strings
`
"MongoDb": {
    "ConnectionURI": "mongodb://localhost:27017",
    "DatabaseName": "life"
  }
`
### Repository guide
[React documentation](https://medium.com/@marekzyla95/mongo-repository-pattern-700986454a0e)

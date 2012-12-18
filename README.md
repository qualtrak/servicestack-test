# ServiceStack App

## .NET - Mono switching

### When in Mono - Monodevelop

* In `WebApp.Bootstrap.AppHost` uncomment _Sqlite_ and comment _SQL Server_:

```csharp
IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteOrmLiteDialectProvider.Instance);
this.CreateSqliteInMemoryTables(dbFactory);

// string connectionString = ConfigurationManager.ConnectionStrings["QcoachServiceStack"].ConnectionString;
// IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerOrmLiteDialectProvider.Instance);
```

### When in .NET - Visual Studio

* In `WebApp.Bootstrap.AppHost` uncomment _SQL Server_ and comment _Sqlite_:

```csharp
// IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteOrmLiteDialectProvider.Instance);
// this.CreateSqliteInMemoryTables(dbFactory);

string connectionString = ConfigurationManager.ConnectionStrings["QcoachServiceStack"].ConnectionString;
IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerOrmLiteDialectProvider.Instance);
```
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

string connectionString = ConfigurationManager.ConnectionStrings["ServiceStackTest"].ConnectionString;
IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerOrmLiteDialectProvider.Instance);
```


## Creating SQL Server Express Db Tables for first time

### Connection string in `web.config`:

```xml
<connectionStrings>
<add name="ServiceStackTest" providerName="System.Data.SqlClient" connectionString="Data Source=.\sqlexpress;Initial Catalog=test-servicestack;Integrated Security=true;MultipleActiveResultSets=True" />
</connectionStrings>
```

### Create Database

* Go to _SSMS_ and add new Database named `test-servicestack`.


### Create Tables

* Add CreateSqliteInMemoryTables below the dbFactory of SQL Server.
* After first run make sure this line of code is commented, because it will always DROP Table and recreate it.

```csharp
string connectionString = ConfigurationManager.ConnectionStrings["ServiceStackTest"].ConnectionString;
IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerOrmLiteDialectProvider.Instance);

this.CreateSqliteInMemoryTables(dbFactory);
```
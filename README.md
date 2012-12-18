# ServiceStack App

## .NET - Mono switching

### When in Mono - Monodevelop

* In `WebApp/web.config` uncomment `Mono.Data.Sqlite`:

```xml
<add assembly="Mono.Data.Sqlite, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756" />
```

* In `WebApp.Bootstrap.AppHost` uncomment _Sqlite_ and comment _SQL Server_:

```csharp
IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteOrmLiteDialectProvider.Instance);	

// string connectionString = ConfigurationManager.ConnectionStrings["QcoachServiceStack"].ConnectionString;
// IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerOrmLiteDialectProvider.Instance);
```

### When in .NET - Visual Studio

* In `WebApp/web.config` comment `Mono.Data.Sqlite`:

```xml
<!--<add assembly="Mono.Data.Sqlite, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756" />-->
```

* In `WebApp.Bootstrap.AppHost` uncomment _SQL Server_ and comment _Sqlite_:

```csharp
// IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteOrmLiteDialectProvider.Instance);	

string connectionString = ConfigurationManager.ConnectionStrings["QcoachServiceStack"].ConnectionString;
IDbConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, false, SqlServerOrmLiteDialectProvider.Instance);
```
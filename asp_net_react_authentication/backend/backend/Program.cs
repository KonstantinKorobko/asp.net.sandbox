using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//!to do: move to connection param
var host = "localhost";
var port = "3306";
var db = "db_users";
var userName = "root";
var password = "password";

var connectionString = $"server={host};port={port};database={db};user={userName};password={password}";
//!

builder.Services.AddDbContext<UserDbContext>(connection => connection.UseMySQL(connectionString));
builder.Services.AddControllers();

var app = builder.Build();

//* create database if not created, add db data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<UserDbContext>();
    context.Database.EnsureCreated();
    DbUsersInitializer.Initialize(context);
}

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();

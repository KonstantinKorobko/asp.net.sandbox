using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Headers;
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

//*!spa
builder.Services.AddSpaStaticFiles(configuration => {
    
    configuration.RootPath = "frontend/build";
});
//*!

/*builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});*/
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});*/

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

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

//*!spa
var spaPath = "/spaApp";
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    app.MapWhen(y => y.Request.Path.StartsWithSegments(spaPath), client =>
    {
        client.UseSpa(spa =>
        {
            spa.UseProxyToSpaDevelopmentServer("https://localhost:44427");
        });
    });
}
else
{
    app.Map(new PathString(spaPath), client =>
    {
        client.UseSpaStaticFiles();

        client.UseSpa(spa => {

            spa.Options.SourcePath = "frontend";

            // adds no-store header to index page to prevent deployment issues (prevent linking to old .js files)
            // .js and other static resources are still cached by the browser
            spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ResponseHeaders headers = ctx.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = true,
                        MustRevalidate = true
                    };
                }
            };
        });
    });
}
//*!

app.Run();

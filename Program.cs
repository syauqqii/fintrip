using DotNetEnv;
using Microsoft.Extensions.Configuration;

using fintrip.src.Routes;

using System.Net;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
var appPortString = Environment.GetEnvironmentVariable("APP_PORT") ?? "5005";

if (!int.TryParse(appPortString, out var appPort)) {
    appPort = 5005;
}

builder.WebHost.ConfigureKestrel(options => {
    options.Listen(IPAddress.Any, appPort);
});

var app = builder.Build();

app.MapCategoryRoutes();
app.MapExpenseRoute();

app.Run();
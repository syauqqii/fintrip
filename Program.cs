using fintrip.src.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(5005);
});

var app = builder.Build();

app.MapCategoryRoutes();
app.MapExpenseRoute();

app.Run();
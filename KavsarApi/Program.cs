var builder = WebApplication.CreateBuilder(args);
builder.Services.InitialServices(builder.Configuration);
var app = builder.Build();
app.InitialMiddlewares();
app.Run();
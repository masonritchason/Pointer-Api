using PointerAPI;

var builder = WebApplication.CreateBuilder(args);

// setup console logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add the Services and DbContexts as app services
builder = Startup.InjectServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    IServiceScope Scope = app.Services.CreateScope();
    // confirm the DbContext connections
    Startup.EnsureDatabaseConnection(Scope);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
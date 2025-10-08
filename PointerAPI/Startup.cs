using Microsoft.EntityFrameworkCore;
using Pointer.Database.Mappers;
using PointerAPI.DbContexts;
using PointerAPI.Services;

namespace PointerAPI;

/// <summary>
/// Encapsulates dependency injection, database connections, and other startup functions.
/// </summary>
public static class Startup
{
    /// <summary>
    /// Injects all necessary Pointer API service dependencies.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder InjectServices(WebApplicationBuilder builder)
    {
        // inject Context layer classes
        builder.Services.AddDbContext<ControlObjectContext>
        (
            options =>
            {
                options.UseSqlServer
                (
                    builder.Configuration.GetConnectionString("Pointer")
                );
            }
        );
        builder.Services.AddDbContext<ControlObjectSectionContext>
        (
            options =>
            {
                options.UseSqlServer
                (
                    builder.Configuration.GetConnectionString("Pointer")
                );
            }
        );
        // inject Mapper classes
        builder.Services.AddScoped<ControlObjectMapper>();
        builder.Services.AddScoped<ControlObjectSectionMapper>();
        // inject Service layer classes
        builder.Services.AddScoped<IControlObjectService, ControlObjectService>();
        builder.Services.AddScoped<IControlObjectSectionService, ControlObjectSectionService>();
        // return the modified WebApplicationBuilder
        return builder;
    }

    /// <summary>
    /// Ensures that all injected DbContexts are able to connect to a Pointer database.
    /// </summary>
    /// <param name="Scope"></param>
    public static void EnsureDatabaseConnection(IServiceScope Scope)
    {
        // create DbContexts and ensure connections
        ControlObjectContext _controlObjectContext = Scope.ServiceProvider.GetRequiredService<ControlObjectContext>();
        _controlObjectContext.Database.EnsureCreated();
        ControlObjectSectionContext _controlObjectSectionContext = Scope.ServiceProvider.GetRequiredService<ControlObjectSectionContext>();
        _controlObjectSectionContext.Database.EnsureCreated();
    }
}
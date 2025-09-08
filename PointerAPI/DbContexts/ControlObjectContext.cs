using Microsoft.EntityFrameworkCore;
using Pointer.Database.Entities;

namespace PointerAPI.DbContexts;

/// <summary>
/// A context (session) on the ControlObject table of a Pointer database.
/// </summary>
public class ControlObjectContext : DbContext
{
    /// <summary>
    /// The current set of entities in the ControlObject database table.
    /// </summary>
    public DbSet<ControlObjectEntity> ControlObjects { get; set; }

    /// <summary>
    /// Creates a new ControlObjectContext.
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControlObjectContext(DbContextOptions<ControlObjectContext> options) : base(options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }
    }
}
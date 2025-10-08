using Microsoft.EntityFrameworkCore;
using Pointer.Database.Entities;

namespace PointerAPI.DbContexts;

/// <summary>
/// A context (session) on the ControlObjectSection table of a Pointer database.
/// </summary>
public class ControlObjectSectionContext : DbContext
{
    /// <summary>
    /// The current set of entities in the ControlObjectSection database table.
    /// </summary>
    public DbSet<ControlObjectSectionEntity> ControlObjectSections { get; set; }

    /// <summary>
    /// Creates a new ControlObjectSectionContext.
    /// </summary>
    /// <param name="options"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControlObjectSectionContext(DbContextOptions<ControlObjectSectionContext> options) : base(options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }
    }
}
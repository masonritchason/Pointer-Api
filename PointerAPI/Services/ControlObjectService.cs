using Microsoft.EntityFrameworkCore;
using Pointer.Database.Entities;
using PointerAPI.DbContexts;

namespace PointerAPI.Services;

/// <summary>
/// Provides manipulation of a Pointer database' ControlObject table.
/// </summary>
public class ControlObjectService : IControlObjectService
{
    /// <summary>
    /// The dedicated context session for the ControlObjectService.
    /// </summary>
    private readonly ControlObjectContext _context;

    /// <summary>
    /// Creates a new ControlObjectService.
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControlObjectService(ControlObjectContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        _context = context;
    }

    public ControlObjectEntity? Get(int id)
    {
        return _context.ControlObjects
            .Where(x => x.Id == id)
            .FirstOrDefault();
    }

    public IEnumerable<ControlObjectEntity> GetAll()
    {
        return _context.ControlObjects;
    }

    public ControlObjectEntity? Create(ControlObjectEntity entityToCreate)
    {
        _context.ControlObjects.Add(entityToCreate);
        _context.ControlObjects.Entry(entityToCreate).State = EntityState.Added;
        bool Result = _context.SaveChanges() >= 0;
        if (!Result)
        {
            return null;
        }
        else
        {
            return _context.ControlObjects.Entry(entityToCreate).Entity;
        }
    }

    public ControlObjectEntity? Update(int id, ControlObjectEntity newEntity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
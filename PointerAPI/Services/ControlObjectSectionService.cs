using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pointer.Database.Entities;
using PointerAPI.DbContexts;

namespace PointerAPI.Services;

/// <summary>
/// Provides manipulation of a Pointer database' ControlObjectSection table.
/// </summary>
public class ControlObjectSectionService : IControlObjectSectionService
{
    /// <summary>
    /// The dedicated context session for the ControlObjectSectionService.
    /// </summary>
    private readonly ControlObjectSectionContext _context;

    /// <summary>
    /// A ControlObjectService injected to use for parent ControlObject validation.
    /// </summary>
    private readonly IControlObjectService _controlObjectService;

    /// <summary>
    /// Creates a new ControlObjectSectionService.
    /// </summary>
    /// <param name="context"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControlObjectSectionService(ControlObjectSectionContext context, IControlObjectService controlObjectService)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        _context = context;
        if (controlObjectService is null)
        {
            throw new ArgumentNullException(nameof(controlObjectService));
        }
        _controlObjectService = controlObjectService;
    }

    public ControlObjectSectionEntity? Get(int id)
    {
        return _context.ControlObjectSections
            .Where(x => x.Id == id)
            .FirstOrDefault();
    }

    public IEnumerable<ControlObjectSectionEntity> GetAll()
    {
        return _context.ControlObjectSections;
    }

    public IEnumerable<ControlObjectSectionEntity>? GetAllForControlObject(int controlObjectid)
    {
        IEnumerable<ControlObjectSectionEntity> ControlObjectSectionsFromDatabase = _context.ControlObjectSections
            .Where(x => x.ControlObjectId == controlObjectid);
        if (ControlObjectSectionsFromDatabase.IsNullOrEmpty())
        {
            return [];
        }
        return ControlObjectSectionsFromDatabase;
    }

    public ControlObjectSectionEntity? Create(ControlObjectSectionEntity entityToCreate)
    {
        // ensure the ControlObject that the ControlObjectSection is assigned to exists in the database
        ControlObjectEntity? ControlObjectFromDatabase = _controlObjectService.Get(entityToCreate.ControlObjectId);
        if (ControlObjectFromDatabase is null)
        {
            return null;
        }
        _context.ControlObjectSections.Add(entityToCreate);
        _context.ControlObjectSections.Entry(entityToCreate).State = EntityState.Added;
        bool Result = _context.SaveChanges() >= 0;
        if (!Result)
        {
            return null;
        }
        else
        {
            return _context.ControlObjectSections.Entry(entityToCreate).Entity;
        }
    }

    public ControlObjectSectionEntity? Update(int id, ControlObjectSectionEntity newEntity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
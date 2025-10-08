using Pointer.Database.Entities;

namespace PointerAPI.Services;

/// <summary>
/// Provides manipulation of a Pointer database' ControlObjectSection table.
/// </summary>
public interface IControlObjectSectionService
{
    /// <summary>
    /// Retrieves a single ControlObjectSectionEntity, by Id, from a Pointer database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ControlObjectSectionEntity? Get(int id);

    /// <summary>
    /// Retrieves all ControlObjectSectionEntities from a Pointer database.
    /// </summary>
    /// <returns></returns>
    IEnumerable<ControlObjectSectionEntity> GetAll();

    /// <summary>
    /// Retrieves all ControlObjectSectionEntities assigned to a specific ControlObject from a Pointer database.
    /// </summary>
    /// <returns></returns>
    IEnumerable<ControlObjectSectionEntity>? GetAllForControlObject(int controlObjectid);

    /// <summary>
    /// Creates a new ControlObjectSectionEntity in a Pointer database.
    /// </summary>
    /// <param name="entityToCreate"></param>
    /// <returns></returns>
    ControlObjectSectionEntity? Create(ControlObjectSectionEntity entityToCreate);

    /// <summary>
    /// Updates the ControlObjectSectionEntity at id in a Pointer database, using data from newEntity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newEntity"></param>
    /// <returns></returns>
    ControlObjectSectionEntity? Update(int id, ControlObjectSectionEntity newEntity);

    /// <summary>
    /// Deletes the ControlObjectSectionEntity at id from a Pointer database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Delete(int id);
}
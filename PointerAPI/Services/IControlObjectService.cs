using Pointer.Database.Entities;

namespace PointerAPI.Services;

/// <summary>
/// Provides manipulation of a Pointer database' ControlObject table.
/// </summary>
public interface IControlObjectService
{
    /// <summary>
    /// Retrieves a single ControlObjectEntity, by Id, from a Pointer database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ControlObjectEntity? Get(int id);

    /// <summary>
    /// Retrieves all ControlObjectEntities from a Pointer database.
    /// </summary>
    /// <returns></returns>
    IEnumerable<ControlObjectEntity> GetAll();

    /// <summary>
    /// Creates a new ControlObjectEntity in a Pointer database.
    /// </summary>
    /// <param name="entityToCreate"></param>
    /// <returns></returns>
    ControlObjectEntity? Create(ControlObjectEntity entityToCreate);

    /// <summary>
    /// Updates the ControlObjectEntity at id in a Pointer database, using data from newEntity.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newEntity"></param>
    /// <returns></returns>
    ControlObjectEntity? Update(int id, ControlObjectEntity newEntity);

    /// <summary>
    /// Deletes the ControlObjectEntity at id from a Pointer database.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Delete(int id);
}
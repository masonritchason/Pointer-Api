using Microsoft.AspNetCore.Mvc;
using Pointer.Database.Entities;
using Pointer.Database.Mappers;
using Pointer.Database.Transfer;
using PointerAPI.Services;

namespace PointerAPI.Controllers;

/// <summary>
/// Enables routing of HTTP requests to the "ControlObject" API endpoint.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ControlObjectController : ControllerBase
{
    /// <summary>
    /// A ControlObjectService that provides manipulation of the ControlObject table in a Pointer database.
    /// </summary>
    private readonly IControlObjectService _service;

    /// <summary>
    /// A ControlObjectMapper that provides mapping between states of ControlObject instances.
    /// </summary>
    private readonly ControlObjectMapper _mapper;

    /// <summary>
    /// Creates a new ControlObjectController.
    /// </summary>
    /// <param name="service"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControlObjectController(IControlObjectService service, ControlObjectMapper mapper)
    {
        // ensure a ControlObjectService was injected successfully
        if (service is null)
        {
            throw new ArgumentNullException(nameof(service));
        }
        _service = service;
        // ensure a ControlObjectMapper was injected successfully
        if (mapper is null)
        {
            throw new ArgumentNullException(nameof(mapper));
        }
        _mapper = mapper;
    }

    /// <summary>
    /// Routes an HTTP GET request for a single ControlObject with id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("id")]
    public ActionResult<ControlObjectDto> Get(int id)
    {
        ControlObjectEntity? ControlObjectFromDatabase = _service.Get(id);
        if (ControlObjectFromDatabase is null)
        {
            return NotFound();
        }
        return Ok(_mapper.EntityToDto(ControlObjectFromDatabase));
    }

    /// <summary>
    /// Routes an HTTP GET request for a all ControlObjects.
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public ActionResult<IEnumerable<ControlObjectDto>> GetAll()
    {
        IEnumerable<ControlObjectEntity> ControlObjectsFromDatabase = _service.GetAll();
        return Ok(ControlObjectsFromDatabase
            .Select(_mapper.EntityToDto));
    }

    /// <summary>
    /// Routes an HTTP POST request to create a single ControlObject.
    /// </summary>
    /// <param name="dtoToCreate"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<ControlObjectDto> Create([FromBody] ControlObjectDto dtoToCreate)
    {
        ControlObjectEntity? Created = _service.Create(_mapper.DtoToEntity(dtoToCreate));
        if (Created is null)
        {
            return BadRequest();
        }
        ControlObjectDto DtoToReturn = _mapper.EntityToDto(Created);
        return new CreatedAtActionResult
        (
            nameof(Get),
            "ControlObject",
            new { id = DtoToReturn.Id },
            DtoToReturn
        );
    }
}
using Microsoft.AspNetCore.Mvc;
using Pointer.Database.Entities;
using Pointer.Database.Mappers;
using Pointer.Database.Transfer;
using PointerAPI.Services;

namespace PointerAPI.Controllers;

/// <summary>
/// Enables routing of HTTP requests to the "ControlObject/Section" API endpoint.
/// </summary>
[ApiController]
[Route("ControlObject/Section")]
public class ControlObjectSectionController : ControllerBase
{
    /// <summary>
    /// A ControlObjectSectionService that provides manipulation of the ControlObjectSection table in a Pointer database.
    /// </summary>
    private readonly IControlObjectSectionService _service;

    /// <summary>
    /// A ControlObjectSectionMapper that provides mapping between states of ControlObjectSection instances.
    /// </summary>
    private readonly ControlObjectSectionMapper _mapper;

    /// <summary>
    /// Creates a new ControlObjectSectionController.
    /// </summary>
    /// <param name="service"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControlObjectSectionController(IControlObjectSectionService service, ControlObjectSectionMapper mapper)
    {
        // ensure a ControlObjectSectionService was injected successfully
        if (service is null)
        {
            throw new ArgumentNullException(nameof(service));
        }
        _service = service;
        // ensure a ControlObjectSectionMapper was injected successfully
        if (mapper is null)
        {
            throw new ArgumentNullException(nameof(mapper));
        }
        _mapper = mapper;
    }

    /// <summary>
    /// Routes an HTTP GET request for a single ControlObjectSection with id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("id")]
    public ActionResult<ControlObjectSectionDto> Get(int id)
    {
        ControlObjectSectionEntity? ControlObjectSectionFromDatabase = _service.Get(id);
        if (ControlObjectSectionFromDatabase is null)
        {
            return NotFound();
        }
        return Ok(_mapper.EntityToDto(ControlObjectSectionFromDatabase));
    }

    /// <summary>
    /// Routes an HTTP GET request for a all ControlObjectSections.
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public ActionResult<IEnumerable<ControlObjectSectionDto>> GetAll()
    {
        IEnumerable<ControlObjectSectionEntity> ControlObjectSectionsFromDatabase = _service.GetAll();
        return Ok(ControlObjectSectionsFromDatabase
            .Select(_mapper.EntityToDto));
    }

    /// <summary>
    /// Routes an HTTP GET request for a all ControlObjectSections assigned to a specific ControlObject.
    /// </summary>
    /// <returns></returns>
    [HttpGet("assignedTo")]
    public ActionResult<IEnumerable<ControlObjectSectionDto>> GetAllForControlObject([FromQuery] int ControlObjectId)
    {
        IEnumerable<ControlObjectSectionEntity>? ControlObjectSectionsFromDatabase = _service.GetAllForControlObject(ControlObjectId);
        if (ControlObjectSectionsFromDatabase is null)
        {
            return NotFound();
        }
        return Ok(ControlObjectSectionsFromDatabase
            .Select(_mapper.EntityToDto));
    }

    /// <summary>
    /// Routes an HTTP POST request to create a single ControlObjectSection.
    /// </summary>
    /// <param name="dtoToCreate"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<ControlObjectSectionDto> Create([FromBody] ControlObjectSectionDto dtoToCreate)
    {
        ControlObjectSectionEntity? Created = _service.Create(_mapper.DtoToEntity(dtoToCreate));
        if (Created is null)
        {
            return BadRequest();
        }
        ControlObjectSectionDto DtoToReturn = _mapper.EntityToDto(Created);
        return new CreatedAtActionResult
        (
            nameof(Get),
            "ControlObject/Section",
            new { id = DtoToReturn.Id },
            DtoToReturn
        );
    }
}
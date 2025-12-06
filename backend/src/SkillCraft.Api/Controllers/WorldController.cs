using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace SkillCraft.Api.Controllers;

[ApiController]
[Authorize]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[Route("worlds")]
public class WorldController : ControllerBase
{
  private readonly IWorldService _worldService;

  public WorldController(IWorldService worldService)
  {
    _worldService = worldService;
  }

  [HttpPost]
  [ProducesResponseType<WorldModel>(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
  [ProducesResponseType(StatusCodes.Status403Forbidden)]
  [SwaggerOperation(Summary = "Creates a new world.")]
  public async Task<ActionResult<WorldModel>> CreateAsync([FromBody] CreateOrReplaceWorldPayload payload, CancellationToken cancellationToken)
  {
    CreateOrReplaceWorldResult result = await _worldService.CreateOrReplaceAsync(payload, id: null, cancellationToken);
    return ToActionResult(result);
  }

  [HttpPut("{id}")]
  [ProducesResponseType<WorldModel>(StatusCodes.Status200OK)]
  [ProducesResponseType<WorldModel>(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
  [ProducesResponseType(StatusCodes.Status403Forbidden)]
  [SwaggerOperation(Summary = "Creates or replaces a world.",
    Description = "<p>If an existing world matches the specified ID, it will be replaced.</p>"
      + "<p>Otherwise, a new world will be created using the specified ID.</p>")]
  public async Task<ActionResult<WorldModel>> ReplaceAsync(Guid id, [FromBody] CreateOrReplaceWorldPayload payload, CancellationToken cancellationToken)
  {
    CreateOrReplaceWorldResult result = await _worldService.CreateOrReplaceAsync(payload, id, cancellationToken);
    return ToActionResult(result);
  }

  [HttpPatch("{id}")]
  [ProducesResponseType<WorldModel>(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status402PaymentRequired)]
  [ProducesResponseType(StatusCodes.Status403Forbidden)]
  [SwaggerOperation(Summary = "Partially updates an existing world.")]
  public async Task<ActionResult<WorldModel>> UpdateAsync(Guid id, [FromBody] UpdateWorldPayload payload, CancellationToken cancellationToken)
  {
    WorldModel? world = await _worldService.UpdateAsync(id, payload, cancellationToken);
    return world is null ? NotFound() : Ok(world);
  }

  private ActionResult<WorldModel> ToActionResult(CreateOrReplaceWorldResult result)
  {
    if (result.Created)
    {
      Uri location = new($"{Request.Scheme}://{Request.Host}/worlds/{result.World.Id}", UriKind.Absolute);
      return Created(location, result.World);
    }

    return Ok(result.World);
  }
}

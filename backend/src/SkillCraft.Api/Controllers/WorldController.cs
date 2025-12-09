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
  [ProducesResponseType(StatusCodes.Status409Conflict)]
  [SwaggerOperation(Summary = "Creates a new world.")]
  public async Task<ActionResult<WorldModel>> CreateAsync([FromBody] CreateWorldPayload payload, CancellationToken cancellationToken)
  {
    WorldModel world = await _worldService.CreateAsync(payload, cancellationToken);
    Uri location = new($"{Request.Scheme}://{Request.Host}/worlds/{world.Id}", UriKind.Absolute);
    return Created(location, world);
  }
}

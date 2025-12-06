using Microsoft.AspNetCore.Mvc;
using SkillCraft.Api.Models.Index;
using SkillCraft.Api.Settings;
using Swashbuckle.AspNetCore.Annotations;

namespace SkillCraft.Api.Controllers;

[ApiController]
[Route("")]
public class IndexController : ControllerBase
{
  private readonly ApiSettings _settings;

  public IndexController(ApiSettings settings)
  {
    _settings = settings;
  }

  [HttpGet]
  [ProducesResponseType<ApiVersion>(StatusCodes.Status200OK)]
  [SwaggerOperation(Summary = "Returns the API current title and version.")]
  public ActionResult<ApiVersion> Get()
  {
    return Ok(new ApiVersion(_settings.Title, _settings.Version));
  }
}

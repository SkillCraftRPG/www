using Microsoft.AspNetCore.Mvc;
using SkillCraft.Api.Models.Index;
using SkillCraft.Api.Settings;

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
  public ActionResult<ApiVersion> Get() => Ok(new ApiVersion(_settings.Title, _settings.Version));
}

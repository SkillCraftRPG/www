using Krakenar.Web.Settings;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Models.Index;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api")]
public class IndexController : ControllerBase
{
  private readonly AdminSettings _adminSettings;

  public IndexController(AdminSettings adminSettings)
  {
    _adminSettings = adminSettings;
  }

  [HttpGet]
  public ActionResult<ApiVersion> Get()
  {
    ApiVersion version = new(_adminSettings.Title, _adminSettings.Version);
    return Ok(version);
  }
}

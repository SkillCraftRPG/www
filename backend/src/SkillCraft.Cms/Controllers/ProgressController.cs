using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Progress;
using SkillCraft.Cms.Core.Progress.Models;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/progress")]
public class ProgressController : ControllerBase
{
  private readonly IProgressService _progressService;

  public ProgressController(IProgressService progressService)
  {
    _progressService = progressService;
  }

  [HttpGet]
  public async Task<ActionResult<ProgressModel>> GetAsync(CancellationToken cancellationToken)
  {
    ProgressModel progress = await _progressService.ReadAsync(cancellationToken);
    return Ok(progress);
  }
}

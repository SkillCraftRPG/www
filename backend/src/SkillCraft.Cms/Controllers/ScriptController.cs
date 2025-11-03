using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Scripts;
using SkillCraft.Cms.Core.Scripts.Models;
using SkillCraft.Cms.Models.Script;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/scripts")]
public class ScriptController : ControllerBase
{
  private readonly IScriptQuerier _scriptQuerier;

  public ScriptController(IScriptQuerier scriptQuerier)
  {
    _scriptQuerier = scriptQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<ScriptModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    ScriptModel? script = await _scriptQuerier.ReadAsync(id, cancellationToken);
    return script is null ? NotFound() : Ok(script);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<ScriptModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    ScriptModel? script = await _scriptQuerier.ReadAsync(slug, cancellationToken);
    return script is null ? NotFound() : Ok(script);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<ScriptModel>>> SearchAsync([FromQuery] SearchScriptsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<ScriptModel> scripts = await _scriptQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(scripts);
  }
}

using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Skills;
using SkillCraft.Cms.Core.Skills.Models;
using SkillCraft.Cms.Models.Skill;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillController : ControllerBase
{
  private readonly ISkillQuerier _skillQuerier;

  public SkillController(ISkillQuerier skillQuerier)
  {
    _skillQuerier = skillQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<SkillModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    SkillModel? skill = await _skillQuerier.ReadAsync(id, cancellationToken);
    return skill is null ? NotFound() : Ok(skill);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<SkillModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    SkillModel? skill = await _skillQuerier.ReadAsync(slug, cancellationToken);
    return skill is null ? NotFound() : Ok(skill);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<SkillModel>>> SearchAsync([FromQuery] SearchSkillsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<SkillModel> skills = await _skillQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(skills);
  }
}

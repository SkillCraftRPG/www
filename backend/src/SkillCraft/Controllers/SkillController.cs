using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillController : ControllerBase
{
  private readonly ISkillQuerier _skillQuerier;

  public SkillController(ISkillQuerier skillQuerier)
  {
    _skillQuerier = skillQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<SkillModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<SkillModel> skills = await _skillQuerier.ListAsync(cancellationToken);
    SearchResults<SkillModel> results = new(skills);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<SkillModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    SkillModel? skill = await _skillQuerier.ReadAsync(slug, cancellationToken);
    return skill is null ? NotFound() : Ok(skill);
  }
}

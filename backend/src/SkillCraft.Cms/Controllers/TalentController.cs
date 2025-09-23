using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Talents;
using SkillCraft.Cms.Core.Talents.Models;
using SkillCraft.Cms.Models.Talent;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/talents")]
public class TalentController : ControllerBase
{
  private readonly ITalentQuerier _talentQuerier;

  public TalentController(ITalentQuerier talentQuerier)
  {
    _talentQuerier = talentQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TalentModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    TalentModel? talent = await _talentQuerier.ReadAsync(id, cancellationToken);
    return talent is null ? NotFound() : Ok(talent);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<TalentModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    TalentModel? talent = await _talentQuerier.ReadAsync(slug, cancellationToken);
    return talent is null ? NotFound() : Ok(talent);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<TalentModel>>> SearchAsync([FromQuery] SearchTalentsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<TalentModel> talents = await _talentQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(talents);
  }
}

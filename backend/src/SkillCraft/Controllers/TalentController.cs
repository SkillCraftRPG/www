using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/talents")]
public class TalentController : ControllerBase
{
  private readonly ITalentQuerier _talentQuerier;

  public TalentController(ITalentQuerier talentQuerier)
  {
    _talentQuerier = talentQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<TalentModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<TalentModel> talents = await _talentQuerier.ListAsync(cancellationToken);
    SearchResults<TalentModel> results = new(talents);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<TalentModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    TalentModel? talent = await _talentQuerier.ReadAsync(slug, cancellationToken);
    return talent is null ? NotFound() : Ok(talent);
  }
}

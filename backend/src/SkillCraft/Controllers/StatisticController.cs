using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticController : ControllerBase
{
  private readonly IStatisticQuerier _statisticQuerier;

  public StatisticController(IStatisticQuerier statisticQuerier)
  {
    _statisticQuerier = statisticQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<StatisticModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<StatisticModel> statistics = await _statisticQuerier.ListAsync(cancellationToken);
    SearchResults<StatisticModel> results = new(statistics);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<StatisticModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    StatisticModel? statistic = await _statisticQuerier.ReadAsync(slug, cancellationToken);
    return statistic is null ? NotFound() : Ok(statistic);
  }
}

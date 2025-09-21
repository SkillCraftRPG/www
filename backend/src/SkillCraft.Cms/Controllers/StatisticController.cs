using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Statistics;
using SkillCraft.Cms.Core.Statistics.Models;
using SkillCraft.Cms.Models.Statistic;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticController : ControllerBase
{
  private readonly IStatisticQuerier _statisticQuerier;

  public StatisticController(IStatisticQuerier statisticQuerier)
  {
    _statisticQuerier = statisticQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<StatisticModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    StatisticModel? statistic = await _statisticQuerier.ReadAsync(id, cancellationToken);
    return statistic is null ? NotFound() : Ok(statistic);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<StatisticModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    StatisticModel? statistic = await _statisticQuerier.ReadAsync(slug, cancellationToken);
    return statistic is null ? NotFound() : Ok(statistic);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<StatisticModel>>> SearchAsync([FromQuery] SearchStatisticsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<StatisticModel> statistics = await _statisticQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(statistics);
  }
}

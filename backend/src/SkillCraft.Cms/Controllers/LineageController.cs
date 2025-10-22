using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Lineages;
using SkillCraft.Cms.Core.Lineages.Models;
using SkillCraft.Cms.Models.Lineage;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/lineages")]
public class LineageController : ControllerBase
{
  private readonly ILineageQuerier _lineageQuerier;

  public LineageController(ILineageQuerier lineageQuerier)
  {
    _lineageQuerier = lineageQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<LineageModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    LineageModel? lineage = await _lineageQuerier.ReadAsync(id, cancellationToken);
    return lineage is null ? NotFound() : Ok(lineage);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<LineageModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    LineageModel? lineage = await _lineageQuerier.ReadAsync(slug, cancellationToken);
    return lineage is null ? NotFound() : Ok(lineage);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<LineageModel>>> SearchAsync([FromQuery] SearchLineagesParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<LineageModel> lineages = await _lineageQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(lineages);
  }
}

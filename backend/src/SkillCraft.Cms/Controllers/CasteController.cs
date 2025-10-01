using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Castes;
using SkillCraft.Cms.Core.Castes.Models;
using SkillCraft.Cms.Models.Caste;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/castes")]
public class CasteController : ControllerBase
{
  private readonly ICasteQuerier _casteQuerier;

  public CasteController(ICasteQuerier casteQuerier)
  {
    _casteQuerier = casteQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<CasteModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    CasteModel? caste = await _casteQuerier.ReadAsync(id, cancellationToken);
    return caste is null ? NotFound() : Ok(caste);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<CasteModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    CasteModel? caste = await _casteQuerier.ReadAsync(slug, cancellationToken);
    return caste is null ? NotFound() : Ok(caste);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<CasteModel>>> SearchAsync([FromQuery] SearchCastesParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<CasteModel> castes = await _casteQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(castes);
  }
}

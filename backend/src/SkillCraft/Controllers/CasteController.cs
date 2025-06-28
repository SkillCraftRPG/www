using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/castes")]
public class CasteController : ControllerBase
{
  private readonly ICasteQuerier _casteQuerier;

  public CasteController(ICasteQuerier casteQuerier)
  {
    _casteQuerier = casteQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<CasteModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<CasteModel> castes = await _casteQuerier.ListAsync(cancellationToken);
    SearchResults<CasteModel> results = new(castes);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<CasteModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    CasteModel? caste = await _casteQuerier.ReadAsync(slug, cancellationToken);
    return caste is null ? NotFound() : Ok(caste);
  }
}

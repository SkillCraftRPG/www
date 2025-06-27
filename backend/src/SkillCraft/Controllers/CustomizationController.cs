using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/customizations")]
public class CustomizationController : ControllerBase
{
  private readonly ICustomizationQuerier _customizationQuerier;

  public CustomizationController(ICustomizationQuerier customizationQuerier)
  {
    _customizationQuerier = customizationQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<CustomizationModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<CustomizationModel> customizations = await _customizationQuerier.ListAsync(cancellationToken);
    SearchResults<CustomizationModel> results = new(customizations);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<CustomizationModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    CustomizationModel? customization = await _customizationQuerier.ReadAsync(slug, cancellationToken);
    return customization is null ? NotFound() : Ok(customization);
  }
}

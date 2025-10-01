using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Customizations;
using SkillCraft.Cms.Core.Customizations.Models;
using SkillCraft.Cms.Models.Customization;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/customizations")]
public class CustomizationController : ControllerBase
{
  private readonly ICustomizationQuerier _customizationQuerier;

  public CustomizationController(ICustomizationQuerier customizationQuerier)
  {
    _customizationQuerier = customizationQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<CustomizationModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    CustomizationModel? customization = await _customizationQuerier.ReadAsync(id, cancellationToken);
    return customization is null ? NotFound() : Ok(customization);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<CustomizationModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    CustomizationModel? customization = await _customizationQuerier.ReadAsync(slug, cancellationToken);
    return customization is null ? NotFound() : Ok(customization);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<CustomizationModel>>> SearchAsync([FromQuery] SearchCustomizationsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<CustomizationModel> customizations = await _customizationQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(customizations);
  }
}

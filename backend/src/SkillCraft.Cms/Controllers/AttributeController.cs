using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Attributes;
using SkillCraft.Cms.Core.Attributes.Models;
using SkillCraft.Cms.Models.Attribute;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/attributes")]
public class AttributeController : ControllerBase
{
  private readonly IAttributeQuerier _attributeQuerier;

  public AttributeController(IAttributeQuerier attributeQuerier)
  {
    _attributeQuerier = attributeQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<AttributeModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    AttributeModel? attribute = await _attributeQuerier.ReadAsync(id, cancellationToken);
    return attribute is null ? NotFound() : Ok(attribute);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<AttributeModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    AttributeModel? attribute = await _attributeQuerier.ReadAsync(slug, cancellationToken);
    return attribute is null ? NotFound() : Ok(attribute);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<AttributeModel>>> SearchAsync([FromQuery] SearchAttributesParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<AttributeModel> attributes = await _attributeQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(attributes);
  }
}

using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/attributes")]
public class AttributeController : ControllerBase
{
  private readonly IAttributeQuerier _attributeQuerier;

  public AttributeController(IAttributeQuerier attributeQuerier)
  {
    _attributeQuerier = attributeQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<AttributeModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<AttributeModel> attributes = await _attributeQuerier.ListAsync(cancellationToken);
    SearchResults<AttributeModel> results = new(attributes);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<AttributeModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    AttributeModel? attribute = await _attributeQuerier.ReadAsync(slug, cancellationToken);
    return attribute is null ? NotFound() : Ok(attribute);
  }
}

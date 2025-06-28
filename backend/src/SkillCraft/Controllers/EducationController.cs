using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Core.Rules;
using SkillCraft.Core.Rules.Models;

namespace SkillCraft.Controllers;

[ApiController]
[Route("api/educations")]
public class EducationController : ControllerBase
{
  private readonly IEducationQuerier _educationQuerier;

  public EducationController(IEducationQuerier educationQuerier)
  {
    _educationQuerier = educationQuerier;
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<EducationModel>>> ListAsync(CancellationToken cancellationToken)
  {
    IReadOnlyCollection<EducationModel> educations = await _educationQuerier.ListAsync(cancellationToken);
    SearchResults<EducationModel> results = new(educations);
    return Ok(results);
  }

  [HttpGet("{slug}")]
  public async Task<ActionResult<EducationModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    EducationModel? education = await _educationQuerier.ReadAsync(slug, cancellationToken);
    return education is null ? NotFound() : Ok(education);
  }
}

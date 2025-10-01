using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Educations;
using SkillCraft.Cms.Core.Educations.Models;
using SkillCraft.Cms.Models.Education;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/educations")]
public class EducationController : ControllerBase
{
  private readonly IEducationQuerier _educationQuerier;

  public EducationController(IEducationQuerier educationQuerier)
  {
    _educationQuerier = educationQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<EducationModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    EducationModel? education = await _educationQuerier.ReadAsync(id, cancellationToken);
    return education is null ? NotFound() : Ok(education);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<EducationModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    EducationModel? education = await _educationQuerier.ReadAsync(slug, cancellationToken);
    return education is null ? NotFound() : Ok(education);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<EducationModel>>> SearchAsync([FromQuery] SearchEducationsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<EducationModel> educations = await _educationQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(educations);
  }
}

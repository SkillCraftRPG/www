using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Specializations;
using SkillCraft.Cms.Core.Specializations.Models;
using SkillCraft.Cms.Models.Specialization;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/specializations")]
public class SpecializationController : ControllerBase
{
  private readonly ISpecializationQuerier _specializationQuerier;

  public SpecializationController(ISpecializationQuerier specializationQuerier)
  {
    _specializationQuerier = specializationQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<SpecializationModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    SpecializationModel? specialization = await _specializationQuerier.ReadAsync(id, cancellationToken);
    return specialization is null ? NotFound() : Ok(specialization);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<SpecializationModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    SpecializationModel? specialization = await _specializationQuerier.ReadAsync(slug, cancellationToken);
    return specialization is null ? NotFound() : Ok(specialization);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<SpecializationModel>>> SearchAsync([FromQuery] SearchSpecializationsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<SpecializationModel> specializations = await _specializationQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(specializations);
  }
}

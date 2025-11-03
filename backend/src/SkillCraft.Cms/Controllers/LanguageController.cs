using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Languages;
using SkillCraft.Cms.Core.Languages.Models;
using SkillCraft.Cms.Models.Language;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/languages")]
public class LanguageController : ControllerBase
{
  private readonly ILanguageQuerier _languageQuerier;

  public LanguageController(ILanguageQuerier languageQuerier)
  {
    _languageQuerier = languageQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<LanguageModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    LanguageModel? language = await _languageQuerier.ReadAsync(id, cancellationToken);
    return language is null ? NotFound() : Ok(language);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<LanguageModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    LanguageModel? language = await _languageQuerier.ReadAsync(slug, cancellationToken);
    return language is null ? NotFound() : Ok(language);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<LanguageModel>>> SearchAsync([FromQuery] SearchLanguagesParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<LanguageModel> languages = await _languageQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(languages);
  }
}

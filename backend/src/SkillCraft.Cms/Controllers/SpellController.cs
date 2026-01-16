using Krakenar.Contracts.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Spells;
using SkillCraft.Cms.Core.Spells.Models;
using SkillCraft.Cms.Models.Spell;

namespace SkillCraft.Cms.Controllers;

[ApiController]
[Route("api/spells")]
public class SpellController : ControllerBase
{
  private readonly ISpellQuerier _spellQuerier;

  public SpellController(ISpellQuerier spellQuerier)
  {
    _spellQuerier = spellQuerier;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<SpellModel>> ReadAsync(Guid id, CancellationToken cancellationToken)
  {
    SpellModel? spell = await _spellQuerier.ReadAsync(id, cancellationToken);
    return spell is null ? NotFound() : Ok(spell);
  }

  [HttpGet("slug:{slug}")]
  public async Task<ActionResult<SpellModel>> ReadAsync(string slug, CancellationToken cancellationToken)
  {
    SpellModel? spell = await _spellQuerier.ReadAsync(slug, cancellationToken);
    return spell is null ? NotFound() : Ok(spell);
  }

  [HttpGet]
  public async Task<ActionResult<SearchResults<SpellModel>>> SearchAsync([FromQuery] SearchSpellsParameters parameters, CancellationToken cancellationToken)
  {
    SearchResults<SpellModel> spells = await _spellQuerier.SearchAsync(parameters.ToPayload(), cancellationToken);
    return Ok(spells);
  }
}

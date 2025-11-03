using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Scripts.Models;

namespace SkillCraft.Cms.Core.Scripts;

public interface IScriptQuerier
{
  Task<ScriptModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<ScriptModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<ScriptModel>> SearchAsync(SearchScriptsPayload payload, CancellationToken cancellationToken = default);
}

using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Languages.Models;

namespace SkillCraft.Cms.Core.Languages;

public interface ILanguageQuerier
{
  Task<LanguageModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<LanguageModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<LanguageModel>> SearchAsync(SearchLanguagesPayload payload, CancellationToken cancellationToken = default);
}

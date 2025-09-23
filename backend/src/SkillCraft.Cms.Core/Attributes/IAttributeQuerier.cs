using Krakenar.Contracts.Search;
using SkillCraft.Cms.Core.Attributes.Models;

namespace SkillCraft.Cms.Core.Attributes;

public interface IAttributeQuerier
{
  Task<AttributeModel?> ReadAsync(Guid id, CancellationToken cancellationToken = default);
  Task<AttributeModel?> ReadAsync(string slug, CancellationToken cancellationToken = default);

  Task<SearchResults<AttributeModel>> SearchAsync(SearchAttributesPayload payload, CancellationToken cancellationToken = default);
}

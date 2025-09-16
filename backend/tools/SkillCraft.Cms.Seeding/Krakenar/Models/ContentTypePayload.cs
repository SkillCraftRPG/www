using Krakenar.Contracts.Contents;

namespace SkillCraft.Cms.Seeding.Krakenar.Models;

internal record ContentTypePayload : CreateOrReplaceContentTypePayload
{
  public Guid Id { get; set; }

  public List<FieldDefinitionPayload> Fields { get; set; } = [];
}

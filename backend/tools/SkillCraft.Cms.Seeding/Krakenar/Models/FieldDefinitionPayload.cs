using Krakenar.Contracts.Fields;

namespace SkillCraft.Cms.Seeding.Krakenar.Models;

internal record FieldDefinitionPayload : CreateOrReplaceFieldDefinitionPayload
{
  public Guid Id { get; set; }
}

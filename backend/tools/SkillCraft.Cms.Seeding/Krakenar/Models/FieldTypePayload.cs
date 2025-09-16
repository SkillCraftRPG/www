using Krakenar.Contracts.Fields;

namespace SkillCraft.Cms.Seeding.Krakenar.Models;

internal record FieldTypePayload : CreateOrReplaceFieldTypePayload
{
  public Guid Id { get; set; }
}

using Krakenar.Contracts.Fields;

namespace SkillCraft.Seeding.Krakenar.Payloads;

internal record FieldTypePayload : CreateOrReplaceFieldTypePayload
{
  public Guid Id { get; set; }
}

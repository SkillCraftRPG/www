using Krakenar.Contracts.Fields;

namespace SkillCraft.Seeding.Krakenar.Payloads;

internal record FieldDefinitionPayload : CreateOrReplaceFieldDefinitionPayload
{
  public Guid Id { get; set; }
}

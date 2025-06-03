using Krakenar.Contracts.Realms;

namespace SkillCraft.Seeding.Krakenar.Payloads;

internal record RealmPayload : CreateOrReplaceRealmPayload
{
  public Guid Id { get; set; }
}

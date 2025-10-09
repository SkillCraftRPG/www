using Krakenar.Contracts.Users;

namespace SkillCraft.Cms.Seeding.Krakenar.Models;

internal record UserPayload : CreateOrReplaceUserPayload
{
  public Guid? Id { get; set; }
}

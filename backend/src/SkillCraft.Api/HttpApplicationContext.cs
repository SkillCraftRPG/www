using SkillCraft.Core;

namespace SkillCraft.Api;

internal class HttpApplicationContext : IApplicationContext
{
  public UserId UserId => throw new InvalidOperationException("An authenticated user is required.");
}

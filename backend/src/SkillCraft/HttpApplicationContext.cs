using SkillCraft.Core;
using SkillCraft.Extensions;

namespace SkillCraft;

internal class HttpApplicationContext : IContext
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  private HttpContext HttpContext => _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("The HttpContext is required.");

  public UserId UserId => new(HttpContext.GetUserId());

  public HttpApplicationContext(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }
}

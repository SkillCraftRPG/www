using SkillCraft.Api.Extensions;
using SkillCraft.Core;

namespace SkillCraft.Api;

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

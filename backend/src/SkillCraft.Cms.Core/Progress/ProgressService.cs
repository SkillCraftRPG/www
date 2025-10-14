using Krakenar.Core;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Cms.Core.Progress.Models;
using SkillCraft.Cms.Core.Progress.Queries;

namespace SkillCraft.Cms.Core.Progress;

public interface IProgressService
{
  Task<ProgressModel> ReadAsync(CancellationToken cancellationToken = default);
}

internal class ProgressService : IProgressService
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IProgressService, ProgressService>();
    services.AddTransient<IQueryHandler<ReadProgress, ProgressModel>, ReadProgressHandler>();
  }

  private readonly IQueryBus _queryBus;

  public ProgressService(IQueryBus queryBus)
  {
    _queryBus = queryBus;
  }

  public async Task<ProgressModel> ReadAsync(CancellationToken cancellationToken)
  {
    ReadProgress query = new();
    return await _queryBus.ExecuteAsync(query, cancellationToken);
  }
}

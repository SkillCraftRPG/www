using Krakenar.Contracts.Contents;
using Krakenar.Core;

namespace SkillCraft.Cms.Seeding.Rules.Tasks;

internal class SeedAttributesTask : SeedingTask
{
  public override string? Description => $"Seeds the Attributes contents.";
}

internal class SeedAttributesTaskHandler : ICommandHandler<SeedAttributesTask, TaskResult>
{
  private readonly IContentService _contentService;
  private readonly ILogger<SeedAttributesTaskHandler> _logger;

  public SeedAttributesTaskHandler(IContentService contentService, ILogger<SeedAttributesTaskHandler> logger)
  {
    _contentService = contentService;
    _logger = logger;
  }

  public async Task<TaskResult> HandleAsync(SeedAttributesTask command, CancellationToken cancellationToken)
  {
    string json = await File.ReadAllTextAsync("Rules/data/attributes.json", Encoding.UTF8, cancellationToken);
    IEnumerable<AttributeDto>? attributes = SeedingSerializer.Deserialize<IEnumerable<AttributeDto>>(json);
    if (attributes is not null)
    {
      foreach (AttributeDto attribute in attributes)
      {

      }
    }

    return new TaskResult();
  }
}

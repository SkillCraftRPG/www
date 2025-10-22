namespace SkillCraft.Cms.Infrastructure.Entities;

internal class LineageLanguageEntity
{
  public LineageEntity? Lineage { get; private set; }
  public int LineageId { get; private set; }
  public Guid LineageUid { get; private set; }

  public LanguageEntity? Language { get; private set; }
  public int LanguageId { get; private set; }
  public Guid LanguageUid { get; private set; }

  public LineageLanguageEntity(LineageEntity lineage, LanguageEntity language)
  {
    Lineage = lineage;
    LineageId = lineage.LineageId;
    LineageUid = lineage.Id;

    Language = language;
    LanguageId = language.LanguageId;
    LanguageUid = language.Id;
  }

  private LineageLanguageEntity()
  {
  }
}

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class LineageFeatureEntity
{
  public LineageEntity? Lineage { get; private set; }
  public int LineageId { get; private set; }
  public Guid LineageUid { get; private set; }

  public FeatureEntity? Feature { get; private set; }
  public int FeatureId { get; private set; }
  public Guid FeatureUid { get; private set; }

  public LineageFeatureEntity(LineageEntity lineage, FeatureEntity feature)
  {
    Lineage = lineage;
    LineageId = lineage.LineageId;
    LineageUid = lineage.Id;

    Feature = feature;
    FeatureId = feature.FeatureId;
    FeatureUid = feature.Id;
  }

  private LineageFeatureEntity()
  {
  }
}

namespace SkillCraft.Cms.Infrastructure.Entities;

internal class SpecializationFeatureEntity
{
  public SpecializationEntity? Specialization { get; private set; }
  public int SpecializationId { get; private set; }
  public Guid SpecializationUid { get; private set; }

  public FeatureEntity? Feature { get; private set; }
  public int FeatureId { get; private set; }
  public Guid FeatureUid { get; private set; }

  public SpecializationFeatureEntity(SpecializationEntity specialization, FeatureEntity feature)
  {
    Specialization = specialization;
    SpecializationId = specialization.SpecializationId;
    SpecializationUid = specialization.Id;

    Feature = feature;
    FeatureId = feature.FeatureId;
    FeatureUid = feature.Id;
  }

  private SpecializationFeatureEntity()
  {
  }
}

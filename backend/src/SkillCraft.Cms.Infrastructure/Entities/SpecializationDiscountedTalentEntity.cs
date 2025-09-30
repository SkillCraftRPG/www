namespace SkillCraft.Cms.Infrastructure.Entities;

internal class SpecializationDiscountedTalentEntity
{
  public SpecializationEntity? Specialization { get; private set; }
  public int SpecializationId { get; private set; }
  public Guid SpecializationUid { get; private set; }

  public TalentEntity? Talent { get; private set; }
  public int TalentId { get; private set; }
  public Guid TalentUid { get; private set; }

  public SpecializationDiscountedTalentEntity(SpecializationEntity specialization, TalentEntity talent)
  {
    Specialization = specialization;
    SpecializationId = specialization.SpecializationId;
    SpecializationUid = specialization.Id;

    Talent = talent;
    TalentId = talent.TalentId;
    TalentUid = talent.Id;
  }

  private SpecializationDiscountedTalentEntity()
  {
  }
}

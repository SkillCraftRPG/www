using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Specializations
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Specializations), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(SpecializationEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(SpecializationEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(SpecializationEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(SpecializationEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(SpecializationEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(SpecializationEntity.Version), Table);

  public static readonly ColumnId Description = new(nameof(SpecializationEntity.Description), Table);
  public static readonly ColumnId Id = new(nameof(SpecializationEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(SpecializationEntity.IsPublished), Table);
  public static readonly ColumnId MandatoryTalentId = new(nameof(SpecializationEntity.MandatoryTalentId), Table);
  public static readonly ColumnId MandatoryTalentUid = new(nameof(SpecializationEntity.MandatoryTalentUid), Table);
  public static readonly ColumnId Name = new(nameof(SpecializationEntity.Name), Table);
  public static readonly ColumnId OtherOptions = new(nameof(SpecializationEntity.OtherOptions), Table);
  public static readonly ColumnId OtherRequirements = new(nameof(SpecializationEntity.OtherRequirements), Table);
  public static readonly ColumnId ReservedTalentDescription = new(nameof(SpecializationEntity.ReservedTalentDescription), Table);
  public static readonly ColumnId ReservedTalentName = new(nameof(SpecializationEntity.ReservedTalentName), Table);
  public static readonly ColumnId Slug = new(nameof(SpecializationEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(SpecializationEntity.SlugNormalized), Table);
  public static readonly ColumnId SpecializationId = new(nameof(SpecializationEntity.SpecializationId), Table);
  public static readonly ColumnId Summary = new(nameof(SpecializationEntity.Summary), Table);
  public static readonly ColumnId Tier = new(nameof(SpecializationEntity.Tier), Table);
}

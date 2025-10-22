using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class Lineages
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.Lineages), alias: null);

  public static readonly ColumnId CreatedBy = new(nameof(LineageEntity.CreatedBy), Table);
  public static readonly ColumnId CreatedOn = new(nameof(LineageEntity.CreatedOn), Table);
  public static readonly ColumnId StreamId = new(nameof(LineageEntity.StreamId), Table);
  public static readonly ColumnId UpdatedBy = new(nameof(LineageEntity.UpdatedBy), Table);
  public static readonly ColumnId UpdatedOn = new(nameof(LineageEntity.UpdatedOn), Table);
  public static readonly ColumnId Version = new(nameof(LineageEntity.Version), Table);

  public static readonly ColumnId Adolescent = new(nameof(LineageEntity.Adolescent), Table);
  public static readonly ColumnId Adult = new(nameof(LineageEntity.Adult), Table);
  public static readonly ColumnId Burrow = new(nameof(LineageEntity.Burrow), Table);
  public static readonly ColumnId Climb = new(nameof(LineageEntity.Climb), Table);
  public static readonly ColumnId Description = new(nameof(LineageEntity.Description), Table);
  public static readonly ColumnId ExtraLanguages = new(nameof(LineageEntity.ExtraLanguages), Table);
  public static readonly ColumnId Fly = new(nameof(LineageEntity.Fly), Table);
  public static readonly ColumnId Hover = new(nameof(LineageEntity.Hover), Table);
  public static readonly ColumnId Id = new(nameof(LineageEntity.Id), Table);
  public static readonly ColumnId IsPublished = new(nameof(LineageEntity.IsPublished), Table);
  public static readonly ColumnId LanguagesText = new(nameof(LineageEntity.LanguagesText), Table);
  public static readonly ColumnId LineageId = new(nameof(LineageEntity.LineageId), Table);
  public static readonly ColumnId Malnutrition = new(nameof(LineageEntity.Malnutrition), Table);
  public static readonly ColumnId Mature = new(nameof(LineageEntity.Mature), Table);
  public static readonly ColumnId MetaDescription = new(nameof(LineageEntity.MetaDescription), Table);
  public static readonly ColumnId Name = new(nameof(LineageEntity.Name), Table);
  public static readonly ColumnId Names = new(nameof(LineageEntity.Names), Table);
  public static readonly ColumnId NormalWeight = new(nameof(LineageEntity.NormalWeight), Table);
  public static readonly ColumnId Obese = new(nameof(LineageEntity.Obese), Table);
  public static readonly ColumnId Overweight = new(nameof(LineageEntity.Overweight), Table);
  public static readonly ColumnId ParentId = new(nameof(LineageEntity.ParentId), Table);
  public static readonly ColumnId ParentUid = new(nameof(LineageEntity.ParentUid), Table);
  public static readonly ColumnId SizeCategory = new(nameof(LineageEntity.SizeCategory), Table);
  public static readonly ColumnId SizeRoll = new(nameof(LineageEntity.SizeRoll), Table);
  public static readonly ColumnId Skinny = new(nameof(LineageEntity.Skinny), Table);
  public static readonly ColumnId Slug = new(nameof(LineageEntity.Slug), Table);
  public static readonly ColumnId SlugNormalized = new(nameof(LineageEntity.SlugNormalized), Table);
  public static readonly ColumnId Summary = new(nameof(LineageEntity.Summary), Table);
  public static readonly ColumnId Swim = new(nameof(LineageEntity.Swim), Table);
  public static readonly ColumnId Venerable = new(nameof(LineageEntity.Venerable), Table);
  public static readonly ColumnId Walk = new(nameof(LineageEntity.Walk), Table);
}

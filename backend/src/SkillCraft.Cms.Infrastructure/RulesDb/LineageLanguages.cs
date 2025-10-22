using Logitar.Data;
using SkillCraft.Cms.Infrastructure.Entities;

namespace SkillCraft.Cms.Infrastructure.RulesDb;

internal static class LineageLanguages
{
  public static readonly TableId Table = new(RulesContext.Schema, nameof(RulesContext.LineageLanguages), alias: null);

  public static readonly ColumnId LanguageId = new(nameof(LineageLanguageEntity.LanguageId), Table);
  public static readonly ColumnId LanguageUid = new(nameof(LineageLanguageEntity.LanguageUid), Table);
  public static readonly ColumnId LineageId = new(nameof(LineageLanguageEntity.LineageId), Table);
  public static readonly ColumnId LineageUid = new(nameof(LineageLanguageEntity.LineageUid), Table);
}

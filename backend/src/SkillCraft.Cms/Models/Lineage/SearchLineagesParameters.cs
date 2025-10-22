using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Lineages.Models;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Models.Lineage;

public record SearchLineagesParameters : SearchParameters
{
  [FromQuery(Name = "parent")]
  public Guid? ParentId { get; set; }

  [FromQuery(Name = "language")]
  public Guid? LanguageId { get; set; }

  [FromQuery(Name = "size")]
  public SizeCategory? SizeCategory { get; set; }

  public virtual SearchLineagesPayload ToPayload()
  {
    SearchLineagesPayload payload = new()
    {
      ParentId = ParentId,
      LanguageId = LanguageId,
      SizeCategory = SizeCategory
    };
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out LineageSort field))
      {
        payload.Sort.Add(new LineageSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

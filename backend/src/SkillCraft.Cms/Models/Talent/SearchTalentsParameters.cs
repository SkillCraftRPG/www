using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Talents.Models;

namespace SkillCraft.Cms.Models.Talent;

public record SearchTalentsParameters : SearchParameters
{
  [FromQuery(Name = "slug")]
  public List<string> Slugs { get; set; } = [];

  [FromQuery(Name = "tier")]
  public List<int> Tiers { get; set; } = [];

  [FromQuery(Name = "multiple")]
  public bool? AllowMultiplePurchases { get; set; }

  [FromQuery(Name = "skill")]
  public string? Skill { get; set; }

  [FromQuery(Name = "required")]
  public Guid? RequiredTalentId { get; set; }

  public virtual SearchTalentsPayload ToPayload()
  {
    SearchTalentsPayload payload = new()
    {
      AllowMultiplePurchases = AllowMultiplePurchases,
      Skill = Skill,
      RequiredTalentId = RequiredTalentId
    };
    payload.Slugs.AddRange(Slugs);
    payload.Tiers.AddRange(Tiers);
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out TalentSort field))
      {
        payload.Sort.Add(new TalentSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

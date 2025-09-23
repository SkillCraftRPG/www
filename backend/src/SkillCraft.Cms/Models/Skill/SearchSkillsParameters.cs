using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Skills.Models;

namespace SkillCraft.Cms.Models.Skill;

public record SearchSkillsParameters : SearchParameters
{
  public virtual SearchSkillsPayload ToPayload()
  {
    SearchSkillsPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out SkillSort field))
      {
        payload.Sort.Add(new SkillSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

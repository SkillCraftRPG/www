using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Educations.Models;

namespace SkillCraft.Cms.Models.Education;

public record SearchEducationsParameters : SearchParameters
{
  public virtual SearchEducationsPayload ToPayload()
  {
    SearchEducationsPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out EducationSort field))
      {
        payload.Sort.Add(new EducationSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

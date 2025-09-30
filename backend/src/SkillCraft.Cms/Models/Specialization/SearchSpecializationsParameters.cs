using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Specializations.Models;

namespace SkillCraft.Cms.Models.Specialization;

public record SearchSpecializationsParameters : SearchParameters
{
  public virtual SearchSpecializationsPayload ToPayload()
  {
    SearchSpecializationsPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out SpecializationSort field))
      {
        payload.Sort.Add(new SpecializationSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

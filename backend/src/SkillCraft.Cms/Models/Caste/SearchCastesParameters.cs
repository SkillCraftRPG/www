using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Castes.Models;

namespace SkillCraft.Cms.Models.Caste;

public record SearchCastesParameters : SearchParameters
{
  public virtual SearchCastesPayload ToPayload()
  {
    SearchCastesPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out CasteSort field))
      {
        payload.Sort.Add(new CasteSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

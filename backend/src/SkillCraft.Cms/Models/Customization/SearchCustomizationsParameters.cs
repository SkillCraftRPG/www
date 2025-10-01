using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Customizations.Models;
using SkillCraft.Contracts;

namespace SkillCraft.Cms.Models.Customization;

public record SearchCustomizationsParameters : SearchParameters
{
  [FromQuery(Name = "type")]
  public CustomizationKind? Kind { get; set; }

  public virtual SearchCustomizationsPayload ToPayload()
  {
    SearchCustomizationsPayload payload = new()
    {
      Kind = Kind
    };
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out CustomizationSort field))
      {
        payload.Sort.Add(new CustomizationSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

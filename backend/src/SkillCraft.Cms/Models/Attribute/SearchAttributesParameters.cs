using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Attributes.Models;

namespace SkillCraft.Cms.Models.Attribute;

public record SearchAttributesParameters : SearchParameters
{
  public virtual SearchAttributesPayload ToPayload()
  {
    SearchAttributesPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out AttributeSort field))
      {
        payload.Sort.Add(new AttributeSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

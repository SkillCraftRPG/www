using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using SkillCraft.Cms.Core.Scripts.Models;

namespace SkillCraft.Cms.Models.Script;

public record SearchScriptsParameters : SearchParameters
{
  public virtual SearchScriptsPayload ToPayload()
  {
    SearchScriptsPayload payload = new();
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out ScriptSort field))
      {
        payload.Sort.Add(new ScriptSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

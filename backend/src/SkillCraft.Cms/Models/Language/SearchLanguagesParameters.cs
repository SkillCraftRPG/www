using Krakenar.Contracts.Search;
using Krakenar.Web.Models.Search;
using Microsoft.AspNetCore.Mvc;
using SkillCraft.Cms.Core.Languages.Models;

namespace SkillCraft.Cms.Models.Language;

public record SearchLanguagesParameters : SearchParameters
{
  [FromQuery(Name = "script")]
  public Guid? ScriptId { get; set; }

  public virtual SearchLanguagesPayload ToPayload()
  {
    SearchLanguagesPayload payload = new()
    {
      ScriptId = ScriptId
    };
    Fill(payload);

    foreach (SortOption item in ((SearchPayload)payload).Sort)
    {
      if (Enum.TryParse(item.Field, out LanguageSort field))
      {
        payload.Sort.Add(new LanguageSortOption(field, item.IsDescending));
      }
    }

    return payload;
  }
}

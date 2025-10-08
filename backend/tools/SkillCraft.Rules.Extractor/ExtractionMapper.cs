using SkillCraft.Cms.Infrastructure.Entities;
using SkillCraft.Rules.Extractor.Models;

namespace SkillCraft.Rules.Extractor;

internal static class ExtractionMapper
{
  public static AttributeDto ToAttribute(AttributeEntity source)
  {
    AttributeDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Category = source.Category,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    return destination;
  }

  public static CustomizationDto ToCustomization(CustomizationEntity source)
  {
    CustomizationDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Kind = source.Kind,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    return destination;
  }

  public static RelationshipDto ToRelationship(AttributeEntity attribute) => new(attribute.Slug, attribute.Name, attribute.IsPublished, attribute.Id);

  public static SkillDto ToSkill(SkillEntity source)
  {
    SkillDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Value = source.Value,
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };

    if (source.Attribute is not null)
    {
      destination.Attribute = ToRelationship(source.Attribute);
    }
    else if (source.AttributeId.HasValue)
    {
      throw new ArgumentException("The attribute is required.", nameof(source));
    }

    return destination;
  }

  public static StatisticDto ToStatistic(StatisticEntity source)
  {
    if (source.Attribute is null)
    {
      throw new ArgumentException("The attribute is required.", nameof(source));
    }

    StatisticDto destination = new()
    {
      Id = source.Id,
      IsPublished = source.IsPublished,
      Slug = source.Slug,
      Name = source.Name,
      Value = source.Value,
      Attribute = ToRelationship(source.Attribute),
      Summary = source.Summary,
      MetaDescription = source.MetaDescription,
      Description = source.Description
    };
    return destination;
  }
}

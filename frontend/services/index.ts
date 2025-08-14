import type {
  Attribute,
  AttributeCategory,
  Customization,
  CustomizationKind,
  GameAttribute,
  GameSkill,
  GameStatistic,
  Skill,
  Statistic,
  Talent,
} from "~/types/game";

export function mapAttribute(attribute: any): Attribute {
  return {
    ...attribute,
    value: attribute.value as GameAttribute,
    category: attribute.category ? (attribute.category as AttributeCategory) : undefined,
    statistics: [],
    skills: [],
  };
}

export function mapCustomization(customization: any): Customization {
  return {
    ...customization,
    kind: customization.kind as CustomizationKind,
  };
}

export function mapSkill(skill: any): Skill {
  return {
    ...skill,
    value: skill.value as GameSkill,
  };
}

export function mapStatistic(statistic: any): Statistic {
  return {
    ...statistic,
    value: statistic.value as GameStatistic,
  };
}

export function mapTalent(talent: any): Talent {
  return {
    ...talent,
    requiringTalents: [],
  };
}

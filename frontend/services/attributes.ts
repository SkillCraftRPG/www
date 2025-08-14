import attributesData from "~/assets/data/attributes.json";
import skillsData from "~/assets/data/skills.json";
import statisticsData from "~/assets/data/statistics.json";
import type { Attribute } from "~/types/game";
import { mapAttribute, mapSkill, mapStatistic } from ".";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetAttributeOptions = {
  statistics?: boolean;
  skills?: boolean;
};
export function getAttribute(idOrSlug: string, options?: GetAttributeOptions): Attribute | undefined {
  options ??= {};

  const data = attributesData.find((attribute) => areEqual(attribute.id, idOrSlug) || areEqual(attribute.slug, idOrSlug));
  if (!data) {
    return;
  }
  const attribute: Attribute = mapAttribute(data);

  if (options.statistics) {
    attribute.statistics = statisticsData.filter(({ attributeId }) => attributeId === attribute.id).map(mapStatistic);
  }
  if (options.skills) {
    attribute.skills = skillsData.filter(({ attributeId }) => attributeId === attribute.id).map(mapSkill);
  }

  return attribute;
}

type GetAttributesOptions = {
  statistics?: boolean;
  skills?: boolean;
};
export function getAttributes(options?: GetAttributesOptions): Attribute[] {
  options ??= {};

  const attributes: Attribute[] = attributesData.map(mapAttribute);
  const index: Map<string, Attribute> = new Map(attributes.map((attribute) => [attribute.id, attribute]));

  if (options.statistics) {
    statisticsData.forEach((statistic) => {
      const attribute: Attribute | undefined = index.get(statistic.attributeId);
      if (attribute) {
        attribute.statistics.push(mapStatistic(statistic));
      }
    });
  }
  if (options.skills) {
    skillsData.forEach((skill) => {
      if (skill.attributeId) {
        const attribute: Attribute | undefined = index.get(skill.attributeId);
        if (attribute) {
          attribute.skills.push(mapSkill(skill));
        }
      }
    });
  }

  return attributes;
}

import attributesData from "~/assets/data/attributes.json";
import skillsData from "~/assets/data/skills.json";
import type { Attribute, Skill } from "~/types/game";
import { mapAttribute, mapSkill } from ".";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetSkillOptions = {
  attribute?: boolean;
};
export function getSkill(idOrSlug: string, options?: GetSkillOptions): Skill | undefined {
  options ??= {};

  const data = skillsData.find((skill) => areEqual(skill.id, idOrSlug) || areEqual(skill.slug, idOrSlug));
  if (!data) {
    return undefined;
  }
  const skill: Skill = mapSkill(data);

  if (options.attribute && skill.attributeId) {
    const attribute = attributesData.find(({ id }) => id === skill.attributeId);
    if (attribute) {
      skill.attribute = mapAttribute(attribute);
    }
  }

  return skill;
}

type GetSkillsOptions = {
  attribute?: boolean;
};
export function getSkills(options?: GetSkillsOptions): Skill[] {
  options ??= {};

  const skills: Skill[] = skillsData.map(mapSkill);

  if (options.attribute) {
    const attributes: Map<string, Attribute> = new Map(attributesData.map((attribute) => [attribute.id, mapAttribute(attribute)]));
    skills.forEach((skill) => {
      if (skill.attributeId) {
        skill.attribute = attributes.get(skill.attributeId);
      }
    });
  }

  return skills;
}

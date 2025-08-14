import castesData from "~/assets/data/castes.json";
import type { Caste, Skill } from "~/types/game";
import { getSkill, getSkills } from "./skills";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetCasteOptions = {
  skill?: boolean;
};
export function getCaste(idOrSlug: string, options?: GetCasteOptions): Caste | undefined {
  options ??= {};

  const data = castesData.find((caste) => areEqual(caste.id, idOrSlug) || areEqual(caste.slug, idOrSlug));
  if (!data) {
    return undefined;
  }
  const caste: Caste = data;

  if (options.skill) {
    caste.skill = getSkill(caste.skillId, { attribute: true });
  }

  return caste;
}

type GetCastesOptions = {
  skill?: boolean;
};
export function getCastes(options?: GetCastesOptions): Caste[] {
  options ??= {};

  const castes: Caste[] = castesData;

  if (options.skill) {
    const skills: Map<string, Skill> = new Map(getSkills().map((skill) => [skill.id, skill]));
    castes.forEach((caste) => {
      if (caste.skillId) {
        caste.skill = skills.get(caste.skillId);
      }
    });
  }

  return castes;
}

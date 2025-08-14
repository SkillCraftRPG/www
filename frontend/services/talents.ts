import talentsData from "~/assets/data/talents.json";
import type { Skill, Talent } from "~/types/game";
import { getSkill, getSkills } from "./skills";
import { mapTalent } from ".";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetTalentOptions = { requiredTalent?: boolean; skill?: boolean };
export function getTalent(idOrSlug: string, options?: GetTalentOptions): Talent | undefined {
  options ??= {};

  const data = talentsData.find((talent) => areEqual(talent.id, idOrSlug) || areEqual(talent.slug, idOrSlug));
  if (!data) {
    return;
  }
  const talent: Talent = mapTalent(data);

  if (options.requiredTalent && talent.requiredTalentId) {
    talent.requiredTalent = getTalent(talent.requiredTalentId);
  }
  if (options.skill && talent.skillId) {
    talent.skill = getSkill(talent.skillId, { attribute: true });
  }

  return talent;
}

type GetTalentsOptions = { requiredTalent?: boolean; skill?: boolean };
export function getTalents(options?: GetTalentsOptions): Talent[] {
  options ??= {};

  const talents: Talent[] = talentsData.map(mapTalent);

  if (options.requiredTalent) {
    const index: Map<string, Talent> = new Map(talents.map((talent) => [talent.id, talent]));
    talents.forEach((talent) => {
      if (talent.requiredTalentId) {
        talent.requiredTalent = index.get(talent.requiredTalentId);
      }
    });
  }
  if (options.skill) {
    const skills: Map<string, Skill> = new Map(getSkills().map((skill) => [skill.id, skill]));
    talents.forEach((talent) => {
      if (talent.skillId) {
        talent.skill = skills.get(talent.skillId);
      }
    });
  }

  return talents;
}

import educationsData from "~/assets/data/educations.json";
import type { Education, Skill } from "~/types/game";
import { getSkill, getSkills } from "./skills";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetEducationOptions = {
  skill?: boolean;
};
export function getEducation(idOrSlug: string, options?: GetEducationOptions): Education | undefined {
  options ??= {};

  const data = educationsData.find((education) => areEqual(education.id, idOrSlug) || areEqual(education.slug, idOrSlug));
  if (!data) {
    return undefined;
  }
  const education: Education = data;

  if (options.skill) {
    education.skill = getSkill(education.skillId, { attribute: true });
  }

  return education;
}

type GetEducationsOptions = {
  skill?: boolean;
};
export function getEducations(options?: GetEducationsOptions): Education[] {
  options ??= {};

  const educations: Education[] = educationsData;

  if (options.skill) {
    const skills: Map<string, Skill> = new Map(getSkills().map((skill) => [skill.id, skill]));
    educations.forEach((education) => {
      if (education.skillId) {
        education.skill = skills.get(education.skillId);
      }
    });
  }

  return educations;
}

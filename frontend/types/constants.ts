import type { Actor } from "./game";

export const Brand: string = "SkillCraft";

export const Icons: Record<string, string> = {
  attribute: "fas fa-chart-simple",
  skill: "fas fa-kitchen-set",
  talent: "fas fa-code-branch",
};

export const System: Actor = {
  type: "System",
  id: "00000000-0000-0000-0000-000000000000",
  isDeleted: false,
  displayName: "Système",
};

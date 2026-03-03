import type { Actor } from "./game";

export const Icons: Record<string, string> = {
  attribute: "fas fa-chart-simple",
  skill: "fas fa-kitchen-set",
  talent: "fas fa-code-branch",
};

export const SpellCategories = {
  Animism: "ffed3a54-a461-4135-934c-7e4859d08e72",
  Divine: "d86fed43-66fa-4a52-9d83-a878196b83a8",
};

export const System: Actor = {
  type: "System",
  id: "00000000-0000-0000-0000-000000000000",
  isDeleted: false,
  displayName: "Système",
};

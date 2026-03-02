import type { Actor } from "./game";

export const Icons: Record<string, string> = {
  attribute: "fas fa-chart-simple",
  skill: "fas fa-kitchen-set",
  talent: "fas fa-code-branch",
};

export const SpellCategories = {
  Animism: "57852c8a-1baa-4e67-9a63-feff494ce5bc",
  Divine: "6bd0b0bf-a81e-4abb-a77c-6801c02a0bf4",
};

export const System: Actor = {
  type: "System",
  id: "00000000-0000-0000-0000-000000000000",
  isDeleted: false,
  displayName: "Système",
};

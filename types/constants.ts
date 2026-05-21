import type { Actor } from "./game";

export const Icons: Record<string, string> = {
  attribute: "fas fa-chart-simple",
  skill: "fas fa-kitchen-set",
  talent: "fas fa-code-branch",
};

export const SpellCategories = {
  Abjuration: "b9399240-ec40-47c9-b709-8f515f7984e6",
  Animism: "ffed3a54-a461-4135-934c-7e4859d08e72",
  Astromancy: "1101ee27-ddf6-4be3-b7e8-e5673dd8aed0",
  Divination: "69ac2700-0c05-4b85-81d5-8077ca6de3bc",
  Divine: "d86fed43-66fa-4a52-9d83-a878196b83a8",
  Elementalism: "5cb39d5d-e826-456f-946a-408a007857fb",
  Enchantment: "9bfed560-3230-456d-aa5b-1efe1e5ce24a",
  Invocation: "962a99ed-bc33-4eb1-8f0e-f21363d08ac5",
  Transmutation: "59a3b5eb-79c7-46fc-b702-60a978307b46",
};

export const System: Actor = {
  type: "System",
  id: "00000000-0000-0000-0000-000000000000",
  isDeleted: false,
  displayName: "Système",
};

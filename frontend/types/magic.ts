import type { Aggregate } from "./game";

export type DurationUnit = "Day" | "Hour" | "Minute" | "Month " | "Round" | "Second" | "Week " | "Year";

export type Spell = Aggregate & {
  slug: string;
  name: string;
  tier: number;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  abilities: SpellAbility[];
};

export type SpellAbility = {
  level: number;
  name?: string | null;
  casting: SpellCasting;
  duration?: SpellDuration | null;
  range: number;
  components: SpellComponents;
  description?: string | null;
};

export type SpellCasting = {
  time: string;
  ritual: boolean;
};

export type SpellComponents = {
  focus?: string | null;
  material?: string | null;
  somatic: boolean;
  verbal: boolean;
};

export type SpellDuration = {
  value: number;
  unit: DurationUnit;
  concentration: boolean;
};

// TODO(fpion): refactor units for PascalCase.

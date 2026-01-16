import type { Aggregate } from "./game";

export type DurationUnit = "Day" | "Hour" | "Minute" | "Month " | "Round" | "Second" | "Week " | "Year";

export type SpellNew = Aggregate & {
  slug: string;
  name: string;
  tier: number;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  levels: SpellLevel[];
}; // TODO(fpion): rename this class

export type SpellCasting = {
  time: string;
  isRitual: boolean;
};

export type SpellComponents = {
  isSomatic: boolean;
  isVerbal: boolean;
  focus?: string | null;
  material?: string | null;
};

export type SpellDuration = {
  value: number;
  unit: DurationUnit;
  isConcentration: boolean;
};

export type SpellLevel = {
  level: number;
  name?: string | null;
  casting: SpellCasting;
  duration?: SpellDuration | null;
  range: number;
  components: SpellComponents;
  description?: string | null;
};

// TODO(fpion): LEGACY; remove the following
export type Spell = {
  id: string;
  slug: string;
  name: string;
  tier: number;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  effects: SpellEffect[];
};

export type SpellEffect = {
  level: number;
  name?: string | null;
  castingTime: string;
  duration?: number | null;
  concentration: boolean;
  range: number;
  focus?: string | null;
  material?: string | null;
  somatic: boolean;
  verbal: boolean;
  description?: string | null;
};

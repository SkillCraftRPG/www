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

import type { Aggregate, Skill } from "./game";

export type Talent = Aggregate & {
  slug: string;
  name: string;
  tier: number;
  allowMultiplePurchases: boolean;
  skill?: Skill | null;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
  requiredTalent?: Talent | null;
  requiringTalents: Talent[];
};

export type TalentNode = {
  id: string;
  parent?: string | null;
  children: string[];
  tier: number;
  slug: string;
  name: string;
  allowMultiplePurchases: boolean;
  skill?: string | null;
  summary?: string | null;
};

export type TalentTree = {
  nodes: TalentNode[];
};

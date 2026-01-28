import type { Aggregate, Feature, Talent } from "./game";

export type Specialization = Aggregate & {
  slug: string;
  name: string;
  tier: number;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  requirements: Requirements;
  options: Options;
  reservedTalent?: ReservedTalent | null;
};

export type Options = {
  talents: Talent[];
  other: string[];
};

export type Requirements = {
  talent?: Talent | null;
  other: string[];
};

export type ReservedTalent = {
  name: string;
  description: string[];
  discountedTalents: Talent[];
  features: Feature[];
};

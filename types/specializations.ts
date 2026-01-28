import type { Aggregate, Feature, Talent } from "./game";

export type Doctrine = {
  name: string;
  description: string[];
  discountedTalents: Talent[];
  features: Feature[];
};

export type Specialization = Aggregate & {
  slug: string;
  name: string;
  tier: number;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
  requirements: Requirements;
  options: Options;
  doctrine?: Doctrine | null;
};

export type Options = {
  talents: Talent[];
  other: string[];
};

export type Requirements = {
  talent?: Talent | null;
  other: string[];
};

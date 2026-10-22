import type { Aggregate, Feature } from "./game";
import type { Talent } from "./talents";

export type Doctrine = {
  name: string;
  description: string[];
  discountedTalents: Talent[];
  features: Feature[];
};

export type Options = {
  talents: Talent[];
  other: string[];
};

export type Requirements = {
  talent?: Talent | null;
  other: string[];
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

export type SpecializationNode = {
  id: string;
  parents: string[];
  children: string[];
  tier: number;
  slug: string;
  name: string;
  doctrine?: string | null;
  summary?: string | null;
};

export type SpecializationTree = {
  nodes: SpecializationNode[];
};

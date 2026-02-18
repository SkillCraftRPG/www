import type { Aggregate, Feature, Language, SizeCategory } from "./game";

export type Age = {
  teenager: number;
  adult: number;
  mature: number;
  venerable: number;
};

export type Ethnicity = LineageBase & {
  species?: Species | null;
};

export type Languages = {
  items: Language[];
  extra: number;
  text?: string | null;
};

export type Lineage = LineageBase & {
  parent?: Lineage | null;
  children: Lineage[];
};

export type LineageBase = Aggregate & {
  slug: string;
  name: string;
  languages: Languages;
  names: Names;
  speeds: Speeds;
  size: Size;
  weight: Weight;
  age: Age;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent: LineageContent;
  features: Feature[];
};

export type LineageContent = {
  overview?: string | null;
  morphology?: string | null;
  psychology?: string | null;
  culture?: string | null;
  history?: string | null;
  geography?: string | null;
  politics?: string | null;
  relations?: string | null;
};

export type NameCategory = {
  category: string;
  values: string[];
};

export type Names = {
  family: string[];
  female: string[];
  male: string[];
  unisex: string[];
  custom: NameCategory[];
  text?: string | null;
};

export type Size = {
  category: SizeCategory;
  roll?: string | null;
};

export type Species = LineageBase & {
  ethnicities: Ethnicity[];
};

export type Speeds = {
  walk: number;
  climb: number;
  swim: number;
  fly: number;
  hover: boolean;
  burrow: number;
};

export type Weight = {
  malnutrition?: string | null;
  skinny?: string | null;
  normal?: string | null;
  overweight?: string | null;
  obese?: string | null;
};

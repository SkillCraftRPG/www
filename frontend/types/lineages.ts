import type { Aggregate, Feature, Language, SizeCategory } from "./game";

export type Age = {
  teenager: number;
  adult: number;
  mature: number;
  venerable: number;
};

export type Languages = {
  items: Language[];
  extra: number;
  text?: string | null;
};

export type Lineage = Aggregate & {
  slug: string;
  name: string;
  languages: Languages;
  names: Names;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  speeds: Speeds;
  size: Size;
  weight: Weight;
  age: Age;
  parent?: Lineage | null;
  children: Lineage[];
  features: Feature[];
};

export type NameCategory = {
  category: string;
  values: string[];
};

export type Names = {
  text?: string | null;
  family: string[];
  female: string[];
  male: string[];
  unisex: string[];
  custom: NameCategory[];
};

export type Size = {
  category: SizeCategory;
  roll?: string | null;
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

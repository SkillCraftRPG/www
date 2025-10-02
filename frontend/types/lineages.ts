import type { Feature } from "./game";

export type Age = {
  teenager: number;
  adult: number;
  mature: number;
  venerable: number;
};

export type Languages = {
  text: string;
};

export type Lineage = {
  id: string;
  slug: string;
  name: string;
  summary?: string;
  metaDescription?: string;
  description?: string;
  traits: Feature[];
  languages: Languages;
  names: Names;
  speeds: Speeds;
  size: string;
  height: string;
  weight: Weight;
  age: Age;
};

export type Names = {
  text: string;
};

export type Speeds = {
  walk: number;
};

export type Weight = {
  malnutrition: string;
  skinny: string;
  normal: string;
  overweight: string;
  obese: string;
};

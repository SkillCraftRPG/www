export type Actions = {
  mandatory: number;
  optional: number;
  reaction: boolean;
};

export type Activity = {
  id: string;
  path: string;
  name: string;
  actions: Actions;
  threatening: boolean | "maybe";
  summary: string;
};

export type Actor = {
  realmId?: string | null;
  type: ActorType;
  id: string;
  isDeleted: boolean;
  displayName: string;
  emailAddress?: string | null;
  pictureUrl?: string | null;
};

export type ActorType = "System" | "ApiKey" | "User";

export type Age = {
  teenager: number;
  adult: number;
  mature: number;
  venerable: number;
};

export type Aggregate = {
  id: string;
  version: number;
  createdBy: Actor;
  createdOn: string;
  updatedBy: Actor;
  updatedOn: string;
};

export type Attribute = Aggregate & {
  slug: string;
  name: string;
  category?: AttributeCategory | null;
  value: GameAttribute;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  statistics: Statistic[];
  skills: Skill[];
};

export type AttributeCategory = "Mental" | "Physical";

export type Caste = Aggregate & {
  slug: string;
  name: string;
  wealthRoll?: string | null;
  skill?: Skill | null;
  feature?: Feature | null;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
};

export type Customization = Aggregate & {
  slug: string;
  name: string;
  kind: CustomizationKind;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
};

export type CustomizationKind = "Disability" | "Gift";

export type DamageType = "Bludgeoning" | "Piercing" | "Slashing";

export type Feature = {
  name: string;
  description?: string | null;
};

export type Education = Attribute & {
  slug: string;
  name: string;
  wealthMultiplier?: number | null;
  skill?: Skill | null;
  feature?: Feature | null;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
};

export type GameAttribute = "Dexterity" | "Health" | "Intellect" | "Senses" | "Vigor";

export type GameSkill =
  | "Acrobatics"
  | "Athletics"
  | "Crafting"
  | "Deception"
  | "Diplomacy"
  | "Discipline"
  | "Insight"
  | "Investigation"
  | "Knowledge"
  | "Linguistics"
  | "Medicine"
  | "Melee"
  | "Occultism"
  | "Orientation"
  | "Perception"
  | "Performance"
  | "Resistance"
  | "Stealth"
  | "Survival"
  | "Thievery";

export type GameStatistic = "Dodge" | "Encumbrance" | "Initiative" | "Learning" | "Power" | "Precision" | "Stamina" | "Stratagem" | "Strength" | "Vitality";

export type Languages = {
  text: string;
};

export type Lineage = {
  id: string;
  slug: string;
  name: string;
  summary: string;
  description: string;
  traits: Trait[];
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

export type SearchResults<T> = {
  items: T[];
  total: number;
};

export type SizeCategory = "Diminutive" | "Tiny" | "Small" | "Medium" | "Large" | "Huge" | "Gargantuan" | "Colossal";

export type Skill = Aggregate & {
  slug: string;
  name: string;
  attribute?: Attribute | null;
  value: GameSkill;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
};

export type Speeds = {
  walk: number;
};

export type Statistic = Aggregate & {
  slug: string;
  name: string;
  attribute: Attribute;
  value: GameStatistic;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
};

export type Talent = Aggregate & {
  slug: string;
  name: string;
  tier: number;
  allowMultiplePurchases: boolean;
  skill?: Skill | null;
  summary?: string | null;
  metaDescription?: string | null;
  description?: string | null;
  requiredTalent?: Talent | null;
  requiringTalents: Talent[];
};

export type Trait = {
  name: string;
  description: string;
};

export type Weight = {
  malnutrition: string;
  skinny: string;
  normal: string;
  overweight: string;
  obese: string;
};

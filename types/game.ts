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
  value: GameAttribute;
  category?: AttributeCategory | null;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
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
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
};

export type Customization = Aggregate & {
  slug: string;
  name: string;
  kind: CustomizationKind;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
};

export type CustomizationKind = "Disability" | "Gift";

export type DamageType = "Bludgeoning" | "Piercing" | "Slashing";

export type Feature = Aggregate & {
  key: string;
  name: string;
  htmlContent?: string | null;
};

export type Education = Aggregate & {
  slug: string;
  name: string;
  wealthMultiplier?: number | null;
  skill?: Skill | null;
  feature?: Feature | null;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
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

export type HerbalismCategory = "Basic" | "Advanced";

export type Language = Aggregate & {
  slug: string;
  name: string;
  script?: Script | null;
  typicalSpeakers?: string | null;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
};

export type Poison = {
  id: string;
  slug: string;
  name: string;
  category: HerbalismCategory;
  trigger: PoisonTrigger;
  description: string;
};

export type PoisonTrigger = "Contact" | "Ingested" | "Inhaled" | "Injury";

export type Remedy = {
  id: string;
  slug: string;
  name: string;
  category: HerbalismCategory;
  description: string;
};

export type Script = Aggregate & {
  slug: string;
  name: string;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
  languages: Language[];
};

export type SearchResults<T> = {
  items: T[];
  total: number;
};

export type SizeCategory = "Diminutive" | "Tiny" | "Small" | "Medium" | "Large" | "Huge" | "Gargantuan" | "Colossal";

export type Skill = Aggregate & {
  slug: string;
  name: string;
  value: GameSkill;
  attribute?: Attribute | null;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
  talents: Talent[];
};

export type Statistic = Aggregate & {
  slug: string;
  name: string;
  value: GameStatistic;
  attribute: Attribute;
  metaDescription?: string | null;
  summary?: string | null;
  htmlContent?: string | null;
};

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

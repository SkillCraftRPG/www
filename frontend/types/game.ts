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
  value: GameAttribute;
  name: string;
  summary?: string | null;
  description?: string | null;
  skills: Skill[];
  statistics: Statistic[];
};

export type Customization = Aggregate & {
  slug: string;
  kind: CustomizationKind;
  name: string;
  summary?: string | null;
  description?: string | null;
};

export type CustomizationKind = "Disability" | "Gift";

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

export type SearchResults<T> = {
  items: T[];
  total: number;
};

export type Skill = Aggregate & {
  slug: string;
  value: GameSkill;
  name: string;
  summary?: string | null;
  description?: string | null;
  attribute?: Attribute | null;
};

export type Statistic = Aggregate & {
  slug: string;
  value: GameStatistic;
  name: string;
  summary?: string | null;
  description?: string | null;
  attribute?: Attribute | null;
};

export type Talent = Aggregate & {
  slug: string;
  tier: number;
  name: string;
  summary?: string | null;
  description?: string | null;
  allowMultiplePurchases: boolean;
  skill?: Skill | null;
  requiredTalent?: Talent | null;
  requiringTalents: Talent[];
};

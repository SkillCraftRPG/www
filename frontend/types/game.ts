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
};

export type GameAttribute = "Dexterity" | "Health" | "Intellect" | "Senses" | "Vigor";

export type SearchResults<T> = {
  items: T[];
  total: number;
};

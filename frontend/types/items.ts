import type { DamageType } from "./game";

export type Ammunition = Item & {
  weapons: string;
  container: Container;
};

export type Armor = Item & {
  category: string;
  defense: number;
  resistance: number;
  properties: string[];
};

export type Container = Item & {
  volume?: string;
  capacity: number;
};

export type Item = {
  id: string;
  slug: string;
  name: string;
  price: number;
  weight: number;
  description: string;
};

export type SelectionItem = Item & {
  quantity: number;
};

export type Shield = Item & {
  category: string;
  defense: number;
  resistance: number;
  properties: string[];
};

export type Weapon = Item & {
  category: WeaponCategory;
  damage?: WeaponDamage | null;
  ammunition?: WeaponRange | null;
  reload?: number | null;
  special?: string | null;
  thrown?: WeaponRange | null;
  properties: WeaponProperty[];
};

export type WeaponCategory = "Simple" | "Martial";

export type WeaponDamage = {
  roll: string;
  versatile?: string | null;
  type: DamageType;
};

export type WeaponProperty = "Heavy" | "Finesse" | "Light" | "Loading" | "Reach" | "TwoHanded";

export type WeaponRange = {
  standard: number;
  long: number;
};

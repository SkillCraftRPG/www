export type Armor = Item & {
  category: string;
  defense: number;
  resistance: number;
  properties: string[];
};

export type Container = Item & {
  volume: string;
  capacity: number;
};

export type Item = {
  id: string;
  name: string;
  price: number;
  weight: number;
  description: string;
};

export type Range = {
  normal: number;
  long: number;
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
  category: string;
  range: string;
  damage?: string;
  properties: string[];
  ammunition?: Range;
  reload?: number;
  special?: string;
  thrown?: Range;
  versatile?: string;
};

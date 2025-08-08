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

export type SelectionItem = Item & {
  quantity: number;
};

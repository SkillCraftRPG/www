export type ProgressItem = {
  key: string;
  name?: string;
  children?: ProgressItem[];
  updatedOn?: string;
  value?: number;
  weight?: number;
};

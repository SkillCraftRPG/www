import type { Aggregate } from "./game";

export type Article = Aggregate & {
  slug: string;
  title: string;
  metaDescription?: string | null;
  htmlContent?: string | null;
  collection: Collection;
  parent?: Article | null;
  children: Article[];
};

export type Collection = Aggregate & {
  slug: string;
  name: string;
  metaDescription?: string | null;
  htmlContent?: string | null;
  articles: Article[];
};

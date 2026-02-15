import type { Aggregate } from "./game";

export type Quest = {
  id: string;
  title: string;
  group?: QuestGroup | null;
  grantedLevels: number;
  progressRatio: number;
  htmlContent?: string | null;
  completedEntries?: string | null;
  activeEntries?: string | null;
};

export type QuestGroup = {
  id: string;
  name: string;
};

export type QuestLog = Aggregate & {
  slug: string;
  title: string;
  metaDescription?: string | null;
  htmlContent?: string | null;
  quests: Quest[];
};

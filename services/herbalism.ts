import poisonData from "~/assets/data/poisons.json";
import remedyData from "~/assets/data/remedies.json";
import type { Poison, HerbalismCategory, PoisonTrigger, Remedy } from "~/types/game";

export function getPoisons(): Poison[] {
  return poisonData.map((poison) => ({
    ...poison,
    category: poison.category as HerbalismCategory,
    trigger: poison.trigger as PoisonTrigger,
  }));
}

export function getRemedies(): Remedy[] {
  return remedyData.map((remedy) => ({
    ...remedy,
    category: remedy.category as HerbalismCategory,
  }));
}

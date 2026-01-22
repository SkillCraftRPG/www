import poisonData from "~/assets/data/poisons.json";
import type { Poison, PoisonCategory, PoisonTrigger } from "~/types/game";

export function getPoisons(): Poison[] {
  return poisonData.map((poison) => ({
    ...poison,
    category: poison.category as PoisonCategory,
    trigger: poison.trigger as PoisonTrigger,
  }));
}

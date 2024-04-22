import progress from "@/assets/data/progress.json";
import type { ProgressItem } from "@/types";

export async function readProgress(): Promise<ProgressItem> {
  return progress;
}

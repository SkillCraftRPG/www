import type { SizeCategory } from "~/types/game";

export default function (size: SizeCategory): number {
  switch (size) {
    case "Diminutive":
      return 0.25;
    case "Tiny":
      return 0.5;
    case "Large":
      return 2;
    case "Huge":
      return 3;
    case "Gargantuan":
      return 4;
    case "Colossal":
      return 8;
  }
  return 1;
}

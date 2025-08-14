import customizationsData from "~/assets/data/customizations.json";
import type { Customization } from "~/types/game";
import { mapCustomization } from ".";

function areEqual(a: string, b: string): boolean {
  return a.trim().toLowerCase() === b.trim().toLowerCase();
}

type GetCustomizationOptions = {};
export function getCustomization(idOrSlug: string, options?: GetCustomizationOptions): Customization | undefined {
  options ??= {};

  const data = customizationsData.find((customization) => areEqual(customization.id, idOrSlug) || areEqual(customization.slug, idOrSlug));
  if (!data) {
    return;
  }
  const customization: Customization = mapCustomization(data);
  return customization;
}

type GetCustomizationsOptions = {};
export function getCustomizations(options?: GetCustomizationsOptions): Customization[] {
  options ??= {};

  const customizations: Customization[] = customizationsData.map(mapCustomization);
  return customizations;
}

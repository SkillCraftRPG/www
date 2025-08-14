import ammunitionData from "~/assets/data/items/ammunition.json";
import weaponsData from "~/assets/data/items/weapons.json";
import type { DamageType } from "~/types/game";
import type { Ammunition, Weapon, WeaponCategory, WeaponProperty } from "~/types/items";

export function getAmmunition(): Ammunition[] {
  return ammunitionData;
}

export function getWeapons(): Weapon[] {
  return weaponsData.map((weapon) => ({
    ...weapon,
    category: weapon.category as WeaponCategory,
    damage: weapon.damage ? { ...weapon.damage, type: weapon.damage.type as DamageType } : undefined,
    properties: weapon.properties as WeaponProperty[],
  }));
}

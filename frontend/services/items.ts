import ammunitionData from "~/assets/data/items/ammunition.json";
import shieldsData from "~/assets/data/items/shields.json";
import weaponsData from "~/assets/data/items/weapons.json";
import type { DamageType } from "~/types/game";
import type { Ammunition, Shield, ShieldProperty, Weapon, WeaponCategory, WeaponProperty } from "~/types/items";

export function getAmmunition(): Ammunition[] {
  return ammunitionData;
}

export function getShields(): Shield[] {
  return shieldsData.map((shield) => ({
    ...shield,
    properties: shield.properties as ShieldProperty[],
  }));
}

export function getWeapons(): Weapon[] {
  return weaponsData.map((weapon) => ({
    ...weapon,
    category: weapon.category as WeaponCategory,
    damage: weapon.damage ? { ...weapon.damage, type: weapon.damage.type as DamageType } : undefined,
    properties: weapon.properties as WeaponProperty[],
  }));
}

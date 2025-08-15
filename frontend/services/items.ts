import ammunitionData from "~/assets/data/items/ammunition.json";
import armorData from "~/assets/data/items/armor.json";
import clothingData from "~/assets/data/items/clothing.json";
import containersData from "~/assets/data/items/containers.json";
import generalData from "~/assets/data/items/general.json";
import shieldsData from "~/assets/data/items/shields.json";
import weaponsData from "~/assets/data/items/weapons.json";
import type { DamageType } from "~/types/game";
import type { Ammunition, Armor, ArmorCategory, ArmorProperty, Item, Shield, ShieldProperty, Weapon, WeaponCategory, WeaponProperty } from "~/types/items";

export function getAmmunition(): Ammunition[] {
  return ammunitionData;
}

export function getArmor(): Armor[] {
  return armorData.map((armor) => ({
    ...armor,
    category: armor.category as ArmorCategory,
    properties: armor.properties as ArmorProperty[],
  }));
}

export function getClothingItems(): Item[] {
  return clothingData;
}

export function getContainers(): Item[] {
  return containersData;
}

export function getGeneralItems(): Item[] {
  return generalData;
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

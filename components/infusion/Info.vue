<template>
  <div>
    <h3 :id="id" class="h5">{{ name }}</h3>
    <div class="d-flex flex-wrap gap-2 mb-2">
      <slot name="item">
        <InfusionArmor v-if="isArmor" :text="armorText" />
        <InfusionWeapon v-if="isWeapon" :property="weaponProperty" :text="weaponText" />
      </slot>
      <InfusionAttunement v-if="isAttunementRequired" />
    </div>
    <slot></slot>
  </div>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

const { parseBoolean } = parsingUtils;

const props = withDefaults(
  defineProps<{
    armor?: boolean | string;
    attunement?: boolean | string;
    id: string;
    name: string;
    weapon?: boolean | string;
  }>(),
  {
    attunement: false,
  },
);

const isAttunementRequired = computed<boolean>(() => parseBoolean(props.attunement) ?? false);

const armorText = computed<string | undefined>(() => {
  const parsed: boolean | undefined = parseBoolean(props.armor);
  if (typeof parsed === "boolean") {
    return undefined;
  }
  return typeof props.armor === "string" && props.armor.length ? props.armor : undefined;
});
const isArmor = computed<boolean>(() => Boolean(parseBoolean(props.armor) || armorText.value));

const weaponProperty = computed<string | undefined>(() => {
  const parsed: boolean | undefined = parseBoolean(props.weapon);
  if (typeof parsed === "boolean") {
    return undefined;
  }
  return typeof props.weapon === "string" && props.weapon.length && props.weapon[0] === "#" ? props.weapon.substring(1) : undefined;
});
const weaponText = computed<string | undefined>(() => {
  const parsed: boolean | undefined = parseBoolean(props.weapon);
  if (typeof parsed === "boolean") {
    return undefined;
  }
  return typeof props.weapon === "string" && props.weapon.length && props.weapon[0] !== "#" ? props.weapon : undefined;
});
const isWeapon = computed<boolean>(() => Boolean(parseBoolean(props.weapon) || weaponProperty.value || weaponText.value));
</script>

<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Arme</th>
          <th scope="col" class="w-10">Prix (deniers)</th>
          <th scope="col" class="w-10">Poids (kg)</th>
          <th scope="col" class="w-10">Attaque</th>
          <th scope="col" class="w-15">Dégâts</th>
          <th scope="col" class="w-40">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="weapon in items" :key="weapon.id">
          <td>{{ weapon.name }}</td>
          <td>{{ $n(weapon.price, "price") }}</td>
          <td>{{ $n(weapon.weight, "weight") }}</td>
          <td>{{ formatAttack(weapon) }}</td>
          <td>
            <template v-if="weapon.damage">{{ formatDamage(weapon.damage) }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
          <td v-html="formatProperties(weapon)"></td>
        </tr>
      </tbody>
    </table>
    <h3 v-if="isMultiple" class="h5">Descriptions</h3>
    <h2 v-else class="h3">Descriptions</h2>
    <ul>
      <li v-for="weapon in items" :key="weapon.id">
        <strong>{{ weapon.name }}.</strong> {{ weapon.description }}
        <ul v-if="weapon.special">
          <li>
            <strong><font-awesome-icon icon="fas fa-flag" /> {{ $t("weapon.property.options.Special") }}.</strong> {{ weapon.special }}
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { parsingUtils, stringUtils } from "logitar-js";

import type { Weapon, WeaponDamage } from "~/types/items";

const { isNullOrWhiteSpace } = stringUtils;
const { parseBoolean } = parsingUtils;

const props = defineProps<{
  items: Weapon[];
  multiple?: boolean | string;
}>();

const isMultiple = computed<boolean>(() => parseBoolean(props.multiple) ?? false);

function formatAttack(weapon: Weapon): string {
  let attack: number = 2;
  if (weapon.properties.includes("Light")) {
    attack = 1;
  } else if (!isNullOrWhiteSpace(weapon.damage?.versatile ?? "")) {
    attack = 3;
  } else if (weapon.properties.includes("TwoHanded")) {
    attack = 4;
  }
  return $n(attack, "attack");
}

function formatDamage(damage: WeaponDamage): string {
  return [damage.roll, $t(`damage.type.options.${damage.type}`)].join(" ").toLowerCase();
}

function formatProperties(weapon: Weapon): string {
  const properties: string[] = weapon.properties.map((property) => $t(`weapon.property.options.${property}`));
  if (weapon.ammunition) {
    properties.push([$t("weapon.property.options.Ammunition"), `(${weapon.ammunition.standard}/${weapon.ammunition.long || "—"})`].join(" "));
  }
  if (weapon.reload && weapon.reload > 1) {
    properties.push([$t("weapon.property.options.Reload"), `(${weapon.reload})`].join(" "));
  }
  if (weapon.special) {
    properties.push($t("weapon.property.options.Special"));
  }
  if (weapon.thrown) {
    properties.push([$t("weapon.property.options.Thrown"), `(${weapon.thrown.standard}/${weapon.thrown.long})`].join(" "));
  }
  if (weapon.damage?.versatile) {
    properties.push([$t("weapon.property.options.Versatile"), `(${weapon.damage.versatile})`].join(" "));
  }
  if (!properties.length) {
    return `<span class="text-muted">—</span>`;
  }
  return properties.sort((a, b) => (a > b ? 1 : a < b ? -1 : 0)).join(", ");
}
</script>

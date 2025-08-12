<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Arme</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-10">Attaque</th>
          <th scope="col" class="w-15">Dégâts</th>
          <th scope="col" class="w-30">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="melee.length && ranged.length">
          <td colspan="6">
            <i>Armes de mêlée</i>
          </td>
        </tr>
        <tr v-for="weapon in melee" :key="weapon.id">
          <td>{{ weapon.name }}</td>
          <td>{{ $n(weapon.price, "price") }}</td>
          <td>{{ $n(weapon.weight, "weight") }}</td>
          <td>{{ formatAttack(weapon) }}</td>
          <td>{{ weapon.damage ?? "—" }}</td>
          <td>{{ formatProperties(weapon) }}</td>
        </tr>
        <tr v-if="melee.length && ranged.length">
          <td colspan="6">
            <i>Armes à distance</i>
          </td>
        </tr>
        <tr v-for="weapon in ranged" :key="weapon.id">
          <td>{{ weapon.name }}</td>
          <td>{{ $n(weapon.price, "price") }}</td>
          <td>{{ $n(weapon.weight, "weight") }}</td>
          <td>{{ formatAttack(weapon) }}</td>
          <td>{{ weapon.damage ?? "—" }}</td>
          <td>{{ formatProperties(weapon) }}</td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
    <ul>
      <li v-for="weapon in weapons" :key="weapon.id">
        <strong>{{ weapon.name }}.</strong> {{ weapon.description }}
        <ul v-if="weapon.special">
          <li>
            <strong><font-awesome-icon icon="fas fa-flag" /> Spéciale.</strong> {{ weapon.special }}
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils, stringUtils } from "logitar-js";

import type { Weapon } from "~/types/items";

const { isNullOrWhiteSpace, unaccent } = stringUtils;
const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Weapon[];
}>();

const weapons = computed<Weapon[]>(() => orderBy(props.items, "id"));

const melee = computed<Weapon[]>(() =>
  orderBy(
    props.items.filter(({ range }) => range === "Melee"),
    "id",
  ),
);
const ranged = computed<Weapon[]>(() =>
  orderBy(
    props.items.filter(({ range }) => range === "Ranged"),
    "id",
  ),
);

function formatAttack(weapon: Weapon): string {
  let attack: number = 2;
  const properties: string[] = weapon.properties.map((property) => unaccent(property.trim().toLowerCase()));
  if (properties.includes("legere")) {
    attack = 1;
  } else if (!isNullOrWhiteSpace(weapon.versatile)) {
    attack = 3;
  } else if (properties.includes("deux mains")) {
    attack = 4;
  }
  return $n(attack, "attack");
}

function formatProperties(weapon: Weapon): string {
  const properties: string[] = [...weapon.properties];
  if (weapon.ammunition) {
    properties.push(`Munition (${weapon.ammunition.normal}/${weapon.ammunition.long})`);
  }
  if (weapon.reload && weapon.reload > 1) {
    properties.push(`Barillet (${weapon.reload})`);
  }
  if (weapon.special) {
    properties.push("Spéciale");
  }
  if (weapon.thrown) {
    properties.push(`Jet (${weapon.thrown.normal}/${weapon.thrown.long})`);
  }
  if (weapon.versatile) {
    properties.push(`Versatile (${weapon.versatile})`);
  }
  if (!properties.length) {
    return "—";
  }
  return properties.sort((a, b) => (a > b ? 1 : a < b ? -1 : 0)).join(", ");
}
</script>

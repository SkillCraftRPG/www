<template>
  <div>
    <h2 class="h3">Physique</h2>
    <p v-if="age.adult && age.venerable">
      Ils atteignent l’âge adulte à {{ age.adult }} {{ $t("unit.Year", age.adult) }} et leur espérance de vie moyenne est de {{ age.venerable }}
      {{ $t("unit.Year", age.venerable) }}.
    </p>
    <table class="table table-striped text-center">
      <tbody>
        <tr>
          <th scope="row" :class="classes">Taille</th>
          <td :class="classes">
            <NuxtLink to="/regles/especes/taille">{{ $t(`size.category.options.${size.category}`) }}</NuxtLink>
          </td>
          <td v-if="size.roll" :class="classes">{{ size.roll }} {{ $t("unit.Centimeter", 100) }}</td>
        </tr>
        <tr v-if="minHeight">
          <th scope="row">Hauteur minimale</th>
          <td>{{ $n(minHeight, "decimal") }} {{ $t("unit.Meter", Math.floor(minHeight)) }}</td>
          <td>{{ minHeightImperial }}</td>
        </tr>
        <tr v-if="maxHeight">
          <th scope="row">Hauteur maximale</th>
          <td>{{ $n(maxHeight, "decimal") }} {{ $t("unit.Meter", Math.floor(maxHeight)) }}</td>
          <td>{{ maxHeightImperial }}</td>
        </tr>
        <tr v-if="minWeight">
          <th scope="row">Poids minimal</th>
          <td>{{ $n(minWeight, "weight") }} {{ $t("unit.Kilogram", Math.floor(minWeight)) }}</td>
          <td>{{ $n(minWeightImperial, "integer") }} {{ $t("unit.Pound", Math.round(minWeightImperial)) }}</td>
        </tr>
        <tr v-if="maxWeight">
          <th scope="row">Poids maximal</th>
          <td>{{ $n(maxWeight, "weight") }} {{ $t("unit.Kilogram", Math.floor(maxWeight)) }}</td>
          <td>{{ $n(maxWeightImperial, "integer") }} {{ $t("unit.Pound", Math.round(maxWeightImperial)) }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup lang="ts">
import type { Age, LineageBase, Size, Weight } from "~/types/lineages";

const props = defineProps<{
  lineage: LineageBase;
}>();

const classes = computed<string>(() => (size.value.roll ? "w-third" : "w-50"));

const size = computed<Size>(() => props.lineage.size);
const minHeight = computed<number>(() => {
  if (!size.value.roll) {
    return 0;
  }
  const parts: string[] = size.value.roll.split("+");
  const roll: string[] = parts[1].split("d");
  return (parseInt(parts[0]) + parseInt(roll[0])) / 100;
});
const minHeightImperial = computed<string>(() => {
  const feetInches: number[] = metersToFeetInches(minHeight.value);
  return [$n(feetInches[0], "integer"), $t("unit.Foot", feetInches[0]), $n(feetInches[1], "integer"), $t("unit.Inch", Math.round(feetInches[1]))].join(" ");
});
const maxHeight = computed<number>(() => {
  if (!size.value.roll) {
    return 0;
  }
  const parts: string[] = size.value.roll.split("+");
  const roll: string[] = parts[1].split("d");
  return (parseInt(parts[0]) + parseInt(roll[0]) * parseInt(roll[1])) / 100;
});
const maxHeightImperial = computed<string>(() => {
  const feetInches: number[] = metersToFeetInches(maxHeight.value);
  return [$n(feetInches[0], "integer"), $t("unit.Foot", feetInches[0]), $n(feetInches[1], "integer"), $t("unit.Inch", Math.round(feetInches[1]))].join(" ");
});

const weight = computed<Weight>(() => props.lineage.weight);
const minWeight = computed<number>(() => {
  if (!minHeight.value || !weight.value.skinny) {
    return 0;
  }
  const parts: string[] = weight.value.skinny.split("+");
  const roll: string[] = parts[1].split("d");
  return Math.round(minHeight.value * minHeight.value * (parseInt(parts[0]) + parseInt(roll[0])) * 10) / 10;
});
const minWeightImperial = computed<number>(() => kilogramsToPounds(minWeight.value));
const maxWeight = computed<number>(() => {
  if (!maxHeight.value || !weight.value.overweight) {
    return 0;
  }
  const parts: string[] = weight.value.overweight.split("+");
  const roll: string[] = parts[1].split("d");
  return Math.round(maxHeight.value * maxHeight.value * (parseInt(parts[0]) + parseInt(roll[0]) * parseInt(roll[1])) * 10) / 10;
});
const maxWeightImperial = computed<number>(() => kilogramsToPounds(maxWeight.value));

const age = computed<Age>(() => props.lineage.age);
</script>

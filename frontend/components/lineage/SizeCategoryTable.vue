<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" :class="classes">Catégorie de taille</th>
        <th v-if="showLoad" scope="col" :class="classes">Facteur de Charge</th>
        <template v-if="showSpace">
          <th scope="col" :class="classes">Espace occupé (carrés)</th>
          <th scope="col" :class="classes">Espace occupé (hexagones)</th>
        </template>
      </tr>
    </thead>
    <tbody>
      <tr v-for="size in sizes" :key="size.key">
        <td>{{ $t(`size.category.options.${size.key}`) }}</td>
        <td v-if="showLoad">{{ size.load ?? `×${getLoadMultiplier(size.key as SizeCategory)}` }}</td>
        <template v-if="showSpace">
          <td>{{ size.squares }}</td>
          <td>{{ size.hexes }}</td>
        </template>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { SizeCategory } from "~/types/game";

type Display = "load" | "space";
type Size = {
  key: string;
  load?: string;
  squares: string;
  hexes: string;
};

const props = defineProps<{
  display?: Display;
}>();

const sizes = ref<Size[]>([
  { key: "Diminutive", load: "×¼", squares: "¼", hexes: "¼" },
  { key: "Tiny", load: "×½", squares: "½", hexes: "½" },
  { key: "Small", squares: "1", hexes: "1" },
  { key: "Medium", squares: "1", hexes: "1" },
  { key: "Large", squares: "2 × 2 (4)", hexes: "3" },
  { key: "Huge", squares: "3 × 3 (9)", hexes: "7" },
  { key: "Gargantuan", squares: "4 × 4 (16)", hexes: "12" },
  { key: "Colossal", squares: "5 × 5 (25) et plus", hexes: "30 et plus" },
]);

const showLoad = computed<boolean>(() => typeof props.display === "undefined" || props.display === "load");
const showSpace = computed<boolean>(() => typeof props.display === "undefined" || props.display === "space");
const classes = computed<string[]>(() => {
  const classes: string[] = [];
  if (showLoad.value && showSpace.value) {
    classes.push("w-25");
  } else if (showLoad.value) {
    classes.push("w-50");
  } else if (showSpace.value) {
    classes.push("w-33");
  }
  return classes;
});
</script>

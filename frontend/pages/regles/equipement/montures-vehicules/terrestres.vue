<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Terrestres" :parent="parent" />
    <p>🚧</p>
    <ItemList :items="vehicles" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Item } from "~/types/items";
import { getVehicles } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Montures et véhicules", to: "/regles/equipement/montures-vehicules" },
];
const title: string = "Véhicules terrestres";
const { orderBy } = arrayUtils;

const vehicles = ref<Item[]>(orderBy(getVehicles(), "slug"));

useSeo({
  title,
  description: "🚧",
});
</script>

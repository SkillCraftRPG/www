<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <ItemList :items="clothing" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Item } from "~/types/items";
import { getClothingItems } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Général", to: "/regles/equipement/general" },
];
const title: string = "Vêtements";
const { orderBy } = arrayUtils;

const clothing = ref<Item[]>(orderBy(getClothingItems(), "slug"));

useSeo({
  title,
  description: "🚧",
});
</script>

<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Des instruments variés pour rythmer fêtes, voyages et récits épiques.</p>
    <ItemList :items="musicalInstruments" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Tool } from "~/types/items";
import { getTools } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Outils et trousses", to: "/regles/equipement/outils" },
];
const title: string = "Instruments de musique";
const { orderBy } = arrayUtils;

const tools = ref<Tool[]>(getTools());

const musicalInstruments = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category }) => category === "MusicalInstrument"),
    "slug",
  ),
);

useSeo({
  title,
  description: "Découvrez une collection d’instruments, des flûtes et tambours aux luths et cornemuses, pour animer vos aventures et cérémonies.",
});
</script>

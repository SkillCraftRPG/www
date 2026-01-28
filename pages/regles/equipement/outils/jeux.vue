<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Des jeux de société et d’adresse pour divertir voyageurs et aventuriers.</p>
    <ItemList :items="playingSets" />
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
const title: string = "Ensembles de jeu";
const { orderBy } = arrayUtils;

const tools = ref<Tool[]>(getTools());

const playingSets = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category }) => category === "PlayingSet"),
    "slug",
  ),
);

useSeo({
  title,
  description: "Découvrez une sélection de jeux comme les dés, échecs, dominos et tarots, pour animer vos soirées et vos voyages.",
});
</script>

<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Simples" :parent="parent" />
    <p>🚧</p>
    <!--
      TODO(fpion): liens vers les sections utiles
      * Attaque
      * Dégâts
      * Formation
      * Propriétés
    -->
    <ItemWeaponList :items="weapons" />
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Weapon } from "~/types/items";
import { getWeapons } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Armes simples";
const { orderBy } = arrayUtils;

const weapons = ref<Weapon[]>(
  orderBy(
    getWeapons().filter(({ category }) => category === "Simple"),
    "slug",
  ),
);

useSeo({
  title,
  description: "🚧",
});
</script>
